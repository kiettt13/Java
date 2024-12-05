namespace DeMoDoAn
{
    partial class frmSach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSach));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txbSL = new System.Windows.Forms.TextBox();
            this.dtpNamXuatBan = new System.Windows.Forms.DateTimePicker();
            this.txbViTri = new System.Windows.Forms.TextBox();
            this.txbTheLoai = new System.Windows.Forms.TextBox();
            this.txbNXB = new System.Windows.Forms.TextBox();
            this.txbTacGia = new System.Windows.Forms.TextBox();
            this.txbTenSach = new System.Windows.Forms.TextBox();
            this.txbIDSach = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRS = new System.Windows.Forms.Button();
            this.btnThemSach = new System.Windows.Forms.Button();
            this.btnSuaSach = new System.Windows.Forms.Button();
            this.btnXoaSach = new System.Windows.Forms.Button();
            this.btnThoatSach = new System.Windows.Forms.Button();
            this.dgvSach = new System.Windows.Forms.DataGridView();
            this.maSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.theLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viTri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NXB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayXB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(47)))), ((int)(((byte)(27)))));
            this.label1.Location = new System.Drawing.Point(43, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã sách";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::DeMoDoAn.Properties.Resources.BGQLSach;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.btnTim);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txbSL);
            this.groupBox1.Controls.Add(this.dtpNamXuatBan);
            this.groupBox1.Controls.Add(this.txbViTri);
            this.groupBox1.Controls.Add(this.txbTheLoai);
            this.groupBox1.Controls.Add(this.txbNXB);
            this.groupBox1.Controls.Add(this.txbTacGia);
            this.groupBox1.Controls.Add(this.txbTenSach);
            this.groupBox1.Controls.Add(this.txbIDSach);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.MintCream;
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(848, 321);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sách";
            // 
            // btnTim
            // 
            this.btnTim.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTim.BackgroundImage")));
            this.btnTim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTim.Location = new System.Drawing.Point(388, 54);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(36, 36);
            this.btnTim.TabIndex = 18;
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(47)))), ((int)(((byte)(27)))));
            this.label8.Location = new System.Drawing.Point(448, 256);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Số lượng";
            // 
            // txbSL
            // 
            this.txbSL.Location = new System.Drawing.Point(559, 250);
            this.txbSL.Name = "txbSL";
            this.txbSL.Size = new System.Drawing.Size(231, 25);
            this.txbSL.TabIndex = 16;
            this.txbSL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbSL_KeyPress);
            // 
            // dtpNamXuatBan
            // 
            this.dtpNamXuatBan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNamXuatBan.Location = new System.Drawing.Point(559, 191);
            this.dtpNamXuatBan.Name = "dtpNamXuatBan";
            this.dtpNamXuatBan.Size = new System.Drawing.Size(231, 25);
            this.dtpNamXuatBan.TabIndex = 14;
            // 
            // txbViTri
            // 
            this.txbViTri.Location = new System.Drawing.Point(559, 125);
            this.txbViTri.Name = "txbViTri";
            this.txbViTri.Size = new System.Drawing.Size(231, 25);
            this.txbViTri.TabIndex = 12;
            // 
            // txbTheLoai
            // 
            this.txbTheLoai.Location = new System.Drawing.Point(559, 64);
            this.txbTheLoai.Name = "txbTheLoai";
            this.txbTheLoai.Size = new System.Drawing.Size(231, 25);
            this.txbTheLoai.TabIndex = 11;
            // 
            // txbNXB
            // 
            this.txbNXB.Location = new System.Drawing.Point(150, 250);
            this.txbNXB.Multiline = true;
            this.txbNXB.Name = "txbNXB";
            this.txbNXB.Size = new System.Drawing.Size(231, 24);
            this.txbNXB.TabIndex = 10;
            // 
            // txbTacGia
            // 
            this.txbTacGia.Location = new System.Drawing.Point(150, 190);
            this.txbTacGia.Multiline = true;
            this.txbTacGia.Name = "txbTacGia";
            this.txbTacGia.Size = new System.Drawing.Size(231, 24);
            this.txbTacGia.TabIndex = 9;
            // 
            // txbTenSach
            // 
            this.txbTenSach.Location = new System.Drawing.Point(150, 125);
            this.txbTenSach.Multiline = true;
            this.txbTenSach.Name = "txbTenSach";
            this.txbTenSach.Size = new System.Drawing.Size(231, 24);
            this.txbTenSach.TabIndex = 8;
            // 
            // txbIDSach
            // 
            this.txbIDSach.Location = new System.Drawing.Point(150, 64);
            this.txbIDSach.Name = "txbIDSach";
            this.txbIDSach.Size = new System.Drawing.Size(231, 25);
            this.txbIDSach.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(47)))), ((int)(((byte)(27)))));
            this.label7.Location = new System.Drawing.Point(448, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Ngày xuất bản";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(47)))), ((int)(((byte)(27)))));
            this.label6.Location = new System.Drawing.Point(448, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Vị trí";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(47)))), ((int)(((byte)(27)))));
            this.label5.Location = new System.Drawing.Point(43, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Nhà xuất bản";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(47)))), ((int)(((byte)(27)))));
            this.label4.Location = new System.Drawing.Point(448, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Thể loại";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(47)))), ((int)(((byte)(27)))));
            this.label3.Location = new System.Drawing.Point(43, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tác giả";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(47)))), ((int)(((byte)(27)))));
            this.label2.Location = new System.Drawing.Point(43, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên sách";
            // 
            // btnRS
            // 
            this.btnRS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRS.Image = global::DeMoDoAn.Properties.Resources.rs__1_;
            this.btnRS.Location = new System.Drawing.Point(912, 209);
            this.btnRS.Name = "btnRS";
            this.btnRS.Size = new System.Drawing.Size(106, 46);
            this.btnRS.TabIndex = 15;
            this.btnRS.Text = "Reset";
            this.btnRS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRS.UseVisualStyleBackColor = true;
            this.btnRS.Click += new System.EventHandler(this.btnRS_Click);
            // 
            // btnThemSach
            // 
            this.btnThemSach.Image = global::DeMoDoAn.Properties.Resources.add__1_;
            this.btnThemSach.Location = new System.Drawing.Point(912, 54);
            this.btnThemSach.Name = "btnThemSach";
            this.btnThemSach.Size = new System.Drawing.Size(106, 45);
            this.btnThemSach.TabIndex = 3;
            this.btnThemSach.Text = "Thêm";
            this.btnThemSach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThemSach.UseVisualStyleBackColor = true;
            this.btnThemSach.Click += new System.EventHandler(this.btnThemSach_Click);
            // 
            // btnSuaSach
            // 
            this.btnSuaSach.Image = global::DeMoDoAn.Properties.Resources._16941__1_;
            this.btnSuaSach.Location = new System.Drawing.Point(912, 105);
            this.btnSuaSach.Name = "btnSuaSach";
            this.btnSuaSach.Size = new System.Drawing.Size(106, 45);
            this.btnSuaSach.TabIndex = 4;
            this.btnSuaSach.Text = "Sửa";
            this.btnSuaSach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSuaSach.UseVisualStyleBackColor = true;
            this.btnSuaSach.Click += new System.EventHandler(this.btnSuaSach_Click);
            // 
            // btnXoaSach
            // 
            this.btnXoaSach.Image = global::DeMoDoAn.Properties.Resources.Tay__1_;
            this.btnXoaSach.Location = new System.Drawing.Point(912, 157);
            this.btnXoaSach.Name = "btnXoaSach";
            this.btnXoaSach.Size = new System.Drawing.Size(106, 45);
            this.btnXoaSach.TabIndex = 5;
            this.btnXoaSach.Text = "Xóa";
            this.btnXoaSach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoaSach.UseVisualStyleBackColor = true;
            this.btnXoaSach.Click += new System.EventHandler(this.btnXoaSach_Click);
            // 
            // btnThoatSach
            // 
            this.btnThoatSach.Image = global::DeMoDoAn.Properties.Resources.ex__1_;
            this.btnThoatSach.Location = new System.Drawing.Point(912, 261);
            this.btnThoatSach.Name = "btnThoatSach";
            this.btnThoatSach.Size = new System.Drawing.Size(106, 45);
            this.btnThoatSach.TabIndex = 6;
            this.btnThoatSach.Text = "Thoát";
            this.btnThoatSach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoatSach.UseVisualStyleBackColor = true;
            this.btnThoatSach.Click += new System.EventHandler(this.btnThoatSach_Click);
            // 
            // dgvSach
            // 
            this.dgvSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSach.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maSach,
            this.tenS,
            this.TGia,
            this.theLoai,
            this.viTri,
            this.NXB,
            this.ngayXB,
            this.soLuong});
            this.dgvSach.Location = new System.Drawing.Point(14, 342);
            this.dgvSach.Name = "dgvSach";
            this.dgvSach.RowHeadersWidth = 51;
            this.dgvSach.RowTemplate.Height = 24;
            this.dgvSach.Size = new System.Drawing.Size(1046, 339);
            this.dgvSach.TabIndex = 7;
            this.dgvSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSach_CellClick);
            // 
            // maSach
            // 
            this.maSach.DataPropertyName = "maSach";
            this.maSach.HeaderText = "Mã sách";
            this.maSach.MinimumWidth = 6;
            this.maSach.Name = "maSach";
            this.maSach.Width = 98;
            // 
            // tenS
            // 
            this.tenS.DataPropertyName = "tenSach";
            this.tenS.HeaderText = "Tên sách";
            this.tenS.MinimumWidth = 6;
            this.tenS.Name = "tenS";
            this.tenS.Width = 103;
            // 
            // TGia
            // 
            this.TGia.DataPropertyName = "tacGia";
            this.TGia.HeaderText = "Tác giả";
            this.TGia.MinimumWidth = 6;
            this.TGia.Name = "TGia";
            this.TGia.Width = 89;
            // 
            // theLoai
            // 
            this.theLoai.DataPropertyName = "theLoai";
            this.theLoai.HeaderText = "Thể loại";
            this.theLoai.MinimumWidth = 6;
            this.theLoai.Name = "theLoai";
            this.theLoai.Width = 93;
            // 
            // viTri
            // 
            this.viTri.DataPropertyName = "viTriTV";
            this.viTri.HeaderText = "Vị trí";
            this.viTri.MinimumWidth = 6;
            this.viTri.Name = "viTri";
            this.viTri.Width = 69;
            // 
            // NXB
            // 
            this.NXB.DataPropertyName = "namXuatBan";
            this.NXB.HeaderText = "Năm xuất bản";
            this.NXB.MinimumWidth = 6;
            this.NXB.Name = "NXB";
            this.NXB.Width = 136;
            // 
            // ngayXB
            // 
            this.ngayXB.DataPropertyName = "nhaXuatBan";
            this.ngayXB.HeaderText = "Nhà xuất bản";
            this.ngayXB.MinimumWidth = 6;
            this.ngayXB.Name = "ngayXB";
            this.ngayXB.Width = 132;
            // 
            // soLuong
            // 
            this.soLuong.DataPropertyName = "soLuong";
            this.soLuong.HeaderText = "Số lượng";
            this.soLuong.MinimumWidth = 6;
            this.soLuong.Name = "soLuong";
            this.soLuong.Width = 101;
            // 
            // frmSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DeMoDoAn.Properties.Resources.BGQLSach;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1073, 702);
            this.Controls.Add(this.dgvSach);
            this.Controls.Add(this.btnThoatSach);
            this.Controls.Add(this.btnRS);
            this.Controls.Add(this.btnXoaSach);
            this.Controls.Add(this.btnSuaSach);
            this.Controls.Add(this.btnThemSach);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý sách";
            this.Load += new System.EventHandler(this.frmSach_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txbViTri;
        private System.Windows.Forms.TextBox txbTheLoai;
        private System.Windows.Forms.TextBox txbNXB;
        private System.Windows.Forms.TextBox txbTacGia;
        private System.Windows.Forms.TextBox txbTenSach;
        private System.Windows.Forms.TextBox txbIDSach;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpNamXuatBan;
        private System.Windows.Forms.Button btnThemSach;
        private System.Windows.Forms.Button btnSuaSach;
        private System.Windows.Forms.Button btnXoaSach;
        private System.Windows.Forms.Button btnThoatSach;
        private System.Windows.Forms.DataGridView dgvSach;
        private System.Windows.Forms.Button btnRS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbSL;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DataGridViewTextBoxColumn maSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenS;
        private System.Windows.Forms.DataGridViewTextBoxColumn TGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn theLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn viTri;
        private System.Windows.Forms.DataGridViewTextBoxColumn NXB;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayXB;
        private System.Windows.Forms.DataGridViewTextBoxColumn soLuong;
    }
}