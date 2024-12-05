namespace DeMoDoAn
{
    partial class frmTKiemNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTKiemNhanVien));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbTen = new System.Windows.Forms.TextBox();
            this.cbbChuVu = new System.Windows.Forms.ComboBox();
            this.rdbtnChuVu = new System.Windows.Forms.RadioButton();
            this.rdbtnTen = new System.Windows.Forms.RadioButton();
            this.dgvKQ = new System.Windows.Forms.DataGridView();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.idNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diaChiNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdtNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.khuVuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKQ)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::DeMoDoAn.Properties.Resources.nenBG;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.txbTen);
            this.groupBox1.Controls.Add(this.cbbChuVu);
            this.groupBox1.Controls.Add(this.rdbtnChuVu);
            this.groupBox1.Controls.Add(this.rdbtnTen);
            this.groupBox1.Location = new System.Drawing.Point(17, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(831, 270);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // txbTen
            // 
            this.txbTen.Location = new System.Drawing.Point(323, 84);
            this.txbTen.Name = "txbTen";
            this.txbTen.Size = new System.Drawing.Size(354, 26);
            this.txbTen.TabIndex = 0;
            // 
            // cbbChuVu
            // 
            this.cbbChuVu.FormattingEnabled = true;
            this.cbbChuVu.Location = new System.Drawing.Point(323, 144);
            this.cbbChuVu.Name = "cbbChuVu";
            this.cbbChuVu.Size = new System.Drawing.Size(354, 28);
            this.cbbChuVu.TabIndex = 1;
            // 
            // rdbtnChuVu
            // 
            this.rdbtnChuVu.AutoSize = true;
            this.rdbtnChuVu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(234)))), ((int)(((byte)(230)))));
            this.rdbtnChuVu.Location = new System.Drawing.Point(106, 151);
            this.rdbtnChuVu.Name = "rdbtnChuVu";
            this.rdbtnChuVu.Size = new System.Drawing.Size(91, 24);
            this.rdbtnChuVu.TabIndex = 1;
            this.rdbtnChuVu.Text = "Chức vụ";
            this.rdbtnChuVu.UseVisualStyleBackColor = false;
            this.rdbtnChuVu.CheckedChanged += new System.EventHandler(this.rdbtnChuVu_CheckedChanged);
            // 
            // rdbtnTen
            // 
            this.rdbtnTen.AutoSize = true;
            this.rdbtnTen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(232)))));
            this.rdbtnTen.Location = new System.Drawing.Point(106, 87);
            this.rdbtnTen.Name = "rdbtnTen";
            this.rdbtnTen.Size = new System.Drawing.Size(134, 24);
            this.rdbtnTen.TabIndex = 0;
            this.rdbtnTen.Text = "Tên nhân viên";
            this.rdbtnTen.UseVisualStyleBackColor = false;
            this.rdbtnTen.CheckedChanged += new System.EventHandler(this.rdbtnTen_CheckedChanged);
            // 
            // dgvKQ
            // 
            this.dgvKQ.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvKQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKQ.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idNhanVien,
            this.tenNhanVien,
            this.chucVu,
            this.diaChiNhanVien,
            this.sdtNhanVien,
            this.emailNhanVien,
            this.khuVuc});
            this.dgvKQ.Location = new System.Drawing.Point(17, 315);
            this.dgvKQ.Name = "dgvKQ";
            this.dgvKQ.RowHeadersWidth = 51;
            this.dgvKQ.RowTemplate.Height = 24;
            this.dgvKQ.Size = new System.Drawing.Size(1031, 372);
            this.dgvKQ.TabIndex = 2;
            // 
            // btnReset
            // 
            this.btnReset.Image = global::DeMoDoAn.Properties.Resources.rs__1_;
            this.btnReset.Location = new System.Drawing.Point(920, 119);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(103, 57);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnTim
            // 
            this.btnTim.Image = global::DeMoDoAn.Properties.Resources.tim__1_;
            this.btnTim.Location = new System.Drawing.Point(920, 48);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(103, 63);
            this.btnTim.TabIndex = 2;
            this.btnTim.Text = "Tìm";
            this.btnTim.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Image = global::DeMoDoAn.Properties.Resources.ex__1_;
            this.btnThoat.Location = new System.Drawing.Point(920, 182);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(103, 57);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnRS_Click);
            // 
            // idNhanVien
            // 
            this.idNhanVien.DataPropertyName = "idNhanVien";
            this.idNhanVien.HeaderText = "Mã nhân viên";
            this.idNhanVien.MinimumWidth = 6;
            this.idNhanVien.Name = "idNhanVien";
            this.idNhanVien.Width = 125;
            // 
            // tenNhanVien
            // 
            this.tenNhanVien.DataPropertyName = "tenNhanVien";
            this.tenNhanVien.HeaderText = "Họ & Tên";
            this.tenNhanVien.MinimumWidth = 6;
            this.tenNhanVien.Name = "tenNhanVien";
            this.tenNhanVien.Width = 125;
            // 
            // chucVu
            // 
            this.chucVu.DataPropertyName = "chucVu";
            this.chucVu.HeaderText = "Chức vụ";
            this.chucVu.MinimumWidth = 6;
            this.chucVu.Name = "chucVu";
            this.chucVu.Width = 125;
            // 
            // diaChiNhanVien
            // 
            this.diaChiNhanVien.DataPropertyName = "diaChiNhanVien";
            this.diaChiNhanVien.HeaderText = "Địa chỉ";
            this.diaChiNhanVien.MinimumWidth = 6;
            this.diaChiNhanVien.Name = "diaChiNhanVien";
            this.diaChiNhanVien.Width = 125;
            // 
            // sdtNhanVien
            // 
            this.sdtNhanVien.DataPropertyName = "sdtNhanVien";
            this.sdtNhanVien.HeaderText = "Số điện thoại";
            this.sdtNhanVien.MinimumWidth = 6;
            this.sdtNhanVien.Name = "sdtNhanVien";
            this.sdtNhanVien.Width = 125;
            // 
            // emailNhanVien
            // 
            this.emailNhanVien.DataPropertyName = "emailNhanVien";
            this.emailNhanVien.HeaderText = "Email";
            this.emailNhanVien.MinimumWidth = 6;
            this.emailNhanVien.Name = "emailNhanVien";
            this.emailNhanVien.Width = 125;
            // 
            // khuVuc
            // 
            this.khuVuc.DataPropertyName = "khuVuc";
            this.khuVuc.HeaderText = "Khu vực";
            this.khuVuc.MinimumWidth = 6;
            this.khuVuc.Name = "khuVuc";
            this.khuVuc.Width = 125;
            // 
            // frmTKiemNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DeMoDoAn.Properties.Resources.nenBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1084, 713);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.dgvKQ);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTKiemNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm nhân viên";
            this.Load += new System.EventHandler(this.frmTKiemNhanVien_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKQ)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvKQ;
        private System.Windows.Forms.TextBox txbTen;
        private System.Windows.Forms.ComboBox cbbChuVu;
        private System.Windows.Forms.RadioButton rdbtnChuVu;
        private System.Windows.Forms.RadioButton rdbtnTen;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridViewTextBoxColumn idNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn chucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn diaChiNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdtNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn khuVuc;
    }
}