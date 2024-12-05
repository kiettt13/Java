namespace DeMoDoAn
{
    partial class frmXoaTK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXoaTK));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbTenTK = new System.Windows.Forms.TextBox();
            this.dgvHT = new System.Windows.Forms.DataGridView();
            this.maDangNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nvPass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnTao = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHT)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(208)))), ((int)(((byte)(191)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(460, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "XÓA TÀI KHOẢN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(224)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(101, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên tài khoản";
            // 
            // txbTenTK
            // 
            this.txbTenTK.Location = new System.Drawing.Point(171, 158);
            this.txbTenTK.Multiline = true;
            this.txbTenTK.Name = "txbTenTK";
            this.txbTenTK.Size = new System.Drawing.Size(198, 29);
            this.txbTenTK.TabIndex = 2;
            // 
            // dgvHT
            // 
            this.dgvHT.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvHT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maDangNhap,
            this.nvPass});
            this.dgvHT.Location = new System.Drawing.Point(90, 249);
            this.dgvHT.Name = "dgvHT";
            this.dgvHT.RowHeadersWidth = 51;
            this.dgvHT.RowTemplate.Height = 24;
            this.dgvHT.Size = new System.Drawing.Size(654, 231);
            this.dgvHT.TabIndex = 3;
            this.dgvHT.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHT_CellClick);
            // 
            // maDangNhap
            // 
            this.maDangNhap.DataPropertyName = "maDangNhap";
            this.maDangNhap.HeaderText = "Tên đăng nhập";
            this.maDangNhap.MinimumWidth = 6;
            this.maDangNhap.Name = "maDangNhap";
            this.maDangNhap.Width = 160;
            // 
            // nvPass
            // 
            this.nvPass.DataPropertyName = "nvPass";
            this.nvPass.HeaderText = "Mật khẩu";
            this.nvPass.MinimumWidth = 6;
            this.nvPass.Name = "nvPass";
            this.nvPass.Width = 125;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(393, 179);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(113, 45);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(631, 179);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(113, 45);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTao
            // 
            this.btnTao.Location = new System.Drawing.Point(512, 179);
            this.btnTao.Name = "btnTao";
            this.btnTao.Size = new System.Drawing.Size(113, 45);
            this.btnTao.TabIndex = 6;
            this.btnTao.Text = "Tạo";
            this.btnTao.UseVisualStyleBackColor = true;
            this.btnTao.Click += new System.EventHandler(this.btnTao_Click);
            // 
            // frmXoaTK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DeMoDoAn.Properties.Resources.bgxoaTK;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(823, 553);
            this.Controls.Add(this.btnTao);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.dgvHT);
            this.Controls.Add(this.txbTenTK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmXoaTK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xóa tài khoản";
            this.Load += new System.EventHandler(this.frmXoaTK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbTenTK;
        private System.Windows.Forms.DataGridView dgvHT;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridViewTextBoxColumn maDangNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn nvPass;
        private System.Windows.Forms.Button btnTao;
    }
}