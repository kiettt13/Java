using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeMoDoAn
{

    public partial class frmDocGia : Form
    {
        string chuoiKN = @"Data Source = . ; Database = QLTV; Integrated Security =SSPI";
        private int maTuDong = 0;
        public frmDocGia()
        {
            InitializeComponent();
        }
        public static bool IsEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            string strRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Regex regex = new Regex(strRegex);

            return regex.IsMatch(email);
        }
        private void btnThoatSach_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadData()
        {
            
            using (SqlConnection ketNoi = new SqlConnection(chuoiKN))
            {
                try
                {
                    ketNoi.Open();

                    SqlDataAdapter dt = new SqlDataAdapter("Select * from docGia", ketNoi);
                    DataTable dtb = new DataTable();
                    dt.Fill(dtb);
                    dgvDocGia.DataSource = dtb;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Loi data girdview " + ex.Message);
                }
            }
        }
        private void btnThemSach_Click(object sender, EventArgs e)
        {

            SqlConnection ketNoi = new SqlConnection(chuoiKN);

            try
            {
                ketNoi.Open();

                using (SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM docGia", ketNoi))
                {
                    maTuDong = (int)cmdCount.ExecuteScalar() + 1;
                }

                string maDG = $"DG{maTuDong:D6}";

                using (SqlCommand kt = new SqlCommand("select count (*) from docGia where idDocGia = @idDocGia ", ketNoi))
                {
                    kt.Parameters.AddWithValue("@idDocGia", txbMaDocGia.Text);
                    int exits = (int)kt.ExecuteScalar();

                    if (exits > 0)
                    {
                        MessageBox.Show("Ma doc gia da ton tai!!");
                        txbTenDG.Clear();
                        txbDiaChi.Clear();
                        txbSDT.Clear();
                        txbEmail.Clear();
                        return;
                    }
                }

                using (SqlCommand them = new SqlCommand("insert into docGia (idDocGia, tenDocGia, diaChi, sdtDocGia, emailDocGia) values (@idDocGia, @tenDocGia, @diaChi, @sdtDocGia, @emailDocGia)",ketNoi))
                {
                    them.Parameters.AddWithValue("@idDocGia", txbMaDocGia.Text);
                    them.Parameters.AddWithValue("@tenDocGia", txbTenDG.Text);
                    them.Parameters.AddWithValue("@diaChi", txbDiaChi.Text);
                    them.Parameters.AddWithValue("@sdtDocGia", txbSDT.Text);
                    them.Parameters.AddWithValue("@emailDocGia", txbEmail.Text);

                    int result = them.ExecuteNonQuery();
                    if(result > 0)
                    {
                        MessageBox.Show("Them thanh cong!!");
                        txbTenDG.Focus();
                        txbTenDG.Clear();
                        txbDiaChi.Clear();
                        txbSDT.Clear();
                        txbEmail.Clear();
                        using (SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM docGia", ketNoi))
                        {
                            maTuDong = (int)cmdCount.ExecuteScalar() + 1;
                        }

                        maDG = $"DG{maTuDong:D6}";
                        txbMaDocGia.Text = maDG;
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi " + ex.Message);
            }
        }

        private void frmDocGia_Load(object sender, EventArgs e)
        {
            LoadData();
            txbMaDocGia.Enabled = false;
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            ketNoi.Open();
            using (SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM docGia", ketNoi))
            {
                maTuDong = (int)cmdCount.ExecuteScalar() + 1;
            }

            string maDG = $"DG{maTuDong:D6}";
            txbMaDocGia.Text = maDG;
            ketNoi.Close();
        }

        private void btnSuaSach_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);

            try
            {
                ketNoi.Open();

                if (txbMaDocGia.Text == "")
                {
                    MessageBox.Show("Ban chua nhap ma doc gia ");
                }
                else
                {
                    using (SqlCommand kt = new SqlCommand("select count (*) from docGia where idDocGia = @idDocGia ", ketNoi))
                    {
                        kt.Parameters.AddWithValue("@idDocGia", txbMaDocGia.Text);
                        int exits = (int)kt.ExecuteScalar();

                        if (exits == 0)
                        {
                            MessageBox.Show("Ma doc gia vua nhap khong ton tai");

                            txbTenDG.Clear();
                            txbDiaChi.Clear();
                            txbSDT.Clear();
                            txbEmail.Clear();
                            return;
                        }
                    }

                    string query = "update docGia set tenDocGia = @tenDocGia, diaChi = @diaChi, sdtDocGia = @sdtDocGia, emailDocGia = @emailDocGia where idDocGia = @idDocGia";
                    using (SqlCommand sua = new SqlCommand(query, ketNoi))
                    {
                        sua.Parameters.AddWithValue("@idDocGia", txbMaDocGia.Text);
                        sua.Parameters.AddWithValue("@tenDocGia", txbTenDG.Text);
                        sua.Parameters.AddWithValue("@diaChi", txbDiaChi.Text);
                        sua.Parameters.AddWithValue("@sdtDocGia", txbSDT.Text);
                        sua.Parameters.AddWithValue("@emailDocGia", txbEmail.Text);

                        int result = sua.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Cap nhat thanh cong");
                            txbTenDG.Focus();
                            txbTenDG.Clear();
                            txbDiaChi.Clear();
                            txbSDT.Clear();
                            txbEmail.Clear();
                            using (SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM docGia", ketNoi))
                            {
                                maTuDong = (int)cmdCount.ExecuteScalar() + 1;
                            }

                            string maDG = $"DG{maTuDong:D6}";
                            txbMaDocGia.Text = maDG;
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Khong tim thay ma doc gia vua nhap!!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi sua" + ex.Message);
            }
        }

        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);

            try
            {
                ketNoi.Open();
                if (txbMaDocGia.Text == "")
                {
                    MessageBox.Show("Ban chua nhap ma doc gia ");
                }
                else
                {
                    string del = "delete from docGia where idDocGia = @idDocGia";
                    using (SqlCommand xoa = new SqlCommand(del, ketNoi))
                    {
                        xoa.Parameters.AddWithValue("@idDocGia", txbMaDocGia.Text);

                        int result = xoa.ExecuteNonQuery();
                        if (result != 0)
                        {
                            MessageBox.Show("Xoa thanh cong", "Thong bao");
                            txbTenDG.Focus();
                            txbTenDG.Clear();
                            txbDiaChi.Clear();
                            txbSDT.Clear();
                            txbEmail.Clear();
                            using (SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM docGia", ketNoi))
                            {
                                maTuDong = (int)cmdCount.ExecuteScalar() + 1;
                            }

                            string maDG = $"DG{maTuDong:D6}";
                            txbMaDocGia.Text = maDG;
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Khong tim thay ma doc gia!!");
                        }
                    }
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi xoa" + ex.Message);
            }
        }

        private void dgvDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow ht = dgvDocGia.Rows[e.RowIndex];
                if (ht.Cells["idDocGia"].Value != null)
                {
                    txbMaDocGia.Text = ht.Cells["idDocGia"].Value.ToString();
                    txbTenDG.Text = ht.Cells["tenDocGia"].Value.ToString();
                    txbSDT.Text = ht.Cells["sdtDocGia"].Value.ToString();
                    txbEmail.Text = ht.Cells["emailDocGia"].Value.ToString();
                    txbDiaChi.Text = ht.Cells["diaChi"].Value.ToString();
                }
                else 
                {
                    MessageBox.Show("Ban dang click phai dong trong");
                }
            }
        }

        private void btnRS_Click(object sender, EventArgs e)
        {
            txbMaDocGia.Clear();
            txbTenDG.Clear();
            txbDiaChi.Clear();
            txbSDT.Clear();
            txbEmail.Clear();
        }

        private void txbEmail_TextChanged(object sender, EventArgs e)
        {
            TextBox txtEmail = sender as TextBox;
            if (txtEmail != null)
            {
                string email = txtEmail.Text;
                if (!IsEmail(email))
                {
                    txtEmail.ForeColor = Color.Red;
                }
                else
                {
                    txtEmail.ForeColor = Color.Black;
                }
            }
        }

        private void txbSDT_TextChanged(object sender, EventArgs e)
        {
            TextBox txbSDT = sender as TextBox;
            if (txbSDT != null)
            {
                if (txbSDT.Text.Length > 10)
                {
                    MessageBox.Show("So dien thoai khong vuot qua 10 so");
                    txbSDT.Text = txbSDT.Text.Substring(0, 10);
                    txbSDT.SelectionStart = txbSDT.Text.Length;
                }
            }
        }

        private void txbSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
