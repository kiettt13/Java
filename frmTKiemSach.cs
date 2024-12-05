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
    public partial class frmTKiemSach : Form
    {
        string chuoiKN = @"Data source = .; database = QLTV; integrated security = SSPI";
        public frmTKiemSach()
        {
            InitializeComponent();
        }
        private void LoadTen()
        {
            using (SqlConnection ketNoi = new SqlConnection(chuoiKN))
            {
                using (SqlCommand timkiem = new SqlCommand("select maSach, tenSach, tacGia, nhaXuatBan, namXuatBan, theLoai, viTriTV, soLuong from sach where tenSach like @tenSach", ketNoi))
                {
                    timkiem.Parameters.AddWithValue("@tenSach", "%" + txbTen.Text.Trim() + "%");
                    ketNoi.Open();
                    SqlDataAdapter tk = new SqlDataAdapter(timkiem);
                    DataTable dt = new DataTable();
                    tk.Fill(dt);
                    dgvTKSach.DataSource = dt;
                }
            }
        }
        private void LoadTG()
        {
            using (SqlConnection ketNoi = new SqlConnection(chuoiKN))
            {
                using (SqlCommand tk = new SqlCommand("select * from Sach where tacGia like @tacGia", ketNoi))
                {
                    tk.Parameters.AddWithValue("@tacGia", "%" + txbShow.Text.Trim() + "%");
                    try
                    {
                        ketNoi.Open();
                        SqlDataAdapter da = new SqlDataAdapter(tk);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvTKSach.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Loi " + ex.Message);
                    }
                }
            }
        }
        private void LoadTL()
        {
            using (SqlConnection ketNoi = new SqlConnection(chuoiKN))
            {
                string lay = cbbTLoai.SelectedItem.ToString();
                using (SqlCommand tim = new SqlCommand("select maSach, tenSach, tacGia, nhaXuatBan, namXuatBan, theLoai, viTriTV, soLuong from Sach where theLoai=@theLoai", ketNoi))
                {
                    tim.Parameters.AddWithValue("@theLoai", lay);
                    ketNoi.Open();
                    SqlDataAdapter tk = new SqlDataAdapter(tim);
                    DataTable dt = new DataTable();
                    tk.Fill(dt);
                    dgvTKSach.DataSource = dt;
                }
            }
        }
        private void LoadData()
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            using(SqlDataAdapter kn = new SqlDataAdapter("select maSach, tenSach, tacGia, nhaXuatBan, namXuatBan, theLoai, viTriTV, soLuong from sach", ketNoi))
            {
                DataTable dt = new DataTable();
                kn.Fill(dt);
                dgvTKSach.DataSource = dt;
            }
        }
        private void TlLoad()
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            ketNoi.Open();
            using (SqlCommand kn = new SqlCommand("select distinct theLoai from sach", ketNoi))
            {
                SqlDataReader doc = kn.ExecuteReader();
                while(doc.Read())
                {
                    cbbTLoai.Items.Add(doc["theLoai"].ToString());
                }
                doc.Close();
            }
        }
        private void frmTKiemSach_Load(object sender, EventArgs e)
        {
            TlLoad();
        }

        private void btnRS_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnTen.Checked)
            {
                txbShow.Enabled = false;
                txbTen.Enabled = true;
                cbbTLoai.Enabled = false;
                cbbTLoai.Text = "";
                txbShow.Clear();
            }
        }

        private void rdbtnTL_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnTL.Checked)
            {
                txbShow.Enabled = false;
                txbTen.Enabled = false;
                cbbTLoai.Enabled = true;
                txbShow.Clear();
                txbTen.Clear();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if(rdbtnTL.Checked)
            {
                LoadTL();
            }
            else if (rdbtnTen.Checked)
            {
                LoadTen();
            }
            else if (rdbtnTG.Checked)
            {
                LoadTG();
            }
            else
            {
                MessageBox.Show("Vui long chon 1 trong 3 phuong thuc tim kiem");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbbTLoai.Focus();
            txbTen.Clear();
            cbbTLoai.Text = "";
            txbShow.Clear();
            txbShow.Enabled = true;
            txbTen.Enabled = true;
            rdbtnTL.Checked = true;
            cbbTLoai.Enabled = true;
        }

        private void dgvKQ_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvTKSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow ht = dgvTKSach.Rows[e.RowIndex];
                if (ht.Cells[e.RowIndex].Value != DBNull.Value && ht.Cells[e.ColumnIndex].Value != DBNull.Value)
                {
                    txbShow.Text = ht.Cells["maSach"].Value.ToString();
                    txbShow.Text = ht.Cells["tenSach"].Value.ToString();
                }
            }
        }

        private void txbShow_TextChanged(object sender, EventArgs e)
        {

        }

        private void rdbtnTG_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbtnTG.Checked)
            {
                txbTen.Enabled = false;
                cbbTLoai.Enabled = false;
                txbShow.Enabled = true;
                cbbTLoai.Text = "";
                txbTen.Clear();
            }
        }
    }
}
