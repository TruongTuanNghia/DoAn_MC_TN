namespace QL_HSKD
{
    partial class frmMinhChung
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMinhChung));
            this.label4 = new System.Windows.Forms.Label();
            this.cbTC = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTChi = new System.Windows.Forms.ComboBox();
            this.txtTenPMC = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTMC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMMC = new System.Windows.Forms.TextBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.tv = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFMC = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnTPMC = new System.Windows.Forms.Button();
            this.btnSPMC = new System.Windows.Forms.Button();
            this.btnXPMC = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.lvMC = new System.Windows.Forms.ListView();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaPMC = new System.Windows.Forms.TextBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 43;
            this.label4.Text = "Tiêu chí";
            // 
            // cbTC
            // 
            this.cbTC.FormattingEnabled = true;
            this.cbTC.Location = new System.Drawing.Point(137, 81);
            this.cbTC.Name = "cbTC";
            this.cbTC.Size = new System.Drawing.Size(128, 21);
            this.cbTC.TabIndex = 60;
            this.cbTC.SelectedIndexChanged += new System.EventHandler(this.cbTC_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 59;
            this.label1.Text = "Tiêu chuẩn";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(352, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(256, 24);
            this.label5.TabIndex = 64;
            this.label5.Text = "DANH MỤC MINH CHỨNG";
            // 
            // cbTChi
            // 
            this.cbTChi.FormattingEnabled = true;
            this.cbTChi.Location = new System.Drawing.Point(137, 114);
            this.cbTChi.Name = "cbTChi";
            this.cbTChi.Size = new System.Drawing.Size(128, 21);
            this.cbTChi.TabIndex = 65;
            // 
            // txtTenPMC
            // 
            this.txtTenPMC.Location = new System.Drawing.Point(654, 219);
            this.txtTenPMC.MaxLength = 10;
            this.txtTenPMC.Multiline = true;
            this.txtTenPMC.Name = "txtTenPMC";
            this.txtTenPMC.Size = new System.Drawing.Size(108, 20);
            this.txtTenPMC.TabIndex = 70;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(513, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 16);
            this.label8.TabIndex = 69;
            this.label8.Text = "Tên phần minh chứng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 16);
            this.label3.TabIndex = 42;
            this.label3.Text = "Tên minh chứng";
            // 
            // txtTMC
            // 
            this.txtTMC.Location = new System.Drawing.Point(110, 46);
            this.txtTMC.MaxLength = 50;
            this.txtTMC.Name = "txtTMC";
            this.txtTMC.Size = new System.Drawing.Size(108, 20);
            this.txtTMC.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 41;
            this.label2.Text = "Mã minh chứng";
            // 
            // txtMMC
            // 
            this.txtMMC.Location = new System.Drawing.Point(110, 19);
            this.txtMMC.MaxLength = 10;
            this.txtMMC.Multiline = true;
            this.txtMMC.Name = "txtMMC";
            this.txtMMC.Size = new System.Drawing.Size(108, 20);
            this.txtMMC.TabIndex = 44;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.Red;
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.Black;
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(86, 365);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(77, 27);
            this.btnSua.TabIndex = 54;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Red;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.Black;
            this.btnXoa.Location = new System.Drawing.Point(171, 365);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(77, 27);
            this.btnXoa.TabIndex = 55;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Red;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.Black;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(0, 364);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(77, 28);
            this.btnThem.TabIndex = 50;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // tv
            // 
            this.tv.BackColor = System.Drawing.SystemColors.MenuBar;
            this.tv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tv.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.tv.LineColor = System.Drawing.Color.DarkOrange;
            this.tv.Location = new System.Drawing.Point(1, 87);
            this.tv.Name = "tv";
            this.tv.Size = new System.Drawing.Size(247, 260);
            this.tv.TabIndex = 56;
            this.tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.tv);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.txtMMC);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTMC);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(4, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 413);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cây thư mục Tiêu chuẩn";
            // 
            // txtFMC
            // 
            this.txtFMC.Enabled = false;
            this.txtFMC.Location = new System.Drawing.Point(579, 245);
            this.txtFMC.MaxLength = 10;
            this.txtFMC.Multiline = true;
            this.txtFMC.Name = "txtFMC";
            this.txtFMC.Size = new System.Drawing.Size(265, 20);
            this.txtFMC.TabIndex = 72;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(463, 245);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 16);
            this.label9.TabIndex = 71;
            this.label9.Text = "File minh chứng";
            // 
            // btnTPMC
            // 
            this.btnTPMC.BackColor = System.Drawing.Color.Red;
            this.btnTPMC.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTPMC.ForeColor = System.Drawing.Color.Black;
            this.btnTPMC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTPMC.Location = new System.Drawing.Point(489, 475);
            this.btnTPMC.Margin = new System.Windows.Forms.Padding(2);
            this.btnTPMC.Name = "btnTPMC";
            this.btnTPMC.Size = new System.Drawing.Size(77, 28);
            this.btnTPMC.TabIndex = 57;
            this.btnTPMC.Text = "Thêm";
            this.btnTPMC.UseVisualStyleBackColor = false;
            this.btnTPMC.Click += new System.EventHandler(this.btnTPMC_Click);
            // 
            // btnSPMC
            // 
            this.btnSPMC.BackColor = System.Drawing.Color.Red;
            this.btnSPMC.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSPMC.ForeColor = System.Drawing.Color.Black;
            this.btnSPMC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSPMC.Location = new System.Drawing.Point(629, 476);
            this.btnSPMC.Margin = new System.Windows.Forms.Padding(2);
            this.btnSPMC.Name = "btnSPMC";
            this.btnSPMC.Size = new System.Drawing.Size(77, 27);
            this.btnSPMC.TabIndex = 57;
            this.btnSPMC.Text = "Sửa";
            this.btnSPMC.UseVisualStyleBackColor = false;
            this.btnSPMC.Click += new System.EventHandler(this.btnSPMC_Click);
            // 
            // btnXPMC
            // 
            this.btnXPMC.BackColor = System.Drawing.Color.Red;
            this.btnXPMC.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXPMC.ForeColor = System.Drawing.Color.Black;
            this.btnXPMC.Location = new System.Drawing.Point(757, 476);
            this.btnXPMC.Margin = new System.Windows.Forms.Padding(2);
            this.btnXPMC.Name = "btnXPMC";
            this.btnXPMC.Size = new System.Drawing.Size(77, 27);
            this.btnXPMC.TabIndex = 57;
            this.btnXPMC.Text = "Xóa";
            this.btnXPMC.UseVisualStyleBackColor = false;
            this.btnXPMC.Click += new System.EventHandler(this.btnXPMC_Click);
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(716, 280);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(75, 23);
            this.btnFile.TabIndex = 73;
            this.btnFile.Text = "Chọn file";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // lvMC
            // 
            this.lvMC.CheckBoxes = true;
            this.lvMC.HideSelection = false;
            this.lvMC.Location = new System.Drawing.Point(579, 320);
            this.lvMC.Name = "lvMC";
            this.lvMC.Size = new System.Drawing.Size(265, 126);
            this.lvMC.TabIndex = 74;
            this.lvMC.UseCompatibleStateImageBehavior = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(518, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 16);
            this.label7.TabIndex = 57;
            this.label7.Text = "Mã phần minh chứng";
            // 
            // txtMaPMC
            // 
            this.txtMaPMC.Location = new System.Drawing.Point(654, 187);
            this.txtMaPMC.MaxLength = 10;
            this.txtMaPMC.Multiline = true;
            this.txtMaPMC.Name = "txtMaPMC";
            this.txtMaPMC.Size = new System.Drawing.Size(108, 20);
            this.txtMaPMC.TabIndex = 58;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(833, 57);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 40);
            this.btnThoat.TabIndex = 53;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmMinhChung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(920, 562);
            this.Controls.Add(this.lvMC);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.btnXPMC);
            this.Controls.Add(this.btnSPMC);
            this.Controls.Add(this.btnTPMC);
            this.Controls.Add(this.txtFMC);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTenPMC);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMaPMC);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbTChi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbTC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Name = "frmMinhChung";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách minh chứng";
            this.Load += new System.EventHandler(this.frmMinhChung_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ComboBox cbTC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTChi;
        private System.Windows.Forms.TextBox txtTenPMC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTMC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMMC;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFMC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnTPMC;
        private System.Windows.Forms.Button btnSPMC;
        private System.Windows.Forms.Button btnXPMC;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.ListView lvMC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaPMC;
    }
}