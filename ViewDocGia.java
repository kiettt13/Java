package demo.view;

import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import java.awt.*;

public class ViewDocGia extends JPanel {

    // Text fields and labels
    public JTextField txbMaDocGia, txbTenDG, txbDiaChi, txbSDT, txbEmail;
    public JButton btnThemSach, btnSuaSach, btnXoaSach, btnRS, btnThoatSach;
    public JTable dgvDocGia;
    public JScrollPane scrollPane;
    public JLabel label1, label2, label3, label4, label5;

    private String[] columnNames = {"Mã độc giả", "Tên độc giả", "Số điện thoại", "Email", "Địa chỉ"};
    private String[][] data = {};

    private Image backgroundImage;

    public ViewDocGia() {
        setLayout(null);

        // Load background image
        backgroundImage = new ImageIcon("DemoQLTV/src/images/BGDocGia.jpg").getImage(); // Đảm bảo đường dẫn đúng
        
        // Initialize components
        initComponents();
    }

    private void initComponents() {
        // Create group box "Thông tin độc giả"
        JPanel groupBox = new JPanel();
        groupBox.setLayout(null);
        groupBox.setBounds(20, 20, 900, 300);
        groupBox.setBackground(null);
        groupBox.setOpaque(false);
        groupBox.setBorder(BorderFactory.createTitledBorder("Thông tin độc giả"));
        this.add(groupBox);

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

        // Buttons
        btnThemSach = new JButton("Thêm", new ImageIcon("DemoQLTV/src/images/add (1).png"));
        btnThemSach.setBounds(950, 20, 110, 50);
        this.add(btnThemSach);

        btnSuaSach = new JButton("Sửa", new ImageIcon("DemoQLTV/src/images/16941 (1).png"));
        btnSuaSach.setBounds(950, 80, 110, 50);
        this.add(btnSuaSach);

        btnXoaSach = new JButton("Xóa", new ImageIcon("DemoQLTV/src/images/Tay (1).png"));
        btnXoaSach.setBounds(950, 140, 110, 50);
        this.add(btnXoaSach);

        btnRS = new JButton("Reset", new ImageIcon("DemoQLTV/src/images/rs (1).png"));
        btnRS.setBounds(950, 200, 110, 50);
        this.add(btnRS);

        btnThoatSach = new JButton("Thoát", new ImageIcon("DemoQLTV/src/images/ex (1).png"));
        btnThoatSach.setBounds(950, 260, 110, 50);
        this.add(btnThoatSach);

        // Table
        DefaultTableModel model = new DefaultTableModel(data, columnNames);
        dgvDocGia = new JTable(model);
        scrollPane = new JScrollPane(dgvDocGia);
        scrollPane.setBounds(20, 340, 1130, 400);
        this.add(scrollPane);
    }

    @Override
    protected void paintComponent(Graphics g) {
        super.paintComponent(g);
        
        // Draw background image
        if (backgroundImage != null) {
            g.drawImage(backgroundImage, 0, 0, getWidth(), getHeight(), this);
        }
    }
}
