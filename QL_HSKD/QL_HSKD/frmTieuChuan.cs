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
using System.IO;

namespace QL_HSKD
{
    public partial class frmTieuChuan : Form
    {
        SqlConnection conn;
        DataTable dt;
        SqlDataAdapter da;
        DataView dtv;
        String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\QLHSKD";
        public frmTieuChuan()
        {
            InitializeComponent();
           
            conn = new SqlConnection(@"Data Source=DESKTOP-6O1SKBD\SQLEXPRESS;Initial Catalog=QL_HoSoKiemDinh;User ID=sa;Password=sa2012");
        }

        void Load_DataGridView_TieuChuan()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try 
            {
                dt = new DataTable();
                string sql = "SELECT * from TIEUCHUAN order by MATIEUCHUAN ASC ";
                da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
                dtv = new DataView(dt);
                dgv_DSTieuchuan.DataSource = dtv;
            }
            catch
            {

            }
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

        }       
        private void frmTieuChuan_Load(object sender, EventArgs e)
        {
            Load_DataGridView_TieuChuan();
            
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
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
                
                String TC = path + @"\" + txtMaTieuChuan.Text;
                Directory.CreateDirectory(Path.Combine(TC));
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                try
                {
                    string s = txtMaTieuChuan.Text.Trim();
                    string delete = "delete TIEUCHUAN where MATIEUCHUAN='" + s + "'";
                    SqlCommand cmd = new SqlCommand(delete, conn);
                    cmd.ExecuteNonQuery();
                    Load_DataGridView_TieuChuan();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Không thể xóa, Tiêu chuẩn này đang chứa Tiêu chí", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
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
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private void dgv_DSTieuchuan_Click(object sender, EventArgs e)
        {
            int index = dgv_DSTieuchuan.CurrentRow.Index;

            txtMaTieuChuan.Text = dgv_DSTieuchuan.Rows[index].Cells[0].Value.ToString();
            txtTenTieuChuan.Text = dgv_DSTieuchuan.Rows[index].Cells[1].Value.ToString();
            txtTieuDeTieuChuan.Text = dgv_DSTieuchuan.Rows[index].Cells[2].Value.ToString();

        }

        private void dgv_DSTieuchuan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string RowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(RowNumber, this.Font);
            if (dgv_DSTieuchuan.RowHeadersWidth < (int)(size.Width + 20))
                dgv_DSTieuchuan.RowHeadersWidth = (int)(size.Width + 20);
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(RowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }
    }
}
