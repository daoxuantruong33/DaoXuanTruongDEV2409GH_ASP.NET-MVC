namespace QuanLyVienPhi.Areas.Admins.Models
{
    public class BenhNhanDTO
    {
        public int BenhNhanId { get; set; }
        public string HoTen { get; set; }
        public string CCCD { get; set; }
        public bool TrangThaiThanhToan { get; set; }
        public decimal TongSoTien { get; set; } // Tổng tiền từ các bảng ChiTietPhong, ChiTietThuoc, ChiTietDichVu
    }
}
