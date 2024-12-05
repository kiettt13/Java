namespace DeMoDoAn
{
    partial class frmSuKien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSuKien));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbGio = new System.Windows.Forms.TextBox();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.txbDiaDiem = new System.Windows.Forms.TextBox();
            this.txbMoTa = new System.Windows.Forms.TextBox();
            this.txbTen = new System.Windows.Forms.TextBox();
            this.txbMa = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRS = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvSuKien = new System.Windows.Forms.DataGridView();
            this.MaSk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayTC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioTC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diaDiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuKien)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(118)))), ((int)(((byte)(104)))));
            this.groupBox1.BackgroundImage = global::DeMoDoAn.Properties.Resources.BGEven;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.txbGio);
            this.groupBox1.Controls.Add(this.dtpNgay);
            this.groupBox1.Controls.Add(this.txbDiaDiem);
            this.groupBox1.Controls.Add(this.txbMoTa);
            this.groupBox1.Controls.Add(this.txbTen);
            this.groupBox1.Controls.Add(this.txbMa);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(851, 331);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sự kiện";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txbGio
            // 
            this.txbGio.Location = new System.Drawing.Point(557, 109);
            this.txbGio.Name = "txbGio";
            this.txbGio.Size = new System.Drawing.Size(207, 26);
            this.txbGio.TabIndex = 4;
            // 
            // dtpNgay
            // 
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgay.Location = new System.Drawing.Point(557, 57);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(207, 26);
            this.dtpNgay.TabIndex = 3;
            // 
            // txbDiaDiem
            // 
            this.txbDiaDiem.Location = new System.Drawing.Point(164, 211);
            this.txbDiaDiem.Multiline = true;
            this.txbDiaDiem.Name = "txbDiaDiem";
            this.txbDiaDiem.Size = new System.Drawing.Size(600, 26);
            this.txbDiaDiem.TabIndex = 6;
            // 
            // txbMoTa
            // 
            this.txbMoTa.Location = new System.Drawing.Point(164, 162);
            this.txbMoTa.Multiline = true;
            this.txbMoTa.Name = "txbMoTa";
            this.txbMoTa.Size = new System.Drawing.Size(600, 26);
            this.txbMoTa.TabIndex = 5;
            // 
            // txbTen
            // 
            this.txbTen.Location = new System.Drawing.Point(164, 109);
            this.txbTen.Name = "txbTen";
            this.txbTen.Size = new System.Drawing.Size(222, 26);
            this.txbTen.TabIndex = 2;
            // 
            // txbMa
            // 
            this.txbMa.Location = new System.Drawing.Point(164, 57);
            this.txbMa.Name = "txbMa";
            this.txbMa.Size = new System.Drawing.Size(222, 26);
            this.txbMa.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Địa điểm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(439, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Giờ tổ chức";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(439, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngày tổ chức";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mô tả";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên sự kiện";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã sự kiện";
            // 
            // btnRS
            // 
            this.btnRS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRS.Image = global::DeMoDoAn.Properties.Resources.rs__1_;
            this.btnRS.Location = new System.Drawing.Point(910, 212);
            this.btnRS.Name = "btnRS";
            this.btnRS.Size = new System.Drawing.Size(102, 48);
            this.btnRS.TabIndex = 11;
            this.btnRS.Text = "Reset";
            this.btnRS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRS.UseVisualStyleBackColor = true;
            this.btnRS.Click += new System.EventHandler(this.btnRS_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Image = global::DeMoDoAn.Properties.Resources.ex__1_;
            this.btnThoat.Location = new System.Drawing.Point(910, 266);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(102, 48);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Image = global::DeMoDoAn.Properties.Resources.Tay__1_;
            this.btnXoa.Location = new System.Drawing.Point(910, 158);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(102, 48);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Image = global::DeMoDoAn.Properties.Resources._16941__1_;
            this.btnSua.Location = new System.Drawing.Point(910, 104);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(102, 48);
            this.btnSua.TabIndex = 8;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Image = global::DeMoDoAn.Properties.Resources.add__1_;
            this.btnThem.Location = new System.Drawing.Point(910, 50);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(102, 48);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvSuKien
            // 
            this.dgvSuKien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSuKien.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSuKien.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvSuKien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSuKien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSk,
            this.TenSK,
            this.ngayTC,
            this.gioTC,
            this.moTa,
            this.diaDiem});
            this.dgvSuKien.Location = new System.Drawing.Point(16, 367);
            this.dgvSuKien.Name = "dgvSuKien";
            this.dgvSuKien.RowHeadersWidth = 51;
            this.dgvSuKien.RowTemplate.Height = 24;
            this.dgvSuKien.Size = new System.Drawing.Size(1043, 308);
            this.dgvSuKien.TabIndex = 1;
            this.dgvSuKien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSuKien_CellClick);
            // 
            // MaSk
            // 
            this.MaSk.DataPropertyName = "idSuKien";
            this.MaSk.HeaderText = "Mã sự kiện";
            this.MaSk.MinimumWidth = 6;
            this.MaSk.Name = "MaSk";
            this.MaSk.Width = 110;
            // 
            // TenSK
            // 
            this.TenSK.DataPropertyName = "tenSuKien";
            this.TenSK.HeaderText = "Tên sự kiện";
            this.TenSK.MinimumWidth = 6;
            this.TenSK.Name = "TenSK";
            this.TenSK.Width = 114;
            // 
            // ngayTC
            // 
            this.ngayTC.DataPropertyName = "ngayToChuc";
            this.ngayTC.HeaderText = "Ngày tổ chức";
            this.ngayTC.MinimumWidth = 6;
            this.ngayTC.Name = "ngayTC";
            this.ngayTC.Width = 125;
            // 
            // gioTC
            // 
            this.gioTC.DataPropertyName = "gioToChuc";
            this.gioTC.HeaderText = "Giờ tổ chức";
            this.gioTC.MinimumWidth = 6;
            this.gioTC.Name = "gioTC";
            this.gioTC.Width = 114;
            // 
            // moTa
            // 
            this.moTa.DataPropertyName = "moTaSuKien";
            this.moTa.HeaderText = "Mô tả";
            this.moTa.MinimumWidth = 6;
            this.moTa.Name = "moTa";
            this.moTa.Width = 62;
            // 
            // diaDiem
            // 
            this.diaDiem.DataPropertyName = "diaDiemToChuc";
            this.diaDiem.HeaderText = "Địa điểm tổ chức";
            this.diaDiem.MinimumWidth = 6;
            this.diaDiem.Name = "diaDiem";
            this.diaDiem.Width = 118;
            // 
            // frmSuKien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DeMoDoAn.Properties.Resources.BGEven;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1073, 691);
            this.Controls.Add(this.btnRS);
            this.Controls.Add(this.dgvSuKien);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSuKien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý sự kiện";
            this.Load += new System.EventHandler(this.frmSuKien_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuKien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txbDiaDiem;
        private System.Windows.Forms.TextBox txbMoTa;
        private System.Windows.Forms.TextBox txbTen;
        private System.Windows.Forms.TextBox txbMa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.DataGridView dgvSuKien;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.TextBox txbGio;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSk;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSK;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayTC;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioTC;
        private System.Windows.Forms.DataGridViewTextBoxColumn moTa;
        private System.Windows.Forms.DataGridViewTextBoxColumn diaDiem;
        private System.Windows.Forms.Button btnRS;
    }
}