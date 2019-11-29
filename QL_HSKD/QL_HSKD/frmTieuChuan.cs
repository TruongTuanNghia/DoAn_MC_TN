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
        public frmTieuChuan()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

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
        }
    }
}
