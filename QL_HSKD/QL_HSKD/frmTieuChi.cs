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
    public partial class frmTieuChi : Form
    {
        SqlConnection conn;
        DataTable dt;
        SqlDataAdapter da;
        DataView dtv;
        public frmTieuChi()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=DESKTOP-OF9JLA8\HIEUKHAI;Initial Catalog=QL_HoSoKiemDinh;User ID=sa;Password=1234");
        }
        void Load_DataGridView_TieuChi()
        {
            dt = new DataTable();
            string sql = "SELECT * from TIEUCHI where MATIEUCHUAN ='"+cobMaTieuChuan.Text+"' order by MATIEUCHUAN ASC ";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            dtv = new DataView(dt);
            dgv_DSTieuChi.DataSource = dtv;

        }
        private void dt_Click_1()
        {
            int index = dgv_DSTieuChi.CurrentRow.Index;

            cobMaTieuChuan.Text = dgv_DSTieuChi.Rows[index].Cells[1].Value.ToString();
            txtMaTC.Text = dgv_DSTieuChi.Rows[index].Cells[0].Value.ToString();
            txtTenTC.Text = dgv_DSTieuChi.Rows[index].Cells[2].Value.ToString();
            txtNoiDungTC.Text = dgv_DSTieuChi.Rows[index].Cells[3].Value.ToString();


        }
        public void LoadComboboxMaTieuChuan()
        {
            dt = new DataTable();
            string query = "SELECT distinct MATIEUCHUAN FROM TIEUCHUAN ";
            da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            dtv = new DataView(dt);
            cobMaTieuChuan.DataSource = dtv;
            cobMaTieuChuan.DisplayMember = "MATIEUCHUAN";
            // cb.ValueMember = "masach";
            cobMaTieuChuan.SelectedIndex = -1;

        }


        private void frmTieuChi_Load(object sender, EventArgs e)
        {
            
            LoadComboboxMaTieuChuan();
        }

        private void cobMaTieuChuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_DataGridView_TieuChi();
        }

        private void dgv_DSTieuChi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dt_Click_1();
        }
    }
}
