package demo.view;

import javax.swing.*;
import javax.swing.border.TitledBorder;
import javax.swing.table.DefaultTableModel;
import demo.event.EventSuKien;
import java.awt.*;
import java.text.SimpleDateFormat;
import java.util.Date;

public class ViewSuKien extends JPanel {
    public JTextField txbIDSuKien;
    public JTextField txbTenSuKien;
    public JTextField txbMoTa;
    public JTextField txbDiaDiem;
    public JTextField txbGio;
    public JSpinner spnNgay;
    public JTable dgvSuKien;
    public JButton btnThemSuKien;
    public JButton btnSuaSuKien;
    public JButton btnXoaSuKien;
    public JButton btnRS;
    public JButton btnThoatSuKien;

    // Constructor does not need to take EventSuKien as a parameter anymore
    public ViewSuKien() {
        initComponents();
    }

    private void initComponents() {
        // Panel setup with background and layout
        JPanel panel = new JPanel() {
            @Override
            protected void paintComponent(Graphics g) {
                super.paintComponent(g);
                ImageIcon background = new ImageIcon("DemoQLTV/src/images/BGEven.jpg");
                g.drawImage(background.getImage(), 0, 0, getWidth(), getHeight(), this);
            }
        };
        panel.setLayout(null);
        setLayout(new BorderLayout());
        add(panel, BorderLayout.CENTER);

        JPanel groupBox = new JPanel();
        groupBox.setLayout(null);
        groupBox.setBounds(20, 20, 900, 300);
        groupBox.setOpaque(false);
        groupBox.setBorder(BorderFactory.createTitledBorder(
                BorderFactory.createLineBorder(Color.WHITE),
                "Thông tin sự kiện",
                TitledBorder.LEFT,
                TitledBorder.TOP,
                new Font("Arial", Font.BOLD, 14),
                Color.WHITE
        ));
        panel.add(groupBox);

        // Initialize text fields and other components
        txbIDSuKien = createTextField(groupBox, "Mã sự kiện", 20, 60);
        txbTenSuKien = createTextField(groupBox, "Tên sự kiện", 20, 120);
        txbMoTa = createTextField(groupBox, "Mô tả", 20, 180);
        txbDiaDiem = createTextField(groupBox, "Địa điểm", 450, 60);
        txbGio = createTextField(groupBox, "Giờ tổ chức", 450, 120);

        JLabel lblNgayToChuc = new JLabel("Ngày tổ chức");
        lblNgayToChuc.setBounds(20, 240, 100, 30);
        lblNgayToChuc.setForeground(Color.WHITE);
        groupBox.add(lblNgayToChuc);

        spnNgay = new JSpinner(new SpinnerDateModel());
        JSpinner.DateEditor editor = new JSpinner.DateEditor(spnNgay, "yyyy-MM-dd");
        spnNgay.setEditor(editor);
        spnNgay.setBounds(130, 240, 250, 30);
        groupBox.add(spnNgay);

        // Table for displaying events
        DefaultTableModel model = new DefaultTableModel();
        model.addColumn("Mã sự kiện");
        model.addColumn("Tên sự kiện");
        model.addColumn("Mô tả");
        model.addColumn("Địa điểm");
        model.addColumn("Giờ tổ chức");
        model.addColumn("Ngày tổ chức");
        dgvSuKien = new JTable(model);
        JScrollPane scrollPane = new JScrollPane(dgvSuKien);
        scrollPane.setBounds(20, 340, 1130, 400);
        panel.add(scrollPane);

        // Initialize buttons
        btnThemSuKien = createButton(panel, "Thêm", "DemoQLTV/src/images/add (1).png", 950, 20);
        btnSuaSuKien = createButton(panel, "Sửa", "DemoQLTV/src/images/16941 (1).png", 950, 80);
        btnXoaSuKien = createButton(panel, "Xóa", "DemoQLTV/src/images/Tay (1).png", 950, 140);
        btnRS = createButton(panel, "Reset", "DemoQLTV/src/images/rs (1).png", 950, 200);
        btnThoatSuKien = createButton(panel, "Thoát", "DemoQLTV/src/images/ex (1).png", 950, 260);
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

    // Getter methods
    public JTable getTable() {
        return dgvSuKien;
    }

    public JTextField getTxbIDSuKien() {
        return txbIDSuKien;
    }

    public JTextField getTxbTenSuKien() {
        return txbTenSuKien;
    }

    public JTextField getTxbMoTa() {
        return txbMoTa;
    }

    public JTextField getTxbDiaDiem() {
        return txbDiaDiem;
    }

    public JTextField getTxbGio() {
        return txbGio;
    }

    public JSpinner getSpnNgay() {
        return spnNgay;
    }
}
