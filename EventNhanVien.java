package demo.event;

import demo.view.ViewNhanVien;
import javax.swing.*;
import javax.swing.event.ListSelectionEvent;
import javax.swing.event.ListSelectionListener;
import javax.swing.table.DefaultTableModel;
import java.sql.*;

public class EventNhanVien {
    private ViewNhanVien view;

    private String url = "jdbc:mysql://localhost:3306/qltv"; // Địa chỉ cơ sở dữ liệu
    private String user = "root"; // Tên đăng nhập
    private String password = "123456"; // Mật khẩu

    public EventNhanVien(ViewNhanVien view) {
        this.view = view;
        addEventListeners();
        view.getTable().getSelectionModel().addListSelectionListener(new ListSelectionListener() {
            @Override
            public void valueChanged(ListSelectionEvent e) {
                int selectedRow = view.getTable().getSelectedRow();
                if (selectedRow != -1) {
                    // Cập nhật các trường văn bản với dữ liệu từ dòng được chọn
                    String idNhanVien = view.getTable().getValueAt(selectedRow, 0).toString();
                    String tenNhanVien = view.getTable().getValueAt(selectedRow, 1).toString();
                    String chucVu = view.getTable().getValueAt(selectedRow, 2).toString();
                    String khuVuc = view.getTable().getValueAt(selectedRow, 3).toString();
                    String sdt = view.getTable().getValueAt(selectedRow, 4).toString();
                    String email = view.getTable().getValueAt(selectedRow, 5).toString();
                    String diaChi = view.getTable().getValueAt(selectedRow, 6).toString();

                    // Đặt dữ liệu vào các trường văn bản
                    view.getTxbMaNV().setText(idNhanVien);
                    view.getTxbTenNV().setText(tenNhanVien);
                    view.getTxbChucVu().setText(chucVu);
                    view.getTxbKhuVuc().setText(khuVuc);
                    view.getTxbSDT().setText(sdt);
                    view.getTxbEmail().setText(email);
                    view.getTxbDiaChi().setText(diaChi);
                }
            }
        });
    }

    private void addEventListeners() {
        view.btnThem.addActionListener(e -> addEmployee());
        view.btnSua.addActionListener(e -> updateEmployee());
        view.btnXoa.addActionListener(e -> deleteEmployee());
        view.btnRS.addActionListener(e -> resetFields());
        view.btnThoat.addActionListener(e -> exitForm());
    }

    private void addEmployee() {
        String idNhanVien = view.getTxbMaNV().getText();
        String tenNhanVien = view.getTxbTenNV().getText();
        String chucVu = view.getTxbChucVu().getText();
        String khuVuc = view.getTxbKhuVuc().getText();
        String sdt = view.getTxbSDT().getText();
        String email = view.getTxbEmail().getText();
        String diaChi = view.getTxbDiaChi().getText();

        if (idNhanVien.isEmpty() || tenNhanVien.isEmpty() || chucVu.isEmpty() || khuVuc.isEmpty() || sdt.isEmpty() || email.isEmpty() || diaChi.isEmpty()) {
            JOptionPane.showMessageDialog(view, "Vui lòng điền đầy đủ thông tin!", "Thông báo", JOptionPane.WARNING_MESSAGE);
            return;
        }

        try (Connection conn = DriverManager.getConnection(url, user, password)) {
            String sql = "INSERT INTO nhanvien (idNhanVien, tenNhanVien, chucVu, khuVuc, sdtNhanVien, emailNhanVien, diaChiNhanVien) VALUES (?, ?, ?, ?, ?, ?, ?)";
            PreparedStatement stmt = conn.prepareStatement(sql);
            stmt.setString(1, idNhanVien);
            stmt.setString(2, tenNhanVien);
            stmt.setString(3, chucVu);
            stmt.setString(4, khuVuc);
            stmt.setString(5, sdt);
            stmt.setString(6, email);
            stmt.setString(7, diaChi);

            int rowsAffected = stmt.executeUpdate();

            if (rowsAffected > 0) {
                JOptionPane.showMessageDialog(view, "Thêm nhân viên thành công!", "Thông báo", JOptionPane.INFORMATION_MESSAGE);
                DefaultTableModel model = (DefaultTableModel) view.getTable().getModel();
                model.addRow(new Object[]{idNhanVien, tenNhanVien, chucVu, khuVuc, sdt, email, diaChi});
                resetFields();
            }
        } catch (SQLException ex) {
            ex.printStackTrace();
            JOptionPane.showMessageDialog(view, "Lỗi khi thêm nhân viên: " + ex.getMessage(), "Lỗi", JOptionPane.ERROR_MESSAGE);
        }
    }

    private void updateEmployee() {
        int selectedRow = view.getTable().getSelectedRow();
        if (selectedRow != -1) {
            try (Connection conn = DriverManager.getConnection(url, user, password)) {
                String sql = "UPDATE nhanvien SET tenNhanVien = ?, chucVu = ?, khuVuc = ?, sdtNhanVien = ?, emailNhanVien = ?, diaChiNhanVien = ? WHERE idNhanVien = ?";
                PreparedStatement stmt = conn.prepareStatement(sql);
                stmt.setString(1, view.getTxbTenNV().getText());
                stmt.setString(2, view.getTxbChucVu().getText());
                stmt.setString(3, view.getTxbKhuVuc().getText());
                stmt.setString(4, view.getTxbSDT().getText());
                stmt.setString(5, view.getTxbEmail().getText());
                stmt.setString(6, view.getTxbDiaChi().getText());
                stmt.setString(7, view.getTxbMaNV().getText());

                int rowsAffected = stmt.executeUpdate();

                if (rowsAffected > 0) {
                    JOptionPane.showMessageDialog(view, "Sửa thông tin thành công!", "Thông báo", JOptionPane.INFORMATION_MESSAGE);
                    DefaultTableModel model = (DefaultTableModel) view.getTable().getModel();
                    model.setValueAt(view.getTxbTenNV().getText(), selectedRow, 1);
                    model.setValueAt(view.getTxbChucVu().getText(), selectedRow, 2);
                    model.setValueAt(view.getTxbKhuVuc().getText(), selectedRow, 3);
                    model.setValueAt(view.getTxbSDT().getText(), selectedRow, 4);
                    model.setValueAt(view.getTxbEmail().getText(), selectedRow, 5);
                    model.setValueAt(view.getTxbDiaChi().getText(), selectedRow, 6);
                }
            } catch (SQLException ex) {
                ex.printStackTrace();
                JOptionPane.showMessageDialog(view, "Lỗi khi sửa nhân viên", "Lỗi", JOptionPane.ERROR_MESSAGE);
            }
        }
    }

    private void deleteEmployee() {
        int selectedRow = view.getTable().getSelectedRow();
        if (selectedRow != -1) {
            String idNhanVien = (String) view.getTable().getValueAt(selectedRow, 0);
            try (Connection conn = DriverManager.getConnection(url, user, password)) {
                String sql = "DELETE FROM nhanvien WHERE idNhanVien = ?";
                PreparedStatement stmt = conn.prepareStatement(sql);
                stmt.setString(1, idNhanVien);
                stmt.executeUpdate();

                DefaultTableModel model = (DefaultTableModel) view.getTable().getModel();
                model.removeRow(selectedRow);
            } catch (SQLException ex) {
                ex.printStackTrace();
                JOptionPane.showMessageDialog(view, "Lỗi khi xóa nhân viên", "Lỗi", JOptionPane.ERROR_MESSAGE);
            }
        }
    }

    private void resetFields() {
        view.getTxbMaNV().setText("");
        view.getTxbTenNV().setText("");
        view.getTxbChucVu().setText("");
        view.getTxbKhuVuc().setText("");
        view.getTxbSDT().setText("");
        view.getTxbEmail().setText("");
        view.getTxbDiaChi().setText("");
    }

    private void exitForm() {
        // Logic để thoát khỏi form (nếu cần)
    }
}
