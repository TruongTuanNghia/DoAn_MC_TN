using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_HSKD
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void tmiThongke_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tiêuChuẩnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTieuChuan fm = new frmTieuChuan();
            this.Hide();
            fm.ShowDialog();
            this.Show();
        }
    }
}
