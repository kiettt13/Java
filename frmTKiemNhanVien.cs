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
    public partial class frmTKiemNhanVien : Form
    {
        string chuoiKN = @"Data source = .; database = QLTV; integrated security = SSPI";
        public frmTKiemNhanVien()
        {
            InitializeComponent();
        }
        private void chucVuLoad()
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            ketNoi.Open();
            using (SqlCommand ht = new SqlCommand("select distinct chucVu from nhanVien", ketNoi))
            {
                SqlDataReader doc = ht.ExecuteReader();
                while (doc.Read())
                {
                    cbbChuVu.Items.Add(doc["chucVu"].ToString());
                }
                doc.Close();
            }
            
        }
        private void rdbtnTen_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbtnTen.Checked)
            {
                txbTen.Enabled = true;
                cbbChuVu.Enabled = false;
                cbbChuVu.Text = "";
            }
        }

        private void rdbtnChuVu_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbtnChuVu.Checked)
            {
                txbTen.Enabled = false;
                cbbChuVu.Enabled = true;
                txbTen.Clear();
            }
        }

        private void btnRS_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTKiemNhanVien_Load(object sender, EventArgs e)
        {
            rdbtnChuVu.Checked = false;
            rdbtnTen.Checked = false;
            chucVuLoad();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            rdbtnTen.Checked = false;
            rdbtnChuVu.Checked = false;
            txbTen.Enabled = true;
            cbbChuVu.Enabled = true;
            cbbChuVu.Text = "";
            txbTen.Clear();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            try
            {
                ketNoi.Open();
                if (rdbtnTen.Checked)
                {
                    using (SqlCommand tim = new SqlCommand("select * from nhanVien where tenNhanVien like @tenNhanVien",ketNoi))
                    {
                        tim.Parameters.AddWithValue("@tenNhanVien", "%" + txbTen.Text.Trim() + "%");
                        SqlDataAdapter da = new SqlDataAdapter(tim);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvKQ.DataSource = dt;
                        dgvKQ.Show();
                    }
                }
                else if (rdbtnChuVu.Checked)
                {
                    using(SqlCommand tim = new SqlCommand("select * from nhanVien where chucVu = @chucVu", ketNoi))
                    {
                        tim.Parameters.AddWithValue("@chucVu",cbbChuVu.SelectedItem.ToString());
                        SqlDataAdapter da = new SqlDataAdapter(tim);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvKQ.DataSource= dt;
                        dgvKQ.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Vui long chon 1 trong 2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi " + ex.Message);
            }
        }
    }
}
