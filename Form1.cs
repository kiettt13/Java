using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using DeMoDoAn.Htro;

namespace DeMoDoAn
{
    public partial class Form1 : Form
    {
        string chuoiKN = @"Data Source = . ; Database = QLTV; Integrated Security =SSPI";
        public Form1()
        {
            InitializeComponent();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);

            try
            {
                ketNoi.Open();
                bool isAuthenticated = false;

                using (SqlCommand ktr = new SqlCommand("select count(*) from admin where username = @username and adPass = @password", ketNoi))
                {
                    ktr.Parameters.AddWithValue("@username", txbTaiKhoan.Text);
                    ktr.Parameters.AddWithValue("@password", txbMatKhau.Text);
                    int ktra = (int)ktr.ExecuteScalar();
                    if (ktra > 0)
                    {
                        MessageBox.Show("Đăng nhập thành công!");
                        luuTTDN.Username = txbTaiKhoan.Text;
                        luuTTDN.Password = txbMatKhau.Text;
                        txbMatKhau.Clear();
                        lblTB.Hide();
                        frmQLAdmin adQL = new frmQLAdmin();
                        this.Hide();
                        adQL.ShowDialog();
                        isAuthenticated = true;
                    }
                    else if (txbMatKhau.Text == "" && txbTaiKhoan.Text == "")
                    {
                        lblTB.Text = "* Vui lòng nhập đầy đủ thông tin";
                        lblTB.ForeColor = Color.Red;
                    }
                    else
                    {

                    }
                }

                if (!isAuthenticated)
                {

                    using (SqlCommand ktr = new SqlCommand("select count(*) from dangNhap where maDangNhap = @maDangNhap and nvPass = @password", ketNoi))
                    {
                        ktr.Parameters.AddWithValue("@maDangNhap", txbTaiKhoan.Text);
                        ktr.Parameters.AddWithValue("@password", txbMatKhau.Text);
                        int ktra = (int)ktr.ExecuteScalar();
                        if (ktra > 0)
                        {
                            MessageBox.Show("Đăng nhập thành công!");
                            luuTTDN.Username = txbTaiKhoan.Text;
                            luuTTDN.Password = txbMatKhau.Text;
                            txbMatKhau.Clear();
                            lblTB.Hide();
                            frmMain m = new frmMain();
                            this.Hide();
                            m.ShowDialog();
                        }
                        else if (txbMatKhau.Text == "" && txbTaiKhoan.Text == "")
                        {
                            lblTB.Text = "* Vui lòng nhập đầy đủ thông tin";
                            lblTB.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblTB.Text = "* Tên đăng nhập hoặc mật khẩu không chính xác";
                            lblTB.ForeColor = Color.Red;
                            txbMatKhau.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                if (ketNoi.State == System.Data.ConnectionState.Open)
                {
                    ketNoi.Close();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình hay không","Thông báo!" ,MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            frmAdminDN ad = new frmAdminDN();
            this.Hide();
            ad.ShowDialog();
            this.Close();
        }
    }
}
