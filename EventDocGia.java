package demo.event;

import javax.swing.*;
import javax.swing.event.ListSelectionEvent;
import javax.swing.event.ListSelectionListener;
import javax.swing.table.DefaultTableModel;
import demo.view.ViewDocGia;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.sql.*;

public class EventDocGia {
	private String[] columnNames = {"Mã độc giả", "Tên độc giả", "Số điện thoại", "Email", "Địa chỉ"};
	private String[][] data = {};
    private ViewDocGia viewDocGia;


    public EventDocGia(ViewDocGia viewDocGia) {
        this.viewDocGia = viewDocGia;
        addEventListeners();
        DefaultTableModel model = new DefaultTableModel(data, columnNames);
        viewDocGia.dgvDocGia.setModel(model);

        // Add the table to the JScrollPane
        viewDocGia.scrollPane.setViewportView(viewDocGia.dgvDocGia);

        // Add ListSelectionListener for row selection in the JTable
        viewDocGia.dgvDocGia.getSelectionModel().addListSelectionListener(new ListSelectionListener() {
            @Override
            public void valueChanged(ListSelectionEvent e) {
                int selectedRow = viewDocGia.dgvDocGia.getSelectedRow();
                if (selectedRow != -1) {
                    // Update text fields with selected row data
                    String idDocGia = viewDocGia.dgvDocGia.getValueAt(selectedRow, 0).toString();
                    String tenDocGia = viewDocGia.dgvDocGia.getValueAt(selectedRow, 1).toString();
                    String diaChiDocGia = viewDocGia.dgvDocGia.getValueAt(selectedRow, 4).toString();
                    String sdtDocGia = viewDocGia.dgvDocGia.getValueAt(selectedRow, 2).toString();
                    String emailDocGia = viewDocGia.dgvDocGia.getValueAt(selectedRow, 3).toString();

                    // Set the data to the text fields
                    viewDocGia.txbMaDocGia.setText(idDocGia);
                    viewDocGia.txbTenDG.setText(tenDocGia);
                    viewDocGia.txbDiaChi.setText(diaChiDocGia);
                    viewDocGia.txbSDT.setText(sdtDocGia);
                    viewDocGia.txbEmail.setText(emailDocGia);
                }
            }
        });
    }

    private void addEventListeners() {
        viewDocGia.btnThemSach.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                btnThemSach_Click();
            }
        });

        viewDocGia.btnSuaSach.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                btnSuaSach_Click();
            }
        });

        viewDocGia.btnXoaSach.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                btnXoaSach_Click();
            }
        });

        viewDocGia.btnRS.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                btnRS_Click();
            }
        });

        viewDocGia.btnThoatSach.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                btnThoatSach_Click();
            }
        });
    }

    private void btnThemSach_Click() {
        String idDocGia = viewDocGia.txbMaDocGia.getText();
        String tenDocGia = viewDocGia.txbTenDG.getText();
        String diaChi = viewDocGia.txbDiaChi.getText();
        String sdtDocGia = viewDocGia.txbSDT.getText();
        String emailDocGia = viewDocGia.txbEmail.getText();

        if (idDocGia.isEmpty() || tenDocGia.isEmpty() || diaChi.isEmpty() || sdtDocGia.isEmpty() || emailDocGia.isEmpty()) {
            JOptionPane.showMessageDialog(viewDocGia, "Vui lòng điền đầy đủ thông tin", "Thông báo", JOptionPane.WARNING_MESSAGE);
            return;
        }

        // Database logic
        try (Connection conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/QLTV", "root", "123456")) {
            String query = "INSERT INTO docgia (idDocGia, tenDocGia, diaChi, sdtDocGia, emailDocGia) VALUES (?, ?, ?, ?, ?)";
            PreparedStatement stmt = conn.prepareStatement(query);
            stmt.setString(1, idDocGia);
            stmt.setString(2, tenDocGia);
            stmt.setString(3, diaChi);
            stmt.setString(4, sdtDocGia);
            stmt.setString(5, emailDocGia);
            int rowsAffected = stmt.executeUpdate();
            if (rowsAffected > 0) {
                JOptionPane.showMessageDialog(viewDocGia, "Thêm độc giả thành công!", "Thông báo", JOptionPane.INFORMATION_MESSAGE);
                DefaultTableModel model = (DefaultTableModel) viewDocGia.dgvDocGia.getModel();
                model.addRow(new String[] {idDocGia, tenDocGia, sdtDocGia, emailDocGia, diaChi});
                btnRS_Click();
            } else {
                JOptionPane.showMessageDialog(viewDocGia, "Lỗi khi thêm độc giả", "Lỗi", JOptionPane.ERROR_MESSAGE);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    private void btnSuaSach_Click() {
        int selectedRow = viewDocGia.dgvDocGia.getSelectedRow();
        if (selectedRow != -1) {
            String idDocGia = viewDocGia.dgvDocGia.getValueAt(selectedRow, 0).toString();
            String tenDocGia = viewDocGia.txbTenDG.getText();
            String diaChiDocGia = viewDocGia.txbDiaChi.getText();
            String sdtDocGia = viewDocGia.txbSDT.getText();
            String emailDocGia = viewDocGia.txbEmail.getText();

            try (Connection conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/qltv", "root", "123456")) {
                String query = "UPDATE docgia SET tenDocGia = ?, diaChi = ?, sdtDocGia = ?, emailDocGia = ? WHERE idDocGia = ?";
                PreparedStatement stmt = conn.prepareStatement(query);
                stmt.setString(1, tenDocGia);
                stmt.setString(2, diaChiDocGia);
                stmt.setString(3, sdtDocGia);
                stmt.setString(4, emailDocGia);
                stmt.setString(5, idDocGia);
                int rowsAffected = stmt.executeUpdate();

                if (rowsAffected > 0) {
                    JOptionPane.showMessageDialog(viewDocGia, "Sửa thông tin thành công!", "Thông báo", JOptionPane.INFORMATION_MESSAGE);
                    viewDocGia.dgvDocGia.setValueAt(tenDocGia, selectedRow, 1);
                    viewDocGia.dgvDocGia.setValueAt(diaChiDocGia, selectedRow, 4);
                    viewDocGia.dgvDocGia.setValueAt(sdtDocGia, selectedRow, 2);
                    viewDocGia.dgvDocGia.setValueAt(emailDocGia, selectedRow, 3);
                } else {
                    JOptionPane.showMessageDialog(viewDocGia, "Lỗi khi sửa thông tin độc giả", "Lỗi", JOptionPane.ERROR_MESSAGE);
                }
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }

    private void btnXoaSach_Click() {
        int selectedRow = viewDocGia.dgvDocGia.getSelectedRow();
        if (selectedRow != -1) {
            String idDocGia = viewDocGia.dgvDocGia.getValueAt(selectedRow, 0).toString();

            try (Connection conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/qltv", "root", "123456")) {
                String query = "DELETE FROM docgia WHERE idDocGia = ?";
                PreparedStatement stmt = conn.prepareStatement(query);
                stmt.setString(1, idDocGia);
                int rowsAffected = stmt.executeUpdate();

                if (rowsAffected > 0) {
                    JOptionPane.showMessageDialog(viewDocGia, "Xóa độc giả thành công!", "Thông báo", JOptionPane.INFORMATION_MESSAGE);
                    DefaultTableModel model = (DefaultTableModel) viewDocGia.dgvDocGia.getModel();
                    model.removeRow(selectedRow);
                } else {
                    JOptionPane.showMessageDialog(viewDocGia, "Lỗi khi xóa độc giả", "Lỗi", JOptionPane.ERROR_MESSAGE);
                }
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }

    private void btnRS_Click() {
        viewDocGia.txbMaDocGia.setText("");
        viewDocGia.txbTenDG.setText("");
        viewDocGia.txbDiaChi.setText("");
        viewDocGia.txbSDT.setText("");
        viewDocGia.txbEmail.setText("");
    }

    private void btnThoatSach_Click() {
        System.exit(0);
    }
}
