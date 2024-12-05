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
using DeMoDoAn.Htro;

namespace DeMoDoAn
{
    public partial class frmDoiMK : Form
    {
        string chuoiKN = @"Data Source = . ; Database = QLTV; Integrated Security =SSPI";
        public frmDoiMK()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txbNewPass.Clear();
            txbOldPass.Clear();
            txbRePass.Clear();
            txbTDN.Clear();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (txbTDN.Text == "" || txbRePass.Text == "" || txbOldPass.Text == "" || txbNewPass.Text == "")
            {
                MessageBox.Show("Vui long nhap day du thong tin");
                return;
            }

            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            try
            {
                ketNoi.Open();
                if(txbTDN.Text == luuTTDN.Username && txbOldPass.Text == luuTTDN.Password)
                {
                    if(txbNewPass.Text == txbRePass.Text)
                    {
                        using (SqlCommand doi = new SqlCommand("update dangNhap set nvPass = @nvPass where maDangNhap = @maDangNhap", ketNoi))
                        {
                            doi.Parameters.AddWithValue("@maDangNhap", txbTDN.Text);
                            doi.Parameters.AddWithValue("@nvPass", txbNewPass.Text);

                            int ktra = (int)doi.ExecuteNonQuery();
                            if(ktra != 0)
                            {
                                MessageBox.Show("Doi mat khau thanh cong");
                                txbNewPass.Clear();
                                txbOldPass.Clear();
                                txbRePass.Clear();
                                txbTDN.Clear();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mat khau khong giong nhau!!");
                        txbRePass.Clear();
                        txbNewPass.Clear();
                        txbOldPass.Clear();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Ten dang nhap hoac mat khau khong chinh xac");
                    txbTDN.Clear();
                    txbNewPass.Clear();
                    txbOldPass.Clear();
                    txbRePass.Clear();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
