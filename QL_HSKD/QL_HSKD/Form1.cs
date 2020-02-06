using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_HSKD
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=DESKTOP-6O1SKBD\SQLEXPRESS;Initial Catalog=QL_HoSoKiemDinh;User ID=sa;Password=sa2012");
        }
        private DataTable tryvan(string sql, SqlConnection conn)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            return dt;
        }

        void hienthiTV()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                DataTable nodeTChuan = new DataTable();
                DataTable nodeTChi = new DataTable();
                nodeTChuan = tryvan("select MATIEUCHUAN,TENTIEUCHUAN from TIEUCHUAN", conn);
                for (int i = 0; i < nodeTChuan.Rows.Count; i++)
                {
                    tv.Nodes.Add(nodeTChuan.Rows[i][1].ToString());
                    tv.Nodes[i].Tag = "1";
                    nodeTChi = tryvan("select MATC from TIEUCHI where MATIEUCHUAN='" + nodeTChuan.Rows[i][0] + "'", conn);
                    for (int j = 0; j < nodeTChi.Rows.Count; j++)
                    {
                        tv.Nodes[i].Nodes.Add(nodeTChi.Rows[j][0].ToString());
                        tv.Nodes[i].Nodes[j].Tag = "2";
                    }
                }
            }
            catch
            {
                MessageBox.Show("Tạo thư mục thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            hienthiTV();
        }
        OpenFileDialog op;
        private void button1_Click(object sender, EventArgs e)
        {
            op = new OpenFileDialog();
            op.Filter = "Word|*.doc;*.docx|Excel|*.xls;*.xlsx|PDF|*.pdf|Text|*.txt|Images (.BMP;.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files(.)| *.* ";
            if(op.ShowDialog()==DialogResult.OK)
            {
                StreamReader r = new StreamReader(op.FileName);
              //  txtND.Text = r.ReadToEnd();
               
                r.Close();
            }
        }
    }
}
