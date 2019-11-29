using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace QL_HSKD
{
    public partial class frmTieuChuan : Form
    {
<<<<<<< HEAD
        SqlConnection conn;
        DataTable dt;
        SqlDataAdapter da;
        DataView dtv;
=======
>>>>>>> 83961e4ffdd039407d6d3d418fd84254422bba1e
        public frmTieuChuan()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            dt = new DataTable();
            string sql = "SELECT * from TIEUCHUAN order by MATIEUCHUAN ASC ";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            dtv = new DataView(dt);
            dgv_DSTieuchuan.DataSource = dtv;
            
=======
>>>>>>> 83961e4ffdd039407d6d3d418fd84254422bba1e

        }
        private void dt_Click_1()
        {
            int index = dgv_DSTieuchuan.CurrentRow.Index;

            txtMaTieuChuan.Text = dgv_DSTieuchuan.Rows[index].Cells[0].Value.ToString();
            txtTenTieuChuan.Text = dgv_DSTieuchuan.Rows[index].Cells[1].Value.ToString();
            txtTieuDeTieuChuan.Text = dgv_DSTieuchuan.Rows[index].Cells[2].Value.ToString();
            

<<<<<<< HEAD
        }
        private void frmTieuChuan_Load(object sender, EventArgs e)
        {
            Load_DataGridView_TieuChuan();
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
=======
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+@"\QLHS";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);       
                }
               
                 String TC = path + @"\"+txtTTC.Text;
                 if (Directory.Exists(TC))
                  {  
                     MessageBox.Show("Thư mục "+txtTTC.Text+" này đã tồn tại");
                     txtTTC.Text = "";
                  }
                  else
                   {
                     Directory.CreateDirectory(Path.Combine(TC));
                     MessageBox.Show("Tạo thư mục "+txtTTC.Text+" thành công");
                   }
                
            }
            catch
            {
                MessageBox.Show("lỗi");
            }
>>>>>>> 83961e4ffdd039407d6d3d418fd84254422bba1e
        }

        private void dgv_DSTieuchuan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dt_Click_1();
        }
    }
}
