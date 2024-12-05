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
    public partial class frmPhieuTra : Form
    {
        string chuoiKN = @"data source = . ; database = QLTV ; integrated security = SSPI";
        
        public frmPhieuTra()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            try
            {
                ketNoi.Open();
                using(SqlDataAdapter da =new SqlDataAdapter("select pt.idPhieuMuon, pt.tenNhanVien1, pt.idNhanVien, nv.tenNhanVien, pt.tenDocGia,pt.phiTreHen,pt.phiPhatSinh, (pt.phiTreHen + pt.phiPhatSinh) as tongPhi , pt.trangThai,soLuong from phieuTra pt, nhanVien nv where pt.idNhanVien = nv.idNhanVien ", ketNoi))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvShow.DataSource = dt;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi " + ex.Message);
            }
        }
        private void txbMa_TextChanged(object sender, EventArgs e)
        {
     
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string maMuon = txbMa.Text.Trim();
            if (!string.IsNullOrEmpty(maMuon))
            {
                SqlConnection ketNoi = new SqlConnection(chuoiKN);
                try
                {
                    ketNoi.Open();
                    string query = "SELECT pm.idNhanVien, dg.tenDocGia, nv.tenNhanVien, pm.ngayHenTra, pm.soLuong FROM phieuMuon pm, docGia dg , nhanVien nv WHERE pm.idDocGia = dg.idDocGia and idPhieuMuon = @idPhieuMuon and pm.idNhanVien = nv.idNhanVien";
                    using (SqlCommand command = new SqlCommand(query, ketNoi))
                    {
                        command.Parameters.AddWithValue("@idPhieuMuon", maMuon);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            
                            txbNVMuon.Text = reader["tenNhanVien"].ToString();
                            txbTenDG.Text = reader["tenDocGia"].ToString();
                            dtpNgayHen.Value = Convert.ToDateTime(reader["ngayHenTra"]);
                            txbSoLuong.Text = reader["soLuong"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin cho mã mượn này.");
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
            else
            {
                MessageBox.Show("Vui lòng nhập mã mượn.");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int soLuong = 0;
            int kq = 0;
            using (SqlConnection ketNoi = new SqlConnection(chuoiKN))
            {
                try
                {
                    ketNoi.Open();
                    if (txbMa.Text == "")
                    {
                        MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                        return;
                    }
                    using (SqlCommand kt = new SqlCommand("SELECT COUNT(*) FROM phieuTra WHERE idPhieuMuon = @idPhieuMuon", ketNoi))
                    {
                        kt.Parameters.AddWithValue("@idPhieuMuon", txbMa.Text);
                        int kt_pm = (int)kt.ExecuteScalar();
                        if (kt_pm != 0)
                        {
                            MessageBox.Show("Phiếu mượn đã tồn tại");
                            return;
                        }
                    }
                    using(SqlCommand lay = new SqlCommand("select soLuong from phieuMuon where idPhieuMuon = @idPhieuMuon", ketNoi))
                    {
                        lay.Parameters.AddWithValue("@idPhieuMuon",txbMa.Text);
                        int kt = (int)lay.ExecuteScalar();
                        if(kt == 0)
                        {
                            MessageBox.Show("Ma ban nhap khong ton tai");
                            return;
                        }
                        soLuong = (int)kt;
                    }
                    using (SqlCommand them = new SqlCommand("INSERT INTO phieuTra (idPhieuMuon, idNhanVien, tenDocGia, tenNhanVien1, trangThai, ngayTraThuc, phiTreHen, phiPhatSinh, ngayHenTra, soLuong) VALUES (@idPhieuMuon, @idNhanVien, @tenDocGia, @tenNhanVien1, @trangThai, @ngayTraThuc, @phiTreHen, @phiPhatSinh, @ngayHenTra,@soLuong)", ketNoi))
                    {
                        them.Parameters.AddWithValue("@idPhieuMuon", txbMa.Text);
                        them.Parameters.AddWithValue("@idNhanVien", txbNVTra.Text);
                        them.Parameters.AddWithValue("@phiPhatSinh", txbPhiPhatSinh.Text);
                        them.Parameters.AddWithValue("@ngayTraThuc", dtpNgayTra.Value.Date);
                        them.Parameters.AddWithValue("@tenNhanVien1", txbNVMuon.Text);
                        them.Parameters.AddWithValue("@tenDocGia", txbTenDG.Text);
                        them.Parameters.AddWithValue("@ngayHenTra", dtpNgayHen.Value);
                        them.Parameters.AddWithValue("@soLuong",txbSoLuong.Text);

                        if (dtpNgayTra.Value < dtpNgayHen.Value)
                        {
                            them.Parameters.AddWithValue("@trangThai", "Trả sớm");
                            them.Parameters.AddWithValue("@phiTreHen",kq.ToString());
                        }
                        else if (dtpNgayTra.Value > dtpNgayHen.Value)
                        {
                            kq = (int)(dtpNgayTra.Value - dtpNgayHen.Value).TotalDays * 2000;
                            them.Parameters.AddWithValue("@phiTreHen", kq.ToString());
                            them.Parameters.AddWithValue("@trangThai", "Trễ hẹn");
                        }
                        else if (dtpNgayTra.Value == DateTime.Today)
                        {
                            them.Parameters.AddWithValue("@trangThai", "Đã trả");
                            them.Parameters.AddWithValue("@phiTreHen", kq.ToString());
                        }
                        else
                        {
                            them.Parameters.AddWithValue("@trangThai", txbTT.Text);
                        }

                        int kt_them = them.ExecuteNonQuery();
                        if (kt_them > 0)
                        {
                            using (SqlCommand capNhat = new SqlCommand("UPDATE Kho SET soLuong = soLuong + @soLuong WHERE maSach IN (SELECT maSach FROM phieuMuon WHERE idPhieuMuon = @idPhieuMuon);", ketNoi))
                            {
                                capNhat.Parameters.AddWithValue("@idPhieuMuon", txbMa.Text);
                                capNhat.Parameters.AddWithValue("@soLuong", soLuong);
                                capNhat.ExecuteNonQuery();
                            }
                            MessageBox.Show("Thêm thành công");
                            txbMa.Clear();
                            txbNVTra.Clear();
                            txbPhiTre.Clear();
                            txbTenDG.Clear();
                            txbPhiPhatSinh.Clear();
                            txbNVMuon.Clear();
                            txbTT.Clear();
                            dtpNgayHen.Value = DateTime.Today;
                            dtpNgayTra.Value = DateTime.Today;
                            txbSoLuong.Clear();
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally { ketNoi.Close(); }
            }
        }

        private void frmPhieuTra_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int kq = 0;
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            try
            {
                ketNoi.Open();
                using(SqlCommand kt = new SqlCommand("select count (*) from phieuTra where idPhieuMuon = @idPhieuMuon", ketNoi))
                {
                    kt.Parameters.AddWithValue("@idPhieuMuon",txbMa.Text);
                    int ktra = (int)kt.ExecuteScalar();
                    if(ktra == 0)
                    {
                        MessageBox.Show("Ma ban vua nhap khong ton tai!!");
                        return;
                    }
                    using(SqlCommand sua = new SqlCommand("update phieuTra set idNhanVien = @idNhanVien, phiTreHen = @phiTreHen, phiPhatSinh = @phiPhatSinh , trangThai = @trangThai where idPhieuMuon = @idPhieuMuon ", ketNoi))
                    {
                        sua.Parameters.AddWithValue("@idPhieuMuon", txbMa.Text);
                        sua.Parameters.AddWithValue("@idNhanVien", txbNVTra.Text);
                        if (dtpNgayTra.Value < dtpNgayHen.Value)
                        {
                            sua.Parameters.AddWithValue("@trangThai", "Trả sớm");
                            sua.Parameters.AddWithValue("@phiTreHen", kq.ToString());
                        }
                        else if (dtpNgayTra.Value > dtpNgayHen.Value)
                        {
                            kq = (int)(dtpNgayTra.Value - dtpNgayHen.Value).TotalDays * 2000;
                            sua.Parameters.AddWithValue("@phiTreHen", kq.ToString());
                            sua.Parameters.AddWithValue("@trangThai", "Trễ hẹn");
                        }
                        else if (dtpNgayTra.Value == DateTime.Today)
                        {
                            sua.Parameters.AddWithValue("@trangThai", "Đã trả");
                            sua.Parameters.AddWithValue("@phiTreHen", kq.ToString());
                        }
                        else
                        {
                            sua.Parameters.AddWithValue("@trangThai", txbTT.Text);
                        }
                        sua.Parameters.AddWithValue("@phiPhatSinh",txbPhiPhatSinh.Text);
                        
                        int check = (int)sua.ExecuteNonQuery();
                        if (check != 0)
                        {
                            MessageBox.Show("Sua thanh cong");
                            txbMa.Clear();
                            txbNVTra.Clear();
                            txbPhiTre.Clear();
                            txbTenDG.Clear();
                            txbPhiPhatSinh.Clear();
                            txbNVMuon.Clear();
                            txbTT.Clear();
                            dtpNgayHen.Value = DateTime.Today;
                            dtpNgayTra.Value = DateTime.Today;
                            txbSoLuong.Clear();
                            LoadData();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Sua that bai");
                            
                            return;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ket noi that bai " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            try
            {
                ketNoi.Open();
                using(SqlCommand kt = new SqlCommand("select count (*) from phieuTra where idPhieuMuon = @idPhieuMuon", ketNoi))
                {
                    kt.Parameters.AddWithValue("@idPhieuMuon", txbMa.Text);
                    int ktra = (int)kt.ExecuteScalar();
                    if(ktra == 0)
                    {
                        MessageBox.Show("Ma ban vua nhap khong ton tai");
                        return;
                    }
                    using(SqlCommand xoa = new SqlCommand("delete from phieuTra where idPhieuMuon = @idPhieuMuon", ketNoi))
                    {
                        xoa.Parameters.AddWithValue("@idPhieuMuon",txbMa.Text);
                        int check = (int)xoa.ExecuteNonQuery();
                        if(check != 0)
                        {
                            MessageBox.Show("Xoa thanh cong");
                            txbMa.Clear();
                            txbNVTra.Clear();
                            txbPhiTre.Clear();
                            txbTenDG.Clear();
                            txbPhiPhatSinh.Clear();
                            txbNVMuon.Clear();
                            txbTT.Clear();
                            txbSoLuong.Clear();
                            dtpNgayHen.Value = DateTime.Today;
                            dtpNgayTra.Value = DateTime.Today;
                            LoadData();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Xoa that bai");
                            return;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ket noi that bai" + ex.Message);
            }
        }

        private void btnRS_Click(object sender, EventArgs e)
        {
            txbMa.Clear();
            txbNVTra.Clear();
            txbPhiTre.Clear();
            txbTenDG.Clear();
            txbPhiPhatSinh.Clear();
            txbNVMuon.Clear();
            txbTT.Clear();
            dtpNgayHen.Value = DateTime.Today;
            dtpNgayTra.Value = DateTime.Today;
            LoadData();
        }

        private void dgvShow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow ht = dgvShow.Rows[e.RowIndex];
                if (ht.Cells["idPhieuMuon"].Value != null)
                {
                    txbMa.Text = ht.Cells["idPhieuMuon"].Value.ToString();
                    txbNVMuon.Text = ht.Cells["tenNhanVien1"].Value.ToString();
                    txbNVTra.Text = ht.Cells["idNhanVien"].Value.ToString();
                    txbPhiPhatSinh.Text = ht.Cells["phiPhatSinh"].Value.ToString();
                    txbPhiTre.Text = ht.Cells["phiTreHen"].Value.ToString();
                    txbSoLuong.Text = ht.Cells["soLuong"].Value.ToString();
                    txbTenDG.Text = ht.Cells["tenDocGia"].Value.ToString();
                    txbTT.Text = ht.Cells["trangThai"].Value.ToString();
                }
            }
        }

        private void txbTT_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txbNVMuon_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txbNVTra_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbTenDG_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
