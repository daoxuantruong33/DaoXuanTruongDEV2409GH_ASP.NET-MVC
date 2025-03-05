using Microsoft.Data.SqlClient;

namespace QuanLyVienPhi.Areas.Admins.Models
{
    public class DashboardService
    {
        private readonly string _connectionString;

        public DashboardService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Method to get the Dashboard data
        public Dashboard GetDashboardData()
        {
            var data = new Dashboard();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                // Query to get the counts for SanPham, BaiViet, NguoiDung, and LienHe
                string query = @"
                 SELECT 
                     (SELECT COUNT(*) FROM BenhNhan) AS BenhNhan";
                 

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Read the data and assign it to the Dashboard properties
                        data.BenhNhan = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        //data.BaiViet = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                        //data.NguoiDung = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                        //data.LienHe = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                    }
                }
            }

            return data;
        }
    }
}
