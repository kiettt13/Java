package demo.main;

import javax.swing.JFrame;
import javax.swing.SwingUtilities;
import demo.view.ViewDocGia;
import demo.event.EventDocGia;

public class MainDocGia {
    public static void main(String[] args) {
        SwingUtilities.invokeLater(new Runnable() {
            @Override
            public void run() {
                // Khởi tạo View
                ViewDocGia viewDocGia = new ViewDocGia();
                
                // Khởi tạo Event handler và truyền view vào
                EventDocGia eventDocGia = new EventDocGia(viewDocGia);

                // Tạo JFrame chính và thêm View vào
                JFrame frame = new JFrame("Quản lý độc giả");
                frame.setSize(1200, 800);
                frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
                frame.setLocationRelativeTo(null);
                frame.add(viewDocGia);
                frame.setVisible(true);
            }
        });
    }
}
