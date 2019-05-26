namespace SimpleWallet
{
    partial class ConfigureMasternode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigureMasternode));
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.tbPrivKey = new System.Windows.Forms.TextBox();
            this.tbOutPuts = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConfigure = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(89, 15);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(577, 21);
            this.tbName.TabIndex = 0;
            this.tbName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyUp_Action);
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(89, 45);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(577, 21);
            this.tbIP.TabIndex = 1;
            this.tbIP.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyUp_Action);
            // 
            // tbPrivKey
            // 
            this.tbPrivKey.Location = new System.Drawing.Point(89, 75);
            this.tbPrivKey.Name = "tbPrivKey";
            this.tbPrivKey.Size = new System.Drawing.Size(577, 21);
            this.tbPrivKey.TabIndex = 2;
            this.tbPrivKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyUp_Action);
            // 
            // tbOutPuts
            // 
            this.tbOutPuts.Location = new System.Drawing.Point(89, 105);
            this.tbOutPuts.Name = "tbOutPuts";
            this.tbOutPuts.Size = new System.Drawing.Size(577, 21);
            this.tbOutPuts.TabIndex = 3;
            this.tbOutPuts.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyUp_Action);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Alias name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "VPS IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Priv Key";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Outputs";
            // 
            // btnConfigure
            // 
            this.btnConfigure.BackColor = System.Drawing.Color.Black;
            this.btnConfigure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigure.Location = new System.Drawing.Point(579, 135);
            this.btnConfigure.Name = "btnConfigure";
            this.btnConfigure.Size = new System.Drawing.Size(87, 27);
            this.btnConfigure.TabIndex = 5;
            this.btnConfigure.Text = "Configure";
            this.btnConfigure.UseVisualStyleBackColor = false;
            this.btnConfigure.Click += new System.EventHandler(this.btnConfigure_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Black;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(484, 135);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 27);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ConfigureMasternode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(680, 171);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfigure);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbOutPuts);
            this.Controls.Add(this.tbPrivKey);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.tbName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Gold;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConfigureMasternode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConfigureMasternode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.TextBox tbPrivKey;
        private System.Windows.Forms.TextBox tbOutPuts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConfigure;
        private System.Windows.Forms.Button btnCancel;
    }
}