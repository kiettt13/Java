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
using System.IO;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;

namespace DeMoDoAn
{
    public partial class frmThongKe : Form
    {
        string chuoiKN = @"data source = . ; database = QLTV; integrated Security = SSPI";
        public frmThongKe()
        {
            InitializeComponent();
        }
        private void LoadDataAll()
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            using (SqlDataAdapter da = new SqlDataAdapter("select * from phieuMuon ; select * from phieuTra", ketNoi))
            {
                ketNoi.Open();
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgvTK.DataSource = ds.Tables[0];
                dgvTK2.DataSource = ds.Tables[1];
            }
        }
        private void LoadDataGD()
        {
            cbbPhieu.Items.Add("Phieu muon");
            cbbPhieu.Items.Add("Phieu tra");

            cbbLoc.Items.Add("Tất cả");
            cbbLoc.Items.Add("Phiếu giao dịch");
            cbbLoc.Items.Add("Độc giả");
            cbbLoc.Items.Add("Nhân viên");
            cbbLoc.Items.Add("Sách");

        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
          
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            rdbTheoNgay.Checked = true;
            LoadDataGD();
            lbP.Hide();
            rdbTheoNgay.Show();
            rdbTheoThang.Show();
            lbP.Show();
            cbbLoc.Show();
            cbbPhieu.Show();
        }

        private void btnRS_Click(object sender, EventArgs e)
        {
            
        }
        private void ExportExcel (string path)
        {
            Excel.Application ap = new Excel.Application();
            ap.Application.Workbooks.Add(Type.Missing);

            for (int i = 0; i< dgvKQ.Columns.Count; i++)
            {
                ap.Cells[1,i+1] = dgvKQ.Columns[i].HeaderText;
            }
            for (int i = 0; i < dgvKQ.Rows.Count; i++)
            {
                for(int j = 0; j < dgvKQ.Columns.Count; j++)
                {
                    ap.Cells[i + 2, j + 1] = dgvKQ.Rows[i].Cells[j].Value;
                }
            }
            ap.Columns.AutoFit();
            ap.ActiveWorkbook.SaveCopyAs(path);
            ap.ActiveWorkbook.Saved = true;
        }
        private void rdbtnGD_CheckedChanged(object sender, EventArgs e)
        {
             lbP.BackColor = Color.FromArgb(202, 215, 255);
             lbP.Text = "Chon loai phieu";
        }

        private void rdbtnAll_CheckedChanged(object sender, EventArgs e)
        {
            rdbTheoNgay.Hide();
            rdbTheoThang.Hide();
            lbP.Hide();
            cbbPhieu.Hide();
        }

        private void rdbtnDG_CheckedChanged(object sender, EventArgs e)
        {
            rdbTheoNgay.Show();
            rdbTheoThang.Show();
            lbP.Hide();
            cbbPhieu.Hide();
        }

        private void rdbtnNV_CheckedChanged(object sender, EventArgs e)
        {
            rdbTheoNgay.Show();
            rdbTheoThang.Show();
            lbP.Hide();
            cbbPhieu.Show();
        }

        private void rdbtnSach_CheckedChanged(object sender, EventArgs e)
        {
            rdbTheoNgay.Show();
            rdbTheoThang.Show();
            lbP.Hide();
            cbbPhieu.Hide();
            rdbTheoNgay.Checked = false;
            rdbTheoThang.Checked =false;
        }

        private void cbbLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbLoc.Text == "Sách")
            {
                rdbTheoNgay.Checked = false;
                rdbTheoThang.Checked = false;
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            try
            {
                ketNoi.Open();
                if (cbbLoc.Text == "Tất cả")
                {
                    LoadDataAll();
                    return;
                }
                else if (cbbLoc.Text == "Phiếu giao dịch")
                {
                    if (cbbPhieu.Text == "Phieu muon" && rdbTheoNgay.Checked)
                    {

                        SqlDataAdapter da = new SqlDataAdapter("select ngayLapPhieu as Ngày, count(*) as 'Số lần' from phieuMuon group by ngayLapPhieu", ketNoi);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvKQ.DataSource = dt;
                    }
                    else if (cbbPhieu.Text == "Phieu muon" && rdbTheoThang.Checked)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("select month(ngayLapPhieu) as Tháng, count(*) as 'Số lần' from phieuMuon group by month(ngayLapPhieu)", ketNoi);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvKQ.DataSource = dt;
                    }
                    else if (cbbPhieu.Text == "Phieu tra" && rdbTheoNgay.Checked)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("select ngayTraThuc as Ngày, count(*) as 'Số lần' from phieuTra group by ngayTraThuc", ketNoi);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvKQ.DataSource = dt;
                    }
                    else if (cbbPhieu.Text == "Phieu tra" && rdbTheoThang.Checked)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("select month(ngayTraThuc) as Tháng, count(*) as 'Số lần' from phieuTra group by month(ngayTraThuc)", ketNoi);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvKQ.DataSource = dt;
                    }
                }
                else if (cbbLoc.Text == "Độc giả" && rdbTheoNgay.Checked == true)
                {
                    SqlDataAdapter da = new SqlDataAdapter("select dg.tenDocGia as 'Tên độc giả', pm.ngayLapPhieu as Ngày, sum(pm.soLuong) as SoLuongSachMuon from phieuMuon pm, docGia dg where pm.idDocGia = dg.idDocGia group by dg.tenDocGia, pm.ngayLapPhieu", ketNoi);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvKQ.DataSource = dt;
                }
                else if (cbbLoc.Text == "Độc giả" && rdbTheoThang.Checked == true)
                {

                    SqlDataAdapter da = new SqlDataAdapter("select dg.tenDocGia as Tên_độc_giả, month(pm.ngayLapPhieu) as Tháng, sum(pm.soLuong) as SoLuongSachMuon from phieuMuon pm, docGia dg where pm.idDocGia = dg.idDocGia group by dg.tenDocGia, month(pm.ngayLapPhieu)", ketNoi);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvKQ.DataSource = dt;
                }
                else if (cbbLoc.Text == "Nhân viên")
                {
                    if (cbbPhieu.Text == "Phieu muon" && rdbTheoNgay.Checked == true)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("select nv.tenNhanVien as Tên_Nhân_Viên, pm.ngayLapPhieu as Ngày ,count(*) as Lập_phiếu from nhanVien nv, phieuMuon pm where nv.idNhanVien = pm.idNhanVien group by nv.tenNhanVien, pm.ngayLapPhieu", ketNoi);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvKQ.DataSource = dt;
                    }
                    else if (cbbPhieu.Text == "Phieu muon" && rdbTheoThang.Checked == true)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("select nv.tenNhanVien as Tên_Nhân_Viên, month(pm.ngayLapPhieu) as Tháng ,count(*) as Lập_phiếu from nhanVien nv, phieuMuon pm where nv.idNhanVien = pm.idNhanVien group by nv.tenNhanVien, month(pm.ngayLapPhieu)", ketNoi);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvKQ.DataSource = dt;
                    }
                    else if (cbbPhieu.Text == "Phieu tra" && rdbTheoNgay.Checked == true)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("select nv.tenNhanVien as Tên_Nhân_Viên, pt.ngayTraThuc as Ngày ,count(*) as Lập_phiếu_trả from nhanVien nv, phieuTra pt, phieuMuon pm where nv.idNhanVien = pt.idNhanVien and pt.idPhieuMuon = pm.idPhieuMuon group by nv.tenNhanVien, pt.ngayTraThuc", ketNoi);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvKQ.DataSource = dt;
                    }
                    else if (cbbPhieu.Text == "Phieu tra" && rdbTheoThang.Checked == true)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("select nv.tenNhanVien as Tên_Nhân_Viên, month(pt.ngayTraThuc) as Tháng ,count(*) as Lập_phiếu_trả from nhanVien nv, phieuTra pt, phieuMuon pm where nv.idNhanVien = pt.idNhanVien and pt.idPhieuMuon = pm.idPhieuMuon group by nv.tenNhanVien, month(pt.ngayTraThuc)", ketNoi);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvKQ.DataSource = dt;
                    }
                }
                else if (cbbLoc.Text == "Nhân viên" && rdbTheoNgay.Checked == true)
                {
                    SqlDataAdapter da = new SqlDataAdapter("select nv.tenNhanVien as Tên_Nhân_Viên, pm.ngayLapPhieu as Ngày ,count(*) as Lập_phiếu from nhanVien nv, phieuMuon pm where nv.idNhanVien = pm.idNhanVien group by nv.tenNhanVien, pm.ngayLapPhieu", ketNoi);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvKQ.DataSource = dt;
                }
                else if (cbbLoc.Text == "Nhân viên" && rdbTheoThang.Checked == true)
                {
                    SqlDataAdapter da = new SqlDataAdapter("select nv.tenNhanVien as Tên_Nhân_Viên, month(pm.ngayLapPhieu) as Tháng ,count(*) as Lập_phiếu from nhanVien nv, phieuMuon pm where nv.idNhanVien = pm.idNhanVien group by nv.tenNhanVien, month(pm.ngayLapPhieu)", ketNoi);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvKQ.DataSource = dt;
                }
                else if (cbbLoc.Text == "Sách" && rdbTheoNgay.Checked == true)
                {
                    SqlDataAdapter da = new SqlDataAdapter("select s.tenSach as Tên_sách, pm.ngayLapPhieu as Ngày, count(*) as Lần from Sach s, phieuMuon pm where s.maSach = pm.maSach group by s.tenSach, pm.ngayLapPhieu", ketNoi);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvKQ.DataSource = dt;
                }
                else if (cbbLoc.Text == "Sách" && rdbTheoThang.Checked == true)
                {
                    SqlDataAdapter da = new SqlDataAdapter("select s.tenSach as Tên_sách, month(pm.ngayLapPhieu) as Tháng, count(*) as Lần from Sach s, phieuMuon pm where s.maSach = pm.maSach group by s.tenSach, month(pm.ngayLapPhieu)", ketNoi);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvKQ.DataSource = dt;
                }
                else if (cbbLoc.Text == "Sách")
                {
                    SqlDataAdapter da = new SqlDataAdapter("select s.tenSach as Tên_sách, count(*) as Lần from Sach s, phieuMuon pm where s.maSach = pm.maSach group by s.tenSach", ketNoi);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvKQ.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Vui long chon cach loc");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi " + ex.Message);
                return;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            rdbTheoNgay.Checked = true;
            LoadDataAll();
            lbP.Hide();
            dgvTK.ClearSelection();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            try
            {
                ketNoi.Open();
                if (cbbLoc.Text == "Tất cả")
                {
                    LoadDataAll();
                    return;
                }
                else if (cbbLoc.Text == "Phiếu giao dịch")
                {
                    if (cbbPhieu.Text == "Phieu muon" && rdbTheoNgay.Checked)
                    {

                        SqlDataAdapter da = new SqlDataAdapter("select ngayLapPhieu as Ngày, count(*) as Số_lần from phieuMuon group by ngayLapPhieu", ketNoi);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvKQ.DataSource = dt;
                    }
                    else if (cbbPhieu.Text == "Phieu muon" && rdbTheoThang.Checked)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("select month(ngayLapPhieu) as Tháng, count(*) as Số_lần from phieuMuon group by month(ngayLapPhieu)", ketNoi);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvKQ.DataSource = dt;
                    }
                    else if (cbbPhieu.Text == "Phieu tra" && rdbTheoNgay.Checked)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("select ngayTraThuc as Ngày, count(*) as Số_lần from phieuTra group by ngayTraThuc", ketNoi);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvKQ.DataSource = dt;
                    }
                    else if (cbbPhieu.Text == "Phieu tra" && rdbTheoThang.Checked)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("select month(ngayTraThuc) as Tháng, count(*) as Số_lần from phieuTra group by month(ngayTraThuc)", ketNoi);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvKQ.DataSource = dt;
                    }
                }
                else if (cbbLoc.Text == "Độc giả" && rdbTheoNgay.Checked == true)
                {
                    SqlDataAdapter da = new SqlDataAdapter("select dg.tenDocGia as Tên_độc_giả, pm.ngayLapPhieu as Ngày, sum(pm.soLuong) as SoLuongSachMuon from phieuMuon pm, docGia dg where pm.idDocGia = dg.idDocGia group by dg.tenDocGia, pm.ngayLapPhieu", ketNoi);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvKQ.DataSource = dt;
                }
                else if (cbbLoc.Text == "Độc giả" && rdbTheoThang.Checked == true)
                {

                    SqlDataAdapter da = new SqlDataAdapter("select dg.tenDocGia as Tên_độc_giả, month(pm.ngayLapPhieu) as Tháng, sum(pm.soLuong) as SoLuongSachMuon from phieuMuon pm, docGia dg where pm.idDocGia = dg.idDocGia group by dg.tenDocGia, month(pm.ngayLapPhieu)", ketNoi);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvKQ.DataSource = dt;
                }
                else if (cbbLoc.Text == "Nhân viên")
                {
                    if (cbbPhieu.Text == "Phieu muon" && rdbTheoNgay.Checked == true)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("select nv.tenNhanVien as Tên_Nhân_Viên, pm.ngayLapPhieu as Ngày ,count(*) as Lập_phiếu from nhanVien nv, phieuMuon pm where nv.idNhanVien = pm.idNhanVien group by nv.tenNhanVien, pm.ngayLapPhieu", ketNoi);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvKQ.DataSource = dt;
                    }
                    else if (cbbPhieu.Text == "Phieu muon" && rdbTheoThang.Checked == true)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("select nv.tenNhanVien as Tên_Nhân_Viên, month(pm.ngayLapPhieu) as Tháng ,count(*) as Lập_phiếu from nhanVien nv, phieuMuon pm where nv.idNhanVien = pm.idNhanVien group by nv.tenNhanVien, month(pm.ngayLapPhieu)", ketNoi);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvKQ.DataSource = dt;
                    }
                    else if (cbbPhieu.Text == "Phieu tra" && rdbTheoNgay.Checked == true)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("select nv.tenNhanVien as Tên_Nhân_Viên, pt.ngayTraThuc as Ngày ,count(*) as Lập_phiếu_trả from nhanVien nv, phieuTra pt, phieuMuon pm where nv.idNhanVien = pt.idNhanVien and pt.idPhieuMuon = pm.idPhieuMuon group by nv.tenNhanVien, pt.ngayTraThuc", ketNoi);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvKQ.DataSource = dt;
                    }
                    else if (cbbPhieu.Text == "Phieu tra" && rdbTheoThang.Checked == true)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("select nv.tenNhanVien as Tên_Nhân_Viên, month(pt.ngayTraThuc) as Tháng ,count(*) as Lập_phiếu_trả from nhanVien nv, phieuTra pt, phieuMuon pm where nv.idNhanVien = pt.idNhanVien and pt.idPhieuMuon = pm.idPhieuMuon group by nv.tenNhanVien, month(pt.ngayTraThuc)", ketNoi);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvKQ.DataSource = dt;
                    }
                }
                else if (cbbLoc.Text == "Nhân viên" && rdbTheoNgay.Checked == true)
                {
                    SqlDataAdapter da = new SqlDataAdapter("select nv.tenNhanVien as Tên_Nhân_Viên, pm.ngayLapPhieu as Ngày ,count(*) as Lập_phiếu from nhanVien nv, phieuMuon pm where nv.idNhanVien = pm.idNhanVien group by nv.tenNhanVien, pm.ngayLapPhieu", ketNoi);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvKQ.DataSource = dt;
                }
                else if (cbbLoc.Text == "Nhân viên" && rdbTheoThang.Checked == true)
                {
                    SqlDataAdapter da = new SqlDataAdapter("select nv.tenNhanVien as Tên_Nhân_Viên, month(pm.ngayLapPhieu) as Tháng ,count(*) as Lập_phiếu from nhanVien nv, phieuMuon pm where nv.idNhanVien = pm.idNhanVien group by nv.tenNhanVien, month(pm.ngayLapPhieu)", ketNoi);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvKQ.DataSource = dt;
                }
                else if (cbbLoc.Text == "Sách" && rdbTheoNgay.Checked == true)
                {
                    SqlDataAdapter da = new SqlDataAdapter("select s.tenSach as Tên_sách, pm.ngayLapPhieu as Ngày, count(*) as Lần from Sach s, phieuMuon pm where s.maSach = pm.maSach group by s.tenSach, pm.ngayLapPhieu", ketNoi);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvKQ.DataSource = dt;
                }
                else if (cbbLoc.Text == "Sách" && rdbTheoThang.Checked == true)
                {
                    SqlDataAdapter da = new SqlDataAdapter("select s.tenSach as Tên_sách, month(pm.ngayLapPhieu) as Tháng, count(*) as Lần from Sach s, phieuMuon pm where s.maSach = pm.maSach group by s.tenSach, month(pm.ngayLapPhieu)", ketNoi);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvKQ.DataSource = dt;
                }
                else if (cbbLoc.Text == "Sách")
                {
                    SqlDataAdapter da = new SqlDataAdapter("select s.tenSach as Tên_sách, count(*) as Lần from Sach s, phieuMuon pm where s.maSach = pm.maSach group by s.tenSach", ketNoi);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvKQ.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Vui long chon cach loc");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi " + ex.Message);
                return;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            SaveFileDialog luu = new SaveFileDialog();
            luu.Title = "Export excel";
            luu.Filter = "Excel (*.xlsx)|*.xlsx| Excel 2003 (*.xls)|*.xls";
            if(luu.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportExcel(luu.FileName);
                    MessageBox.Show("Xuất file thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xuất fiel lỗi " + ex.Message);
                }
            }
        }
    }
}
