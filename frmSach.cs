using DeMoDoAn.Htro;
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
    public partial class frmSach : Form
    {
        string chuoiKN = @"Data Source = . ; Database = QLTV; Integrated Security =SSPI";
        private int maTuDong = 0;
        public frmSach()
        {
            InitializeComponent();           
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void LoadMaSach ()
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            try
            {
                ketNoi.Open();
                using (SqlCommand tim = new SqlCommand("select * from Sach where maSach like @maSach", ketNoi))
                {
                    tim.Parameters.AddWithValue("@maSach", "%" + txbIDSach.Text.Trim() + "%");
                    SqlDataAdapter da = new SqlDataAdapter(tim);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvSach.DataSource = dt;;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi " + ex.Message);
            }
        }
        private void btnThemSach_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            try
            {
                ketNoi.Open();
                using (SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM Sach", ketNoi))
                {
                    maTuDong = (int)cmdCount.ExecuteScalar() + 1;
                }

                string maSach = $"S{maTuDong:D6}";

                using (SqlCommand kt_idSach = new SqlCommand("select count (*) from Sach where maSach = @maSach ", ketNoi))
                {
                    kt_idSach.Parameters.AddWithValue("@maSach", maSach);
                    int exists = (int)kt_idSach.ExecuteScalar();

                    if (exists > 0)
                    {
                        MessageBox.Show("Mã sách đã tồn tại!!");
                        return;
                    }
                }

                if (txbTenSach.Text == "" || txbTacGia.Text == "" || txbNXB.Text == "" || txbTheLoai.Text == "" || txbViTri.Text == "" || txbSL.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!");
                    return;
                }

                using (SqlCommand them = new SqlCommand("insert into Sach (maSach, tenSach, tacGia, nhaXuatBan, namXuatBan, theLoai, viTriTV, soLuong) values (@maSach, @tenSach, @tacGia, @nhaXuatBan, @namXuatBan, @theLoai, @viTriTV, @soLuong)", ketNoi))
                {
                    if(dtpNamXuatBan.Value >= DateTime.Today)
                    {
                        MessageBox.Show("Ngày bạn vừa nhập lớn hơn ngày hiện tại");
                        return;
                    }
                    else
                    {
                        them.Parameters.AddWithValue("@maSach", maSach);
                        them.Parameters.AddWithValue("@tenSach", txbTenSach.Text);
                        them.Parameters.AddWithValue("@tacGia", txbTacGia.Text);
                        them.Parameters.AddWithValue("@nhaXuatBan", txbNXB.Text);
                        them.Parameters.AddWithValue("@theLoai", txbTheLoai.Text);
                        them.Parameters.AddWithValue("@viTriTV", txbViTri.Text);
                        them.Parameters.AddWithValue("@soLuong", txbSL.Text);
                        them.Parameters.AddWithValue("@namXuatBan", dtpNamXuatBan.Value.Date);
                    }

                    int result = them.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Thêm sách thành công");

                        using (SqlCommand add_Kho = new SqlCommand("insert into Kho (maSach, soLuong) values (@maSach, @soLuong)", ketNoi))
                        {
                            add_Kho.Parameters.AddWithValue("@maSach", maSach);
                            add_Kho.Parameters.AddWithValue("@soLuong", txbSL.Text);
                            add_Kho.ExecuteNonQuery();
                        }

                        using (SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM Sach", ketNoi))
                        {
                            maTuDong = (int)cmdCount.ExecuteScalar() + 1;
                        }
                        maSach = $"S{maTuDong:D6}";
                        txbIDSach.Text = maSach;

                        txbTenSach.Clear();
                        txbTacGia.Clear();
                        txbNXB.Clear();
                        txbTheLoai.Clear();
                        txbViTri.Clear();
                        txbSL.Clear();

                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Thêm sách thất bại!!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại vì: " + ex.Message);
            }
            finally
            {
                ketNoi.Close();
            }
        }

        private void btnThoatSach_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSuaSach_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);

            try
            {
                ketNoi.Open();

                if(txbIDSach.Text == "")
                {
                    MessageBox.Show("Ban chua nhap ma sach");
                }
                else
                {
                    using (SqlCommand kt_idSach = new SqlCommand("select count (*) from Sach where maSach = @maSach ", ketNoi))
                    {
                        kt_idSach.Parameters.AddWithValue("@maSach", txbIDSach.Text);
                        int exits = (int)kt_idSach.ExecuteScalar();

                        if (exits == 0)
                        {
                            MessageBox.Show("Ma sach vua nhap khong ton tai");
                            return;
                        }
                    }

                    string query = "update Sach set tenSach = @tenSach, tacGia = @tacGia, nhaXuatBan = @nhaXuatBan, namXuatBan = @namXuatBan, theLoai = @theLoai, viTriTV = @viTriTV, soLuong = @soLuong where maSach = @maSach";
                    using (SqlCommand sua = new SqlCommand(query, ketNoi))
                    {
                        sua.Parameters.AddWithValue("@maSach", txbIDSach.Text);
                        sua.Parameters.AddWithValue("@tenSach", txbTenSach.Text);
                        sua.Parameters.AddWithValue("@tacGia", txbTacGia.Text);
                        sua.Parameters.AddWithValue("@nhaXuatBan", txbNXB.Text);
                        sua.Parameters.AddWithValue("@theLoai", txbTheLoai.Text);
                        sua.Parameters.AddWithValue("@viTriTV", txbViTri.Text);
                        sua.Parameters.AddWithValue("@soLuong", txbSL.Text);
                        sua.Parameters.AddWithValue("@namXuatBan", dtpNamXuatBan.Value.Date);

                        int result = sua.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Cap nhat thanh cong");
                            using(SqlCommand update_kho = new SqlCommand("update Kho set soLuong = @soLuong where maSach = @maSach", ketNoi))
                            {
                                update_kho.Parameters.AddWithValue("@maSach", txbIDSach.Text);
                                update_kho.Parameters.AddWithValue("@soLuong", txbSL.Text);
                                update_kho.ExecuteNonQuery();
                            }
                            txbIDSach.Clear();
                            txbTenSach.Clear();
                            txbTacGia.Clear();
                            txbNXB.Clear();
                            txbTheLoai.Clear();
                            txbViTri.Clear();
                            txbSL.Clear();
                            dtpNamXuatBan.Value = DateTime.Now;
                            using (SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM Sach", ketNoi))
                            {
                                maTuDong = (int)cmdCount.ExecuteScalar() + 1;
                            }
                            string maSach = $"S{maTuDong:D6}";
                            txbIDSach.Text = maSach;

                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Khong tim thay ma sach vua nhap!!");
                        }
                    }
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai tai: ","Loi" + ex.Message);
            }
            finally 
            { 
                ketNoi.Close();
            }
        }

        private void btnXoaSach_Click(object sender, EventArgs e)
        {

            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            try
            {
                ketNoi.Open();

                if (txbIDSach.Text == "")
                {
                    MessageBox.Show("Ban chua nhap ma sach");
                }
                else
                {
                    using (SqlCommand xoa = new SqlCommand("delete from Kho where maSach = @maSach", ketNoi))
                    {
                        xoa.Parameters.AddWithValue("@maSach", txbIDSach.Text);

                        int result = xoa.ExecuteNonQuery();
                        if (result != 0)
                        {
                            MessageBox.Show("Xoa thanh cong");
                            using(SqlCommand del_Sach = new SqlCommand("delete from Sach where maSach = @maSach", ketNoi))
                            {
                                del_Sach.Parameters.AddWithValue("@maSach", txbIDSach.Text);
                                del_Sach.ExecuteNonQuery();
                            }
                            txbIDSach.Clear();
                            txbTenSach.Clear();
                            txbTacGia.Clear();
                            txbNXB.Clear();
                            txbTheLoai.Clear();
                            txbViTri.Clear();
                            txbSL.Clear();
                            dtpNamXuatBan.Value = DateTime.Now;
                            using (SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM Sach", ketNoi))
                            {
                                maTuDong = (int)cmdCount.ExecuteScalar() + 1;
                            }
                            string maSach = $"S{maTuDong:D6}";
                            txbIDSach.Text = maSach;

                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy mã sách!!");
                            using (SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM Sach", ketNoi))
                            {
                                maTuDong = (int)cmdCount.ExecuteScalar() + 1;
                            }
                            string maSach = $"S{maTuDong:D6}";
                            txbIDSach.Text = maSach;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Phát hiện lỗi : " + ex.Message);
            }
            finally
            {
                ketNoi.Close();
            }
        }

        private void LoadData()
        {
            using (SqlConnection ketNoi = new SqlConnection(chuoiKN))
            {
                try
                {
                    ketNoi.Open();

                    SqlDataAdapter dt = new SqlDataAdapter("Select maSach, tenSach, tacGia, nhaXuatBan, namXuatBan, theLoai, viTriTV, soLuong from Sach",ketNoi);
                    DataTable dtb = new DataTable();
                    dt.Fill(dtb);
                    dgvSach.DataSource = dtb;

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Loi data girdview " + ex.Message);
                }
            }
        }

        private void frmSach_Load(object sender, EventArgs e)
        {
            LoadData();
            txbIDSach.Enabled = false;
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            ketNoi.Open();
            using (SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM Sach", ketNoi))
            {
                maTuDong = (int)cmdCount.ExecuteScalar() + 1;
            }

            string maSach = $"S{maTuDong:D6}";
            txbIDSach.Text = maSach;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 )
            {
                DataGridViewRow ht = dgvSach.Rows[e.RowIndex];
                txbIDSach.Text = ht.Cells["maSach"].Value.ToString();
                txbTenSach.Text = ht.Cells["tenS"].Value.ToString();
                txbTacGia.Text = ht.Cells["TGia"].Value.ToString();
                txbNXB.Text = ht.Cells["ngayXB"].Value.ToString();
                txbTheLoai.Text = ht.Cells["theLoai"].Value.ToString();
                txbViTri.Text = ht.Cells["viTri"].Value.ToString();
                txbSL.Text = ht.Cells["soLuong"].Value.ToString();;               
                
                if (ht.Cells["NXB"].Value != DBNull.Value)
                {
                    dtpNamXuatBan.Value = Convert.ToDateTime(ht.Cells["NXB"].Value);
                } 
            }
        }

        private void btnRS_Click(object sender, EventArgs e)
        {
            txbIDSach.Clear();
            txbTenSach.Clear();
            txbTacGia.Clear();
            txbNXB.Clear();
            txbTheLoai.Clear();
            txbViTri.Clear();
            txbSL.Clear();
            dtpNamXuatBan.Value = DateTime.Today;
            LoadData();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadMaSach();
            txbTenSach.Clear();
            txbTacGia.Clear();
            txbNXB.Clear();
            txbTheLoai.Clear();
            txbViTri.Clear();
            txbSL.Clear();
            dtpNamXuatBan.Value = DateTime.Today;
        }

        private void txbSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            RangBuocNhapSo.AllowNumbersOnly(sender, e);
        }
    }
}
