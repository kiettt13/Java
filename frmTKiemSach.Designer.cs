namespace DeMoDoAn
{
    partial class frmTKiemSach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTKiemSach));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbtnTG = new System.Windows.Forms.RadioButton();
            this.txbShow = new System.Windows.Forms.TextBox();
            this.rdbtnTen = new System.Windows.Forms.RadioButton();
            this.rdbtnTL = new System.Windows.Forms.RadioButton();
            this.txbTen = new System.Windows.Forms.TextBox();
            this.cbbTLoai = new System.Windows.Forms.ComboBox();
            this.dgvTKSach = new System.Windows.Forms.DataGridView();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnRS = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.maSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tacGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.theLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nhaXuatBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namXuatBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viTriTV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKSach)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::DeMoDoAn.Properties.Resources.bg2;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.rdbtnTG);
            this.groupBox1.Controls.Add(this.txbShow);
            this.groupBox1.Controls.Add(this.rdbtnTen);
            this.groupBox1.Controls.Add(this.rdbtnTL);
            this.groupBox1.Controls.Add(this.txbTen);
            this.groupBox1.Controls.Add(this.cbbTLoai);
            this.groupBox1.Location = new System.Drawing.Point(15, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(723, 224);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // rdbtnTG
            // 
            this.rdbtnTG.AutoSize = true;
            this.rdbtnTG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.rdbtnTG.Location = new System.Drawing.Point(97, 160);
            this.rdbtnTG.Name = "rdbtnTG";
            this.rdbtnTG.Size = new System.Drawing.Size(81, 24);
            this.rdbtnTG.TabIndex = 13;
            this.rdbtnTG.TabStop = true;
            this.rdbtnTG.Text = "Tác giả";
            this.rdbtnTG.UseVisualStyleBackColor = false;
            this.rdbtnTG.CheckedChanged += new System.EventHandler(this.rdbtnTG_CheckedChanged);
            // 
            // txbShow
            // 
            this.txbShow.Location = new System.Drawing.Point(233, 156);
            this.txbShow.Name = "txbShow";
            this.txbShow.Size = new System.Drawing.Size(354, 25);
            this.txbShow.TabIndex = 12;
            this.txbShow.TextChanged += new System.EventHandler(this.txbShow_TextChanged);
            // 
            // rdbtnTen
            // 
            this.rdbtnTen.AutoSize = true;
            this.rdbtnTen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(236)))), ((int)(((byte)(231)))));
            this.rdbtnTen.Location = new System.Drawing.Point(97, 96);
            this.rdbtnTen.Name = "rdbtnTen";
            this.rdbtnTen.Size = new System.Drawing.Size(95, 24);
            this.rdbtnTen.TabIndex = 9;
            this.rdbtnTen.TabStop = true;
            this.rdbtnTen.Text = "Tên sách";
            this.rdbtnTen.UseVisualStyleBackColor = false;
            this.rdbtnTen.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rdbtnTL
            // 
            this.rdbtnTL.AutoSize = true;
            this.rdbtnTL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(229)))), ((int)(((byte)(234)))));
            this.rdbtnTL.Location = new System.Drawing.Point(97, 38);
            this.rdbtnTL.Name = "rdbtnTL";
            this.rdbtnTL.Size = new System.Drawing.Size(85, 24);
            this.rdbtnTL.TabIndex = 8;
            this.rdbtnTL.TabStop = true;
            this.rdbtnTL.Text = "Thể loại";
            this.rdbtnTL.UseVisualStyleBackColor = false;
            this.rdbtnTL.CheckedChanged += new System.EventHandler(this.rdbtnTL_CheckedChanged);
            // 
            // txbTen
            // 
            this.txbTen.Location = new System.Drawing.Point(233, 94);
            this.txbTen.Name = "txbTen";
            this.txbTen.Size = new System.Drawing.Size(354, 25);
            this.txbTen.TabIndex = 7;
            // 
            // cbbTLoai
            // 
            this.cbbTLoai.FormattingEnabled = true;
            this.cbbTLoai.Location = new System.Drawing.Point(233, 32);
            this.cbbTLoai.Name = "cbbTLoai";
            this.cbbTLoai.Size = new System.Drawing.Size(354, 28);
            this.cbbTLoai.TabIndex = 6;
            // 
            // dgvTKSach
            // 
            this.dgvTKSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTKSach.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvTKSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTKSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maSach,
            this.tenSach,
            this.tacGia,
            this.theLoai,
            this.nhaXuatBan,
            this.namXuatBan,
            this.viTriTV,
            this.soLuong});
            this.dgvTKSach.Location = new System.Drawing.Point(15, 250);
            this.dgvTKSach.Name = "dgvTKSach";
            this.dgvTKSach.RowHeadersWidth = 51;
            this.dgvTKSach.RowTemplate.Height = 24;
            this.dgvTKSach.Size = new System.Drawing.Size(948, 449);
            this.dgvTKSach.TabIndex = 3;
            this.dgvTKSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTKSach_CellClick);
            // 
            // btnReset
            // 
            this.btnReset.Image = global::DeMoDoAn.Properties.Resources.rs__1_;
            this.btnReset.Location = new System.Drawing.Point(790, 104);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(95, 57);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset";
            this.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnRS
            // 
            this.btnRS.Image = global::DeMoDoAn.Properties.Resources.ex__1_;
            this.btnRS.Location = new System.Drawing.Point(790, 174);
            this.btnRS.Name = "btnRS";
            this.btnRS.Size = new System.Drawing.Size(95, 57);
            this.btnRS.TabIndex = 5;
            this.btnRS.Text = "Thoát";
            this.btnRS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRS.UseVisualStyleBackColor = true;
            this.btnRS.Click += new System.EventHandler(this.btnRS_Click);
            // 
            // btnTim
            // 
            this.btnTim.Image = global::DeMoDoAn.Properties.Resources.tim__1_;
            this.btnTim.Location = new System.Drawing.Point(790, 31);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(95, 63);
            this.btnTim.TabIndex = 4;
            this.btnTim.Text = "Tìm";
            this.btnTim.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // maSach
            // 
            this.maSach.DataPropertyName = "maSach";
            this.maSach.HeaderText = "Mã sách";
            this.maSach.MinimumWidth = 6;
            this.maSach.Name = "maSach";
            this.maSach.Width = 91;
            // 
            // tenSach
            // 
            this.tenSach.DataPropertyName = "tenSach";
            this.tenSach.HeaderText = "Tên sách";
            this.tenSach.MinimumWidth = 6;
            this.tenSach.Name = "tenSach";
            this.tenSach.Width = 95;
            // 
            // tacGia
            // 
            this.tacGia.DataPropertyName = "tacGia";
            this.tacGia.HeaderText = "Tác giả";
            this.tacGia.MinimumWidth = 6;
            this.tacGia.Name = "tacGia";
            this.tacGia.Width = 64;
            // 
            // theLoai
            // 
            this.theLoai.DataPropertyName = "theLoai";
            this.theLoai.HeaderText = "Thể loại";
            this.theLoai.MinimumWidth = 6;
            this.theLoai.Name = "theLoai";
            this.theLoai.Width = 65;
            // 
            // nhaXuatBan
            // 
            this.nhaXuatBan.DataPropertyName = "nhaXuatBan";
            this.nhaXuatBan.HeaderText = "Nhà xuất bản";
            this.nhaXuatBan.MinimumWidth = 6;
            this.nhaXuatBan.Name = "nhaXuatBan";
            this.nhaXuatBan.Width = 121;
            // 
            // namXuatBan
            // 
            this.namXuatBan.DataPropertyName = "namXuatBan";
            this.namXuatBan.HeaderText = "Năm xuất bản";
            this.namXuatBan.MinimumWidth = 6;
            this.namXuatBan.Name = "namXuatBan";
            this.namXuatBan.Width = 101;
            // 
            // viTriTV
            // 
            this.viTriTV.DataPropertyName = "viTriTV";
            this.viTriTV.HeaderText = "Vị trí";
            this.viTriTV.MinimumWidth = 6;
            this.viTriTV.Name = "viTriTV";
            this.viTriTV.Width = 53;
            // 
            // soLuong
            // 
            this.soLuong.DataPropertyName = "soLuong";
            this.soLuong.HeaderText = "Số lượng";
            this.soLuong.MinimumWidth = 6;
            this.soLuong.Name = "soLuong";
            this.soLuong.Width = 93;
            // 
            // frmTKiemSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DeMoDoAn.Properties.Resources.bg2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(976, 713);
            this.Controls.Add(this.dgvTKSach);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnRS);
            this.Controls.Add(this.btnTim);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTKiemSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm Sách";
            this.Load += new System.EventHandler(this.frmTKiemSach_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTKSach;
        private System.Windows.Forms.Button btnRS;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.ComboBox cbbTLoai;
        private System.Windows.Forms.TextBox txbTen;
        private System.Windows.Forms.RadioButton rdbtnTen;
        private System.Windows.Forms.RadioButton rdbtnTL;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txbShow;
        private System.Windows.Forms.RadioButton rdbtnTG;
        private System.Windows.Forms.DataGridViewTextBoxColumn maSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn tacGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn theLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn nhaXuatBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn namXuatBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn viTriTV;
        private System.Windows.Forms.DataGridViewTextBoxColumn soLuong;
    }
}