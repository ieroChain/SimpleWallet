using System;
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
    public partial class SplashScreen : Form
    {
        Start start = new Start();
        Executor exec = Executor.Instance;
        Api api = Api.Instance;
        EndScreen scr = EndScreen.Instance;

        BackgroundWorker startWallet = new BackgroundWorker();
        const String verifyingKey = "sprout-verifying.key";
        const String provingKey = "sprout-proving.key";

        bool veriStatus = false;
        bool provStatus = false;
        bool shouldRestart = false;
        String command = "";

        bool checkParamsDone = false;
        Dictionary<String, String> result = new Dictionary<String, String>();

        public SplashScreen()
        {
            InitializeComponent();

            exec.progressChange += Download_ProgressChange;
            exec.progressDone += Download_ProgressDone;
            exec.errorOccurs += ErrorOccurs;

            startWallet.WorkerSupportsCancellation = true;
            startWallet.DoWork += new DoWorkEventHandler(this.startWallet_DoWork);
            startWallet.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.startWallet_RunWorkerCompleted);

        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        void startWallet_RunWorkerCompleted(Object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (Api.checkResult(result))
            {
                this.Hide();
                start.ShowDialog();
                if (shouldRestart || start.shouldRestart == true)
                {
                    Task.Run(() => Application.Restart());
                }
                else
                    this.Close();
            }
            else
            {
                MessageBox.Show(Api.getMessage(result));
            }
        }

        void startWallet_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            beginning(e);

                Types.AllData dataimport = new Types.AllData();
                dataimport = api.getAllData();

                //connections
                start.connections = dataimport.connectionCount;
                
                //balance info
                start.privatebalance = dataimport.privatebalance;
                start.transparentbalance = dataimport.transparentbalance;
                start.totalbalance = dataimport.totalbalance;
                start.unconfirmedbalance = dataimport.unconfirmedbalance;
                start.privatebalanceunconfirmed = dataimport.privatebalanceunconfirmed;
                start.transparentbalanceunconfirmed = dataimport.transparentbalanceunconfirmed;
                start.totalbalanceunconfirmed = dataimport.totalbalanceunconfirmed;    

                //blockhash info
                start.bestHash = dataimport.bestblockhash;

                //bestblock time
                start.bestTime = dataimport.time;
                
                //transaction list
                start.listtransactions = dataimport.listtransactions;

                //Address List
                if (dataimport.addressbalance != null && dataimport.addressbalance.Count > 0)
                {
                    start.walletDic = new Dictionary<String, String>(dataimport.addressbalance[0]);
                }


        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            if (File.Exists(Types.startCommandsFile))
            {
                command = File.ReadAllText(Types.startCommandsFile);
                File.Delete(Types.startCommandsFile);
            }

            String walletDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
            "\\zero\\wallet.zero";

            if (!File.Exists(walletDir))
            {
                MessageBox.Show("Remember to backup your wallet.dat file and private keys before using the wallet", "ATTENTION!!!");
            }

            startWallet.RunWorkerAsync();
        }

        void beginning(System.ComponentModel.DoWorkEventArgs e)
        {
            api.checkConfig();
            String currStatus = "Checking params...";
            lbCurrentStatus.Invoke(new Action(() => lbCurrentStatus.Text = currStatus));
            bool downloadFile = exec.checkParamsFile(verifyingKey, provingKey);
            if (downloadFile)
            {
                pbProcess.Invoke(new Action(() => pbProcess.Visible = true));
                currStatus = "Downloading params";
                lbCurrentStatus.Invoke(new Action(() => lbCurrentStatus.Text = currStatus));
                downloadFile = Task.Run(() => exec.downloadParams(verifyingKey, Types.DownloadFileType.VERIFYING)).Result;
                if (!downloadFile)
                {
                    veriStatus = true;
                }
                downloadFile |= Task.Run(() => exec.downloadParams(provingKey, Types.DownloadFileType.PROVING)).Result;
                if (downloadFile)
                {
                    checkParamsDone = false;
                }
                else
                {
                    provStatus = true;
                }
            }
            else
            {
                veriStatus = true;
                provStatus = true;
                checkParamsDone = true;
                if (start.isEnableAutoBackup())
                    command += " -backupwallet";
                Task.Run(() =>
                        api.startWallet(command));
            }
            Thread.Sleep(1000);
            int countdot = 0;
            while (true)
            {
                if (e.Cancel)
                {
                    break;
                }
                if (checkParamsDone)
                {
                    Dictionary<String, String> data = api.checkWallet();
                    if (Api.checkResult(data))
                    {
                        if (Api.getResult(data) == "success")
                        {
                            break;
                        }
                        else if (Api.getResult(data) == "fail")
                        {
                            currStatus = data["message"];
                        }
                        else
                        {
                            currStatus = data["message"];
                        }
                    }
                }
                else
                {
                    if (countdot < 3)
                    {
                        currStatus = "Downloading params";
                    }
                    else if (countdot < 6)
                    {
                        currStatus = "Downloading params.";
                    }
                    else if (countdot < 9)
                    {
                        currStatus = "Downloading params..";
                    }
                    else if (countdot < 12)
                    {
                        currStatus = "Downloading params...";
                    }
                    else
                    {
                        countdot = 0;
                    }
                }
                lbCurrentStatus.Invoke(new Action(() => lbCurrentStatus.Text = currStatus));
                countdot++;

                Thread.Sleep(200);
            }
        }


        void ErrorOccurs(object sender, DeamonErrorEventArgs e)
        {
            if (!e.errMessage.Contains("Zero is probably already running"))
            {
                api.stopWallet();

                if (e.errMessage.Contains("-reindex"))
                {
                    MessageBox.Show("Your data need reindex", "Error!!!");
                    shouldRestart = true;
                    File.WriteAllText(Types.startCommandsFile, "-reindex");
                }
                MessageBox.Show(e.errMessage, "Error!!!");
                this.Invoke(new Action(() => this.Close()));
            }
        }

        void Download_ProgressChange(object sender, ReceivedDataEventArgs e)
        {
            pbProcess.Invoke(new Action(() => pbProcess.Value = e.progress * 100));   
        }

        void pbIncrease()
        {
            pbProcess.Invoke(new Action(() =>
                {
                    if (pbProcess.Value + 100 >= pbProcess.Maximum)
                        pbProcess.Value = 0;
                    pbProcess.Value += 100;
                }));   
        }

        void Download_ProgressDone(object sender, ReceivedDataEventArgs e)
        {
            if(!e.isCancel && e.fileName == verifyingKey)
            {
                veriStatus = true;
            }
            else if(!e.isCancel && e.fileName == provingKey)
            {
                provStatus = true;
            }
            if (veriStatus && provStatus)
            {
                checkParamsDone = true;
                if (start.isEnableAutoBackup())
                    command += " -backupwallet";
                Task.Run(() =>
                    api.startWallet(command));
            }

            if(e.isCancel)
            {
                startWallet.CancelAsync();
            }
        }

        private void pbProcess_MouseHover(object sender, EventArgs e)
        {
            //toolt
        }

        private void SplashScreen_FormClosed(object sender, FormClosedEventArgs e)
        {

        }


    }
}
