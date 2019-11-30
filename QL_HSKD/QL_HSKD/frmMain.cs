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

        private void tiêuChíToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmTieuChi fm = new frmTieuChi();
            this.Hide();
            fm.ShowDialog();
            this.Show();
        }

        private void minhChứngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMinhChung fm = new frmMinhChung();
            this.Hide();
            fm.ShowDialog();
            this.Show();
        }

        private void tmiChange_Click(object sender, EventArgs e)
        {
            frmDMK fm = new frmDMK();
            this.Hide();
            fm.ShowDialog();
            this.Show();
        }
    }
}
