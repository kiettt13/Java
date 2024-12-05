
CREATE DATABASE QLTV;

-- Sử dụng cơ sở dữ liệu QLTV
USE QLTV;

-- Tạo bảng admin
CREATE TABLE admin (
    idAdmin INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    username VARCHAR(20) NOT NULL,
    adPass VARCHAR(50) NOT NULL
);

-- Tạo bảng dangNhap
CREATE TABLE dangNhap (
    maDangNhap VARCHAR(10) PRIMARY KEY NOT NULL,
    nvPass VARCHAR(20) NOT NULL
);

-- Tạo bảng Sach
CREATE TABLE Sach (
    idBook INT AUTO_INCREMENT NOT NULL,
    maSach VARCHAR(10) NOT NULL,
    tenSach VARCHAR(150),
    tacGia VARCHAR(100),
    nhaXuatBan VARCHAR(100),
    namXuatBan DATE,
    theLoai VARCHAR(50),
    viTriTV VARCHAR(100),
    soLuong INT NOT NULL,
    PRIMARY KEY (idBook),
    UNIQUE (maSach)
);

-- Tạo bảng docGia
CREATE TABLE docGia (
    idDocGia VARCHAR(10) PRIMARY KEY NOT NULL,
    tenDocGia VARCHAR(100),
    diaChi VARCHAR(150),
    sdtDocGia VARCHAR(10),
    emailDocGia TEXT
);

-- Tạo bảng nhanVien
CREATE TABLE nhanVien (
    idNhanVien VARCHAR(10) PRIMARY KEY NOT NULL,
    tenNhanVien VARCHAR(100),
    chucVu VARCHAR(50),
    sdtNhanVien VARCHAR(10),
    khuVuc VARCHAR(20),
    emailNhanVien TEXT,
    diaChiNhanVien VARCHAR(150)
);

-- Tạo bảng suKien
CREATE TABLE suKien (
    idSuKien VARCHAR(10) PRIMARY KEY NOT NULL,
    tenSuKien VARCHAR(100),
    moTaSuKien VARCHAR(200),
    ngayToChuc DATE,
    gioToChuc VARCHAR(50),
    diaDiemToChuc VARCHAR(200)
);

-- Tạo bảng coSoVatChat
CREATE TABLE coSoVatChat (
    idThietBi VARCHAR(10) PRIMARY KEY NOT NULL,
    tenThietBi VARCHAR(50),
    tinhTrangThietBi VARCHAR(100),
    ngayMua DATE,
    ngayBaoTri DATE
);

-- Tạo bảng Kho
CREATE TABLE Kho (
    maSach VARCHAR(10) NOT NULL,
    soLuong INT NOT NULL,
    trangThai VARCHAR(50),
    PRIMARY KEY (maSach)
);

-- Tạo ràng buộc khóa ngoại cho bảng Kho
ALTER TABLE Kho
ADD CONSTRAINT FK_Kho_Sach FOREIGN KEY (maSach) REFERENCES Sach(maSach);

-- Tạo bảng phieuMuon
CREATE TABLE phieuMuon (
    idPhieuMuon VARCHAR(10) PRIMARY KEY NOT NULL,
    maSach VARCHAR(10),
    idDocGia VARCHAR(10),
    idNhanVien VARCHAR(10),
    soLuong INT NOT NULL,
    ngayLapPhieu DATE,
    ngayHenTra DATE,
    FOREIGN KEY (maSach) REFERENCES Sach(maSach),
    FOREIGN KEY (idDocGia) REFERENCES docGia(idDocGia),
    FOREIGN KEY (idNhanVien) REFERENCES nhanVien(idNhanVien)
);

-- Tạo bảng thongKe
CREATE TABLE thongKe (
    idNhanVien VARCHAR(10) NOT NULL,
    idDocGia VARCHAR(10) NOT NULL,
    idSach VARCHAR(10) NOT NULL,
    ngayThongKe DATE,
    soLanMuon INT,
    soLanTra INT,
    PRIMARY KEY (idNhanVien, idDocGia, idSach),
    FOREIGN KEY (idNhanVien) REFERENCES nhanVien(idNhanVien),
    FOREIGN KEY (idSach) REFERENCES Sach(maSach),
    FOREIGN KEY (idDocGia) REFERENCES docGia(idDocGia)
);

-- Tạo bảng phieuTra
CREATE TABLE phieuTra (
    idPhieuMuon VARCHAR(10),
    idNhanVien VARCHAR(10),
    tenNhanVien1 VARCHAR(100),
    tenDocGia VARCHAR(100),
    trangThai VARCHAR(50),
    ngayTraThuc DATE,
    ngayHenTra DATE,
    phiTreHen FLOAT,
    phiPhatSinh FLOAT,
    soLuong INT,
    PRIMARY KEY (idPhieuMuon),
    FOREIGN KEY (idPhieuMuon) REFERENCES phieuMuon(idPhieuMuon),
    FOREIGN KEY (idNhanVien) REFERENCES nhanVien(idNhanVien)
);

-- Tạo bảng Luong
CREATE TABLE Luong (
    idNhanVien VARCHAR(10),
    ngayDiLam DATE,
    thuong DECIMAL(10,2),
    luong DECIMAL(10,2),
    chucVu VARCHAR(50),
    PRIMARY KEY (idNhanVien),
    FOREIGN KEY (idNhanVien) REFERENCES nhanVien(idNhanVien)
);

-- Tạo bảng chamCong
CREATE TABLE chamCong (
    idNhanVien VARCHAR(10),
    chucVu VARCHAR(50),
    ngayDiLam DATE,
    tinhTrang VARCHAR(100),
    phep BOOLEAN,
    PRIMARY KEY (idNhanVien),
    FOREIGN KEY (idNhanVien) REFERENCES nhanVien(idNhanVien)
);

-- Thêm dữ liệu vào bảng admin
INSERT INTO admin (username, adPass) VALUES ('admin', '08072003');
