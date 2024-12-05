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
    public partial class frmGiaoDich : Form
    {
        string chuoiKN = @"data source = . ; database = QLTV; integrated security = SSPI";
        public frmGiaoDich()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txbMaGD.Clear();
            txbPhi.Clear();
            cbbMaDG.Text = "";
            cbbMaSach.Text = "";
            dtpNgayHen.Value = DateTime.Today;
            dtpNgayMuon.Value = DateTime.Today;
            dtpNgayTra.Value = DateTime.Today;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGiaoDich_Load(object sender, EventArgs e)
        {
            LoadData();
            sachLoad();
            DGLoad();
        }
        private void LoadData()
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            try
            {
                ketNoi.Open();
                using (SqlDataAdapter da = new SqlDataAdapter("select * from giaoDich", ketNoi))
                {                                 
                        DataTable dt = new DataTable();;
                        da.Fill(dt);
                        dgvGD.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi " + ex.Message);
            }
        }
        private void sachLoad()
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            try
            {
                ketNoi.Open();
                using(SqlCommand maSach = new SqlCommand("select idSach from sach", ketNoi))
                {
                    SqlDataReader doc = maSach.ExecuteReader();
                    while (doc.Read())
                    {
                        cbbMaSach.Items.Add(doc["idSach"].ToString());
                    }
                    doc.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi " + ex.Message);
            }
        }
        private void DGLoad()
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            try
            {
                ketNoi.Open();
                using (SqlCommand maSach = new SqlCommand("select idDocGia from docGia", ketNoi))
                {
                    SqlDataReader doc = maSach.ExecuteReader();
                    while (doc.Read())
                    {
                        cbbMaDG.Items.Add(doc["idDocGia"].ToString());
                    }
                    doc.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);

            try
            {
                ketNoi.Open();
                
                if (txbMaGD.Text == "" || cbbMaDG.Text == "" || cbbMaSach.Text == "")
                {
                    MessageBox.Show("Cac ma khong duoc de trong");
                    return;
                }
                string maSach = cbbMaSach.SelectedItem.ToString();
                string maDG = cbbMaDG.SelectedItem.ToString();
                using (SqlCommand kt = new SqlCommand("select count (*) from giaoDich where idGiaoDich = @idGiaoDich",ketNoi))
                {
                    
                    kt.Parameters.AddWithValue("@idGiaoDich", txbMaGD.Text);
                    int check = (int)kt.ExecuteScalar();
                    if(check != 0)
                    {
                        MessageBox.Show("Ma giao dich da ton tai");
                        txbMaGD.Clear();
                        txbPhi.Clear();
                        cbbMaDG.Text = "";
                        cbbMaSach.Text = "";
                        dtpNgayHen.Value = DateTime.Today;
                        dtpNgayMuon.Value = DateTime.Today;
                        dtpNgayTra.Value = DateTime.Today;
                    }
                    else
                    {
                        
                        using (SqlCommand them = new SqlCommand("insert into giaoDich (idGiaoDich, idSach, idDocGia, ngayMuon, ngayHenTra, ngayTraThuc, phiTreHen) values (@idGiaoDich, @maSach, @maDG, @ngayMuon, @ngayHenTra, @ngayTraThuc, @phiTreHen) ", ketNoi))
                        {
                            them.Parameters.AddWithValue("@idGiaoDich",txbMaGD.Text);
                            them.Parameters.AddWithValue("@maSach", maSach);
                            them.Parameters.AddWithValue("@maDG", maDG);
                            them.Parameters.AddWithValue("@ngayMuon", dtpNgayMuon.Value);
                            them.Parameters.AddWithValue("@ngayHenTra", dtpNgayHen.Value);
                            them.Parameters.AddWithValue("@ngayTraThuc", dtpNgayTra.Value);
                            them.Parameters.AddWithValue("@phiTreHen", txbPhi.Text);

                            int ktra = them.ExecuteNonQuery();
                            if(ktra > 0)
                            {
                                MessageBox.Show("Them thanh cong");
                                txbMaGD.Clear();
                                txbPhi.Clear();
                                cbbMaDG.Text = "";
                                cbbMaSach.Text = "";
                                dtpNgayHen.Value = DateTime.Today;
                                dtpNgayMuon.Value = DateTime.Today;
                                dtpNgayTra.Value = DateTime.Today;
                                LoadData();
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi " + ex.Message);
            }
        }

        private void dgvGD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 )
            {
                DataGridViewRow ht = dgvGD.Rows[e.RowIndex];
                txbMaGD.Text = ht.Cells["idGiaoDich"].Value.ToString();
                txbPhi.Text = ht.Cells["phiTreHen"].Value.ToString();
                if(dtpNgayHen.Value != null)
                {
                    dtpNgayHen.Value = Convert.ToDateTime(dtpNgayHen.Value);
                }
                else
                {
                    dtpNgayHen.Value = DateTime.Today;
                }
                if (dtpNgayMuon.Value != null)
                {
                    dtpNgayMuon.Value = Convert.ToDateTime(dtpNgayMuon.Value);
                }
                else
                {
                    dtpNgayMuon.Value = DateTime.Today;
                }
                if (dtpNgayTra.Value != null)
                {
                    dtpNgayTra.Value = Convert.ToDateTime(dtpNgayTra.Value);
                }
                else
                {
                    dtpNgayTra.Value = DateTime.Today;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            try
            {
                ketNoi.Open();
                if (txbMaGD.Text == "" || cbbMaDG.Text == "" || cbbMaSach.Text == "")
                {
                    MessageBox.Show("Vui long khong de trong cac ma");
                    return;
                }
                

                using (SqlCommand kt = new SqlCommand("select * from giaoDich where idGiaoDich = @idGiaoDich",ketNoi))
                {
                    kt.Parameters.AddWithValue("@idGiaoDich",txbMaGD.Text);
                    int ktra = (int)kt.ExecuteScalar();
                    if(ktra == 0)
                    {
                        MessageBox.Show("Ma ban vua nhap khong ton tai");
                        return;
                    }
                    string maSach = cbbMaSach.SelectedItem.ToString();
                    string maDG = cbbMaDG.SelectedItem.ToString();
                    using (SqlCommand sua = new SqlCommand("update giaoDich set idSach = @maSach, idDocGia = @maDG, ngayMuon = @ngayMuon, ngayHenTra = @ngayHenTra, ngayTraThuc = @ngayTraThuc, phiTreHen = @phiTreHen where idGiaoDich = @idGiaoDich", ketNoi))
                    {
                        sua.Parameters.AddWithValue("@idGiaoDich", txbMaGD.Text);
                        sua.Parameters.AddWithValue("@maSach",maSach);
                        sua.Parameters.AddWithValue("@maDG", maDG);
                        sua.Parameters.AddWithValue("@ngayMuon", dtpNgayMuon.Value);
                        sua.Parameters.AddWithValue("@ngayHenTra", dtpNgayHen.Value);
                        sua.Parameters.AddWithValue("@ngayTraThuc",dtpNgayTra.Value);
                        sua.Parameters.AddWithValue("@phiTreHen", txbPhi.Text);

                        int check = (int)sua.ExecuteNonQuery();
                        if(check > 0)
                        {
                            MessageBox.Show("Sua thanh cong");
                            txbMaGD.Clear();
                            txbPhi.Clear();
                            cbbMaDG.Text = "";
                            cbbMaSach.Text = "";
                            dtpNgayHen.Value = DateTime.Today;
                            dtpNgayMuon.Value = DateTime.Today;
                            dtpNgayTra.Value = DateTime.Today;
                            LoadData();
                            return;
                        }
                        else 
                        {
                           
                            MessageBox.Show("Sua that bai");
                            txbPhi.Clear();
                            cbbMaDG.Text = "";
                            cbbMaSach.Text = "";
                            dtpNgayHen.Value = DateTime.Today;
                            dtpNgayMuon.Value = DateTime.Today;
                            dtpNgayTra.Value = DateTime.Today;
                            
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi " + ex.Message);
            }
            finally
            {
                ketNoi.Close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            try
            {
                ketNoi.Open();
                if (txbMaGD.Text == "")
                {
                    MessageBox.Show("Khong de trong ma giao dich");
                    return;
                }
                using (SqlCommand kt = new SqlCommand("select count (*) from giaoDich where idGiaoDich = @idGiaoDich",ketNoi))
                {
                    kt.Parameters.AddWithValue("@idGiaoDich",txbMaGD.Text);
                    int ktra = (int)kt.ExecuteScalar();
                    if (ktra == 0)
                    {
                        MessageBox.Show("Ma ban vua nhap khong ton tai");
                        return;
                    }
                    using(SqlCommand xoa = new SqlCommand("delete giaoDich where idGiaoDich = @idGiaoDich", ketNoi))
                    {
                        
                        xoa.Parameters.AddWithValue("@idGiaoDich", txbMaGD.Text);
                        int check = (int)xoa.ExecuteNonQuery();
                        if(check != 0)
                        {
                            MessageBox.Show("Xoa thanh cong");
                            txbMaGD.Clear();
                            txbPhi.Clear();
                            cbbMaDG.Text = "";
                            cbbMaSach.Text = "";
                            dtpNgayHen.Value = DateTime.Today;
                            dtpNgayMuon.Value = DateTime.Today;
                            dtpNgayTra.Value = DateTime.Today;
                            LoadData();
                            return;
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
                MessageBox.Show("Loi " + ex.Message);
            }
        }
    }
}
