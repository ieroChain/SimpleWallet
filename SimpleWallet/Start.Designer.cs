namespace SimpleWallet
{
    partial class Start
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.walletToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportPrivateKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importPrivateKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importOnePrivateKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableAutoBackupWalletToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyZeroconfDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ttStart = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbPercent = new System.Windows.Forms.ProgressBar();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnWalletInfo = new System.Windows.Forms.Button();
            this.btnMasternode = new System.Windows.Forms.Button();
            this.btnTransactions = new System.Windows.Forms.Button();
            this.btnSendCoins = new System.Windows.Forms.Button();
            this.btnReceiveCoins = new System.Windows.Forms.Button();
            this.btnOverview = new System.Windows.Forms.Button();
            this.pnlOverview = new System.Windows.Forms.Panel();
            this.lblLockedMessage = new System.Windows.Forms.Label();
            this.pbTransaction4 = new System.Windows.Forms.PictureBox();
            this.pbTransaction3 = new System.Windows.Forms.PictureBox();
            this.pbTransaction2 = new System.Windows.Forms.PictureBox();
            this.pbTransaction1 = new System.Windows.Forms.PictureBox();
            this.pnlZeronodes = new System.Windows.Forms.Panel();
            this.btnClearMNCache = new System.Windows.Forms.Button();
            this.lbUpdateTime = new System.Windows.Forms.Label();
            this.btnRefreshZeronode = new System.Windows.Forms.Button();
            this.btnStartAll = new System.Windows.Forms.Button();
            this.btnStartAlias = new System.Windows.Forms.Button();
            this.btnStartZeronode = new System.Windows.Forms.Button();
            this.btnEditConfigFile = new System.Windows.Forms.Button();
            this.btnGetOutputs = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnGetMNPrivKey = new System.Windows.Forms.Button();
            this.dtgGlobalMN = new System.Windows.Forms.DataGridView();
            this.rankDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activetimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastseenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastpaidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txhashDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ipDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.masternodeDetailConvertedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtgMasternode = new System.Windows.Forms.DataGridView();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aliasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ipAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.privKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txHashDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.masternodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlTransactions = new System.Windows.Forms.Panel();
            this.btnReindex = new System.Windows.Forms.Button();
            this.dtgTransactions = new System.Windows.Forms.DataGridView();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.confirmationsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transactionConvertedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRescan = new System.Windows.Forms.Button();
            this.pnlSendCoins = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnMaxAmount = new System.Windows.Forms.Button();
            this.btnSendMany = new System.Windows.Forms.Button();
            this.cbbAddress = new System.Windows.Forms.ComboBox();
            this.cbDefaultFee = new System.Windows.Forms.CheckBox();
            this.cbbFrom = new System.Windows.Forms.ComboBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.cbUnit = new System.Windows.Forms.ComboBox();
            this.tbFee = new System.Windows.Forms.TextBox();
            this.tbLabel = new System.Windows.Forms.TextBox();
            this.tbPayTo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btShield = new System.Windows.Forms.Button();
            this.cbbShieldTo = new System.Windows.Forms.ComboBox();
            this.cbbShieldFrom = new System.Windows.Forms.ComboBox();
            this.tbShieldUtxo = new System.Windows.Forms.TextBox();
            this.cbShieldDefaultFee = new System.Windows.Forms.CheckBox();
            this.tbShieldFee = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.pbSignal = new System.Windows.Forms.PictureBox();
            this.pbStatus = new System.Windows.Forms.PictureBox();
            this.pnlReceiveCoins = new System.Windows.Forms.Panel();
            this.btnNewSaplingAddress = new System.Windows.Forms.Button();
            this.dtgAddress = new System.Windows.Forms.DataGridView();
            this.btnNewAddress = new System.Windows.Forms.Button();
            this.btnAddressBook = new System.Windows.Forms.Button();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dtgZeroNode = new System.Windows.Forms.DataGridView();
            this.dtgWalletInfo = new System.Windows.Forms.DataGridView();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.addressBookBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.masternodeListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbImmatureTxt = new SimpleWallet.TransparentLabel();
            this.lbImmature = new SimpleWallet.TransparentLabel();
            this.label3 = new SimpleWallet.TransparentLabel();
            this.lbLocked = new SimpleWallet.TransparentLabel();
            this.lblConfirmed = new SimpleWallet.TransparentLabel();
            this.lblUnconfirmedHeader = new SimpleWallet.TransparentLabel();
            this.lblTotalUnconfirmed = new SimpleWallet.TransparentLabel();
            this.lblPrivateUnconfirmed = new SimpleWallet.TransparentLabel();
            this.lblTransparentUnconfirmed = new SimpleWallet.TransparentLabel();
            this.label5 = new SimpleWallet.TransparentLabel();
            this.lbBestTime = new SimpleWallet.TransparentLabel();
            this.lbBestHash = new SimpleWallet.TransparentLabel();
            this.label1 = new SimpleWallet.TransparentLabel();
            this.lbAddress4 = new SimpleWallet.TransparentLabel();
            this.lbTotal = new SimpleWallet.TransparentLabel();
            this.lbAddress3 = new SimpleWallet.TransparentLabel();
            this.transparentLabel1 = new SimpleWallet.TransparentLabel();
            this.lbAddress2 = new SimpleWallet.TransparentLabel();
            this.lbAddress1 = new SimpleWallet.TransparentLabel();
            this.lbPrivate = new SimpleWallet.TransparentLabel();
            this.lbValue4 = new SimpleWallet.TransparentLabel();
            this.lbValue3 = new SimpleWallet.TransparentLabel();
            this.tlTransparentBalance = new SimpleWallet.TransparentLabel();
            this.lbValue2 = new SimpleWallet.TransparentLabel();
            this.lbTransparent = new SimpleWallet.TransparentLabel();
            this.lbValue1 = new SimpleWallet.TransparentLabel();
            this.lbTime4 = new SimpleWallet.TransparentLabel();
            this.lbTime3 = new SimpleWallet.TransparentLabel();
            this.label4 = new SimpleWallet.TransparentLabel();
            this.lbTime2 = new SimpleWallet.TransparentLabel();
            this.label7 = new SimpleWallet.TransparentLabel();
            this.lbTime1 = new SimpleWallet.TransparentLabel();
            this.label12 = new SimpleWallet.TransparentLabel();
            this.btnSearch = new SimpleWallet.RoundButton();
            this.label6 = new SimpleWallet.TransparentLabel();
            this.label9 = new SimpleWallet.TransparentLabel();
            this.label8 = new SimpleWallet.TransparentLabel();
            this.label10 = new SimpleWallet.TransparentLabel();
            this.label11 = new SimpleWallet.TransparentLabel();
            this.transparentLabel3 = new SimpleWallet.TransparentLabel();
            this.transparentLabel6 = new SimpleWallet.TransparentLabel();
            this.transparentLabel5 = new SimpleWallet.TransparentLabel();
            this.transparentLabel4 = new SimpleWallet.TransparentLabel();
            this.transparentLabel66 = new SimpleWallet.TransparentLabel();
            this.transparentLabel45 = new SimpleWallet.TransparentLabel();
            this.typesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlOverview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTransaction4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTransaction3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTransaction2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTransaction1)).BeginInit();
            this.pnlZeronodes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGlobalMN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masternodeDetailConvertedBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMasternode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masternodeBindingSource)).BeginInit();
            this.pnlTransactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionConvertedBindingSource)).BeginInit();
            this.pnlSendCoins.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSignal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).BeginInit();
            this.pnlReceiveCoins.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAddress)).BeginInit();
            this.pnlInfo.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgZeroNode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgWalletInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressBookBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masternodeListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "address-book.png");
            this.imgList.Images.SetKeyName(1, "history.png");
            this.imgList.Images.SetKeyName(2, "overview.png");
            this.imgList.Images.SetKeyName(3, "receive.png");
            this.imgList.Images.SetKeyName(4, "send.png");
            this.imgList.Images.SetKeyName(5, "masternodes.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.walletToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(168, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Gold;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.fileToolStripMenuItem.Text = "Main";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.Gold;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.quitToolStripMenuItem.ForeColor = System.Drawing.Color.Gold;
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // walletToolStripMenuItem
            // 
            this.walletToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem,
            this.exportPrivateKeyToolStripMenuItem,
            this.importPrivateKeysToolStripMenuItem,
            this.importOnePrivateKeyToolStripMenuItem,
            this.enableAutoBackupWalletToolStripMenuItem});
            this.walletToolStripMenuItem.ForeColor = System.Drawing.Color.Gold;
            this.walletToolStripMenuItem.Name = "walletToolStripMenuItem";
            this.walletToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.walletToolStripMenuItem.Text = "Settings";
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.backupToolStripMenuItem.ForeColor = System.Drawing.Color.Gold;
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // exportPrivateKeyToolStripMenuItem
            // 
            this.exportPrivateKeyToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.exportPrivateKeyToolStripMenuItem.ForeColor = System.Drawing.Color.Gold;
            this.exportPrivateKeyToolStripMenuItem.Name = "exportPrivateKeyToolStripMenuItem";
            this.exportPrivateKeyToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.exportPrivateKeyToolStripMenuItem.Text = "Export private keys";
            this.exportPrivateKeyToolStripMenuItem.Click += new System.EventHandler(this.exportPrivateKeyToolStripMenuItem_Click);
            // 
            // importPrivateKeysToolStripMenuItem
            // 
            this.importPrivateKeysToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.importPrivateKeysToolStripMenuItem.ForeColor = System.Drawing.Color.Gold;
            this.importPrivateKeysToolStripMenuItem.Name = "importPrivateKeysToolStripMenuItem";
            this.importPrivateKeysToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.importPrivateKeysToolStripMenuItem.Text = "Import private keys";
            this.importPrivateKeysToolStripMenuItem.Click += new System.EventHandler(this.importPrivateKeysToolStripMenuItem_Click);
            // 
            // importOnePrivateKeyToolStripMenuItem
            // 
            this.importOnePrivateKeyToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.importOnePrivateKeyToolStripMenuItem.ForeColor = System.Drawing.Color.Gold;
            this.importOnePrivateKeyToolStripMenuItem.Name = "importOnePrivateKeyToolStripMenuItem";
            this.importOnePrivateKeyToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.importOnePrivateKeyToolStripMenuItem.Text = "Import one private key";
            this.importOnePrivateKeyToolStripMenuItem.Click += new System.EventHandler(this.importOnePrivateKeyToolStripMenuItem_Click);
            // 
            // enableAutoBackupWalletToolStripMenuItem
            // 
            this.enableAutoBackupWalletToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.enableAutoBackupWalletToolStripMenuItem.ForeColor = System.Drawing.Color.Gold;
            this.enableAutoBackupWalletToolStripMenuItem.Name = "enableAutoBackupWalletToolStripMenuItem";
            this.enableAutoBackupWalletToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.enableAutoBackupWalletToolStripMenuItem.Text = "Enable auto backup wallet";
            this.enableAutoBackupWalletToolStripMenuItem.Click += new System.EventHandler(this.enableAutoBackupWalletToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugToolStripMenuItem,
            this.peersToolStripMenuItem,
            this.copyZeroconfDataToolStripMenuItem});
            this.toolsToolStripMenuItem.ForeColor = System.Drawing.Color.Gold;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.debugToolStripMenuItem.ForeColor = System.Drawing.Color.Gold;
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.debugToolStripMenuItem.Text = "Debug";
            this.debugToolStripMenuItem.Click += new System.EventHandler(this.debugToolStripMenuItem_Click);
            // 
            // peersToolStripMenuItem
            // 
            this.peersToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.peersToolStripMenuItem.ForeColor = System.Drawing.Color.Gold;
            this.peersToolStripMenuItem.Name = "peersToolStripMenuItem";
            this.peersToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.peersToolStripMenuItem.Text = "Peers";
            this.peersToolStripMenuItem.Click += new System.EventHandler(this.peersToolStripMenuItem_Click);
            // 
            // copyZeroconfDataToolStripMenuItem
            // 
            this.copyZeroconfDataToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.copyZeroconfDataToolStripMenuItem.ForeColor = System.Drawing.Color.Gold;
            this.copyZeroconfDataToolStripMenuItem.Name = "copyZeroconfDataToolStripMenuItem";
            this.copyZeroconfDataToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.copyZeroconfDataToolStripMenuItem.Text = "Copy Zero.conf data";
            this.copyZeroconfDataToolStripMenuItem.Click += new System.EventHandler(this.copyZeroconfDataToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.btnWalletInfo);
            this.panel1.Controls.Add(this.btnMasternode);
            this.panel1.Controls.Add(this.btnTransactions);
            this.panel1.Controls.Add(this.btnSendCoins);
            this.panel1.Controls.Add(this.btnReceiveCoins);
            this.panel1.Controls.Add(this.btnOverview);
            this.panel1.Location = new System.Drawing.Point(0, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(168, 669);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.pbPercent);
            this.panel2.Controls.Add(this.pbSignal);
            this.panel2.Controls.Add(this.pbStatus);
            this.panel2.Location = new System.Drawing.Point(1, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1300, 666);
            this.panel2.TabIndex = 20;
            // 
            // pbPercent
            // 
            this.pbPercent.Location = new System.Drawing.Point(201, 638);
            this.pbPercent.Maximum = 10000;
            this.pbPercent.Name = "pbPercent";
            this.pbPercent.Size = new System.Drawing.Size(1041, 16);
            this.pbPercent.Step = 1;
            this.pbPercent.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Gold;
            this.btnClose.Location = new System.Drawing.Point(1276, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(15, 25);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.Gold;
            this.btnMinimize.Location = new System.Drawing.Point(1258, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(15, 25);
            this.btnMinimize.TabIndex = 13;
            this.btnMinimize.Text = "__";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnWalletInfo
            // 
            this.btnWalletInfo.BackColor = System.Drawing.Color.Black;
            this.btnWalletInfo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnWalletInfo.FlatAppearance.BorderSize = 0;
            this.btnWalletInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnWalletInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWalletInfo.ForeColor = System.Drawing.Color.Gold;
            this.btnWalletInfo.Image = global::SimpleWallet.Properties.Resources.sm_logo_yellow;
            this.btnWalletInfo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnWalletInfo.Location = new System.Drawing.Point(0, 315);
            this.btnWalletInfo.Name = "btnWalletInfo";
            this.btnWalletInfo.Size = new System.Drawing.Size(168, 50);
            this.btnWalletInfo.TabIndex = 5;
            this.btnWalletInfo.Text = "Wallet Info";
            this.btnWalletInfo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnWalletInfo.UseVisualStyleBackColor = false;
            this.btnWalletInfo.Click += new System.EventHandler(this.btnWalletInfo_Click);
            // 
            // btnMasternode
            // 
            this.btnMasternode.BackColor = System.Drawing.Color.Black;
            this.btnMasternode.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMasternode.FlatAppearance.BorderSize = 0;
            this.btnMasternode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnMasternode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMasternode.ForeColor = System.Drawing.Color.Gold;
            this.btnMasternode.Image = ((System.Drawing.Image)(resources.GetObject("btnMasternode.Image")));
            this.btnMasternode.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMasternode.Location = new System.Drawing.Point(0, 255);
            this.btnMasternode.Name = "btnMasternode";
            this.btnMasternode.Size = new System.Drawing.Size(168, 50);
            this.btnMasternode.TabIndex = 4;
            this.btnMasternode.Text = "Zeronodes";
            this.btnMasternode.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMasternode.UseVisualStyleBackColor = false;
            this.btnMasternode.Click += new System.EventHandler(this.btnMasternode_Click);
            // 
            // btnTransactions
            // 
            this.btnTransactions.BackColor = System.Drawing.Color.Black;
            this.btnTransactions.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTransactions.FlatAppearance.BorderSize = 0;
            this.btnTransactions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactions.ForeColor = System.Drawing.Color.Gold;
            this.btnTransactions.Image = global::SimpleWallet.Properties.Resources.transaction_sm;
            this.btnTransactions.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTransactions.Location = new System.Drawing.Point(0, 195);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Size = new System.Drawing.Size(168, 50);
            this.btnTransactions.TabIndex = 3;
            this.btnTransactions.Text = "Transactions";
            this.btnTransactions.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTransactions.UseVisualStyleBackColor = false;
            this.btnTransactions.Click += new System.EventHandler(this.btnTransactions_Click);
            // 
            // btnSendCoins
            // 
            this.btnSendCoins.BackColor = System.Drawing.Color.Black;
            this.btnSendCoins.FlatAppearance.BorderSize = 0;
            this.btnSendCoins.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnSendCoins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendCoins.ForeColor = System.Drawing.Color.Gold;
            this.btnSendCoins.Image = global::SimpleWallet.Properties.Resources.sendicon_sm;
            this.btnSendCoins.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSendCoins.Location = new System.Drawing.Point(0, 135);
            this.btnSendCoins.Name = "btnSendCoins";
            this.btnSendCoins.Size = new System.Drawing.Size(168, 50);
            this.btnSendCoins.TabIndex = 2;
            this.btnSendCoins.Text = "Send Coins";
            this.btnSendCoins.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSendCoins.UseVisualStyleBackColor = false;
            this.btnSendCoins.Click += new System.EventHandler(this.btnSendCoins_Click);
            // 
            // btnReceiveCoins
            // 
            this.btnReceiveCoins.BackColor = System.Drawing.Color.Black;
            this.btnReceiveCoins.FlatAppearance.BorderSize = 0;
            this.btnReceiveCoins.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnReceiveCoins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceiveCoins.ForeColor = System.Drawing.Color.Gold;
            this.btnReceiveCoins.Image = global::SimpleWallet.Properties.Resources.receiveicon_sm;
            this.btnReceiveCoins.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReceiveCoins.Location = new System.Drawing.Point(0, 80);
            this.btnReceiveCoins.Name = "btnReceiveCoins";
            this.btnReceiveCoins.Size = new System.Drawing.Size(168, 50);
            this.btnReceiveCoins.TabIndex = 1;
            this.btnReceiveCoins.Text = "Receive Coins";
            this.btnReceiveCoins.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReceiveCoins.UseVisualStyleBackColor = false;
            this.btnReceiveCoins.Click += new System.EventHandler(this.btnReceiveCoins_Click);
            // 
            // btnOverview
            // 
            this.btnOverview.BackColor = System.Drawing.Color.Black;
            this.btnOverview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOverview.FlatAppearance.BorderSize = 0;
            this.btnOverview.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnOverview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOverview.ForeColor = System.Drawing.Color.Gold;
            this.btnOverview.Image = global::SimpleWallet.Properties.Resources.overview_sm;
            this.btnOverview.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOverview.Location = new System.Drawing.Point(0, 25);
            this.btnOverview.Name = "btnOverview";
            this.btnOverview.Size = new System.Drawing.Size(168, 50);
            this.btnOverview.TabIndex = 0;
            this.btnOverview.Text = "Overview";
            this.btnOverview.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOverview.UseVisualStyleBackColor = false;
            this.btnOverview.Click += new System.EventHandler(this.btnOverview_Click);
            // 
            // pnlOverview
            // 
            this.pnlOverview.BackColor = System.Drawing.Color.Black;
            this.pnlOverview.BackgroundImage = global::SimpleWallet.Properties.Resources.zero05;
            this.pnlOverview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlOverview.Controls.Add(this.lbImmatureTxt);
            this.pnlOverview.Controls.Add(this.lbImmature);
            this.pnlOverview.Controls.Add(this.lblLockedMessage);
            this.pnlOverview.Controls.Add(this.label3);
            this.pnlOverview.Controls.Add(this.lbLocked);
            this.pnlOverview.Controls.Add(this.lblConfirmed);
            this.pnlOverview.Controls.Add(this.lblUnconfirmedHeader);
            this.pnlOverview.Controls.Add(this.lblTotalUnconfirmed);
            this.pnlOverview.Controls.Add(this.lblPrivateUnconfirmed);
            this.pnlOverview.Controls.Add(this.lblTransparentUnconfirmed);
            this.pnlOverview.Controls.Add(this.pbTransaction4);
            this.pnlOverview.Controls.Add(this.label5);
            this.pnlOverview.Controls.Add(this.pbTransaction3);
            this.pnlOverview.Controls.Add(this.lbBestTime);
            this.pnlOverview.Controls.Add(this.pbTransaction2);
            this.pnlOverview.Controls.Add(this.lbBestHash);
            this.pnlOverview.Controls.Add(this.pbTransaction1);
            this.pnlOverview.Controls.Add(this.label1);
            this.pnlOverview.Controls.Add(this.lbAddress4);
            this.pnlOverview.Controls.Add(this.lbTotal);
            this.pnlOverview.Controls.Add(this.lbAddress3);
            this.pnlOverview.Controls.Add(this.transparentLabel1);
            this.pnlOverview.Controls.Add(this.lbAddress2);
            this.pnlOverview.Controls.Add(this.lbAddress1);
            this.pnlOverview.Controls.Add(this.lbPrivate);
            this.pnlOverview.Controls.Add(this.lbValue4);
            this.pnlOverview.Controls.Add(this.lbValue3);
            this.pnlOverview.Controls.Add(this.tlTransparentBalance);
            this.pnlOverview.Controls.Add(this.lbValue2);
            this.pnlOverview.Controls.Add(this.lbTransparent);
            this.pnlOverview.Controls.Add(this.lbValue1);
            this.pnlOverview.Controls.Add(this.lbTime4);
            this.pnlOverview.Controls.Add(this.lbTime3);
            this.pnlOverview.Controls.Add(this.label4);
            this.pnlOverview.Controls.Add(this.lbTime2);
            this.pnlOverview.Controls.Add(this.label7);
            this.pnlOverview.Controls.Add(this.lbTime1);
            this.pnlOverview.Controls.Add(this.label12);
            this.pnlOverview.Location = new System.Drawing.Point(169, 25);
            this.pnlOverview.Name = "pnlOverview";
            this.pnlOverview.Size = new System.Drawing.Size(1132, 620);
            this.pnlOverview.TabIndex = 8;
            // 
            // lblLockedMessage
            // 
            this.lblLockedMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblLockedMessage.ForeColor = System.Drawing.Color.Gold;
            this.lblLockedMessage.Location = new System.Drawing.Point(21, 275);
            this.lblLockedMessage.Name = "lblLockedMessage";
            this.lblLockedMessage.Size = new System.Drawing.Size(345, 63);
            this.lblLockedMessage.TabIndex = 22;
            this.lblLockedMessage.Text = "*Coins can only be locked/unlocked via command line. Zeronodes automatically lock" +
    "/unlock coins used as collateral.";
            // 
            // pbTransaction4
            // 
            this.pbTransaction4.BackColor = System.Drawing.Color.Transparent;
            this.pbTransaction4.Location = new System.Drawing.Point(578, 306);
            this.pbTransaction4.Name = "pbTransaction4";
            this.pbTransaction4.Size = new System.Drawing.Size(58, 58);
            this.pbTransaction4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTransaction4.TabIndex = 10;
            this.pbTransaction4.TabStop = false;
            this.pbTransaction4.Visible = false;
            // 
            // pbTransaction3
            // 
            this.pbTransaction3.BackColor = System.Drawing.Color.Transparent;
            this.pbTransaction3.Location = new System.Drawing.Point(578, 224);
            this.pbTransaction3.Name = "pbTransaction3";
            this.pbTransaction3.Size = new System.Drawing.Size(58, 58);
            this.pbTransaction3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTransaction3.TabIndex = 10;
            this.pbTransaction3.TabStop = false;
            this.pbTransaction3.Visible = false;
            // 
            // pbTransaction2
            // 
            this.pbTransaction2.BackColor = System.Drawing.Color.Transparent;
            this.pbTransaction2.Location = new System.Drawing.Point(578, 143);
            this.pbTransaction2.Name = "pbTransaction2";
            this.pbTransaction2.Size = new System.Drawing.Size(58, 58);
            this.pbTransaction2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTransaction2.TabIndex = 10;
            this.pbTransaction2.TabStop = false;
            this.pbTransaction2.Visible = false;
            // 
            // pbTransaction1
            // 
            this.pbTransaction1.BackColor = System.Drawing.Color.Transparent;
            this.pbTransaction1.Location = new System.Drawing.Point(578, 63);
            this.pbTransaction1.Name = "pbTransaction1";
            this.pbTransaction1.Size = new System.Drawing.Size(58, 58);
            this.pbTransaction1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTransaction1.TabIndex = 10;
            this.pbTransaction1.TabStop = false;
            this.pbTransaction1.Visible = false;
            // 
            // pnlZeronodes
            // 
            this.pnlZeronodes.BackColor = System.Drawing.Color.Black;
            this.pnlZeronodes.BackgroundImage = global::SimpleWallet.Properties.Resources.zero05;
            this.pnlZeronodes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlZeronodes.Controls.Add(this.btnSearch);
            this.pnlZeronodes.Controls.Add(this.btnClearMNCache);
            this.pnlZeronodes.Controls.Add(this.lbUpdateTime);
            this.pnlZeronodes.Controls.Add(this.btnRefreshZeronode);
            this.pnlZeronodes.Controls.Add(this.btnStartAll);
            this.pnlZeronodes.Controls.Add(this.btnStartAlias);
            this.pnlZeronodes.Controls.Add(this.btnStartZeronode);
            this.pnlZeronodes.Controls.Add(this.btnEditConfigFile);
            this.pnlZeronodes.Controls.Add(this.btnGetOutputs);
            this.pnlZeronodes.Controls.Add(this.tbSearch);
            this.pnlZeronodes.Controls.Add(this.btnGetMNPrivKey);
            this.pnlZeronodes.Controls.Add(this.dtgGlobalMN);
            this.pnlZeronodes.Controls.Add(this.dtgMasternode);
            this.pnlZeronodes.Location = new System.Drawing.Point(169, 25);
            this.pnlZeronodes.Name = "pnlZeronodes";
            this.pnlZeronodes.Size = new System.Drawing.Size(1132, 620);
            this.pnlZeronodes.TabIndex = 19;
            // 
            // btnClearMNCache
            // 
            this.btnClearMNCache.BackColor = System.Drawing.Color.Black;
            this.btnClearMNCache.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnClearMNCache.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnClearMNCache.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearMNCache.ForeColor = System.Drawing.Color.Gold;
            this.btnClearMNCache.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClearMNCache.Location = new System.Drawing.Point(978, 572);
            this.btnClearMNCache.Name = "btnClearMNCache";
            this.btnClearMNCache.Size = new System.Drawing.Size(135, 40);
            this.btnClearMNCache.TabIndex = 24;
            this.btnClearMNCache.Text = "Cleare ZN Cache";
            this.btnClearMNCache.UseVisualStyleBackColor = false;
            this.btnClearMNCache.Click += new System.EventHandler(this.btnClearMNCache_Click);
            // 
            // lbUpdateTime
            // 
            this.lbUpdateTime.AutoSize = true;
            this.lbUpdateTime.BackColor = System.Drawing.Color.Transparent;
            this.lbUpdateTime.ForeColor = System.Drawing.Color.Gold;
            this.lbUpdateTime.Location = new System.Drawing.Point(1084, 545);
            this.lbUpdateTime.Name = "lbUpdateTime";
            this.lbUpdateTime.Size = new System.Drawing.Size(29, 15);
            this.lbUpdateTime.TabIndex = 23;
            this.lbUpdateTime.Text = "(60)";
            // 
            // btnRefreshZeronode
            // 
            this.btnRefreshZeronode.BackColor = System.Drawing.Color.Black;
            this.btnRefreshZeronode.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnRefreshZeronode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnRefreshZeronode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshZeronode.ForeColor = System.Drawing.Color.Gold;
            this.btnRefreshZeronode.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefreshZeronode.Location = new System.Drawing.Point(12, 572);
            this.btnRefreshZeronode.Name = "btnRefreshZeronode";
            this.btnRefreshZeronode.Size = new System.Drawing.Size(135, 40);
            this.btnRefreshZeronode.TabIndex = 22;
            this.btnRefreshZeronode.Text = "Refresh";
            this.btnRefreshZeronode.UseVisualStyleBackColor = false;
            this.btnRefreshZeronode.Click += new System.EventHandler(this.btnRefreshMasternode_Click);
            // 
            // btnStartAll
            // 
            this.btnStartAll.BackColor = System.Drawing.Color.Black;
            this.btnStartAll.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnStartAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnStartAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartAll.ForeColor = System.Drawing.Color.Gold;
            this.btnStartAll.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStartAll.Location = new System.Drawing.Point(840, 572);
            this.btnStartAll.Name = "btnStartAll";
            this.btnStartAll.Size = new System.Drawing.Size(135, 40);
            this.btnStartAll.TabIndex = 21;
            this.btnStartAll.Text = "Start All";
            this.btnStartAll.UseVisualStyleBackColor = false;
            this.btnStartAll.Click += new System.EventHandler(this.btnStartAll_Click);
            // 
            // btnStartAlias
            // 
            this.btnStartAlias.BackColor = System.Drawing.Color.Black;
            this.btnStartAlias.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnStartAlias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnStartAlias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartAlias.ForeColor = System.Drawing.Color.Gold;
            this.btnStartAlias.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStartAlias.Location = new System.Drawing.Point(702, 572);
            this.btnStartAlias.Name = "btnStartAlias";
            this.btnStartAlias.Size = new System.Drawing.Size(135, 40);
            this.btnStartAlias.TabIndex = 20;
            this.btnStartAlias.Text = "Start Alias";
            this.btnStartAlias.UseVisualStyleBackColor = false;
            this.btnStartAlias.Click += new System.EventHandler(this.btnStartAlias_Click);
            // 
            // btnStartZeronode
            // 
            this.btnStartZeronode.BackColor = System.Drawing.Color.Black;
            this.btnStartZeronode.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnStartZeronode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnStartZeronode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartZeronode.ForeColor = System.Drawing.Color.Gold;
            this.btnStartZeronode.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStartZeronode.Location = new System.Drawing.Point(564, 572);
            this.btnStartZeronode.Name = "btnStartZeronode";
            this.btnStartZeronode.Size = new System.Drawing.Size(135, 40);
            this.btnStartZeronode.TabIndex = 19;
            this.btnStartZeronode.Text = "Start ZN";
            this.btnStartZeronode.UseVisualStyleBackColor = false;
            this.btnStartZeronode.Click += new System.EventHandler(this.btnStartMasternode_Click);
            // 
            // btnEditConfigFile
            // 
            this.btnEditConfigFile.BackColor = System.Drawing.Color.Black;
            this.btnEditConfigFile.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnEditConfigFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnEditConfigFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditConfigFile.ForeColor = System.Drawing.Color.Gold;
            this.btnEditConfigFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEditConfigFile.Location = new System.Drawing.Point(426, 572);
            this.btnEditConfigFile.Name = "btnEditConfigFile";
            this.btnEditConfigFile.Size = new System.Drawing.Size(135, 40);
            this.btnEditConfigFile.TabIndex = 18;
            this.btnEditConfigFile.Text = "New ZN";
            this.btnEditConfigFile.UseVisualStyleBackColor = false;
            this.btnEditConfigFile.Click += new System.EventHandler(this.btnEditConfigFile_Click);
            // 
            // btnGetOutputs
            // 
            this.btnGetOutputs.BackColor = System.Drawing.Color.Black;
            this.btnGetOutputs.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnGetOutputs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnGetOutputs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetOutputs.ForeColor = System.Drawing.Color.Gold;
            this.btnGetOutputs.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGetOutputs.Location = new System.Drawing.Point(288, 572);
            this.btnGetOutputs.Name = "btnGetOutputs";
            this.btnGetOutputs.Size = new System.Drawing.Size(135, 40);
            this.btnGetOutputs.TabIndex = 17;
            this.btnGetOutputs.Text = "Unused Outputs";
            this.btnGetOutputs.UseVisualStyleBackColor = false;
            this.btnGetOutputs.Click += new System.EventHandler(this.btnGetOutputs_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tbSearch.Location = new System.Drawing.Point(12, 542);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(549, 21);
            this.tbSearch.TabIndex = 16;
            this.tbSearch.Text = "ZeroNode address or tx hash";
            this.tbSearch.Enter += new System.EventHandler(this.tbSearch_Enter);
            this.tbSearch.Leave += new System.EventHandler(this.tbSearch_Leave);
            // 
            // btnGetMNPrivKey
            // 
            this.btnGetMNPrivKey.BackColor = System.Drawing.Color.Black;
            this.btnGetMNPrivKey.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnGetMNPrivKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnGetMNPrivKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetMNPrivKey.ForeColor = System.Drawing.Color.Gold;
            this.btnGetMNPrivKey.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGetMNPrivKey.Location = new System.Drawing.Point(150, 572);
            this.btnGetMNPrivKey.Name = "btnGetMNPrivKey";
            this.btnGetMNPrivKey.Size = new System.Drawing.Size(135, 40);
            this.btnGetMNPrivKey.TabIndex = 5;
            this.btnGetMNPrivKey.Text = "Get ZN Priv Key";
            this.btnGetMNPrivKey.UseVisualStyleBackColor = false;
            this.btnGetMNPrivKey.Click += new System.EventHandler(this.btnGetMNPrivKey_Click);
            // 
            // dtgGlobalMN
            // 
            this.dtgGlobalMN.AutoGenerateColumns = false;
            this.dtgGlobalMN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGlobalMN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rankDataGridViewTextBoxColumn,
            this.addrDataGridViewTextBoxColumn,
            this.versionDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn1,
            this.activetimeDataGridViewTextBoxColumn,
            this.lastseenDataGridViewTextBoxColumn,
            this.lastpaidDataGridViewTextBoxColumn,
            this.txhashDataGridViewTextBoxColumn1,
            this.ipDataGridViewTextBoxColumn});
            this.dtgGlobalMN.DataSource = this.masternodeDetailConvertedBindingSource;
            this.dtgGlobalMN.Location = new System.Drawing.Point(11, 207);
            this.dtgGlobalMN.Name = "dtgGlobalMN";
            this.dtgGlobalMN.Size = new System.Drawing.Size(1107, 328);
            this.dtgGlobalMN.TabIndex = 15;
            this.dtgGlobalMN.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgGlobalMN_CellMouseClick);
            this.dtgGlobalMN.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dtg_MouseClick);
            // 
            // rankDataGridViewTextBoxColumn
            // 
            this.rankDataGridViewTextBoxColumn.DataPropertyName = "rank";
            this.rankDataGridViewTextBoxColumn.HeaderText = "rank";
            this.rankDataGridViewTextBoxColumn.Name = "rankDataGridViewTextBoxColumn";
            // 
            // addrDataGridViewTextBoxColumn
            // 
            this.addrDataGridViewTextBoxColumn.DataPropertyName = "addr";
            this.addrDataGridViewTextBoxColumn.HeaderText = "addr";
            this.addrDataGridViewTextBoxColumn.Name = "addrDataGridViewTextBoxColumn";
            // 
            // versionDataGridViewTextBoxColumn
            // 
            this.versionDataGridViewTextBoxColumn.DataPropertyName = "version";
            this.versionDataGridViewTextBoxColumn.HeaderText = "version";
            this.versionDataGridViewTextBoxColumn.Name = "versionDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewTextBoxColumn1
            // 
            this.statusDataGridViewTextBoxColumn1.DataPropertyName = "status";
            this.statusDataGridViewTextBoxColumn1.HeaderText = "status";
            this.statusDataGridViewTextBoxColumn1.Name = "statusDataGridViewTextBoxColumn1";
            // 
            // activetimeDataGridViewTextBoxColumn
            // 
            this.activetimeDataGridViewTextBoxColumn.DataPropertyName = "activetime";
            this.activetimeDataGridViewTextBoxColumn.HeaderText = "activetime";
            this.activetimeDataGridViewTextBoxColumn.Name = "activetimeDataGridViewTextBoxColumn";
            // 
            // lastseenDataGridViewTextBoxColumn
            // 
            this.lastseenDataGridViewTextBoxColumn.DataPropertyName = "lastseen";
            this.lastseenDataGridViewTextBoxColumn.HeaderText = "lastseen";
            this.lastseenDataGridViewTextBoxColumn.Name = "lastseenDataGridViewTextBoxColumn";
            // 
            // lastpaidDataGridViewTextBoxColumn
            // 
            this.lastpaidDataGridViewTextBoxColumn.DataPropertyName = "lastpaid";
            this.lastpaidDataGridViewTextBoxColumn.HeaderText = "lastpaid";
            this.lastpaidDataGridViewTextBoxColumn.Name = "lastpaidDataGridViewTextBoxColumn";
            // 
            // txhashDataGridViewTextBoxColumn1
            // 
            this.txhashDataGridViewTextBoxColumn1.DataPropertyName = "txhash";
            this.txhashDataGridViewTextBoxColumn1.HeaderText = "txhash";
            this.txhashDataGridViewTextBoxColumn1.Name = "txhashDataGridViewTextBoxColumn1";
            // 
            // ipDataGridViewTextBoxColumn
            // 
            this.ipDataGridViewTextBoxColumn.DataPropertyName = "ip";
            this.ipDataGridViewTextBoxColumn.HeaderText = "ip";
            this.ipDataGridViewTextBoxColumn.Name = "ipDataGridViewTextBoxColumn";
            // 
            // masternodeDetailConvertedBindingSource
            // 
            this.masternodeDetailConvertedBindingSource.DataSource = typeof(SimpleWallet.Types.MasternodeDetailConverted);
            // 
            // dtgMasternode
            // 
            this.dtgMasternode.AutoGenerateColumns = false;
            this.dtgMasternode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMasternode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statusDataGridViewTextBoxColumn,
            this.aliasDataGridViewTextBoxColumn,
            this.ipAddressDataGridViewTextBoxColumn,
            this.privKeyDataGridViewTextBoxColumn,
            this.txHashDataGridViewTextBoxColumn,
            this.indexDataGridViewTextBoxColumn});
            this.dtgMasternode.DataSource = this.masternodeBindingSource;
            this.dtgMasternode.Location = new System.Drawing.Point(12, 11);
            this.dtgMasternode.Name = "dtgMasternode";
            this.dtgMasternode.Size = new System.Drawing.Size(1106, 190);
            this.dtgMasternode.TabIndex = 14;
            this.dtgMasternode.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgMasternode_CellMouseClick);
            this.dtgMasternode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dtg_MouseClick);
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            // 
            // aliasDataGridViewTextBoxColumn
            // 
            this.aliasDataGridViewTextBoxColumn.DataPropertyName = "alias";
            this.aliasDataGridViewTextBoxColumn.HeaderText = "alias";
            this.aliasDataGridViewTextBoxColumn.Name = "aliasDataGridViewTextBoxColumn";
            // 
            // ipAddressDataGridViewTextBoxColumn
            // 
            this.ipAddressDataGridViewTextBoxColumn.DataPropertyName = "ipAddress";
            this.ipAddressDataGridViewTextBoxColumn.HeaderText = "ipAddress";
            this.ipAddressDataGridViewTextBoxColumn.Name = "ipAddressDataGridViewTextBoxColumn";
            // 
            // privKeyDataGridViewTextBoxColumn
            // 
            this.privKeyDataGridViewTextBoxColumn.DataPropertyName = "privKey";
            this.privKeyDataGridViewTextBoxColumn.HeaderText = "privKey";
            this.privKeyDataGridViewTextBoxColumn.Name = "privKeyDataGridViewTextBoxColumn";
            // 
            // txHashDataGridViewTextBoxColumn
            // 
            this.txHashDataGridViewTextBoxColumn.DataPropertyName = "txHash";
            this.txHashDataGridViewTextBoxColumn.HeaderText = "txHash";
            this.txHashDataGridViewTextBoxColumn.Name = "txHashDataGridViewTextBoxColumn";
            // 
            // indexDataGridViewTextBoxColumn
            // 
            this.indexDataGridViewTextBoxColumn.DataPropertyName = "index";
            this.indexDataGridViewTextBoxColumn.HeaderText = "index";
            this.indexDataGridViewTextBoxColumn.Name = "indexDataGridViewTextBoxColumn";
            // 
            // masternodeBindingSource
            // 
            this.masternodeBindingSource.DataSource = typeof(SimpleWallet.Types.Masternode);
            // 
            // pnlTransactions
            // 
            this.pnlTransactions.BackColor = System.Drawing.Color.Black;
            this.pnlTransactions.BackgroundImage = global::SimpleWallet.Properties.Resources.zero05;
            this.pnlTransactions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTransactions.Controls.Add(this.btnReindex);
            this.pnlTransactions.Controls.Add(this.dtgTransactions);
            this.pnlTransactions.Controls.Add(this.btnRescan);
            this.pnlTransactions.Location = new System.Drawing.Point(169, 25);
            this.pnlTransactions.Name = "pnlTransactions";
            this.pnlTransactions.Size = new System.Drawing.Size(1132, 620);
            this.pnlTransactions.TabIndex = 9;
            // 
            // btnReindex
            // 
            this.btnReindex.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnReindex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReindex.ForeColor = System.Drawing.Color.Gold;
            this.btnReindex.Location = new System.Drawing.Point(752, 585);
            this.btnReindex.Name = "btnReindex";
            this.btnReindex.Size = new System.Drawing.Size(180, 27);
            this.btnReindex.TabIndex = 10;
            this.btnReindex.Text = "Reindex the wallet";
            this.btnReindex.UseVisualStyleBackColor = true;
            this.btnReindex.Click += new System.EventHandler(this.btnReindex_Click);
            // 
            // dtgTransactions
            // 
            this.dtgTransactions.AllowUserToResizeColumns = false;
            this.dtgTransactions.AllowUserToResizeRows = false;
            this.dtgTransactions.AutoGenerateColumns = false;
            this.dtgTransactions.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dtgTransactions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.categoryDataGridViewTextBoxColumn,
            this.confirmationsDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.timeDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.txidDataGridViewTextBoxColumn});
            this.dtgTransactions.DataSource = this.transactionConvertedBindingSource;
            this.dtgTransactions.Location = new System.Drawing.Point(10, 14);
            this.dtgTransactions.MultiSelect = false;
            this.dtgTransactions.Name = "dtgTransactions";
            this.dtgTransactions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtgTransactions.Size = new System.Drawing.Size(1108, 555);
            this.dtgTransactions.TabIndex = 0;
            this.dtgTransactions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgTransactions_CellDoubleClick);
            this.dtgTransactions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dtg_MouseClick);
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "category";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            // 
            // confirmationsDataGridViewTextBoxColumn
            // 
            this.confirmationsDataGridViewTextBoxColumn.DataPropertyName = "confirmations";
            this.confirmationsDataGridViewTextBoxColumn.HeaderText = "confirmations";
            this.confirmationsDataGridViewTextBoxColumn.Name = "confirmationsDataGridViewTextBoxColumn";
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            // 
            // timeDataGridViewTextBoxColumn
            // 
            this.timeDataGridViewTextBoxColumn.DataPropertyName = "time";
            this.timeDataGridViewTextBoxColumn.HeaderText = "time";
            this.timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "address";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            // 
            // txidDataGridViewTextBoxColumn
            // 
            this.txidDataGridViewTextBoxColumn.DataPropertyName = "txid";
            this.txidDataGridViewTextBoxColumn.HeaderText = "txid";
            this.txidDataGridViewTextBoxColumn.Name = "txidDataGridViewTextBoxColumn";
            // 
            // transactionConvertedBindingSource
            // 
            this.transactionConvertedBindingSource.DataSource = typeof(SimpleWallet.Types.TransactionConverted);
            // 
            // btnRescan
            // 
            this.btnRescan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnRescan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRescan.ForeColor = System.Drawing.Color.Gold;
            this.btnRescan.Location = new System.Drawing.Point(938, 585);
            this.btnRescan.Name = "btnRescan";
            this.btnRescan.Size = new System.Drawing.Size(180, 27);
            this.btnRescan.TabIndex = 10;
            this.btnRescan.Text = "Rescan the transactions";
            this.btnRescan.UseVisualStyleBackColor = true;
            this.btnRescan.Click += new System.EventHandler(this.btnRescan_Click);
            // 
            // pnlSendCoins
            // 
            this.pnlSendCoins.BackColor = System.Drawing.Color.Black;
            this.pnlSendCoins.BackgroundImage = global::SimpleWallet.Properties.Resources.zero05;
            this.pnlSendCoins.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlSendCoins.Controls.Add(this.groupBox2);
            this.pnlSendCoins.Controls.Add(this.label2);
            this.pnlSendCoins.Controls.Add(this.groupBox1);
            this.pnlSendCoins.Controls.Add(this.label15);
            this.pnlSendCoins.Location = new System.Drawing.Point(169, 25);
            this.pnlSendCoins.Name = "pnlSendCoins";
            this.pnlSendCoins.Size = new System.Drawing.Size(1132, 620);
            this.pnlSendCoins.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.groupBox2.Controls.Add(this.btnMaxAmount);
            this.groupBox2.Controls.Add(this.btnSendMany);
            this.groupBox2.Controls.Add(this.cbbAddress);
            this.groupBox2.Controls.Add(this.cbDefaultFee);
            this.groupBox2.Controls.Add(this.cbbFrom);
            this.groupBox2.Controls.Add(this.btnSend);
            this.groupBox2.Controls.Add(this.btnRefresh);
            this.groupBox2.Controls.Add(this.tbAmount);
            this.groupBox2.Controls.Add(this.cbUnit);
            this.groupBox2.Controls.Add(this.tbFee);
            this.groupBox2.Controls.Add(this.tbLabel);
            this.groupBox2.Controls.Add(this.tbPayTo);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.ForeColor = System.Drawing.Color.Gold;
            this.groupBox2.Location = new System.Drawing.Point(12, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1106, 201);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Normal send";
            // 
            // btnMaxAmount
            // 
            this.btnMaxAmount.BackColor = System.Drawing.Color.Black;
            this.btnMaxAmount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnMaxAmount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaxAmount.Location = new System.Drawing.Point(69, 159);
            this.btnMaxAmount.Margin = new System.Windows.Forms.Padding(0);
            this.btnMaxAmount.Name = "btnMaxAmount";
            this.btnMaxAmount.Size = new System.Drawing.Size(87, 27);
            this.btnMaxAmount.TabIndex = 18;
            this.btnMaxAmount.Text = "Max Amount";
            this.ttStart.SetToolTip(this.btnMaxAmount, "Refresh address value");
            this.btnMaxAmount.UseVisualStyleBackColor = false;
            this.btnMaxAmount.Click += new System.EventHandler(this.btnMaxAmount_Click);
            // 
            // btnSendMany
            // 
            this.btnSendMany.BackColor = System.Drawing.Color.Black;
            this.btnSendMany.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnSendMany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMany.Location = new System.Drawing.Point(974, 159);
            this.btnSendMany.Name = "btnSendMany";
            this.btnSendMany.Size = new System.Drawing.Size(118, 27);
            this.btnSendMany.TabIndex = 16;
            this.btnSendMany.Text = "Send Many";
            this.btnSendMany.UseVisualStyleBackColor = false;
            this.btnSendMany.Click += new System.EventHandler(this.btnSendMany_Click);
            // 
            // cbbAddress
            // 
            this.cbbAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbAddress.FormattingEnabled = true;
            this.cbbAddress.Location = new System.Drawing.Point(851, 49);
            this.cbbAddress.Name = "cbbAddress";
            this.cbbAddress.Size = new System.Drawing.Size(241, 23);
            this.cbbAddress.Sorted = true;
            this.cbbAddress.TabIndex = 2;
            this.cbbAddress.SelectedIndexChanged += new System.EventHandler(this.cbbAddress_SelectedIndexChanged);
            // 
            // cbDefaultFee
            // 
            this.cbDefaultFee.AutoSize = true;
            this.cbDefaultFee.Checked = true;
            this.cbDefaultFee.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDefaultFee.Location = new System.Drawing.Point(226, 133);
            this.cbDefaultFee.Name = "cbDefaultFee";
            this.cbDefaultFee.Size = new System.Drawing.Size(85, 19);
            this.cbDefaultFee.TabIndex = 7;
            this.cbDefaultFee.Text = "Default fee";
            this.cbDefaultFee.UseVisualStyleBackColor = true;
            this.cbDefaultFee.CheckedChanged += new System.EventHandler(this.cbFee_CheckedChanged);
            // 
            // cbbFrom
            // 
            this.cbbFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFrom.FormattingEnabled = true;
            this.cbbFrom.Location = new System.Drawing.Point(69, 20);
            this.cbbFrom.Name = "cbbFrom";
            this.cbbFrom.Size = new System.Drawing.Size(1023, 23);
            this.cbbFrom.Sorted = true;
            this.cbbFrom.TabIndex = 0;
            this.cbbFrom.SelectedIndexChanged += new System.EventHandler(this.cbbFrom_SelectedIndexChanged);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Black;
            this.btnSend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Location = new System.Drawing.Point(881, 159);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(87, 27);
            this.btnSend.TabIndex = 15;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Black;
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(788, 159);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(87, 27);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "Refresh";
            this.ttStart.SetToolTip(this.btnRefresh, "Refresh address value");
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(69, 103);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(151, 21);
            this.tbAmount.TabIndex = 4;
            this.tbAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAmount_KeyPress);
            // 
            // cbUnit
            // 
            this.cbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnit.FormattingEnabled = true;
            this.cbUnit.Items.AddRange(new object[] {
            "Zer"});
            this.cbUnit.Location = new System.Drawing.Point(226, 101);
            this.cbUnit.Name = "cbUnit";
            this.cbUnit.Size = new System.Drawing.Size(100, 23);
            this.cbUnit.TabIndex = 5;
            // 
            // tbFee
            // 
            this.tbFee.Enabled = false;
            this.tbFee.Location = new System.Drawing.Point(69, 130);
            this.tbFee.Name = "tbFee";
            this.tbFee.Size = new System.Drawing.Size(151, 21);
            this.tbFee.TabIndex = 6;
            this.tbFee.Text = "0.0001";
            this.tbFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAmount_KeyPress);
            // 
            // tbLabel
            // 
            this.tbLabel.Location = new System.Drawing.Point(69, 76);
            this.tbLabel.Name = "tbLabel";
            this.tbLabel.Size = new System.Drawing.Size(756, 21);
            this.tbLabel.TabIndex = 3;
            // 
            // tbPayTo
            // 
            this.tbPayTo.Location = new System.Drawing.Point(69, 49);
            this.tbPayTo.Name = "tbPayTo";
            this.tbPayTo.Size = new System.Drawing.Size(776, 21);
            this.tbPayTo.TabIndex = 1;
            this.tbPayTo.Leave += new System.EventHandler(this.tbPayTo_Leave);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(18, 538);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(506, 21);
            this.label2.TabIndex = 17;
            this.label2.Text = "** Outbound transactions from Z (sprout) addresses are not reported in the transa" +
    "ction log.";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.groupBox1.Controls.Add(this.btShield);
            this.groupBox1.Controls.Add(this.cbbShieldTo);
            this.groupBox1.Controls.Add(this.cbbShieldFrom);
            this.groupBox1.Controls.Add(this.tbShieldUtxo);
            this.groupBox1.Controls.Add(this.cbShieldDefaultFee);
            this.groupBox1.Controls.Add(this.tbShieldFee);
            this.groupBox1.Controls.Add(this.transparentLabel3);
            this.groupBox1.Controls.Add(this.transparentLabel6);
            this.groupBox1.Controls.Add(this.transparentLabel5);
            this.groupBox1.Controls.Add(this.transparentLabel4);
            this.groupBox1.ForeColor = System.Drawing.Color.Gold;
            this.groupBox1.Location = new System.Drawing.Point(12, 233);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1106, 152);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shield coinbase";
            // 
            // btShield
            // 
            this.btShield.BackColor = System.Drawing.Color.Black;
            this.btShield.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btShield.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btShield.Location = new System.Drawing.Point(285, 95);
            this.btShield.Name = "btShield";
            this.btShield.Size = new System.Drawing.Size(118, 27);
            this.btShield.TabIndex = 18;
            this.btShield.Text = "Shield Coinbase";
            this.btShield.UseVisualStyleBackColor = false;
            this.btShield.Click += new System.EventHandler(this.btnShield_Click);
            // 
            // cbbShieldTo
            // 
            this.cbbShieldTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbShieldTo.FormattingEnabled = true;
            this.cbbShieldTo.Location = new System.Drawing.Point(69, 45);
            this.cbbShieldTo.Name = "cbbShieldTo";
            this.cbbShieldTo.Size = new System.Drawing.Size(1023, 23);
            this.cbbShieldTo.TabIndex = 9;
            // 
            // cbbShieldFrom
            // 
            this.cbbShieldFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbShieldFrom.FormattingEnabled = true;
            this.cbbShieldFrom.Location = new System.Drawing.Point(69, 18);
            this.cbbShieldFrom.Name = "cbbShieldFrom";
            this.cbbShieldFrom.Size = new System.Drawing.Size(1023, 23);
            this.cbbShieldFrom.TabIndex = 8;
            // 
            // tbShieldUtxo
            // 
            this.tbShieldUtxo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tbShieldUtxo.Location = new System.Drawing.Point(69, 74);
            this.tbShieldUtxo.Name = "tbShieldUtxo";
            this.tbShieldUtxo.Size = new System.Drawing.Size(102, 21);
            this.tbShieldUtxo.TabIndex = 10;
            this.tbShieldUtxo.Text = "utxo to shield";
            this.tbShieldUtxo.Enter += new System.EventHandler(this.tbShieldUtxo_Enter);
            this.tbShieldUtxo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAmount_KeyPress);
            this.tbShieldUtxo.Leave += new System.EventHandler(this.tbShieldUtxo_Leave);
            // 
            // cbShieldDefaultFee
            // 
            this.cbShieldDefaultFee.AutoSize = true;
            this.cbShieldDefaultFee.Checked = true;
            this.cbShieldDefaultFee.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShieldDefaultFee.Location = new System.Drawing.Point(177, 104);
            this.cbShieldDefaultFee.Name = "cbShieldDefaultFee";
            this.cbShieldDefaultFee.Size = new System.Drawing.Size(85, 19);
            this.cbShieldDefaultFee.TabIndex = 12;
            this.cbShieldDefaultFee.Text = "Default fee";
            this.cbShieldDefaultFee.UseVisualStyleBackColor = true;
            this.cbShieldDefaultFee.CheckedChanged += new System.EventHandler(this.cbShieldDefaultFee_CheckedChanged);
            // 
            // tbShieldFee
            // 
            this.tbShieldFee.Enabled = false;
            this.tbShieldFee.Location = new System.Drawing.Point(69, 101);
            this.tbShieldFee.Name = "tbShieldFee";
            this.tbShieldFee.Size = new System.Drawing.Size(102, 21);
            this.tbShieldFee.TabIndex = 11;
            this.tbShieldFee.Text = "0.0001";
            this.tbShieldFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAmount_KeyPress);
            this.tbShieldFee.Leave += new System.EventHandler(this.tbPayTo_Leave);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.ForeColor = System.Drawing.Color.Gold;
            this.label15.Location = new System.Drawing.Point(18, 422);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(499, 99);
            this.label15.TabIndex = 9;
            this.label15.Text = resources.GetString("label15.Text");
            // 
            // pbSignal
            // 
            this.pbSignal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbSignal.Location = new System.Drawing.Point(1249, 638);
            this.pbSignal.Name = "pbSignal";
            this.pbSignal.Size = new System.Drawing.Size(16, 16);
            this.pbSignal.TabIndex = 6;
            this.pbSignal.TabStop = false;
            // 
            // pbStatus
            // 
            this.pbStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbStatus.Location = new System.Drawing.Point(1271, 638);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(16, 16);
            this.pbStatus.TabIndex = 6;
            this.pbStatus.TabStop = false;
            // 
            // pnlReceiveCoins
            // 
            this.pnlReceiveCoins.BackColor = System.Drawing.Color.Black;
            this.pnlReceiveCoins.BackgroundImage = global::SimpleWallet.Properties.Resources.zero05;
            this.pnlReceiveCoins.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlReceiveCoins.Controls.Add(this.btnNewSaplingAddress);
            this.pnlReceiveCoins.Controls.Add(this.dtgAddress);
            this.pnlReceiveCoins.Controls.Add(this.btnNewAddress);
            this.pnlReceiveCoins.Controls.Add(this.btnAddressBook);
            this.pnlReceiveCoins.Location = new System.Drawing.Point(169, 25);
            this.pnlReceiveCoins.Name = "pnlReceiveCoins";
            this.pnlReceiveCoins.Size = new System.Drawing.Size(1132, 620);
            this.pnlReceiveCoins.TabIndex = 9;
            // 
            // btnNewSaplingAddress
            // 
            this.btnNewSaplingAddress.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnNewSaplingAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewSaplingAddress.ForeColor = System.Drawing.Color.Gold;
            this.btnNewSaplingAddress.Location = new System.Drawing.Point(944, 585);
            this.btnNewSaplingAddress.Name = "btnNewSaplingAddress";
            this.btnNewSaplingAddress.Size = new System.Drawing.Size(180, 27);
            this.btnNewSaplingAddress.TabIndex = 10;
            this.btnNewSaplingAddress.Text = "Get new Z address (Sapling)";
            this.btnNewSaplingAddress.UseVisualStyleBackColor = true;
            this.btnNewSaplingAddress.Click += new System.EventHandler(this.btnNewSaplingAddress_Click);
            // 
            // dtgAddress
            // 
            this.dtgAddress.AllowUserToAddRows = false;
            this.dtgAddress.AllowUserToDeleteRows = false;
            this.dtgAddress.AllowUserToResizeColumns = false;
            this.dtgAddress.AllowUserToResizeRows = false;
            this.dtgAddress.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dtgAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgAddress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAddress.Location = new System.Drawing.Point(10, 14);
            this.dtgAddress.MultiSelect = false;
            this.dtgAddress.Name = "dtgAddress";
            this.dtgAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtgAddress.Size = new System.Drawing.Size(1112, 555);
            this.dtgAddress.TabIndex = 9;
            this.dtgAddress.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgAddress_CellMouseClick);
            this.dtgAddress.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dtg_MouseClick);
            // 
            // btnNewAddress
            // 
            this.btnNewAddress.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnNewAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewAddress.ForeColor = System.Drawing.Color.Gold;
            this.btnNewAddress.Location = new System.Drawing.Point(758, 585);
            this.btnNewAddress.Name = "btnNewAddress";
            this.btnNewAddress.Size = new System.Drawing.Size(180, 27);
            this.btnNewAddress.TabIndex = 7;
            this.btnNewAddress.Text = "Get new t address";
            this.btnNewAddress.UseVisualStyleBackColor = true;
            this.btnNewAddress.Click += new System.EventHandler(this.btnNewAddress_Click);
            // 
            // btnAddressBook
            // 
            this.btnAddressBook.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnAddressBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddressBook.ForeColor = System.Drawing.Color.Gold;
            this.btnAddressBook.Location = new System.Drawing.Point(572, 585);
            this.btnAddressBook.Name = "btnAddressBook";
            this.btnAddressBook.Size = new System.Drawing.Size(180, 27);
            this.btnAddressBook.TabIndex = 7;
            this.btnAddressBook.Text = "Address Book";
            this.btnAddressBook.UseVisualStyleBackColor = true;
            this.btnAddressBook.Click += new System.EventHandler(this.btnAddressBook_Click);
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.Black;
            this.pnlInfo.BackgroundImage = global::SimpleWallet.Properties.Resources.zero05;
            this.pnlInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlInfo.Controls.Add(this.transparentLabel66);
            this.pnlInfo.Controls.Add(this.panel5);
            this.pnlInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlInfo.Location = new System.Drawing.Point(169, 25);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(1132, 620);
            this.pnlInfo.TabIndex = 67;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.panel5.Controls.Add(this.transparentLabel45);
            this.panel5.Controls.Add(this.dtgZeroNode);
            this.panel5.Controls.Add(this.dtgWalletInfo);
            this.panel5.Controls.Add(this.progressBar2);
            this.panel5.Controls.Add(this.pictureBox3);
            this.panel5.Controls.Add(this.pictureBox4);
            this.panel5.ForeColor = System.Drawing.Color.Black;
            this.panel5.Location = new System.Drawing.Point(5, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1119, 383);
            this.panel5.TabIndex = 50;
            // 
            // dtgZeroNode
            // 
            this.dtgZeroNode.AllowUserToAddRows = false;
            this.dtgZeroNode.AllowUserToDeleteRows = false;
            this.dtgZeroNode.AllowUserToResizeColumns = false;
            this.dtgZeroNode.AllowUserToResizeRows = false;
            this.dtgZeroNode.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.dtgZeroNode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgZeroNode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgZeroNode.Location = new System.Drawing.Point(581, 36);
            this.dtgZeroNode.MultiSelect = false;
            this.dtgZeroNode.Name = "dtgZeroNode";
            this.dtgZeroNode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtgZeroNode.Size = new System.Drawing.Size(518, 332);
            this.dtgZeroNode.TabIndex = 50;
            // 
            // dtgWalletInfo
            // 
            this.dtgWalletInfo.AllowUserToAddRows = false;
            this.dtgWalletInfo.AllowUserToDeleteRows = false;
            this.dtgWalletInfo.AllowUserToResizeColumns = false;
            this.dtgWalletInfo.AllowUserToResizeRows = false;
            this.dtgWalletInfo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.dtgWalletInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgWalletInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgWalletInfo.Location = new System.Drawing.Point(16, 36);
            this.dtgWalletInfo.MultiSelect = false;
            this.dtgWalletInfo.Name = "dtgWalletInfo";
            this.dtgWalletInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtgWalletInfo.Size = new System.Drawing.Size(518, 332);
            this.dtgWalletInfo.TabIndex = 49;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(201, 638);
            this.progressBar2.Maximum = 10000;
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(1041, 16);
            this.progressBar2.Step = 1;
            this.progressBar2.TabIndex = 1;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox3.Location = new System.Drawing.Point(1249, 638);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox4.Location = new System.Drawing.Point(1271, 638);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 16);
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            // 
            // addressBookBindingSource
            // 
            this.addressBookBindingSource.DataSource = typeof(SimpleWallet.Types.AddressBook);
            // 
            // masternodeListBindingSource
            // 
            this.masternodeListBindingSource.DataSource = typeof(SimpleWallet.Types.MasternodeList);
            // 
            // lbImmatureTxt
            // 
            this.lbImmatureTxt.AutoSize = true;
            this.lbImmatureTxt.BackColor = System.Drawing.Color.Transparent;
            this.lbImmatureTxt.ForeColor = System.Drawing.Color.Gold;
            this.lbImmatureTxt.Location = new System.Drawing.Point(21, 186);
            this.lbImmatureTxt.Name = "lbImmatureTxt";
            this.lbImmatureTxt.Opacity = 0;
            this.lbImmatureTxt.Size = new System.Drawing.Size(60, 15);
            this.lbImmatureTxt.TabIndex = 23;
            this.lbImmatureTxt.Text = "Immature";
            this.lbImmatureTxt.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // lbImmature
            // 
            this.lbImmature.AutoSize = true;
            this.lbImmature.BackColor = System.Drawing.Color.Transparent;
            this.lbImmature.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbImmature.ForeColor = System.Drawing.Color.Gold;
            this.lbImmature.Location = new System.Drawing.Point(142, 186);
            this.lbImmature.Name = "lbImmature";
            this.lbImmature.Opacity = 0;
            this.lbImmature.Size = new System.Drawing.Size(103, 15);
            this.lbImmature.TabIndex = 24;
            this.lbImmature.Text = "Loading data...";
            this.lbImmature.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Gold;
            this.label3.Location = new System.Drawing.Point(20, 207);
            this.label3.Name = "label3";
            this.label3.Opacity = 0;
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 19;
            this.label3.Text = "Locked";
            this.label3.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // lbLocked
            // 
            this.lbLocked.AutoSize = true;
            this.lbLocked.BackColor = System.Drawing.Color.Transparent;
            this.lbLocked.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLocked.ForeColor = System.Drawing.Color.Gold;
            this.lbLocked.Location = new System.Drawing.Point(141, 207);
            this.lbLocked.Name = "lbLocked";
            this.lbLocked.Opacity = 0;
            this.lbLocked.Size = new System.Drawing.Size(103, 15);
            this.lbLocked.TabIndex = 20;
            this.lbLocked.Text = "Loading data...";
            this.lbLocked.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // lblConfirmed
            // 
            this.lblConfirmed.AutoSize = true;
            this.lblConfirmed.BackColor = System.Drawing.Color.Transparent;
            this.lblConfirmed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmed.ForeColor = System.Drawing.Color.Gold;
            this.lblConfirmed.Location = new System.Drawing.Point(142, 52);
            this.lblConfirmed.Name = "lblConfirmed";
            this.lblConfirmed.Opacity = 0;
            this.lblConfirmed.Size = new System.Drawing.Size(78, 16);
            this.lblConfirmed.TabIndex = 18;
            this.lblConfirmed.Text = "Confirmed";
            this.lblConfirmed.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // lblUnconfirmedHeader
            // 
            this.lblUnconfirmedHeader.AutoSize = true;
            this.lblUnconfirmedHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblUnconfirmedHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnconfirmedHeader.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblUnconfirmedHeader.Location = new System.Drawing.Point(269, 52);
            this.lblUnconfirmedHeader.Name = "lblUnconfirmedHeader";
            this.lblUnconfirmedHeader.Opacity = 0;
            this.lblUnconfirmedHeader.Size = new System.Drawing.Size(95, 16);
            this.lblUnconfirmedHeader.TabIndex = 17;
            this.lblUnconfirmedHeader.Text = "Unconfirmed";
            this.lblUnconfirmedHeader.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // lblTotalUnconfirmed
            // 
            this.lblTotalUnconfirmed.AutoSize = true;
            this.lblTotalUnconfirmed.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalUnconfirmed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalUnconfirmed.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTotalUnconfirmed.Location = new System.Drawing.Point(268, 106);
            this.lblTotalUnconfirmed.Name = "lblTotalUnconfirmed";
            this.lblTotalUnconfirmed.Opacity = 0;
            this.lblTotalUnconfirmed.Size = new System.Drawing.Size(103, 15);
            this.lblTotalUnconfirmed.TabIndex = 14;
            this.lblTotalUnconfirmed.Text = "Loading data...";
            this.lblTotalUnconfirmed.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // lblPrivateUnconfirmed
            // 
            this.lblPrivateUnconfirmed.AutoSize = true;
            this.lblPrivateUnconfirmed.BackColor = System.Drawing.Color.Transparent;
            this.lblPrivateUnconfirmed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrivateUnconfirmed.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblPrivateUnconfirmed.Location = new System.Drawing.Point(268, 88);
            this.lblPrivateUnconfirmed.Name = "lblPrivateUnconfirmed";
            this.lblPrivateUnconfirmed.Opacity = 0;
            this.lblPrivateUnconfirmed.Size = new System.Drawing.Size(103, 15);
            this.lblPrivateUnconfirmed.TabIndex = 15;
            this.lblPrivateUnconfirmed.Text = "Loading data...";
            this.lblPrivateUnconfirmed.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // lblTransparentUnconfirmed
            // 
            this.lblTransparentUnconfirmed.AutoSize = true;
            this.lblTransparentUnconfirmed.BackColor = System.Drawing.Color.Transparent;
            this.lblTransparentUnconfirmed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransparentUnconfirmed.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTransparentUnconfirmed.Location = new System.Drawing.Point(268, 72);
            this.lblTransparentUnconfirmed.Name = "lblTransparentUnconfirmed";
            this.lblTransparentUnconfirmed.Opacity = 0;
            this.lblTransparentUnconfirmed.Size = new System.Drawing.Size(103, 15);
            this.lblTransparentUnconfirmed.TabIndex = 16;
            this.lblTransparentUnconfirmed.Text = "Loading data...";
            this.lblTransparentUnconfirmed.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gold;
            this.label5.Location = new System.Drawing.Point(573, 31);
            this.label5.Name = "label5";
            this.label5.Opacity = 0;
            this.label5.Size = new System.Drawing.Size(201, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "Recent Transactions";
            this.label5.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // lbBestTime
            // 
            this.lbBestTime.AutoSize = true;
            this.lbBestTime.BackColor = System.Drawing.Color.Transparent;
            this.lbBestTime.ForeColor = System.Drawing.Color.Gold;
            this.lbBestTime.Location = new System.Drawing.Point(161, 572);
            this.lbBestTime.Name = "lbBestTime";
            this.lbBestTime.Opacity = 0;
            this.lbBestTime.Size = new System.Drawing.Size(0, 15);
            this.lbBestTime.TabIndex = 3;
            this.lbBestTime.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // lbBestHash
            // 
            this.lbBestHash.AutoSize = true;
            this.lbBestHash.BackColor = System.Drawing.Color.Transparent;
            this.lbBestHash.ForeColor = System.Drawing.Color.Gold;
            this.lbBestHash.Location = new System.Drawing.Point(161, 587);
            this.lbBestHash.Name = "lbBestHash";
            this.lbBestHash.Opacity = 0;
            this.lbBestHash.Size = new System.Drawing.Size(0, 15);
            this.lbBestHash.TabIndex = 4;
            this.lbBestHash.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(20, 106);
            this.label1.Name = "label1";
            this.label1.Opacity = 0;
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Total";
            this.label1.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // lbAddress4
            // 
            this.lbAddress4.AutoSize = true;
            this.lbAddress4.BackColor = System.Drawing.Color.Transparent;
            this.lbAddress4.ForeColor = System.Drawing.Color.Gold;
            this.lbAddress4.Location = new System.Drawing.Point(642, 340);
            this.lbAddress4.Name = "lbAddress4";
            this.lbAddress4.Opacity = 0;
            this.lbAddress4.Size = new System.Drawing.Size(51, 15);
            this.lbAddress4.TabIndex = 13;
            this.lbAddress4.Text = "address";
            this.lbAddress4.TransparentBackColor = System.Drawing.Color.Blue;
            this.lbAddress4.Visible = false;
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.BackColor = System.Drawing.Color.Transparent;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.ForeColor = System.Drawing.Color.Gold;
            this.lbTotal.Location = new System.Drawing.Point(141, 106);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Opacity = 0;
            this.lbTotal.Size = new System.Drawing.Size(103, 15);
            this.lbTotal.TabIndex = 5;
            this.lbTotal.Text = "Loading data...";
            this.lbTotal.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // lbAddress3
            // 
            this.lbAddress3.AutoSize = true;
            this.lbAddress3.BackColor = System.Drawing.Color.Transparent;
            this.lbAddress3.ForeColor = System.Drawing.Color.Gold;
            this.lbAddress3.Location = new System.Drawing.Point(642, 258);
            this.lbAddress3.Name = "lbAddress3";
            this.lbAddress3.Opacity = 0;
            this.lbAddress3.Size = new System.Drawing.Size(51, 15);
            this.lbAddress3.TabIndex = 13;
            this.lbAddress3.Text = "address";
            this.lbAddress3.TransparentBackColor = System.Drawing.Color.Blue;
            this.lbAddress3.Visible = false;
            // 
            // transparentLabel1
            // 
            this.transparentLabel1.AutoSize = true;
            this.transparentLabel1.BackColor = System.Drawing.Color.Transparent;
            this.transparentLabel1.ForeColor = System.Drawing.Color.Gold;
            this.transparentLabel1.Location = new System.Drawing.Point(20, 88);
            this.transparentLabel1.Name = "transparentLabel1";
            this.transparentLabel1.Opacity = 0;
            this.transparentLabel1.Size = new System.Drawing.Size(44, 15);
            this.transparentLabel1.TabIndex = 5;
            this.transparentLabel1.Text = "Private";
            this.transparentLabel1.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // lbAddress2
            // 
            this.lbAddress2.AutoSize = true;
            this.lbAddress2.BackColor = System.Drawing.Color.Transparent;
            this.lbAddress2.ForeColor = System.Drawing.Color.Gold;
            this.lbAddress2.Location = new System.Drawing.Point(642, 177);
            this.lbAddress2.Name = "lbAddress2";
            this.lbAddress2.Opacity = 0;
            this.lbAddress2.Size = new System.Drawing.Size(51, 15);
            this.lbAddress2.TabIndex = 13;
            this.lbAddress2.Text = "address";
            this.lbAddress2.TransparentBackColor = System.Drawing.Color.Blue;
            this.lbAddress2.Visible = false;
            // 
            // lbAddress1
            // 
            this.lbAddress1.AutoSize = true;
            this.lbAddress1.BackColor = System.Drawing.Color.Transparent;
            this.lbAddress1.ForeColor = System.Drawing.Color.Gold;
            this.lbAddress1.Location = new System.Drawing.Point(642, 97);
            this.lbAddress1.Name = "lbAddress1";
            this.lbAddress1.Opacity = 0;
            this.lbAddress1.Size = new System.Drawing.Size(51, 15);
            this.lbAddress1.TabIndex = 13;
            this.lbAddress1.Text = "address";
            this.lbAddress1.TransparentBackColor = System.Drawing.Color.Blue;
            this.lbAddress1.Visible = false;
            // 
            // lbPrivate
            // 
            this.lbPrivate.AutoSize = true;
            this.lbPrivate.BackColor = System.Drawing.Color.Transparent;
            this.lbPrivate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrivate.ForeColor = System.Drawing.Color.Gold;
            this.lbPrivate.Location = new System.Drawing.Point(141, 88);
            this.lbPrivate.Name = "lbPrivate";
            this.lbPrivate.Opacity = 0;
            this.lbPrivate.Size = new System.Drawing.Size(103, 15);
            this.lbPrivate.TabIndex = 5;
            this.lbPrivate.Text = "Loading data...";
            this.lbPrivate.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // lbValue4
            // 
            this.lbValue4.AutoSize = true;
            this.lbValue4.BackColor = System.Drawing.Color.Transparent;
            this.lbValue4.ForeColor = System.Drawing.Color.Gold;
            this.lbValue4.Location = new System.Drawing.Point(793, 316);
            this.lbValue4.Name = "lbValue4";
            this.lbValue4.Opacity = 0;
            this.lbValue4.Size = new System.Drawing.Size(36, 15);
            this.lbValue4.TabIndex = 13;
            this.lbValue4.Text = "value";
            this.lbValue4.TransparentBackColor = System.Drawing.Color.Blue;
            this.lbValue4.Visible = false;
            // 
            // lbValue3
            // 
            this.lbValue3.AutoSize = true;
            this.lbValue3.BackColor = System.Drawing.Color.Transparent;
            this.lbValue3.ForeColor = System.Drawing.Color.Gold;
            this.lbValue3.Location = new System.Drawing.Point(793, 233);
            this.lbValue3.Name = "lbValue3";
            this.lbValue3.Opacity = 0;
            this.lbValue3.Size = new System.Drawing.Size(36, 15);
            this.lbValue3.TabIndex = 13;
            this.lbValue3.Text = "value";
            this.lbValue3.TransparentBackColor = System.Drawing.Color.Blue;
            this.lbValue3.Visible = false;
            // 
            // tlTransparentBalance
            // 
            this.tlTransparentBalance.AutoSize = true;
            this.tlTransparentBalance.BackColor = System.Drawing.Color.Transparent;
            this.tlTransparentBalance.ForeColor = System.Drawing.Color.Gold;
            this.tlTransparentBalance.Location = new System.Drawing.Point(20, 72);
            this.tlTransparentBalance.Name = "tlTransparentBalance";
            this.tlTransparentBalance.Opacity = 0;
            this.tlTransparentBalance.Size = new System.Drawing.Size(73, 15);
            this.tlTransparentBalance.TabIndex = 5;
            this.tlTransparentBalance.Text = "Transparent";
            this.tlTransparentBalance.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // lbValue2
            // 
            this.lbValue2.AutoSize = true;
            this.lbValue2.BackColor = System.Drawing.Color.Transparent;
            this.lbValue2.ForeColor = System.Drawing.Color.Gold;
            this.lbValue2.Location = new System.Drawing.Point(793, 152);
            this.lbValue2.Name = "lbValue2";
            this.lbValue2.Opacity = 0;
            this.lbValue2.Size = new System.Drawing.Size(36, 15);
            this.lbValue2.TabIndex = 13;
            this.lbValue2.Text = "value";
            this.lbValue2.TransparentBackColor = System.Drawing.Color.Blue;
            this.lbValue2.Visible = false;
            // 
            // lbTransparent
            // 
            this.lbTransparent.AutoSize = true;
            this.lbTransparent.BackColor = System.Drawing.Color.Transparent;
            this.lbTransparent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTransparent.ForeColor = System.Drawing.Color.Gold;
            this.lbTransparent.Location = new System.Drawing.Point(141, 72);
            this.lbTransparent.Name = "lbTransparent";
            this.lbTransparent.Opacity = 0;
            this.lbTransparent.Size = new System.Drawing.Size(103, 15);
            this.lbTransparent.TabIndex = 5;
            this.lbTransparent.Text = "Loading data...";
            this.lbTransparent.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // lbValue1
            // 
            this.lbValue1.AutoSize = true;
            this.lbValue1.BackColor = System.Drawing.Color.Transparent;
            this.lbValue1.ForeColor = System.Drawing.Color.Gold;
            this.lbValue1.Location = new System.Drawing.Point(793, 72);
            this.lbValue1.Name = "lbValue1";
            this.lbValue1.Opacity = 0;
            this.lbValue1.Size = new System.Drawing.Size(36, 15);
            this.lbValue1.TabIndex = 13;
            this.lbValue1.Text = "value";
            this.lbValue1.TransparentBackColor = System.Drawing.Color.Blue;
            this.lbValue1.Visible = false;
            // 
            // lbTime4
            // 
            this.lbTime4.AutoSize = true;
            this.lbTime4.BackColor = System.Drawing.Color.Transparent;
            this.lbTime4.ForeColor = System.Drawing.Color.Gold;
            this.lbTime4.Location = new System.Drawing.Point(642, 316);
            this.lbTime4.Name = "lbTime4";
            this.lbTime4.Opacity = 0;
            this.lbTime4.Size = new System.Drawing.Size(31, 15);
            this.lbTime4.TabIndex = 13;
            this.lbTime4.Text = "time";
            this.lbTime4.TransparentBackColor = System.Drawing.Color.Blue;
            this.lbTime4.Visible = false;
            // 
            // lbTime3
            // 
            this.lbTime3.AutoSize = true;
            this.lbTime3.BackColor = System.Drawing.Color.Transparent;
            this.lbTime3.ForeColor = System.Drawing.Color.Gold;
            this.lbTime3.Location = new System.Drawing.Point(642, 233);
            this.lbTime3.Name = "lbTime3";
            this.lbTime3.Opacity = 0;
            this.lbTime3.Size = new System.Drawing.Size(31, 15);
            this.lbTime3.TabIndex = 13;
            this.lbTime3.Text = "time";
            this.lbTime3.TransparentBackColor = System.Drawing.Color.Blue;
            this.lbTime3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gold;
            this.label4.Location = new System.Drawing.Point(19, 31);
            this.label4.Name = "label4";
            this.label4.Opacity = 0;
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "WALLET";
            this.label4.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // lbTime2
            // 
            this.lbTime2.AutoSize = true;
            this.lbTime2.BackColor = System.Drawing.Color.Transparent;
            this.lbTime2.ForeColor = System.Drawing.Color.Gold;
            this.lbTime2.Location = new System.Drawing.Point(642, 152);
            this.lbTime2.Name = "lbTime2";
            this.lbTime2.Opacity = 0;
            this.lbTime2.Size = new System.Drawing.Size(31, 15);
            this.lbTime2.TabIndex = 13;
            this.lbTime2.Text = "time";
            this.lbTime2.TransparentBackColor = System.Drawing.Color.Blue;
            this.lbTime2.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Gold;
            this.label7.Location = new System.Drawing.Point(29, 572);
            this.label7.Name = "label7";
            this.label7.Opacity = 0;
            this.label7.Size = new System.Drawing.Size(102, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "Latest block time:";
            this.label7.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // lbTime1
            // 
            this.lbTime1.AutoSize = true;
            this.lbTime1.BackColor = System.Drawing.Color.Transparent;
            this.lbTime1.ForeColor = System.Drawing.Color.Gold;
            this.lbTime1.Location = new System.Drawing.Point(642, 72);
            this.lbTime1.Name = "lbTime1";
            this.lbTime1.Opacity = 0;
            this.lbTime1.Size = new System.Drawing.Size(31, 15);
            this.lbTime1.TabIndex = 13;
            this.lbTime1.Text = "time";
            this.lbTime1.TransparentBackColor = System.Drawing.Color.Blue;
            this.lbTime1.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.Color.Gold;
            this.label12.Location = new System.Drawing.Point(29, 587);
            this.label12.Name = "label12";
            this.label12.Opacity = 0;
            this.label12.Size = new System.Drawing.Size(105, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "Latest block hash:";
            this.label12.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImage = global::SimpleWallet.Properties.Resources.search;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(570, 541);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(25, 25);
            this.btnSearch.TabIndex = 25;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.MouseEnter += new System.EventHandler(this.btnSearch_MouseEnter);
            this.btnSearch.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(6, 23);
            this.label6.Name = "label6";
            this.label6.Opacity = 0;
            this.label6.Size = new System.Drawing.Size(36, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "From";
            this.label6.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(6, 79);
            this.label9.Name = "label9";
            this.label9.Opacity = 0;
            this.label9.Size = new System.Drawing.Size(58, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Message";
            this.label9.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(6, 52);
            this.label8.Name = "label8";
            this.label8.Opacity = 0;
            this.label8.Size = new System.Drawing.Size(44, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Pay To";
            this.label8.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(6, 106);
            this.label10.Name = "label10";
            this.label10.Opacity = 0;
            this.label10.Size = new System.Drawing.Size(49, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Amount";
            this.label10.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(6, 133);
            this.label11.Name = "label11";
            this.label11.Opacity = 0;
            this.label11.Size = new System.Drawing.Size(28, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "Fee";
            this.label11.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // transparentLabel3
            // 
            this.transparentLabel3.AutoSize = true;
            this.transparentLabel3.BackColor = System.Drawing.Color.Transparent;
            this.transparentLabel3.Location = new System.Drawing.Point(6, 23);
            this.transparentLabel3.Name = "transparentLabel3";
            this.transparentLabel3.Opacity = 0;
            this.transparentLabel3.Size = new System.Drawing.Size(36, 15);
            this.transparentLabel3.TabIndex = 0;
            this.transparentLabel3.Text = "From";
            this.transparentLabel3.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // transparentLabel6
            // 
            this.transparentLabel6.AutoSize = true;
            this.transparentLabel6.BackColor = System.Drawing.Color.Transparent;
            this.transparentLabel6.Location = new System.Drawing.Point(6, 77);
            this.transparentLabel6.Name = "transparentLabel6";
            this.transparentLabel6.Opacity = 0;
            this.transparentLabel6.Size = new System.Drawing.Size(63, 15);
            this.transparentLabel6.TabIndex = 0;
            this.transparentLabel6.Text = "Max utxos";
            this.transparentLabel6.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // transparentLabel5
            // 
            this.transparentLabel5.AutoSize = true;
            this.transparentLabel5.BackColor = System.Drawing.Color.Transparent;
            this.transparentLabel5.Location = new System.Drawing.Point(6, 104);
            this.transparentLabel5.Name = "transparentLabel5";
            this.transparentLabel5.Opacity = 0;
            this.transparentLabel5.Size = new System.Drawing.Size(28, 15);
            this.transparentLabel5.TabIndex = 0;
            this.transparentLabel5.Text = "Fee";
            this.transparentLabel5.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // transparentLabel4
            // 
            this.transparentLabel4.AutoSize = true;
            this.transparentLabel4.BackColor = System.Drawing.Color.Transparent;
            this.transparentLabel4.Location = new System.Drawing.Point(6, 50);
            this.transparentLabel4.Name = "transparentLabel4";
            this.transparentLabel4.Opacity = 0;
            this.transparentLabel4.Size = new System.Drawing.Size(21, 15);
            this.transparentLabel4.TabIndex = 0;
            this.transparentLabel4.Text = "To";
            this.transparentLabel4.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // transparentLabel66
            // 
            this.transparentLabel66.AutoSize = true;
            this.transparentLabel66.BackColor = System.Drawing.Color.Transparent;
            this.transparentLabel66.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transparentLabel66.ForeColor = System.Drawing.Color.Gold;
            this.transparentLabel66.Location = new System.Drawing.Point(20, 14);
            this.transparentLabel66.Name = "transparentLabel66";
            this.transparentLabel66.Opacity = 0;
            this.transparentLabel66.Size = new System.Drawing.Size(184, 25);
            this.transparentLabel66.TabIndex = 27;
            this.transparentLabel66.Text = "Wallet Information";
            this.transparentLabel66.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // transparentLabel45
            // 
            this.transparentLabel45.AutoSize = true;
            this.transparentLabel45.BackColor = System.Drawing.Color.Transparent;
            this.transparentLabel45.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transparentLabel45.ForeColor = System.Drawing.Color.Gold;
            this.transparentLabel45.Location = new System.Drawing.Point(576, 8);
            this.transparentLabel45.Name = "transparentLabel45";
            this.transparentLabel45.Opacity = 0;
            this.transparentLabel45.Size = new System.Drawing.Size(219, 25);
            this.transparentLabel45.TabIndex = 48;
            this.transparentLabel45.Text = "ZeroNode Information";
            this.transparentLabel45.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // typesBindingSource
            // 
            this.typesBindingSource.DataSource = typeof(SimpleWallet.Types);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1300, 691);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pnlOverview);
            this.Controls.Add(this.pnlZeronodes);
            this.Controls.Add(this.pnlTransactions);
            this.Controls.Add(this.pnlSendCoins);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlReceiveCoins);
            this.Controls.Add(this.pnlInfo);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Start";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zero Simple Wallet - Version 1.0.2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Start_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Start_FormClosed);
            this.Load += new System.EventHandler(this.Start_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlOverview.ResumeLayout(false);
            this.pnlOverview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTransaction4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTransaction3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTransaction2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTransaction1)).EndInit();
            this.pnlZeronodes.ResumeLayout(false);
            this.pnlZeronodes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGlobalMN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masternodeDetailConvertedBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMasternode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masternodeBindingSource)).EndInit();
            this.pnlTransactions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionConvertedBindingSource)).EndInit();
            this.pnlSendCoins.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSignal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).EndInit();
            this.pnlReceiveCoins.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAddress)).EndInit();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgZeroNode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgWalletInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressBookBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masternodeListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TransparentLabel lbBestTime;
        private TransparentLabel lbBestHash;
        private TransparentLabel label4;
        private TransparentLabel lbTotal;
        private TransparentLabel label1;
        private System.Windows.Forms.ComboBox cbUnit;
        private System.Windows.Forms.TextBox tbLabel;
        private System.Windows.Forms.TextBox tbPayTo;
        private TransparentLabel label11;
        private TransparentLabel label10;
        private TransparentLabel label9;
        private TransparentLabel label8;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbFee;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.ComboBox cbbFrom;
        private TransparentLabel label6;
        private System.Windows.Forms.CheckBox cbDefaultFee;
        private TransparentLabel label12;
        private TransparentLabel label7;
        private System.Windows.Forms.Button btnNewAddress;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem walletToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportPrivateKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importPrivateKeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importOnePrivateKeyToolStripMenuItem;
        private System.Windows.Forms.ToolTip ttStart;
        private System.Windows.Forms.ImageList imgList;
        private TransparentLabel lbTime1;
        private System.Windows.Forms.PictureBox pbTransaction1;
        private TransparentLabel label5;
        private TransparentLabel lbAddress1;
        private System.Windows.Forms.Button btnSendMany;
        private TransparentLabel lbValue1;
        private TransparentLabel lbAddress4;
        private TransparentLabel lbAddress3;
        private TransparentLabel lbAddress2;
        private TransparentLabel lbValue4;
        private TransparentLabel lbValue3;
        private TransparentLabel lbValue2;
        private TransparentLabel lbTime4;
        private TransparentLabel lbTime3;
        private TransparentLabel lbTime2;
        private System.Windows.Forms.PictureBox pbTransaction4;
        private System.Windows.Forms.PictureBox pbTransaction3;
        private System.Windows.Forms.PictureBox pbTransaction2;
        private System.Windows.Forms.DataGridView dtgTransactions;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dtgAddress;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peersToolStripMenuItem;
        private TransparentLabel lbTransparent;
        private TransparentLabel tlTransparentBalance;
        private TransparentLabel lbPrivate;
        private TransparentLabel transparentLabel1;
        private System.Windows.Forms.Button btnRescan;
        private System.Windows.Forms.Button btnReindex;
        private System.Windows.Forms.ComboBox cbbAddress;
        private System.Windows.Forms.ToolStripMenuItem copyZeroconfDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableAutoBackupWalletToolStripMenuItem;
        private System.Windows.Forms.BindingSource masternodeListBindingSource;
        private System.Windows.Forms.BindingSource typesBindingSource;
        //private System.Windows.Forms.DataGridViewTextBoxColumn rankDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn addrDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn activetimeDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn lastseenDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn lastpaidDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn txhashDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn ipDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource masternodeDetailConvertedBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private TransparentLabel transparentLabel3;
        private System.Windows.Forms.TextBox tbShieldUtxo;
        private TransparentLabel transparentLabel6;
        private System.Windows.Forms.TextBox tbShieldFee;
        private TransparentLabel transparentLabel5;
        private TransparentLabel transparentLabel4;
        private System.Windows.Forms.CheckBox cbShieldDefaultFee;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.BindingSource addressBookBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn confirmationsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn txidDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource transactionConvertedBindingSource;
        private System.Windows.Forms.Button btnAddressBook;
        private System.Windows.Forms.ComboBox cbbShieldTo;
        private System.Windows.Forms.ComboBox cbbShieldFrom;
        private System.Windows.Forms.BindingSource masternodeBindingSource;
        private System.Windows.Forms.Panel pnlOverview;
        private System.Windows.Forms.Panel pnlSendCoins;
        private System.Windows.Forms.Panel pnlReceiveCoins;
        private System.Windows.Forms.Panel pnlTransactions;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTransactions;
        private System.Windows.Forms.Button btnSendCoins;
        private System.Windows.Forms.Button btnReceiveCoins;
        private System.Windows.Forms.Button btnOverview;
        private System.Windows.Forms.Button btnClose;
        private TransparentLabel lblUnconfirmedHeader;
        private TransparentLabel lblTotalUnconfirmed;
        private TransparentLabel lblPrivateUnconfirmed;
        private TransparentLabel lblTransparentUnconfirmed;
        private TransparentLabel lblConfirmed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnNewSaplingAddress;
        private System.Windows.Forms.Panel pnlZeronodes;
        private System.Windows.Forms.DataGridView dtgMasternode;
        private System.Windows.Forms.Button btnMasternode;
        private System.Windows.Forms.DataGridView dtgGlobalMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aliasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn privKeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn txHashDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indexDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rankDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn activetimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastseenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastpaidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn txhashDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnRefreshZeronode;
        private System.Windows.Forms.Button btnStartAll;
        private System.Windows.Forms.Button btnStartAlias;
        private System.Windows.Forms.Button btnStartZeronode;
        private System.Windows.Forms.Button btnEditConfigFile;
        private System.Windows.Forms.Button btnGetOutputs;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnGetMNPrivKey;
        private System.Windows.Forms.Label lbUpdateTime;
        private System.Windows.Forms.Button btnClearMNCache;
        private RoundButton btnSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar pbPercent;
        private System.Windows.Forms.PictureBox pbSignal;
        private System.Windows.Forms.PictureBox pbStatus;
        private System.Windows.Forms.Label lblLockedMessage;
        private TransparentLabel label3;
        private TransparentLabel lbLocked;
        private System.Windows.Forms.Button btShield;
        private TransparentLabel lbImmatureTxt;
        private TransparentLabel lbImmature;
        private System.Windows.Forms.Button btnWalletInfo;
        private System.Windows.Forms.Panel pnlInfo;
        private TransparentLabel transparentLabel66;
        private System.Windows.Forms.Panel panel5;
        private TransparentLabel transparentLabel45;
        private System.Windows.Forms.DataGridView dtgZeroNode;
        private System.Windows.Forms.DataGridView dtgWalletInfo;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btnMaxAmount;

    }
}
