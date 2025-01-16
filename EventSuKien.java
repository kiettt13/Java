package demo.event;

import demo.view.ViewSuKien;

import javax.swing.*;
import javax.swing.event.ListSelectionEvent;
import javax.swing.event.ListSelectionListener;
import javax.swing.table.DefaultTableModel;
import java.sql.*;
import java.text.SimpleDateFormat;
import java.util.Date;

public class EventSuKien {
    private ViewSuKien viewSuKien;

    public EventSuKien(ViewSuKien viewSuKien) {
        this.viewSuKien = viewSuKien;
        addEventListeners();
        viewSuKien.getTable().getSelectionModel().addListSelectionListener(new ListSelectionListener() {
            @Override
            public void valueChanged(ListSelectionEvent e) {
                int selectedRow = viewSuKien.getTable().getSelectedRow();
                if (selectedRow != -1) {
                    // Cập nhật các trường văn bản với dữ liệu từ dòng được chọn
                    String idSuKien = viewSuKien.getTable().getValueAt(selectedRow, 0).toString();
                    String tenSuKien = viewSuKien.getTable().getValueAt(selectedRow, 1).toString();
                    String ngayToChuc = viewSuKien.getTable().getValueAt(selectedRow, 5).toString();
                    String gioToChuc = viewSuKien.getTable().getValueAt(selectedRow, 4).toString();
                    String moTaSuKien = viewSuKien.getTable().getValueAt(selectedRow, 2).toString();
                    String diaDiemToChuc = viewSuKien.getTable().getValueAt(selectedRow, 3).toString();

                    // Đặt dữ liệu vào các trường văn bản
                    viewSuKien.getTxbIDSuKien().setText(idSuKien);
                    viewSuKien.getTxbTenSuKien().setText(tenSuKien);
                    try {
                        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
                        Date date = sdf.parse(ngayToChuc);
                        viewSuKien.getSpnNgay().setValue(date);
                    } catch (Exception ex) {
                        System.err.println("Lỗi khi chuyển đổi ngày tháng: " + ex.getMessage());
                    }
                    viewSuKien.getTxbMoTa().setText(moTaSuKien);
                    viewSuKien.getTxbGio().setText(gioToChuc);
                    viewSuKien.getTxbDiaDiem().setText(diaDiemToChuc);
                }
            }
        });
    }

    private void addEventListeners() {
        viewSuKien.btnThemSuKien.addActionListener(e -> btnThem_Click());
        viewSuKien.btnSuaSuKien.addActionListener(e -> btnSua_Click());
        viewSuKien.btnXoaSuKien.addActionListener(e -> btnXoa_Click());
        viewSuKien.btnRS.addActionListener(e -> btnRS_Click());
        viewSuKien.btnThoatSuKien.addActionListener(e -> btnThoat_Click());
    }

    public void btnThem_Click() {
        String idSuKien = viewSuKien.getTxbIDSuKien().getText();
        String tenSuKien = viewSuKien.getTxbTenSuKien().getText();
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
        String ngayToChuc = sdf.format(viewSuKien.getSpnNgay().getValue());
        String gioToChuc = viewSuKien.getTxbGio().getText();
        String moTaSuKien = viewSuKien.getTxbMoTa().getText();
        String diaDiemToChuc = viewSuKien.getTxbDiaDiem().getText();

        if (idSuKien.isEmpty() || tenSuKien.isEmpty() || gioToChuc.isEmpty() || moTaSuKien.isEmpty() || diaDiemToChuc.isEmpty()) {
            JOptionPane.showMessageDialog(viewSuKien, "Vui lòng điền đầy đủ thông tin", "Thông báo", JOptionPane.WARNING_MESSAGE);
            return;
        }

        String url = "jdbc:mysql://localhost:3306/qltv";
        String user = "root";
        String password = "123456";

        try (Connection conn = DriverManager.getConnection(url, user, password)) {
            String sql = "INSERT INTO sukien (idSuKien, tenSuKien, moTaSuKien, ngayToChuc, gioToChuc, diaDiemToChuc) VALUES (?, ?, ?, ?, ?, ?)";
            PreparedStatement pst = conn.prepareStatement(sql);
            pst.setString(1, idSuKien);
            pst.setString(2, tenSuKien);
            pst.setString(3, moTaSuKien);
            pst.setString(4, ngayToChuc);
            pst.setString(5, gioToChuc);
            pst.setString(6, diaDiemToChuc);

            int rowsAffected = pst.executeUpdate();
            if (rowsAffected > 0) {
                JOptionPane.showMessageDialog(viewSuKien, "Thêm sự kiện thành công!", "Thông báo", JOptionPane.INFORMATION_MESSAGE);
                DefaultTableModel model = (DefaultTableModel) viewSuKien.getTable().getModel();
                model.addRow(new Object[]{idSuKien, tenSuKien, moTaSuKien,diaDiemToChuc, gioToChuc,  ngayToChuc});
                btnRS_Click(); // Reset fields after success
            } else {
                JOptionPane.showMessageDialog(viewSuKien, "Lỗi khi thêm sự kiện", "Lỗi", JOptionPane.ERROR_MESSAGE);
            }
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(viewSuKien, "Lỗi kết nối cơ sở dữ liệu: " + e.getMessage(), "Lỗi", JOptionPane.ERROR_MESSAGE);
            e.printStackTrace();
        }
    }

    public void btnSua_Click() {
        int selectedRow = viewSuKien.getTable().getSelectedRow();
        if (selectedRow != -1) {
            String idSuKien = viewSuKien.getTxbIDSuKien().getText();
            String tenSuKien = viewSuKien.getTxbTenSuKien().getText();
            String moTaSuKien = viewSuKien.getTxbMoTa().getText();
            String diaDiemToChuc = viewSuKien.getTxbDiaDiem().getText();
            String gioToChuc = viewSuKien.getTxbGio().getText();
            String ngayToChuc = new SimpleDateFormat("yyyy-MM-dd").format(viewSuKien.getSpnNgay().getValue());

            String url = "jdbc:mysql://localhost:3306/qltv";
            String user = "root";
            String password = "123456";

            try (Connection conn = DriverManager.getConnection(url, user, password)) {
                String sql = "UPDATE sukien SET tenSuKien = ?, moTaSuKien = ?, diaDiemToChuc = ?, gioToChuc = ?, ngayToChuc = ? WHERE idSuKien = ?";
                PreparedStatement pst = conn.prepareStatement(sql);

                pst.setString(1, tenSuKien);
                pst.setString(2, moTaSuKien);
                pst.setString(3, diaDiemToChuc);
                pst.setString(4, gioToChuc);
                pst.setString(5, ngayToChuc);
                pst.setString(6, idSuKien);

                pst.executeUpdate();

                DefaultTableModel model = (DefaultTableModel) viewSuKien.getTable().getModel();
                model.setValueAt(idSuKien, selectedRow, 0);
                model.setValueAt(tenSuKien, selectedRow, 1);
                model.setValueAt(moTaSuKien, selectedRow, 2);
                model.setValueAt(diaDiemToChuc, selectedRow, 3);
                model.setValueAt(gioToChuc, selectedRow, 4);
                model.setValueAt(ngayToChuc, selectedRow, 5);

                JOptionPane.showMessageDialog(viewSuKien, "Sửa sự kiện thành công!", "Thông báo", JOptionPane.INFORMATION_MESSAGE);
            } catch (SQLException e) {
                JOptionPane.showMessageDialog(viewSuKien, "Lỗi khi sửa sự kiện: " + e.getMessage(), "Lỗi", JOptionPane.ERROR_MESSAGE);
                e.printStackTrace();
            }
        }
    }

    public void btnXoa_Click() {
        int selectedRow = viewSuKien.getTable().getSelectedRow();
        if (selectedRow != -1) {
            String idSuKien = (String) viewSuKien.getTable().getValueAt(selectedRow, 0);

            String url = "jdbc:mysql://localhost:3306/qltv";
            String user = "root";
            String password = "123456";

            try (Connection conn = DriverManager.getConnection(url, user, password)) {
                String sql = "DELETE FROM sukien WHERE idSuKien = ?";
                PreparedStatement stmt = conn.prepareStatement(sql);
                stmt.setString(1, idSuKien);
                stmt.executeUpdate();

                DefaultTableModel model = (DefaultTableModel) viewSuKien.getTable().getModel();
                model.removeRow(selectedRow);

                JOptionPane.showMessageDialog(viewSuKien, "Xóa sự kiện thành công!", "Thông báo", JOptionPane.INFORMATION_MESSAGE);
            } catch (SQLException e) {
                JOptionPane.showMessageDialog(viewSuKien, "Lỗi khi xóa sự kiện: " + e.getMessage(), "Lỗi", JOptionPane.ERROR_MESSAGE);
                e.printStackTrace();
            }
        } else {
            JOptionPane.showMessageDialog(viewSuKien, "Vui lòng chọn sự kiện để xóa!", "Thông báo", JOptionPane.WARNING_MESSAGE);
        }
    }

    public void btnRS_Click() {
        viewSuKien.getTxbIDSuKien().setText("");
        viewSuKien.getTxbTenSuKien ().setText("");
        viewSuKien.getTxbMoTa().setText("");
        viewSuKien.getTxbDiaDiem().setText("");
        viewSuKien.getTxbGio().setText("");
        viewSuKien.getSpnNgay().setValue(new Date());
    }

    public void btnThoat_Click() {
        System.exit(0);
    }
}
