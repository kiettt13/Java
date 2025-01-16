package demo.view;

import javax.swing.*;
import javax.swing.border.TitledBorder;
import javax.swing.table.DefaultTableModel;
import java.awt.*;
import demo.event.EventNhanVien;

public class ViewNhanVien extends JPanel {

    // Declare UI components
    private JTextField txbMaNV, txbTenNV, txbChucVu, txbKhuVuc, txbSDT, txbEmail, txbDiaChi;
    private JTable dgvNhanVien;
    public JButton btnThem, btnSua, btnXoa, btnRS, btnThoat;

    public ViewNhanVien() {
        initComponents();
    }

    private void initComponents() {
        // Panel setup with background and layout
        JPanel panel = new JPanel() {
            @Override
            protected void paintComponent(Graphics g) {
                super.paintComponent(g);
                ImageIcon background = new ImageIcon("DemoQLTV/src/images/BGNhanVien.jpg");
                g.drawImage(background.getImage(), 0, 0, getWidth(), getHeight(), this);
            }
        };
        panel.setLayout(null);
        setLayout(new BorderLayout());
        add(panel, BorderLayout.CENTER);

        // GroupBox for employee information
        JPanel groupBox = new JPanel();
        groupBox.setLayout(null);
        groupBox.setBounds(20, 20, 900, 300);
        groupBox.setOpaque(false);
        groupBox.setBorder(BorderFactory.createTitledBorder(
                BorderFactory.createLineBorder(Color.WHITE),
                "Thông tin nhân viên",
                TitledBorder.LEFT,
                TitledBorder.TOP,
                new Font("Arial", Font.BOLD, 14),
                Color.WHITE
        ));
        panel.add(groupBox);

        // Initialize text fields and other components for employee details
        txbMaNV = createTextField(groupBox, "Mã nhân viên", 20, 60);
        txbTenNV = createTextField(groupBox, "Tên nhân viên", 20, 120);
        txbChucVu = createTextField(groupBox, "Chức vụ", 450, 60);
        txbKhuVuc = createTextField(groupBox, "Khu vực", 450, 120);
        txbSDT = createTextField(groupBox, "Số điện thoại", 20, 180);
        txbEmail = createTextField(groupBox, "Email", 450, 180);
        txbDiaChi = createTextField(groupBox, "Địa chỉ", 20, 240);

        // Initialize buttons
        btnThem = createButton(panel, "Thêm", "DemoQLTV/src/images/add (1).png", 950, 20);
        btnSua = createButton(panel, "Sửa", "DemoQLTV/src/images/16941 (1).png", 950, 80);
        btnXoa = createButton(panel, "Xóa", "DemoQLTV/src/images/Tay (1).png", 950, 140);
        btnRS = createButton(panel, "Reset", "DemoQLTV/src/images/rs (1).png", 950, 200);
        btnThoat = createButton(panel, "Thoát", "DemoQLTV/src/images/ex (1).png", 950, 260);

        // Table for displaying employees
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
    }

    private JTextField createTextField(JPanel parent, String label, int x, int y) {
        JLabel lbl = new JLabel(label);
        lbl.setBounds(x, y, 100, 30);
        lbl.setForeground(Color.WHITE);
        parent.add(lbl);

        JTextField textField = new JTextField();
        textField.setBounds(x + 110, y, 250, 30);
        parent.add(textField);
        return textField;
    }

    private JButton createButton(JPanel parent, String text, String iconPath, int x, int y) {
        JButton button = new JButton(text, new ImageIcon(iconPath));
        button.setBounds(x, y, 110, 50);
        parent.add(button);
        return button;
    }

    // Getter methods for UI components
    public JTable getTable() {
        return dgvNhanVien;
    }

    public JTextField getTxbMaNV() {
        return txbMaNV;
    }

    public JTextField getTxbTenNV() {
        return txbTenNV;
    }

    public JTextField getTxbChucVu() {
        return txbChucVu;
    }

    public JTextField getTxbKhuVuc() {
        return txbKhuVuc;
    }

    public JTextField getTxbSDT() {
        return txbSDT;
    }

    public JTextField getTxbEmail() {
        return txbEmail;
    }

    public JTextField getTxbDiaChi() {
        return txbDiaChi;
    }

    public JButton getBtnThem() {
        return btnThem;
    }

    public JButton getBtnSua() {
        return btnSua;
    }

    public JButton getBtnXoa() {
        return btnXoa;
    }

    public JButton getBtnRS() {
        return btnRS;
    }

    public JButton getBtnThoat() {
        return btnThoat;
    }
}
