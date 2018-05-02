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
            this.SuspendLayout();
            // 
            // pbProcess
            // 
            this.pbProcess.Location = new System.Drawing.Point(19, 311);
            this.pbProcess.Margin = new System.Windows.Forms.Padding(4);
            this.pbProcess.Maximum = 10000;
            this.pbProcess.Name = "pbProcess";
            this.pbProcess.Size = new System.Drawing.Size(630, 12);
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
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::SimpleWallet.Properties.Resources.logo512;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(668, 356);
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
    }
}