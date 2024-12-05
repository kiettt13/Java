namespace DeMoDoAn
{
    partial class frmCSVC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCSVC));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpNgayBT = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayMua = new System.Windows.Forms.DateTimePicker();
            this.txbTT = new System.Windows.Forms.TextBox();
            this.txbTen = new System.Windows.Forms.TextBox();
            this.txbMa = new System.Windows.Forms.TextBox();
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
            this.dgvCSVC = new System.Windows.Forms.DataGridView();
            this.idThietBi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenThietBi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tinhTrangThietBi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayMua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayBaoTri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCSVC)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::DeMoDoAn.Properties.Resources.BgCSVC3;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.dtpNgayBT);
            this.groupBox1.Controls.Add(this.dtpNgayMua);
            this.groupBox1.Controls.Add(this.txbTT);
            this.groupBox1.Controls.Add(this.txbTen);
            this.groupBox1.Controls.Add(this.txbMa);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(870, 309);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin thiết bị";
            // 
            // dtpNgayBT
            // 
            this.dtpNgayBT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayBT.Location = new System.Drawing.Point(589, 110);
            this.dtpNgayBT.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNgayBT.Name = "dtpNgayBT";
            this.dtpNgayBT.Size = new System.Drawing.Size(249, 22);
            this.dtpNgayBT.TabIndex = 9;
            // 
            // dtpNgayMua
            // 
            this.dtpNgayMua.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayMua.Location = new System.Drawing.Point(589, 34);
            this.dtpNgayMua.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNgayMua.Name = "dtpNgayMua";
            this.dtpNgayMua.Size = new System.Drawing.Size(249, 22);
            this.dtpNgayMua.TabIndex = 8;
            // 
            // txbTT
            // 
            this.txbTT.Location = new System.Drawing.Point(148, 181);
            this.txbTT.Margin = new System.Windows.Forms.Padding(4);
            this.txbTT.Multiline = true;
            this.txbTT.Name = "txbTT";
            this.txbTT.Size = new System.Drawing.Size(690, 26);
            this.txbTT.TabIndex = 7;
            // 
            // txbTen
            // 
            this.txbTen.Location = new System.Drawing.Point(148, 110);
            this.txbTen.Margin = new System.Windows.Forms.Padding(4);
            this.txbTen.Name = "txbTen";
            this.txbTen.Size = new System.Drawing.Size(242, 22);
            this.txbTen.TabIndex = 6;
            // 
            // txbMa
            // 
            this.txbMa.Location = new System.Drawing.Point(148, 35);
            this.txbMa.Margin = new System.Windows.Forms.Padding(4);
            this.txbMa.Name = "txbMa";
            this.txbMa.Size = new System.Drawing.Size(242, 22);
            this.txbMa.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(79)))), ((int)(((byte)(35)))));
            this.label5.Location = new System.Drawing.Point(449, 116);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày bảo trì";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(79)))), ((int)(((byte)(35)))));
            this.label4.Location = new System.Drawing.Point(449, 41);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngày mua";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(79)))), ((int)(((byte)(35)))));
            this.label3.Location = new System.Drawing.Point(29, 189);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tình trạng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(79)))), ((int)(((byte)(35)))));
            this.label2.Location = new System.Drawing.Point(29, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên thiết bị";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(79)))), ((int)(((byte)(35)))));
            this.label1.Location = new System.Drawing.Point(29, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã thiết bị";
            // 
            // btnRS
            // 
            this.btnRS.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnRS.Image = global::DeMoDoAn.Properties.Resources.rs__1_;
            this.btnRS.Location = new System.Drawing.Point(931, 201);
            this.btnRS.Margin = new System.Windows.Forms.Padding(4);
            this.btnRS.Name = "btnRS";
            this.btnRS.Size = new System.Drawing.Size(109, 52);
            this.btnRS.TabIndex = 14;
            this.btnRS.Text = "Reset";
            this.btnRS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRS.UseVisualStyleBackColor = true;
            this.btnRS.Click += new System.EventHandler(this.btnRS_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnThoat.Image = global::DeMoDoAn.Properties.Resources.ex__1_;
            this.btnThoat.Location = new System.Drawing.Point(931, 261);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(109, 52);
            this.btnThoat.TabIndex = 13;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnXoa.Image = global::DeMoDoAn.Properties.Resources.Tay__1_;
            this.btnXoa.Location = new System.Drawing.Point(931, 141);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(109, 52);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnSua.Image = global::DeMoDoAn.Properties.Resources._16941__1_;
            this.btnSua.Location = new System.Drawing.Point(931, 81);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(109, 52);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnThem.Image = global::DeMoDoAn.Properties.Resources.add__1_;
            this.btnThem.Location = new System.Drawing.Point(931, 21);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(109, 52);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvCSVC
            // 
            this.dgvCSVC.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCSVC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCSVC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idThietBi,
            this.tenThietBi,
            this.tinhTrangThietBi,
            this.ngayMua,
            this.ngayBaoTri});
            this.dgvCSVC.Location = new System.Drawing.Point(15, 332);
            this.dgvCSVC.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCSVC.Name = "dgvCSVC";
            this.dgvCSVC.RowHeadersWidth = 51;
            this.dgvCSVC.RowTemplate.Height = 24;
            this.dgvCSVC.Size = new System.Drawing.Size(1082, 299);
            this.dgvCSVC.TabIndex = 1;
            this.dgvCSVC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCSVC_CellClick);
            // 
            // idThietBi
            // 
            this.idThietBi.DataPropertyName = "idThietBi";
            this.idThietBi.HeaderText = "Mã thiết bị";
            this.idThietBi.MinimumWidth = 6;
            this.idThietBi.Name = "idThietBi";
            this.idThietBi.Width = 125;
            // 
            // tenThietBi
            // 
            this.tenThietBi.DataPropertyName = "tenThietBi";
            this.tenThietBi.HeaderText = "Tên thiết bị";
            this.tenThietBi.MinimumWidth = 6;
            this.tenThietBi.Name = "tenThietBi";
            this.tenThietBi.Width = 125;
            // 
            // tinhTrangThietBi
            // 
            this.tinhTrangThietBi.DataPropertyName = "tinhTrangThietBi";
            this.tinhTrangThietBi.HeaderText = "Tình trạng";
            this.tinhTrangThietBi.MinimumWidth = 6;
            this.tinhTrangThietBi.Name = "tinhTrangThietBi";
            this.tinhTrangThietBi.Width = 125;
            // 
            // ngayMua
            // 
            this.ngayMua.DataPropertyName = "ngayMua";
            this.ngayMua.HeaderText = "Ngày mua";
            this.ngayMua.MinimumWidth = 6;
            this.ngayMua.Name = "ngayMua";
            this.ngayMua.Width = 125;
            // 
            // ngayBaoTri
            // 
            this.ngayBaoTri.DataPropertyName = "ngayBaoTri";
            this.ngayBaoTri.HeaderText = "Ngày bảo trì";
            this.ngayBaoTri.MinimumWidth = 6;
            this.ngayBaoTri.Name = "ngayBaoTri";
            this.ngayBaoTri.Width = 150;
            // 
            // frmCSVC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DeMoDoAn.Properties.Resources.BgCSVC3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1112, 652);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnRS);
            this.Controls.Add(this.dgvCSVC);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCSVC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Cơ sở vật chất";
            this.Load += new System.EventHandler(this.frmCSVC_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCSVC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCSVC;
        private System.Windows.Forms.DateTimePicker dtpNgayBT;
        private System.Windows.Forms.DateTimePicker dtpNgayMua;
        private System.Windows.Forms.TextBox txbTT;
        private System.Windows.Forms.TextBox txbTen;
        private System.Windows.Forms.TextBox txbMa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnRS;
        private System.Windows.Forms.DataGridViewTextBoxColumn idThietBi;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenThietBi;
        private System.Windows.Forms.DataGridViewTextBoxColumn tinhTrangThietBi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayMua;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayBaoTri;
    }
}