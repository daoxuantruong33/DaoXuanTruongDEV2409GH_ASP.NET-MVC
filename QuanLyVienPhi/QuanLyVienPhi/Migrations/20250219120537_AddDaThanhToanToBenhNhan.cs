using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyVienPhi.Migrations
{
    /// <inheritdoc />
    public partial class AddDaThanhToanToBenhNhan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Admin__719FE4E8A5BFF347", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "BacSi",
                columns: table => new
                {
                    BacSiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ChuyenKhoa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BacSi__5B2D07542A824BF7", x => x.BacSiID);
                });

            migrationBuilder.CreateTable(
                name: "Khoa",
                columns: table => new
                {
                    KhoaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhoa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Khoa__42EDDF14CB74A22A", x => x.KhoaID);
                });

            migrationBuilder.CreateTable(
                name: "ThuNgan",
                columns: table => new
                {
                    ThuNganID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ThuNgan__4CD824F59C05AF03", x => x.ThuNganID);
                });

            migrationBuilder.CreateTable(
                name: "Thuoc",
                columns: table => new
                {
                    ThuocID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThuoc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GiaTien = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Thuoc__AB5C3E544F77143F", x => x.ThuocID);
                });

            migrationBuilder.CreateTable(
                name: "YTa",
                columns: table => new
                {
                    YTaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__YTa__EF698884567CA9B2", x => x.YTaID);
                });

            migrationBuilder.CreateTable(
                name: "Phong",
                columns: table => new
                {
                    PhongID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoPhong = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TienPhongNgay = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KhoaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Phong__FC669947BC716FF7", x => x.PhongID);
                    table.ForeignKey(
                        name: "FK_Phong_Khoa",
                        column: x => x.KhoaID,
                        principalTable: "Khoa",
                        principalColumn: "KhoaID");
                });

            migrationBuilder.CreateTable(
                name: "BenhNhan",
                columns: table => new
                {
                    BenhNhanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CMND = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    NgayNhapVien = table.Column<DateOnly>(type: "date", nullable: false),
                    NgayRaVien = table.Column<DateOnly>(type: "date", nullable: true),
                    BacSiID = table.Column<int>(type: "int", nullable: true),
                    KhoaID = table.Column<int>(type: "int", nullable: true),
                    PhongID = table.Column<int>(type: "int", nullable: true),
                    TienThuoc = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    TienPhong = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    DaThanhToan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BenhNhan__151050A6BBB20004", x => x.BenhNhanID);
                    table.ForeignKey(
                        name: "FK__BenhNhan__BacSiI__45F365D3",
                        column: x => x.BacSiID,
                        principalTable: "BacSi",
                        principalColumn: "BacSiID");
                    table.ForeignKey(
                        name: "FK__BenhNhan__KhoaID__47DBAE45",
                        column: x => x.KhoaID,
                        principalTable: "Khoa",
                        principalColumn: "KhoaID");
                    table.ForeignKey(
                        name: "FK__BenhNhan__PhongI__48CFD27E",
                        column: x => x.PhongID,
                        principalTable: "Phong",
                        principalColumn: "PhongID");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhong",
                columns: table => new
                {
                    ChiTietPhongID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenhNhanID = table.Column<int>(type: "int", nullable: false),
                    PhongID = table.Column<int>(type: "int", nullable: false),
                    NgayBatDau = table.Column<DateOnly>(type: "date", nullable: false),
                    NgayKetThuc = table.Column<DateOnly>(type: "date", nullable: true),
                    TienPhong = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChiTietP__E1B170CDCFE9E1D9", x => x.ChiTietPhongID);
                    table.ForeignKey(
                        name: "FK__ChiTietPh__BenhN__5165187F",
                        column: x => x.BenhNhanID,
                        principalTable: "BenhNhan",
                        principalColumn: "BenhNhanID");
                    table.ForeignKey(
                        name: "FK__ChiTietPh__Phong__52593CB8",
                        column: x => x.PhongID,
                        principalTable: "Phong",
                        principalColumn: "PhongID");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietThuoc",
                columns: table => new
                {
                    ChiTietThuocID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenhNhanID = table.Column<int>(type: "int", nullable: false),
                    ThuocID = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TienThuoc = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChiTietT__E34DF085D9112CA1", x => x.ChiTietThuocID);
                    table.ForeignKey(
                        name: "FK__ChiTietTh__BenhN__4D94879B",
                        column: x => x.BenhNhanID,
                        principalTable: "BenhNhan",
                        principalColumn: "BenhNhanID");
                    table.ForeignKey(
                        name: "FK__ChiTietTh__Thuoc__4E88ABD4",
                        column: x => x.ThuocID,
                        principalTable: "Thuoc",
                        principalColumn: "ThuocID");
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    HoaDonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenhNhanID = table.Column<int>(type: "int", nullable: false),
                    TienPhong = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TienThuoc = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(11,2)", nullable: true, computedColumnSql: "([TienPhong]+[TienThuoc])", stored: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HoaDon__6956CE69F0192C85", x => x.HoaDonID);
                    table.ForeignKey(
                        name: "FK__HoaDon__BenhNhan__5535A963",
                        column: x => x.BenhNhanID,
                        principalTable: "BenhNhan",
                        principalColumn: "BenhNhanID");
                });

            migrationBuilder.CreateTable(
                name: "ThanhToan",
                columns: table => new
                {
                    ThanhToanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoaDonID = table.Column<int>(type: "int", nullable: false),
                    HinhThuc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgayThanhToan = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    SoTien = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ThuNganID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ThanhToa__24A8D684071FDBE2", x => x.ThanhToanID);
                    table.ForeignKey(
                        name: "FK__ThanhToan__HoaDo__5812160E",
                        column: x => x.HoaDonID,
                        principalTable: "HoaDon",
                        principalColumn: "HoaDonID");
                    table.ForeignKey(
                        name: "FK__ThanhToan__ThuNg__6754599E",
                        column: x => x.ThuNganID,
                        principalTable: "ThuNgan",
                        principalColumn: "ThuNganID");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Admin__536C85E4398DF850",
                table: "Admin",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BenhNhan_BacSiID",
                table: "BenhNhan",
                column: "BacSiID");

            migrationBuilder.CreateIndex(
                name: "IX_BenhNhan_KhoaID",
                table: "BenhNhan",
                column: "KhoaID");

            migrationBuilder.CreateIndex(
                name: "IX_BenhNhan_PhongID",
                table: "BenhNhan",
                column: "PhongID");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhong_BenhNhanID",
                table: "ChiTietPhong",
                column: "BenhNhanID");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhong_PhongID",
                table: "ChiTietPhong",
                column: "PhongID");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietThuoc_BenhNhanID",
                table: "ChiTietThuoc",
                column: "BenhNhanID");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietThuoc_ThuocID",
                table: "ChiTietThuoc",
                column: "ThuocID");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_BenhNhanID",
                table: "HoaDon",
                column: "BenhNhanID");

            migrationBuilder.CreateIndex(
                name: "UQ__Khoa__AAD3615830EED0CA",
                table: "Khoa",
                column: "TenKhoa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phong_KhoaID",
                table: "Phong",
                column: "KhoaID");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToan_HoaDonID",
                table: "ThanhToan",
                column: "HoaDonID");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToan_ThuNganID",
                table: "ThanhToan",
                column: "ThuNganID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "ChiTietPhong");

            migrationBuilder.DropTable(
                name: "ChiTietThuoc");

            migrationBuilder.DropTable(
                name: "ThanhToan");

            migrationBuilder.DropTable(
                name: "YTa");

            migrationBuilder.DropTable(
                name: "Thuoc");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "ThuNgan");

            migrationBuilder.DropTable(
                name: "BenhNhan");

            migrationBuilder.DropTable(
                name: "BacSi");

            migrationBuilder.DropTable(
                name: "Phong");

            migrationBuilder.DropTable(
                name: "Khoa");
        }
    }
}
