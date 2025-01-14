package frm;

import javax.swing.*;
import javax.swing.event.ListSelectionEvent;
import javax.swing.event.ListSelectionListener;

import java.awt.*;
import javax.swing.table.DefaultTableModel;
import java.sql.*;
import java.util.Vector;

public class frmNhanVien extends JFrame {

    private JTextField txbMaNV, txbTenNV, txbChucVu, txbKhuVuc, txbSDT, txbEmail, txbDiaChi;
    private JTable dgvNhanVien;
    private JButton btnThem, btnSua, btnXoa, btnRS, btnThoat;
    private MainForm frmMain;

    // Cấu hình kết nối cơ sở dữ liệu
    private String url = "jdbc:mysql://localhost:3306/qltv"; // Địa chỉ cơ sở dữ liệu
    private String user = "root"; // Tên đăng nhập
    private String password = "123456"; // Mật khẩu

    public frmNhanVien(MainForm frmMain) {
        this.frmMain = frmMain;
        initComponents();
    }

    private void initComponents() {
        setTitle("Quản lý nhân viên");
        setSize(1200, 800);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);

        JPanel panel = new JPanel() {
            @Override
            protected void paintComponent(Graphics g) {
                super.paintComponent(g);
                ImageIcon background = new ImageIcon("src/images/BGNhanVien.jpg");
                g.drawImage(background.getImage(), 0, 0, getWidth(), getHeight(), this);
            }
        };
        panel.setLayout(null);

        // Nhóm "Thông tin nhân viên"
        JPanel groupBox = new JPanel();
        groupBox.setLayout(null);
        groupBox.setBounds(20, 20, 900, 300);
        groupBox.setBackground(null);
        groupBox.setOpaque(false);
        groupBox.setBorder(BorderFactory.createTitledBorder("Thông tin nhân viên"));
        panel.add(groupBox);

        // Mã nhân viên
        JLabel lblMaNV = new JLabel("Mã nhân viên");
        lblMaNV.setBounds(20, 60, 100, 30);
        groupBox.add(lblMaNV);
        txbMaNV = new JTextField();
        txbMaNV.setBounds(130, 60, 250, 30);
        groupBox.add(txbMaNV);

        // Tên nhân viên
        JLabel lblTenNV = new JLabel("Tên nhân viên");
        lblTenNV.setBounds(20, 120, 100, 30);
        groupBox.add(lblTenNV);
        txbTenNV = new JTextField();
        txbTenNV.setBounds(130, 120, 250, 30);
        groupBox.add(txbTenNV);

        // Chức vụ
        JLabel lblChucVu = new JLabel("Chức vụ");
        lblChucVu.setBounds(450, 60, 100, 30);
        groupBox.add(lblChucVu);
        txbChucVu = new JTextField();
        txbChucVu.setBounds(570, 60, 250, 30);
        groupBox.add(txbChucVu);

        // Khu vực
        JLabel lblKhuVuc = new JLabel("Khu vực");
        lblKhuVuc.setBounds(450, 120, 100, 30);
        groupBox.add(lblKhuVuc);
        txbKhuVuc = new JTextField();
        txbKhuVuc.setBounds(570, 120, 250, 30);
        groupBox.add(txbKhuVuc);

        // Số điện thoại
        JLabel lblSDT = new JLabel("Số điện thoại");
        lblSDT.setBounds(20, 180, 100, 30);
        groupBox.add(lblSDT);
        txbSDT = new JTextField();
        txbSDT.setBounds(130, 180, 250, 30);
        groupBox.add(txbSDT);

        // Email
        JLabel lblEmail = new JLabel("Email");
        lblEmail.setBounds(450, 180, 100, 30);
        groupBox.add(lblEmail);
        txbEmail = new JTextField();
        txbEmail.setBounds(570, 180, 250, 30);
        groupBox.add(txbEmail);

        // Địa chỉ
        JLabel lblDiaChi = new JLabel("Địa chỉ");
        lblDiaChi.setBounds(20, 240, 100, 30);
        groupBox.add(lblDiaChi);
        txbDiaChi = new JTextField();
        txbDiaChi.setBounds(130, 240, 711, 30);
        groupBox.add(txbDiaChi);

        // Các nút chức năng với biểu tượng
        btnThem = new JButton("Thêm", new ImageIcon("src/images/add (1).png"));
        btnThem.setBounds(950, 20, 110, 50);
        panel.add(btnThem);

        btnSua = new JButton("Sửa", new ImageIcon("src/images/16941 (1).png"));
        btnSua.setBounds(950, 80, 110, 50);
        panel.add(btnSua);

        btnXoa = new JButton("Xóa", new ImageIcon("src/images/Tay (1).png"));
        btnXoa.setBounds(950, 140, 110, 50);
        panel.add(btnXoa);

        btnRS = new JButton("Reset", new ImageIcon("src/images/rs (1).png"));
        btnRS.setBounds(950, 200, 110, 50);
        panel.add(btnRS);

        btnThoat = new JButton("Thoát", new ImageIcon("src/images/ex (1).png"));
        btnThoat.setBounds(950, 260, 110, 50);
        panel.add(btnThoat);

        // Bảng hiển thị nhân viên
        DefaultTableModel model = new DefaultTableModel();
        model.addColumn("Mã nhân viên");
        model.addColumn("Tên nhân viên");
        model.addColumn("Chức vụ");
        model.addColumn("Khu vực");
        model.addColumn("Số điện thoại");
        model.addColumn("Email");
        model.addColumn("Địa chỉ");

        dgvNhanVien = new JTable(model);
        JScrollPane scrollPane = new JScrollPane(dgvNhanVien);
        scrollPane.setBounds(20, 340, 1130, 400);
        panel.add(scrollPane);
        dgvNhanVien.getSelectionModel().addListSelectionListener(new ListSelectionListener() {
            @Override
            public void valueChanged(ListSelectionEvent e) {
                // Kiểm tra nếu có dòng nào được chọn
                int selectedRow = dgvNhanVien.getSelectedRow();
                if (selectedRow != -1) {
                    // Lấy dữ liệu từ dòng được chọn và cập nhật vào các trường văn bản
                    String idNhanVien = dgvNhanVien.getValueAt(selectedRow, 0).toString();
                    String tenNhanVien = dgvNhanVien.getValueAt(selectedRow, 1).toString();
                    String chucVu = dgvNhanVien.getValueAt(selectedRow, 2).toString();
                    String sdtNhanVien = dgvNhanVien.getValueAt(selectedRow, 4).toString();
                    String khuVuc = dgvNhanVien.getValueAt(selectedRow, 3).toString();
                    String emailNhanVien = dgvNhanVien.getValueAt(selectedRow, 5).toString();
                    String diaChiNhanVien = dgvNhanVien.getValueAt(selectedRow, 6).toString();

                    // Cập nhật vào các trường văn bản
                    txbMaNV.setText(idNhanVien);
                    txbTenNV.setText(tenNhanVien);
                    txbChucVu.setText(chucVu);
                    txbKhuVuc.setText(khuVuc);
                    txbSDT.setText(sdtNhanVien);
                    txbEmail.setText(emailNhanVien);
                    txbDiaChi.setText(diaChiNhanVien);
                }
            }
        });

        // Xử lý sự kiện các nút
        btnThem.addActionListener(e -> {
            // Lấy thông tin từ các trường nhập liệu
            String idNhanVien = txbMaNV.getText();
            String tenNhanVien = txbTenNV.getText();
            String chucVu = txbChucVu.getText();
            String khuVuc = txbKhuVuc.getText();
            String sdt = txbSDT.getText();
            String email = txbEmail.getText();
            String diaChi = txbDiaChi.getText();

            // Kiểm tra nếu có trường nào chưa nhập
            if (idNhanVien.isEmpty() || tenNhanVien.isEmpty() || chucVu.isEmpty() || khuVuc.isEmpty() ||
                sdt.isEmpty() || email.isEmpty() || diaChi.isEmpty()) {
                JOptionPane.showMessageDialog(this, "Vui lòng điền đầy đủ thông tin!", "Thông báo", JOptionPane.WARNING_MESSAGE);
                return;
            }

            // Kết nối cơ sở dữ liệu và thực hiện thêm nhân viên
            try (Connection conn = DriverManager.getConnection(url, user, password)) {
                String sql = "INSERT INTO nhanvien (idNhanVien, tenNhanVien, chucVu, khuVuc, sdtNhanVien, emailNhanVien, diaChiNhanVien) VALUES (?, ?, ?, ?, ?, ?, ?)";
                PreparedStatement stmt = conn.prepareStatement(sql);
                
                // Set dữ liệu vào prepared statement
                stmt.setString(1, idNhanVien);
                stmt.setString(2, tenNhanVien);
                stmt.setString(3, chucVu);
                stmt.setString(4, khuVuc);
                stmt.setString(5, sdt);
                stmt.setString(6, email);
                stmt.setString(7, diaChi);
                
                // Thực thi câu lệnh SQL
                int rowsAffected = stmt.executeUpdate();
                
                // Kiểm tra nếu có bản ghi được thêm vào
                if (rowsAffected > 0) {
                    JOptionPane.showMessageDialog(this, "Thêm nhân viên thành công!", "Thông báo", JOptionPane.INFORMATION_MESSAGE);
                    
                    // Cập nhật bảng dữ liệu
                    DefaultTableModel tableModel = (DefaultTableModel) dgvNhanVien.getModel();
                    tableModel.addRow(new Object[]{
                            idNhanVien, tenNhanVien, chucVu, khuVuc, sdt, email, diaChi
                    });

                    // Reset các ô nhập liệu sau khi thêm
                    btnRS.doClick();
                }
            } catch (SQLException ex) {
                // In ra lỗi chi tiết và hiển thị thông báo lỗi
                ex.printStackTrace();
                JOptionPane.showMessageDialog(this, "Lỗi khi thêm nhân viên: " + ex.getMessage(), "Lỗi", JOptionPane.ERROR_MESSAGE);
            }
        });


        btnSua.addActionListener(e -> {
            int selectedRow = dgvNhanVien.getSelectedRow();
            if (selectedRow != -1) {
                try (Connection conn = DriverManager.getConnection(url, user, password)) {
                    String sql = "UPDATE nhanvien SET tenNhanVien = ?, chucVu = ?, khuVuc = ?, sdtNhanVien = ?, emailNhanVien = ?, diaChiNhanVien = ? WHERE idNhanVien = ?";
                    PreparedStatement stmt = conn.prepareStatement(sql);
                    stmt.setString(1, txbTenNV.getText());
                    stmt.setString(2, txbChucVu.getText());
                    stmt.setString(3, txbKhuVuc.getText());
                    stmt.setString(4, txbSDT.getText());
                    stmt.setString(5, txbEmail.getText());
                    stmt.setString(6, txbDiaChi.getText());
                    stmt.setString(7, txbMaNV.getText());
                    int rowsAffected =stmt.executeUpdate();

                    // Cập nhật bảng
                    if (rowsAffected > 0) {
	                    JOptionPane.showMessageDialog(this, "Sửa thông tin thành công!", "Thông báo", JOptionPane.INFORMATION_MESSAGE);
                    DefaultTableModel tableModel = (DefaultTableModel) dgvNhanVien.getModel();
                    tableModel.setValueAt(txbTenNV.getText(), selectedRow, 1);
                    tableModel.setValueAt(txbChucVu.getText(), selectedRow, 2);
                    tableModel.setValueAt(txbKhuVuc.getText(), selectedRow, 3);
                    tableModel.setValueAt(txbSDT.getText(), selectedRow, 4);
                    tableModel.setValueAt(txbEmail.getText(), selectedRow, 5);
                    tableModel.setValueAt(txbDiaChi.getText(), selectedRow, 6);
                    } else {
	                    JOptionPane.showMessageDialog(this, "Lỗi khi sửa thông tin nhân viên", "Lỗi", JOptionPane.ERROR_MESSAGE);
	                }
                } catch (SQLException ex) {
                    ex.printStackTrace();
                    JOptionPane.showMessageDialog(this, "Lỗi khi sửa nhân viên", "Lỗi", JOptionPane.ERROR_MESSAGE);
                }
            }
        });

        btnXoa.addActionListener(e -> {
            int selectedRow = dgvNhanVien.getSelectedRow();
            if (selectedRow != -1) {
                String idNhanVien = (String) dgvNhanVien.getValueAt(selectedRow, 0);
                try (Connection conn = DriverManager.getConnection(url, user, password)) {
                    String sql = "DELETE FROM nhanvien WHERE idNhanVien = ?";
                    PreparedStatement stmt = conn.prepareStatement(sql);
                    stmt.setString(1, idNhanVien);
                    stmt.executeUpdate();

                    // Xóa dòng trong bảng
                    DefaultTableModel tableModel = (DefaultTableModel) dgvNhanVien.getModel();
                    tableModel.removeRow(selectedRow);
                } catch (SQLException ex) {
                    ex.printStackTrace();
                    JOptionPane.showMessageDialog(this, "Lỗi khi xóa nhân viên", "Lỗi", JOptionPane.ERROR_MESSAGE);
                }
            }
        });

        btnRS.addActionListener(e -> {
            txbMaNV.setText("");
            txbTenNV.setText("");
            txbChucVu.setText("");
            txbKhuVuc.setText("");
            txbSDT.setText("");
            txbEmail.setText("");
            txbDiaChi.setText("");
        });

        btnThoat.addActionListener(e -> {
            frmMain.setVisible(true);
            this.setVisible(false);
        });

        add(panel);
    }
}
