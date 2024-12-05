using OfficeOpenXml.LoadFunctions.Params;
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
using System.Windows.Media.Effects;

namespace DeMoDoAn
{
    public partial class frmChamCong : Form
    {
        string chuoiKN = @"Data Source = . ; Database = QLTV ; Integrated Security = SSPI";
        public frmChamCong()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            ketNoi.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from chamCong",ketNoi);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvHT.DataSource = dt;
        }
        private void rdbtnDiLam_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbtnDiLam.Checked)
            {
                cbxPhep.Enabled = false;
            }
            else
            {
                cbxPhep.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection ketNoi = new SqlConnection(chuoiKN);
            ketNoi.Open();
            SqlCommand them = new SqlCommand("INSERT INTO chamCong (idNhanVien, ngayDiLam, tinhTrang, phep) VALUES (@idNhanVien, @ngayDiLam, @tinhTrang, @phep)", ketNoi);
            them.Parameters.AddWithValue("@idNhanVien", txbMaNV.Text);
            them.Parameters.AddWithValue("@tinhTrang", txbTT.Text);
            them.Parameters.AddWithValue("@ngayDiLam", dtpNgayLam.Value);

            // Kiểm tra RadioButton "Đi làm"
            if (rdbtnDiLam.Checked)
            {
                them.Parameters.AddWithValue("@phep", DBNull.Value); // Đặt giá trị phép là null
            }
            else // RadioButton "Vắng" được chọn
            {
                // Kiểm tra nếu có phép
                bool coPhep = (cbxPhep.Checked) ? true : false;
                them.Parameters.AddWithValue("@phep", coPhep);
            }

            int check = them.ExecuteNonQuery();
            if (check > 0)
            {
                MessageBox.Show("Thêm thành công");
                LoadData();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }

            ketNoi.Close();
        }

        private void frmChamCong_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
