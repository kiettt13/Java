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
using System.Configuration;
using System.Net.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace DeMoDoAn
{
    public partial class frmTKiemDocGia : Form
    {
        string chuoiKN = @"data source = . ; database = QLTV ; integrated security = SSPI";
        public frmTKiemDocGia()
        {
            InitializeComponent();
        }
        private void LoadTK()
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            ketNoi.Open();
            using (SqlCommand tim = new SqlCommand("select * from docGia where idDocGia like @idDocGia", ketNoi))
            {
                tim.Parameters.AddWithValue("@idDocGia","%" + txbMa.Text.Trim() + "%");
                SqlDataAdapter da = new SqlDataAdapter(tim);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvKQ.DataSource = dt;
            }
        }
        private void LoadTen()
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            ketNoi.Open();
            using (SqlCommand tkiem = new SqlCommand("select * from docGia where tenDocGia like @tenDocGia", ketNoi))
            {
                tkiem.Parameters.AddWithValue("@tenDocGia", "%" + txbTen.Text.Trim() + "%");
                SqlDataAdapter da = new SqlDataAdapter(tkiem);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvKQ.DataSource = dt;
            }
        }
        private void LoadData()
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            using (SqlDataAdapter kn = new SqlDataAdapter("select * from docGia", ketNoi))
            {
                DataTable dt = new DataTable();
                kn.Fill(dt);
                dgvKQ.DataSource = dt;
            }
        }
        private void rdbtnMa_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbtnMa.Checked)
            {
                txbMa.Enabled = true;
                txbTen.Enabled = false;
            }
        }

        private void rdbtnTen_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbtnTen.Checked)
            {
                txbTen.Enabled = true;
                txbMa.Enabled = false;
                txbMa.Clear();
            }
        }

        private void btnRS_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txbMa.Clear();
            txbTen.Clear();
            LoadData();
            rdbtnMa.Checked = false;
            rdbtnTen.Checked = false;
            txbMa.Enabled = true;
            txbTen.Enabled = true;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            try
            {
                ketNoi.Open();
                if (rdbtnMa.Checked)
                {
                    LoadTK();
                }
                else if (rdbtnTen.Checked)
                {
                    LoadTen();
                }
                else
                {
                    MessageBox.Show("Vui long chon 1 trong 2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi ket noi" + ex.Message);
            }
        }

        private void frmTKiemDocGia_Load(object sender, EventArgs e)
        {
            txbMa.Focus();
            dgvKQ.Show();
            LoadData();
        }
    }
}
