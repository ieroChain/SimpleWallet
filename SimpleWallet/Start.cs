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

        public List<String> addressBalanceChange = new List<String>();
        public List<Types.Transaction> listtransactions = new List<Types.Transaction>();
        List<Types.TransactionConverted> txconvert = new List<Types.TransactionConverted>();
        public static String privKey = "";
        const int startTime = 1487462548;
        int numConnection = 0;
        int bestHeight = 0;
        Object lockObj = new Object();

        public bool shouldRestart = false;
        bool shouldGetTransaction = false;
        bool shouldGetWallet = false;
        String outImg = "Images\\outboundred.png";
        String inImg = "Images\\inboundgreen.png";
        System.Timers.Timer closeTmr = new System.Timers.Timer(5000);

        Dictionary<String, String> oldWalletDic = new Dictionary<String, String>();
        public Dictionary<String, String> walletDic = new Dictionary<String, String>();
        List<String> oldTransactions = new List<String>();
        List<String> transactions = new List<String>();
        WebClient proving = new WebClient();
        WebClient verifying = new WebClient();

        List<Types.AddressBook> book = new List<Types.AddressBook>();

        Types.RightClickData rightClick = new Types.RightClickData();
        List<String> oldTx = new List<String>();
        Api api = Api.Instance;
        Types type = new Types();

        public Start()
        {
            InitializeComponent();
            dtgAddress.ColumnCount = 3;
            dtgAddress.RowHeadersVisible = false;
            dtgAddress.Columns[0].Name = "Confirmed";
            dtgAddress.Columns[0].Width = dtgAddress.Width / 10;
            dtgAddress.Columns[0].ReadOnly = true;
            dtgAddress.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgAddress.Columns[1].Name = "Address";
            dtgAddress.Columns[1].Width = dtgAddress.Width * 7 / 10;
            dtgAddress.Columns[1].ReadOnly = true;
            dtgAddress.Columns[2].Name = "Amount";
            dtgAddress.Columns[2].Width = dtgAddress.Width * 2 / 10;
            dtgAddress.Columns[2].ReadOnly = true;
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

            cbUnit.SelectedIndex = 0;
            groupBox1.Enabled = false;
            groupBox1.Hide();


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
            lbTotal.Invoke(new Action(() => lblTotalUnconfirmed.Text = totalbalanceunconfirmed));
            //balance
            lbPrivate.Invoke(new Action(() => lbPrivate.Text = privatebalance));
            lbPrivate.Invoke(new Action(() => lblPrivateUnconfirmed.Text = privatebalanceunconfirmed));

            //balance
            lbTransparent.Invoke(new Action(() => lbTransparent.Text = transparentbalance));
            lbTransparent.Invoke(new Action(() => lblTransparentUnconfirmed.Text = transparentbalanceunconfirmed));

            if (totalbalance==totalbalanceunconfirmed &&
                privatebalance==privatebalanceunconfirmed &&
                transparentbalance==transparentbalanceunconfirmed)
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
            listtransactions.Reverse();

            //populate recent trans
            populateRecentTx(listtransactions);

            //populate balance
            populateBalance(walletDic);

            dtgTransactions.Invoke(new Action(() => dtgTransactions.Visible = false));

            book = api.readAddressBook();

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
            Types.AllData dataimport= new Types.AllData();
            List<String> addresses;
            populateTransactions(listtransactions, out addresses);
            startCheckBalance(walletDic);
            loadWallet();
            dtgTransactions.Invoke(new Action(() => dtgTransactions.Visible = true));
            bool isSynced = false;
            int count = 0;
            while (true)
            {
                try
                {
                    if (count == 15)
                    {
                        shouldGetWallet = true; // should get wallet at least 1 time per 120 sec
                    }
                    data = api.getNetworkHeight();
                    dynamic parse = JsonConvert.DeserializeObject<Types.Info>(data);
                    int nHeight = Convert.ToInt32(parse.blocks);
                    if (bestHeight + 1 == nHeight || shouldGetTransaction)
                    {
                        shouldGetWallet = true;
                    }

                    dataimport = api.getAllData();
                        
                    listtransactions = dataimport.listtransactions;

                    //recent transactions
                    listtransactions.Reverse();

                    populateRecentTx(listtransactions);

                    //transactions
                    populateTransactions(listtransactions, out addresses);

                    walletDic = new Dictionary<String, String>(dataimport.addressbalance[0]);
                    populateBalance(walletDic);
                    startCheckBalance(walletDic);
                    btnNewAddress.Invoke(new Action(() => btnNewAddress.Enabled = true));
                    btnNewZAddress.Invoke(new Action(() => btnNewZAddress.Enabled = true));

                    //balance
                    lbTotal.Invoke(new Action(() => lbTotal.Text = dataimport.totalbalance));
                    lbTotal.Invoke(new Action(() => lblTotalUnconfirmed.Text = dataimport.totalbalanceunconfirmed));

                    //balance
                    lbPrivate.Invoke(new Action(() => lbPrivate.Text = dataimport.privatebalance));
                    lbPrivate.Invoke(new Action(() => lblPrivateUnconfirmed.Text = dataimport.privatebalanceunconfirmed));

                    //balance
                    lbTransparent.Invoke(new Action(() => lbTransparent.Text = dataimport.transparentbalance));
                    lbTransparent.Invoke(new Action(() => lblTransparentUnconfirmed.Text = dataimport.transparentbalanceunconfirmed));

                    if (dataimport.totalbalance==dataimport.totalbalanceunconfirmed &&
                        dataimport.privatebalance==dataimport.privatebalanceunconfirmed &&
                        dataimport.transparentbalance==dataimport.transparentbalanceunconfirmed)
                    {
                        lblUnconfirmedHeader.Invoke(new Action (() => lblUnconfirmedHeader.Hide()));
                        lblTransparentUnconfirmed.Invoke(new Action (() => lblTransparentUnconfirmed.Hide()));
                        lblPrivateUnconfirmed.Invoke(new Action (() => lblPrivateUnconfirmed.Hide()));
                        lblTotalUnconfirmed.Invoke(new Action(() => lblTotalUnconfirmed.Hide()));
                    }
                    else
                    {
                        lblUnconfirmedHeader.Invoke(new Action(() => lblUnconfirmedHeader.Show()));
                        lblTransparentUnconfirmed.Invoke(new Action(() => lblTransparentUnconfirmed.Show()));
                        lblPrivateUnconfirmed.Invoke(new Action(() => lblPrivateUnconfirmed.Show()));
                        lblTotalUnconfirmed.Invoke(new Action(() => lblTotalUnconfirmed.Show()));
                    }

                    if (shouldGetWallet)
                    {
                        loadWallet();
                        shouldGetWallet = false;
                        shouldGetTransaction = false;
                        count = 0;
                    }
                    
                    bestHeight = nHeight;

                    //block hash
                    lbBestHash.Invoke(new Action(() => lbBestHash.Text = dataimport.bestblockhash));

                    //block time
                    String curr = dataimport.besttime;
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
                    populateConnections(dataimport.connectionCount);
                    
                    count++;
                }
                catch
                {

                }
                Thread.Sleep(8000);
            }
        }

        void startCheckBalance(List<String> addresses)
        {
            try
            {
                addresses = addresses.Distinct().ToList();
                foreach (String a in addresses)
                {
                    //get current balance of the address
                    String balance = Task.Run(() => api.getAddressBalance(a)).Result;
                    //update balance
                    updateBalance(a, balance);
                }
                //loadWallet();
            }
            catch  { }
        }

        void startCheckBalance(Dictionary<String, String> addresses)
        {
            try
            {
                foreach (String a in addresses.Keys)
                {
                    //get current balance of the address
                    String balance = Task.Run(() => api.getAddressBalance(a)).Result;
                    //update balance
                    updateBalance(a, balance);
                }
                //loadWallet();
            }
            catch { }
        }

        string CheckBalanceUnconfirmed(string a)
        {
            String balance = null;
            try
            {
                //get current balance of the address
                balance = Task.Run(() => api.getAddressBalanceUnconfirmed(a)).Result;
            }
            catch 
            {
                balance = "0.00";
            }
            return balance;
        }

        void updateBalance(String address, String balance)
        {
            DataGridViewRow row = new DataGridViewRow();
            String balanceUnconfirmed = "0.00";
            try
            {
                bool tempAllowUserToAddRows = dtgAddress.AllowUserToAddRows;

                dtgAddress.AllowUserToAddRows = false;


                row = dtgAddress.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells[1].Value.ToString().Equals(address))
                .First();

                dtgAddress.AllowUserToAddRows = tempAllowUserToAddRows;
            }
            catch  { return; }
            int rowIndex = row.Index;

            balanceUnconfirmed=CheckBalanceUnconfirmed(address);
            if (balanceUnconfirmed==balance)
            {
                dtgAddress.Invoke(new Action(() => dtgAddress.Rows[rowIndex].Cells[0].Value = "Yes"));
                dtgAddress.Invoke(new Action(() => dtgAddress.Rows[rowIndex].Cells[2].Value = balance));
            }
            else
            {
                dtgAddress.Invoke(new Action(() => dtgAddress.Rows[rowIndex].Cells[0].Value = "No"));
                dtgAddress.Invoke(new Action(() => dtgAddress.Rows[rowIndex].Cells[2].Value = balanceUnconfirmed));
            }
            
        }

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
                else if (connected >= 5 && connected < 7)
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

        String parseString(String input)
        {
            List<String> split = input.Split(new String[] { "\"", " ", ":", ",", "\n" }, StringSplitOptions.None).ToList();
            split.RemoveAll(String.IsNullOrEmpty);
            return split[split.Count - 1];
        }
        void addWalletInfo(Dictionary<String, String> data, Dictionary<String, String> oldData)
        {
            dtgAddress.Invoke(new Action(() => dtgAddress.Visible = false));
            if (data.Count != oldData.Count)
            {
                dtgAddress.Invoke(new Action(() => dtgAddress.Rows.Clear()));
                for (int i = 0; i < data.Keys.Count; i++)
                {
                    String[] row = { (i + 1).ToString(), data.Keys.ElementAt(i), data[data.Keys.ElementAt(i)] };
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
                        break;
                    }
                }
                if (shouldClear)
                {
                    dtgAddress.Invoke(new Action(() => dtgAddress.Rows.Clear()));
                    for (int i = 0; i < data.Keys.Count; i++)
                    {
                        String[] row = { i.ToString(), data.Keys.ElementAt(i), data[data.Keys.ElementAt(i)] };
                        dtgAddress.Invoke(new Action(() => dtgAddress.Rows.Add(row)));
                    }
                }
                else
                {
                    for (int i = 0; i < data.Keys.Count; i++)
                    {
                        if (data[data.Keys.ElementAt(i)] != oldData[data.Keys.ElementAt(i)])
                        {
                            dtgAddress.Invoke(new Action(() => dtgAddress.Rows[i].Cells[2].Value = data[data.Keys.ElementAt(i)]));
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
                        if ((Double.TryParse(walletDic[wallet], out output) && Convert.ToDouble(walletDic[wallet]) != 0) ||
                            (Double.TryParse(walletDic[wallet].Replace(".", ","), out output) && Convert.ToDouble(walletDic[wallet].Replace(".", ",")) != 0))
                        {
                            cbbAdd(cbbFrom, wallet + " - " + walletDic[wallet]);
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
                                cbbAdd(cbbShieldFrom, wallet + " - " + walletDic[wallet]);
                                countShieldFrom++;
                            }
                            else if (wallet.StartsWith("zc"))
                            {
                                if (selectedShieldToAddress == wallet)
                                {
                                    selectedShieldToIdx = countShieldTo;
                                }
                                cbbAdd(cbbShieldTo, wallet);
                                countShieldTo++;
                            }
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

        void populateBalance(Dictionary<String, String> walletDic)
        {
            walletDic.OrderBy(i => i.Key);

            addWalletInfo(walletDic, oldWalletDic);

            oldWalletDic = new Dictionary<String, String>(walletDic);

            if (btnNewAddress.Enabled == false)
            {
                btnNewAddress.Invoke(new Action(() => btnNewAddress.Enabled = true));
            }
            if (btnNewZAddress.Enabled == false)
            {
                btnNewAddress.Invoke(new Action(() => btnNewZAddress.Enabled = true));
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
            String fee = tbFee.Text;
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
            btnNewZAddress.Enabled = false;
            api.newAddress();
            shouldGetWallet = true;
            MessageBox.Show("Please wait few seconds for new address");
        }

        private void btnNewZAddress_Click(object sender, EventArgs e)
        {
            btnNewAddress.Enabled = false;
            btnNewZAddress.Enabled = false;
            api.newZAddress();
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
                    QrCode qr = new QrCode(dtgAddress.Rows[dtgAddress.CurrentRow.Index].Cells[1].Value.ToString());
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
                    Dictionary<String, String> strDict = api.exportPrivateKey(dtgAddress.CurrentRow.Cells[1].FormattedValue.ToString());
                    if (!Api.checkResult(strDict))
                    {
                        MessageBox.Show(Api.getMessage(strDict));
                    }
                    else
                    {
                        Clipboard.SetText(Api.getMessage(strDict));
                        MessageBox.Show("The private key has also been copied to the clipboard." + System.Environment.NewLine + System.Environment.NewLine + "Your keys for address " +
                                         dtgAddress.CurrentRow.Cells[1].FormattedValue.ToString() + " is: " +
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
                    Clipboard.SetText(dtgAddress.CurrentRow.Cells[1].FormattedValue.ToString());
                }
                catch
                {
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
                string data = Task.Run(() => api.getTransaction(txid)).Result;
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
                ((DataGridView)sender).CurrentCell = ((DataGridView)sender).Rows[rightClick.rowIdx].Cells[1];
                ctxMenu.Show(((DataGridView)sender), new Point(rightClick.x, rightClick.y));
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
