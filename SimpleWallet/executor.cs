﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace SimpleWallet
{
    class Executor
    {
        Types type = new Types();
        String daemond = "zerod.exe";
        String cli = "zero-cli.exe";
        const String verifyingKey = "sprout-verifying.key";
        const String provingKey = "sprout-proving.key";
        const String groth16Key = "sprout-groth16.params";
        const String saplingSpend = "sapling-spend.params";
        const String saplingOutput = "sapling-output.params";
        String dataToGetSync = "";
        String getResultSync = "";
        String dataToGetBalance = "";
        String getResultBalance = "";
        String dataToGetOthers = "";
        String getResultOthers = "";
        String dataToGetMasternode = "";
        String getResultMasternode = "";
        String getResultDaemond = "";
        String dataToGetTransaction = "";
        String getResultGetTransaction = "";

        //bool error = false;
        bool isClosedDeamon = true;

        public event ReceivedDataEventHandler progressChange;
        public event ReceivedDataEventHandler progressDone;
        public event DeamonErrorEventHandler errorOccurs;
        public event DaemonEventHandler daemondHdl;

        private static Executor instance = null;
        private static readonly object padlock = new object();

        Executor()
        {
        }

        public static Executor Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Executor();
                        }
                    }
                }
                return instance;
            }
        }

        public bool getDeamondClosedStatus()
        {
            return isClosedDeamon;
        }

        void executeCommand(List<String> args, Types.OutputType type)
        {
            ProcessStartInfo ProcessInfo;
            String command = "";
            if (type == Types.OutputType.DAEMOND)
            {
                command = daemond;
            }
            else
            {
                command = cli;
            }
            foreach(String arg in args)
            {
                if (!String.IsNullOrEmpty(arg))
                {
                    command += " " + arg;
                }
            }
            try
            {
                Process process = new System.Diagnostics.Process();
                ProcessInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
                ProcessInfo.CreateNoWindow = true;
                ProcessInfo.UseShellExecute = false;
                ProcessInfo.RedirectStandardError = true;
                ProcessInfo.RedirectStandardOutput = true;
                process.StartInfo = ProcessInfo;
                process.EnableRaisingEvents = true;
                if (type == Types.OutputType.DAEMOND)
                {
                    process.OutputDataReceived += new DataReceivedEventHandler(this.outputHandlerDaemond);
                    process.ErrorDataReceived += new DataReceivedEventHandler(this.outputHandlerDaemond);
                }
                if (type == Types.OutputType.SYNC)
                {
                    process.OutputDataReceived += new DataReceivedEventHandler(this.outputHandlerSync);
                    process.ErrorDataReceived += new DataReceivedEventHandler(this.outputHandlerSync);
                }
                else if (type == Types.OutputType.BALANCE)
                {
                    process.OutputDataReceived += new DataReceivedEventHandler(this.outputHandlerBalance);
                    process.ErrorDataReceived += new DataReceivedEventHandler(this.outputHandlerBalance);
                }
                else if (type == Types.OutputType.MASTERNODE)
                {
                    process.OutputDataReceived += new DataReceivedEventHandler(this.outputHandlerMasternode);
                    process.ErrorDataReceived += new DataReceivedEventHandler(this.outputHandlerMasternode);
                }
                else if (type == Types.OutputType.OTHERS)
                {
                    process.OutputDataReceived += new DataReceivedEventHandler(this.outputHandlerOthers);
                    process.ErrorDataReceived += new DataReceivedEventHandler(this.outputHandlerOthers);
                }
                else if(type == Types.OutputType.GET_TRANSACTION)
                {
                    process.OutputDataReceived += new DataReceivedEventHandler(this.outputHandlerGetTransaction);
                    process.ErrorDataReceived += new DataReceivedEventHandler(this.outputHandlerGetTransaction);
                }
                process.Start();
                process.BeginErrorReadLine();
                process.BeginOutputReadLine();
                process.WaitForExit();
                if(type == Types.OutputType.DAEMOND)
                {
                    OnDaemonStatus(new DaemonEventArgs(true));
                }
            }
            catch 
            {

            }
        }

        void outputHandlerDaemond(Object sender, DataReceivedEventArgs e)
        {
            // Prepend line numbers to each line of the output.
            if (!String.IsNullOrEmpty(e.Data))
            {
                if (String.IsNullOrEmpty(getResultBalance))
                {
                    getResultDaemond += e.Data;
                }
                else
                {
                    getResultDaemond += "\n" + e.Data;
                } 
            }
        }

        void outputHandlerSync(Object sender, DataReceivedEventArgs e)
        {
            // Prepend line numbers to each line of the output.
            if (!String.IsNullOrEmpty(e.Data))
            {
                if (e.Data.Contains(dataToGetBalance))
                {
                    if (String.IsNullOrEmpty(getResultBalance))
                    {
                        getResultSync += e.Data;
                    }
                    else
                    {
                        getResultSync += "\n" + e.Data;
                    }
                }
            }
        }

        void outputHandlerBalance(Object sender, DataReceivedEventArgs e)
        {
            // Prepend line numbers to each line of the output.
            if (!String.IsNullOrEmpty(e.Data))
            {
                if (e.Data.Contains(dataToGetBalance))
                {
                    if (String.IsNullOrEmpty(getResultBalance))
                    {
                        getResultBalance += e.Data;
                    }
                    else
                    {
                        getResultBalance += "\n" + e.Data;
                    }
                }
            }
        }

        void outputHandlerMasternode(Object sender, DataReceivedEventArgs e)
        {
            // Prepend line numbers to each line of the output.
            if (!String.IsNullOrEmpty(e.Data))
            {
                if (e.Data.Contains(dataToGetMasternode))
                {
                    if (String.IsNullOrEmpty(getResultMasternode))
                    {
                        getResultMasternode += e.Data;
                    }
                    else
                    {
                        getResultMasternode += "\n" + e.Data;
                    }
                }
            }
        }

        void outputHandlerOthers(Object sender, DataReceivedEventArgs e)
        {
            // Prepend line numbers to each line of the output.
            if (!String.IsNullOrEmpty(e.Data))
            {
                if (e.Data.Contains(dataToGetOthers))
                {
                    if (String.IsNullOrEmpty(getResultOthers))
                    {
                        getResultOthers += e.Data;
                    }
                    else
                    {
                        getResultOthers += "\n" + e.Data;
                    }
                }
            }
        }

        void outputHandlerGetTransaction(Object sender, DataReceivedEventArgs e)
        {
            // Prepend line numbers to each line of the output.
            if (!String.IsNullOrEmpty(e.Data))
            {
                if (e.Data.Contains(dataToGetTransaction))
                {
                    if (String.IsNullOrEmpty(getResultGetTransaction))
                    {
                        getResultGetTransaction += e.Data;
                    }
                    else
                    {
                        getResultGetTransaction += "\n" + e.Data;
                    }
                }
            }
        }

        public String executeStart(String command)
        {
            String exportDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            List<String> args = new List<String> { command, " -exportdir=\"" + exportDir + "\"" };
            executeCommand(args, Types.OutputType.DAEMOND);
            if(!String.IsNullOrEmpty(getResultDaemond))
            {
                OnErrorOccurs(new DeamonErrorEventArgs(getResultDaemond));
            }
            return getResultDaemond;
        }

        public void executeStop()
        {
            String exportDir = Directory.GetCurrentDirectory();
            exportDir = exportDir.Split('\\')[0];
            List<String> args = new List<String> { "stop" };
            executeCommand(args, Types.OutputType.OTHERS);
        }

        public String executeSync(List<String> command, String dataToGet)
        {
            dataToGetSync = dataToGet;
            getResultSync = "";
            executeCommand(command, Types.OutputType.SYNC);
            return getResultSync;
        }

        public String executeBalance(List<String> command, String dataToGet)
        {
            dataToGetBalance = dataToGet;
            getResultBalance = "";
            executeCommand(command, Types.OutputType.BALANCE);
            return getResultBalance;
        }

        public String executeGetTransaction(List<String> command, String dataToGet)
        {
            dataToGetTransaction = dataToGet;
            getResultGetTransaction = "";
            executeCommand(command, Types.OutputType.GET_TRANSACTION);
            return getResultGetTransaction;
        }
        

        public String executeOthers(List<String> command, String dataToGet)
        {
            dataToGetOthers = dataToGet;
            getResultOthers = "";
            executeCommand(command, Types.OutputType.OTHERS);
            return getResultOthers;
        }

        public String executeMasternode(List<String> command, String dataToGet)
        {
            dataToGetMasternode = dataToGet;
            getResultMasternode = "";
            executeCommand(command, Types.OutputType.MASTERNODE);
            return getResultMasternode;
        }
        
        public bool checkParamsFile(String file1, String file2, String file3, String file4, String file5)
        {
            bool ret = false;
            String webLink = "https://download.z.cash/downloads/";
            String file1Link = webLink + file1;
            String file2Link = webLink + file2;
            String file3Link = webLink + file3;
            String file4Link = webLink + file4;
            String file5Link = webLink + file5;
            String appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            String file1Loc = appdata + "\\ZcashParams\\" + file1;
            String file2Loc = appdata + "\\ZcashParams\\" + file2;
            String file3Loc = appdata + "\\ZcashParams\\" + file3;
            String file4Loc = appdata + "\\ZcashParams\\" + file4;
            String file5Loc = appdata + "\\ZcashParams\\" + file5;
            Int64 length = 0;
            WebClient wc = new WebClient();
            Stream response = null;
            if (!Directory.Exists(appdata + "\\ZcashParams"))
            {
                Directory.CreateDirectory(appdata + "\\ZcashParams");
                return true;
            }
            if (!File.Exists(file1Loc) || !File.Exists(file2Loc) || !File.Exists(file3Loc) || !File.Exists(file4Loc) || !File.Exists(file5Loc))
            {
                return true;
            }

            try
            {
                response = wc.OpenRead(new System.Uri(file1Link));
                length = new System.IO.FileInfo(file1Loc).Length;
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Int64 bytes_total = Convert.ToInt64(wc.ResponseHeaders["Content-Length"]);
            
            if (bytes_total != length)
            {
                ret = true;
            }



            try
            {
                response = wc.OpenRead(new System.Uri(file2Link));
                length = new System.IO.FileInfo(file2Loc).Length;
                response.Close();
            }
            catch 
            {
                
            }
            bytes_total = Convert.ToInt64(wc.ResponseHeaders["Content-Length"]);

            if (bytes_total != length)
            {
                ret = true;
            }
            

            try
            {
                response = wc.OpenRead(new System.Uri(file3Link));
                length = new System.IO.FileInfo(file3Loc).Length;
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            bytes_total = Convert.ToInt64(wc.ResponseHeaders["Content-Length"]);

            if (bytes_total != length)
            {
                ret = true;
            }

            try
            {
                response = wc.OpenRead(new System.Uri(file4Link));
                length = new System.IO.FileInfo(file4Loc).Length;
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            bytes_total = Convert.ToInt64(wc.ResponseHeaders["Content-Length"]);

            if (bytes_total != length)
            {
                ret = true;
            }

            try
            {
                response = wc.OpenRead(new System.Uri(file5Link));
                length = new System.IO.FileInfo(file5Loc).Length;
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            bytes_total = Convert.ToInt64(wc.ResponseHeaders["Content-Length"]);

            if (bytes_total != length)
            {
                ret = true;
            }

            return ret;
        }

        public bool downloadParams(String file, Types.DownloadFileType downloadType)
        {
            bool shouldDownload = false;
            String webLink = "https://z.cash/downloads/";
            String fileLink = webLink + file;
            String appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            String fileLoc = appdata + "\\ZcashParams\\" + file;
            Int64 length = 0;
            WebClient wc = new WebClient();
            Stream response = null;
            Int64 bytes_total = 0;

            try
            {
                response = wc.OpenRead(new System.Uri(fileLink));
                bytes_total = Convert.ToInt64(wc.ResponseHeaders["Content-Length"]);
                response.Close();
                length = new System.IO.FileInfo(fileLoc).Length;
            }
            catch
            {
               
            }

            if(bytes_total != length)
            {
                shouldDownload = true;
            }

            if(shouldDownload)
            {
                if(downloadType == Types.DownloadFileType.PROVING)
                {
                    wc.DownloadProgressChanged += proving_DownloadProgressChanged;
                    wc.DownloadFileCompleted += proving_DownloadFileCompleted;
                }
                else if (downloadType == Types.DownloadFileType.VERIFYING)
                {
                    wc.DownloadProgressChanged += verifying_DownloadProgressChanged;
                    wc.DownloadFileCompleted += verifying_DownloadFileCompleted;
                }
                else if (downloadType == Types.DownloadFileType.GROTH)
                {
                    wc.DownloadProgressChanged += groth_DownloadProgressChanged;
                    wc.DownloadFileCompleted += groth_DownloadFileCompleted;
                }
                else if (downloadType == Types.DownloadFileType.SPEND)
                {
                    wc.DownloadProgressChanged += spend_DownloadProgressChanged;
                    wc.DownloadFileCompleted += spend_DownloadFileCompleted;
                }
                else if (downloadType == Types.DownloadFileType.OUTPUT)
                {
                    wc.DownloadProgressChanged += output_DownloadProgressChanged;
                    wc.DownloadFileCompleted += output_DownloadFileCompleted;
                }
                wc.DownloadFileAsync(new System.Uri(fileLink), appdata + "\\ZcashParams\\" + file, true);
            }
            return shouldDownload;
        }

        protected void OnDaemonStatus(DaemonEventArgs e)
        {
            if (daemondHdl != null)
                daemondHdl(this, e);
        }

        protected void OnErrorOccurs(DeamonErrorEventArgs e)
        {
            if (errorOccurs != null)
                errorOccurs(this, e);
        }  

        protected void OnProgressChange(ReceivedDataEventArgs e)
        {
            if (progressChange != null)
                progressChange(this, e);
        }

        protected void OnProgressDone(ReceivedDataEventArgs e)
        {
            if (progressDone != null)
                progressDone(this, e);
        }  

        void verifying_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                OnProgressDone(new ReceivedDataEventArgs(true, 100, true, verifyingKey));
            }
            else
            {
                OnProgressDone(new ReceivedDataEventArgs(false, 100, false, verifyingKey));
            }
        }

        void verifying_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            OnProgressChange(new ReceivedDataEventArgs(false, e.ProgressPercentage, false, verifyingKey));
        }

        void proving_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                OnProgressDone(new ReceivedDataEventArgs(true, 100, true, provingKey));
            }
            else
            {
                OnProgressDone(new ReceivedDataEventArgs(false, 100, false, provingKey));
            }
        }

        void proving_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            OnProgressChange(new ReceivedDataEventArgs(false, e.ProgressPercentage, false, provingKey));
        }

        void groth_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                OnProgressDone(new ReceivedDataEventArgs(true, 100, true, groth16Key));
            }
            else
            {
                OnProgressDone(new ReceivedDataEventArgs(false, 100, false, groth16Key));
            }
        }

        void groth_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            OnProgressChange(new ReceivedDataEventArgs(false, e.ProgressPercentage, false, groth16Key));
        }

        void spend_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                OnProgressDone(new ReceivedDataEventArgs(true, 100, true, saplingSpend));
            }
            else
            {
                OnProgressDone(new ReceivedDataEventArgs(false, 100, false, saplingSpend));
            }
        }

        void spend_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            OnProgressChange(new ReceivedDataEventArgs(false, e.ProgressPercentage, false, saplingSpend));
        }

        void output_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                OnProgressDone(new ReceivedDataEventArgs(true, 100, true, saplingOutput));
            }
            else
            {
                OnProgressDone(new ReceivedDataEventArgs(false, 100, false, saplingOutput));
            }
        }

        void output_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            OnProgressChange(new ReceivedDataEventArgs(false, e.ProgressPercentage, false, saplingOutput));
        }
    }
}
