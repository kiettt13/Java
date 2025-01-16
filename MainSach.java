package demo.main;

import demo.view.ViewSach;
import demo.event.EventSach;

import javax.swing.*;

public class MainSach {
    public static void main(String[] args) {
        // Create ViewSach
        ViewSach viewSach = new ViewSach();

        // Create EventSach and pass viewSach to it
        EventSach eventSach = new EventSach(viewSach);

        // Add event listeners (Now in MainSach)
        viewSach.setVisible(true);

        // Set up JFrame
        JFrame frame = new JFrame("Quản lý sách");
        frame.setSize(1200, 800);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setLocationRelativeTo(null);
        frame.add(viewSach); // Add ViewSach to JFrame
        frame.setVisible(true);
    }
}
