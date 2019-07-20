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
        const String groth16Key = "sprout-groth16.params";
        const String saplingSpend = "sapling-spend.params";
        const String saplingOutput = "sapling-output.params";

        bool veriStatus = false;
        bool provStatus = false;
        bool grothStatus = false;
        bool spendStatus = false;
        bool outputStatus = false;
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

                //get data
                String data = api.getAllData(Types.GetAllDataType.ALL, 200);
                dynamic parse = JsonConvert.DeserializeObject<Types.AllData>(data);

                //Info
                start.bestHash = parse.bestblockhash;
                start.bestTime = parse.besttime;
                start.connections = parse.connectionCount;

                //Balance Info
                start.totalbalance = parse.totalbalance;
                start.totalbalanceunconfirmed = parse.totalunconfirmed;
                start.unconfirmedbalance = parse.totalunconfirmed;
                start.privatebalance = parse.privatebalance;
                start.privatebalanceunconfirmed = parse.privatebalanceunconfirmed;
                start.lockedbalance = parse.lockedbalance;
                start.transparentbalance = parse.transparentbalance;
                start.transparentbalanceunconfirmed = parse.transparentbalanceunconfirmed;
                start.immaturebalance = parse.immaturebalance;

                //Addresses and transactions
                start.listtransactions = api.convertTransactionList(parse.listtransactions);
                List<Dictionary<String, Types.AllDataAddress>> addressbalance = parse.addressbalance;
                if (addressbalance != null && addressbalance.Count > 0)
                {
                    start.walletDic = new Dictionary<String, Types.AllDataAddress>(addressbalance[0]);
                }


        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            if (File.Exists(Types.startCommandsFile))
            {
                command = File.ReadAllText(Types.startCommandsFile);
                File.Delete(Types.startCommandsFile);

            }
            else
            {
                String appPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                    "\\zero\\simplewallet\\";
                System.IO.Directory.CreateDirectory(appPath);
            }

            String walletDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
            "\\zero\\wallet.zero";

            if (!File.Exists(walletDir))
            {
                MessageBox.Show("Remember to backup your wallet.zero file and private keys before using the wallet", "ATTENTION!!!");
            }

            startWallet.RunWorkerAsync();
        }

        void beginning(System.ComponentModel.DoWorkEventArgs e)
        {
            api.checkConfig();
            String currStatus = "Checking params...";
            lbCurrentStatus.Invoke(new Action(() => lbCurrentStatus.Text = currStatus));
            bool downloadFile = exec.checkParamsFile(verifyingKey, provingKey, groth16Key, saplingSpend, saplingOutput);
            if (downloadFile)
            {
                lblVerifing.Invoke(new Action(() => lblVerifing.Visible = true));
                lblProving.Invoke(new Action(() => lblProving.Visible = true));
                lblGroth.Invoke(new Action(() => lblGroth.Visible = true));
                lblSpend.Invoke(new Action(() => lblSpend.Visible = true));
                lblOutput.Invoke(new Action(() => lblOutput.Visible = true));

                pbProcess.Invoke(new Action(() => pbProcess.Visible = true));
                pbProving.Invoke(new Action(() => pbProving.Visible = true));
                pbGroth.Invoke(new Action(() => pbGroth.Visible = true));
                pbSpend.Invoke(new Action(() => pbSpend.Visible = true));
                pbOutput.Invoke(new Action(() => pbOutput.Visible = true));
                currStatus = "Downloading params";
                lbCurrentStatus.Invoke(new Action(() => lbCurrentStatus.Text = currStatus));
                
                downloadFile = Task.Run(() => exec.downloadParams(verifyingKey, Types.DownloadFileType.VERIFYING)).Result;
                if (!downloadFile)
                {
                    pbProcess.Invoke(new Action(() => pbProcess.Value = 100 * 100));
                    veriStatus = true;
                }

                downloadFile = Task.Run(() => exec.downloadParams(provingKey, Types.DownloadFileType.PROVING)).Result;
                if (!downloadFile)
                {
                    pbProving.Invoke(new Action(() => pbProving.Value = 100 * 100));
                    provStatus = true;
                }

                downloadFile = Task.Run(() => exec.downloadParams(groth16Key, Types.DownloadFileType.GROTH)).Result;
                if (!downloadFile)
                {
                    pbGroth.Invoke(new Action(() => pbGroth.Value = 100 * 100));
                    grothStatus = true;
                }
                
                downloadFile = Task.Run(() => exec.downloadParams(saplingSpend, Types.DownloadFileType.SPEND)).Result;
                if (!downloadFile)
                {
                    pbSpend.Invoke(new Action(() => pbSpend.Value = 100 * 100));
                    spendStatus = true;
                }

                downloadFile = Task.Run(() => exec.downloadParams(saplingOutput, Types.DownloadFileType.OUTPUT)).Result;
                if (!downloadFile)
                {
                    pbOutput.Invoke(new Action(() => pbOutput.Value = 100 * 100));
                    outputStatus = true;
                }

                if (veriStatus && provStatus && grothStatus && spendStatus && outputStatus)
                {
                    checkParamsDone = true;
                }
                else
                {
                    checkParamsDone = false;
                }

            }
            else
            {
                veriStatus = true;
                provStatus = true;
                grothStatus = true;
                outputStatus = true;
                spendStatus = true;
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
            
            switch (e.fileName)
              {
                case verifyingKey:
                      pbProcess.Invoke(new Action(() => pbProcess.Value = e.progress * 100));
                      break;
                case provingKey:
                      pbProving.Invoke(new Action(() => pbProving.Value = e.progress * 100));
                      break;
                case groth16Key:
                      pbGroth.Invoke(new Action(() => pbGroth.Value = e.progress * 100));
                      break;
                case saplingSpend:
                      pbSpend.Invoke(new Action(() => pbSpend.Value = e.progress * 100));
                      break;
                case saplingOutput:
                      pbOutput.Invoke(new Action(() => pbOutput.Value = e.progress * 100));
                      break;
              }
             

            
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
            
            if(!e.isCancel && e.fileName == provingKey)
            {
                provStatus = true;
            }
            
            if (!e.isCancel && e.fileName == groth16Key)
            {
                grothStatus = true;
            }
            
            if (!e.isCancel && e.fileName == saplingSpend)
            {
                spendStatus = true;
            }
            
            if (!e.isCancel && e.fileName == saplingOutput)
            {
                outputStatus = true;
            }
            if (veriStatus && provStatus && grothStatus && spendStatus && outputStatus)
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

        private void transparentLabel1_Click(object sender, EventArgs e)
        {

        }


    }
}
