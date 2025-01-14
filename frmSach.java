package frm;

import javax.swing.*;
import javax.swing.border.TitledBorder;
import javax.swing.event.ListSelectionEvent;
import javax.swing.event.ListSelectionListener;
import javax.swing.table.DefaultTableModel;
import java.awt.*;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

public class frmSach extends JFrame {

    private JTextField txbIDSach, txbTenSach, txbTacGia, txbNXB, txbTheLoai, txbViTri, txbSL;
    private JSpinner spnNamXuatBan;
    private JTable dgvSach;
    private JScrollPane scrollPane;
    private JButton btnThemSach, btnSuaSach, btnXoaSach, btnRS, btnThoatSach;
    private MainForm frmMain;
    
    public frmSach(MainForm frmMain) {
    	this.frmMain = frmMain;  
        initComponents();
    }

    private void initComponents() {
        setTitle("Quản lý sách");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(1200, 800);
        setLocationRelativeTo(null);

        // Panel với nền hình ảnh
        JPanel panel = new JPanel() {
            @Override
            protected void paintComponent(Graphics g) {
                super.paintComponent(g);
                ImageIcon background = new ImageIcon("src/images/BGQLSach.jpg");
                g.drawImage(background.getImage(), 0, 0, getWidth(), getHeight(), this);
            }
        };
        panel.setLayout(null);
        setContentPane(panel);

        JPanel groupBox = new JPanel();
        groupBox.setLayout(null);
        groupBox.setBounds(20, 20, 900, 300);
        groupBox.setBackground(null);
        groupBox.setOpaque(false);  // Đặt panel thành trong suốt

        
        groupBox.setBorder(BorderFactory.createTitledBorder(
            BorderFactory.createLineBorder(Color.WHITE),
            "Thông tin sách",
            TitledBorder.LEFT,
            TitledBorder.TOP,
            new Font("Arial", Font.BOLD, 14),
            Color.WHITE // Màu chữ tiêu đề là trắng
        ));
        panel.add(groupBox);

        // Mã sách
        JLabel lblIDSach = new JLabel("Mã sách");
        lblIDSach.setBounds(20, 60, 100, 30);
        groupBox.add(lblIDSach);
        txbIDSach = new JTextField();
        txbIDSach.setBounds(130, 60, 250, 30);
        lblIDSach.setForeground(Color.WHITE);
        groupBox.add(txbIDSach);

        // Tên sách
        JLabel lblTenSach = new JLabel("Tên sách");
        lblTenSach.setBounds(20, 120, 100, 30);
        groupBox.add(lblTenSach);
        txbTenSach = new JTextField();
        txbTenSach.setBounds(130, 120, 250, 30);
        lblTenSach.setForeground(Color.WHITE);
        groupBox.add(txbTenSach);

        // Tác giả
        JLabel lblTacGia = new JLabel("Tác giả");
        lblTacGia.setBounds(20, 180, 100, 30);
        groupBox.add(lblTacGia);
        txbTacGia = new JTextField();
        txbTacGia.setBounds(130, 180, 250, 30);
        lblTacGia.setForeground(Color.WHITE);
        groupBox.add(txbTacGia);

        // Thể loại
        JLabel lblTheLoai = new JLabel("Thể loại");
        lblTheLoai.setBounds(450, 60, 100, 30);
        groupBox.add(lblTheLoai);
        txbTheLoai = new JTextField();
        txbTheLoai.setBounds(570, 60, 250, 30);
        lblTheLoai.setForeground(Color.WHITE);
        groupBox.add(txbTheLoai);

        // Nhà xuất bản
        JLabel lblNXB = new JLabel("Nhà xuất bản");
        lblNXB.setBounds(450, 120, 100, 30);
        groupBox.add(lblNXB);
        txbNXB = new JTextField();
        txbNXB.setBounds(570, 120, 250, 30);
        lblNXB.setForeground(Color.WHITE);
        groupBox.add(txbNXB);

        // Vị trí
        JLabel lblViTri = new JLabel("Vị trí");
        lblViTri.setBounds(450, 180, 100, 30);
        groupBox.add(lblViTri);
        txbViTri = new JTextField();
        txbViTri.setBounds(570, 180, 250, 30);
        lblViTri.setForeground(Color.WHITE);
        groupBox.add(txbViTri);

        // Ngày xuất bản
        JLabel lblNamXuatBan = new JLabel("Ngày xuất bản");
        lblNamXuatBan.setBounds(20, 240, 100, 30);
        groupBox.add(lblNamXuatBan);
        spnNamXuatBan = new JSpinner(new SpinnerDateModel());
        JSpinner.DateEditor editor = new JSpinner.DateEditor(spnNamXuatBan, "yyyy-MM-dd");
        spnNamXuatBan.setEditor(editor);
        spnNamXuatBan.setBounds(130, 240, 250, 30);
        lblNamXuatBan.setForeground(Color.WHITE);
        groupBox.add(spnNamXuatBan);

        // Số lượng
        JLabel lblSL = new JLabel("Số lượng");
        lblSL.setBounds(450, 240, 100, 30);
        groupBox.add(lblSL);
        txbSL = new JTextField();
        txbSL.setBounds(570, 240, 250, 30);
        lblSL.setForeground(Color.WHITE);
        groupBox.add(txbSL);

        // Các nút chức năng
        btnThemSach = new JButton("Thêm", new ImageIcon("src/images/add (1).png"));
        btnThemSach.setBounds(950, 20, 110, 50);
        btnThemSach.addActionListener(e -> btnThemSach_Click());
        panel.add(btnThemSach);

        btnSuaSach = new JButton("Sửa", new ImageIcon("src/images/16941 (1).png"));
        btnSuaSach.setBounds(950, 80, 110, 50);
        btnSuaSach.addActionListener(e -> btnSuaSach_Click());
        panel.add(btnSuaSach);

        btnXoaSach = new JButton("Xóa", new ImageIcon("src/images/Tay (1).png"));
        btnXoaSach.setBounds(950, 140, 110, 50);
        btnXoaSach.addActionListener(e -> btnXoaSach_Click());
        panel.add(btnXoaSach);

        btnRS = new JButton("Reset", new ImageIcon("src/images/rs (1).png"));
        btnRS.setBounds(950, 200, 110, 50);
        btnRS.addActionListener(e -> btnRS_Click());
        panel.add(btnRS);

        btnThoatSach = new JButton("Thoát", new ImageIcon("src/images/ex (1).png"));
        btnThoatSach.setBounds(950, 260, 110, 50);
        btnThoatSach.addActionListener(e -> btnThoatSach_Click());
        panel.add(btnThoatSach);

        // Bảng hiển thị sách
        DefaultTableModel model = new DefaultTableModel();
        model.addColumn("Mã sách");
        model.addColumn("Tên sách");
        model.addColumn("Tác giả");
        model.addColumn("Thể loại");
        model.addColumn("Nhà xuất bản");
        model.addColumn("Vị trí");
        model.addColumn("Ngày xuất bản");
        model.addColumn("Số lượng");
        dgvSach = new JTable(model);

        // Thêm bảng vào JScrollPane
        scrollPane = new JScrollPane(dgvSach);
        scrollPane.setBounds(20, 340, 1130, 400);
        panel.add(scrollPane);
        dgvSach.getSelectionModel().addListSelectionListener(new ListSelectionListener() {
            @Override
            public void valueChanged(ListSelectionEvent e) {
                int selectedRow = dgvSach.getSelectedRow();
                if (selectedRow != -1) {
                    // Lấy dữ liệu từ dòng được chọn và cập nhật vào các trường văn bản
                    String maSach = dgvSach.getValueAt(selectedRow, 0).toString();
                    String tenSach = dgvSach.getValueAt(selectedRow, 1).toString();
                    String tacGia = dgvSach.getValueAt(selectedRow, 2).toString();
                    String nhaXuatBan = dgvSach.getValueAt(selectedRow, 4).toString();
                    String namXuatBan = dgvSach.getValueAt(selectedRow, 6).toString(); // Đảm bảo giá trị này là một chuỗi ngày hợp lệ
                    String theLoai = dgvSach.getValueAt(selectedRow, 3).toString();
                    String viTriTV = dgvSach.getValueAt(selectedRow, 5).toString();
                    String soLuong = dgvSach.getValueAt(selectedRow, 7).toString();

                    // Cập nhật vào các trường văn bản
                    txbIDSach.setText(maSach);
                    txbTenSach.setText(tenSach);
                    txbTacGia.setText(tacGia);
                    txbTheLoai.setText(theLoai);
                    txbNXB.setText(nhaXuatBan);
                    txbViTri.setText(viTriTV);
                    txbSL.setText(soLuong);

                    // Chuyển namXuatBan thành đối tượng Date và đặt vào JSpinner
                    try {
                        // Giả sử namXuatBan là một chuỗi ngày tháng có định dạng "yyyy-MM-dd"
                        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
                        Date date = sdf.parse(namXuatBan);  // Chuyển đổi chuỗi thành Date
                        spnNamXuatBan.setValue(date);  // Đặt giá trị vào JSpinner
                    } catch (ParseException ex) {
                        // Xử lý lỗi nếu chuỗi không thể chuyển đổi thành ngày
                        System.out.println("Lỗi định dạng ngày tháng: " + ex.getMessage());
                    }
                }
            }
        });

    }

    private void btnThemSach_Click() {
        // Lấy dữ liệu từ các ô nhập liệu
        String maSach = txbIDSach.getText();
        String tenSach = txbTenSach.getText();
        String tacGia = txbTacGia.getText();
        String theLoai = txbTheLoai.getText();
        String nhaXuatBan = txbNXB.getText();
        String viTriTV = txbViTri.getText();
        String soluong = txbSL.getText();
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
        String namXuatBan = sdf.format(spnNamXuatBan.getValue());

        // Kiểm tra nếu các trường dữ liệu không trống
        if (maSach.isEmpty() || tenSach.isEmpty() || tacGia.isEmpty() || theLoai.isEmpty() || nhaXuatBan.isEmpty() || viTriTV.isEmpty() || soluong.isEmpty()) {
            JOptionPane.showMessageDialog(this, "Vui lòng điền đầy đủ thông tin", "Thông báo", JOptionPane.WARNING_MESSAGE);
            return;
        }

        // Kết nối cơ sở dữ liệu MySQL
        String url = "jdbc:mysql://localhost:3306/qltv"; // Địa chỉ cơ sở dữ liệu
        String user = "root"; // Tên đăng nhập MySQL
        String password = "123456"; // Mật khẩu MySQL

        try (Connection conn = DriverManager.getConnection(url, user, password)) {
            // Câu lệnh SQL để thêm sách vào cơ sở dữ liệu
            String sql = "INSERT INTO sach (maSach, tenSach, tacGia, theLoai, nhaXuatBan, viTriTV, namXuatBan, soLuong) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
            
            // Chuẩn bị câu lệnh
            PreparedStatement stmt = conn.prepareStatement(sql);
            stmt.setString(1, maSach);
            stmt.setString(2, tenSach);
            stmt.setString(3, tacGia);
            stmt.setString(4, theLoai);
            stmt.setString(5, nhaXuatBan);
            stmt.setString(6, viTriTV);
            stmt.setString(7, namXuatBan);
            stmt.setInt(8, Integer.parseInt(soluong));

            // Thực thi câu lệnh và kiểm tra xem có thêm thành công không
            int rowsAffected = stmt.executeUpdate();
            
            if (rowsAffected > 0) {
                // Nếu thêm thành công, hiển thị thông báo và thêm dòng vào bảng hiển thị trên giao diện
                JOptionPane.showMessageDialog(this, "Thêm sách thành công!", "Thông báo", JOptionPane.INFORMATION_MESSAGE);
                
                // Cập nhật bảng hiển thị dữ liệu
                DefaultTableModel model = (DefaultTableModel) dgvSach.getModel();
                model.addRow(new Object[]{maSach, tenSach, tacGia, theLoai, nhaXuatBan, viTriTV, namXuatBan, soluong});
                
                // Reset các ô nhập liệu sau khi thêm
                btnRS_Click();
            } else {
                // Nếu không thêm thành công, thông báo lỗi
                JOptionPane.showMessageDialog(this, "Lỗi khi thêm sách", "Lỗi", JOptionPane.ERROR_MESSAGE);
            }
        } catch (SQLException e) {
            // Xử lý ngoại lệ nếu có lỗi khi kết nối hoặc thực thi câu lệnh
            JOptionPane.showMessageDialog(this, "Lỗi kết nối cơ sở dữ liệu: " + e.getMessage(), "Lỗi", JOptionPane.ERROR_MESSAGE);
            e.printStackTrace();
        }
    }
    private void btnSuaSach_Click() {
        int selectedRow = dgvSach.getSelectedRow();
        if (selectedRow != -1) {
            // Cập nhật các ô nhập liệu với dữ liệu từ dòng đã chọn
            txbIDSach.setText(dgvSach.getValueAt(selectedRow, 0).toString());
            txbTenSach.setText(dgvSach.getValueAt(selectedRow, 1).toString());
            txbTacGia.setText(dgvSach.getValueAt(selectedRow, 2).toString());
            txbTheLoai.setText(dgvSach.getValueAt(selectedRow, 3).toString());
            txbNXB.setText(dgvSach.getValueAt(selectedRow, 4).toString());
            txbViTri.setText(dgvSach.getValueAt(selectedRow, 5).toString());
            spnNamXuatBan.setValue(dgvSach.getValueAt(selectedRow, 6));
            txbSL.setText(dgvSach.getValueAt(selectedRow, 7).toString());

            // Cập nhật lại dữ liệu vào bảng
            DefaultTableModel model = (DefaultTableModel) dgvSach.getModel();
            String maSach = txbIDSach.getText();
            String tenSach = txbTenSach.getText();
            String tacGia = txbTacGia.getText();
            String theLoai = txbTheLoai.getText();
            String nhaXuatBan = txbNXB.getText();
            String viTriTV = txbViTri.getText();
            String soluong = txbSL.getText();
            String namXuatBan = new SimpleDateFormat("yyyy-MM-dd").format(spnNamXuatBan.getValue());

            // Cập nhật cơ sở dữ liệu
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
                stmt.executeUpdate();

                // Cập nhật lại bảng
                model.setValueAt(maSach, selectedRow, 0);
                model.setValueAt(tenSach, selectedRow, 1);
                model.setValueAt(tacGia, selectedRow, 2);
                model.setValueAt(theLoai, selectedRow, 3);
                model.setValueAt(nhaXuatBan, selectedRow, 4);
                model.setValueAt(viTriTV, selectedRow, 5);
                model.setValueAt(namXuatBan, selectedRow, 6);
                model.setValueAt(soluong, selectedRow, 7);

                JOptionPane.showMessageDialog(this, "Sửa sách thành công", "Thông báo", JOptionPane.INFORMATION_MESSAGE);
            } catch (SQLException e) {
                JOptionPane.showMessageDialog(this, "Lỗi khi sửa sách: " + e.getMessage(), "Lỗi", JOptionPane.ERROR_MESSAGE);
                e.printStackTrace();
            }
        }
    }

    private void btnXoaSach_Click() {
        int selectedRow = dgvSach.getSelectedRow();
        if (selectedRow != -1) {
            String maSach = dgvSach.getValueAt(selectedRow, 0).toString();

            // Kết nối cơ sở dữ liệu và thực hiện xóa sách
            String url = "jdbc:mysql://localhost:3306/qltv";
            String user = "root";
            String password = "123456";

            try (Connection conn = DriverManager.getConnection(url, user, password)) {
                String sql = "DELETE FROM sach WHERE maSach = ?";
                PreparedStatement stmt = conn.prepareStatement(sql);
                stmt.setString(1, maSach);
                stmt.executeUpdate();

                // Xóa dòng trong bảng hiển thị
                DefaultTableModel model = (DefaultTableModel) dgvSach.getModel();
                model.removeRow(selectedRow);

                JOptionPane.showMessageDialog(this, "Xóa sách thành công", "Thông báo", JOptionPane.INFORMATION_MESSAGE);
            } catch (SQLException e) {
                JOptionPane.showMessageDialog(this, "Lỗi khi xóa sách: " + e.getMessage(), "Lỗi", JOptionPane.ERROR_MESSAGE);
                e.printStackTrace();
            }
        } else {
            JOptionPane.showMessageDialog(this, "Vui lòng chọn một dòng để xóa", "Thông báo", JOptionPane.WARNING_MESSAGE);
        }
    }

    private void btnRS_Click() {
        // Reset các ô nhập liệu
        txbIDSach.setText("");
        txbTenSach.setText("");
        txbTacGia.setText("");
        txbTheLoai.setText("");
        txbNXB.setText("");
        txbViTri.setText("");
        txbSL.setText("");
        spnNamXuatBan.setValue(new Date());
    }

    private void btnThoatSach_Click() {
    	frmMain.setVisible(true);
        this.setVisible(false);
    }
}
