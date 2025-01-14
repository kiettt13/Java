package frm;

import java.sql.*;

public class frmCSDL {
    // Thông tin kết nối đến MySQL
    private static final String URL = "jdbc:mysql://localhost:3306/QLTV?useSSL=false&allowPublicKeyRetrieval=true"; // Thay đổi tên cơ sở dữ liệu
    private static final String USER = "root"; // Tên người dùng MySQL
    private static final String PASSWORD = "123456"; // Mật khẩu của người dùng

    private Connection connection;

    // Khởi tạo kết nối cơ sở dữ liệu
    public frmCSDL() throws SQLException {
        connection = DriverManager.getConnection(URL, USER, PASSWORD);
    }

    // Phương thức kiểm tra kết nối
    public void testConnection() {
        try {
            if (connection != null && !connection.isClosed()) {
                System.out.println("Kết nối thành công!");
            } else {
                System.out.println("Không thể kết nối!");
            }
        } catch (SQLException e) {
            System.err.println("Lỗi khi kiểm tra kết nối: " + e.getMessage());
        }
    }

    // Phương thức đóng kết nối
    public void closeConnection() {
        try {
            if (connection != null && !connection.isClosed()) {
                connection.close();
                System.out.println("Đóng kết nối thành công.");
            }
        } catch (SQLException e) {
            System.err.println("Lỗi khi đóng kết nối: " + e.getMessage());
        }
    }

    public static void main(String[] args) {
        frmCSDL db = null;
        try {
            db = new frmCSDL();
            db.testConnection();  // Kiểm tra kết nối
        } catch (SQLException e) {
            e.printStackTrace();
        } finally {
            // Đảm bảo đóng kết nối
            if (db != null) {
                db.closeConnection();
            }
        }
    }
}
