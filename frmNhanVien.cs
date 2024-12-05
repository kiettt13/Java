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
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace DeMoDoAn
{
    public partial class frmNhanVien : Form
    {
        string chuoiKN = @"Data Source = .; Database = QLTV ; Integrated Security =SSPI";
        private int maTuDong = 0;
        public frmNhanVien()
        {
            InitializeComponent();
        }
        private void LoadData()
        {

            using (SqlConnection ketNoi = new SqlConnection(chuoiKN))
            {
                try
                {
                    ketNoi.Open();
                    SqlDataAdapter dt = new SqlDataAdapter("Select * from nhanVien", ketNoi);
                    DataTable dtb = new DataTable();
                    dt.Fill(dtb);
                    dgvNhanVien.DataSource = dtb;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Loi data girdview " + ex.Message);
                }
            }
        }
        public static bool IsEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            string strRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Regex regex = new Regex(strRegex);

            return regex.IsMatch(email);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            txbTenNV.Focus();
            LoadData();
            txbMaNV.Enabled = false;
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            ketNoi.Open();
            using (SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM nhanVien", ketNoi))
            {
                maTuDong = (int)cmdCount.ExecuteScalar() + 1;
            }

            string maNV = $"NV{maTuDong:D6}";
            txbMaNV.Text = maNV;
            ketNoi.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);

            try
            {
                ketNoi.Open();

                using (SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM nhanVien", ketNoi))
                {
                    maTuDong = (int)cmdCount.ExecuteScalar() + 1;
                }

                string maNV = $"NV{maTuDong:D6}";

                using (SqlCommand kt = new SqlCommand("select count (*) from nhanVien where idNhanVien = @idNhanVien", ketNoi))
                {
                    kt.Parameters.AddWithValue("@idNhanVien",txbMaNV.Text);
                    int ktra = (int)kt.ExecuteScalar();
                    if(ktra > 0)
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại!!");
                        return;
                    }
                }

                using(SqlCommand them = new SqlCommand("insert into nhanVien (idNhanVien, tenNhanVien, chucVu, sdtNhanVien, emailNhanVien, diaChiNhanVien, khuVuc) values (@idNhanVien, @tenNhanVien, @chucVu, @sdtNhanVien, @emailNhanVien, @diaChiNhanVien, @khuVuc)",ketNoi))
                {
                    them.Parameters.AddWithValue("@idNhanVien", txbMaNV.Text);
                    them.Parameters.AddWithValue("@tenNhanVien", txbTenNV.Text);
                    them.Parameters.AddWithValue("@chucVu", txbChucVu.Text);
                    them.Parameters.AddWithValue("@sdtNhanVien", txbSDT.Text);
                    them.Parameters.AddWithValue("@diaChiNhanVien", txbDiaChi.Text);
                    them.Parameters.AddWithValue("@emailNhanVien", txbEmail.Text);
                    them.Parameters.AddWithValue("@khuVuc", txbKhuVuc.Text);

                    int check = them.ExecuteNonQuery();
                    if (check > 0)
                    {
                        MessageBox.Show("Thêm thành công!!");

                        txbChucVu.Clear();
                        txbEmail.Clear();
                        txbDiaChi.Clear();
                        txbKhuVuc.Clear();
                        txbTenNV.Clear();
                        txbTenNV.Focus();
                        txbSDT.Clear();
                        using (SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM nhanVien", ketNoi))
                        {
                            maTuDong = (int)cmdCount.ExecuteScalar() + 1;
                        }

                        maNV = $"NV{maTuDong:D6}";
                        txbMaNV.Text = maNV;
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi them " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);

            try
            {
                ketNoi.Open();

                if (txbMaNV.Text == "")
                {
                    MessageBox.Show("Ban chua nhap ma nhan vien");
                    return;
                }
                else
                {
                    using (SqlCommand kt = new SqlCommand("select count(*) from nhanVien where idNhanVien = @idNhanVien", ketNoi))
                    {
                        kt.Parameters.AddWithValue("@idNhanVien", txbMaNV.Text);
                        int ktra = (int)kt.ExecuteScalar();
                        if (ktra == 0)
                        {
                            MessageBox.Show("Ma nhan vien ban nhap khong ton tai");
                            txbMaNV.Clear();
                            return;
                        }
                    }

                    using (SqlCommand sua = new SqlCommand("update nhanVien set tenNhanVien = @tenNhanVien, chucVu = @chucVu, sdtNhanVien = @sdtNhanVien, emailNhanVien = @emailNhanVien, diaChiNhanVien = @diaChiNhanVien, khuVuc =@khuVuc where idNhanVien = @idNhanVien ", ketNoi))
                    {
                        sua.Parameters.AddWithValue("@idNhanVien", txbMaNV.Text);
                        sua.Parameters.AddWithValue("@tenNhanVien", txbTenNV.Text);
                        sua.Parameters.AddWithValue("@chucVu", txbChucVu.Text);
                        sua.Parameters.AddWithValue("@sdtNhanVien", txbSDT.Text);
                        sua.Parameters.AddWithValue("@diaChiNhanVien", txbDiaChi.Text);
                        sua.Parameters.AddWithValue("@emailNhanVien", txbEmail.Text);
                        sua.Parameters.AddWithValue("@khuVuc", txbKhuVuc.Text);

                        int ktra = sua.ExecuteNonQuery();
                        if (ktra > 0)
                        {
                            if(txbEmail.ForeColor != Color.Red || txbEmail.Text == "")
                            {
                                MessageBox.Show("Sửa thành công");
                                txbChucVu.Clear();
                                txbEmail.Clear();
                                txbDiaChi.Clear();
                                txbKhuVuc.Clear();
                                txbTenNV.Clear();
                                txbTenNV.Focus();
                                txbSDT.Clear();
                                using (SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM nhanVien", ketNoi))
                                {
                                    maTuDong = (int)cmdCount.ExecuteScalar() + 1;
                                }

                                string maNV = $"NV{maTuDong:D6}";
                                txbMaNV.Text = maNV;

                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("Email bạn nhập không hợp lệ, vui lòng nhập lại!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy mã nhân viên!!");
                        }
                    }
                }      
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi ket noi " + ex.Message);
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow ht = dgvNhanVien.Rows[e.RowIndex];
                
                if (ht.Cells["idNhanVien"].Value != null)
                {
                    txbMaNV.Text = ht.Cells["idNhanVien"].Value.ToString();
                    txbTenNV.Text = ht.Cells["tenNhanVien"].Value.ToString();
                    txbChucVu.Text = ht.Cells["chucVu"].Value.ToString();
                    txbSDT.Text = ht.Cells["sdtNhanVien"].Value.ToString();
                    txbEmail.Text = ht.Cells["emailNhanVien"].Value.ToString();
                    txbDiaChi.Text = ht.Cells["diaChiNhanVien"].Value.ToString();
                    txbKhuVuc.Text = ht.Cells["khuVuc"].Value.ToString();
                }
                
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);

            try
            {
                ketNoi.Open();
                if (txbMaNV.Text == "")
                {
                    MessageBox.Show("Ban chua nhap ma nhan vien");
                    return;
                }
                else
                {
                    using (SqlCommand kt = new SqlCommand("select count(*) from nhanVien where idNhanVien = @idNhanVien",ketNoi))
                    {
                        kt.Parameters.AddWithValue("@idNhanVien", txbMaNV.Text);
                        int ktra = (int)kt.ExecuteScalar();
                        if(ktra == 0)
                        {
                            MessageBox.Show("Ma ban vua nhap khong ton tai!!");
                            txbMaNV.Clear();
                            return;
                        }
                    }

                    using(SqlCommand xoa = new SqlCommand("delete from nhanVien where idNhanVien = @idNhanVien", ketNoi))
                    {
                        xoa.Parameters.AddWithValue("@idNhanVien",txbMaNV.Text);

                        int del = (int)xoa.ExecuteNonQuery();
                        if(del != 0)
                        {
                            MessageBox.Show("Xoa thanh cong");

                            txbTenNV.Focus();
                            txbTenNV.Clear();
                            txbChucVu.Clear();
                            txbDiaChi.Clear();
                            txbEmail.Clear();
                            txbSDT.Clear();
                            txbKhuVuc.Clear();
                            using (SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM nhanVien", ketNoi))
                            {
                                maTuDong = (int)cmdCount.ExecuteScalar() + 1;
                            }

                            string maNV = $"NV{maTuDong:D6}";
                            txbMaNV.Text = maNV;

                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Xoa that bai");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi ket noi"+ex.Message);
            }
        }

        private void btnRS_Click(object sender, EventArgs e)
        {
            txbMaNV.Clear();
            txbTenNV.Clear();
            txbChucVu.Clear();
            txbDiaChi.Clear();
            txbEmail.Clear();
            txbSDT.Clear();
            txbKhuVuc.Clear();
        }

        private void txbEmail_TextChanged(object sender, EventArgs e)
        {
            TextBox txtEmail = sender as TextBox;
            if (txtEmail != null)
            {
                string email = txtEmail.Text;
                if (!IsEmail(email))
                {
                    txtEmail.ForeColor = Color.Red;
                }
                else
                {
                    txtEmail.ForeColor = Color.Black;
                }
            }
        }

        private void txbSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbSDT_TextChanged(object sender, EventArgs e)
        {
            TextBox txbSDT = sender as TextBox;
            if (txbSDT != null)
            {
                if(txbSDT.Text.Length > 10)
                {
                    MessageBox.Show("So dien thoai khong vuot qua 10 so");
                    txbSDT.Text = txbSDT.Text.Substring(0, 10);
                    txbSDT.SelectionStart = txbSDT.Text.Length;
                }
            }
        }
    }
}
