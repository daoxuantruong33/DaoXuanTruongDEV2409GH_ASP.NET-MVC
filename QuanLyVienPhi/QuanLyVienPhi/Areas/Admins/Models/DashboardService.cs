using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QuanLyVienPhi.Models;

namespace QuanLyVienPhi.Areas.Admins.Models
{
    public class DashboardService
    {
        private readonly string _connectionString;

        public DashboardService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public Dashboard GetDashboardData()
        {
            var data = new Dashboard(); // Luôn khởi tạo đối tượng để đảm bảo có giá trị trả về

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = @"
                            SELECT 
                                COUNT(*) AS TongBenhNhan,
                                SUM(CASE WHEN bn.TrangThaiThanhToan = 1 THEN 1 ELSE 0 END) AS DaThanhToan,
                                SUM(CASE WHEN bn.TrangThaiThanhToan = 0 THEN 1 ELSE 0 END) AS ChuaThanhToan,
                                 SUM(
                                    CASE 
                                        WHEN bn.TrangThaiThanhToan = 1 
                                        THEN (ISNULL(cp.TienPhong, 0) + ISNULL(ctt.TienThuoc, 0) + ISNULL(ctdv.GiaTien, 0)) 
                                             * (1 - ISNULL(bh.MienGiam, 0) / 100)
                                        ELSE 0 
                                    END
                                ) AS TongDoanhThu
                            FROM BenhNhan bn
                            LEFT JOIN (SELECT BenhNhanId, SUM(TienPhong) AS TienPhong FROM ChiTietPhong GROUP BY BenhNhanId) cp 
                                ON bn.BenhNhanId = cp.BenhNhanId
                            LEFT JOIN (SELECT BenhNhanId, SUM(TienThuoc) AS TienThuoc FROM ChiTietThuoc GROUP BY BenhNhanId) ctt 
                                ON bn.BenhNhanId = ctt.BenhNhanId
                            LEFT JOIN (SELECT BenhNhanId, SUM(GiaTien) AS GiaTien FROM ChiTietDichVu GROUP BY BenhNhanId) ctdv 
                                ON bn.BenhNhanId = ctdv.BenhNhanId
                            LEFT JOIN (SELECT BenhNhanId, MAX(MienGiam) AS MienGiam FROM Bhyt GROUP BY BenhNhanId) bh 
                                ON bn.BenhNhanId = bh.BenhNhanId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Kiểm tra nếu có dữ liệu trả về
                        {
                            data.TongBenhNhan = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            data.DaThanhToan = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                            data.ChuaThanhToan = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                            data.TongDoanhThu = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu Dashboard: " + ex.Message);
                // Hoặc log lỗi bằng một logger framework
            }

            return data; // Đảm bảo luôn có giá trị trả về
        }
        public List<BenhNhanDTO> GetDanhSachBenhNhan(int pageNumber, int pageSize)
        {
            var danhSach = new List<BenhNhanDTO>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                            SELECT 
                                bn.BenhNhanId,
                                bn.HoTen,
                                bn.CCCD,
                                bn.TrangThaiThanhToan,
                                (
                                  (ISNULL(cp.TienPhong, 0) + ISNULL(ctt.TienThuoc, 0) + ISNULL(ctdv.GiaTien, 0)) 
                                  * (1 - ISNULL(bh.MienGiam, 0) / 100)
                                ) AS TongSoTien
                            FROM BenhNhan bn
                            LEFT JOIN (SELECT BenhNhanId, SUM(TienPhong) AS TienPhong FROM ChiTietPhong GROUP BY BenhNhanId) cp 
                                ON bn.BenhNhanId = cp.BenhNhanId
                            LEFT JOIN (SELECT BenhNhanId, SUM(TienThuoc) AS TienThuoc FROM ChiTietThuoc GROUP BY BenhNhanId) ctt 
                                ON bn.BenhNhanId = ctt.BenhNhanId
                            LEFT JOIN (SELECT BenhNhanId, SUM(GiaTien) AS GiaTien FROM ChiTietDichVu GROUP BY BenhNhanId) ctdv 
                                ON bn.BenhNhanId = ctdv.BenhNhanId
                            LEFT JOIN (SELECT BenhNhanId, MAX(MienGiam) AS MienGiam FROM Bhyt GROUP BY BenhNhanId) bh 
                                ON bn.BenhNhanId = bh.BenhNhanId
                            ORDER BY bn.BenhNhanId DESC
                            OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Tính toán offset dựa trên số trang và số lượng mỗi trang
                    cmd.Parameters.AddWithValue("@Offset", (pageNumber - 1) * pageSize);
                    cmd.Parameters.AddWithValue("@PageSize", pageSize);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSach.Add(new BenhNhanDTO
                            {
                                BenhNhanId = reader.GetInt32(0),
                                HoTen = reader.GetString(1),
                                CCCD = reader.GetString(2),
                                TrangThaiThanhToan = reader.GetBoolean(3),
                                TongSoTien = reader.IsDBNull(4) ? 0 : reader.GetDecimal(4)
                            });
                        }
                    }
                }
            }

            return danhSach;
        }



        public decimal GetDoanhThuTuanNay()
        {
            decimal doanhThu = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = @"
                                SELECT SUM(
                                    (ISNULL(cp.TienPhong, 0) + ISNULL(ctt.TienThuoc, 0) + ISNULL(ctdv.GiaTien, 0)) 
                                    * (1 - ISNULL(bh.MienGiam, 0) / 100)
                                ) AS TongDoanhThu
                                FROM BenhNhan bn
                                LEFT JOIN (SELECT BenhNhanId, SUM(TienPhong) AS TienPhong, MAX(NgayKetThuc) AS NgayRaVien 
                                           FROM ChiTietPhong GROUP BY BenhNhanId) cp 
                                    ON bn.BenhNhanId = cp.BenhNhanId
                                LEFT JOIN (SELECT BenhNhanId, SUM(TienThuoc) AS TienThuoc FROM ChiTietThuoc GROUP BY BenhNhanId) ctt 
                                    ON bn.BenhNhanId = ctt.BenhNhanId
                                LEFT JOIN (SELECT BenhNhanId, SUM(GiaTien) AS GiaTien FROM ChiTietDichVu GROUP BY BenhNhanId) ctdv 
                                    ON bn.BenhNhanId = ctdv.BenhNhanId
                                LEFT JOIN (SELECT BenhNhanId, MAX(MienGiam) AS MienGiam FROM Bhyt GROUP BY BenhNhanId) bh 
                                    ON bn.BenhNhanId = bh.BenhNhanId
                                WHERE bn.TrangThaiThanhToan = 1
                                AND cp.NgayRaVien >= DATEADD(DAY, - (DATEPART(WEEKDAY, GETDATE()) + @@DATEFIRST - 2) % 7, CAST(GETDATE() AS DATE))
                                AND cp.NgayRaVien <=  DATEADD(DAY, 6 - (DATEPART(WEEKDAY, GETDATE()) + @@DATEFIRST - 2) % 7, CAST(GETDATE() AS DATE))";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        var result = cmd.ExecuteScalar();
                        doanhThu = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy doanh thu tuần này: " + ex.Message);
            }

            return doanhThu;
        }
        public List<DoanhThuTheoNgayDTO> GetDoanhThuTheoNgay()
        {
            var doanhThuTheoNgay = new List<DoanhThuTheoNgayDTO>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    CAST(cp.NgayKetThuc AS DATE) AS Ngay,
                    SUM(
                        (ISNULL(cp.TienPhong, 0) + ISNULL(ctt.TienThuoc, 0) + ISNULL(ctdv.GiaTien, 0)) 
                        * (1 - ISNULL(bh.MienGiam, 0) / 100)
                        ) AS DoanhThu
                    FROM BenhNhan bn
                    LEFT JOIN (SELECT BenhNhanId, SUM(TienPhong) AS TienPhong, MAX(NgayKetThuc) AS NgayKetThuc 
                                FROM ChiTietPhong GROUP BY BenhNhanId) cp 
                        ON bn.BenhNhanId = cp.BenhNhanId
                    LEFT JOIN (SELECT BenhNhanId, SUM(TienThuoc) AS TienThuoc FROM ChiTietThuoc GROUP BY BenhNhanId) ctt 
                        ON bn.BenhNhanId = ctt.BenhNhanId
                    LEFT JOIN (SELECT BenhNhanId, SUM(GiaTien) AS GiaTien FROM ChiTietDichVu GROUP BY BenhNhanId) ctdv 
                        ON bn.BenhNhanId = ctdv.BenhNhanId
                    LEFT JOIN (SELECT BenhNhanId, MAX(MienGiam) AS MienGiam FROM Bhyt GROUP BY BenhNhanId) bh 
                        ON bn.BenhNhanId = bh.BenhNhanId
                    WHERE bn.TrangThaiThanhToan = 1
                    AND cp.NgayKetThuc >= DATEADD(DAY, - (DATEPART(WEEKDAY, GETDATE()) + @@DATEFIRST - 2) % 7, CAST(GETDATE() AS DATE))
                    AND cp.NgayKetThuc <= DATEADD(DAY, 6 - (DATEPART(WEEKDAY, GETDATE()) + @@DATEFIRST - 2) % 7, CAST(GETDATE() AS DATE))
                    GROUP BY CAST(cp.NgayKetThuc AS DATE)
                    ORDER BY CAST(cp.NgayKetThuc AS DATE)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            doanhThuTheoNgay.Add(new DoanhThuTheoNgayDTO
                            {
                                Ngay = reader.GetDateTime(0),
                                DoanhThu = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1)
                            });
                        }
                    }
                }

                // Bước 1: Xác định khoảng thời gian từ Thứ Hai đến Chủ Nhật tuần hiện tại
                DateTime today = DateTime.Today;
                int daysSinceMonday = ((int)today.DayOfWeek == 0 ? 7 : (int)today.DayOfWeek) - 1;
                DateTime startOfWeek = today.AddDays(-daysSinceMonday); // Thứ Hai
                DateTime endOfWeek = startOfWeek.AddDays(6); // Chủ Nhật

                // Bước 2: Tạo danh sách đủ 7 ngày
                var fullWeekData = new List<DoanhThuTheoNgayDTO>();
                for (DateTime date = startOfWeek; date <= endOfWeek; date = date.AddDays(1))
                {
                    var existingData = doanhThuTheoNgay.FirstOrDefault(d => d.Ngay.Date == date.Date);
                    fullWeekData.Add(new DoanhThuTheoNgayDTO
                    {
                        Ngay = date,
                        DoanhThu = existingData?.DoanhThu ?? 0 // Nếu không có dữ liệu, gán 0
                    });
                }

                return fullWeekData;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy doanh thu theo ngày kết thúc: " + ex.Message);
            }

            return new List<DoanhThuTheoNgayDTO>(); // Trả về danh sách rỗng nếu có lỗi
        }

        public Dictionary<string, decimal> GetTongChiPhi()
        {
            var tongChiPhi = new Dictionary<string, decimal>
            {
                { "Tiền phòng", 0 },
                { "Tiền thuốc", 0 },
                { "Tiền dịch vụ", 0 }
            };

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    ISNULL(SUM(ctp.TienPhong), 0) AS TongTienPhong,
                    ISNULL(SUM(ctt.TienThuoc), 0) AS TongTienThuoc,
                    ISNULL(SUM(ctdv.GiaTien), 0) AS TongTienDichVu
                FROM BenhNhan bn
                LEFT JOIN (SELECT BenhNhanId, SUM(TienPhong) AS TienPhong FROM ChiTietPhong GROUP BY BenhNhanId) ctp 
                    ON bn.BenhNhanId = ctp.BenhNhanId                
                LEFT JOIN (SELECT BenhNhanId, SUM(TienThuoc) AS TienThuoc FROM ChiTietThuoc GROUP BY BenhNhanId) ctt 
                    ON bn.BenhNhanId = ctt.BenhNhanId
                LEFT JOIN (SELECT BenhNhanId, SUM(GiaTien) AS GiaTien FROM ChiTietDichVu GROUP BY BenhNhanId) ctdv 
                    ON bn.BenhNhanId = ctdv.BenhNhanId
                WHERE bn.TrangThaiThanhToan = 1";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tongChiPhi["Tiền phòng"] = reader.GetDecimal(0);
                            tongChiPhi["Tiền thuốc"] = reader.GetDecimal(1);
                            tongChiPhi["Tiền dịch vụ"] = reader.GetDecimal(2);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy tổng chi phí: {ex.Message}");
            }

            return tongChiPhi;
        }

    }

}
