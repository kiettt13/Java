package frm;

import javax.swing.*;
import javax.swing.event.ListSelectionEvent;
import javax.swing.event.ListSelectionListener;
import javax.swing.table.DefaultTableModel;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class frmDocGia extends JFrame {

    private JTextField txbMaDocGia, txbTenDG, txbDiaChi, txbSDT, txbEmail;
    private JButton btnThemSach, btnSuaSach, btnXoaSach, btnRS, btnThoatSach;
    private JTable dgvDocGia;
    private JScrollPane scrollPane;
    private JLabel label1, label2, label3, label4, label5;
    private JPanel panel;
    private String[] columnNames = {"Mã độc giả", "Tên độc giả", "Số điện thoại", "Email", "Địa chỉ"};
    private String[][] data = {};
    
    private MainForm frmMain;
    
    public frmDocGia(MainForm frmMain) {
    
    	
        setTitle("Quản lý độc giả");
        setSize(1200, 800);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);
    	this.frmMain = frmMain;  
        initComponents();
    }

  

	private void initComponents() {
        panel = new JPanel() {
            @Override
            protected void paintComponent(Graphics g) {
                super.paintComponent(g);
                // Đặt hình nền
                ImageIcon backgroundIcon = new ImageIcon("src/images/BGDocGia.jpg");
                g.drawImage(backgroundIcon.getImage(), 0, 0, getWidth(), getHeight(), this);
            }
        };
        panel.setLayout(null);

        // Nhóm "Thông tin độc giả"
        JPanel groupBox = new JPanel();
        groupBox.setLayout(null);
        groupBox.setBounds(20, 20, 900, 300);
        groupBox.setBackground(null);
        groupBox.setOpaque(false);// Màu nền nhạt, trong suốt
        groupBox.setBorder(BorderFactory.createTitledBorder("Thông tin độc giả"));
        panel.add(groupBox);

        // Mã độc giả
        label1 = new JLabel("Mã độc giả");
        label1.setBounds(20, 60, 100, 30);
        groupBox.add(label1);
        txbMaDocGia = new JTextField();
        txbMaDocGia.setBounds(130, 60, 250, 30);
        groupBox.add(txbMaDocGia);

        // Tên độc giả
        label2 = new JLabel("Tên độc giả");
        label2.setBounds(20, 120, 100, 30);
        groupBox.add(label2);
        txbTenDG = new JTextField();
        txbTenDG.setBounds(130, 120, 250, 30);
        groupBox.add(txbTenDG);

        // Địa chỉ
        label3 = new JLabel("Địa chỉ");
        label3.setBounds(20, 180, 100, 30);
        groupBox.add(label3);
        txbDiaChi = new JTextField();
        txbDiaChi.setBounds(130, 180, 711, 30);
        groupBox.add(txbDiaChi);

        // Số điện thoại
        label4 = new JLabel("Số điện thoại");
        label4.setBounds(450, 60, 100, 30);
        groupBox.add(label4);
        txbSDT = new JTextField();
        txbSDT.setBounds(570, 60, 250, 30);
        groupBox.add(txbSDT);

        // Email
        label5 = new JLabel("Email");
        label5.setBounds(450, 120, 100, 30);
        groupBox.add(label5);
        txbEmail = new JTextField();
        txbEmail.setBounds(570, 120, 250, 30);
        groupBox.add(txbEmail);

        // Các nút chức năng với biểu tượng
        btnThemSach = new JButton("Thêm", new ImageIcon("src/images/add (1).png"));
        btnThemSach.setBounds(950, 20, 110, 50);
        btnThemSach.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                btnThemSach_Click();
            }
        });
        panel.add(btnThemSach);

        btnSuaSach = new JButton("Sửa", new ImageIcon("src/images/16941 (1).png"));
        btnSuaSach.setBounds(950, 80, 110, 50);
        btnSuaSach.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                btnSuaSach_Click();
            }
        });
        panel.add(btnSuaSach);

        btnXoaSach = new JButton("Xóa", new ImageIcon("src/images/Tay (1).png"));
        btnXoaSach.setBounds(950, 140, 110, 50);
        btnXoaSach.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                btnXoaSach_Click();
            }
        });
        panel.add(btnXoaSach);

        btnRS = new JButton("Reset", new ImageIcon("src/images/rs (1).png"));
        btnRS.setBounds(950, 200, 110, 50);
        btnRS.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                btnRS_Click();
            }
        });
        panel.add(btnRS);

        btnThoatSach = new JButton("Thoát", new ImageIcon("src/images/ex (1).png"));
        btnThoatSach.setBounds(950, 260, 110, 50);
        btnThoatSach.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                btnThoatSach_Click();
            }
        });
        panel.add(btnThoatSach);

        // Bảng hiển thị dữ liệu
        DefaultTableModel model = new DefaultTableModel(data, columnNames);
        dgvDocGia = new JTable(model);

        // Thêm bảng vào JScrollPane
        scrollPane = new JScrollPane(dgvDocGia);
        scrollPane.setBounds(20, 340, 1130, 400);
        panel.add(scrollPane);
        dgvDocGia.getSelectionModel().addListSelectionListener(new ListSelectionListener() {
            @Override
            public void valueChanged(ListSelectionEvent e) {
                // Kiểm tra nếu có dòng nào được chọn
                int selectedRow = dgvDocGia.getSelectedRow();
                if (selectedRow != -1) {
                    // Lấy dữ liệu từ dòng được chọn và cập nhật vào các trường văn bản
                    String idDocGia = dgvDocGia.getValueAt(selectedRow, 0).toString();
                    String tenDocGia = dgvDocGia.getValueAt(selectedRow, 1).toString();
                    String diaChiDocGia = dgvDocGia.getValueAt(selectedRow, 4).toString();
                    String sdtDocGia = dgvDocGia.getValueAt(selectedRow, 2).toString();
                    String emailDocGia = dgvDocGia.getValueAt(selectedRow, 3).toString();

                    // Cập nhật vào các trường văn bản
                    txbMaDocGia.setText(idDocGia);
                    txbTenDG.setText(tenDocGia);
                    txbDiaChi.setText(diaChiDocGia);
                    txbSDT.setText(sdtDocGia);
                    txbEmail.setText(emailDocGia);
                }
            }
        });
        

        add(panel);
    }

    // Xử lý sự kiện các nút
	  private void btnThemSach_Click() {
	        String idDocGia = txbMaDocGia.getText();
	        String tenDocGia = txbTenDG.getText();
	        String diaChi = txbDiaChi.getText();
	        String sdtDocGia = txbSDT.getText();
	        String emailDocGia = txbEmail.getText();

	        if (idDocGia.isEmpty() || tenDocGia.isEmpty() || diaChi.isEmpty() || sdtDocGia.isEmpty() || emailDocGia.isEmpty()) {
	            JOptionPane.showMessageDialog(this, "Vui lòng điền đầy đủ thông tin", "Thông báo", JOptionPane.WARNING_MESSAGE);
	            return;
	        }

	        // Kết nối và thêm độc giả vào cơ sở dữ liệu
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
	                JOptionPane.showMessageDialog(this, "Thêm độc giả thành công!", "Thông báo", JOptionPane.INFORMATION_MESSAGE);
	                // Thêm vào bảng
	                DefaultTableModel model = (DefaultTableModel) dgvDocGia.getModel();
	                String[] newRow = {idDocGia, tenDocGia, sdtDocGia, emailDocGia, diaChi};
	                model.addRow(newRow);
	                btnRS_Click();
	            } else {
	                JOptionPane.showMessageDialog(this, "Lỗi khi thêm độc giả", "Lỗi", JOptionPane.ERROR_MESSAGE);
	            }
	        } catch (SQLException e) {
	            e.printStackTrace();
	        }
	    }

	  private void btnSuaSach_Click() {
	        int selectedRow = dgvDocGia.getSelectedRow();
	        if (selectedRow != -1) {
	            String idDocGia = dgvDocGia.getValueAt(selectedRow, 0).toString();
	            String tenDocGia = txbTenDG.getText();
	            String diaChiDocGia = txbDiaChi.getText();
	            String sdtDocGia = txbSDT.getText();
	            String emailDocGia = txbEmail.getText();
	            txbTenDG.setText(tenDocGia);
	            txbDiaChi.setText(diaChiDocGia);
	            txbSDT.setText(sdtDocGia);
	            txbEmail.setText(emailDocGia);	

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
	                    JOptionPane.showMessageDialog(this, "Sửa thông tin thành công!", "Thông báo", JOptionPane.INFORMATION_MESSAGE);
	                    dgvDocGia.setValueAt(tenDocGia, selectedRow, 1);
	                    dgvDocGia.setValueAt(diaChiDocGia, selectedRow, 2);
	                    dgvDocGia.setValueAt(sdtDocGia, selectedRow, 3);
	                    dgvDocGia.setValueAt(emailDocGia, selectedRow, 4);
	                } else {
	                    JOptionPane.showMessageDialog(this, "Lỗi khi sửa thông tin độc giả", "Lỗi", JOptionPane.ERROR_MESSAGE);
	                }
	            } catch (SQLException e) {
	                e.printStackTrace();
	            }
	        }
	    }
	  

	  private void btnXoaSach_Click() {
	        int selectedRow = dgvDocGia.getSelectedRow();
	        if (selectedRow != -1) {
	            String idDocGia = dgvDocGia.getValueAt(selectedRow, 0).toString();

	            try (Connection conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/QLTV", "root", "123456")) {
	                String query = "DELETE FROM docgia WHERE idDocGia = ?";
	                PreparedStatement stmt = conn.prepareStatement(query);
	                stmt.setString(1, idDocGia);
	                int rowsAffected = stmt.executeUpdate();

	                if (rowsAffected > 0) {
	                    JOptionPane.showMessageDialog(this, "Xóa độc giả thành công!", "Thông báo", JOptionPane.INFORMATION_MESSAGE);
	                    DefaultTableModel model = (DefaultTableModel) dgvDocGia.getModel();
	                    model.removeRow(selectedRow);
	                } else {
	                    JOptionPane.showMessageDialog(this, "Lỗi khi xóa độc giả", "Lỗi", JOptionPane.ERROR_MESSAGE);
	                }
	            } catch (SQLException e) {
	                e.printStackTrace();
	            }
	        } else {
	            JOptionPane.showMessageDialog(this, "Vui lòng chọn một dòng để xóa", "Thông báo", JOptionPane.WARNING_MESSAGE);
	        }
	    }

    private void btnRS_Click() {
        // Reset các ô nhập liệu
        txbMaDocGia.setText("");
        txbTenDG.setText("");
        txbDiaChi.setText("");
        txbSDT.setText("");
        txbEmail.setText("");
    }

    private void btnThoatSach_Click() {
    	frmMain.setVisible(true);
        this.setVisible(false); // 
    }
    private void loadData() {
        DefaultTableModel model = (DefaultTableModel) dgvDocGia.getModel();
        try (Connection conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/QLTV", "root", "123456")) {
            String query = "SELECT * FROM docgia";
            Statement stmt = conn.createStatement();
            ResultSet rs = stmt.executeQuery(query);
            while (rs.next()) {
                String idDocGia = rs.getString("idDocGia");
                String tenDocGia = rs.getString("tenDocGia");
                String diaChi = rs.getString("diaChi");
                String sdtDocGia = rs.getString("sdtDocGia");
                String emailDocGia = rs.getString("emailDocGia");
                model.addRow(new String[] {idDocGia, tenDocGia, sdtDocGia, emailDocGia, diaChi});
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }

    }
}
