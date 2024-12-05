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

namespace DeMoDoAn
{
    public partial class frmAdminDN : Form
    {
        string chuoiKN = @"Data Source = . ; Database = QLTV; Integrated Security =SSPI";
        public frmAdminDN()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool AuthenticateUser(string username, string password)
        {
         
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            try
            {
                ketNoi.Open(); // Mở kết nối
                string query = "SELECT adPass FROM admin WHERE username = @username";
                SqlCommand cmd = new SqlCommand(query, ketNoi);
                cmd.Parameters.AddWithValue("@username", username);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedPassword = reader["adPass"].ToString();
                        return storedPassword == password;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
                return false;
            }
            finally
            {
                ketNoi.Close(); // Đóng kết nối
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txbTaiKhoan.Text;
            string password = txbMatKhau.Text;
            if (AuthenticateUser(username, password))
            {
                MessageBox.Show("Đăng nhập thành công!");
                txbMatKhau.Clear();

                frmQLAdmin ql = new frmQLAdmin();
                this.Hide();
                ql.ShowDialog();
                
            }
            else if (username == "" || password == "")
            {
                MessageBox.Show("Tên đăng nhập hoặc tài khoản không được bỏ trống!!");
                txbMatKhau.Clear();
                txbTaiKhoan.Clear();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.");
                txbMatKhau.Clear();
                txbTaiKhoan.Clear();
            }
        }
    }
}
