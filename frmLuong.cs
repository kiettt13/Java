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
    public partial class frmLuong : Form
    {
        string chuoiKN = @"Data source = . ; database = QLTV ; Integrated security = SSPI";
        public frmLuong()
        {
            InitializeComponent();
        }
        private void ExecuteQueryAndDisplayResult(string query)
        {
            using (SqlConnection connection = new SqlConnection(chuoiKN))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Hiển thị dữ liệu trên form (ví dụ: DataGridView)
                dgvLuong.DataSource = dataTable;
            }

        }
        private void frmLuong_Load(object sender, EventArgs e)
        {

        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            string idNhanVien = txbMa.Text;

            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            // Lấy ngày cuối cùng của tháng hiện tại
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);

            // Khởi tạo chuỗi truy vấn SQL
            string query = $@"SELECT NV.ChucVu, 
                            SUM(CASE WHEN (PM.idNhanVien IS NOT NULL OR PT.idNhanVien IS NOT NULL) THEN 280000 ELSE 0 END) AS Luong
                    FROM nhanVien NV
                    LEFT JOIN phieuMuon PM ON NV.idNhanVien = PM.idNhanVien
                    LEFT JOIN phieuTra PT ON NV.idNhanVien = PT.idNhanVien
                    WHERE NV.idNhanVien = '{idNhanVien}'
                    GROUP BY NV.ChucVu;";

            // Thực hiện truy vấn và hiển thị kết quả
            ExecuteQueryAndDisplayResult(query);
        }
    }
}
