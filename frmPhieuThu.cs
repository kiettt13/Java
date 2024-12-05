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
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;

namespace DeMoDoAn
{
    public partial class frmPhieuMuon : Form
    {
        string chuoiKN = @"data source = .; database = QLTV; integrated security = SSPI";
        private int maTuDong = 0;
        public frmPhieuMuon()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            try
            {
                ketNoi.Open();
                using(SqlDataAdapter da = new SqlDataAdapter("select pt.idPhieuMuon,pt.idNhanVien, nv.tenNhanVien, pt.maSach, s.tenSach, pt.idDocGia, pt.ngayLapPhieu, pt.ngayHenTra, pt.soLuong, dg.tenDocGia from phieuMuon pt, Sach s, docGia dg, nhanVien nv where pt.idDocGia = dg.idDocGia and pt.maSach = s.maSach and pt.idNhanVien = nv.idNhanVien", ketNoi))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvPhieuMuon.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi " + ex.Message);
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPhieuMuon_Load(object sender, EventArgs e)
        {
            txbMaPhieu.Enabled = false;
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            ketNoi.Open();
            using (SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM phieuMuon", ketNoi))
            {
                maTuDong = (int)cmdCount.ExecuteScalar() + 1;
            }
            string maPhieu = $"PM{maTuDong:D6}";
            txbMaPhieu.Text = maPhieu;
            LoadData();
            ketNoi.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection (chuoiKN);
            try
            {
                ketNoi.Open();
                using (SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM phieuMuon", ketNoi))
                {
                    maTuDong = (int)cmdCount.ExecuteScalar() + 1;
                }

                string maPhieu = $"PM{maTuDong:D6}";
                using (SqlCommand kt = new SqlCommand("select count(*) from phieuMuon where idPhieuMuon = @idPhieuMuon", ketNoi))
                {
                    kt.Parameters.AddWithValue("@idPhieuMuon", txbMaPhieu.Text);
                    int ktra = (int)kt.ExecuteScalar();
                    if (ktra != 0)
                    {
                        MessageBox.Show("Ma nay da ton tai");
                        return;
                    }
                    if (txbMaNV.Text == "" || txbMaDG.Text == "" || txbMaPhieu.Text == "" || txbMaSach.Text == "" || txbSL.Text == "")
                    {
                        MessageBox.Show("Vui long dien day du thong tin");
                        return;
                    }
                    
                    using(SqlCommand kt_sl = new SqlCommand("select soLuong from Kho where maSach = @maSach", ketNoi))
                    {
                        kt_sl.Parameters.AddWithValue("@maSach", txbMaSach.Text);
                        object kt_kho  = kt_sl.ExecuteScalar();
                        if(kt_kho == null)
                        {
                            MessageBox.Show("Ma sach khong ton tai trong kho");
                            return;
                        }
                        int soLuongMuon = int.Parse(txbSL.Text);
                        int slKho = (int)kt_kho;
                        
                        if(soLuongMuon > slKho)
                        {
                            MessageBox.Show("So luong sach trong kho khong du!");
                            return;
                        }
                        using (SqlCommand capNhat = new SqlCommand("update kho set soLuong = soLuong - @soLuongMuon where maSach = @maSach", ketNoi))
                        {
                            capNhat.Parameters.AddWithValue("@soLuongMuon",soLuongMuon);
                            capNhat.Parameters.AddWithValue("@maSach", txbMaSach.Text);
                            capNhat.ExecuteNonQuery();
                        }
                    }

                    using(SqlCommand them = new SqlCommand("INSERT INTO phieuMuon (idPhieuMuon, ngayLapPhieu, ngayHenTra, maSach, idNhanVien, idDocGia, soLuong) VALUES (@idPhieuMuon, @ngayLapPhieu, @ngayHenTra, @maSach, @idNhanVien, @idDocGia, @soLuong)", ketNoi))
                    {
                        them.Parameters.AddWithValue("@idPhieuMuon", txbMaPhieu.Text);
                        them.Parameters.AddWithValue("@maSach", txbMaSach.Text);
                        them.Parameters.AddWithValue("@idDocGia", txbMaDG.Text);
                        them.Parameters.AddWithValue("@idNhanVien", txbMaNV.Text);
                        them.Parameters.AddWithValue("@ngayLapPhieu", dtpLap.Value.Date);
                        if(dtpNgayHen.Value <= dtpLap.Value)
                        {
                            MessageBox.Show("Ngày hẹn trả không được trước ngày lập phiếu");
                            return;
                        }
                        else if ((dtpNgayHen.Value - dtpLap.Value).TotalDays > 14)
                        {
                            MessageBox.Show("Bạn chỉ có thể mượn tối đa 14 ngày");
                        }
                        else
                        {
                            them.Parameters.AddWithValue("@ngayHenTra", dtpNgayHen.Value.Date);
                        }
                        
                        them.Parameters.AddWithValue("@soLuong", txbSL.Text);


                        int check = (int)them.ExecuteNonQuery();
                        if(check != 0)
                        {
                            MessageBox.Show("Them thanh cong");
                            using (SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM phieuMuon", ketNoi))
                            {
                                maTuDong = (int)cmdCount.ExecuteScalar() + 1;
                            }
                            maPhieu = $"PM{maTuDong:D6}";
                            txbMaPhieu.Text = maPhieu;
                            dtpNgayHen.Value = DateTime.Today;
                            txbMaNV.Clear();
                            txbMaDG.Clear();
                            //
                            txbMaSach.Clear();
                            dtpLap.Value = DateTime.Today;
                            txbSL.Clear();
                            LoadData();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Them that bai");
                            return;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi " + ex.Message);
            }
        }

        private void btnRS_Click(object sender, EventArgs e)
        {
            dtpNgayHen.Value = DateTime.Today;
            txbMaNV.Clear();
            txbMaDG.Clear();
            //
            txbMaSach.Clear();
            dtpLap.Value = DateTime.Today;
            txbSL.Clear();
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            try
            {
                if (string.IsNullOrEmpty(txbMaPhieu.Text) || string.IsNullOrEmpty(txbMaDG.Text) || string.IsNullOrEmpty(txbMaNV.Text) || string.IsNullOrEmpty(txbMaSach.Text) || string.IsNullOrEmpty(txbSL.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                ketNoi.Open();

                using (SqlCommand kt = new SqlCommand("SELECT COUNT(*) FROM phieuMuon WHERE idPhieuMuon = @idPhieuMuon", ketNoi))
                {
                    kt.Parameters.AddWithValue("@idPhieuMuon", txbMaPhieu.Text);
                    int ktra = (int)kt.ExecuteScalar();
                    if (ktra == 0)
                    {
                        MessageBox.Show("Mã bạn vừa nhập không tồn tại.");
                        return;
                    }
                }

                int soLuongCu;
                using (SqlCommand lay_sl = new SqlCommand("SELECT soLuong FROM phieuMuon WHERE idPhieuMuon = @idPhieuMuon", ketNoi))
                {
                    lay_sl.Parameters.AddWithValue("@idPhieuMuon", txbMaPhieu.Text);
                    soLuongCu = (int)lay_sl.ExecuteScalar();
                }

                int soLuongMoi = int.Parse(txbSL.Text);

                if (soLuongMoi != soLuongCu)
                {
                    int chenh = Math.Abs(soLuongMoi - soLuongCu);

                    using (SqlCommand kt_sl = new SqlCommand("SELECT soLuong FROM Kho WHERE maSach = @maSach", ketNoi))
                    {
                        kt_sl.Parameters.AddWithValue("@maSach", txbMaSach.Text);
                        object kt_kho = kt_sl.ExecuteScalar();
                        if (kt_kho == null)
                        {
                            MessageBox.Show("Mã sách không tồn tại trong kho.");
                            return;
                        }

                        int slKho = (int)kt_kho;

                        if (soLuongCu > soLuongMoi && chenh > slKho)
                        {
                            MessageBox.Show("Số lượng sách trong kho không đủ để trả lại.");
                            return;
                        }

                        using (SqlCommand capNhatKho = new SqlCommand())
                        {
                            capNhatKho.Connection = ketNoi;
                            if (soLuongMoi > soLuongCu)
                            {
                                capNhatKho.CommandText = "UPDATE Kho SET soLuong = soLuong - @chenh WHERE maSach = @maSach";
                            }
                            else
                            {
                                capNhatKho.CommandText = "UPDATE Kho SET soLuong = soLuong + @chenh WHERE maSach = @maSach";
                            }
                            capNhatKho.Parameters.AddWithValue("@chenh", chenh);
                            capNhatKho.Parameters.AddWithValue("@maSach", txbMaSach.Text);
                            capNhatKho.ExecuteNonQuery();
                        }
                    }
                }

                using (SqlCommand sua = new SqlCommand("UPDATE phieuMuon SET maSach = @maSach, idDocGia = @idDocGia, idNhanVien = @idNhanVien, soLuong = @soLuong, ngayLapPhieu = @ngayLapPhieu, ngayHenTra = @ngayHenTra WHERE idPhieuMuon = @idPhieuMuon", ketNoi))
                {
                    sua.Parameters.AddWithValue("@idPhieuMuon", txbMaPhieu.Text);
                    sua.Parameters.AddWithValue("@maSach", txbMaSach.Text);
                    sua.Parameters.AddWithValue("@idDocGia", txbMaDG.Text);
                    sua.Parameters.AddWithValue("@idNhanVien", txbMaNV.Text);
                    sua.Parameters.AddWithValue("@soLuong", txbSL.Text);
                    sua.Parameters.AddWithValue("@ngayLapPhieu", dtpLap.Value.Date);
                    if (dtpNgayHen.Value <= dtpLap.Value)
                    {
                        MessageBox.Show("Ngày hẹn trả không được trước ngày lập phiếu");
                        return;
                    }
                    else if ((dtpNgayHen.Value - dtpLap.Value).TotalDays > 14)
                    {
                        MessageBox.Show("Bạn chỉ có thể mượn tối đa 14 ngày");
                    }
                    else
                    {
                        sua.Parameters.AddWithValue("@ngayHenTra", dtpNgayHen.Value.Date);
                    }

                    int check = (int)sua.ExecuteNonQuery();
                    if (check != 0)
                    {
                        MessageBox.Show("Sửa thành công.");
                        using (SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM phieuMuon", ketNoi))
                        {
                            maTuDong = (int)cmdCount.ExecuteScalar() + 1;
                        }
                        string maPhieu = $"PM{maTuDong:D6}";
                        txbMaPhieu.Text = maPhieu;
                        dtpNgayHen.Value = DateTime.Today;
                        txbMaNV.Clear();
                        txbMaDG.Clear();
                        //
                        txbMaSach.Clear();
                        dtpLap.Value = DateTime.Today;
                        txbSL.Clear();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại: " + ex.Message);
            }
            finally
            {
                ketNoi.Close();
            }
        }

        private void dgvPhieuMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow ht = dgvPhieuMuon.Rows[e.RowIndex];
                txbMaPhieu.Text = ht.Cells["idPhieuMuon"].Value.ToString();
                txbMaNV.Text = ht.Cells["idNhanVien"].Value.ToString();
                txbMaDG.Text = ht.Cells["idDocGia"].Value.ToString();
                txbMaSach.Text = ht.Cells["maSach"].Value.ToString();
                if (ht.Cells["ngayHenTra"].Value != DBNull.Value)
                    dtpNgayHen.Value = Convert.ToDateTime(ht.Cells["ngayHenTra"].Value);
                txbSL.Text = ht.Cells["soLuong"].Value.ToString();
                if (ht.Cells["ngayLapPhieu"].Value != DBNull.Value)
                    dtpLap.Value = Convert.ToDateTime(ht.Cells["ngayLapPhieu"].Value);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            try
            {
                if (string.IsNullOrEmpty(txbMaPhieu.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                ketNoi.Open();

                using (SqlCommand kt = new SqlCommand("SELECT COUNT(*) FROM phieuMuon WHERE idPhieuMuon = @idPhieuMuon", ketNoi))
                {
                    kt.Parameters.AddWithValue("@idPhieuMuon", txbMaPhieu.Text);
                    int ktra = (int)kt.ExecuteScalar();
                    if (ktra == 0)
                    {
                        MessageBox.Show("Mã bạn vừa nhập không tồn tại.");
                        return;
                    }
                }

                int soLuongTra;
                using (SqlCommand lay_sl = new SqlCommand("SELECT soLuong FROM phieuMuon WHERE idPhieuMuon = @idPhieuMuon", ketNoi))
                {
                    lay_sl.Parameters.AddWithValue("@idPhieuMuon", txbMaPhieu.Text);
                    soLuongTra = (int)lay_sl.ExecuteScalar();
                }

                using (SqlCommand kt_sl = new SqlCommand("SELECT soLuong FROM Kho WHERE maSach = @maSach", ketNoi))
                {
                    kt_sl.Parameters.AddWithValue("@maSach", txbMaSach.Text);
                    object kt_kho = kt_sl.ExecuteScalar();
                    if (kt_kho == null)
                    {
                        MessageBox.Show("Mã sách không tồn tại trong kho.");
                        return;
                    }
                    int soLuongHienTai = (int)kt_kho;

                    using (SqlCommand capNhat = new SqlCommand("UPDATE Kho SET soLuong = soLuong + @soLuongTra WHERE maSach = @maSach", ketNoi))
                    {
                        capNhat.Parameters.AddWithValue("@soLuongTra", soLuongTra);
                        capNhat.Parameters.AddWithValue("@maSach", txbMaSach.Text);
                        capNhat.ExecuteNonQuery();
                    }
                }

                using (SqlCommand xoa = new SqlCommand("DELETE FROM phieuMuon WHERE idPhieuMuon = @idPhieuMuon", ketNoi))
                {
                    xoa.Parameters.AddWithValue("@idPhieuMuon", txbMaPhieu.Text);
                    int check = (int)xoa.ExecuteNonQuery();
                    if (check != 0)
                    {
                        MessageBox.Show("Xóa thành công.");
                        using (SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM phieuMuon", ketNoi))
                        {
                            maTuDong = (int)cmdCount.ExecuteScalar() + 1;
                        }
                        string maPhieu = $"PM{maTuDong:D6}";
                        txbMaPhieu.Text = maPhieu;
                        dtpNgayHen.Value = DateTime.Today;
                        txbMaNV.Clear();
                        txbMaDG.Clear();
                        //
                        txbMaSach.Clear();
                        dtpLap.Value = DateTime.Today;
                        txbSL.Clear();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
            finally
            {
                ketNoi.Close();
            }
        }

        private void txbSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            RangBuocNhapSo.AllowNumbersOnly(sender, e);
        }
    }
}
