namespace QuanLyVienPhi.Helpers
{
    public static class RoleHelper
    {
        public const int Admin = 1;
        public const int BacSi = 2;
        public const int ThuNgan = 3;

        public static bool IsAdmin(int? roleId) => roleId == Admin;
        public static bool IsBacSi(int? roleId) => roleId == BacSi;
        public static bool IsThuNgan(int? roleId) => roleId == ThuNgan;
    }
}