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
    public partial class frmQLAdmin : Form
    {
        public frmQLAdmin()
        {
            InitializeComponent();
        }

        private void tạoTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaoTK tk = new frmTaoTK();
            this.Hide();
            tk.ShowDialog();
            this.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void formChínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            this.Hide();
            main.ShowDialog();
            
        }

        private void xóaTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXoaTK xoaTK = new frmXoaTK();
            this.Hide();
            xoaTK.ShowDialog();
            this.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmXoaTK xoa = new frmXoaTK();
            this.Hide();
            xoa.ShowDialog();
            this.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmTaoTK tao = new frmTaoTK();
            this.Hide(); 
            tao.ShowDialog();
            this.Show();
        }

        private void lươngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmLuong l = new frmLuong();
            this.Hide();
            l.ShowDialog();
            this.Show();
        }
    }
}
