namespace DeMoDoAn
{
    partial class frmTKiemDocGia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTKiemDocGia));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbMa = new System.Windows.Forms.TextBox();
            this.rdbtnTen = new System.Windows.Forms.RadioButton();
            this.rdbtnMa = new System.Windows.Forms.RadioButton();
            this.txbTen = new System.Windows.Forms.TextBox();
            this.dgvKQ = new System.Windows.Forms.DataGridView();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.idDocGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenDocGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdtDocGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDocGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKQ)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::DeMoDoAn.Properties.Resources.bbg;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.txbMa);
            this.groupBox1.Controls.Add(this.rdbtnTen);
            this.groupBox1.Controls.Add(this.rdbtnMa);
            this.groupBox1.Controls.Add(this.txbTen);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(796, 270);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // txbMa
            // 
            this.txbMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMa.Location = new System.Drawing.Point(313, 84);
            this.txbMa.Margin = new System.Windows.Forms.Padding(4);
            this.txbMa.Name = "txbMa";
            this.txbMa.Size = new System.Drawing.Size(320, 28);
            this.txbMa.TabIndex = 0;
            // 
            // rdbtnTen
            // 
            this.rdbtnTen.AutoSize = true;
            this.rdbtnTen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(199)))), ((int)(((byte)(222)))));
            this.rdbtnTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnTen.Location = new System.Drawing.Point(121, 175);
            this.rdbtnTen.Margin = new System.Windows.Forms.Padding(4);
            this.rdbtnTen.Name = "rdbtnTen";
            this.rdbtnTen.Size = new System.Drawing.Size(126, 26);
            this.rdbtnTen.TabIndex = 3;
            this.rdbtnTen.TabStop = true;
            this.rdbtnTen.Text = "Tên độc giả";
            this.rdbtnTen.UseVisualStyleBackColor = false;
            this.rdbtnTen.CheckedChanged += new System.EventHandler(this.rdbtnTen_CheckedChanged);
            // 
            // rdbtnMa
            // 
            this.rdbtnMa.AutoSize = true;
            this.rdbtnMa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(174)))), ((int)(((byte)(228)))));
            this.rdbtnMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnMa.Location = new System.Drawing.Point(121, 87);
            this.rdbtnMa.Margin = new System.Windows.Forms.Padding(4);
            this.rdbtnMa.Name = "rdbtnMa";
            this.rdbtnMa.Size = new System.Drawing.Size(118, 26);
            this.rdbtnMa.TabIndex = 2;
            this.rdbtnMa.TabStop = true;
            this.rdbtnMa.Text = "Mã độc giả";
            this.rdbtnMa.UseVisualStyleBackColor = false;
            this.rdbtnMa.CheckedChanged += new System.EventHandler(this.rdbtnMa_CheckedChanged);
            // 
            // txbTen
            // 
            this.txbTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTen.Location = new System.Drawing.Point(313, 172);
            this.txbTen.Margin = new System.Windows.Forms.Padding(4);
            this.txbTen.Name = "txbTen";
            this.txbTen.Size = new System.Drawing.Size(320, 28);
            this.txbTen.TabIndex = 1;
            // 
            // dgvKQ
            // 
            this.dgvKQ.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvKQ.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvKQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKQ.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDocGia,
            this.tenDocGia,
            this.diaChi,
            this.sdtDocGia,
            this.emailDocGia});
            this.dgvKQ.Location = new System.Drawing.Point(14, 305);
            this.dgvKQ.Margin = new System.Windows.Forms.Padding(4);
            this.dgvKQ.Name = "dgvKQ";
            this.dgvKQ.RowHeadersWidth = 51;
            this.dgvKQ.RowTemplate.Height = 24;
            this.dgvKQ.Size = new System.Drawing.Size(1046, 460);
            this.dgvKQ.TabIndex = 2;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Image = global::DeMoDoAn.Properties.Resources.rs__1_;
            this.btnReset.Location = new System.Drawing.Point(865, 124);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(112, 56);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Image = global::DeMoDoAn.Properties.Resources.ex__1_;
            this.btnThoat.Location = new System.Drawing.Point(865, 188);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(112, 56);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnRS_Click);
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Image = global::DeMoDoAn.Properties.Resources.tim__1_;
            this.btnTim.Location = new System.Drawing.Point(865, 60);
            this.btnTim.Margin = new System.Windows.Forms.Padding(4);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(112, 56);
            this.btnTim.TabIndex = 2;
            this.btnTim.Text = "Tìm";
            this.btnTim.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // idDocGia
            // 
            this.idDocGia.DataPropertyName = "idDocGia";
            this.idDocGia.HeaderText = "Mã độc giả";
            this.idDocGia.MinimumWidth = 6;
            this.idDocGia.Name = "idDocGia";
            this.idDocGia.Width = 115;
            // 
            // tenDocGia
            // 
            this.tenDocGia.DataPropertyName = "tenDocGia";
            this.tenDocGia.HeaderText = "Tên độc giả";
            this.tenDocGia.MinimumWidth = 6;
            this.tenDocGia.Name = "tenDocGia";
            this.tenDocGia.Width = 120;
            // 
            // diaChi
            // 
            this.diaChi.DataPropertyName = "diaChi";
            this.diaChi.HeaderText = "Địa chỉ";
            this.diaChi.MinimumWidth = 6;
            this.diaChi.Name = "diaChi";
            this.diaChi.Width = 86;
            // 
            // sdtDocGia
            // 
            this.sdtDocGia.DataPropertyName = "sdtDocGia";
            this.sdtDocGia.HeaderText = "Số điện thoại";
            this.sdtDocGia.MinimumWidth = 6;
            this.sdtDocGia.Name = "sdtDocGia";
            this.sdtDocGia.Width = 131;
            // 
            // emailDocGia
            // 
            this.emailDocGia.DataPropertyName = "emailDocGia";
            this.emailDocGia.HeaderText = "Email";
            this.emailDocGia.MinimumWidth = 6;
            this.emailDocGia.Name = "emailDocGia";
            this.emailDocGia.Width = 77;
            // 
            // frmTKiemDocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DeMoDoAn.Properties.Resources.bbg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1073, 780);
            this.Controls.Add(this.dgvKQ);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTKiemDocGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm Kiếm Độc Giả";
            this.Load += new System.EventHandler(this.frmTKiemDocGia_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKQ)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvKQ;
        private System.Windows.Forms.RadioButton rdbtnTen;
        private System.Windows.Forms.RadioButton rdbtnMa;
        private System.Windows.Forms.TextBox txbTen;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txbMa;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenDocGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn diaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdtDocGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDocGia;
    }
}