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
    public partial class frmXemTatCaPMC : Form
    {
        SqlConnection conn;
        DataTable dt;
        SqlDataAdapter da;
        DataView dtv;
        SqlCommand cm;
        public frmXemTatCaPMC()
        {
            InitializeComponent();
        }

        private void frmXemTatCaPMC_Load(object sender, EventArgs e)
        {

        }
        void loadListview()
        {
            lvMC.Clear();
            string qr = "SELECT  MAMC,TENMC FROM MINHCHUNG  ";
            SqlDataAdapter da = new SqlDataAdapter(qr, conn);
            dt = new DataTable();
            da.Fill(dt);
            lvMC.View = View.Details;
            lvMC.Columns.Add("MÃ MINH CHỨNG");
            lvMC.Columns.Add("TEN MINH CHỨNG");
            lvMC.Columns[0].Width = 110;
            lvMC.Columns[1].Width = 200;
            ListViewItem item1 = new ListViewItem();
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                lvMC.Items.Add(row["MAMC"].ToString());
                lvMC.Items[i].SubItems.Add(row["TENMC"].ToString());
                i++;
            }

        }
        void ThemCTMC()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            int sl = lvMC.Items.Count;
            for (int i = 0; i < sl; i++)
            {
                if (lvMC.Items[i].Checked)
                {
                    string s = lvMC.Items[i].SubItems[0].Text;
                    string query = "insert into CTMC  values ('" + s + "','" + txtMaPMC.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
            }

        }
        private DataTable tryvan(string sql, SqlConnection conn)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            return dt;
        }
        void hienThiDauTichListView()
        {
            for (int k = 0; k < lvMC.Items.Count; k++)
            {
                lvMC.Items[k].Checked = false;
            }
            DataTable MaMC = new DataTable();
            MaMC = tryvan("select MAMC from CTMC where MAPHANMINHCHUNG='" + txtMaPMC.Text + "'", conn);
            for (int i = 0; i < MaMC.Rows.Count; i++)
            {
                for (int j = 0; j < lvMC.Items.Count; j++)
                {
                    if (MaMC.Rows[i][0].ToString() == lvMC.Items[j].SubItems[0].Text)
                    {
                        lvMC.Items[j].Checked = true;
                    }
                }
            }
        }
        //void themThuMucPMC()
        //{
        //    try
        //    {
        //        int sl = lvMC.Items.Count;
        //        for (int i = 0; i < sl; i++)
        //        {
        //            if (lvMC.Items[i].Checked)
        //            {
        //                string s = lvMC.Items[i].SubItems[0].Text;
        //                String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\QLHSKD" + @"\" + cbTC.SelectedValue + @"\" + cbTChi.SelectedValue + @"\" + s;
        //                String TC = path + @"\" + txtMaPMC.Text;
        //                Directory.CreateDirectory(Path.Combine(TC));
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Tạo thư mục thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
    }
}
