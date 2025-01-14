package frm;

import javax.swing.*;
import javax.swing.event.ListSelectionEvent;
import javax.swing.event.ListSelectionListener;
import javax.swing.table.DefaultTableModel;
import java.awt.*;
import java.sql.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

public class frmCSVC extends JFrame {
    private JTextField txbMa, txbTen, txbTT;
    private JSpinner spnNgayMua, spnNgayBT;
    private JButton btnThem, btnSua, btnXoa, btnRS, btnThoat;
    private JTable dgvCSVC;
    private JScrollPane scrollPane;
    private JLabel label1, label2, label3, label4, label5;
    private JPanel panel;
    private MainForm frmMain;

    // Database connection
    private Connection conn;

    public frmCSVC(MainForm frmMain) {
        setTitle("Quản lý Cơ sở vật chất");
        setSize(1200, 800);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);
        this.frmMain = frmMain;	
        initComponents();
       
    }

  

    private void initComponents() {
        // Panel with background
        panel = new JPanel() {
            @Override
            protected void paintComponent(Graphics g) {
                super.paintComponent(g);
                // Background image
                ImageIcon backgroundIcon = new ImageIcon("src/images/BGDocGia.jpg");
                g.drawImage(backgroundIcon.getImage(), 0, 0, getWidth(), getHeight(), this);
            }
        };
        panel.setLayout(null);

        // Group box for input fields
        JPanel groupBox = new JPanel();
        groupBox.setLayout(null);
        groupBox.setBounds(20, 20, 900, 300);
        groupBox.setBackground(null);
        groupBox.setOpaque(false);
        groupBox.setBorder(BorderFactory.createTitledBorder("Thông tin thiết bị"));
        panel.add(groupBox);

        // Mã thiết bị
        label1 = new JLabel("Mã thiết bị");
        label1.setBounds(20, 60, 100, 30);
        groupBox.add(label1);
        txbMa = new JTextField();
        txbMa.setBounds(130, 60, 250, 30);
        groupBox.add(txbMa);

        // Tên thiết bị
        label2 = new JLabel("Tên thiết bị");
        label2.setBounds(20, 120, 100, 30);
        groupBox.add(label2);
        txbTen = new JTextField();
        txbTen.setBounds(130, 120, 250, 30);
        groupBox.add(txbTen);

        // Tình trạng
        label3 = new JLabel("Tình trạng");
        label3.setBounds(20, 180, 100, 30);
        groupBox.add(label3);
        txbTT = new JTextField();
        txbTT.setBounds(130, 180, 250, 30);
        groupBox.add(txbTT);

        // Ngày mua
        label4 = new JLabel("Ngày mua");
        label4.setBounds(450, 60, 100, 30);
        groupBox.add(label4);
        spnNgayMua = new JSpinner(new SpinnerDateModel());
        spnNgayMua.setBounds(570, 60, 250, 30);
        JSpinner.DateEditor dateEditor1 = new JSpinner.DateEditor(spnNgayMua, "yyyy-MM-dd");
        spnNgayMua.setEditor(dateEditor1);
        groupBox.add(spnNgayMua);

        // Ngày bảo trì
        label5 = new JLabel("Ngày bảo trì");
        label5.setBounds(450, 120, 100, 30);
        groupBox.add(label5);
        spnNgayBT = new JSpinner(new SpinnerDateModel());
        spnNgayBT.setBounds(570, 120, 250, 30);
        JSpinner.DateEditor dateEditor2 = new JSpinner.DateEditor(spnNgayBT, "yyyy-MM-dd");
        spnNgayBT.setEditor(dateEditor2);
        groupBox.add(spnNgayBT);

        // Buttons
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

        // Data table (JTable)
        DefaultTableModel model = new DefaultTableModel();
        model.addColumn("Mã thiết bị");
        model.addColumn("Tên thiết bị");
        model.addColumn("Tình trạng");
        model.addColumn("Ngày mua");
        model.addColumn("Ngày bảo trì");
        dgvCSVC = new JTable(model);

        // Thêm bảng vào JScrollPane
        scrollPane = new JScrollPane(dgvCSVC);
        scrollPane.setBounds(20, 340, 1130, 400);
        panel.add(scrollPane);
        
        dgvCSVC.getSelectionModel().addListSelectionListener(new ListSelectionListener() {
            @Override
            public void valueChanged(ListSelectionEvent e) {
                int selectedRow = dgvCSVC.getSelectedRow();
                if (selectedRow != -1) {
                    // Lấy dữ liệu từ dòng được chọn và cập nhật vào các trường văn bản
                    String idThietBi = dgvCSVC.getValueAt(selectedRow, 0).toString();
                    String tenThietBi = dgvCSVC.getValueAt(selectedRow, 1).toString();
                    String tinhTrangThietBi = dgvCSVC.getValueAt(selectedRow, 2).toString();
                    String ngayMua = dgvCSVC.getValueAt(selectedRow, 3).toString(); // Đảm bảo giá trị này là một chuỗi ngày hợp lệ
                    String ngayBaoTri = dgvCSVC.getValueAt(selectedRow, 4).toString();
                 
                   
         
                    txbMa.setText(idThietBi);
                    txbTen.setText(tenThietBi);
                    try {
                        // Giả sử namXuatBan là một chuỗi ngày tháng có định dạng "yyyy-MM-dd"
                        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
                        Date date = sdf.parse(ngayMua);  // Chuyển đổi chuỗi thành Date
                        spnNgayMua.setValue(date);  // Đặt giá trị vào JSpinner
                    } catch (ParseException ex) {
                        // Xử lý lỗi nếu chuỗi không thể chuyển đổi thành ngày
                        System.out.println("Lỗi định dạng ngày tháng: " + ex.getMessage());
                    }
                    try {
                        // Giả sử namXuatBan là một chuỗi ngày tháng có định dạng "yyyy-MM-dd"
                        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
                        Date date = sdf.parse(ngayBaoTri);  // Chuyển đổi chuỗi thành Date
                        spnNgayBT.setValue(date);  // Đặt giá trị vào JSpinner
                    } catch (ParseException ex) {
                        // Xử lý lỗi nếu chuỗi không thể chuyển đổi thành ngày
                        System.out.println("Lỗi định dạng ngày tháng: " + ex.getMessage());
                    }
                    txbTT.setText(tinhTrangThietBi);
                 
                 
                  

                    // Chuyển namXuatBan thành đối tượng Date và đặt vào JSpinner
                  
                }
            }
        });

        // Add panel to frame
        add(panel);
    }

    private void btnThem_Click() {
    	
        String idThietBi = txbMa.getText();
        String tenThietBi	 = txbTen.getText();
        String tinhTrangThietBi = txbTT.getText();
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
        String ngayMua = sdf.format(spnNgayMua.getValue());
        SimpleDateFormat sdf1 = new SimpleDateFormat("yyyy-MM-dd");
        String ngayBaoTri = sdf1.format(spnNgayBT.getValue());

        if (idThietBi.isEmpty() || tenThietBi.isEmpty() || tinhTrangThietBi.isEmpty() || ngayMua == null || ngayBaoTri == null) {
            JOptionPane.showMessageDialog(this, "Vui lòng điền đầy đủ thông tin", "Thông báo", JOptionPane.WARNING_MESSAGE);
            return;
        }
        String url = "jdbc:mysql://localhost:3306/qltv"; // Địa chỉ cơ sở dữ liệu
        String user = "root"; // Tên đăng nhập MySQL
        String password = "123456"; // Mật khẩu MySQL

        try (Connection conn = DriverManager.getConnection(url, user, password)) {
        String sql ="INSERT INTO cosovatchat (idThietBi,tenThietBi,tinhTrangThietBi,ngayMua,ngayBaoTri) VALUES (?, ?, ?, ?, ?)";
        PreparedStatement pst = conn.prepareStatement(sql);
            pst.setString(1, idThietBi);
            pst.setString(2, tenThietBi);
            pst.setString(3, tinhTrangThietBi);
            pst.setString(4, ngayMua);
            pst.setString(5, ngayBaoTri);
            
            int rowsAffected = pst.executeUpdate();
            
            if (rowsAffected > 0) {
                // Nếu thêm thành công, hiển thị thông báo và thêm dòng vào bảng hiển thị trên giao diện
                JOptionPane.showMessageDialog(this, "Thêm thiết bị mới  thành công!", "Thông báo", JOptionPane.INFORMATION_MESSAGE);
                
                // Cập nhật bảng hiển thị dữ liệu
                DefaultTableModel model = (DefaultTableModel) dgvCSVC.getModel();
                model.addRow(new Object[]{idThietBi, tenThietBi, tinhTrangThietBi,ngayMua,ngayBaoTri});
                
                // Reset các ô nhập liệu sau khi thêm
                btnRS_Click();	
            } else {
                // Nếu không thêm thành công, thông báo lỗi
                JOptionPane.showMessageDialog(this, "Lỗi khi thêm thiết bị", "Lỗi", JOptionPane.ERROR_MESSAGE);
            }
        } catch (SQLException e) {
            // Xử lý ngoại lệ nếu có lỗi khi kết nối hoặc thực thi câu lệnh
            JOptionPane.showMessageDialog(this, "Lỗi kết nối cơ sở dữ liệu: " + e.getMessage(), "Lỗi", JOptionPane.ERROR_MESSAGE);
            e.printStackTrace();
        }
        }

    private void btnSua_Click() {
        int selectedRow = dgvCSVC.getSelectedRow();
        if (selectedRow != -1) {
        	  txbMa.setText(dgvCSVC.getValueAt(selectedRow, 0).toString());
              txbTen.setText(dgvCSVC.getValueAt(selectedRow, 1).toString());
              txbTT.setText(dgvCSVC.getValueAt(selectedRow, 2).toString());
              spnNgayMua.setValue(dgvCSVC.getValueAt(selectedRow, 3));
              spnNgayBT.setValue(dgvCSVC.getValueAt(selectedRow, 4));
              
             DefaultTableModel model = (DefaultTableModel) dgvCSVC.getModel();
            String idThietBi = txbMa.getText();
            String tenThietBi = txbTen.getText();
            String tinhTrangThietBi = txbTT.getText();
            String ngayMua = new SimpleDateFormat("yyyy-MM-dd").format(spnNgayMua.getValue());
            String ngayBaoTri = new SimpleDateFormat("yyyy-MM-dd").format(spnNgayBT.getValue());
            String url = "jdbc:mysql://localhost:3306/qltv";
            String user = "root";
            String password = "123456";

            try (Connection conn = DriverManager.getConnection(url, user, password)) {
            // Update the data in the database
            String sql = "UPDATE cosovatchat SET tenThietBi = ?, tinhTrangThietBi = ?, ngayMua = ?, ngayBaoTri = ? WHERE idThietBi = ?";
            PreparedStatement pst = conn.prepareStatement(sql);
            pst.setString(1, tenThietBi);
                pst.setString(2, tinhTrangThietBi);
                pst.setString(3, ngayMua);
                pst.setString(4, ngayBaoTri);
                pst.setString(5, idThietBi);
                pst.executeUpdate();
          
                model.setValueAt(idThietBi, selectedRow, 0);
                model.setValueAt(tenThietBi, selectedRow, 1);
                model.setValueAt(tinhTrangThietBi, selectedRow, 2);
                model.setValueAt(ngayMua, selectedRow, 3);
                model.setValueAt(ngayBaoTri, selectedRow, 4);
                

                JOptionPane.showMessageDialog(this, "Sửa  thành công", "Thông báo", JOptionPane.INFORMATION_MESSAGE);
            } catch (SQLException e) {
                JOptionPane.showMessageDialog(this, "Lỗi khi sữa: " + e.getMessage(), "Lỗi", JOptionPane.ERROR_MESSAGE);
                e.printStackTrace();
            }}
    }

    private void btnXoa_Click() {
    	 int selectedRow = dgvCSVC.getSelectedRow();
         if (selectedRow != -1) {
             String idThietBi = dgvCSVC.getValueAt(selectedRow, 0).toString();

             // Kết nối cơ sở dữ liệu và thực hiện xóa sách
             String url = "jdbc:mysql://localhost:3306/qltv";
             String user = "root";
             String password = "123456";

             try (Connection conn = DriverManager.getConnection(url, user, password)) {
                 String sql = "DELETE FROM cosovatchat WHERE idThietBi = ?";
                 PreparedStatement stmt = conn.prepareStatement(sql);
                 stmt.setString(1, idThietBi);
                 stmt.executeUpdate();

                 // Xóa dòng trong bảng hiển thị
                 DefaultTableModel model = (DefaultTableModel) dgvCSVC.getModel();
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
        txbTT.setText("");
        spnNgayMua.setValue(new Date());
        spnNgayBT.setValue(new Date());
    }

    private void btnThoat_Click() {
        frmMain.setVisible(true);
        this.setVisible(false);
    }

  
  

}
