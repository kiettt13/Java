using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DeMoDoAn
{
    public partial class frmCSVC : Form
    {
        string chuoiKN = @"Data source = . ; database = QLTV; Integrated Security =SSPI";
        private int maTuDong = 0;
        public frmCSVC()
        {
            InitializeComponent();
        }

        private void LoadData ()
        {
            using (SqlConnection ketNoi = new SqlConnection(chuoiKN))
            {
                try
                {
                    ketNoi.Open ();
                    using(SqlDataAdapter kt = new SqlDataAdapter("select * from coSoVatChat", ketNoi))
                    {
                        DataTable dt = new DataTable();
                        kt.Fill (dt);
                        dgvCSVC.DataSource = dt;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Loi DataGridView " + ex.Message);
                }
            }
        }

        private void frmCSVC_Load(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection (chuoiKN);
            txbMa.Enabled = false;
            ketNoi.Open();
            using (SqlCommand dem = new SqlCommand("select count (*) from coSoVatChat", ketNoi))
            {
                maTuDong = (int)dem.ExecuteScalar() + 1;
            }
            string maTB = $"TB{maTuDong:D6}";
            txbMa.Text = maTB;
            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection (chuoiKN);

            try
            {
                ketNoi.Open ();

                using(SqlCommand kt = new SqlCommand("select count (*) from coSoVatChat where idThietBi = @idThietBi", ketNoi))
                {
                    kt.Parameters.AddWithValue("idThietBi", txbMa.Text);
                    int ktra = (int)kt.ExecuteScalar();
                    if(ktra > 0)
                    {
                        MessageBox.Show("Ma ban vua nhap da ton tai");
                    }
                }
                using (SqlCommand dem = new SqlCommand("select count (*) from coSoVatChat",ketNoi))
                {
                    maTuDong = (int)dem.ExecuteScalar() + 1;
                }
                string maTB = $"TB{maTuDong:D6}";
                if (txbMa.Text == "")
                {
                    MessageBox.Show("Ban chua nhap ma thiet bi");
                }
                else
                {
                    using (SqlCommand them = new SqlCommand("insert into coSoVatChat (idThietBi, tenThietBi, tinhTrangThietBi, ngayMua, ngayBaoTri) values (@idThietBi, @tenThietBi, @tinhTrangThietBi, @ngayMua, @ngayBaoTri)", ketNoi))
                    {
                       
                        if (dtpNgayMua.Value >= dtpNgayBT.Value)
                        {
                             MessageBox.Show("Ngày bảo trì không thể có trước ngày mua");
                             return;
                        }
                        else
                        {
                            them.Parameters.AddWithValue("@ngayBaoTri", dtpNgayBT.Value);
                            them.Parameters.AddWithValue("@idThietBi", txbMa.Text);
                            them.Parameters.AddWithValue("@tenThietBi", txbTen.Text);
                            them.Parameters.AddWithValue("@tinhTrangThietBi", txbTT.Text);
                            them.Parameters.AddWithValue("@ngayMua", dtpNgayMua.Value);
                        }
                        int kt = (int)them.ExecuteNonQuery();
                        if (kt > 0)
                        {
                            MessageBox.Show("Thêm thành công");
                        using (SqlCommand dem = new SqlCommand("select count (*) from coSoVatChat", ketNoi))
                        {
                                maTuDong = (int)dem.ExecuteScalar() + 1;
                        }
                            maTB = $"TB{maTuDong:D6}";
                            txbMa.Text = maTB;
                            txbTT.Clear();
                            txbTen.Clear();
                            dtpNgayBT.Value = DateTime.Today;
                            dtpNgayMua.Value  = DateTime.Today;
                            LoadData();
                        }
                        else
                        {
                             MessageBox.Show("Thêm thất bại");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi ket noi" + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            try
            {
                ketNoi.Open();
                if(txbMa.Text == "")
                {
                    MessageBox.Show("Ban chua nhap ma thiet bi");
                }
                else
                {
                    using(SqlCommand kt = new SqlCommand("select count(*) from coSoVatChat where idThietBi = @idThietBi", ketNoi))
                    {
                        kt.Parameters.AddWithValue("@idThietBi",txbMa.Text);
                        int ktra = (int)kt.ExecuteScalar();
                        if(ktra == 0)
                        {
                            MessageBox.Show("Ma ban nhap khong ton tai");
                            txbMa.Clear();
                            return;
                        }
                    }

                    using(SqlCommand sua = new SqlCommand("update coSoVatChat set tenThietBi = @tenThietBi, tinhTrangThietBi = @tinhTrangThietBi, ngayMua = @ngayMua, ngayBaoTri = @ngayBaoTri where idThietBi = @idThietBi", ketNoi))
                    {
                        
                        if (dtpNgayMua.Value >= dtpNgayBT.Value)
                        {
                            MessageBox.Show("Ngày bảo trì không thể có trước ngày mua");
                            return;
                        }
                        else
                        {
                            sua.Parameters.AddWithValue("@ngayBaoTri", dtpNgayBT.Value);
                            sua.Parameters.AddWithValue("@idThietBi", txbMa.Text);
                            sua.Parameters.AddWithValue("@tenThietBi", txbTen.Text);
                            sua.Parameters.AddWithValue("@tinhTrangThietBi", txbTT.Text);
                            sua.Parameters.AddWithValue("@ngayMua", dtpNgayMua.Value);
                        }

                        int ktra = (int)sua.ExecuteNonQuery();
                        if(ktra > 0)
                        {
                            MessageBox.Show("Sua thanh cong");
                            using (SqlCommand dem = new SqlCommand("select count (*) from coSoVatChat", ketNoi))
                            {
                                maTuDong = (int)dem.ExecuteScalar() + 1;
                            }
                            string maTB = $"TB{maTuDong:D6}";
                            txbMa.Text = maTB;
                            txbTT.Clear();
                            txbTen.Clear();
                            dtpNgayBT.Value = DateTime.Today;
                            dtpNgayMua.Value = DateTime.Today;
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Sua that bai");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi ket noi " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            try
            {
                ketNoi.Open();

                if (txbMa.Text == "")
                {
                    MessageBox.Show("Ban chua nhap ma thiet bi");
                    return;
                }
                else
                {
                    using(SqlCommand xoa = new SqlCommand("delete from coSoVatChat where idThietBi = @idThietBi", ketNoi))
                    {
                        xoa.Parameters.AddWithValue("@idThietBi", txbMa.Text);
                        int ktra = (int)xoa.ExecuteNonQuery();
                        if(ktra != 0)
                        {
                            MessageBox.Show("Xoa thanh cong");
                            using (SqlCommand dem = new SqlCommand("select count (*) from coSoVatChat", ketNoi))
                            {
                                maTuDong = (int)dem.ExecuteScalar() + 1;
                            }
                            string maTB = $"TB{maTuDong:D6}";
                            txbMa.Text = maTB;
                            txbTT.Clear();
                            txbTen.Clear();
                            dtpNgayBT.Value = DateTime.Today;
                            dtpNgayMua.Value = DateTime.Today;
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Ma ban nhap khong ton tai");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi ket noi" + ex.Message);
            }
        }

        private void dgvCSVC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow ht = dgvCSVC.Rows[e.RowIndex];

                if (ht.Cells["ngayMua"].Value == DBNull.Value || ht.Cells["ngayBaoTri"].Value == DBNull.Value)
                {
                    dtpNgayMua.Value = DateTime.Today;
                    dtpNgayBT.Value = DateTime.Today;
                    txbMa.Text = ht.Cells["idThietBi"].Value.ToString();
                    txbTen.Text = ht.Cells["tenThietBi"].Value.ToString();
                    txbTT.Text = ht.Cells["tinhTrangThietBi"].Value.ToString();
                }
                else if (ht.Cells["idThietBi"].Value != null)
                {
                    txbMa.Text = ht.Cells["idThietBi"].Value.ToString();
                    txbTen.Text = ht.Cells["tenThietBi"].Value.ToString();
                    txbTT.Text = ht.Cells["tinhTrangThietBi"].Value.ToString();
                    dtpNgayMua.Value = Convert.ToDateTime(ht.Cells["ngayMua"].Value);
                    dtpNgayMua.Value = Convert.ToDateTime(ht.Cells["ngayBaoTri"].Value);
                }
                else
                {
                    MessageBox.Show("Ban dang click phai dong trong");
                }

            }
        }

        private void btnRS_Click(object sender, EventArgs e)
        {
            txbMa.Clear();
            txbTen.Clear();
            txbTT.Clear();
            dtpNgayBT.Value = DateTime.Today;
            dtpNgayMua.Value = DateTime.Today;
        }
    }
}
