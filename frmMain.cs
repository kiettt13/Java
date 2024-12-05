using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeMoDoAn
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 dn = new Form1();
            this.Hide();
            dn.ShowDialog();
            this.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSach f = new frmSach();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void tạoTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaoTK tk = new frmTaoTK();
            this.Hide();
            tk.ShowDialog();
            this.Show();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void adminToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAdminDN ad = new frmAdminDN();
            this.Hide();
            ad.ShowDialog();
            this.Show();
        }

        private void quảnLýĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDocGia dg = new frmDocGia();
            this.Hide();
            dg.ShowDialog();
            this.Show();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien nv = new frmNhanVien();
            this.Hide();
            nv.ShowDialog();
            this.Show();
        }

        private void sựKiệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSuKien sk = new frmSuKien();
            this.Hide();
            sk.ShowDialog();
            this.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void cơSởVậtChấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCSVC csvc = new frmCSVC();
            this.Hide();
            csvc.ShowDialog();
            this.Show();
        }

        private void tìmKiếmSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTKiemSach tkS = new frmTKiemSach();
            this.Hide();
            tkS.ShowDialog();
            this.Show();
        }

        private void tìmKiếmĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTKiemDocGia tkDG = new frmTKiemDocGia();
            this.Hide();
            tkDG.ShowDialog();
            this.Show();
        }

        private void tìmKiếmNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTKiemNhanVien tkNV = new frmTKiemNhanVien();
            this.Hide();
            tkNV.ShowDialog();
            this.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiMK dmk = new frmDoiMK();
            this.Hide();
            dmk.ShowDialog();
            this.Show();
        }

        private void giaoDịchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGiaoDich gd = new frmGiaoDich();
            this.Hide();
            gd.ShowDialog();
            this.Show();
        }

        private void phiếuMươnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuMuon pm = new frmPhieuMuon();
            this.Hide();
            pm.ShowDialog();
            this.Show();
        }

        private void phiếuThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuTra pt = new frmPhieuTra();
            this.Hide();
            pt.ShowDialog();
            this.Show();
        }

        private void thốngKêToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmThongKe tk = new frmThongKe();
            this.Hide();
            tk.ShowDialog();
            this.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            frmAdminDN ad = new frmAdminDN();
            this.Hide();
            ad.ShowDialog();
            this.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmDocGia dg = new frmDocGia();
            this.Hide();
            dg.ShowDialog();
            this.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            frmNhanVien nv = new frmNhanVien();
            this.Hide();
            nv.ShowDialog();
            this.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmSach sach = new frmSach();
            this.Hide();
            sach.ShowDialog();
            this.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            frmPhieuMuon pm =new frmPhieuMuon();
            this.Hide();
            pm.ShowDialog();
            this.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            frmPhieuTra pt = new frmPhieuTra();
            this.Hide();
            pt.ShowDialog();
            this.Show();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            frmThongKe tk = new frmThongKe();
            this.Hide();
            tk.ShowDialog();
            this.Show();
        }
    }
}
