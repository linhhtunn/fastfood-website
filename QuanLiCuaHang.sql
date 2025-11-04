CREATE TABLE LOAI_MON (
    MaLoai CHAR(10) PRIMARY KEY,
    TenLoai VARCHAR(50) NOT NULL UNIQUE
);



CREATE TABLE MON_AN (
    MaMon CHAR(10) PRIMARY KEY,
    TenMon VARCHAR(100) NOT NULL,
    Gia DECIMAL(10,2) NOT NULL CHECK (Gia >= 0),
    MaLoai CHAR(10) NOT NULL,
    CONSTRAINT FK_MON_AN_LOAI_MON FOREIGN KEY (MaLoai) REFERENCES LOAI_MON(MaLoai)
);

ALTER TABLE MON_AN
ADD SoLuong INT NOT NULL DEFAULT 0 CHECK (SoLuong >= 0);

CREATE TRIGGER TRG_KiemSoatSoLuongMonAn
ON CHI_TIET_HOA_DON
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra xem có món nào không đủ số lượng không
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN MON_AN m ON i.MaMon = m.MaMon
        WHERE m.SoLuong < i.SoLuong
    )
    BEGIN
        -- Nếu không đủ thì rollback, hủy thao tác
        RAISERROR(N'Số lượng món không đủ để bán!', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END;

    -- Nếu đủ thì cập nhật trừ số lượng
    UPDATE m
    SET m.SoLuong = m.SoLuong - i.SoLuong
    FROM MON_AN m
    JOIN inserted i ON m.MaMon = i.MaMon;
END;
GO

CREATE TRIGGER TRG_HoanLaiSoLuongMonAn
ON CHI_TIET_HOA_DON
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    
    UPDATE m
    SET m.SoLuong = m.SoLuong + d.SoLuong
    FROM MON_AN m
    JOIN deleted d ON m.MaMon = d.MaMon;
END;
GO



DROP TRIGGER TRG_GiamSoLuongSauKhiBan;


ALTER TABLE MON_AN
ALTER COLUMN TenMon NVARCHAR(100) NOT NULL;

CREATE TABLE KHACH_HANG (
    MaKH CHAR(10) PRIMARY KEY,
    TenKH VARCHAR(100) NOT NULL,
    SDT CHAR(10) UNIQUE
);


CREATE TABLE NHAN_VIEN (
    MaNV CHAR(10) PRIMARY KEY,
    TenNV VARCHAR(100) NOT NULL,
    CaLam VARCHAR(20)
);
ALTER TABLE NHAN_VIEN
ALTER COLUMN TenNV NVARCHAR(50) NOT NULL;

ALTER TABLE NHAN_VIEN
ALTER COLUMN CaLam NVARCHAR(50) NOT NULL;


CREATE TABLE MAY_ORDER (
    MaMay CHAR(10) PRIMARY KEY,
    ViTri VARCHAR(100) NOT NULL,
    TrangThai VARCHAR(30) NOT NULL DEFAULT 'Hoat dong',
    CONSTRAINT CHK_MAY_ORDER_TrangThai CHECK (TrangThai IN ('Hoat dong', 'Bao tri', 'Loi'))
);

ALTER TABLE MAY_ORDER
ALTER COLUMN ViTri NVARCHAR(50) NOT NULL;

INSERT INTO MAY_ORDER (MaMay, ViTri, TrangThai) VALUES
('M01', N'Tầng 1 - Góc trái', 'Hoat dong'),
('M02', N'Tầng 1 - Giữa sảnh', 'Hoat dong'),
('M03', N'Tầng 2 - Ban công', 'Hoat dong');


CREATE TABLE PHIEN_ORDER (
    MaPhien CHAR(10) PRIMARY KEY,
    MaKH CHAR(10) NOT NULL,
    MaMay CHAR(10) NOT NULL,
    ThoiGianBatDau DATETIME NOT NULL DEFAULT GETDATE(),
    ThoiGianKetThuc DATETIME,
    TrangThai VARCHAR(20) NOT NULL DEFAULT 'DangHoatDong',
    CONSTRAINT FK_PHIEN_ORDER_KHACH_HANG FOREIGN KEY (MaKH) REFERENCES KHACH_HANG(MaKH),
    CONSTRAINT FK_PHIEN_ORDER_MAY_ORDER FOREIGN KEY (MaMay) REFERENCES MAY_ORDER(MaMay)
);

INSERT INTO PHIEN_ORDER (MaPhien, MaKH, MaMay, ThoiGianBatDau, TrangThai) VALUES
('P01', 'KH001', 'M01', GETDATE(), 'DangHoatDong');


CREATE INDEX idx_may_trangthai ON PHIEN_ORDER(MaMay, TrangThai);


CREATE TABLE VAI_TRO (
    MaVaiTro CHAR(10) PRIMARY KEY,
    TenVaiTro VARCHAR(50) NOT NULL UNIQUE
);


CREATE TABLE HOA_DON (
    MaHD CHAR(10) PRIMARY KEY,
    NgayLap DATETIME NOT NULL DEFAULT GETDATE(),
    MaNV CHAR(10) NOT NULL,
    MaPhien CHAR(10) NOT NULL,
    TongTien DECIMAL(12,2) NOT NULL DEFAULT 0 CHECK (TongTien >= 0),
    PhuongThucTT VARCHAR(50),
    TrangThai VARCHAR(30) NOT NULL DEFAULT 'Pending',
    CONSTRAINT FK_HOA_DON_NHAN_VIEN FOREIGN KEY (MaNV) REFERENCES NHAN_VIEN(MaNV),
    CONSTRAINT FK_HOA_DON_PHIEN_ORDER FOREIGN KEY (MaPhien) REFERENCES PHIEN_ORDER(MaPhien)
);


INSERT INTO HOA_DON (MaHD, NgayLap, MaNV, MaPhien, TongTien, PhuongThucTT, TrangThai) VALUES
('HD01', GETDATE(), 'NV01', 'P01', 0, N'Tiền mặt', 'Pending');


----------------------------------------------------------
-- 9️⃣ Bảng CHI_TIET_HOA_DON
----------------------------------------------------------
INSERT INTO CHI_TIET_HOA_DON (MaHD, MaMon, SoLuong, DonGia) VALUES
('HD01', 'MA01', 2, 45000),
('HD01', 'MA03', 2, 20000);


ALTER TABLE HOA_DON
ALTER COLUMN PhuongThucTT NVARCHAR(50) NOT NULL;

CREATE INDEX idx_hoa_don_ngaylap ON HOA_DON(NgayLap);
CREATE INDEX idx_hoa_don_maphien ON HOA_DON(MaPhien);


CREATE TABLE CHI_TIET_HOA_DON (
    MaHD CHAR(10),
    MaMon CHAR(10),
    SoLuong INT NOT NULL DEFAULT 1 CHECK (SoLuong > 0),
    DonGia DECIMAL(10,2) NOT NULL CHECK (DonGia >= 0),
    CONSTRAINT PK_CHI_TIET_HOA_DON PRIMARY KEY (MaHD, MaMon),
    CONSTRAINT FK_CHI_TIET_HOA_DON_HOA_DON FOREIGN KEY (MaHD) REFERENCES HOA_DON(MaHD) ON DELETE CASCADE,
    CONSTRAINT FK_CHI_TIET_HOA_DON_MON_AN FOREIGN KEY (MaMon) REFERENCES MON_AN(MaMon)
);


CREATE TABLE TAI_KHOAN (
    MaTK CHAR(10) PRIMARY KEY,
    TenDN VARCHAR(50) UNIQUE NOT NULL,
    MatKhau CHAR(60) NOT NULL,
    MaVaiTro CHAR(10) NOT NULL,
    MaKH CHAR(10) NULL,
    MaNV CHAR(10) NULL,
    NguoiTao CHAR(10),
    NgayTao DATETIME NOT NULL DEFAULT GETDATE(),
    TrangThai VARCHAR(20) NOT NULL DEFAULT 'Active',
    CONSTRAINT FK_TAI_KHOAN_VAI_TRO FOREIGN KEY (MaVaiTro) REFERENCES VAI_TRO(MaVaiTro),
    CONSTRAINT FK_TAI_KHOAN_KHACH_HANG FOREIGN KEY (MaKH) REFERENCES KHACH_HANG(MaKH),
    CONSTRAINT FK_TAI_KHOAN_NHAN_VIEN FOREIGN KEY (MaNV) REFERENCES NHAN_VIEN(MaNV),
    CONSTRAINT FK_TAI_KHOAN_NGUOI_TAO FOREIGN KEY (NguoiTao) REFERENCES NHAN_VIEN(MaNV),
    CONSTRAINT CHK_TAI_KHOAN_User CHECK (
        (MaKH IS NOT NULL AND MaNV IS NULL) OR 
        (MaKH IS NULL AND MaNV IS NOT NULL)
    )
);


ALTER TABLE MON_AN ADD HinhAnh NVARCHAR(255);
ALTER TABLE TAI_KHOAN ALTER COLUMN MatKhau VARCHAR(255);
ALTER TABLE KHACH_HANG ADD DiaChi NVARCHAR(200) NULL;


INSERT INTO LOAI_MON (MaLoai, TenLoai) VALUES
('LM01', N'Món mì'),
('LM02', N'Đồ cuộn'),
('LM03', N'Món bánh');


----------------------------------------------------------
-- 2️⃣ Bảng MON_AN
----------------------------------------------------------
INSERT INTO MON_AN (MaMon, TenMon, Gia, MaLoai, HinhAnh) VALUES
-- Món mì
('MA01', N'Mì Quảng', 45000, 'LM01', N'mi_quang.jpg'),
('MA02', N'Mì xào hải sản', 55000, 'LM01', N'mi_xao_haisan.jpg'),
('MA03', N'Mì bò trứng', 50000, 'LM01', N'mi_bo_trung.jpg'),

-- Đồ cuốn
('MA04', N'Gỏi cuốn tôm thịt', 30000, 'LM02', N'goi_cuon_tom_thit.jpg'),
('MA05', N'Bánh cuốn nóng', 35000, 'LM02', N'banh_cuon_nong.jpg'),
('MA06', N'Nem cuốn Hà Nội', 40000, 'LM02', N'nem_cuon.jpg'),

-- Món bánh
('MA07', N'Bánh xèo', 40000, 'LM03', N'banh_xeo.jpg'),
('MA08', N'Bánh bèo Huế', 30000, 'LM03', N'banh_beo.jpg'),
('MA09', N'Bánh khọt', 35000, 'LM03', N'banh_khot.jpg');

INSERT INTO NHAN_VIEN (MaNV, TenNV, CaLam) VALUES
('NV01', N'Trần Thị Lan', N'Sáng'),
('NV02', N'Ngô Văn Dũng', N'Chiều'),
('NV03', N'Hoàng Mỹ Dung', N'Tối');




CREATE TRIGGER trg_Update_TongTien_HoaDon
ON CHI_TIET_HOA_DON
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE HOA_DON
    SET TongTien = (
        SELECT SUM(SoLuong * DonGia)
        FROM CHI_TIET_HOA_DON
        WHERE CHI_TIET_HOA_DON.MaHD = HOA_DON.MaHD
    )
    WHERE MaHD IN (
        SELECT DISTINCT MaHD FROM inserted
        UNION
        SELECT DISTINCT MaHD FROM deleted
    );
END;
GO


----------------------------------------------------------
-- 2️⃣ Trigger: Khi kết thúc phiên order, đổi trạng thái máy sang 'Hoạt động'
----------------------------------------------------------
CREATE TRIGGER trg_Update_MayOrder_Status
ON PHIEN_ORDER
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE M
    SET TrangThai = 'Hoat dong'
    FROM MAY_ORDER M
    JOIN inserted I ON M.MaMay = I.MaMay
    JOIN deleted D ON I.MaPhien = D.MaPhien
    WHERE I.TrangThai = 'DaKetThuc';
END;
GO


----------------------------------------------------------
-- 3️⃣ Trigger: Khi tạo phiên mới, đổi máy sang 'Đang sử dụng'
----------------------------------------------------------
CREATE TRIGGER trg_PHIEN_ORDER_Insert
ON PHIEN_ORDER
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE M
    SET TrangThai = 'DangSuDung'
    FROM MAY_ORDER M
    JOIN inserted I ON M.MaMay = I.MaMay;
END;
GO


----------------------------------------------------------
-- 4️⃣ Trigger: Kiểm tra trước khi kết thúc phiên order
----------------------------------------------------------
CREATE TRIGGER trg_Check_PHIEN_KetThuc
ON PHIEN_ORDER
INSTEAD OF UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TrangThaiMoi VARCHAR(20);
    SELECT TOP 1 @TrangThaiMoi = TrangThai FROM inserted;

    IF (@TrangThaiMoi = 'DaKetThuc')
    BEGIN
        UPDATE PHIEN_ORDER
        SET ThoiGianKetThuc = GETDATE(),
            TrangThai = 'DaKetThuc'
        WHERE MaPhien IN (SELECT MaPhien FROM inserted);
    END
    ELSE
    BEGIN
        UPDATE PHIEN_ORDER
        SET TrangThai = (SELECT TrangThai FROM inserted WHERE PHIEN_ORDER.MaPhien = inserted.MaPhien)
        WHERE MaPhien IN (SELECT MaPhien FROM inserted);
    END
END;
GO


----------------------------------------------------------
-- 5️⃣ Trigger: Khi tạo hóa đơn, tự động tính tổng tiền ban đầu (nếu có chi tiết)
----------------------------------------------------------
CREATE TRIGGER trg_HOADON_Insert
ON HOA_DON
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE H
    SET TongTien = (
        SELECT ISNULL(SUM(SoLuong * DonGia), 0)
        FROM CHI_TIET_HOA_DON C
        WHERE C.MaHD = H.MaHD
    )
    FROM HOA_DON H
    JOIN inserted I ON H.MaHD = I.MaHD;
END;
GO

SELECT 
    name AS TenTrigger,
    parent_class_desc AS CapDo,
    type_desc AS LoaiTrigger,
    OBJECT_NAME(parent_id) AS BangHoacDoiTuongLienKet
FROM sys.triggers
ORDER BY BangHoacDoiTuongLienKet, TenTrigger;
