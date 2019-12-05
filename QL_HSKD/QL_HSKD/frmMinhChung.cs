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
using System.Data;
using System.IO;

namespace QL_HSKD
{
    public partial class frmMinhChung : Form
    {
        SqlConnection conn;
        DataTable dt;
        SqlDataAdapter da;
        DataView dtv;
        SqlCommand cm;
        public frmMinhChung()
        {
            InitializeComponent();
            try 
            { 
                conn = new SqlConnection(@"Data Source=DESKTOP-6O1SKBD\SQLEXPRESS;Initial Catalog=QL_HoSoKiemDinh;User ID=sa;Password=sa2012");
            }
            catch
            {
                MessageBox.Show("Kết nối thất bại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public void LoadComboboxMaTieuChuan()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            try { 
            dt = new DataTable();
            string query = "SELECT  MATIEUCHUAN,TENTIEUCHUAN FROM TIEUCHUAN order by MATIEUCHUAN ASC";
            da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            dtv = new DataView(dt);
            cbTC.DataSource = dtv;
            cbTC.DisplayMember = "TENTIEUCHUAN";
            cbTC.ValueMember = "MATIEUCHUAN";
                cbTC.SelectedValue = "TIEUCHUAN1";
            }
            catch
            {
                MessageBox.Show("Load tiêu chuẩn thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadComboboxMaTieuChi()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            try { 
                dt = new DataTable();
                string query = "SELECT  MATC,TENTC FROM TIEUCHI where MATIEUCHUAN ='" + cbTC.SelectedValue + "' order by MATC ASC";
                da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
                dtv = new DataView(dt);
                cbTChi.DataSource = dtv;
                cbTChi.DisplayMember = "TENTC";
                cbTChi.ValueMember = "MATC";
                cbTChi.SelectedIndex = -1;
            }
            catch
            {
                MessageBox.Show("Load tiêu chí thất bại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }       
        private void frmMinhChung_Load(object sender, EventArgs e)
        {
            LoadComboboxMaTieuChuan();
            loadListview();
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
                tv.Nodes.Clear();
                DataTable nodeTChi = new DataTable();
                DataTable nodeMC = new DataTable();
                DataTable nodePMC = new DataTable();
                nodeTChi = tryvan("select MATC,TENTC from TIEUCHI where MATIEUCHUAN='" + cbTC.SelectedValue + "'", conn);
                for (int i = 0; i < nodeTChi.Rows.Count; i++)
                {
                    tv.Nodes.Add(nodeTChi.Rows[i][1].ToString());
                    tv.Nodes[i].Tag = nodeTChi.Rows[i][0].ToString();
                    
                    nodeMC = tryvan("select MAMC,TENMC from MINHCHUNG where MATC='" + nodeTChi.Rows[i][0] + "'", conn);
                    for (int j = 0; j < nodeMC.Rows.Count; j++)
                    {                      
                        tv.Nodes[i].Nodes.Add(nodeMC.Rows[j][1].ToString());
                        tv.Nodes[i].Nodes[j].Tag = nodeMC.Rows[j][0].ToString();                   
                        nodePMC = tryvan("select  c.MAPHANMINHCHUNG,p.TENPHANMINHCHUNG, p.NGUONMINHCHUNG from PHANMINHCHUNG p,CTMC c where c.MAMC='"+ nodeMC.Rows[j][0] + "' and c.MAPHANMINHCHUNG=p.MAPHANMINHCHUNG",conn);
                        for (int k = 0; k < nodePMC.Rows.Count; k++)
                        {
                            tv.Nodes[i].Nodes[j].Nodes.Add(nodePMC.Rows[k][1].ToString());
                            tv.Nodes[i].Nodes[j].Nodes[k].Tag = nodePMC.Rows[k][0].ToString();
                            

                        }
                    }
                }
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch
            {
                MessageBox.Show("Tạo thư mục thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {       
            if(cbTChi.SelectedItem==null)
            {
                MessageBox.Show("Bạn chưa chọn Tiêu chí", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else 
            { 
                if(string.IsNullOrEmpty(txtMMC.Text))
                {
                    MessageBox.Show("Bạn chưa nhập Mã minh chứng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        if (conn.State == ConnectionState.Closed)
                            conn.Open();
                        string qr = "select COUNT(MAMC) from MINHCHUNG where MAMC='" + txtMMC.Text + "'";
                        cm = new SqlCommand(qr, conn);
                        int dem = (int)cm.ExecuteScalar();
                        if (dem > 0)
                        {
                            MessageBox.Show("Mã minh chứng này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (conn.State == ConnectionState.Open)
                                conn.Close();
                        }
                        else
                        {
                            if (conn.State == ConnectionState.Closed)
                                conn.Open();
                            string query = "insert into MINHCHUNG  values ('" + txtMMC.Text + "','" + cbTChi.SelectedValue + "' ,N'" + txtTMC.Text + "')";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.ExecuteNonQuery();
                            hienthiTV();
                            loadListview();
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (conn.State == ConnectionState.Open)
                                conn.Close();
                            String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\QLHSKD" + @"\" + cbTC.SelectedValue + @"\" + cbTChi.SelectedValue;
                            String MC = path + @"\" + txtMMC.Text;
                            Directory.CreateDirectory(Path.Combine(MC));
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Thêm minh chứng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }          
            txtMMC.Clear();
            txtTMC.Clear();
        }

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
           
            try
            {
                    txtMMC.Enabled = false;
                    string nodeID;
                    TreeNode node = this.tv.SelectedNode;
                    nodeID = node.Tag.ToString();
                    DataTable mc = new DataTable();
                    mc = tryvan("select MAMC,TENMC from MINHCHUNG where MAMC='" + nodeID + "'", conn);
                    if (mc != null)
                    {
                        txtMMC.Text = mc.Rows[0][0].ToString().Trim();
                        txtTMC.Text = mc.Rows[0][1].ToString().Trim();
                    }
            }
            catch
            {      
                try
                {
                    //string h = tv.SelectedNode.Tag.ToString();
                    string nodeIDP;
                    TreeNode nodeP = this.tv.SelectedNode;
                    nodeIDP = nodeP.Tag.ToString();
                    DataTable pmc = new DataTable();
                    pmc = tryvan("select MAPHANMINHCHUNG,TENPHANMINHCHUNG,NGUONMINHCHUNG from PHANMINHCHUNG where MAPHANMINHCHUNG='" + nodeIDP + "'", conn);
                    if (pmc != null)
                    {
                        txtMaPMC.Text = pmc.Rows[0][0].ToString().Trim();
                        txtTenPMC.Text = pmc.Rows[0][1].ToString().Trim();
                        txtFMC.Text = pmc.Rows[0][2].ToString().Trim();
                        hienThiDauTichListView();
                    }
                }
                catch
                {

                }
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

                    string query = "update MINHCHUNG set TENMC = N'" + txtTMC.Text + "',MATC='" + cbTChi.SelectedValue + "' where MAMC='" + txtMMC.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    hienthiTV();
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
                try
                {
                    string query = "delete MINHCHUNG where MAMC = '" + txtMMC.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienthiTV();
                    txtMMC.Clear();
                    txtTMC.Clear();
                }            
                catch
                {
                    MessageBox.Show("Không thể xóa, Minh chứng này đang chứa các file minh chứng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Dispose();
            }
        }
        OpenFileDialog op;
        private void btnFile_Click(object sender, EventArgs e)
        {
            op = new OpenFileDialog();
            op.Filter = "Word|*.doc;*.docx|Excel|*.xls;*.xlsx|PDF|*.pdf|Text|*.txt|Images (.BMP;.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files(.)| *.* ";
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtFMC.Text = op.FileName;
               
            }
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
        private void cbTC_SelectedIndexChanged(object sender, EventArgs e)
        {
            tv.Nodes.Clear();
            hienthiTV();
            LoadComboboxMaTieuChi();
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
                    //String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\QLHSKD" + @"\" + cbTC.SelectedValue + @"\" + cbTChi.SelectedValue;
                    //String MC = path + @"\" + txtMMC.Text;
                    //Directory.CreateDirectory(Path.Combine(MC));
                }
            }

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
        bool kiemTraDauTichKhiThemPMC()
        {
            int dem = 0;
            for (int k = 0; k < lvMC.Items.Count; k++)
            {
                if (lvMC.Items[k].Checked == false)
                    dem++;
            }
            if(dem== lvMC.Items.Count)
            {
               
                return false;
            }
            return true;
        }
        void themThuMucPMC()
        {
            try
            {
                int sl = lvMC.Items.Count;
                for (int i = 0; i < sl; i++)
                {
                    if (lvMC.Items[i].Checked)
                    {
                        string s = lvMC.Items[i].SubItems[0].Text;
                        String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\QLHSKD" + @"\" + cbTC.SelectedValue + @"\" + cbTChi.SelectedValue + @"\" + s;
                        String TC = path + @"\" + txtMaPMC.Text;
                        Directory.CreateDirectory(Path.Combine(TC));
                    }
                }
            }
            catch
            {
                MessageBox.Show("Tạo thư mục thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnTPMC_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                string qr = "select COUNT(MAPHANMINHCHUNG) from PHANMINHCHUNG where MAPHANMINHCHUNG='" + txtMaPMC.Text + "'";
                cm = new SqlCommand(qr, conn);
                int dem = (int)cm.ExecuteScalar();
                if (dem > 0)
                {
                    MessageBox.Show("Mã phần minh chứng này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                    txtMaPMC.Clear();
                }
                else
                {
                   
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    if (kiemTraDauTichKhiThemPMC())
                    {
                        string query = "insert into PHANMINHCHUNG  values ('" + txtMaPMC.Text + "','" + txtTenPMC.Text + "' ,N'" + txtFMC.Text + "')";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                        ThemCTMC();
                        hienthiTV();
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (conn.State == ConnectionState.Open)
                            conn.Close();
                        themThuMucPMC();
                        loadListview();
                        txtFMC.Clear();
                        txtMaPMC.Clear();
                        txtTenPMC.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa chọn Minh chứng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Thêm phần minh chứng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtMMC.Clear();
            txtTMC.Clear();
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        private void btnSPMC_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            if (MessageBox.Show("Bạn có chắc chắn muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                try
                {
                    string query = "update PHANMINHCHUNG set TENPHANMINHCHUNG = N'" + txtTenPMC.Text + "',NGUONMINHCHUNG='" + txtFMC.Text+ "' where MAPHANMINHCHUNG='" + txtMaPMC.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    // xóa CTMC                   
                                string dl = "delete CTMC where MAPHANMINHCHUNG = '" + txtMaPMC.Text + "'";
                                SqlCommand cmddl = new SqlCommand(dl, conn);
                                cmddl.ExecuteNonQuery();                                              
                    //them CTMC
                    for (int i = 0; i < lvMC.Items.Count; i++)
                    {
                        if (lvMC.Items[i].Checked)
                        {
                            string s = lvMC.Items[i].SubItems[0].Text;
                            string queryt = "insert into CTMC  values ('" + s + "','" + txtMaPMC.Text + "')";
                            SqlCommand cmdt = new SqlCommand(queryt, conn);
                            cmdt.ExecuteNonQuery();
                        }
                    }

                    hienthiTV();
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFMC.Clear();
                    txtMaPMC.Clear();
                    txtTenPMC.Clear();
                }
                catch
                {
                    MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        private void btnXPMC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                try
                {
                    string qr = "select COUNT(MAPHANMINHCHUNG) from CTMC where MAPHANMINHCHUNG = '" + txtMaPMC.Text + "'";
                    cm = new SqlCommand(qr, conn);
                    int dem = (int)cm.ExecuteScalar();
                    if (dem > 0)
                    {  
                        if(MessageBox.Show("Phần minh chứng này đang thuộc về các minh chứng khác, Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                        {
                            string dl = "delete CTMC where MAPHANMINHCHUNG = '" + txtMaPMC.Text + "'";
                            SqlCommand cmddl = new SqlCommand(dl, conn);
                            cmddl.ExecuteNonQuery();

                            string query = "delete PHANMINHCHUNG where MAPHANMINHCHUNG = '" + txtMaPMC.Text + "'";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            hienthiTV();
                            loadListview();
                            txtMaPMC.Clear();
                            txtTenPMC.Clear();
                            txtFMC.Clear();
                        }
                    }
                    else
                    {
                        string query = "delete PHANMINHCHUNG where MAPHANMINHCHUNG = '" + txtMaPMC.Text + "'";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        hienthiTV();
                        loadListview();
                        txtMaPMC.Clear();
                        txtTenPMC.Clear();
                        txtFMC.Clear();
                    }
                
                }
                catch
                {
                    MessageBox.Show("Không thể xóa, Minh chứng này đang chứa các file minh chứng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
