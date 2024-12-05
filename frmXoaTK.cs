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
    public partial class frmXoaTK : Form
    {
        string chuoiKN = @"data source = . ; database = QLTV ;integrated security = SSPI";
        public frmXoaTK()
        {
            InitializeComponent();
        }
        private void LoadData ()
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            try
            {
                ketNoi.Open ();
                SqlDataAdapter da = new SqlDataAdapter("select * from dangNhap",ketNoi);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvHT.DataSource = dt;

                ketNoi.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi ket noi " +  ex.Message);
            }
        }
        private void frmXoaTK_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection (chuoiKN);
            try
            {
                ketNoi.Open ();
                SqlCommand kt = new SqlCommand("select count(*) from dangNhap where maDangNhap = @maDangNhap", ketNoi);
                kt.Parameters.AddWithValue("@maDangNhap", txbTenTK.Text);
                int ktra = (int)kt.ExecuteScalar();
                if (ktra == 0)
                {
                    MessageBox.Show("Ten dang nhap khong co trong he thong");
                    return;
                }
                SqlCommand xoa = new SqlCommand("delete dangNhap where maDangNhap = @maDangNhap", ketNoi);
                xoa.Parameters.AddWithValue("@maDangNhap",txbTenTK.Text);
                int check = (int)xoa.ExecuteNonQuery();
                if (check != 0)
                {
                    MessageBox.Show("Xoa thanh cong!!");
                    txbTenTK.Clear();
                    LoadData();
                    return;
                }
                else
                {
                    MessageBox.Show("Xoa that bai!!");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi ket noi " + ex.Message);
            }
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            frmTaoTK tao = new frmTaoTK();
            this.Hide();
            tao.ShowDialog();
        }

        private void dgvHT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                DataGridViewRow ht = dgvHT.Rows[e.RowIndex];
                if (ht.Cells["maDangNhap"].Value != null)
                {
                    txbTenTK.Text = ht.Cells["maDangNhap"].Value.ToString();
                }
            }
        }
    }
}
