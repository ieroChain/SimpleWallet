namespace SimpleWallet
{
    partial class SendMany
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendMany));
            this.btnSend = new System.Windows.Forms.Button();
            this.cbDefaultFee = new System.Windows.Forms.CheckBox();
            this.tbFee = new System.Windows.Forms.TextBox();
            this.lbFee = new System.Windows.Forms.Label();
            this.rtbAddress = new System.Windows.Forms.RichTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Black;
            this.btnSend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.ForeColor = System.Drawing.Color.Gold;
            this.btnSend.Location = new System.Drawing.Point(584, 374);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 28);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // cbDefaultFee
            // 
            this.cbDefaultFee.AutoSize = true;
            this.cbDefaultFee.Checked = true;
            this.cbDefaultFee.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDefaultFee.ForeColor = System.Drawing.Color.Gold;
            this.cbDefaultFee.Location = new System.Drawing.Point(205, 377);
            this.cbDefaultFee.Margin = new System.Windows.Forms.Padding(4);
            this.cbDefaultFee.Name = "cbDefaultFee";
            this.cbDefaultFee.Size = new System.Drawing.Size(65, 19);
            this.cbDefaultFee.TabIndex = 9;
            this.cbDefaultFee.Text = "Default";
            this.cbDefaultFee.UseVisualStyleBackColor = true;
            this.cbDefaultFee.CheckedChanged += new System.EventHandler(this.cbDefaultFee_CheckedChanged);
            // 
            // tbFee
            // 
            this.tbFee.Enabled = false;
            this.tbFee.Location = new System.Drawing.Point(64, 375);
            this.tbFee.Margin = new System.Windows.Forms.Padding(4);
            this.tbFee.Name = "tbFee";
            this.tbFee.Size = new System.Drawing.Size(132, 21);
            this.tbFee.TabIndex = 8;
            this.tbFee.Text = "0.0001";
            // 
            // lbFee
            // 
            this.lbFee.AutoSize = true;
            this.lbFee.ForeColor = System.Drawing.Color.Gold;
            this.lbFee.Location = new System.Drawing.Point(17, 380);
            this.lbFee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFee.Name = "lbFee";
            this.lbFee.Size = new System.Drawing.Size(28, 15);
            this.lbFee.TabIndex = 7;
            this.lbFee.Text = "Fee";
            // 
            // rtbAddress
            // 
            this.rtbAddress.ForeColor = System.Drawing.SystemColors.GrayText;
            this.rtbAddress.Location = new System.Drawing.Point(13, 33);
            this.rtbAddress.Margin = new System.Windows.Forms.Padding(4);
            this.rtbAddress.Name = "rtbAddress";
            this.rtbAddress.Size = new System.Drawing.Size(669, 333);
            this.rtbAddress.TabIndex = 6;
            this.rtbAddress.Text = "address1,amount1\naddress2,amount2\naddress3,amount3";
            this.rtbAddress.Enter += new System.EventHandler(this.rtbAddress_Enter);
            this.rtbAddress.Leave += new System.EventHandler(this.rtbAddress_Leave);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Gold;
            this.btnClose.Location = new System.Drawing.Point(656, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(42, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Send Many";
            // 
            // SendMany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(700, 415);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.cbDefaultFee);
            this.Controls.Add(this.tbFee);
            this.Controls.Add(this.lbFee);
            this.Controls.Add(this.rtbAddress);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "SendMany";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SendMany";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.CheckBox cbDefaultFee;
        private System.Windows.Forms.TextBox tbFee;
        private System.Windows.Forms.Label lbFee;
        private System.Windows.Forms.RichTextBox rtbAddress;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
    }
}