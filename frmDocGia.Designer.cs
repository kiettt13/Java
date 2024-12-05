namespace DeMoDoAn
{
    partial class frmDocGia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocGia));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbEmail = new System.Windows.Forms.TextBox();
            this.txbSDT = new System.Windows.Forms.TextBox();
            this.txbTenDG = new System.Windows.Forms.TextBox();
            this.txbMaDocGia = new System.Windows.Forms.TextBox();
            this.txbDiaChi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRS = new System.Windows.Forms.Button();
            this.btnThoatSach = new System.Windows.Forms.Button();
            this.btnXoaSach = new System.Windows.Forms.Button();
            this.btnSuaSach = new System.Windows.Forms.Button();
            this.btnThemSach = new System.Windows.Forms.Button();
            this.dgvDocGia = new System.Windows.Forms.DataGridView();
            this.idDocGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenDocGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdtDocGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDocGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGia)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(255)))), ((int)(((byte)(231)))));
            this.groupBox1.BackgroundImage = global::DeMoDoAn.Properties.Resources.BGDocGia;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.txbEmail);
            this.groupBox1.Controls.Add(this.txbSDT);
            this.groupBox1.Controls.Add(this.txbTenDG);
            this.groupBox1.Controls.Add(this.txbMaDocGia);
            this.groupBox1.Controls.Add(this.txbDiaChi);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(17, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(910, 298);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin độc giả";
            // 
            // txbEmail
            // 
            this.txbEmail.Location = new System.Drawing.Point(587, 123);
            this.txbEmail.Name = "txbEmail";
            this.txbEmail.Size = new System.Drawing.Size(255, 26);
            this.txbEmail.TabIndex = 5;
            this.txbEmail.TextChanged += new System.EventHandler(this.txbEmail_TextChanged);
            // 
            // txbSDT
            // 
            this.txbSDT.Location = new System.Drawing.Point(587, 68);
            this.txbSDT.MaxLength = 11;
            this.txbSDT.Name = "txbSDT";
            this.txbSDT.Size = new System.Drawing.Size(255, 26);
            this.txbSDT.TabIndex = 4;
            this.txbSDT.TextChanged += new System.EventHandler(this.txbSDT_TextChanged);
            this.txbSDT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbSDT_KeyPress);
            // 
            // txbTenDG
            // 
            this.txbTenDG.Location = new System.Drawing.Point(131, 123);
            this.txbTenDG.Multiline = true;
            this.txbTenDG.Name = "txbTenDG";
            this.txbTenDG.Size = new System.Drawing.Size(261, 26);
            this.txbTenDG.TabIndex = 2;
            // 
            // txbMaDocGia
            // 
            this.txbMaDocGia.Location = new System.Drawing.Point(131, 63);
            this.txbMaDocGia.Multiline = true;
            this.txbMaDocGia.Name = "txbMaDocGia";
            this.txbMaDocGia.Size = new System.Drawing.Size(261, 26);
            this.txbMaDocGia.TabIndex = 1;
            // 
            // txbDiaChi
            // 
            this.txbDiaChi.Location = new System.Drawing.Point(131, 182);
            this.txbDiaChi.Multiline = true;
            this.txbDiaChi.Name = "txbDiaChi";
            this.txbDiaChi.Size = new System.Drawing.Size(711, 26);
            this.txbDiaChi.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(453, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(453, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số điện thoại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Địa chỉ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên độc giả";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã độc giả";
            // 
            // btnRS
            // 
            this.btnRS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRS.Image = global::DeMoDoAn.Properties.Resources.rs__1_;
            this.btnRS.Location = new System.Drawing.Point(976, 200);
            this.btnRS.Name = "btnRS";
            this.btnRS.Size = new System.Drawing.Size(100, 51);
            this.btnRS.TabIndex = 16;
            this.btnRS.Text = "Reset";
            this.btnRS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRS.UseVisualStyleBackColor = true;
            this.btnRS.Click += new System.EventHandler(this.btnRS_Click);
            // 
            // btnThoatSach
            // 
            this.btnThoatSach.Image = global::DeMoDoAn.Properties.Resources.ex__1_;
            this.btnThoatSach.Location = new System.Drawing.Point(976, 257);
            this.btnThoatSach.Name = "btnThoatSach";
            this.btnThoatSach.Size = new System.Drawing.Size(100, 51);
            this.btnThoatSach.TabIndex = 10;
            this.btnThoatSach.Text = "Thoát";
            this.btnThoatSach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoatSach.UseVisualStyleBackColor = true;
            this.btnThoatSach.Click += new System.EventHandler(this.btnThoatSach_Click);
            // 
            // btnXoaSach
            // 
            this.btnXoaSach.Image = global::DeMoDoAn.Properties.Resources.Tay__1_;
            this.btnXoaSach.Location = new System.Drawing.Point(976, 141);
            this.btnXoaSach.Name = "btnXoaSach";
            this.btnXoaSach.Size = new System.Drawing.Size(100, 51);
            this.btnXoaSach.TabIndex = 9;
            this.btnXoaSach.Text = "Xóa";
            this.btnXoaSach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoaSach.UseVisualStyleBackColor = true;
            this.btnXoaSach.Click += new System.EventHandler(this.btnXoaSach_Click);
            // 
            // btnSuaSach
            // 
            this.btnSuaSach.Image = global::DeMoDoAn.Properties.Resources._16941__1_;
            this.btnSuaSach.Location = new System.Drawing.Point(976, 82);
            this.btnSuaSach.Name = "btnSuaSach";
            this.btnSuaSach.Size = new System.Drawing.Size(100, 53);
            this.btnSuaSach.TabIndex = 8;
            this.btnSuaSach.Text = "Sửa";
            this.btnSuaSach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSuaSach.UseVisualStyleBackColor = true;
            this.btnSuaSach.Click += new System.EventHandler(this.btnSuaSach_Click);
            // 
            // btnThemSach
            // 
            this.btnThemSach.Image = global::DeMoDoAn.Properties.Resources.add__1_;
            this.btnThemSach.Location = new System.Drawing.Point(976, 23);
            this.btnThemSach.Name = "btnThemSach";
            this.btnThemSach.Size = new System.Drawing.Size(100, 53);
            this.btnThemSach.TabIndex = 7;
            this.btnThemSach.Text = "Thêm";
            this.btnThemSach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThemSach.UseVisualStyleBackColor = true;
            this.btnThemSach.Click += new System.EventHandler(this.btnThemSach_Click);
            // 
            // dgvDocGia
            // 
            this.dgvDocGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDocGia.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDocGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocGia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDocGia,
            this.tenDocGia,
            this.sdtDocGia,
            this.emailDocGia,
            this.diaChi});
            this.dgvDocGia.Location = new System.Drawing.Point(17, 338);
            this.dgvDocGia.Name = "dgvDocGia";
            this.dgvDocGia.RowHeadersWidth = 51;
            this.dgvDocGia.RowTemplate.Height = 24;
            this.dgvDocGia.Size = new System.Drawing.Size(1134, 434);
            this.dgvDocGia.TabIndex = 11;
            this.dgvDocGia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocGia_CellClick);
            // 
            // idDocGia
            // 
            this.idDocGia.DataPropertyName = "idDocGia";
            this.idDocGia.HeaderText = "Mã độc giả";
            this.idDocGia.MinimumWidth = 6;
            this.idDocGia.Name = "idDocGia";
            this.idDocGia.Width = 120;
            // 
            // tenDocGia
            // 
            this.tenDocGia.DataPropertyName = "tenDocGia";
            this.tenDocGia.HeaderText = "Tên độc giả";
            this.tenDocGia.MinimumWidth = 6;
            this.tenDocGia.Name = "tenDocGia";
            this.tenDocGia.Width = 125;
            // 
            // sdtDocGia
            // 
            this.sdtDocGia.DataPropertyName = "sdtDocGia";
            this.sdtDocGia.HeaderText = "Số điện thoại";
            this.sdtDocGia.MinimumWidth = 6;
            this.sdtDocGia.Name = "sdtDocGia";
            this.sdtDocGia.Width = 135;
            // 
            // emailDocGia
            // 
            this.emailDocGia.DataPropertyName = "emailDocGia";
            this.emailDocGia.HeaderText = "Email";
            this.emailDocGia.MinimumWidth = 6;
            this.emailDocGia.Name = "emailDocGia";
            this.emailDocGia.Width = 80;
            // 
            // diaChi
            // 
            this.diaChi.DataPropertyName = "diaChi";
            this.diaChi.HeaderText = "Địa chỉ";
            this.diaChi.MinimumWidth = 6;
            this.diaChi.Name = "diaChi";
            this.diaChi.Width = 90;
            // 
            // frmDocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DeMoDoAn.Properties.Resources.BGDocGia;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1164, 788);
            this.Controls.Add(this.btnRS);
            this.Controls.Add(this.btnThoatSach);
            this.Controls.Add(this.dgvDocGia);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnThemSach);
            this.Controls.Add(this.btnSuaSach);
            this.Controls.Add(this.btnXoaSach);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDocGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý độc giả";
            this.Load += new System.EventHandler(this.frmDocGia_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbEmail;
        private System.Windows.Forms.TextBox txbSDT;
        private System.Windows.Forms.TextBox txbTenDG;
        private System.Windows.Forms.TextBox txbMaDocGia;
        private System.Windows.Forms.TextBox txbDiaChi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThoatSach;
        private System.Windows.Forms.Button btnXoaSach;
        private System.Windows.Forms.Button btnSuaSach;
        private System.Windows.Forms.Button btnThemSach;
        private System.Windows.Forms.DataGridView dgvDocGia;
        private System.Windows.Forms.Button btnRS;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDocGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenDocGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdtDocGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDocGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn diaChi;
    }
}