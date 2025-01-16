package demo.view;

import javax.swing.*;
import javax.swing.border.TitledBorder;
import javax.swing.table.DefaultTableModel;
import demo.event.EventSach;
import java.awt.*;
import java.text.SimpleDateFormat;
import java.util.Date;

public class ViewSach extends JPanel {
    public JTextField txbIDSach;
    public JTextField txbTenSach;
    public JTextField txbTacGia;
    public JTextField txbNXB;
    public JTextField txbTheLoai;
    public JTextField txbViTri;
    public JTextField txbSL;
    public JSpinner spnNamXuatBan;
    public JTable dgvSach;
    public JButton btnThemSach;
    public JButton btnSuaSach;
    public JButton btnXoaSach;
    public JButton btnRS;
    public JButton btnThoatSach;

    // Constructor does not need to take EventSach as a parameter anymore
    public ViewSach() {
        initComponents();
        
    }

    private void initComponents() {
        // Panel setup with background and layout
        JPanel panel = new JPanel() {
            @Override
            protected void paintComponent(Graphics g) {
                super.paintComponent(g);
                ImageIcon background = new ImageIcon("DemoQLTV/src/images/BGQLSach.jpg");
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
                "Thông tin sách",
                TitledBorder.LEFT,
                TitledBorder.TOP,
                new Font("Arial", Font.BOLD, 14),
                Color.WHITE
        ));
        panel.add(groupBox);

        // Initialize text fields and other components
        txbIDSach = createTextField(groupBox, "Mã sách", 20, 60);
        txbTenSach = createTextField(groupBox, "Tên sách", 20, 120);
        txbTacGia = createTextField(groupBox, "Tác giả", 20, 180);
        txbTheLoai = createTextField(groupBox, "Thể loại", 450, 60);
        txbNXB = createTextField(groupBox, "Nhà xuất bản", 450, 120);
        txbViTri = createTextField(groupBox, "Vị trí", 450, 180);
        txbSL = createTextField(groupBox, "Số lượng", 450, 240);

        JLabel lblNamXuatBan = new JLabel("Ngày xuất bản");
        lblNamXuatBan.setBounds(20, 240, 100, 30);
        lblNamXuatBan.setForeground(Color.WHITE);
        groupBox.add(lblNamXuatBan);

        spnNamXuatBan = new JSpinner(new SpinnerDateModel());
        JSpinner.DateEditor editor = new JSpinner.DateEditor(spnNamXuatBan, "yyyy-MM-dd");
        spnNamXuatBan.setEditor(editor);
        spnNamXuatBan.setBounds(130, 240, 250, 30);
        groupBox.add(spnNamXuatBan);

        // Table for displaying books
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
        JScrollPane scrollPane = new JScrollPane(dgvSach);
        scrollPane.setBounds(20, 340, 1130, 400);
        panel.add(scrollPane);

        // Initialize buttons
        btnThemSach = createButton(panel, "Thêm", "DemoQLTV/src/images/add (1).png", 950, 20);
        btnSuaSach = createButton(panel, "Sửa", "DemoQLTV/src/images/16941 (1).png", 950, 80);
        btnXoaSach = createButton(panel, "Xóa", "DemoQLTV/src/images/Tay (1).png", 950, 140);
        btnRS = createButton(panel, "Reset", "DemoQLTV/src/images/rs (1).png", 950, 200);
        btnThoatSach = createButton(panel, "Thoát", "DemoQLTV/src/images/ex (1).png", 950, 260);
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
        return dgvSach;
    }

    public JTextField getTxbIDSach() {
        return txbIDSach;
    }

    public JTextField getTxbTenSach() {
        return txbTenSach;
    }

    public JTextField getTxbTacGia() {
        return txbTacGia;
    }

    public JTextField getTxbNXB() {
        return txbNXB;
    }

    public JTextField getTxbTheLoai() {
        return txbTheLoai;
    }

    public JTextField getTxbViTri() {
        return txbViTri;
    }

    public JTextField getTxbSL() {
        return txbSL;
    }

    public JSpinner getSpnNamXuatBan() {
        return spnNamXuatBan;
    }
}
