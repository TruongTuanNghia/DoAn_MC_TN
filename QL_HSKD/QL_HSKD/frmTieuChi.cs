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
    public partial class frmTieuChi : Form
    {
        SqlConnection conn;
        DataTable dt;
        SqlDataAdapter da;
        DataView dtv;
        DataSet ds;
        SqlCommand cm;
        public frmTieuChi()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=DESKTOP-6O1SKBD\SQLEXPRESS;Initial Catalog=QL_HoSoKiemDinh;User ID=sa;Password=sa2012");
        }
        void Load_DataGridView_TieuChi()
        {

            dt = new DataTable();
            string sql = "SELECT  MATC ,TENTC,NOIDUNGTC from TIEUCHI where MATIEUCHUAN ='" + cobMaTieuChuan.SelectedValue + "' order by MATIEUCHUAN ASC ";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            dtv = new DataView(dt);
            dgv_DSTieuChi.DataSource = dtv;
        }
        
        public void LoadComboboxMaTieuChuan()
        {          
            dt = new DataTable();           
            string query = "SELECT  MATIEUCHUAN,TENTIEUCHUAN FROM TIEUCHUAN order by MATIEUCHUAN ASC";
            da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            dtv = new DataView(dt);
            cobMaTieuChuan.DataSource = dtv; 
            cobMaTieuChuan.DisplayMember = "TENTIEUCHUAN";
            cobMaTieuChuan.ValueMember = "MATIEUCHUAN";
            cobMaTieuChuan.SelectedValue= "TIEUCHUAN1";
        }


        private void frmTieuChi_Load(object sender, EventArgs e)
        {

            LoadComboboxMaTieuChuan();
        }

        private void cobMaTieuChuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_DataGridView_TieuChi();
        }

       

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            try
            {
                string qr = "select COUNT(MATC) from TIEUCHI where MATC='" + txtMaTC.Text + "'";
                cm = new SqlCommand(qr, conn);
                int dem = (int)cm.ExecuteScalar();
                if (dem > 0)
                {
                    MessageBox.Show("Mã tiêu chí này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                }
                else
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();                    
                        string query = "insert into TIEUCHI  values ('" + txtMaTC.Text + "','" + cobMaTieuChuan.SelectedValue + "' ,N'" + txtTenTC.Text + "',N'" + txtNoiDungTC.Text + "')";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.ExecuteNonQuery();                       
                        Load_DataGridView_TieuChi();
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);                   
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                    String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\QLHSKD"+@"\"+cobMaTieuChuan.SelectedValue;
                    String TC = path + @"\" + txtMaTC.Text;
                    Directory.CreateDirectory(Path.Combine(TC));
                }
            }
            catch
            {
                MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Dispose();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            if (MessageBox.Show("Bạn có chắc chắn muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                try
                {

                    string query = "update TIEUCHI set TENTC = N'" + txtTenTC.Text + "',NOIDUNGTC=N'" + txtNoiDungTC.Text + "' where MATC='" + txtMaTC.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    Load_DataGridView_TieuChi();
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                try {
                    string query = "delete TIEUCHI where MaTC = '" + txtMaTC.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\QLHSKD" + @"\" + cobMaTieuChuan.SelectedValue;
                    String TC = path + @"\" + txtMaTC.Text;
                    Directory.Delete(Path.Combine(TC)); 
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load_DataGridView_TieuChi();
                }
                catch
                {
                    MessageBox.Show("Không thể xóa, Tiêu chí này đang chứa Minh chứng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void dgv_DSTieuChi_Click(object sender, EventArgs e)
        {
            int index = dgv_DSTieuChi.CurrentRow.Index;

            txtMaTC.Text = dgv_DSTieuChi.Rows[index].Cells[0].Value.ToString();
            txtTenTC.Text = dgv_DSTieuChi.Rows[index].Cells[1].Value.ToString();
            txtNoiDungTC.Text = dgv_DSTieuChi.Rows[index].Cells[2].Value.ToString();

        }

        private void dgv_DSTieuChi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string RowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(RowNumber, this.Font);
            if (dgv_DSTieuChi.RowHeadersWidth < (int)(size.Width + 20))
                dgv_DSTieuChi.RowHeadersWidth = (int)(size.Width + 20);
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(RowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }
    }
}
