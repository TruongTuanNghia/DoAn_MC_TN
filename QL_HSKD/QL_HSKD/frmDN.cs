using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QL_HSKD
{
    public partial class frmDN : Form
    {
        DataTable dt_nv;
        SqlDataAdapter da_nv;
        DataView dtv_nv;

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OF9JLA8\HIEUKHAI;Initial Catalog=QL_HoSoKiemDinh;User ID=sa;Password=1234");
        public frmDN()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string user = txtTK.Text;
            string pass = txtMK.Text;
            string sql = "SELECT * FROM NGUOIDUNG WHERE MANGUOIDUNG = '" + user + "' AND MATKHAU = '" + pass + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                frmMain fm = new frmMain();
                this.Hide();
                fm.ShowDialog();
                this.Show();

            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
        }
    }
}
