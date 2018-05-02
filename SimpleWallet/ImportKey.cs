using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWallet
{
    public partial class ImportKey : Form
    {
        Api api = Api.Instance;
        public ImportKey()
        {
            InitializeComponent();
            tbLabel.Enabled = false;
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

        private void btnImport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Importing process will take alot of time, please be patient");
            Dictionary<String, String> strDict = api.importPrivateKey(tbPrivateKey.Text, tbLabel.Text);
            if (Api.checkResult(strDict))
            {
                MessageBox.Show("Import success");
                this.Close();
            }
            else
            {
                MessageBox.Show(strDict["message"]);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Start.privKey = "";
            this.Close();
        }
    }
}
