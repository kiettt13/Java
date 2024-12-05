select ngayLapPhieu, count(*) as Số_lần_mượn_trong_ngày
from phieuMuon
group by ngayLapPhieu

select month(ngayLapPhieu) as tháng, count(*) as Số_lần_mượn_trong_tháng
from phieuMuon
group by month(ngayLapPhieu)

select dg.tenDocGia, month(pm.ngayLapPhieu) as Tháng, sum(pm.soLuong) as SoLuongSachMuon from phieuMuon pm, docGia dg where pm.idDocGia = dg.idDocGia group by dg.tenDocGia, month(pm.ngayLapPhieu)

select nv.tenNhanVien as Tên_Nhân_Viên, pm.ngayLapPhieu as Ngày ,count(*) as Lập_phiếu
from nhanVien nv, phieuMuon pm
where nv.idNhanVien = pm.idNhanVien
group by nv.tenNhanVien, pm.ngayLapPhieu

select nv.tenNhanVien as Tên_Nhân_Viên, month(pm.ngayLapPhieu) as Tháng ,count(*) as Lập_phiếu
from nhanVien nv, phieuMuon pm
where nv.idNhanVien = pm.idNhanVien
group by nv.tenNhanVien, month(pm.ngayLapPhieu)

select s.tenSach as Tên_sách, pm.ngayLapPhieu as Ngày, count(*) as Lần
from Sach s, phieuMuon pm
where s.idSach = pm.idSach
group by s.tenSach, pm.ngayLapPhieu

select s.tenSach as Tên_sách, month(pm.ngayLapPhieu) as Tháng, count(*) as Lần
from Sach s, phieuMuon pm
where s.idSach = pm.idSach
group by s.tenSach, month(pm.ngayLapPhieu)

select s.tenSach as Tên_sách, count(*) as Lần
from Sach s, phieuMuon pm
where s.idSach = pm.idSach
group by s.tenSach

select nv.tenNhanVien as Tên_Nhân_Viên, pt.ngayTraThuc as Ngày ,count(*) as Lập_phiếu_trả
from nhanVien nv, phieuTra pt, phieuMuon pm
where nv.idNhanVien = pt.idNhanVien and pt.idPhieuMuon = pm.idPhieuMuon
group by nv.tenNhanVien, pt.ngayTraThuc

select nv.tenNhanVien as Tên_Nhân_Viên, month(pt.ngayTraThuc) as Tháng ,count(*) as Lập_phiếu_trả
from nhanVien nv, phieuTra pt, phieuMuon pm
where nv.idNhanVien = pt.idNhanVien and pt.idPhieuMuon = pm.idPhieuMuon
group by nv.tenNhanVien, month(pt.ngayTraThuc)

select * 
from phieuMuon pm

select * 
from phieuTra pt