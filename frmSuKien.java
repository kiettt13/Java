package frm;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.text.ParseException;
import java.text.SimpleDateFormat;

import javax.swing.table.DefaultTableModel;
import javax.swing.border.TitledBorder;
import javax.swing.event.ListSelectionEvent;
import javax.swing.event.ListSelectionListener;

import java.util.Date;

public class frmSuKien extends JFrame {
    private JTextField txbMa, txbTen, txbMoTa, txbDiaDiem, txbGio;
    private JTable dgvSuKien;
    private JSpinner spnNgay; // Replace JDateChooser with JSpinner
    private JButton btnThem, btnSua, btnXoa, btnThoat, btnRS;
    private Connection conn;
    private MainForm frmMain;
    public frmSuKien(MainForm frmMain) {
        setTitle("Quản lý sự kiện");
        setSize(1200, 800);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.frmMain = frmMain;
        // Panel with background image
        JPanel panel = new JPanel() {
            @Override
            protected void paintComponent(Graphics g) {
                super.paintComponent(g);
                ImageIcon background = new ImageIcon("src/images/BGEven.jpg");
                g.drawImage(background.getImage(), 0, 0, getWidth(), getHeight(), this);
            }
        };
        panel.setLayout(null);
        setContentPane(panel);

        // Event Info Panel (similar to "Thông tin sách")
        JPanel groupBox = new JPanel();
        groupBox.setLayout(null);
        groupBox.setBounds(20, 20, 900, 300);
        groupBox.setBackground(null);
        groupBox.setOpaque(false);  // Transparent panel
        groupBox.setBorder(BorderFactory.createTitledBorder(
            BorderFactory.createLineBorder(Color.WHITE),
            "Thông tin sự kiện",
            TitledBorder.LEFT,
            TitledBorder.TOP,
            new Font("Arial", Font.BOLD, 14),
            Color.WHITE // White title color
        ));
        panel.add(groupBox);

        // Mã sự kiện
        JLabel lblMa = new JLabel("Mã sự kiện");
        lblMa.setBounds(20, 60, 100, 30);
        lblMa.setForeground(Color.WHITE);
        groupBox.add(lblMa);
        txbMa = new JTextField();
        txbMa.setBounds(130, 60, 250, 30);
        groupBox.add(txbMa);

        // Tên sự kiện
        JLabel lblTen = new JLabel("Tên sự kiện");
        lblTen.setBounds(20, 120, 100, 30);
        lblTen.setForeground(Color.WHITE);
        groupBox.add(lblTen);
        txbTen = new JTextField();
        txbTen.setBounds(130, 120, 250, 30);
        groupBox.add(txbTen);

        // Mô tả
        JLabel lblMoTa = new JLabel("Mô tả");
        lblMoTa.setBounds(20, 180, 100, 30);
        lblMoTa.setForeground(Color.WHITE);
        groupBox.add(lblMoTa);
        txbMoTa = new JTextField();
        txbMoTa.setBounds(130, 180, 250, 30);
        groupBox.add(txbMoTa);

        // Ngày tổ chức
        JLabel lblNgay = new JLabel("Ngày tổ chức");
        lblNgay.setBounds(450, 60, 100, 30);
        lblNgay.setForeground(Color.WHITE);
        groupBox.add(lblNgay);
        
        // Set up JSpinner for date selection
        SpinnerDateModel modelDate = new SpinnerDateModel();
        spnNgay = new JSpinner(modelDate);
        JSpinner.DateEditor editor = new JSpinner.DateEditor(spnNgay, "yyyy-MM-dd");
        spnNgay.setEditor(editor);
        spnNgay.setBounds(570, 60, 250, 30);
        groupBox.add(spnNgay);

        // Giờ tổ chức
        JLabel lblGio = new JLabel("Giờ tổ chức");
        lblGio.setBounds(450, 120, 100, 30);
        lblGio.setForeground(Color.WHITE);
        groupBox.add(lblGio);
        txbGio = new JTextField();
        txbGio.setBounds(570, 120, 250, 30);
        groupBox.add(txbGio);

        // Địa điểm
        JLabel lblDiaDiem = new JLabel("Địa điểm");
        lblDiaDiem.setBounds(450, 180, 100, 30);
        lblDiaDiem.setForeground(Color.WHITE);
        groupBox.add(lblDiaDiem);
        txbDiaDiem = new JTextField();
        txbDiaDiem.setBounds(570, 180, 250, 30);
        groupBox.add(txbDiaDiem);

        // Buttons Panel (same style as the first form)
        btnThem = new JButton("Thêm", new ImageIcon("src/images/add (1).png"));
        btnThem.setBounds(950, 20, 110, 50);
        btnThem.addActionListener(e -> btnThem_Click());
        panel.add(btnThem);

        btnSua = new JButton("Sửa", new ImageIcon("src/images/16941 (1).png"));
        btnSua.setBounds(950, 80, 110, 50);
        btnSua.addActionListener(e -> btnSua_Click());
        panel.add(btnSua);

        btnXoa = new JButton("Xóa", new ImageIcon("src/images/Tay (1).png"));
        btnXoa.setBounds(950, 140, 110, 50);
        btnXoa.addActionListener(e -> btnXoa_Click());
        panel.add(btnXoa);

        btnRS = new JButton("Reset", new ImageIcon("src/images/rs (1).png"));
        btnRS.setBounds(950, 200, 110, 50);
        btnRS.addActionListener(e -> btnRS_Click());
        panel.add(btnRS);

        btnThoat = new JButton("Thoát", new ImageIcon("src/images/ex (1).png"));
        btnThoat.setBounds(950, 260, 110, 50);
        btnThoat.addActionListener(e -> btnThoat_Click());
        panel.add(btnThoat);

        // Table to display events
        DefaultTableModel modelTable = new DefaultTableModel();
        modelTable.addColumn("Mã sự kiện");
        modelTable.addColumn("Tên sự kiện");
        modelTable.addColumn("Ngày tổ chức");
        modelTable.addColumn("Giờ tổ chức");
        modelTable.addColumn("Mô tả");
        modelTable.addColumn("Địa điểm");
        dgvSuKien = new JTable(modelTable);

        JScrollPane scrollPane = new JScrollPane(dgvSuKien);
        scrollPane.setBounds(20, 340, 1130, 400);
        panel.add(scrollPane);
        dgvSuKien.getSelectionModel().addListSelectionListener(new ListSelectionListener() {
            @Override
            public void valueChanged(ListSelectionEvent e) {
                int selectedRow = dgvSuKien.getSelectedRow();
                if (selectedRow != -1) {
                    // Lấy dữ liệu từ dòng được chọn và cập nhật vào các trường văn bản
                    String idSuKien = dgvSuKien.getValueAt(selectedRow, 0).toString();
                    String tenSuKien = dgvSuKien.getValueAt(selectedRow, 1).toString();
                    String ngayToChuc = dgvSuKien.getValueAt(selectedRow, 2).toString();
                    String gioToChuc = dgvSuKien.getValueAt(selectedRow, 3).toString(); // Đảm bảo giá trị này là một chuỗi ngày hợp lệ
                    
                    String moTaSuKien = dgvSuKien.getValueAt(selectedRow, 4).toString();
                    String diaDiemToChuc = dgvSuKien.getValueAt(selectedRow, 5).toString();
                    
                   
                    // Cập nhật vào các trường văn bản
                    txbMa.setText(idSuKien);
                    txbTen.setText(tenSuKien);
                    try {
                        // Giả sử namXuatBan là một chuỗi ngày tháng có định dạng "yyyy-MM-dd"
                        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
                        Date date = sdf.parse(ngayToChuc);  // Chuyển đổi chuỗi thành Date
                        spnNgay.setValue(date);  // Đặt giá trị vào JSpinner
                    } catch (ParseException ex) {
                        // Xử lý lỗi nếu chuỗi không thể chuyển đổi thành ngày
                        System.out.println("Lỗi định dạng ngày tháng: " + ex.getMessage());
                    }
                    txbMoTa.setText(moTaSuKien);
                    txbGio.setText(gioToChuc);
                    txbDiaDiem.setText(diaDiemToChuc);
                 
                  

                    // Chuyển namXuatBan thành đối tượng Date và đặt vào JSpinner
                  
                }
            }
        });
    }

    private void btnThem_Click() {
        // Add event code
        String idSuKien = txbMa.getText();
        String tenSuKien = txbTen.getText();
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
        String ngayToChuc = sdf.format(spnNgay.getValue()); 
        String gioToChuc = txbGio.getText();
        String moTaSuKien = txbMoTa.getText();
        String diaDiemToChuc = txbDiaDiem.getText();
       
      // Get the date from JSpinner

        if (idSuKien.isEmpty() || tenSuKien.isEmpty()  || gioToChuc.isEmpty() || moTaSuKien.isEmpty() || diaDiemToChuc.isEmpty()) {
            JOptionPane.showMessageDialog(this, "Vui lòng điền đầy đủ thông tin", "Thông báo", JOptionPane.WARNING_MESSAGE);
            return;
        }
        String url = "jdbc:mysql://localhost:3306/qltv"; // Địa chỉ cơ sở dữ liệu
        String user = "root"; // Tên đăng nhập MySQL
        String password = "123456"; // Mật khẩu MySQL
        
        try (Connection conn = DriverManager.getConnection(url, user, password)) {
           String sql ="INSERT INTO sukien (idSuKien,tenSuKien,moTaSuKien,ngayToChuc,gioToChuc,diaDiemToChuc) VALUES (?, ?,?, ?, ?, ?)";
           PreparedStatement pst = conn.prepareStatement(sql);
           pst.setString(1, idSuKien);
           pst.setString(2, tenSuKien);
           pst.setString(3, moTaSuKien);
           pst.setString(4, ngayToChuc);
           pst.setString(5, gioToChuc);
           pst.setString(6, diaDiemToChuc);
           
           int rowsAffected = pst.executeUpdate();
           
           if (rowsAffected > 0) {
               // Nếu thêm thành công, hiển thị thông báo và thêm dòng vào bảng hiển thị trên giao diện
               JOptionPane.showMessageDialog(this, "Thêm sự kiện mới  thành công!", "Thông báo", JOptionPane.INFORMATION_MESSAGE);
               
               // Cập nhật bảng hiển thị dữ liệu
               DefaultTableModel model = (DefaultTableModel) dgvSuKien.getModel();
               model.addRow(new Object[]{idSuKien, tenSuKien,ngayToChuc,gioToChuc, moTaSuKien,diaDiemToChuc});
               
               // Reset các ô nhập liệu sau khi thêm
               btnRS_Click();	
           } else {
               // Nếu không thêm thành công, thông báo lỗi
               JOptionPane.showMessageDialog(this, "Lỗi khi thêm sự kiện", "Lỗi", JOptionPane.ERROR_MESSAGE);
           }
       } catch (SQLException e) {
           // Xử lý ngoại lệ nếu có lỗi khi kết nối hoặc thực thi câu lệnh
           JOptionPane.showMessageDialog(this, "Lỗi kết nối cơ sở dữ liệu: " + e.getMessage(), "Lỗi", JOptionPane.ERROR_MESSAGE);
           e.printStackTrace();
       }
       }


    private void btnSua_Click() {
        int selectedRow = dgvSuKien.getSelectedRow();
        if (selectedRow != -1) {
            txbMa.setText(dgvSuKien.getValueAt(selectedRow, 0).toString());
            txbTen.setText(dgvSuKien.getValueAt(selectedRow, 1).toString());
            txbMoTa.setText(dgvSuKien.getValueAt(selectedRow, 4).toString());
            txbDiaDiem.setText(dgvSuKien.getValueAt(selectedRow, 5).toString());
            txbGio.setText(dgvSuKien.getValueAt(selectedRow, 3).toString());
            spnNgay.setValue(dgvSuKien.getValueAt(selectedRow, 2)); // Update the JSpinner with date value
            
            DefaultTableModel model = (DefaultTableModel) dgvSuKien.getModel();
            String idSuKien = txbMa.getText();
            String tenSuKien = txbTen.getText();
            String moTaSuKien = txbMoTa.getText();
            String diaDiemToChuc = txbDiaDiem.getText();
            String gioToChuc = txbGio.getText();
            String ngayToChuc = new SimpleDateFormat("yyyy-MM-dd").format(spnNgay.getValue());
            String url = "jdbc:mysql://localhost:3306/qltv";
            String user = "root";
            String password = "123456";
            
            try (Connection conn = DriverManager.getConnection(url, user, password)) {
            	 String sql = "UPDATE sukien SET tenSuKien = ?, moTaSuKien = ?, diaDiemToChuc = ?, gioToChuc= ? , ngayToChuc WHERE idSuKien = ?";
                 PreparedStatement pst = conn.prepareStatement(sql);
                
             
                     pst.setString(1, tenSuKien);
                     pst.setString(2, moTaSuKien);
                     pst.setString(3, diaDiemToChuc);
                     pst.setString(4, gioToChuc);
                     pst.setString(5, ngayToChuc);
                 
                     pst.executeUpdate();
               
                     model.setValueAt(idSuKien, selectedRow, 0);
                     model.setValueAt(tenSuKien, selectedRow, 1);
                     model.setValueAt(moTaSuKien, selectedRow, 2);
                     model.setValueAt(diaDiemToChuc, selectedRow, 3);
                     model.setValueAt(gioToChuc, selectedRow, 4);
                     model.setValueAt(ngayToChuc, selectedRow, 5);
                     

                     JOptionPane.showMessageDialog(this, "Sửa  thành công", "Thông báo", JOptionPane.INFORMATION_MESSAGE);
                 } catch (SQLException e) {
                     JOptionPane.showMessageDialog(this, "Lỗi khi sữa : " + e.getMessage(), "Lỗi", JOptionPane.ERROR_MESSAGE);
                     e.printStackTrace();
                 }
        }
    }

    private void btnXoa_Click() {
    	int selectedRow = dgvSuKien.getSelectedRow();
        if (selectedRow != -1) {
            String idSuKien = dgvSuKien.getValueAt(selectedRow, 0).toString();

            // Kết nối cơ sở dữ liệu và thực hiện xóa sách
            String url = "jdbc:mysql://localhost:3306/qltv";
            String user = "root";
            String password = "123456";

            try (Connection conn = DriverManager.getConnection(url, user, password)) {
                String sql = "DELETE FROM sukien WHERE idSuKien = ?";
                PreparedStatement stmt = conn.prepareStatement(sql);
                stmt.setString(1, idSuKien);
                stmt.executeUpdate();

                // Xóa dòng trong bảng hiển thị
                DefaultTableModel model = (DefaultTableModel) dgvSuKien.getModel();
                model.removeRow(selectedRow);

                JOptionPane.showMessageDialog(this, "Xóa thành công", "Thông báo", JOptionPane.INFORMATION_MESSAGE);
            } catch (SQLException e) {
                JOptionPane.showMessageDialog(this, "Lỗi khi xóa : " + e.getMessage(), "Lỗi", JOptionPane.ERROR_MESSAGE);
                e.printStackTrace();
            }
        } else {
            JOptionPane.showMessageDialog(this, "Vui lòng chọn một dòng để xóa", "Thông báo", JOptionPane.WARNING_MESSAGE);
        }
    }

    private void btnRS_Click() {
        txbMa.setText("");
        txbTen.setText("");
        txbMoTa.setText("");
        txbDiaDiem.setText("");
        txbGio.setText("");
        spnNgay.setValue(new Date()); // Reset JSpinner to the current date
    }

    private void btnThoat_Click() {
    	frmMain.setVisible(true);
        this.setVisible(false);
    }

   
}
