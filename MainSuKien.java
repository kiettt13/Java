package demo.main;

import demo.view.ViewSuKien;
import demo.event.EventSuKien;

import javax.swing.*;

public class MainSuKien {
    public static void main(String[] args) {
        // Create ViewSuKien, giả sử nó là JPanel thay vì JFrame
        ViewSuKien viewSuKien = new ViewSuKien();

        // Create EventSuKien and pass viewSuKien to it
        EventSuKien eventSuKien = new EventSuKien(viewSuKien);

        // Set up JFrame (Cửa sổ chính)
        JFrame frame = new JFrame("Quản lý sự kiện");
        frame.setSize(1200, 800);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setLocationRelativeTo(null); // Center the frame on screen
        frame.setContentPane(viewSuKien); // Thêm ViewSuKien (JPanel) vào JFrame

        // Make the frame visible
        frame.setVisible(true);
    }
}
