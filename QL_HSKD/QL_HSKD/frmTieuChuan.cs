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

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow r = dt.NewRow();
                r["MATIEUCHUAN"] = txtMaTieuChuan.Text;
                r["TENTIEUCHUAN"] = txtTenTieuChuan.Text;
                r["TIEUDETIEUCHUAN"] = txtTieuDeTieuChuan.Text;
                dt.Rows.Add(r);
                SqlCommandBuilder cmd_builder = new SqlCommandBuilder(da);
                da.Update(dt);
                Load_DataGridView_TieuChuan();
                MessageBox.Show("Thêm Thành Công");
            }
            catch
            {
                MessageBox.Show("Không thể thực thi");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string s = txtMaTieuChuan.Text.Trim();
                string delete = "delete TIEUCHUAN where MATIEUCHUAN='" + s + "'";

                if (this.dgv_DSTieuchuan.SelectedRows.Count > 0)
                {
                    dgv_DSTieuchuan.Rows.RemoveAt(this.dgv_DSTieuchuan.SelectedRows[0].Index);
                    da = new SqlDataAdapter(delete, conn);
                    da.Fill(dt);
                    dtv = new DataView(dt);
                    dgv_DSTieuchuan.DataSource = dtv;
                }
                MessageBox.Show("Xóa thành công");

            }
            catch
            {
                MessageBox.Show("Wrong! Can not Delete", "Nofitication", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            try
            {
                if(conn.State==ConnectionState.Closed)
                {
                    conn.Open();
                }
                
                string update = "update TIEUCHUAN set TENTIEUCHUAN=N'" + txtTenTieuChuan.Text + "' ,TIEUDETIEUCHUAN=N'" + txtTieuDeTieuChuan.Text + "' where MATIEUCHUAN ='" + txtMaTieuChuan.Text + "'";
                SqlCommand cmd = new SqlCommand(update, conn);
                cmd.ExecuteNonQuery();
                Load_DataGridView_TieuChuan();
                MessageBox.Show("Sửa thành công");
            }
            catch
            {

            }
        }
        
    }
}
