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
using System.Runtime.InteropServices;
using System.Timers;

namespace SimpleWallet
{

    public partial class Start : Form
    {
        EndScreen scr = EndScreen.Instance;

        public String bestTime = "";
        public String bestHash = "";
        public String connections = "";
        public String totalbalance = "";
        public String totalbalanceunconfirmed = "";
        public String unconfirmedbalance = "";
        public String privatebalance = "";
        public String privatebalanceunconfirmed = "";
        public String transparentbalance = "";
        public String transparentbalanceunconfirmed = "";
        public String lockedbalance = "";
        public String immaturebalance = "";
        String masternodeText = "";
        public static bool shouldDeleteMNCache = false;
        public List<String> addressBalanceChange = new List<String>();
        public List<Types.Transaction> listtransactions = new List<Types.Transaction>();
        List<Types.TransactionConverted> txconvert = new List<Types.TransactionConverted>();
        List<Types.Masternode> mn = new List<Types.Masternode>();
        public static String privKey = "";
        const int startTime = 1487462548;
        int numConnection = 0;
        int bestHeight = 0;
        Object lockObj = new Object();
        bool canClose = false;
        public bool shouldRestart = false;
        bool shouldGetTransaction = false;
        bool shouldGetWallet = false;
        bool shouldUpdateMN = false;
        String outImg = "Images\\outboundred.png";
        String inImg = "Images\\inboundgreen.png";
        System.Timers.Timer closeTmr = new System.Timers.Timer(5000);

        Dictionary<String, Types.AllDataAddress> oldWalletDic = new Dictionary<String, Types.AllDataAddress>();
        public Dictionary<String, Types.AllDataAddress> walletDic = new Dictionary<String, Types.AllDataAddress>();
        List<String> oldTransactions = new List<String>();
        List<String> transactions = new List<String>();
        WebClient proving = new WebClient();
        WebClient verifying = new WebClient();

        List<Types.AddressBook> book = new List<Types.AddressBook>();

        bool isAuto = false;
        bool isMNChange = false;
        Types.RightClickData rightClick = new Types.RightClickData();
        List<String> oldTx = new List<String>();
        Api api = Api.Instance;
        Types type = new Types();

        public Start()
        {
            InitializeComponent();

            dtgWalletInfo.ColumnCount = 2;
            dtgWalletInfo.RowHeadersVisible = false;
            dtgWalletInfo.Columns[0].Name = "Type";
            dtgWalletInfo.Columns[0].Width = dtgWalletInfo.Width * 500 / 1000;
            dtgWalletInfo.Columns[0].ReadOnly = true;
            dtgWalletInfo.Columns[1].Name = "Information";
            dtgWalletInfo.Columns[1].Width = dtgWalletInfo.Width * 500 / 1000;
            dtgWalletInfo.Columns[1].ReadOnly = true;
            dtgWalletInfo.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dtgWalletInfo.DoubleBuffered(true);

            dtgZeroNode.ColumnCount = 2;
            dtgZeroNode.RowHeadersVisible = false;
            dtgZeroNode.Columns[0].Name = "Type";
            dtgZeroNode.Columns[0].Width = dtgZeroNode.Width * 500 / 1000;
            dtgZeroNode.Columns[0].ReadOnly = true;
            dtgZeroNode.Columns[1].Name = "Information";
            dtgZeroNode.Columns[1].Width = dtgZeroNode.Width * 500 / 1000;
            dtgZeroNode.Columns[1].ReadOnly = true;
            dtgZeroNode.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dtgZeroNode.DoubleBuffered(true);

            dtgAddress.ColumnCount = 5;
            dtgAddress.RowHeadersVisible = false;
            dtgAddress.Columns[0].Name = "Address";
            dtgAddress.Columns[0].Width = dtgAddress.Width * 500 / 1000;
            dtgAddress.Columns[0].ReadOnly = true;
            dtgAddress.Columns[1].Name = "Confirmed";
            dtgAddress.Columns[1].Width = dtgAddress.Width * 125 / 1000;
            dtgAddress.Columns[1].ReadOnly = true;
            dtgAddress.Columns[2].Name = "Unconfirmed";
            dtgAddress.Columns[2].Width = dtgAddress.Width * 125 / 1000;
            dtgAddress.Columns[2].ReadOnly = true;
            dtgAddress.Columns[3].Name = "Immature";
            dtgAddress.Columns[3].Width = dtgAddress.Width * 125 / 1000;
            dtgAddress.Columns[3].ReadOnly = true;
            dtgAddress.Columns[4].Name = "Locked";
            dtgAddress.Columns[4].Width = dtgAddress.Width * 125 / 1000;
            dtgAddress.Columns[4].ReadOnly = true;
            dtgAddress.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dtgAddress.DoubleBuffered(true);

            dtgTransactions.RowHeadersVisible = false;
            dtgTransactions.Columns[0].HeaderText = "Direction";
            dtgTransactions.Columns[0].Width = dtgTransactions.Width / 10;
            dtgTransactions.Columns[0].ReadOnly = true;
            dtgTransactions.Columns[1].HeaderText = "Confirmed?";
            dtgTransactions.Columns[1].Width = dtgTransactions.Width / 10;
            dtgTransactions.Columns[1].ReadOnly = true;
            dtgTransactions.Columns[2].HeaderText = "Amount";
            dtgTransactions.Columns[2].Width = dtgTransactions.Width * 2 / 10;
            dtgTransactions.Columns[2].ReadOnly = true;
            dtgTransactions.Columns[3].HeaderText = "Date";
            dtgTransactions.Columns[3].Width = dtgTransactions.Width * 2 / 10;
            dtgTransactions.Columns[3].ReadOnly = true;
            dtgTransactions.Columns[4].HeaderText = "Send to";
            dtgTransactions.Columns[4].Width = dtgTransactions.Width * 4 / 10;
            dtgTransactions.Columns[4].ReadOnly = true;
            dtgTransactions.Columns[5].HeaderText = "Txid";
            dtgTransactions.Columns[5].Width = dtgTransactions.Width * 4 / 10;
            dtgTransactions.Columns[5].ReadOnly = true;
            dtgTransactions.Columns[5].Visible = false;
            dtgTransactions.DoubleBuffered(true);

            dtgMasternode.RowHeadersVisible = false;
            dtgMasternode.Columns[0].HeaderText = "Status";
            //dtgMasternode.Columns[0].Width = dtgMasternode.Width * 1 / 10;
            //dtgMasternode.Columns[0].ReadOnly = true;
            dtgMasternode.Columns[1].HeaderText = "Alias";
            //dtgMasternode.Columns[1].Width = dtgMasternode.Width * 1 / 10;
            //dtgMasternode.Columns[1].ReadOnly = true;
            dtgMasternode.Columns[2].HeaderText = "IP Address";
            //dtgMasternode.Columns[2].Width = dtgMasternode.Width * 3 / 2 / 10;
            //dtgMasternode.Columns[2].ReadOnly = true;
            dtgMasternode.Columns[3].HeaderText = "Private Key";
            //dtgMasternode.Columns[3].Width = dtgMasternode.Width * 5 / 2 / 10;
            //dtgMasternode.Columns[3].ReadOnly = true;
            dtgMasternode.Columns[4].HeaderText = "Transaction ID";
            //dtgMasternode.Columns[4].Width = dtgMasternode.Width * 3 / 10;
            //dtgMasternode.Columns[4].ReadOnly = true;
            dtgMasternode.Columns[5].HeaderText = "Index ID";
            //dtgMasternode.Columns[5].Width = dtgMasternode.Width - dtgMasternode.Width * (3 / 5 + 3 / 10);
            //dtgMasternode.Columns[5].ReadOnly = true;
            dtgMasternode.DoubleBuffered(true);

            for (int i = 0; i <= dtgMasternode.Columns.Count - 1; i++)
            {
                dtgMasternode.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgMasternode.Columns[i].ReadOnly = true;
            }

            dtgGlobalMN.Columns[0].HeaderText = "Rank";
            //dtgGlobalMN.Columns[0].Width = dtgGlobalMN.Width * 1 / 18;
            //dtgGlobalMN.Columns[0].ReadOnly = true;
            dtgGlobalMN.Columns[1].HeaderText = "Address";
            //dtgGlobalMN.Columns[1].Width = dtgGlobalMN.Width * 3 / 20;
            //dtgGlobalMN.Columns[1].ReadOnly = true;
            dtgGlobalMN.Columns[2].HeaderText = "Version";
            //dtgGlobalMN.Columns[2].Width = dtgGlobalMN.Width * 7 / 10 / 10;
            //dtgGlobalMN.Columns[2].ReadOnly = true;
            dtgGlobalMN.Columns[3].HeaderText = "Status";
            //dtgGlobalMN.Columns[3].Width = dtgGlobalMN.Width * 1 / 10;
            //dtgGlobalMN.Columns[3].ReadOnly = true;
            dtgGlobalMN.Columns[4].HeaderText = "Active";
            //dtgGlobalMN.Columns[4].Width = dtgGlobalMN.Width * 3 / 2 / 10;
            //dtgGlobalMN.Columns[4].ReadOnly = true;
            dtgGlobalMN.Columns[5].HeaderText = "Last seen";
            //dtgGlobalMN.Columns[5].Width = dtgGlobalMN.Width * 3 / 2 / 10;
            //dtgGlobalMN.Columns[5].ReadOnly = true;
            dtgGlobalMN.Columns[6].HeaderText = "Last paid";
            //dtgGlobalMN.Columns[6].Width = dtgGlobalMN.Width * 3 / 2 / 10;
            //dtgGlobalMN.Columns[6].ReadOnly = true;
            dtgGlobalMN.Columns[7].HeaderText = "Transaction ID";
            //dtgGlobalMN.Columns[7].Width = dtgGlobalMN.Width * 43 / 10 / 10;
            //dtgGlobalMN.Columns[7].ReadOnly = true;
            dtgGlobalMN.Columns[8].HeaderText = "IP address";
            //dtgGlobalMN.Columns[8].Width = dtgGlobalMN.Width * 1 / 8;
            //dtgGlobalMN.Columns[8].ReadOnly = true;
            dtgGlobalMN.RowHeadersVisible = false;
            dtgGlobalMN.DoubleBuffered(true);

            for (int i = 0; i <= dtgGlobalMN.Columns.Count - 1; i++)
            {
                dtgGlobalMN.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtgGlobalMN.Columns[i].ReadOnly = true;
            }

            cbUnit.SelectedIndex = 0;
            //groupBox1.Enabled = false;
            //groupBox1.Hide();
            

        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
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

        private void Start_Load(object sender, EventArgs e)
        {
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new TestColorTable());

            closeTmr.Elapsed += new ElapsedEventHandler(HandleTimerElapsed);
            closeTmr.Start();

            lbBestHash.Invoke(new Action(() => lbBestHash.Text = bestHash));

            //block time
            String curr = bestTime;
            if (!String.IsNullOrEmpty(curr))
            {
                DateTime blkTime = UnixTimeStampToDateTime(Convert.ToInt32(curr));
                String temp = blkTime.ToString("yyyy/MM/dd HH:mm:ss");
                Task.Factory.StartNew(() => { lbBestHash.Invoke(new Action(() => lbBestTime.Text = temp)); });
                int time = Convert.ToInt32(curr);
                int unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                int sub = time - startTime;
                int total = unixTimestamp - startTime;
                int percent = (int)((float)sub / (float)total * 10000);
                if (percent > 9998)
                {
                    pbPercent.Invoke(new Action(() => pbPercent.Value = pbPercent.Maximum));
                    Task.Factory.StartNew(() => { pbStatus.Invoke(new Action(() => pbStatus.BackgroundImage = SimpleWallet.Properties.Resources.synced)); });
                }
                else
                {
                    pbPercent.Invoke(new Action(() => pbPercent.Value = percent));
                    Task.Factory.StartNew(() => { pbStatus.Invoke(new Action(() => pbStatus.BackgroundImage = SimpleWallet.Properties.Resources.notsynced)); });
                }
            }

            //connection
            populateConnections(connections);
            //balance
            lbTotal.Invoke(new Action(() => lbTotal.Text = totalbalance));
            lblTotalUnconfirmed.Invoke(new Action(() => lblTotalUnconfirmed.Text = totalbalanceunconfirmed));
            //balance
            lbPrivate.Invoke(new Action(() => lbPrivate.Text = privatebalance));
            lblPrivateUnconfirmed.Invoke(new Action(() => lblPrivateUnconfirmed.Text = privatebalanceunconfirmed));

            //balance
            lbTransparent.Invoke(new Action(() => lbTransparent.Text = transparentbalance));
            lblTransparentUnconfirmed.Invoke(new Action(() => lblTransparentUnconfirmed.Text = transparentbalanceunconfirmed));

            //balance
            lbLocked.Invoke(new Action(() => lbLocked.Text = lockedbalance));
            lbImmature.Invoke(new Action(() => lbImmature.Text = immaturebalance));

            if (totalbalanceunconfirmed == "0.00" &&
                privatebalanceunconfirmed == "0.00" &&
                transparentbalanceunconfirmed == "0.00")
            {
                lblUnconfirmedHeader.Invoke(new Action(() => lblUnconfirmedHeader.Hide()));
                lblTransparentUnconfirmed.Invoke(new Action(() => lblTransparentUnconfirmed.Hide()));
                lblPrivateUnconfirmed.Invoke(new Action(() => lblPrivateUnconfirmed.Hide()));
                lblTotalUnconfirmed.Invoke(new Action(() => lblTotalUnconfirmed.Hide()));
            }
            else
            {
                lblUnconfirmedHeader.Invoke(new Action(() => lblUnconfirmedHeader.Show()));
                lblTransparentUnconfirmed.Invoke(new Action(() => lblTransparentUnconfirmed.Show()));
                lblPrivateUnconfirmed.Invoke(new Action(() => lblPrivateUnconfirmed.Show()));
                lblTotalUnconfirmed.Invoke(new Action(() => lblTotalUnconfirmed.Show()));
            }

            if (lockedbalance == "0.00")
            {
                lbLocked.Invoke(new Action(() => lbLocked.Hide()));
                label3.Invoke(new Action(() => label3.Hide()));
                lblLockedMessage.Invoke(new Action(() => lblLockedMessage.Hide()));
            }
            else
            {
                lbLocked.Invoke(new Action(() => lbLocked.Show()));
                label3.Invoke(new Action(() => label3.Show()));
                lblLockedMessage.Invoke(new Action(() => lblLockedMessage.Show()));
            }
            if (immaturebalance == "0.00")
            {
                lbImmature.Invoke(new Action(() => lbImmature.Hide()));
                lbImmatureTxt.Invoke(new Action(() => lbImmatureTxt.Hide()));
            }
            else
            {
                lbImmature.Invoke(new Action(() => lbImmature.Show()));
                lbImmatureTxt.Invoke(new Action(() => lbImmatureTxt.Show()));
            }
            //populate recent trans
            if (listtransactions != null)
            {
                listtransactions.Reverse();
                populateRecentTx(listtransactions);
            }

            //populate balance
            populateBalance(walletDic);

            dtgTransactions.Invoke(new Action(() => dtgTransactions.Visible = false));

            book = api.readAddressBook();

            populateMasternodes();

            populateMasternodeList(readMasternodeList(checkMasternodeList()));

            loadAddressBook(book);

            this.Text = Types.version;

            if (!isEnableAutoBackup())
            {
                enableAutoBackupWalletToolStripMenuItem.Text = "Enable auto backup wallet";
            }
            else
            {
                enableAutoBackupWalletToolStripMenuItem.Text = "Disable auto backup wallet";
            }

            Task.Run(() => startSync());
            Task.Run(() => startCheckMasternodeList());
        }

        // Specify what you want to happen when the Elapsed event is raised.
        public void HandleTimerElapsed(object sender, ElapsedEventArgs e)
        {
            ((System.Timers.Timer)sender).Stop();
            //canClose = true;
        }

        void startSync()
        {
            String data = "";
            String dataChainInfo = "";
            String dataZeroNodeCount = "";
            List<String> addresses;
            populateTransactions(listtransactions, out addresses);
            //startCheckBalance(walletDic);
            loadWallet();
            dtgTransactions.Invoke(new Action(() => dtgTransactions.Visible = true));
            bool isSynced = false;
            int count = 0;
            while (true)
            {
                try
                {
                    if (count == 0)
                    {
                        shouldGetTransaction = true; //Run on load
                    }
                    else if (count == 16) 
                    {
                        shouldGetWallet = true;  // should get wallet at least 1 time per 120 sec
                    }


                    dataZeroNodeCount = api.getZeroNodeCount();
                    dataChainInfo = api.getBestBlockhash();
                    data = api.getNetworkHeight();
                    Task.Run(() => addWalletInfo(data, dataChainInfo, dataZeroNodeCount));

                    dynamic parse = JsonConvert.DeserializeObject<Types.Info>(data);
                    int nHeight = Convert.ToInt32(parse.blocks);
                   

                    if (bestHeight + 1 <= nHeight || shouldGetTransaction)
                    {
                        data = api.getAllData(Types.GetAllDataType.ALL, 200);
                        populateAllData(data, true, ref nHeight, ref count, ref isSynced);

                        //transactions
                        populateTransactions(listtransactions, out addresses);
                        shouldGetTransaction = false; 
                    }
                    else if (shouldGetWallet)
                    {
                        data = api.getAllData(Types.GetAllDataType.WITH_BALANCE, 0);
                        populateAllData(data, false, ref nHeight, ref count, ref isSynced);

                    }
                }
                catch
                {
                    
                }

                
                if (shouldGetWallet == false)
                {
                    Thread.Sleep(8000);
                }
                count++;
                shouldGetWallet = false;
            }
        }


        void populateAllData(String data, bool withTransactions, ref int nHeight, ref int count, ref bool isSynced)
        {
            dynamic parse = JsonConvert.DeserializeObject<Types.AllData>(data);
            walletDic = new Dictionary<String, Types.AllDataAddress>(parse.addressbalance[0]);

            populateBalance(walletDic);
            //startCheckBalance(walletDic);


            if (withTransactions == true)
            {
                listtransactions = api.convertTransactionList(parse.listtransactions);

                //recent transactions
                listtransactions.Reverse();
                populateRecentTx(listtransactions);   
            }

            btnNewAddress.Invoke(new Action(() => btnNewAddress.Enabled = true));
            btnNewSaplingAddress.Invoke(new Action(() => btnNewSaplingAddress.Enabled = true));

            //balance
            lbTotal.Invoke(new Action(() => lbTotal.Text = parse.totalbalance));
            lblTotalUnconfirmed.Invoke(new Action(() => lblTotalUnconfirmed.Text = parse.totalunconfirmed));

            //balance
            lbPrivate.Invoke(new Action(() => lbPrivate.Text = parse.privatebalance));
            lblPrivateUnconfirmed.Invoke(new Action(() => lblPrivateUnconfirmed.Text = parse.privatebalanceunconfirmed));

            //balance
            lbTransparent.Invoke(new Action(() => lbTransparent.Text = parse.transparentbalance));
            lblTransparentUnconfirmed.Invoke(new Action(() => lblTransparentUnconfirmed.Text = parse.transparentbalanceunconfirmed));

            //balance
            lbLocked.Invoke(new Action(() => lbLocked.Text = parse.lockedbalance));
            lbImmature.Invoke(new Action(() => lbImmature.Text = parse.immaturebalance));

            if (parse.totalunconfirmed == "0.00" &&
                parse.privatebalanceunconfirmed == "0.00" &&
                parse.transparentbalanceunconfirmed == "0.00")
            {
                lblUnconfirmedHeader.Invoke(new Action(() => lblUnconfirmedHeader.Hide()));
                lblTransparentUnconfirmed.Invoke(new Action(() => lblTransparentUnconfirmed.Hide()));
                lblPrivateUnconfirmed.Invoke(new Action(() => lblPrivateUnconfirmed.Hide()));
                lblTotalUnconfirmed.Invoke(new Action(() => lblTotalUnconfirmed.Hide()));
            }
            else
            {
                lblUnconfirmedHeader.Invoke(new Action(() => lblUnconfirmedHeader.Show()));
                lblTransparentUnconfirmed.Invoke(new Action(() => lblTransparentUnconfirmed.Show()));
                lblPrivateUnconfirmed.Invoke(new Action(() => lblPrivateUnconfirmed.Show()));
                lblTotalUnconfirmed.Invoke(new Action(() => lblTotalUnconfirmed.Show()));
            }

            if (parse.lockedbalance == "0.00")
            {
                lbLocked.Invoke(new Action(() => lbLocked.Hide()));
                label3.Invoke(new Action(() => label3.Hide()));
                lblLockedMessage.Invoke(new Action(() => lblLockedMessage.Hide()));
            }
            else
            {
                lbLocked.Invoke(new Action(() => lbLocked.Show()));
                label3.Invoke(new Action(() => label3.Show()));
                lblLockedMessage.Invoke(new Action(() => lblLockedMessage.Show()));
            }

            if (parse.lockedbalance == "0.00")
            {
                lbImmature.Invoke(new Action(() => lbImmature.Hide()));
            }
            else
            {
                lbImmature.Invoke(new Action(() => lbImmature.Show()));
            }


            if (shouldGetWallet)
            {
                loadWallet();
                shouldGetWallet = false;
                shouldGetTransaction = false;
                count = 1;
            }

            bestHeight = nHeight;

            //block hash
            lbBestHash.Invoke(new Action(() => lbBestHash.Text = parse.bestblockhash));

            //block time
            String curr = parse.besttime;
            if (!String.IsNullOrEmpty(curr))
            {
                DateTime blkTime = UnixTimeStampToDateTime(Convert.ToInt32(curr));
                String temp = blkTime.ToString("yyyy/MM/dd HH:mm:ss");
                Task.Factory.StartNew(() => { lbBestHash.Invoke(new Action(() => lbBestTime.Text = temp)); });
                int time = Convert.ToInt32(curr);
                int unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                int sub = time - startTime;
                int total = unixTimestamp - startTime;
                int percent = (int)((float)sub / (float)total * 10000);
                if (percent > 9998)
                {
                    if (isSynced == false)
                    {
                        isSynced = true;
                        shouldGetWallet = true;
                    }
                    pbPercent.Invoke(new Action(() => pbPercent.Value = pbPercent.Maximum));
                    Task.Factory.StartNew(() => { pbStatus.Invoke(new Action(() => pbStatus.BackgroundImage = SimpleWallet.Properties.Resources.synced)); });
                }
                else
                {
                    pbPercent.Invoke(new Action(() => pbPercent.Value = percent));
                    Task.Factory.StartNew(() => { pbStatus.Invoke(new Action(() => pbStatus.BackgroundImage = SimpleWallet.Properties.Resources.notsynced)); });
                }
            }

            //connection
            populateConnections(parse.connectionCount);
        }





        //void startCheckBalance(List<String> addresses)
        //{
        //    try
        //    {
        //        addresses = addresses.Distinct().ToList();
        //        foreach (String a in addresses)
        //        {
        //            //get current balance of the address
        //            String balance = Task.Run(() => api.getAddressBalance(a)).Result;
        //            //update balance
        //            updateBalance(a, balance);
        //        }
        //        //loadWallet();
        //    }
        //    catch  { }
        //}

        //void startCheckBalance(Dictionary<String, Types.AllDataAddress> addresses)
        //{
        //    try
        //    {
        //        foreach (String a in addresses.Keys)
        //        {
        //            //get current balance of the address
        //            String balance = Task.Run(() => api.getAddressBalance(a)).Result;
        //            //update balance
        //            updateBalance(a, balance);
        //        }
        //        //loadWallet();
        //    }
        //    catch { }
        //}

        //string CheckBalanceUnconfirmed(string a)
        //{
        //    String balance = null;
        //    try
        //    {
        //        //get current balance of the address
        //        balance = Task.Run(() => api.getAddressBalanceUnconfirmed(a)).Result;
        //    }
        //    catch 
        //    {
        //        balance = "0.00";
        //    }
        //    return balance;
        //}

        void startCheckMasternodeList()
        {
            int count = 60;
            while (true)
            {
                if (count > 0 && !shouldUpdateMN)
                {
                    count--;
                }
                else
                {
                    count = 60;
                    shouldUpdateMN = false;
                    populateMasternodeList(readMasternodeList(checkMasternodeList()));
                }
                //update time label
                lbUpdateTime.Invoke(new Action(() => lbUpdateTime.Text = "(" + count + ")"));
                Thread.Sleep(1000);
            }
        }

        String checkMasternodeList()
        {
            return Task.Run(() => api.getMasternodeList()).Result;
        }

        void populateMasternodeList(List<Types.MasternodeDetail> mns)
        {
            List<Types.MasternodeDetailConverted> mnc = ConvertMasternodeDetail(mns);

            dtgGlobalMN.Invoke(new Action(() =>
            {
                dtgGlobalMN.AutoGenerateColumns = true;
                dtgGlobalMN.DataSource = new BindingList<Types.MasternodeDetailConverted>(mnc);
            }));


        }

        List<Types.MasternodeDetailConverted> ConvertMasternodeDetail(List<Types.MasternodeDetail> mnd)
        {
            List<Types.MasternodeDetailConverted> rtn = new List<Types.MasternodeDetailConverted>();
            foreach (Types.MasternodeDetail m in mnd)
            {
                rtn.Add(new Types.MasternodeDetailConverted(m.rank.ToString(), m.addr, m.version.ToString(), m.status,
                   SecondsToString(m.activetime),
                   UnixTimeStampToDateTime(m.lastseen).ToString("yyyy/MM/dd HH:mm:ss"),
                   UnixTimeStampToDateTime(m.lastpaid).ToString("yyyy/MM/dd HH:mm:ss"),
                   m.txhash, m.ip));
            }
            return rtn;
        }

        //void updateBalance(String address, String balance)
        //{
        //    DataGridViewRow row = new DataGridViewRow();
        //    String balanceUnconfirmed = "0.00";
        //    try
        //    {
        //        bool tempAllowUserToAddRows = dtgAddress.AllowUserToAddRows;

        //        dtgAddress.AllowUserToAddRows = false;

        //        row = dtgAddress.Rows
        //        .Cast<DataGridViewRow>()
        //        .Where(r => r.Cells[1].Value.ToString().Equals(address))
        //        .First();

        //        dtgAddress.AllowUserToAddRows = tempAllowUserToAddRows;
        //    }
        //    catch  { return; }
        //    int rowIndex = row.Index;

        //    balanceUnconfirmed=CheckBalanceUnconfirmed(address);
        //    if (balanceUnconfirmed==balance)
        //    {
        //        dtgAddress.Invoke(new Action(() => dtgAddress.Rows[rowIndex].Cells[0].Value = "Yes"));
        //        dtgAddress.Invoke(new Action(() => dtgAddress.Rows[rowIndex].Cells[2].Value = balance));
        //    }
        //    else
        //    {
        //        dtgAddress.Invoke(new Action(() => dtgAddress.Rows[rowIndex].Cells[0].Value = "No"));
        //        dtgAddress.Invoke(new Action(() => dtgAddress.Rows[rowIndex].Cells[2].Value = balanceUnconfirmed));
        //    }
            
        //}

        public DateTime UnixTimeStampToDateTime(int unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public String SecondsToString(int sec)
        {
            // Unix timestamp is seconds past epoch
            int day = sec / 86400;
            int hour = (sec % 86400) / 3600;
            int min = (sec % 3600) / 60;
            return day + " day " + hour.ToString("D2") + "h:" + min.ToString("D2") + "m";
        }

        void addTextToRtb(RichTextBox rtb, String text)
        {
#if DEBUG
            try
            {
                rtb.Invoke(new Action(() =>
                {
                    if (rtb.Text.Length > 100000)
                    {
                        rtb.Text = "";
                    }
                    rtb.AppendText(text + "\n");
                    rtb.ScrollToCaret();
                }));
            }
            catch (Exception) { /*do nothing*/}
#endif
        }

        void populateRecentTx(List<String> txs)
        {
            try
            {
                dynamic parse = JsonConvert.DeserializeObject<Types.Transaction>(" { " + txs[3]);
                if (parse.address == null)
                {
                    parse.address = "Private address";
                }

                pbImage(pbTransaction1, parse.category == "immature" ? SimpleWallet.Properties.Resources.mined_zero : parse.category == "send" ? SimpleWallet.Properties.Resources.outboundred
                    : SimpleWallet.Properties.Resources.inboundgreen);

                DateTime blkTime = UnixTimeStampToDateTime(Convert.ToInt32(parse.time));
                tsText(lbTime1, blkTime.ToString("yyyy/MM/dd HH:mm:ss"));

                tsText(lbValue1, parse.amount);

                tsText(lbAddress1, parse.address);

                pbVisible(pbTransaction1, true);
                tsVisible(lbTime1, true);
                tsVisible(lbValue1, true);
                tsVisible(lbAddress1, true);

                ////////////////////////////////
                parse = JsonConvert.DeserializeObject<Types.Transaction>(" { " + txs[2] + "}");
                if (parse.address == null)
                {
                    parse.address = "Private address";
                }
                pbImage(pbTransaction2, parse.category == "immature" ? SimpleWallet.Properties.Resources.mined_zero : parse.category == "send" ? SimpleWallet.Properties.Resources.outboundred
                    : SimpleWallet.Properties.Resources.inboundgreen);

                blkTime = UnixTimeStampToDateTime(Convert.ToInt32(parse.time));
                tsText(lbTime2, blkTime.ToString("yyyy/MM/dd HH:mm:ss"));

                tsText(lbValue2, parse.amount);

                tsText(lbAddress2, parse.address);

                pbVisible(pbTransaction2, true);
                tsVisible(lbTime2, true);
                tsVisible(lbValue2, true);
                tsVisible(lbAddress2, true);

                ////////////////////////////////
                parse = JsonConvert.DeserializeObject<Types.Transaction>(" { " + txs[1] + "}");
                if (parse.address == null)
                {
                    parse.address = "Private address";
                }
                pbImage(pbTransaction3, parse.category == "immature" ? SimpleWallet.Properties.Resources.mined_zero : parse.category == "send" ? SimpleWallet.Properties.Resources.outboundred
                    : SimpleWallet.Properties.Resources.inboundgreen);

                blkTime = UnixTimeStampToDateTime(Convert.ToInt32(parse.time));
                tsText(lbTime3, blkTime.ToString("yyyy/MM/dd HH:mm:ss"));

                tsText(lbValue3, parse.amount);

                tsText(lbAddress3, parse.address);

                pbVisible(pbTransaction3, true);
                tsVisible(lbTime3, true);
                tsVisible(lbValue3, true);
                tsVisible(lbAddress3, true);
                ////////////////////////////////
                parse = JsonConvert.DeserializeObject<Types.Transaction>(" { " + txs[0] + "}");
                if (parse.address == null)
                {
                    parse.address = "Private address";
                }
                pbImage(pbTransaction4, parse.category == "immature" ? SimpleWallet.Properties.Resources.mined_zero : parse.category == "send" ? SimpleWallet.Properties.Resources.outboundred
                    : SimpleWallet.Properties.Resources.inboundgreen);

                blkTime = UnixTimeStampToDateTime(Convert.ToInt32(parse.time));
                tsText(lbTime4, blkTime.ToString("yyyy/MM/dd HH:mm:ss"));

                tsText(lbValue4, parse.amount);

                tsText(lbAddress4, parse.address);

                pbVisible(pbTransaction4, true);
                tsVisible(lbTime4, true);
                tsVisible(lbValue4, true);
                tsVisible(lbAddress4, true);
            }
            catch 
            {
                //the number of transaction is < 4
            }
        }

        void populateRecentTx(List<Types.Transaction> txs)
        {
            try
            {
                List<Types.Transaction> newTx = new List<Types.Transaction>();
                if (txs.Count > 4)
                    newTx = txs.GetRange(0, 4);
                else
                    newTx = txs;

                Types.Transaction tx = newTx[0];

                pbImage(pbTransaction1, tx.category == "immature" ? SimpleWallet.Properties.Resources.mined_zero : tx.category == "send" ? SimpleWallet.Properties.Resources.outboundred
                    : SimpleWallet.Properties.Resources.inboundgreen);

                DateTime blkTime = UnixTimeStampToDateTime(Convert.ToInt32(tx.time));
                tsText(lbTime1, blkTime.ToString("yyyy/MM/dd HH:mm:ss"));

                tsText(lbValue1, tx.amount);

                tsText(lbAddress1, tx.address == null ? "Private Address" : tx.address);

                pbVisible(pbTransaction1, true);
                tsVisible(lbTime1, true);
                tsVisible(lbValue1, true);
                tsVisible(lbAddress1, true);

                ////////////////////////////////

                if (newTx.Count > 1)
                {
                    tx = newTx[1];

                    pbImage(pbTransaction2, tx.category == "immature" ? SimpleWallet.Properties.Resources.mined_zero : tx.category == "send" ? SimpleWallet.Properties.Resources.outboundred
                    : SimpleWallet.Properties.Resources.inboundgreen);

                    blkTime = UnixTimeStampToDateTime(Convert.ToInt32(tx.time));
                    tsText(lbTime2, blkTime.ToString("yyyy/MM/dd HH:mm:ss"));

                    tsText(lbValue2, tx.amount);

                    tsText(lbAddress2, tx.address == null ? "Private Address" : tx.address);

                    pbVisible(pbTransaction2, true);
                    tsVisible(lbTime2, true);
                    tsVisible(lbValue2, true);
                    tsVisible(lbAddress2, true);
                }
                ////////////////////////////////
                if (newTx.Count > 2)
                {
                    tx = newTx[2];

                    pbImage(pbTransaction3, tx.category == "immature" ? SimpleWallet.Properties.Resources.mined_zero : tx.category == "send" ? SimpleWallet.Properties.Resources.outboundred
                    : SimpleWallet.Properties.Resources.inboundgreen);

                    blkTime = UnixTimeStampToDateTime(Convert.ToInt32(tx.time));
                    tsText(lbTime3, blkTime.ToString("yyyy/MM/dd HH:mm:ss"));

                    tsText(lbValue3, tx.amount);

                    tsText(lbAddress3, tx.address == null ? "Private Address" : tx.address);

                    pbVisible(pbTransaction3, true);
                    tsVisible(lbTime3, true);
                    tsVisible(lbValue3, true);
                    tsVisible(lbAddress3, true);
                }
                ////////////////////////////////
                if (newTx.Count > 3)
                {
                    tx = newTx[3];

                    pbImage(pbTransaction4, tx.category == "immature" ? SimpleWallet.Properties.Resources.mined_zero : tx.category == "send" ? SimpleWallet.Properties.Resources.outboundred
                    : SimpleWallet.Properties.Resources.inboundgreen);

                    blkTime = UnixTimeStampToDateTime(Convert.ToInt32(tx.time));
                    tsText(lbTime4, blkTime.ToString("yyyy/MM/dd HH:mm:ss"));

                    tsText(lbValue4, tx.amount);

                    tsText(lbAddress4, tx.address == null ? "Private Address" : tx.address);

                    pbVisible(pbTransaction4, true);
                    tsVisible(lbTime4, true);
                    tsVisible(lbValue4, true);
                    tsVisible(lbAddress4, true);
                }
            }
            catch
            {
                //the number of transaction is < 4
            }
        }

        String getTxImgLoc(bool isOut)
        {
            if (isOut)
            {
                return outImg;
            }
            else
            {
                return inImg;
            }
        }

        void sortDtg(DataGridView dtg, String sortName)
        {
            dtg.Invoke(new Action(() => dtg.Sort(dtg.Columns[sortName], ListSortDirection.Ascending)));
        }

        List<Types.MasternodeDetail> readMasternodeList(String mns)
        {
            mns = "{\n" +
                "\"zeronodelist\": " +
                mns + "\n" +
                "}";
            List<Types.MasternodeDetail> rtn = new List<Types.MasternodeDetail>();
            try
            {
                dynamic parse = JsonConvert.DeserializeObject<Types.MasternodeList>(mns);
                rtn = parse.zeronodelist;
            }
            catch (Exception ex)
            { }

            List<Types.MasternodeDetail> temp = new List<Types.MasternodeDetail>();
            foreach (String addr in walletDic.Keys)
            {
                int index = rtn.FindIndex(f => f.addr == addr);
                if (index > -1)
                {
                    temp.Add(new Types.MasternodeDetail(rtn[index]));
                    rtn.RemoveAt(index);
                }
            }

            foreach (Types.Masternode m in mn)
            {
                int index = rtn.FindIndex(f => f.txhash == m.txHash);
                if (index > -1)
                {
                    temp.Add(new Types.MasternodeDetail(rtn[index]));
                    rtn.RemoveAt(index);
                }
            }

            foreach (Types.AddressBook b in book)
            {
                try
                {
                    int index = rtn.FindIndex(f => f.addr == b.address);
                    if (index > -1)
                    {
                        temp.Add(new Types.MasternodeDetail(rtn[index]));
                        rtn.RemoveAt(index);
                    }
                }
                catch (Exception ex) { }
            }

            temp.Sort(delegate(Types.MasternodeDetail x, Types.MasternodeDetail y)
            {
                return x.rank.CompareTo(y.rank);
            });
            rtn.InsertRange(0, temp);
            return rtn;
        }

        List<Types.Outputs> readOutputsList(String outputs)
        {
            outputs = "{\n" +
                "\"outputslist\": " +
                outputs + "\n" +
                "}";
            List<Types.Outputs> rtn = new List<Types.Outputs>();
            try
            {
                dynamic parse = JsonConvert.DeserializeObject<Types.OutputsList>(outputs);
                rtn = parse.outputslist;
            }
            catch (Exception ex)
            { }
            return rtn;
        }

        void populateConnections(String data)
        {
            Bitmap image = SimpleWallet.Properties.Resources.connect1_16;
            try
            {
                int connected = Convert.ToInt32(data);
                numConnection = connected;
                if (connected > 0 && connected < 3)
                {
                    image = SimpleWallet.Properties.Resources.connect1_16;
                }
                else if (connected >= 3 && connected < 5)
                {
                    image = SimpleWallet.Properties.Resources.connect2_16;
                }
                else if (connected >= 5 && connected <= 7)
                {
                    image = SimpleWallet.Properties.Resources.connect3_16;
                }
                else if (connected >= 8)
                {
                    image = SimpleWallet.Properties.Resources.connect4_16;
                }
                pbSignal.Invoke(new Action(() => pbSignal.BackgroundImage = image));
            }
            catch  { }
        }

        void populateMasternodes()
        {
            String mnLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                        "\\zero\\zeronode.conf";

            mn = api.getMasternodes();

            if (mn.Count > 0)
            {
                dtgMasternode.Invoke(new Action(() =>
                {
                    dtgMasternode.DataSource = mn;
                }));
            }
        }

        void changeMNColor(DataGridView dtg)
        {
            foreach (DataGridViewRow row in dtg.Rows)
            {
                if (row.Cells.Count > 0 && row.Cells[0].Value != null && row.Cells[0].Value.ToString() == "DISABLE")
                {
                    dtg.Invoke(new Action(() => row.DefaultCellStyle.BackColor = Color.LightGray));
                }
                else
                {
                    dtg.Invoke(new Action(() => row.DefaultCellStyle.BackColor = Color.Empty));
                }
            }
        }

        String parseString(String input)
        {
            List<String> split = input.Split(new String[] { "\"", " ", ":", ",", "\n" }, StringSplitOptions.None).ToList();
            split.RemoveAll(String.IsNullOrEmpty);
            return split[split.Count - 1];
        }

        void addWalletInfo(String data, String dataChainInfo, String dataZeroNode)
        {
            try
            {
                dynamic parse = JsonConvert.DeserializeObject<Types.Info>(data);
                dynamic parsedata = JsonConvert.DeserializeObject<Types.BlockChainInfo>(dataChainInfo);
                int nHeight = Convert.ToInt32(parse.blocks);

                double shieldedValue = Convert.ToDouble(parsedata.valuePools[0].chainValue) + Convert.ToDouble(parsedata.valuePools[1].chainValue);
                double chainValue = 0;
                if (nHeight >= 412300)
                {
                    if (nHeight <= 800000)
                    {
                        chainValue += 4122990 + ((nHeight - 412299) * 10.8);
                    }
                    if (nHeight > 800000 && nHeight <= 1600000)
                    {
                        chainValue += 4122990 + ((799999 - 412299) * 10.8);
                        chainValue += (nHeight - 799999) * 10.8 / 2;
                    }

                }
                else
                {
                    chainValue = Convert.ToDouble(nHeight * 10);
                }

                if (dtgWalletInfo.RowCount != 11)
                {
                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows.Clear()));

                    String[] rowVersion = { "Version", parse.version };
                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows.Add(rowVersion)));

                    String[] rowProtocol = { "Protocol Version", parse.protocolversion };
                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows.Add(rowProtocol)));

                    String[] rowWallet = { "Wallet Version", parse.walletversion };
                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows.Add(rowWallet)));

                    String[] rowBlocks = { "Block Height", String.Format("{0:n0}", nHeight) };
                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows.Add(rowBlocks)));

                    String[] rowConnections = { "Connections", parse.connections };
                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows.Add(rowProtocol)));

                    String[] rowDifficulty = { "Mining Difficulty", parse.difficulty };
                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows.Add(rowDifficulty)));

                    if (parse.testnet == "false")
                    {
                        String[] rowNetwork = { "Network", "Main" };
                        dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows.Add(rowNetwork)));
                    }
                    else
                    {
                        String[] rowNetwork = { "Network", "Test" };
                        dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows.Add(rowNetwork)));
                    }

                    String[] rowTransparent = { "Transparent Value Pool", String.Format("{0:n8}", (chainValue - shieldedValue)) };
                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows.Add(rowTransparent)));

                    String[] rowSprout = { "Sprout Value Pool", String.Format("{0:n8}", (String.Format("{0:n8}", Convert.ToDouble(parsedata.valuePools[0].chainValue)))) };
                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows.Add(rowSprout)));

                    String[] rowSapling = { "Sapling Value Pool", String.Format("{0:n8}", (String.Format("{0:n8}", Convert.ToDouble(parsedata.valuePools[1].chainValue)))) };
                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows.Add(rowSapling)));

                    String[] rowTotal = { "Total Chain Value", String.Format("{0:n8}", (chainValue)) };
                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows.Add(rowTotal)));
                }
                else
                {
                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows[0].Cells[0].Value = "Version"));
                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows[0].Cells[1].Value = parse.version));

                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows[1].Cells[0].Value = "Protocol Version"));
                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows[1].Cells[1].Value = parse.protocolversion));

                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows[2].Cells[0].Value = "Wallet Version"));
                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows[2].Cells[1].Value = parse.walletversion));

                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows[3].Cells[0].Value = "Block Height"));
                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows[3].Cells[1].Value = String.Format("{0:n0}", nHeight)));

                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows[4].Cells[0].Value = "Connections"));
                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows[4].Cells[1].Value = parse.connections));

                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows[5].Cells[0].Value = "Mining Difficulty"));
                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows[5].Cells[1].Value = parse.difficulty));

                    if (parse.testnet == "false")
                    {
                        dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows[6].Cells[0].Value = "Network"));
                        dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows[6].Cells[1].Value = "Main"));
                    }
                    else
                    {
                        dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows[6].Cells[0].Value = "Network"));
                        dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows[6].Cells[1].Value = "Test"));
                    }

                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows[7].Cells[0].Value = "Transparent Value Pool"));
                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows[7].Cells[1].Value = String.Format("{0:n8}", (chainValue - shieldedValue))));

                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows[8].Cells[0].Value = "Sprout Value Pool"));
                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows[8].Cells[1].Value = String.Format("{0:n8}", (String.Format("{0:n8}", Convert.ToDouble(parsedata.valuePools[0].chainValue))))));

                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows[9].Cells[0].Value = "Sapling Value Pool"));
                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows[9].Cells[1].Value = String.Format("{0:n8}", (String.Format("{0:n8}", Convert.ToDouble(parsedata.valuePools[1].chainValue))))));

                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows[10].Cells[0].Value = "Total Chain Value"));
                    dtgWalletInfo.Invoke(new Action(() => dtgWalletInfo.Rows[10].Cells[1].Value = String.Format("{0:n8}", (chainValue))));

                }


                dynamic zeronodedata = JsonConvert.DeserializeObject<Types.ZeroNodeCount>(dataZeroNode);

                if (dtgZeroNode.RowCount != 11)
                {
                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows.Clear()));

                    String[] rowTotalNodes = { "Total ZeroNodes", zeronodedata.total };
                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows.Add(rowTotalNodes)));

                    String[] rowStableNodes = { "Stable ZeroNodes", zeronodedata.stable };
                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows.Add(rowStableNodes)));

                    String[] rowEnabledNodes = { "Enabled ZeroNodes", zeronodedata.enabled };
                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows.Add(rowEnabledNodes)));

                    String[] rowInqueueNodes = { "Inqueue ZeroNodes", zeronodedata.inqueue };
                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows.Add(rowInqueueNodes)));

                    String[] rowIpv4Nodes = { "Ipv4 ZeroNodes", zeronodedata.ipv4 };
                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows.Add(rowIpv4Nodes)));

                    String[] rowIpv6Nodes = { "Ipv6 ZeroNodes", zeronodedata.ipv6 };
                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows.Add(rowIpv6Nodes)));

                    String[] rowOnionNodes = { "Onion ZeroNodes", zeronodedata.onion };
                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows.Add(rowOnionNodes)));

                    String[] rowLockedCoins = { "Locked Coins", String.Format("{0:n0}", Convert.ToUInt32(zeronodedata.total) * 10000) };
                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows.Add(rowLockedCoins)));

                    String[] rowLockedPert = { "Locked Percent", String.Format("{0:0.00%}", Convert.ToDouble(Convert.ToUInt32(zeronodedata.total) * 10000) / chainValue) };
                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows.Add(rowLockedPert)));

                    String[] rowROI = { "Current ROI", String.Format("{0:0.00%}", ((((1.35 * 720) / Convert.ToDouble(Convert.ToUInt32(zeronodedata.total))) / 10000) * 365)) };
                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows.Add(rowROI)));

                    String[] rowIncome = { "Est. Daily Income (1 Node)", String.Format("{0:n8}", ((1.35 * 720) / Convert.ToDouble(Convert.ToUInt32(zeronodedata.total)))) };
                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows.Add(rowIncome)));
                        
                }
                else
                {
                       
                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows[0].Cells[0].Value = "Total ZeroNodes"));
                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows[0].Cells[1].Value = zeronodedata.total));

                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows[1].Cells[0].Value = "Stable ZeroNodes"));
                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows[1].Cells[1].Value = zeronodedata.stable));

                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows[2].Cells[0].Value = "Enabled ZeroNodes"));
                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows[2].Cells[1].Value = zeronodedata.enabled));

                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows[3].Cells[0].Value = "Inqueue ZeroNodes"));
                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows[3].Cells[1].Value = zeronodedata.inqueue));

                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows[4].Cells[0].Value = "Ipv4 ZeroNodes"));
                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows[4].Cells[1].Value = zeronodedata.ipv4));

                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows[5].Cells[0].Value = "Ipv6 ZeroNodes"));
                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows[5].Cells[1].Value = zeronodedata.ipv6));

                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows[6].Cells[0].Value = "Onion ZeroNodes"));
                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows[6].Cells[1].Value = zeronodedata.onion));

                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows[7].Cells[0].Value = "Locked Coins"));
                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows[7].Cells[1].Value = String.Format("{0:n0}", Convert.ToUInt32(zeronodedata.total) * 10000)));

                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows[8].Cells[0].Value = "Locked Percentage"));
                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows[8].Cells[1].Value = String.Format("{0:0.00%}", Convert.ToDouble(Convert.ToUInt32(zeronodedata.total) * 10000) / chainValue)));

                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows[9].Cells[0].Value = "Current ROI"));
                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows[9].Cells[1].Value = String.Format("{0:0.00%}", ((((1.35 * 720) / Convert.ToDouble(Convert.ToUInt32(zeronodedata.total))) / 10000) * 365))));

                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows[10].Cells[0].Value = "Est. Daily Income (1 Node)"));
                    dtgZeroNode.Invoke(new Action(() => dtgZeroNode.Rows[10].Cells[1].Value = String.Format("{0:n8}", ((1.35 * 720) / Convert.ToDouble(Convert.ToUInt32(zeronodedata.total))))));

                }
                
            }
            catch
            {

            }


        }

        void addWalletInfo(Dictionary<String, Types.AllDataAddress> data, Dictionary<String, Types.AllDataAddress> oldData)
        {
            dtgAddress.Invoke(new Action(() => dtgAddress.Visible = false));

            if (data.Count != oldData.Count)   
            {
                shouldGetTransaction = true;
                dtgAddress.Invoke(new Action(() => dtgAddress.Rows.Clear()));
                for (int i = 0; i < data.Keys.Count; i++)
                {
                    String[] row = { data.Keys.ElementAt(i), data[data.Keys.ElementAt(i)].amount, data[data.Keys.ElementAt(i)].unconfirmed, data[data.Keys.ElementAt(i)].immature, data[data.Keys.ElementAt(i)].locked };
                    dtgAddress.Invoke(new Action(() => dtgAddress.Rows.Add(row)));
                }
            }
            else
            {
                bool shouldClear = false;
                for (int i = 0; i < data.Keys.Count; i++)
                {
                    if (!oldData.Keys.Contains(data.Keys.ElementAt(i)))
                    {
                        shouldClear = true;
                        shouldGetTransaction = true;
                        break;
                    }
                }
                if (shouldClear)
                {
                    dtgAddress.Invoke(new Action(() => dtgAddress.Rows.Clear()));
                    for (int i = 0; i < data.Keys.Count; i++)
                    {
                        String[] row = { data.Keys.ElementAt(i), data[data.Keys.ElementAt(i)].amount, data[data.Keys.ElementAt(i)].unconfirmed, data[data.Keys.ElementAt(i)].immature, data[data.Keys.ElementAt(i)].locked };
                        dtgAddress.Invoke(new Action(() => dtgAddress.Rows.Add(row)));
                    }
                }
                else
                {
                    for (int i = 0; i < data.Keys.Count; i++)
                    {
                        if (data[data.Keys.ElementAt(i)].amount != oldData[data.Keys.ElementAt(i)].amount)
                        {
                            dtgAddress.Invoke(new Action(() => dtgAddress.Rows[i].Cells[1].Value = data[data.Keys.ElementAt(i)].amount));
                            shouldGetTransaction = true;
                        }
                        if (data[data.Keys.ElementAt(i)].unconfirmed != oldData[data.Keys.ElementAt(i)].unconfirmed)
                        {
                            dtgAddress.Invoke(new Action(() => dtgAddress.Rows[i].Cells[2].Value = data[data.Keys.ElementAt(i)].unconfirmed));
                            shouldGetTransaction = true;
                        }
                        if (data[data.Keys.ElementAt(i)].immature != oldData[data.Keys.ElementAt(i)].immature)
                        {
                            dtgAddress.Invoke(new Action(() => dtgAddress.Rows[i].Cells[3].Value = data[data.Keys.ElementAt(i)].immature));
                            shouldGetTransaction = true;
                        }
                        if (data[data.Keys.ElementAt(i)].locked != oldData[data.Keys.ElementAt(i)].locked)
                        {
                            dtgAddress.Invoke(new Action(() => dtgAddress.Rows[i].Cells[4].Value = data[data.Keys.ElementAt(i)].locked));
                            shouldGetTransaction = true;
                        }
                    }
                }
            }
            dtgAddress.Invoke(new Action(() => dtgAddress.Visible = true));
        }

        void loadAddressBook(List<Types.AddressBook> book)
        {
            cbbClear(cbbAddress);
            foreach (Types.AddressBook a in book)
            {
                cbbAdd(cbbAddress, a.label);
            }
        }

        void loadWallet()
        {
            lock (lockObj)
            {
                String selectedAddress = "";
                String selectedShieldFromAddress = "";
                String selectedShieldToAddress = "";
                object slItem = getSelectedItem(cbbFrom);
                if (slItem != null)
                {
                    selectedAddress = slItem.ToString().Split(new String[] { " - " }, StringSplitOptions.None)[0];
                }
                slItem = getSelectedItem(cbbShieldFrom);
                if (slItem != null)
                {
                    selectedShieldFromAddress = slItem.ToString().Split(new String[] { " - " }, StringSplitOptions.None)[0];
                }
                slItem = getSelectedItem(cbbShieldTo);
                if (slItem != null)
                {
                    selectedShieldToAddress = slItem.ToString().Split(new String[] { " - " }, StringSplitOptions.None)[0];
                }
                cbbClear(cbbFrom);
                cbbClear(cbbShieldFrom);
                cbbClear(cbbShieldTo);
                if (walletDic.Keys.Count > 0)
                {
                    btnEnable(btnSend, true);
                    btnEnable(btnSendMany, true);
                    double output;
                    int selectedIdx = 0;
                    int selectedShieldFromIdx = -1;
                    int selectedShieldToIdx = -1;
                    int count = 0;
                    int countShieldFrom = 0;
                    int countShieldTo = 0;
                    foreach (String wallet in walletDic.Keys.ToList())
                    {
                        if ((Double.TryParse(walletDic[wallet].amount, out output) && Convert.ToDouble(walletDic[wallet].amount) != 0) ||
                            (Double.TryParse(walletDic[wallet].amount.Replace(".", ","), out output) && Convert.ToDouble(walletDic[wallet].amount.Replace(".", ",")) != 0))
                        {
                            cbbAdd(cbbFrom, wallet + " - " + walletDic[wallet].amount);
                            if (selectedAddress == wallet)
                            {
                                selectedIdx = count;
                            }
                            count++;

                            if (wallet.StartsWith("t"))
                            {
                                if (selectedShieldFromAddress == wallet)
                                {
                                    selectedShieldFromIdx = countShieldFrom;
                                }
                                cbbAdd(cbbShieldFrom, wallet + " - " + walletDic[wallet].amount);
                                countShieldFrom++;
                            }

                        }
                        if (wallet.StartsWith("zc"))
                        {
                            if (selectedShieldToAddress == wallet)
                            {
                                selectedShieldToIdx = countShieldTo;
                            }
                            cbbAdd(cbbShieldTo, wallet);
                            countShieldTo++;
                        }
                        else if (wallet.StartsWith("zs"))
                        {
                            if (selectedShieldToAddress == wallet)
                            {
                                selectedShieldToIdx = countShieldTo;
                            }
                            cbbAdd(cbbShieldTo, wallet);
                            countShieldTo++;
                        }
                    }
                    if (cbbFrom.Items.Count > 0)
                    {
                        cbbSelectedIndex(cbbFrom, selectedIdx);
                    }
                    if (cbbShieldFrom.Items.Count > 0)
                    {
                        cbbSelectedIndex(cbbShieldFrom, selectedShieldFromIdx);
                    }
                    if (cbbShieldTo.Items.Count > 0)
                    {
                        cbbSelectedIndex(cbbShieldTo, selectedShieldToIdx);
                    }
                }
                else
                {
                    btnEnable(btnSend, false);
                    btnEnable(btnSendMany, false);
                }
            }
        }

        void populateBalance(Dictionary<String, Types.AllDataAddress> walletDic)
        {
            walletDic.OrderBy(i => i.Key);

            addWalletInfo(walletDic, oldWalletDic);

            oldWalletDic = new Dictionary<String, Types.AllDataAddress>(walletDic);

            if (btnNewAddress.Enabled == false)
            {
                btnNewAddress.Invoke(new Action(() => btnNewAddress.Enabled = true));
            }
            if (btnNewSaplingAddress.Enabled == false)
            {
                btnNewSaplingAddress.Invoke(new Action(() => btnNewSaplingAddress.Enabled = true));
            }
        }

        void populateTransactions(List<Types.Transaction> datas, out List<String> addresses)
        {
            addresses = new List<String>();

            List<Types.TransactionConverted> txold = new List<Types.TransactionConverted>(txconvert);
            txconvert = ConvertTransactionDetail(datas);

            foreach (Types.TransactionConverted t in txconvert)
            {

                IEnumerable<Types.TransactionConverted> item = txold.Where(x => x.address == t.address && x.amount == t.amount && x.time == t.time && x.category == t.category);
                if (item.ToList().Count == 0)
                {
                    addressBalanceChange.Add(t.address);
                }
            }
            //check balance change

            dtgTransactions.Invoke(new Action(() =>
            {
                dtgTransactions.AutoGenerateColumns = true;
                dtgTransactions.DataSource = new BindingList<Types.TransactionConverted>(txconvert);
            }));

        }

        List<Types.TransactionConverted> ConvertTransactionDetail(List<Types.Transaction> tx)
        {
            List<Types.TransactionConverted> rtn = new List<Types.TransactionConverted>();
            foreach (Types.Transaction t in tx)
            {
                DateTime blkTime = UnixTimeStampToDateTime(Convert.ToInt32(t.time));
                String strTime = blkTime.ToString("yyyy/MM/dd HH:mm:ss");
                String amount = t.amount.TrimStart('-');
                rtn.Add(new Types.TransactionConverted(t.category == "send" ? "<==" : "==>",
                                            t.category == "immature" ? "Immature" : Convert.ToInt32(t.confirmations) >= 1 ? "YES" : "NO (" + t.confirmations + ")",
                                            amount, strTime, t.address == null ? "Private address" : t.address, t.txid));
            }
            return rtn;
        }

        bool getListTrans(List<Types.Transaction> tx, String input)
        {
            dynamic data = new Types.Transaction();
            try
            {
                dynamic parse = JsonConvert.DeserializeObject<Types.Transaction>(input);
                if (parse.address == null)
                {
                    parse.address = "Private address";
                }
                tx.Add((Types.Transaction)parse);
            }
            catch 
            {
                return false;
            }
            return true;
        }

        private void tbAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Dictionary<String, String> strDict = api.checkWallet(tbPayTo.Text);
            if (String.IsNullOrEmpty(tbPayTo.Text) || !Api.checkResult(strDict))
            {
                MessageBox.Show("Destination wallet is invalid", "Error");
                return;
            }
            ((Button)sender).Enabled = false;
            String from = cbbFrom.SelectedItem.ToString().Split(new String[] { " - " }, StringSplitOptions.None)[0];
            String to = tbPayTo.Text;
            String amount = tbAmount.Text;
            if (amount.IndexOf('.', 0) == 0)
            {
                amount = '0' + amount;
            }
            String fee = tbFee.Text;
            if (fee.IndexOf('.', 0) == 0)
            {
                fee = '0' + fee;
            }
            bool defaultFee = cbDefaultFee.Checked;

            if (String.IsNullOrEmpty(from) || String.IsNullOrEmpty(to) || String.IsNullOrEmpty(amount))
            {
                MessageBox.Show("Some data is invalid", "Error!!!");
                ((Button)sender).Enabled = true;
                return;
            }
            strDict = Task.Run(() => api.sendCoin(from, to, amount, fee, defaultFee)).Result;

            SendingCoin send = new SendingCoin(strDict);
            send.ShowDialog();
            strDict = send.data;

            if (Api.checkResult(strDict))
            {
                addressBalanceChange.Add(from);
                shouldGetTransaction = true;
                shouldGetWallet = true;
                MessageBox.Show("Success");
            }
            else
            {
                string err = Api.getMessage(strDict);

                if (err.Contains("bad-txns-oversize"))
                {
                    err += "\nGo to https://zerocurrency.io/ to get help.";
                    ErrorMessage errMsg = new ErrorMessage(err);
                    errMsg.ShowDialog();
                }
                else
                {
                    MessageBox.Show(err);
                }
            }
            ((Button)sender).Enabled = true;
        }

        private void cbbFrom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tpSend_Enter(object sender, EventArgs e)
        {
            loadWallet();
        }

        private void cbFee_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                tbFee.Enabled = false;
            }
            else
            {
                tbFee.Enabled = true;
            }
        }

        private void Start_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnNewAddress_Click(object sender, EventArgs e)
        {
            btnNewAddress.Enabled = false;
            btnNewSaplingAddress.Enabled = false;
            api.newAddress();
            shouldGetWallet = true;
            MessageBox.Show("Please wait few seconds for new address");
        }

        //private void btnNewZAddress_Click(object sender, EventArgs e)
        //{
        //    btnNewAddress.Enabled = false;
        //    btnNewSaplingAddress.Enabled = false;
        //    api.newZAddress();
        //    shouldGetWallet = true;
        //    MessageBox.Show("Please wait few seconds for new address");
        //}

        private void btnNewSaplingAddress_Click(object sender, EventArgs e)
        {
            btnNewAddress.Enabled = false;
            btnNewSaplingAddress.Enabled = false;
            api.newSaplingAddress();
            shouldGetWallet = true;
            MessageBox.Show("Please wait few seconds for new address");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadWallet();
        }

        private void Start_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if(!canClose)
            //{
            //    e.Cancel = true;
            //    MessageBox.Show("Please wait 5 seconds before starting the wallet to close");
            //    return;
            //}
            this.Visible = false;
            this.Hide();
            scr.ShowDialog();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            api.backupWallet();
        }

        private void exportPrivateKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                String[] split = dialog.FileName.Split('\\');
                String filename = split[split.Length - 1].Split('.')[0];
                Dictionary<String, String> strDict = Task.Run(() => api.exportPrivateKeys(filename)).Result;
                if (!Api.checkResult(strDict))
                {
                    MessageBox.Show(Api.getMessage(strDict));
                }
                else
                {
                    MessageBox.Show("Your keys were saved to: " + Api.getMessage(strDict));
                }
            }

        }

        private void importPrivateKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Importing process will take alot of time, please be patient");
            api.importPrivateKeys();
        }

        private void importOnePrivateKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportKey importDialog = new ImportKey();
            importDialog.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String text = Types.version + "\n\n";

            text += "Copyright (c) 2016-2018 Pit ceo@snowgem.org\n" +
                "\n" +
                "Permission is hereby granted, free of charge, to any person obtaining a copy" +
                " of this software and associated documentation files (the \"Software\"), to deal" +
                " in the Software without restriction, including without limitation the rights" +
                " to use, copy, modify, merge, publish, distribute, sublicense, and/or sell" +
                " copies of the Software, and to permit persons to whom the Software is" +
                " furnished to do so, subject to the following conditions:" +
                " \n" +
                "    The above copyright notice and this permission notice shall be included in" +
                " all copies or substantial portions of the Software.\n" +
                " \n" +
                "THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR" +
                " IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY," +
                " FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE" +
                " AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER" +
                " LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM," +
                " OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN" +
                " THE SOFTWARE.		\n";
            License lic = new License(text);
            lic.ShowDialog();
        }

        public bool isEnableAutoBackup()
        {
            String enableFile = Path.GetTempPath() + "\\autoBackup.zero";
            if (!File.Exists(enableFile))
            {
                return false;

            }

            String read = File.ReadAllText(enableFile);

            if (read == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void pbSignal_MouseHover(object sender, EventArgs e)
        {
            ttStart.SetToolTip(pbSignal, "Connections: " + numConnection);
        }

        object getSelectedItem(ComboBox cbb)
        {
            return cbb.Invoke(new Func<object>(() =>
            {
                return cbb.SelectedItem;
            }));
        }

        void cbbClear(ComboBox cbb)
        {
            cbb.Invoke(new Action(() => cbb.Items.Clear()));
        }

        void cbbAdd(ComboBox cbb, String s)
        {
            cbb.Invoke(new Action(() => cbb.Items.Add(s)));
        }

        void cbbInsert(ComboBox cbb, String s, int index)
        {
            cbb.Invoke(new Action(() => cbb.Items.Insert(index, s)));
        }

        void cbbSelectedIndex(ComboBox cbb, int i)
        {
            cbb.Invoke(new Action(() => cbb.SelectedIndex = i));
        }


        void btnEnable(Button btn, bool status)
        {
            btn.Invoke(new Action(() => btn.Enabled = status));
        }

        void tsVisible(TransparentLabel tl, bool status)
        {
            tl.Invoke(new Action(() => tl.Visible = status));
        }

        void tsText(TransparentLabel tl, String text)
        {
            tl.Invoke(new Action(() =>
                {
                    tl.Text = text;
                }));
        }

        void pbVisible(PictureBox pb, bool status)
        {
            pb.Invoke(new Action(() => pb.Visible = status));
        }

        void pbImage(PictureBox pb, Bitmap bmp)
        {
            pb.Invoke(new Action(() => pb.Image = bmp));
        }

        private void btnSendMany_Click(object sender, EventArgs e)
        {
            if (cbbFrom.SelectedItem != null)
            {
                String from = cbbFrom.SelectedItem.ToString().Split(new String[] { " - " }, StringSplitOptions.None)[0];
                SendMany send = new SendMany(from);
                send.ShowDialog();
                if (send.result)
                {
                    addressBalanceChange.Add(from);
                    shouldGetTransaction = true;
                    shouldGetWallet = true;
                }
            }
        }

        private void tpReceive_Leave(object sender, EventArgs e)
        {
            dtgAddress.Visible = false;
        }

        private void tpReceive_Enter(object sender, EventArgs e)
        {
            dtgAddress.Visible = true;
        }

        private void tpTransactions_Enter(object sender, EventArgs e)
        {
            dtgTransactions.Visible = true;
        }

        private void tpTransactions_Leave(object sender, EventArgs e)
        {
            dtgTransactions.Visible = false;
        }

        private void btnRescan_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(@"This action will rescan the blockchain to remove unspendable transaction (zero confirmation for a long time) and get your coin back.
Are you sure?", @"Reopen to scan the wallet", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //canClose = true;
                shouldRestart = true;
                File.WriteAllText(Types.startCommandsFile, "-zapwallettxes=2");
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                shouldRestart = false;
            }
        }

        private void btnReindex_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Reopen to reindex the wallet", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //canClose = true;
                shouldRestart = true;
                File.WriteAllText(Types.startCommandsFile, "-reindex");
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                shouldRestart = false;
            }
        }

        private void btnNewAddressBook_Click(object sender, EventArgs e)
        {
            //NewLabel newLb = new NewLabel();
            //newLb.ShowDialog();
            //if(newLb.edit)
            //{
            //    String name = newLb.name;
            //    String address = newLb.address;
            //    addAddressBook(new Types.AddressBook(name, address));
            //}
        }

        private void dtgAdressBook_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridView dtg = (DataGridView)(sender);
            //int index = dtg.CurrentRow.Index;
            //String label = dtg.Rows[index].Cells[0].Value.ToString();
            //String address = dtg.Rows[index].Cells[1].Value.ToString();
            //NewLabel newLb = new NewLabel(label, address);
            //newLb.ShowDialog();
            //if (newLb.edit)
            //{
            //    book.RemoveAll(x => x.label == label);
            //    label = newLb.name;
            //    address = newLb.address;
            //    editAddressBook(new Types.AddressBook(label, address), dtg, index);
            //}
        }

        private void cbbAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex > -1)
            {
                int index = book.FindIndex(f => f.label == ((ComboBox)sender).SelectedItem.ToString());
                tbPayTo.Text = book[index].address;
            }
        }

        private void tbPayTo_Leave(object sender, EventArgs e)
        {
            int index = book.FindIndex(f => f.address == ((TextBox)sender).Text);
            if (index >= 0)
            {
                cbbAddress.SelectedIndex = cbbAddress.FindStringExact(book[index].label);
            }
            else
            {
                cbbAddress.SelectedIndex = -1;
            }
        }

        private void peersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String peers = Task.Run(() => api.getPeerInfo()).Result;
            List<String> split = peers.Split(new String[] { "    \"addr\": \"", "\",", "\n" }, StringSplitOptions.None).ToList();
            split.RemoveAll(String.IsNullOrEmpty);
            String peerstr = "";
            foreach (String s in split)
            {
                peerstr += s + "\n";
            }
            Debug db = new Debug(Types.DebugType.PEERS, peerstr);
            db.ShowDialog();
        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String peers = Task.Run(() => api.getPeerInfo()).Result;
            List<String> split = peers.Split(new String[] { "    \"addr\": \"", "\",", "\n" }, StringSplitOptions.None).ToList();
            split.RemoveAll(String.IsNullOrEmpty);
            String peerstr = "";
            foreach (String s in split)
            {
                peerstr += s + "\n";
            }
            Debug db = new Debug(Types.DebugType.DEBUG, peerstr);
            db.ShowDialog();
        }


        private void copyZeroconfDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(api.appdata + "zero.conf"))
            {
                Clipboard.SetText(File.ReadAllText(api.appdata + "zero.conf"));
                MessageBox.Show("Copied");
            }
            else
            {
                MessageBox.Show("Can not read zero.conf file");
            }
        }

        private void btnGetMNPrivKey_Click(object sender, EventArgs e)
        {
            String privKey = api.getMNPrivKey();
            Masternode mn = new Masternode("Zeronode Private Key", privKey);
            mn.ShowDialog();
        }

        private void btnGetOutputs_Click(object sender, EventArgs e)
        {
            String outputs = api.getMNOutputs();
            List<Types.Outputs> outputList = readOutputsList(outputs);
            try
            {
                if (outputList.Count == 0)
                {
                    MessageBox.Show("Could not get any outputs, please wait");
                }
                else
                {
                    foreach (Types.Masternode m in mn)
                    {
                        outputList.RemoveAll(op => op.txhash.Contains(m.txHash));
                    }

                    for (int i = outputList.Count - 1; i >= 0; i--)
                    {
                        Masternode mnForm = new Masternode("Outputs " + (outputList.Count - i), outputList[i].txhash + " " + outputList[i].outputidx);
                        mnForm.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not get any outputs, please wait");
            }
        }

        private void btnEditConfigFile_Click(object sender, EventArgs e)
        {
            ConfigureMasternode cf = new ConfigureMasternode(new Types.Masternode(), true);
            cf.ShowDialog();
            if (cf.result == Types.ConfigureResult.OK || cf.result == Types.ConfigureResult.REINDEX)
            {
                if (cf.result == Types.ConfigureResult.REINDEX)
                {
                    File.WriteAllText(Types.startCommandsFile, "-reindex");
                }
                DialogResult result2 = MessageBox.Show("Restart the wallet?", "", MessageBoxButtons.YesNo);
                if (result2 == DialogResult.Yes)
                {
                    canClose = true;
                    shouldRestart = true;
                    this.Close();
                }
            }
            populateMasternodes();
        }

        private void btnStartMasternode_Click(object sender, EventArgs e)
        {
            int rowIndex = -1;
            String aliasName = "";
            if (dtgMasternode.CurrentCell != null)
            {
                rowIndex = dtgMasternode.CurrentCell.RowIndex;
            }
            else
            {
                MessageBox.Show("You must choose a Masternode");
                return;
            }
            if (rowIndex > -1)
            {
                if (dtgMasternode.Rows[rowIndex].Cells[1].Value == null)
                {
                    MessageBox.Show("Masternode cannot be null");
                    return;
                }

                aliasName = dtgMasternode.Rows[rowIndex].Cells[1].Value.ToString();
                if (String.IsNullOrEmpty(aliasName))
                {
                    MessageBox.Show("Masternode cannot be empty");
                    return;
                }
                String rtn = api.startMasternode(aliasName);

                dynamic parse = JsonConvert.DeserializeObject<Types.StartMNResponse>(rtn);

                if (parse.detail[0].result == "successful")
                {
                    MessageBox.Show("Start successfully");
                }
                else
                {
                    MessageBox.Show("Start fail, reason: " + parse.detail[0].error);
                }
            }
        }

        private void btnStartAlias_Click(object sender, EventArgs e)
        {
            int rowIndex = -1;
            String aliasName = "";
            if (dtgMasternode.CurrentCell != null)
            {
                rowIndex = dtgMasternode.CurrentCell.RowIndex;
            }
            else
            {
                MessageBox.Show("You must choose a Masternode");
                return;
            }
            if (rowIndex > -1)
            {
                Object obj = dtgMasternode.Rows[rowIndex].Cells[1].Value;
                if (obj != null && !String.IsNullOrEmpty(obj.ToString()))
                {
                    aliasName = obj.ToString();
                    String rtn = api.startAlias(aliasName);
                    if (rtn.Contains("success"))
                    {
                        MessageBox.Show("Start " + aliasName + " successfully");
                    }
                    else
                    {
                        MessageBox.Show(rtn);
                    }
                }
                else
                {
                    MessageBox.Show("Alias name could not be empty");
                }
                //parse return
            }
        }

        private void tpMasternode_Enter(object sender, EventArgs e)
        {
            dtgMasternode.Visible = true;
            dtgGlobalMN.Visible = true;
        }

        private void tpMasternode_Leave(object sender, EventArgs e)
        {
            dtgMasternode.Visible = false;
            dtgGlobalMN.Visible = false;
        }

        private void btnRefreshMasternode_Click(object sender, EventArgs e)
        {
            shouldUpdateMN = true;
        }

        private void enableAutoBackupWalletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String enableFile = Path.GetTempPath() + "\\autoBackup.zero";
            if (!File.Exists(enableFile))
            {
                File.WriteAllText(enableFile, "1");

            }

            String read = File.ReadAllText(enableFile);

            if (read == "1")
            {
                ((ToolStripMenuItem)sender).Text = "Enable auto backup wallet";
                File.WriteAllText(enableFile, "0");
            }
            else
            {
                ((ToolStripMenuItem)sender).Text = "Disable auto backup wallet";
                File.WriteAllText(enableFile, "1");
            }
        }

        private void dtgGlobalMN_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            foreach (Types.Masternode m in mn)
            {
                try
                {
                    row = ((DataGridView)sender).Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells[7].Value.ToString().Equals(m.txHash))
                    .First();

                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                catch (Exception ex) { }
            }

            foreach (Types.AddressBook b in book)
            {
                try
                {
                    row = ((DataGridView)sender).Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells[1].Value.ToString().Equals(b.address))
                    .First();

                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                catch (Exception ex) { }
            }

            foreach (string s in walletDic.Keys)
            {
                try
                {
                    row = ((DataGridView)sender).Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells[1].Value.ToString().Equals(s))
                    .First();

                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                catch (Exception ex) { }
            }
            return;
        }

        private void tbSearch_Leave(object sender, EventArgs e)
        {
            if (tbSearch.Text == "")
            {
                tbSearch.Text = "Masternode address or tx hash";
                tbSearch.ForeColor = Color.Gray;
            }
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            if (tbSearch.Text == "Masternode address or tx hash")
            {
                tbSearch.Text = "";
                tbSearch.ForeColor = Color.Gray;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = dtgGlobalMN.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells[7].Value.ToString().Equals(tbSearch.Text) || r.Cells[1].Value.ToString().Equals(tbSearch.Text))
                .First();

                row.DefaultCellStyle.BackColor = Color.Cyan;
                dtgGlobalMN.FirstDisplayedScrollingRowIndex = row.Index;
            }
            catch (Exception ex) { MessageBox.Show("Could not find: " + tbSearch.Text); }
        }

        private void btnSearch_MouseEnter(object sender, EventArgs e)
        {
            ((RoundButton)sender).BackgroundImage = global::SimpleWallet.Properties.Resources.search_dark;
        }

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            ((RoundButton)sender).BackgroundImage = global::SimpleWallet.Properties.Resources.search1;
        }

        private void btnShield_Click(object sender, EventArgs e)
        {
            if (cbbShieldFrom.SelectedIndex == -1)
            {
                MessageBox.Show("Please select shielding wallet ");
                return;
            }
            if (cbbShieldFrom.SelectedIndex == -1)
            {
                MessageBox.Show("Please select destination wallet");
                return;
            }

            if (String.IsNullOrEmpty(tbShieldUtxo.Text))
            {
                MessageBox.Show("Shield utxo is empty");
                return;
            }

            ((Button)sender).Enabled = false;

            String from = cbbShieldFrom.SelectedItem.ToString().Split(new String[] { " - " }, StringSplitOptions.None)[0];
            String to = cbbShieldTo.SelectedItem.ToString();
            Dictionary<String, String> strDict = api.checkWallet(tbPayTo.Text);
            strDict = Task.Run(() => api.shieldCoin(from, to, tbShieldUtxo.Text,
                tbShieldFee.Text, cbShieldDefaultFee.Checked)).Result;

            SendingCoin send = new SendingCoin(strDict, Types.TransactionType.SHIELD_COIN);
            send.ShowDialog();
            strDict = send.data;

            if (Api.checkResult(strDict))
            {
                addressBalanceChange.Add(from);
                addressBalanceChange.Add(to);
                shouldGetTransaction = true;
                shouldGetWallet = true;
                MessageBox.Show("Success\n" + strDict["message"]);
            }
            else
            {
                MessageBox.Show(Api.getMessage(strDict));
            }
            ((Button)sender).Enabled = true;

        }

        private void cbShieldDefaultFee_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                tbShieldFee.Enabled = false;
            }
            else
            {
                tbShieldFee.Enabled = true;
            }
        }

        private void tbShieldUtxo_Enter(object sender, EventArgs e)
        {
            if (tbShieldUtxo.Text == "utxo to shield")
            {
                tbShieldUtxo.Text = "";
                tbShieldUtxo.ForeColor = Color.Black;
            }
        }

        private void tbShieldUtxo_Leave(object sender, EventArgs e)
        {
            if (tbShieldUtxo.Text == "")
            {
                tbShieldUtxo.Text = "utxo to shield";
                tbShieldUtxo.ForeColor = Color.Gray;
            }
        }

        private void dtgAddress_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu ctxMenu = new ContextMenu();
                Types.CtxMenuType type = Types.CtxMenuType.WALLET;
                if (((DataGridView)sender).Name == "dtgAddress")
                {
                    type = Types.CtxMenuType.WALLET;
                }
                else if (((DataGridView)sender).Name == "dtgTransactions")
                {
                    type = Types.CtxMenuType.TRANSACTIONS;
                }
                else if (((DataGridView)sender).Name == "dtgGlobalMN")
                {
                    type = Types.CtxMenuType.MASTERNODE_GLOBAL;
                }
                else if (((DataGridView)sender).Name == "dtgMasternode")
                {
                    type = Types.CtxMenuType.MASTERNODE;
                }

                if (type == Types.CtxMenuType.WALLET)
                {
                    ctxMenu.MenuItems.Add(new CustomMenuItem("View QR code", ctxMenu_ViewQrCode, type));
                }
                else if (type == Types.CtxMenuType.TRANSACTIONS)
                {
                    ctxMenu.MenuItems.Add(new CustomMenuItem("View transaction detail", ctxMenu_ViewDetailTx, type));
                }
               
                int currentMouseOverRow = ((DataGridView)sender).HitTest(e.X, e.Y).RowIndex;
                int currentMouseOverColumn = ((DataGridView)sender).HitTest(e.X, e.Y).ColumnIndex;
                if (currentMouseOverRow >= 0 && currentMouseOverColumn >= 0)
                {
                    ((DataGridView)sender).CurrentCell = ((DataGridView)sender).Rows[currentMouseOverRow].Cells[currentMouseOverColumn];
                }

                ctxMenu.Show(((DataGridView)sender), new Point(e.X, e.Y));

                rightClick.isClicked = true;
                rightClick.type = type;
                int currentMouseOverRow1 = ((DataGridView)sender).HitTest(e.X, e.Y).RowIndex;
                int currentMouseOverColumn1 = ((DataGridView)sender).HitTest(e.X, e.Y).ColumnIndex;
                rightClick.rowIdx = currentMouseOverRow1;
                rightClick.colIdx = currentMouseOverColumn1;
                rightClick.x = e.X;
                rightClick.y = e.Y;


            }
        }

        private void ctxMenu_ViewQrCode(Object sender, System.EventArgs e)
        {
            CustomMenuItem item = sender as CustomMenuItem;
            if (item.type == Types.CtxMenuType.WALLET)
            {
                if (dtgAddress.CurrentCell != null && dtgAddress.CurrentCell.Value != null)
                {
                    QrCode qr = new QrCode(dtgAddress.Rows[dtgAddress.CurrentRow.Index].Cells[0].Value.ToString());
                    qr.ShowDialog();
                }
            }
        }

        private void ctxMenu_ViewDetailTx(Object sender, System.EventArgs e)
        {
            CustomMenuItem item = sender as CustomMenuItem;
            if (item.type == Types.CtxMenuType.TRANSACTIONS)
            {
                if (dtgTransactions.CurrentCell != null && dtgTransactions.CurrentCell.Value != null)
                {
                    //get transaction data
                    DataGridView dtg = dtgTransactions;
                    int index = dtg.CurrentRow.Index;
                    string txid = dtg.Rows[index].Cells[5].Value.ToString();
                    string data = Task.Run(() => api.getTransaction(txid)).Result;
                    TransactionDetail txDetail = new TransactionDetail(data);
                    txDetail.ShowDialog();
                }
            }
        }

        private void ctxMenu_ViewPrivateKey(Object sender, System.EventArgs e)
        {
            CustomMenuItem item = sender as CustomMenuItem;
            if (item.type == Types.CtxMenuType.WALLET)
            {
                try
                {
                    Dictionary<String, String> strDict = api.exportPrivateKey(dtgAddress.CurrentRow.Cells[0].FormattedValue.ToString());
                    if (!Api.checkResult(strDict))
                    {
                        MessageBox.Show(Api.getMessage(strDict));
                    }
                    else
                    {
                        Clipboard.SetText(Api.getMessage(strDict));
                        MessageBox.Show("The private key has also been copied to the clipboard." + System.Environment.NewLine + System.Environment.NewLine + "Your keys for address " +
                                         dtgAddress.CurrentRow.Cells[0].FormattedValue.ToString() + " is: " +
                                         System.Environment.NewLine + System.Environment.NewLine + Api.getMessage(strDict));
                    }
                }
                catch
                {
                    MessageBox.Show("Could not export private key, please select your address");
                }
            }
        }
        private void ctxMenu_CopyAddress(Object sender, System.EventArgs e)
        {
            CustomMenuItem item = sender as CustomMenuItem;
            if (item.type == Types.CtxMenuType.WALLET)
            {
                try
                {
                    Clipboard.SetText(dtgAddress.CurrentRow.Cells[0].FormattedValue.ToString());
                }
                catch
                {
                }
            }
        }

        private void ctxMenu_Copy(Object sender, System.EventArgs e)
        {
            CustomMenuItem item = sender as CustomMenuItem;
            if (item.type == Types.CtxMenuType.MASTERNODE)
            {
                if (dtgMasternode.CurrentCell != null && dtgMasternode.CurrentCell.Value != null)
                {
                    String text = dtgMasternode.CurrentCell.Value.ToString();
                    Clipboard.SetText(text);
                }
            }
            else if (item.type == Types.CtxMenuType.MASTERNODE_GLOBAL)
            {
                if (dtgGlobalMN.CurrentCell != null && dtgGlobalMN.CurrentCell.Value != null)
                {
                    String text = dtgGlobalMN.CurrentCell.Value.ToString();
                    Clipboard.SetText(text);
                }
            }
            else if (item.type == Types.CtxMenuType.WALLET)
            {
                if (dtgAddress.CurrentCell != null && dtgAddress.CurrentCell.Value != null)
                {
                    String text = dtgAddress.CurrentCell.Value.ToString();
                    Clipboard.SetText(text);
                }
            }
            else if (item.type == Types.CtxMenuType.TRANSACTIONS)
            {
                if (dtgTransactions.CurrentCell != null && dtgTransactions.CurrentCell.Value != null)
                {
                    String text = dtgTransactions.CurrentCell.Value.ToString();
                    Clipboard.SetText(text);
                }
            }
        }

        private void ctxMenu_StatusAlias(Object sender, System.EventArgs e)
        {
            CustomMenuItem item = sender as CustomMenuItem;
            if (item.type == Types.CtxMenuType.MASTERNODE)
            {
                if (dtgMasternode.CurrentCell != null && dtgMasternode.CurrentCell.Value != null)
                {
                    int index = dtgMasternode.CurrentRow.Index;
                    String status = dtgMasternode.Rows[index].Cells[0].Value.ToString();
                    String text = "";
                    if (status == "ENABLE")
                    {
                        text = "DISABLE";
                    }
                    else
                    {
                        text = "ENABLE";
                    }
                    string aliasName = dtgMasternode.Rows[index].Cells[1].Value.ToString();
                    string IP = dtgMasternode.Rows[index].Cells[2].Value.ToString();
                    string privKey = dtgMasternode.Rows[index].Cells[3].Value.ToString();
                    string txHash = dtgMasternode.Rows[index].Cells[4].Value.ToString();
                    string txIndex = dtgMasternode.Rows[index].Cells[5].Value.ToString();

                    int countEnable = 0;
                    foreach (DataGridViewRow row in dtgMasternode.Rows)
                    {
                        if (row.Cells[0].Value.ToString() == "ENABLE")
                        {
                            countEnable++;
                        }
                    }

                    bool isDisableAll = false;
                    if (countEnable == 1)
                    {
                        isDisableAll = true;
                    }

                    Types.ConfigureResult result = api.changeStatus(text, aliasName, IP, privKey, txHash, txIndex, isDisableAll);

                    if (result == Types.ConfigureResult.OK || result == Types.ConfigureResult.REINDEX)
                    {
                        DialogResult dialogResult = MessageBox.Show("Your configuration has changed. Please restart your wallet to update", "Restart the wallet?", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            canClose = true;
                            shouldRestart = true;
                            this.Close();
                        }
                    }
                    populateMasternodes();
                }
            }
        }

        private void ctxMenu_EnableAllAlias(Object sender, System.EventArgs e)
        {
            CustomMenuItem item = sender as CustomMenuItem;
            if (item.type == Types.CtxMenuType.MASTERNODE)
            {
                foreach (DataGridViewRow row in dtgMasternode.Rows)
                {
                    String status = row.Cells[0].Value.ToString();
                    String text = "ENABLE";
                    string aliasName = row.Cells[1].Value.ToString();
                    string IP = row.Cells[2].Value.ToString();
                    string privKey = row.Cells[3].Value.ToString();
                    string txHash = row.Cells[4].Value.ToString();
                    string txIndex = row.Cells[5].Value.ToString();

                    Types.ConfigureResult result = api.changeStatus(text, aliasName, IP, privKey, txHash, txIndex, false);
                }
                DialogResult dialogResult = MessageBox.Show("Your configuration has changed. Please restart your wallet to update", "Restart the wallet?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    canClose = true;
                    shouldRestart = true;
                    this.Close();
                }
                populateMasternodes();
            }
        }

        private void ctxMenu_DisableAllAlias(Object sender, System.EventArgs e)
        {
            CustomMenuItem item = sender as CustomMenuItem;
            if (item.type == Types.CtxMenuType.MASTERNODE)
            {
                foreach (DataGridViewRow row in dtgMasternode.Rows)
                {
                    String status = row.Cells[0].Value.ToString();
                    String text = "DISABLE";
                    string aliasName = row.Cells[1].Value.ToString();
                    string IP = row.Cells[2].Value.ToString();
                    string privKey = row.Cells[3].Value.ToString();
                    string txHash = row.Cells[4].Value.ToString();
                    string txIndex = row.Cells[5].Value.ToString();

                    Types.ConfigureResult result = api.changeStatus(text, aliasName, IP, privKey, txHash, txIndex, true);
                }
                DialogResult dialogResult = MessageBox.Show("Your configuration has changed. Please restart your wallet to update", "Restart the wallet?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    canClose = true;
                    shouldRestart = true;
                    this.Close();
                }
                populateMasternodes();
            }
        }

        private void ctxMenu_CopyMNAlias(Object sender, System.EventArgs e)
        {
            CustomMenuItem item = sender as CustomMenuItem;
            if (item.type == Types.CtxMenuType.MASTERNODE)
            {
                if (dtgMasternode.CurrentCell != null && dtgMasternode.CurrentCell.Value != null)
                {
                    int index = dtgMasternode.CurrentRow.Index;
                    string aliasName = dtgMasternode.Rows[index].Cells[1].Value.ToString();
                    string IP = dtgMasternode.Rows[index].Cells[2].Value.ToString();
                    string privKey = dtgMasternode.Rows[index].Cells[3].Value.ToString();
                    string txHash = dtgMasternode.Rows[index].Cells[4].Value.ToString();
                    string txIndex = dtgMasternode.Rows[index].Cells[5].Value.ToString();
                    Types.Masternode mn = new Types.Masternode("ENABLE", aliasName, IP, privKey, txHash, txIndex);
                    String text = mn.ToString();
                    Clipboard.SetText(text);
                }
            }
        }

        private void ctxMenu_CopyZeroConfigure(Object sender, System.EventArgs e)
        {
            CustomMenuItem item = sender as CustomMenuItem;
            if (item.type == Types.CtxMenuType.MASTERNODE)
            {
                if (dtgMasternode.CurrentCell != null && dtgMasternode.CurrentCell.Value != null)
                {
                    String confFile = Types.cfLocation;

                    int index = dtgMasternode.CurrentRow.Index;
                    string aliasName = dtgMasternode.Rows[index].Cells[1].Value.ToString();
                    string IP = dtgMasternode.Rows[index].Cells[2].Value.ToString();
                    string privKey = dtgMasternode.Rows[index].Cells[3].Value.ToString();
                    string txHash = dtgMasternode.Rows[index].Cells[4].Value.ToString();
                    string txIndex = dtgMasternode.Rows[index].Cells[5].Value.ToString();

                    String LocalIP = new WebClient().DownloadString("http://icanhazip.com");
                    LocalIP = LocalIP.TrimEnd('\r', '\n');

                    //config file
                    List<String> text = File.ReadAllLines(confFile).ToList();
                    text.RemoveAll(String.IsNullOrEmpty);
                    
                    if (LocalIP == IP)
                    {
                        index = text.FindIndex(x => x.StartsWith("zeronode="));
                        if (index == -1)
                        {
                            text.Add("zeronode=1");
                        }
                        index = text.FindIndex(x => x.StartsWith("zeronodeaddr"));
                        if (index == -1)
                        {
                            text.Add("zeronodeaddr=" + IP);
                        }
                        index = text.FindIndex(x => x.StartsWith("externalip"));
                        if (index == -1)
                        {
                            text.Add("externalip=" + IP);
                        }
                        index = text.FindIndex(x => x.StartsWith("zeronodeprivkey"));
                        if (index == -1)
                        {
                            text.Add("zeronodeprivkey=" + privKey);
                        }
                    }

                    index = text.FindIndex(x => x.StartsWith("txindex="));
                    if (index == -1)
                    {
                        text.Add("txindex=1");
                    }

                    String txt = String.Join("\n", text);
                    Clipboard.SetText(txt);
                }
            }
        }

        private void ctxMenu_Edit(Object sender, System.EventArgs e)
        {
            CustomMenuItem item = sender as CustomMenuItem;

            if (item.type == Types.CtxMenuType.MASTERNODE)
            {
                DataGridView dtg = dtgMasternode;
                int index = dtg.CurrentRow.Index;

                String status = dtg.CurrentRow.Cells[0].Value.ToString();
                String alias = dtg.CurrentRow.Cells[1].Value.ToString();
                String ip = dtg.CurrentRow.Cells[2].Value.ToString().Split(':')[0];
                String privKey = dtg.CurrentRow.Cells[3].Value.ToString();
                String txhash = dtg.CurrentRow.Cells[4].Value.ToString();
                String txIndex = dtg.CurrentRow.Cells[5].Value.ToString();

                ConfigureMasternode cf = new ConfigureMasternode(new Types.Masternode(status, alias, ip, privKey, txhash, txIndex), false);
                cf.ShowDialog();
                if (cf.result == Types.ConfigureResult.OK || cf.result == Types.ConfigureResult.REINDEX)
                {
                    String text = " these changes";
                    if (cf.result == Types.ConfigureResult.REINDEX)
                    {
                        text = "reindexing wallet";
                        File.WriteAllText(Types.startCommandsFile, "-reindex");
                    }


                    DialogResult result = MessageBox.Show("Your configuration has changed. Please restart your wallet for" + text, "Restart the wallet?", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        canClose = true;
                        shouldRestart = true;
                        this.Close();
                    }
                    else
                    {
                        shouldRestart = false;
                    }
                }
                populateMasternodes();

            }
        }

        private void ctxMenu_Delete(Object sender, System.EventArgs e)
        {
            CustomMenuItem item = sender as CustomMenuItem;

            if (item.type == Types.CtxMenuType.MASTERNODE)
            {
                try
                {
                    if (dtgMasternode.CurrentCell != null && dtgMasternode.Rows[dtgMasternode.CurrentCell.RowIndex].Cells[1].Value != null)
                    {
                        String name = dtgMasternode.Rows[dtgMasternode.CurrentCell.RowIndex].Cells[1].Value.ToString();
                        String tdix = dtgMasternode.Rows[dtgMasternode.CurrentCell.RowIndex].Cells[4].Value.ToString();
                        if (!String.IsNullOrEmpty(name))
                        {
                            DialogResult dialogResult = MessageBox.Show(@"Do you want to delete " + name, "ATTENTION!!!", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                List<String> data = File.ReadAllLines(Types.mnLocation).ToList();
                                int index = data.FindIndex(x => x.Contains(tdix));
                                if (index >= 0)
                                {
                                    data.RemoveAt(index);
                                }
                                File.WriteAllLines(Types.mnLocation, data);

                                //dialogResult = MessageBox.Show("Your configuration has changed. Please restart your wallet to update", "Restart the wallet?", MessageBoxButtons.YesNo);
                                //if (dialogResult == DialogResult.Yes)
                                //{
                                //    canClose = true;
                                //    shouldRestart = true;
                                //    this.Close();
                                //}
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cannot delete empty String");
                    }
                    populateMasternodes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete Masternode error");
                }
            }
        }

        private void Dtg_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
        }

        private void tcMain_DrawItem(object sender, DrawItemEventArgs e)
        {
        }

        private void dtgTransactions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)(sender)).CurrentCell.Value != null)
            {
                //get transaction data
                DataGridView dtg = (DataGridView)(sender);
                int index = dtg.CurrentRow.Index;
                string txid = dtg.Rows[index].Cells[5].Value.ToString();
                string data = Task.Run(() => api.getZeroTransaction(txid)).Result;
                TransactionDetail txDetail = new TransactionDetail(data);
                txDetail.ShowDialog();
            }
        }

        private void btnAddressBook_Click(object sender, EventArgs e)
        {
            AddressBook addrBook = new AddressBook(book);
            addrBook.ShowDialog();
            book = new List<Types.AddressBook>(addrBook.book);
            Task.Run(() => loadAddressBook(book));
            loadWallet();
        }

        private void dtg_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu ctxMenu = new ContextMenu();
                Types.CtxMenuType type = Types.CtxMenuType.WALLET;
                if (((DataGridView)sender).Name == "dtgAddress")
                {
                    type = Types.CtxMenuType.WALLET;
                }
                else if (((DataGridView)sender).Name == "dtgTransactions")
                {
                    type = Types.CtxMenuType.TRANSACTIONS;
                }
                else if (((DataGridView)sender).Name == "dtgGlobalMN")
                {
                    type = Types.CtxMenuType.MASTERNODE_GLOBAL;
                }
                else if (((DataGridView)sender).Name == "dtgMasternode")
                {
                    type = Types.CtxMenuType.MASTERNODE;
                }

                rightClick.isClicked = true;
                rightClick.type = type;
                int currentMouseOverRow1 = ((DataGridView)sender).HitTest(e.X, e.Y).RowIndex;
                int currentMouseOverColumn1 = ((DataGridView)sender).HitTest(e.X, e.Y).ColumnIndex;
                rightClick.rowIdx = currentMouseOverRow1;
                rightClick.colIdx = currentMouseOverColumn1;
                rightClick.x = e.X;
                rightClick.y = e.Y;

            }
        }

        private void btnStartAll_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(@"Do you want to start all alias?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                String rtn = api.startAll();
                //Message errMsg = new Message("Message", rtn);
                //errMsg.ShowDialog();
            }
        }

        private void btnClearMNCache_Click(object sender, EventArgs e)
        {
            shouldDeleteMNCache = true;
            DialogResult dialogResult = MessageBox.Show("Do you want to restart the wallet?", "Reopen to load masternode list", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                canClose = true;
                shouldRestart = true;
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                shouldRestart = false;
            }
        }

        private void btnOverview_Click(object sender, EventArgs e)
        {
            pnlOverview.BringToFront();
        }

        private void btnReceiveCoins_Click(object sender, EventArgs e)
        {
            pnlReceiveCoins.BringToFront();
        }

        private void btnSendCoins_Click(object sender, EventArgs e)
        {
            pnlSendCoins.BringToFront();
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            pnlTransactions.BringToFront();
        }
        private void btnMasternode_Click(object sender, EventArgs e)
        {
            pnlZeronodes.BringToFront();
        }
        private void btnWalletInfo_Click(object sender, EventArgs e)
        {
            pnlInfo.BringToFront();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgAddress_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Types.CtxMenuType type = Types.CtxMenuType.WALLET;
                ContextMenu ctxMenu = new ContextMenu();
                ctxMenu.MenuItems.Add(new CustomMenuItem("Copy Address", ctxMenu_CopyAddress, type));
                ctxMenu.MenuItems.Add(new CustomMenuItem("View Private Key", ctxMenu_ViewPrivateKey, type));
                ctxMenu.MenuItems.Add(new CustomMenuItem("View Qr Code", ctxMenu_ViewQrCode, type));
                ((DataGridView)sender).CurrentCell = ((DataGridView)sender).Rows[rightClick.rowIdx].Cells[0];
                ctxMenu.Show(((DataGridView)sender), new Point(rightClick.x, rightClick.y));
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dtgMasternode_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Types.CtxMenuType type = Types.CtxMenuType.MASTERNODE;
                ContextMenu ctxMenu = new ContextMenu();
                //if (dtgMasternode.Rows[rightClick.rowIdx].Cells[0].Value == null)
                //        {
                //            return;
                //        }
                String status = dtgMasternode.Rows[rightClick.rowIdx].Cells[0].Value.ToString();
                String text = "";
                if (status == "ENABLE")
                {
                    text = "Disable";
                }
                else
                {
                    text = "Enable";
                }
                ctxMenu.MenuItems.Add(new CustomMenuItem("Copy zero.conf data", ctxMenu_CopyZeroConfigure, type));
                ctxMenu.MenuItems.Add(new CustomMenuItem("Copy alias data", ctxMenu_CopyMNAlias, type));
                ctxMenu.MenuItems.Add(new CustomMenuItem("Edit alias data", ctxMenu_Edit, type));
                ctxMenu.MenuItems.Add(new CustomMenuItem(text, ctxMenu_StatusAlias, type));
                ctxMenu.MenuItems.Add(new CustomMenuItem("Enable all", ctxMenu_EnableAllAlias, type));
                ctxMenu.MenuItems.Add(new CustomMenuItem("Disable all", ctxMenu_DisableAllAlias, type));
                ctxMenu.MenuItems.Add(new CustomMenuItem("Delete", ctxMenu_Delete, type));
                ((DataGridView)sender).CurrentCell = ((DataGridView)sender).Rows[rightClick.rowIdx].Cells[1];
                ctxMenu.Show(((DataGridView)sender), new Point(rightClick.x, rightClick.y));
            }
        }

        private void dtgGlobalMN_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //Types.CtxMenuType type = Types.CtxMenuType.MASTERNODE_GLOBAL;
                //ContextMenu ctxMenu = new ContextMenu();
                changeMNColor((DataGridView)sender);
            }
        }

        private void btnMaxAmount_Click(object sender, EventArgs e)
        {
            if (cbbFrom.SelectedItem.ToString().Contains("-"))
            {
                int Start = cbbFrom.SelectedItem.ToString().IndexOf("-", 0);
                Int64 maxAmount = Convert.ToInt64(Convert.ToDouble(cbbFrom.SelectedItem.ToString().Substring(Start + 2)) * 10e8);
                Int64 fee = Convert.ToInt64(Convert.ToDouble(tbFee.Text) * 10e8);
                tbAmount.Text =  Convert.ToString(Convert.ToDouble(maxAmount - fee) / 10e8);
            }

        }

        



        
    }

    public class CustomMenuItem : MenuItem
    {
        public Types.CtxMenuType type { get; set; }

        public CustomMenuItem(string text, EventHandler onClick, Types.CtxMenuType type)
            : base(text, onClick)
        {
            this.type = type;
        }
    }
}