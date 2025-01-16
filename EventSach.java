package demo.event;

import demo.view.ViewSach;

import javax.swing.*;
import javax.swing.event.ListSelectionEvent;
import javax.swing.event.ListSelectionListener;
import javax.swing.table.DefaultTableModel;
import java.sql.*;
import java.text.SimpleDateFormat;
import java.util.Date;

public class EventSach {
    private ViewSach viewSach;

    public EventSach(ViewSach viewSach) {
        this.viewSach = viewSach;
        addEventListeners();
        viewSach.getTable().getSelectionModel().addListSelectionListener(new ListSelectionListener() {
            @Override
            public void valueChanged(ListSelectionEvent e) {
                int selectedRow = viewSach.getTable().getSelectedRow();
                if (selectedRow != -1) {
                    // Cập nhật các trường văn bản với dữ liệu từ dòng được chọn
                    String maSach = viewSach.getTable().getValueAt(selectedRow, 0).toString();
                    String tenSach = viewSach.getTable().getValueAt(selectedRow, 1).toString();
                    String tacGia = viewSach.getTable().getValueAt(selectedRow, 2).toString();
                    String theLoai = viewSach.getTable().getValueAt(selectedRow, 3).toString();
                    String nhaXuatBan = viewSach.getTable().getValueAt(selectedRow, 4).toString();
                    String viTriTV = viewSach.getTable().getValueAt(selectedRow, 5).toString();
                    String namXuatBan = viewSach.getTable().getValueAt(selectedRow, 6).toString();
                    String soLuong = viewSach.getTable().getValueAt(selectedRow, 7).toString();

                    // Đặt dữ liệu vào các trường văn bản
                    viewSach.getTxbIDSach().setText(maSach);
                    viewSach.getTxbTenSach().setText(tenSach);
                    viewSach.getTxbTacGia().setText(tacGia);
                    viewSach.getTxbTheLoai().setText(theLoai);
                    viewSach.getTxbNXB().setText(nhaXuatBan);
                    viewSach.getTxbViTri().setText(viTriTV);
                    viewSach.getTxbSL().setText(soLuong);

                    // Đặt giá trị năm xuất bản vào date picker
                    try {
                        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
                        Date date = sdf.parse(namXuatBan);
                        viewSach.getSpnNamXuatBan().setValue(date);
                    } catch (Exception ex) {
                        // Nếu có lỗi khi phân tích ngày tháng, sẽ giữ lại giá trị cũ
                        System.err.println("Lỗi khi chuyển đổi năm xuất bản: " + ex.getMessage());
                    }
                }
            }
        });

    }


    private void addEventListeners() {
        // Add event listeners for the buttons
        viewSach.btnThemSach.addActionListener(e -> btnThem_Click());
        viewSach.btnSuaSach.addActionListener(e -> btnSua_Click());
        viewSach.btnXoaSach.addActionListener(e -> btnXoa_Click());
        viewSach.btnRS.addActionListener(e -> btnRS_Click());
        viewSach.btnThoatSach.addActionListener(e -> btnThoat_Click());
    }

    public void btnThem_Click() {
        // Handle Add Button Click logic
        String maSach = viewSach.getTxbIDSach().getText();
        String tenSach = viewSach.getTxbTenSach().getText();
        String tacGia = viewSach.getTxbTacGia().getText();
        String theLoai = viewSach.getTxbTheLoai().getText();
        String nhaXuatBan = viewSach.getTxbNXB().getText();
        String viTriTV = viewSach.getTxbViTri().getText();
        String soluong = viewSach.getTxbSL().getText();
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
        String namXuatBan = sdf.format(viewSach.getSpnNamXuatBan().getValue());

        // Check if the fields are empty
        if (maSach.isEmpty() || tenSach.isEmpty() || tacGia.isEmpty() || theLoai.isEmpty() || nhaXuatBan.isEmpty() || viTriTV.isEmpty() || soluong.isEmpty()) {
            JOptionPane.showMessageDialog(viewSach, "Vui lòng điền đầy đủ thông tin", "Thông báo", JOptionPane.WARNING_MESSAGE);
            return;
        }

        // Database connection
        String url = "jdbc:mysql://localhost:3306/qltv";
        String user = "root";
        String password = "123456";

        try (Connection conn = DriverManager.getConnection(url, user, password)) {
            String sql = "INSERT INTO sach (maSach, tenSach, tacGia, theLoai, nhaXuatBan, viTriTV, namXuatBan, soLuong) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
            PreparedStatement stmt = conn.prepareStatement(sql);
            stmt.setString(1, maSach);
            stmt.setString(2, tenSach);
            stmt.setString(3, tacGia);
            stmt.setString(4, theLoai);
            stmt.setString(5, nhaXuatBan);
            stmt.setString(6, viTriTV);
            stmt.setString(7, namXuatBan);
            stmt.setInt(8, Integer.parseInt(soluong));

            int rowsAffected = stmt.executeUpdate();

            if (rowsAffected > 0) {
                JOptionPane.showMessageDialog(viewSach, "Thêm sách thành công!", "Thông báo", JOptionPane.INFORMATION_MESSAGE);
                DefaultTableModel model = (DefaultTableModel) viewSach.getTable().getModel();
                model.addRow(new Object[]{maSach, tenSach, tacGia, theLoai, nhaXuatBan, viTriTV, namXuatBan, soluong});
                btnRS_Click(); // Reset fields after successful addition
            } else {
                JOptionPane.showMessageDialog(viewSach, "Lỗi khi thêm sách", "Lỗi", JOptionPane.ERROR_MESSAGE);
            }
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(viewSach, "Lỗi kết nối cơ sở dữ liệu: " + e.getMessage(), "Lỗi", JOptionPane.ERROR_MESSAGE);
            e.printStackTrace();
        }
    }

    public void btnSua_Click() {
        // Handle Edit Button Click logic
        int selectedRow = viewSach.getTable().getSelectedRow();
        if (selectedRow != -1) {
            String maSach = viewSach.getTxbIDSach().getText();
            String tenSach = viewSach.getTxbTenSach().getText();
            String tacGia = viewSach.getTxbTacGia().getText();
            String theLoai = viewSach.getTxbTheLoai().getText();
            String nhaXuatBan = viewSach.getTxbNXB().getText();
            String viTriTV = viewSach.getTxbViTri().getText();
            String soluong = viewSach.getTxbSL().getText();
            String namXuatBan = new SimpleDateFormat("yyyy-MM-dd").format(viewSach.getSpnNamXuatBan().getValue());

            String url = "jdbc:mysql://localhost:3306/qltv";
            String user = "root";
            String password = "123456";

            try (Connection conn = DriverManager.getConnection(url, user, password)) {
                String sql = "UPDATE sach SET tenSach = ?, tacGia = ?, theLoai = ?, nhaXuatBan = ?, viTriTV = ?, namXuatBan = ?, soLuong = ? WHERE maSach = ?";
                PreparedStatement stmt = conn.prepareStatement(sql);
                stmt.setString(1, tenSach);
                stmt.setString(2, tacGia);
                stmt.setString(3, theLoai);
                stmt.setString(4, nhaXuatBan);
                stmt.setString(5, viTriTV);
                stmt.setString(6, namXuatBan);
                stmt.setInt(7, Integer.parseInt(soluong));
                stmt.setString(8, maSach);

                int rowsAffected = stmt.executeUpdate();
                if (rowsAffected > 0) {
                    JOptionPane.showMessageDialog(viewSach, "Sửa sách thành công!", "Thông báo", JOptionPane.INFORMATION_MESSAGE);
                    // Update table
                    DefaultTableModel model = (DefaultTableModel) viewSach.getTable().getModel();
                    model.setValueAt(tenSach, selectedRow, 1);
                    model.setValueAt(tacGia, selectedRow, 2);
                    model.setValueAt(theLoai, selectedRow, 3);
                    model.setValueAt(nhaXuatBan, selectedRow, 4);
                    model.setValueAt(viTriTV, selectedRow, 5);
                    model.setValueAt(namXuatBan, selectedRow, 6);
                    model.setValueAt(soluong, selectedRow, 7);
                } else {
                    JOptionPane.showMessageDialog(viewSach, "Lỗi khi sửa sách", "Lỗi", JOptionPane.ERROR_MESSAGE);
                }
            } catch (SQLException e) {
                JOptionPane.showMessageDialog(viewSach, "Lỗi kết nối cơ sở dữ liệu: " + e.getMessage(), "Lỗi", JOptionPane.ERROR_MESSAGE);
                e.printStackTrace();
            }
        } else {
            JOptionPane.showMessageDialog(viewSach, "Vui lòng chọn sách để sửa!", "Thông báo", JOptionPane.WARNING_MESSAGE);
        }
    }

    public void btnXoa_Click() {
        // Handle Delete Button Click logic
        int selectedRow = viewSach.getTable().getSelectedRow();
        if (selectedRow != -1) {
            String maSach = (String) viewSach.getTable().getValueAt(selectedRow, 0);
            String url = "jdbc:mysql://localhost:3306/qltv";
            String user = "root";
            String password = "123456";

            try (Connection conn = DriverManager.getConnection(url, user, password)) {
                String sql = "DELETE FROM sach WHERE maSach = ?";
                PreparedStatement stmt = conn.prepareStatement(sql);
                stmt.setString(1, maSach);

                int rowsAffected = stmt.executeUpdate();
                if (rowsAffected > 0) {
                    JOptionPane.showMessageDialog(viewSach, "Xóa sách thành công!", "Thông báo", JOptionPane.INFORMATION_MESSAGE);
                    DefaultTableModel model = (DefaultTableModel) viewSach.getTable().getModel();
                    model.removeRow(selectedRow);
                } else {
                    JOptionPane.showMessageDialog(viewSach, "Lỗi khi xóa sách", "Lỗi", JOptionPane.ERROR_MESSAGE);
                }
            } catch (SQLException e) {
                JOptionPane.showMessageDialog(viewSach, "Lỗi kết nối cơ sở dữ liệu: " + e.getMessage(), "Lỗi", JOptionPane.ERROR_MESSAGE);
                e.printStackTrace();
            }
        } else {
            JOptionPane.showMessageDialog(viewSach, "Vui lòng chọn sách để xóa!", "Thông báo", JOptionPane.WARNING_MESSAGE);
        }
    }

    public void btnRS_Click() {
        // Reset all text fields and the date picker
        viewSach.getTxbIDSach().setText("");
        viewSach.getTxbTenSach().setText("");
        viewSach.getTxbTacGia().setText("");
        viewSach.getTxbNXB().setText("");
        viewSach.getTxbTheLoai().setText("");
        viewSach.getTxbViTri().setText("");
        viewSach.getTxbSL().setText("");
        viewSach.getSpnNamXuatBan().setValue(new Date());
    }

    public void btnThoat_Click() {
        // Exit the application
        System.exit(0);
    }
}
