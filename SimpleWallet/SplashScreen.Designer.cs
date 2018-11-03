namespace SimpleWallet
{
    partial class SplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.pbProcess = new System.Windows.Forms.ProgressBar();
            this.ttSplash = new System.Windows.Forms.ToolTip(this.components);
            this.lbCurrentStatus = new SimpleWallet.TransparentLabel();
            this.pbProving = new System.Windows.Forms.ProgressBar();
            this.lblVerifing = new SimpleWallet.TransparentLabel();
            this.lblProving = new SimpleWallet.TransparentLabel();
            this.lblGroth = new SimpleWallet.TransparentLabel();
            this.pbGroth = new System.Windows.Forms.ProgressBar();
            this.lblSpend = new SimpleWallet.TransparentLabel();
            this.pbSpend = new System.Windows.Forms.ProgressBar();
            this.lblOutput = new SimpleWallet.TransparentLabel();
            this.pbOutput = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // pbProcess
            // 
            this.pbProcess.Location = new System.Drawing.Point(430, 82);
            this.pbProcess.Margin = new System.Windows.Forms.Padding(4);
            this.pbProcess.Maximum = 10000;
            this.pbProcess.Name = "pbProcess";
            this.pbProcess.Size = new System.Drawing.Size(226, 10);
            this.pbProcess.Step = 1;
            this.pbProcess.TabIndex = 3;
            this.pbProcess.Visible = false;
            this.pbProcess.MouseHover += new System.EventHandler(this.pbProcess_MouseHover);
            // 
            // lbCurrentStatus
            // 
            this.lbCurrentStatus.BackColor = System.Drawing.Color.Transparent;
            this.lbCurrentStatus.ForeColor = System.Drawing.Color.Gold;
            this.lbCurrentStatus.Location = new System.Drawing.Point(0, 268);
            this.lbCurrentStatus.Name = "lbCurrentStatus";
            this.lbCurrentStatus.Opacity = 0;
            this.lbCurrentStatus.Size = new System.Drawing.Size(668, 26);
            this.lbCurrentStatus.TabIndex = 4;
            this.lbCurrentStatus.Text = "Status";
            this.lbCurrentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbCurrentStatus.TransparentBackColor = System.Drawing.Color.Blue;
            // 
            // pbProving
            // 
            this.pbProving.Location = new System.Drawing.Point(430, 126);
            this.pbProving.Margin = new System.Windows.Forms.Padding(4);
            this.pbProving.Maximum = 10000;
            this.pbProving.Name = "pbProving";
            this.pbProving.Size = new System.Drawing.Size(226, 10);
            this.pbProving.Step = 1;
            this.pbProving.TabIndex = 5;
            this.pbProving.Visible = false;
            // 
            // lblVerifing
            // 
            this.lblVerifing.BackColor = System.Drawing.Color.Transparent;
            this.lblVerifing.ForeColor = System.Drawing.Color.Gold;
            this.lblVerifing.Location = new System.Drawing.Point(430, 52);
            this.lblVerifing.Name = "lblVerifing";
            this.lblVerifing.Opacity = 0;
            this.lblVerifing.Size = new System.Drawing.Size(226, 26);
            this.lblVerifing.TabIndex = 9;
            this.lblVerifing.Text = "Verifing Key";
            this.lblVerifing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblVerifing.TransparentBackColor = System.Drawing.Color.Blue;
            this.lblVerifing.Visible = false;
            this.lblVerifing.Click += new System.EventHandler(this.transparentLabel1_Click);
            // 
            // lblProving
            // 
            this.lblProving.BackColor = System.Drawing.Color.Transparent;
            this.lblProving.ForeColor = System.Drawing.Color.Gold;
            this.lblProving.Location = new System.Drawing.Point(430, 96);
            this.lblProving.Name = "lblProving";
            this.lblProving.Opacity = 0;
            this.lblProving.Size = new System.Drawing.Size(226, 26);
            this.lblProving.TabIndex = 10;
            this.lblProving.Text = "Proving Key";
            this.lblProving.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblProving.TransparentBackColor = System.Drawing.Color.Blue;
            this.lblProving.Visible = false;
            // 
            // lblGroth
            // 
            this.lblGroth.BackColor = System.Drawing.Color.Transparent;
            this.lblGroth.ForeColor = System.Drawing.Color.Gold;
            this.lblGroth.Location = new System.Drawing.Point(430, 140);
            this.lblGroth.Name = "lblGroth";
            this.lblGroth.Opacity = 0;
            this.lblGroth.Size = new System.Drawing.Size(226, 26);
            this.lblGroth.TabIndex = 12;
            this.lblGroth.Text = "Groth 16";
            this.lblGroth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGroth.TransparentBackColor = System.Drawing.Color.Blue;
            this.lblGroth.Visible = false;
            // 
            // pbGroth
            // 
            this.pbGroth.Location = new System.Drawing.Point(430, 170);
            this.pbGroth.Margin = new System.Windows.Forms.Padding(4);
            this.pbGroth.Maximum = 10000;
            this.pbGroth.Name = "pbGroth";
            this.pbGroth.Size = new System.Drawing.Size(226, 10);
            this.pbGroth.Step = 1;
            this.pbGroth.TabIndex = 11;
            this.pbGroth.Visible = false;
            // 
            // lblSpend
            // 
            this.lblSpend.BackColor = System.Drawing.Color.Transparent;
            this.lblSpend.ForeColor = System.Drawing.Color.Gold;
            this.lblSpend.Location = new System.Drawing.Point(430, 184);
            this.lblSpend.Name = "lblSpend";
            this.lblSpend.Opacity = 0;
            this.lblSpend.Size = new System.Drawing.Size(226, 26);
            this.lblSpend.TabIndex = 14;
            this.lblSpend.Text = "Sapling Spend";
            this.lblSpend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSpend.TransparentBackColor = System.Drawing.Color.Blue;
            this.lblSpend.Visible = false;
            // 
            // pbSpend
            // 
            this.pbSpend.Location = new System.Drawing.Point(430, 214);
            this.pbSpend.Margin = new System.Windows.Forms.Padding(4);
            this.pbSpend.Maximum = 10000;
            this.pbSpend.Name = "pbSpend";
            this.pbSpend.Size = new System.Drawing.Size(226, 10);
            this.pbSpend.Step = 1;
            this.pbSpend.TabIndex = 13;
            this.pbSpend.Visible = false;
            // 
            // lblOutput
            // 
            this.lblOutput.BackColor = System.Drawing.Color.Transparent;
            this.lblOutput.ForeColor = System.Drawing.Color.Gold;
            this.lblOutput.Location = new System.Drawing.Point(430, 228);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Opacity = 0;
            this.lblOutput.Size = new System.Drawing.Size(226, 26);
            this.lblOutput.TabIndex = 16;
            this.lblOutput.Text = "Sapling Output";
            this.lblOutput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOutput.TransparentBackColor = System.Drawing.Color.Blue;
            this.lblOutput.Visible = false;
            // 
            // pbOutput
            // 
            this.pbOutput.Location = new System.Drawing.Point(430, 258);
            this.pbOutput.Margin = new System.Windows.Forms.Padding(4);
            this.pbOutput.Maximum = 10000;
            this.pbOutput.Name = "pbOutput";
            this.pbOutput.Size = new System.Drawing.Size(226, 10);
            this.pbOutput.Step = 1;
            this.pbOutput.TabIndex = 15;
            this.pbOutput.Visible = false;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::SimpleWallet.Properties.Resources.logo512;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(668, 356);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.pbOutput);
            this.Controls.Add(this.lblSpend);
            this.Controls.Add(this.pbSpend);
            this.Controls.Add(this.lblGroth);
            this.Controls.Add(this.pbGroth);
            this.Controls.Add(this.lblProving);
            this.Controls.Add(this.lblVerifing);
            this.Controls.Add(this.pbProving);
            this.Controls.Add(this.lbCurrentStatus);
            this.Controls.Add(this.pbProcess);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Gold;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SplashScreen_FormClosed);
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbProcess;
        private System.Windows.Forms.ToolTip ttSplash;
        private TransparentLabel lbCurrentStatus;
        private System.Windows.Forms.ProgressBar pbProving;
        private TransparentLabel lblVerifing;
        private TransparentLabel lblProving;
        private TransparentLabel lblGroth;
        private System.Windows.Forms.ProgressBar pbGroth;
        private TransparentLabel lblSpend;
        private System.Windows.Forms.ProgressBar pbSpend;
        private TransparentLabel lblOutput;
        private System.Windows.Forms.ProgressBar pbOutput;
    }
}