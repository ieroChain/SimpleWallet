namespace SimpleWallet
{
    partial class QrCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QrCode));
            this.tbQrCode = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pbQrCode = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbQrCode)).BeginInit();
            this.SuspendLayout();
            // 
            // tbQrCode
            // 
            this.tbQrCode.Location = new System.Drawing.Point(12, 345);
            this.tbQrCode.Name = "tbQrCode";
            this.tbQrCode.ReadOnly = true;
            this.tbQrCode.Size = new System.Drawing.Size(300, 20);
            this.tbQrCode.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Gold;
            this.btnClose.Location = new System.Drawing.Point(290, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(33, 27);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Receive Address";
            // 
            // pbQrCode
            // 
            this.pbQrCode.BackColor = System.Drawing.SystemColors.Control;
            this.pbQrCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbQrCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbQrCode.Location = new System.Drawing.Point(12, 39);
            this.pbQrCode.Name = "pbQrCode";
            this.pbQrCode.Size = new System.Drawing.Size(300, 300);
            this.pbQrCode.TabIndex = 0;
            this.pbQrCode.TabStop = false;
            // 
            // QrCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(328, 375);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbQrCode);
            this.Controls.Add(this.pbQrCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "QrCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "QrCode";
            this.Load += new System.EventHandler(this.QrCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbQrCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.PictureBox pbQrCode;
        private System.Windows.Forms.TextBox tbQrCode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
    }
}