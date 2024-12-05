using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeMoDoAn
{
    public partial class frmSuKien : Form
    {
        string chuoiKN = @"Data Source = . ; Database = QLTV; Integrated Security =SSPI";
        private int maTuDong = 0;
        public frmSuKien()
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

                    SqlDataAdapter dt = new SqlDataAdapter("Select * from suKien", ketNoi);
                    DataTable dtb = new DataTable();
                    dt.Fill(dtb);
                    dgvSuKien.DataSource = dtb;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Loi data girdview " + ex.Message);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            try
            {
                if (string.IsNullOrEmpty(txbMa.Text))
                {
                    MessageBox.Show("Khong de trong ma su kien", "Canh bao", MessageBoxButtons.OK);
                    return;
                }

                ketNoi.Open();

                using (SqlCommand kt = new SqlCommand("select count (*) from suKien where idSuKien = @idSuKien",ketNoi))
                {
                    kt.Parameters.AddWithValue("idSuKien", txbMa.Text);
                    int exits = (int)kt.ExecuteScalar();
                    if (exits > 0)
                    {
                        MessageBox.Show("Ma nay da ton tai");
                        txbMa.Clear();
                        return;
                    }
                }

                using (SqlCommand dem = new SqlCommand("select count (*) from suKien", ketNoi))
                {
                    maTuDong = (int)dem.ExecuteScalar() + 1;
                }
                string maSK = $"SK{maTuDong:D6}";

                using (SqlCommand them = new SqlCommand("insert into suKien (idSuKien, tenSuKien, moTaSuKien, ngayToChuc, gioToChuc, diaDiemToChuc) values (@idSuKien, @tenSuKien, @moTaSuKien, @ngayToChuc, @gioToChuc, @diaDiemToChuc) ", ketNoi))
                {
                    
                    if (dtpNgay.Value < DateTime.Today)
                    {
                        MessageBox.Show("Ngày tổ chức không nên ở quá khứ");
                        return;
                    }
                    else
                    {
                        them.Parameters.AddWithValue("@idSuKien", txbMa.Text);
                        them.Parameters.AddWithValue("@tenSuKien", txbTen.Text);
                        them.Parameters.AddWithValue("@moTaSuKien", txbMoTa.Text);
                        them.Parameters.AddWithValue("@ngayToChuc", dtpNgay.Value);
                        them.Parameters.AddWithValue("@gioToChuc", txbGio.Text);
                        them.Parameters.AddWithValue("@diaDiemToChuc", txbDiaDiem.Text);
                    }

                    int result = them.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Them thanh cong");
                        using (SqlCommand dem = new SqlCommand("select count (*) from suKien", ketNoi))
                        {
                            maTuDong = (int)dem.ExecuteScalar() + 1;
                        }
                        maSK = $"SK{maTuDong:D6}";
                        txbMa.Text = maSK;
                        txbGio.Clear();
                        txbDiaDiem.Clear();
                        txbMoTa.Clear();
                        txbTen.Clear();
                        dtpNgay.Value = DateTime.Today;

                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Them that bai");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi " + ex.Message);
            }
        }

        private void frmSuKien_Load(object sender, EventArgs e)
        {
            LoadData();
            txbMa.Enabled = false;
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            ketNoi.Open();
            using (SqlCommand dem = new SqlCommand("select count (*) from suKien",ketNoi))
            {
                maTuDong = (int)dem.ExecuteScalar() + 1;
            }
            string maSK = $"SK{maTuDong:D6}";
            txbMa.Text = maSK;
            ketNoi.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
             try
             {
                ketNoi.Open();

                if (txbMa.Text == "")
                {
                    MessageBox.Show("Ban chua nhap ma su kien");
                    return;
                }
                else
                {
                    using (SqlCommand kt = new SqlCommand("select count (*) from suKien where idSuKien = @idSuKien ", ketNoi))
                    {
                        kt.Parameters.AddWithValue("@idSuKien", txbMa.Text);
                        int exits = (int)kt.ExecuteScalar();

                        if (exits == 0)
                        {
                            MessageBox.Show("Ma su kien vua nhap khong ton tai");
                            return;
                        }
                    }

                    using (SqlCommand sua = new SqlCommand("update suKien set tenSuKien = @tenSuKien, moTaSuKien = @moTaSuKien, ngayToChuc = @ngayToChuc, gioToChuc = @gioToChuc, diaDiemToChuc = @diaDiemToChuc where idSuKien = @idSuKien", ketNoi))
                    {

                        if (dtpNgay.Value < DateTime.Today)
                        {
                            MessageBox.Show("Ngày tổ chức không nên ở quá khứ");
                            return;
                        }
                        else
                        {
                            sua.Parameters.AddWithValue("@idSuKien", txbMa.Text);
                            sua.Parameters.AddWithValue("@tenSuKien", txbTen.Text);
                            sua.Parameters.AddWithValue("@moTaSuKien", txbMoTa.Text);
                            sua.Parameters.AddWithValue("@ngayToChuc", dtpNgay.Value);
                            sua.Parameters.AddWithValue("@gioToChuc", txbGio.Text);
                            sua.Parameters.AddWithValue("@diaDiemToChuc", txbDiaDiem.Text);
                        }

                        int result = sua.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Sua thanh cong!!");
                            using (SqlCommand dem = new SqlCommand("select count (*) from suKien", ketNoi))
                            {
                                maTuDong = (int)dem.ExecuteScalar() + 1;
                            }
                            string maSK = $"SK{maTuDong:D6}";
                            txbMa.Text = maSK;
                            txbGio.Clear();
                            txbDiaDiem.Clear();
                            txbMoTa.Clear();
                            txbTen.Clear();
                            dtpNgay.Value = DateTime.Today;
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Khong tim thay ma su kien vua nhap!!");
                        }
                    }
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi" + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            try
            {

                ketNoi.Open();

                if(txbMa.Text == "")
                {
                    MessageBox.Show("Ban chua nhap ma su kien");
                }
                else
                {
                    using (SqlCommand xoa = new SqlCommand("delete from suKien where idSuKien = @idSuKien", ketNoi))
                    {
                        xoa.Parameters.AddWithValue("@idSuKien", txbMa.Text);

                        int result = xoa.ExecuteNonQuery();
                        if (result != 0)
                        {
                            MessageBox.Show("Xoa thanh cong", "Thong bao");
                            using (SqlCommand dem = new SqlCommand("select count (*) from suKien", ketNoi))
                            {
                                maTuDong = (int)dem.ExecuteScalar() + 1;
                            }
                            string maSK = $"SK{maTuDong:D6}";
                            txbMa.Text = maSK;
                            txbGio.Clear();
                            txbDiaDiem.Clear();
                            txbMoTa.Clear();
                            txbTen.Clear();
                            dtpNgay.Value = DateTime.Today;
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Khong tim thay ma su kien vua nhap!!");
                        }
                    }
                }

                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi ket noi " + ex.Message);
            }
        }

        private void dgvSuKien_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow ht = dgvSuKien.Rows[e.RowIndex];
                txbMa.Text = ht.Cells["maSK"].Value.ToString();
                txbTen.Text = ht.Cells["tenSK"].Value.ToString();
                txbMoTa.Text = ht.Cells["moTa"].Value.ToString();
                if (ht.Cells["ngayTC"].Value != null)
                {
                    dtpNgay.Value = Convert.ToDateTime(ht.Cells["ngayTC"].Value);
                    return;
                }
                else
                {
                    dtpNgay.Value = DateTime.Today;
                }
                txbGio.Text = ht.Cells["gioTC"].Value.ToString();
                txbDiaDiem.Text = ht.Cells["diaDiem"].Value.ToString();
            }
        }

        private void btnRS_Click(object sender, EventArgs e)
        {
            txbDiaDiem.Clear();
            txbGio.Clear();
            txbMoTa.Clear();
            txbTen.Clear();
            dtpNgay.Value = DateTime.Today;
            LoadData();
        }
    }
}
