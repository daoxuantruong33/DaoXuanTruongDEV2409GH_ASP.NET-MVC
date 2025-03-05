using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuanLyVienPhi.Models;

public partial class QuanLyVienPhiContext : DbContext
{
    public QuanLyVienPhiContext()
    {
    }

    public QuanLyVienPhiContext(DbContextOptions<QuanLyVienPhiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<BacSi> BacSis { get; set; }

    public virtual DbSet<BenhNhan> BenhNhans { get; set; }

    public virtual DbSet<Bhyt> Bhyts { get; set; }

    public virtual DbSet<ChiTietDichVu> ChiTietDichVus { get; set; }

    public virtual DbSet<ChiTietPhong> ChiTietPhongs { get; set; }

    public virtual DbSet<ChiTietThuoc> ChiTietThuocs { get; set; }

    public virtual DbSet<DichVu> DichVus { get; set; }

    public virtual DbSet<DoiTuong> DoiTuongs { get; set; }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<Phong> Phongs { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<ThanhToan> ThanhToans { get; set; }

    public virtual DbSet<ThuNgan> ThuNgans { get; set; }

    public virtual DbSet<Thuoc> Thuocs { get; set; }

    public virtual DbSet<Ytum> Yta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-RUUP3FM6\\SQLEXPRESS;Database=QuanLyVienPhi;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__719FE4E8A5BFF347");

            entity.ToTable("Admin");

            entity.HasIndex(e => e.Username, "UQ__Admin__536C85E4398DF850").IsUnique();

            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Admins)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Admin_Role");
        });

        modelBuilder.Entity<BacSi>(entity =>
        {
            entity.HasKey(e => e.BacSiId).HasName("PK__BacSi__5B2D07542A824BF7");

            entity.ToTable("BacSi");

            entity.Property(e => e.BacSiId).HasColumnName("BacSiID");
            entity.Property(e => e.DienThoai).HasMaxLength(15);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.KhoaId).HasColumnName("KhoaID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Khoa).WithMany(p => p.BacSis)
                .HasForeignKey(d => d.KhoaId)
                .HasConstraintName("FK_BacSi_Khoa");

            entity.HasOne(d => d.Role).WithMany(p => p.BacSis)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_BacSi_Role");
        });

        modelBuilder.Entity<BenhNhan>(entity =>
        {
            entity.HasKey(e => e.BenhNhanId).HasName("PK__BenhNhan__151050A6BBB20004");

            entity.ToTable("BenhNhan");

            entity.Property(e => e.BenhNhanId).HasColumnName("BenhNhanID");
            entity.Property(e => e.BacSiId).HasColumnName("BacSiID");
            entity.Property(e => e.Cccd)
                .HasMaxLength(12)
                .HasColumnName("CCCD");
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.DienThoai).HasMaxLength(15);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.KhoaId).HasColumnName("KhoaID");
            entity.Property(e => e.MienGiam).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PhongId).HasColumnName("PhongID");
            entity.Property(e => e.ThuNganId).HasColumnName("ThuNganID");
            entity.Property(e => e.TienDichVu).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TienPhong).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TienThuoc).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.BacSi).WithMany(p => p.BenhNhans)
                .HasForeignKey(d => d.BacSiId)
                .HasConstraintName("FK__BenhNhan__BacSiI__45F365D3");

            entity.HasOne(d => d.Khoa).WithMany(p => p.BenhNhans)
                .HasForeignKey(d => d.KhoaId)
                .HasConstraintName("FK__BenhNhan__KhoaID__47DBAE45");

            entity.HasOne(d => d.Phong).WithMany(p => p.BenhNhans)
                .HasForeignKey(d => d.PhongId)
                .HasConstraintName("FK__BenhNhan__PhongI__48CFD27E");

            entity.HasOne(d => d.ThuNgan).WithMany(p => p.BenhNhans)
                .HasForeignKey(d => d.ThuNganId)
                .HasConstraintName("FK_BenhNhan_ThuNgan");
        });

        modelBuilder.Entity<Bhyt>(entity =>
        {
            entity.HasKey(e => e.BhytId).HasName("PK__HoaDon__6956CE69F0192C85");

            entity.ToTable("BHYT");

            entity.Property(e => e.BhytId).HasColumnName("BhytID");
            entity.Property(e => e.BenhNhanId).HasColumnName("BenhNhanID");
            entity.Property(e => e.Cccd).HasMaxLength(12);
            entity.Property(e => e.DoiTuongId).HasColumnName("DoiTuongID");
            entity.Property(e => e.MienGiam).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SoTheBhyt)
                .HasMaxLength(13)
                .HasColumnName("SoTheBHYT");

            entity.HasOne(d => d.BenhNhan).WithMany(p => p.Bhyts)
                .HasForeignKey(d => d.BenhNhanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BHYT_BenhNhan");

            entity.HasOne(d => d.DoiTuong).WithMany(p => p.Bhyts)
                .HasForeignKey(d => d.DoiTuongId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BHYT_DoiTuong");
        });

        modelBuilder.Entity<ChiTietDichVu>(entity =>
        {
            entity.ToTable("ChiTietDichVu");

            entity.Property(e => e.ChiTietDichVuId).HasColumnName("ChiTietDichVuID");
            entity.Property(e => e.BenhNhanId).HasColumnName("BenhNhanID");
            entity.Property(e => e.Cccd).HasMaxLength(12);
            entity.Property(e => e.DichVuId).HasColumnName("DichVuID");
            entity.Property(e => e.GiaTien).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.TenDichVu).HasMaxLength(100);

            entity.HasOne(d => d.BenhNhan).WithMany(p => p.ChiTietDichVus)
                .HasForeignKey(d => d.BenhNhanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietDichVu_BenhNhan");

            entity.HasOne(d => d.DichVu).WithMany(p => p.ChiTietDichVus)
                .HasForeignKey(d => d.DichVuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietDichVu_DichVu");
        });

        modelBuilder.Entity<ChiTietPhong>(entity =>
        {
            entity.HasKey(e => e.ChiTietPhongId).HasName("PK__ChiTietP__E1B170CDCFE9E1D9");

            entity.ToTable("ChiTietPhong");

            entity.Property(e => e.ChiTietPhongId).HasColumnName("ChiTietPhongID");
            entity.Property(e => e.BenhNhanId).HasColumnName("BenhNhanID");
            entity.Property(e => e.Cccd)
                .HasMaxLength(12)
                .HasColumnName("CCCD");
            entity.Property(e => e.PhongId).HasColumnName("PhongID");
            entity.Property(e => e.TienPhong).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.BenhNhan).WithMany(p => p.ChiTietPhongs)
                .HasForeignKey(d => d.BenhNhanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPh__BenhN__5165187F");

            entity.HasOne(d => d.Phong).WithMany(p => p.ChiTietPhongs)
                .HasForeignKey(d => d.PhongId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPh__Phong__52593CB8");
        });

        modelBuilder.Entity<ChiTietThuoc>(entity =>
        {
            entity.HasKey(e => e.ChiTietThuocId).HasName("PK__ChiTietT__E34DF085D9112CA1");

            entity.ToTable("ChiTietThuoc");

            entity.Property(e => e.ChiTietThuocId).HasColumnName("ChiTietThuocID");
            entity.Property(e => e.BenhNhanId).HasColumnName("BenhNhanID");
            entity.Property(e => e.Cccd)
                .HasMaxLength(12)
                .HasColumnName("CCCD");
            entity.Property(e => e.ThuocId).HasColumnName("ThuocID");
            entity.Property(e => e.TienThuoc).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.BenhNhan).WithMany(p => p.ChiTietThuocs)
                .HasForeignKey(d => d.BenhNhanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietTh__BenhN__4D94879B");

            entity.HasOne(d => d.Thuoc).WithMany(p => p.ChiTietThuocs)
                .HasForeignKey(d => d.ThuocId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietTh__Thuoc__4E88ABD4");
        });

        modelBuilder.Entity<DichVu>(entity =>
        {
            entity.ToTable("DichVu");

            entity.Property(e => e.DichVuId).HasColumnName("DichVuID");
            entity.Property(e => e.GiaTien).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.TenDichVu).HasMaxLength(100);
        });

        modelBuilder.Entity<DoiTuong>(entity =>
        {
            entity.ToTable("DoiTuong");

            entity.Property(e => e.DoiTuongId)
                .ValueGeneratedNever()
                .HasColumnName("DoiTuongID");
            entity.Property(e => e.MienGiam).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SoThe).HasMaxLength(15);
        });

        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.KhoaId).HasName("PK__Khoa__42EDDF14CB74A22A");

            entity.ToTable("Khoa");

            entity.HasIndex(e => e.TenKhoa, "UQ__Khoa__AAD3615830EED0CA").IsUnique();

            entity.Property(e => e.KhoaId).HasColumnName("KhoaID");
            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.TenKhoa).HasMaxLength(100);
        });

        modelBuilder.Entity<Phong>(entity =>
        {
            entity.HasKey(e => e.PhongId).HasName("PK__Phong__FC669947BC716FF7");

            entity.ToTable("Phong");

            entity.Property(e => e.PhongId).HasColumnName("PhongID");
            entity.Property(e => e.KhoaId).HasColumnName("KhoaID");
            entity.Property(e => e.SoPhong).HasMaxLength(10);
            entity.Property(e => e.TienPhongNgay).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Khoa).WithMany(p => p.Phongs)
                .HasForeignKey(d => d.KhoaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Phong_Khoa");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<ThanhToan>(entity =>
        {
            entity.HasKey(e => e.ThanhToanId).HasName("PK__ThanhToa__24A8D684071FDBE2");

            entity.ToTable("ThanhToan");

            entity.Property(e => e.ThanhToanId).HasColumnName("ThanhToanID");
            entity.Property(e => e.HinhThuc).HasMaxLength(50);
            entity.Property(e => e.HoaDonId).HasColumnName("HoaDonID");
            entity.Property(e => e.NgayThanhToan).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.SoTien).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ThuNganId).HasColumnName("ThuNganID");
        });

        modelBuilder.Entity<ThuNgan>(entity =>
        {
            entity.HasKey(e => e.ThuNganId).HasName("PK__ThuNgan__4CD824F59C05AF03");

            entity.ToTable("ThuNgan");

            entity.Property(e => e.ThuNganId).HasColumnName("ThuNganID");
            entity.Property(e => e.DienThoai).HasMaxLength(15);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Role).WithMany(p => p.ThuNgans)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_ThuNgan_Role");
        });

        modelBuilder.Entity<Thuoc>(entity =>
        {
            entity.HasKey(e => e.ThuocId).HasName("PK__Thuoc__AB5C3E544F77143F");

            entity.ToTable("Thuoc");

            entity.Property(e => e.ThuocId).HasColumnName("ThuocID");
            entity.Property(e => e.GiaTien).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TenThuoc).HasMaxLength(100);
        });

        modelBuilder.Entity<Ytum>(entity =>
        {
            entity.HasKey(e => e.YtaId).HasName("PK__YTa__EF698884567CA9B2");

            entity.ToTable("YTa");

            entity.Property(e => e.YtaId).HasColumnName("YTaID");
            entity.Property(e => e.DienThoai).HasMaxLength(15);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.HoTen).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
