namespace SimpleWallet
{
    partial class AddressBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddressBook));
            this.dtgAddressBook = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressBookBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnNewAddressBook = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAddressBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressBookBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgAddressBook
            // 
            this.dtgAddressBook.AutoGenerateColumns = false;
            this.dtgAddressBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAddressBook.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dtgAddressBook.DataSource = this.addressBookBindingSource;
            this.dtgAddressBook.Location = new System.Drawing.Point(12, 32);
            this.dtgAddressBook.Name = "dtgAddressBook";
            this.dtgAddressBook.Size = new System.Drawing.Size(899, 442);
            this.dtgAddressBook.TabIndex = 0;
            this.dtgAddressBook.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dtgAddressBook_MouseClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "label";
            this.dataGridViewTextBoxColumn1.HeaderText = "label";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "address";
            this.dataGridViewTextBoxColumn2.HeaderText = "address";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // addressBookBindingSource
            // 
            this.addressBookBindingSource.DataSource = typeof(SimpleWallet.Types.AddressBook);
            // 
            // btnNewAddressBook
            // 
            this.btnNewAddressBook.BackColor = System.Drawing.Color.Black;
            this.btnNewAddressBook.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnNewAddressBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewAddressBook.ForeColor = System.Drawing.Color.Gold;
            this.btnNewAddressBook.Location = new System.Drawing.Point(731, 481);
            this.btnNewAddressBook.Name = "btnNewAddressBook";
            this.btnNewAddressBook.Size = new System.Drawing.Size(180, 27);
            this.btnNewAddressBook.TabIndex = 12;
            this.btnNewAddressBook.Text = "New address label";
            this.btnNewAddressBook.UseVisualStyleBackColor = false;
            this.btnNewAddressBook.Click += new System.EventHandler(this.btnNewAddressBook_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Gold;
            this.btnClose.Location = new System.Drawing.Point(880, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(49, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Address Book";
            // 
            // AddressBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(924, 519);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNewAddressBook);
            this.Controls.Add(this.dtgAddressBook);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddressBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddressBook";
            this.Load += new System.EventHandler(this.AddressBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAddressBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressBookBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgAddressBook;
        //private System.Windows.Forms.DataGridViewTextBoxColumn labelDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.BindingSource addressBookBindingSource;
        private System.Windows.Forms.Button btnNewAddressBook;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
    }
}