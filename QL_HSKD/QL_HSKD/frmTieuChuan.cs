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
        DataTable dt;
        SqlDataAdapter da;
        DataView dtv;
        public frmTieuChuan()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=DESKTOP-OF9JLA8\HIEUKHAI;Initial Catalog=QL_HoSoKiemDinh;User ID=sa;Password=1234");
        }

        void Load_DataGridView_TieuChuan()
        {
            dt = new DataTable();
            string sql = "SELECT * from TIEUCHUAN order by MATIEUCHUAN ASC ";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            dtv = new DataView(dt);
            dgv_DSTieuchuan.DataSource = dtv;
            

        }
        private void dt_Click_1()
        {
            int index = dgv_DSTieuchuan.CurrentRow.Index;

            txtMaTieuChuan.Text = dgv_DSTieuchuan.Rows[index].Cells[0].Value.ToString();
            txtTenTieuChuan.Text = dgv_DSTieuchuan.Rows[index].Cells[1].Value.ToString();
            txtTieuDeTieuChuan.Text = dgv_DSTieuchuan.Rows[index].Cells[2].Value.ToString();
            

        }
        private void frmTieuChuan_Load(object sender, EventArgs e)
        {
            Load_DataGridView_TieuChuan();
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_DSTieuchuan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dt_Click_1();
        }
    }
}
