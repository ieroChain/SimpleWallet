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
    public partial class Debug : Form
    {
        Types.DebugType type;
        String peers = "";
        public Debug(Types.DebugType type, String peers = "")
        {
            InitializeComponent();
            this.type = type;
            this.peers = peers;
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

        private void Debug_Load(object sender, EventArgs e)
        {
            if(type == Types.DebugType.DEBUG)
            {
                tcDebug.SelectTab(tpDebug);
            }
            else if(type == Types.DebugType.PEERS)
            {
                tcDebug.SelectTab(tpPeers);
                rtbPeers.Text = peers;
            }
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
