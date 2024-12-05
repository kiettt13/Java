using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace DeMoDoAn
{
    public partial class frmTaoTK : Form
    {
        string chuoiKN = @"Data Source = . ; Database = QLTV; Integrated Security =SSPI";
        public frmTaoTK()
        {
            InitializeComponent();
        }
        private void btnTao_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbIdNhanVien.Text) || string.IsNullOrEmpty(txbMatKhau.Text) || string.IsNullOrEmpty(txbNhapLai.Text) || string.IsNullOrEmpty(txbIdNhanVien.Text))
            {
                MessageBox.Show("Vui long dien du thong tin", "Canh bao", MessageBoxButtons.OK);
                return;
            }

            SqlConnection ketNoi = new SqlConnection(chuoiKN);

            try
            {
                ketNoi.Open();

                using (SqlCommand kt_id = new SqlCommand("select count (*) from dangNhap where maDangNhap = @maDangNhap", ketNoi))
                {
                    kt_id.Parameters.AddWithValue("@maDangNhap", txbIdNhanVien.Text);
                    int ktra = (int)kt_id.ExecuteScalar();

                    if(ktra > 0)
                    {
                        MessageBox.Show("Ten dang nhap da ton tai");
                        txbMatKhau.Clear();
                        txbNhapLai.Clear();
                        return;
                    }
                }
                if (txbMatKhau.Text == txbNhapLai.Text)
                {
                    using (SqlCommand tao = new SqlCommand("insert into dangNhap (maDangNhap, nvPass) values (@maDangNhap, @nvPass)", ketNoi))
                    {
                        tao.Parameters.AddWithValue("@maDangNhap", txbIdNhanVien.Text);
                        tao.Parameters.AddWithValue("@nvPass", txbMatKhau.Text);

                        int result = tao.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Tao tai khoan thanh cong!!");
                            txbMatKhau.Clear();
                            txbNhapLai.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Tao tai khoan that bai!!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Mat khau khong trung lap");
                    txbMatKhau.Clear();
                    txbNhapLai.Clear();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi" + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txbIdNhanVien.Clear();
            txbMatKhau.Clear();
            txbNhapLai.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            frmXoaTK xoa = new frmXoaTK();
            this.Hide();
            xoa.ShowDialog();

        }
    }
}
