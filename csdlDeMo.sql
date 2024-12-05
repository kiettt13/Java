
CREATE DATABASE QLTV;
GO

USE QLTV;
GO

CREATE TABLE admin (
    idAdmin INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    username NVARCHAR(20) NOT NULL,
    adPass NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE dangNhap (
    maDangNhap NVARCHAR(10) PRIMARY KEY NOT NULL,
    nvPass NVARCHAR(20) NOT NULL
);
GO

CREATE TABLE Sach (
    idBook INT IDENTITY(1,1) NOT NULL,
    maSach NVARCHAR(10) NOT NULL,
    tenSach NVARCHAR(150),
    tacGia NVARCHAR(100),
    nhaXuatBan NVARCHAR(100),
    namXuatBan DATE,
    theLoai NVARCHAR(50),
    viTriTV NVARCHAR(100),
    soLuong INT NOT NULL,
    CONSTRAINT PK_Sach PRIMARY KEY (idBook), -- Khóa chính cho cột idBook
    CONSTRAINT UQ_maSach UNIQUE (maSach) -- Ràng buộc duy nhất cho cột maSach
);
GO

CREATE TABLE docGia (
    idDocGia NVARCHAR(10) PRIMARY KEY NOT NULL,
    tenDocGia NVARCHAR(100),
    diaChi NVARCHAR(150),
    sdtDocGia NVARCHAR(10),
    emailDocGia TEXT
);
GO

CREATE TABLE nhanVien (
    idNhanVien NVARCHAR(10) PRIMARY KEY NOT NULL,
    tenNhanVien NVARCHAR(100),
    chucVu NVARCHAR(50),
    sdtNhanVien NVARCHAR(10),
    khuVuc NVARCHAR(20),
    emailNhanVien TEXT,
    diaChiNhanVien NVARCHAR(150)
);
GO

CREATE TABLE suKien (
    idSuKien NVARCHAR(10) PRIMARY KEY NOT NULL,
    tenSuKien NVARCHAR(100),
    moTaSuKien NVARCHAR(200),
    ngayToChuc DATE,
    gioToChuc NVARCHAR(50),
    diaDiemToChuc NVARCHAR(200)
);
GO

CREATE TABLE coSoVatChat (
    idThietBi NVARCHAR(10) PRIMARY KEY NOT NULL,
    tenThietBi NVARCHAR(50),
    tinhTrangThietBi NVARCHAR(100),
    ngayMua DATE,
    ngayBaoTri DATE
);
GO

CREATE TABLE Kho (
    maSach NVARCHAR(10) NOT NULL,
    soLuong INT NOT NULL,
    trangThai NVARCHAR(50),
);
GO

ALTER TABLE Kho
ADD CONSTRAINT FK_Kho_Sach FOREIGN KEY (maSach) REFERENCES Sach(maSach);

CREATE TABLE phieuMuon (
    idPhieuMuon NVARCHAR(10) PRIMARY KEY NOT NULL,
    maSach NVARCHAR(10),
    idDocGia NVARCHAR(10),
    idNhanVien NVARCHAR(10),
    soLuong INT NOT NULL,
    ngayLapPhieu DATE,
    ngayHenTra DATE,
    FOREIGN KEY (maSach) REFERENCES Sach(maSach),
    FOREIGN KEY (idDocGia) REFERENCES docGia(idDocGia),
    FOREIGN KEY (idNhanVien) REFERENCES nhanVien(idNhanVien)
);
GO

CREATE TABLE thongKe (
    idNhanVien NVARCHAR(10) NOT NULL,
    idDocGia NVARCHAR(10) NOT NULL,
    idSach NVARCHAR(10) NOT NULL,
    ngayThongKe DATE,
    soLanMuon INT,
    soLanTra INT,
    PRIMARY KEY (idNhanVien, idDocGia, idSach),
    FOREIGN KEY (idNhanVien) REFERENCES nhanVien(idNhanVien),
    FOREIGN KEY (idSach) REFERENCES Sach(maSach),
    FOREIGN KEY (idDocGia) REFERENCES docGia(idDocGia)
);
GO

CREATE TABLE phieuTra (
    idPhieuMuon NVARCHAR(10),
    idNhanVien NVARCHAR(10),
    tenNhanVien1 NVARCHAR(100),
    tenDocGia NVARCHAR(100),
    trangThai NVARCHAR(50),
    ngayTraThuc DATE,
    ngayHenTra DATE,
    phiTreHen FLOAT,
    phiPhatSinh FLOAT,
    soLuong INT,
    PRIMARY KEY (idPhieuMuon),
    FOREIGN KEY (idPhieuMuon) REFERENCES phieuMuon(idPhieuMuon),
    FOREIGN KEY (idNhanVien) REFERENCES nhanVien(idNhanVien)
);
GO

CREATE TABLE Luong (
    idNhanVien NVARCHAR(10),
    ngayDiLam DATE,
    thuong MONEY,
    luong MONEY,
    chucVu NVARCHAR(50),
    PRIMARY KEY (idNhanVien),
    FOREIGN KEY (idNhanVien) REFERENCES nhanVien(idNhanVien)
);
GO

CREATE TABLE chamCong (
    idNhanVien NVARCHAR(10),
    chucVu NVARCHAR(50),
    ngayDiLam DATE,
    tinhTrang NVARCHAR(100),
    phep BIT,
    PRIMARY KEY (idNhanVien),
    FOREIGN KEY (idNhanVien) REFERENCES nhanVien(idNhanVien)
);
GO

 insert into admin (username, adPass) values ('admin','08072003')