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
    public partial class frmTieuChuan : Form
    {
        SqlConnection conn;
        DataTable dt_nv;
        SqlDataAdapter da_nv;
        DataView dtv_nv;
        public frmTieuChuan()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=DESKTOP-OF9JLA8\HIEUKHAI;Initial Catalog=QL_HoSoKiemDinh;User ID=sa;Password=1234");
        }

        void Load_DataGridView_TieuChuan()
        {
            dt_nv = new DataTable();
            string sql = "SELECT * from TIEUCHUAN ";
            da_nv = new SqlDataAdapter(sql, conn);
            da_nv.Fill(dt_nv);
            dtv_nv = new DataView(dt_nv);
            dgv_DSTieuchuan.DataSource = dtv_nv;
            

        }

        private void frmTieuChuan_Load(object sender, EventArgs e)
        {
            Load_DataGridView_TieuChuan();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
