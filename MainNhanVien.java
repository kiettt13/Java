package demo.main;

import javax.swing.*;

import demo.event.EventNhanVien;
import demo.view.ViewNhanVien;

public class MainNhanVien {
    public static void main(String[] args) {
        // Create ViewNhanVien
        ViewNhanVien viewNhanVien = new ViewNhanVien();

        // Create EventNhanVien and pass viewNhanVien to it
        EventNhanVien eventNhanVien = new EventNhanVien(viewNhanVien);

        // Set up JFrame
        JFrame frame = new JFrame("Quản lý nhân viên");
        frame.setSize(1200, 800);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setLocationRelativeTo(null);
        frame.add(viewNhanVien); // Add ViewNhanVien to JFrame
        frame.setVisible(true);
    }
}
