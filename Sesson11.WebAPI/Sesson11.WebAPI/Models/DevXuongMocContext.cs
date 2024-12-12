using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sesson11.WebAPI.Models;

public partial class DevXuongMocContext : DbContext
{
    public DevXuongMocContext()
    {
    }

    public DevXuongMocContext(DbContextOptions<DevXuongMocContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminLog> AdminLogs { get; set; }

    public virtual DbSet<AdminUser> AdminUsers { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Banner> Banners { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Extension> Extensions { get; set; }

    public virtual DbSet<InforCompany> InforCompanies { get; set; }

    public virtual DbSet<Introduction> Introductions { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrdersDetail> OrdersDetails { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductExtension> ProductExtensions { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ProductMaterial> ProductMaterials { get; set; }

    public virtual DbSet<Slide> Slides { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-RUUP3FM6\\SQLEXPRESS;Database=DevXuongMoc;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__ADMIN_LO__4364C882D61AF4AF");

            entity.ToTable("ADMIN_LOG");

            entity.Property(e => e.LogId).HasColumnName("LOG_ID");
            entity.Property(e => e.ActionCode)
                .HasMaxLength(250)
                .HasColumnName("ACTION_CODE");
            entity.Property(e => e.ActionName)
                .HasMaxLength(250)
                .HasColumnName("ACTION_NAME");
            entity.Property(e => e.ActionType).HasColumnName("ACTION_TYPE");
            entity.Property(e => e.AdminUserId).HasColumnName("ADMIN_USER_ID");
            entity.Property(e => e.AppCode)
                .HasMaxLength(150)
                .HasColumnName("APP_CODE");
            entity.Property(e => e.Content).HasColumnName("CONTENT");
            entity.Property(e => e.Description)
                .HasMaxLength(550)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("END_TIME");
            entity.Property(e => e.ErrorCode)
                .HasMaxLength(500)
                .HasColumnName("ERROR_CODE");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(50)
                .HasColumnName("IP_ADDRESS");
            entity.Property(e => e.LogLevel).HasColumnName("LOG_LEVEL");
            entity.Property(e => e.MenuCode)
                .HasMaxLength(150)
                .HasColumnName("MENU_CODE");
            entity.Property(e => e.MenuName)
                .HasMaxLength(250)
                .HasColumnName("MENU_NAME");
            entity.Property(e => e.ObjectId).HasColumnName("OBJECT_ID");
            entity.Property(e => e.SessionId)
                .HasMaxLength(150)
                .HasColumnName("SESSION_ID");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("START_TIME");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.ThreadId)
                .HasMaxLength(150)
                .HasColumnName("THREAD_ID");
            entity.Property(e => e.UserLogin)
                .HasMaxLength(150)
                .HasColumnName("USER_LOGIN");
            entity.Property(e => e.UserName)
                .HasMaxLength(250)
                .HasColumnName("USER_NAME");
            entity.Property(e => e.WebpagesActionId).HasColumnName("WEBPAGES_ACTION_ID");
        });

        modelBuilder.Entity<AdminUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ADMIN_US__3214EC2739901ACE");

            entity.ToTable("ADMIN_USER");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Account)
                .HasMaxLength(200)
                .HasColumnName("ACCOUNT");
            entity.Property(e => e.Avatar)
                .HasMaxLength(200)
                .HasColumnName("AVATAR");
            entity.Property(e => e.Email)
                .HasMaxLength(500)
                .HasColumnName("EMAIL");
            entity.Property(e => e.IdPhongBan).HasColumnName("ID_PHONG_BAN");
            entity.Property(e => e.IsAdmin).HasColumnName("IS_ADMIN");
            entity.Property(e => e.IsDelete).HasColumnName("IS_DELETE");
            entity.Property(e => e.MaNhanSu).HasColumnName("MA_NHAN_SU");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("NAME");
            entity.Property(e => e.NgayCapNhat)
                .HasColumnType("datetime")
                .HasColumnName("NGAY_CAP_NHAT");
            entity.Property(e => e.NgayTao)
                .HasColumnType("datetime")
                .HasColumnName("NGAY_TAO");
            entity.Property(e => e.NguoiCapNhat)
                .HasMaxLength(200)
                .HasColumnName("NGUOI_CAP_NHAT");
            entity.Property(e => e.NguoiTao)
                .HasMaxLength(200)
                .HasColumnName("NGUOI_TAO");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Phone)
                .HasMaxLength(30)
                .HasColumnName("PHONE");
            entity.Property(e => e.Salt)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SALT");
            entity.Property(e => e.SessionToken)
                .HasMaxLength(500)
                .HasColumnName("SESSION_TOKEN");
            entity.Property(e => e.TrangThai).HasColumnName("TRANG_THAI");
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Banner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BANNER__3214EC274D7E8BD5");

            entity.ToTable("BANNER");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdminCreated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_CREATED");
            entity.Property(e => e.AdminUpdated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_UPDATED");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("IMAGE");
            entity.Property(e => e.Isdelete).HasColumnName("ISDELETE");
            entity.Property(e => e.Notes).HasColumnName("NOTES");
            entity.Property(e => e.Orders).HasColumnName("ORDERS");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.SubTitle)
                .HasMaxLength(255)
                .HasColumnName("SUB_TITLE");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("TITLE");
            entity.Property(e => e.Type)
                .HasMaxLength(500)
                .HasColumnName("TYPE");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
            entity.Property(e => e.Urls)
                .HasMaxLength(255)
                .HasColumnName("URLS");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PRODUCT___A88186B13985BFD1");

            entity.ToTable("CATEGORY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdminCreated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_CREATED");
            entity.Property(e => e.AdminUpdated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_UPDATED");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Icon)
                .HasMaxLength(200)
                .HasColumnName("ICON");
            entity.Property(e => e.Isdelete)
                .HasDefaultValue(false)
                .HasColumnName("ISDELETE");
            entity.Property(e => e.MateTitle)
                .HasMaxLength(500)
                .HasColumnName("MATE_TITLE");
            entity.Property(e => e.MetaDescription)
                .HasMaxLength(500)
                .HasColumnName("META_DESCRIPTION");
            entity.Property(e => e.MetaKeyword)
                .HasMaxLength(500)
                .HasColumnName("META_KEYWORD");
            entity.Property(e => e.Notes)
                .HasColumnType("ntext")
                .HasColumnName("NOTES");
            entity.Property(e => e.Orders).HasColumnName("ORDERS");
            entity.Property(e => e.Parentid).HasColumnName("PARENTID");
            entity.Property(e => e.Slug)
                .HasMaxLength(500)
                .HasColumnName("SLUG");
            entity.Property(e => e.Status)
                .HasDefaultValue((byte)1)
                .HasColumnName("STATUS");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("TITLE");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.ToTable("CONTACT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.AdminCreated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_CREATED");
            entity.Property(e => e.AdminUpdated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_UPDATED");
            entity.Property(e => e.Content)
                .HasColumnType("ntext")
                .HasColumnName("CONTENT");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Isdelete).HasColumnName("ISDELETE");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("PHONE");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("TITLE");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CUSTOMER__3214EC273DCDA2D2");

            entity.ToTable("CUSTOMER");

            entity.HasIndex(e => e.Username, "UQ__CUSTOMER__B15BE12E0B31281A").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .HasColumnName("AVATAR");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Isactive)
                .HasDefaultValue(true)
                .HasColumnName("ISACTIVE");
            entity.Property(e => e.Isdelete)
                .HasDefaultValue(false)
                .HasColumnName("ISDELETE");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("NAME");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("PHONE");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(100)
                .HasColumnName("UPDATED_BY");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("USERNAME");
        });

        modelBuilder.Entity<Extension>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PRODUCT___EXTENSION");

            entity.ToTable("EXTENSION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdminCreated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_CREATED");
            entity.Property(e => e.AdminUpdated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_UPDATED");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Icon)
                .HasMaxLength(200)
                .HasColumnName("ICON");
            entity.Property(e => e.Isdelete)
                .HasDefaultValue(false)
                .HasColumnName("ISDELETE");
            entity.Property(e => e.MetaDescription)
                .HasMaxLength(500)
                .HasColumnName("META_DESCRIPTION");
            entity.Property(e => e.MetaKeyword)
                .HasMaxLength(500)
                .HasColumnName("META_KEYWORD");
            entity.Property(e => e.MetaTitle)
                .HasMaxLength(500)
                .HasColumnName("META_TITLE");
            entity.Property(e => e.Notes)
                .HasColumnType("ntext")
                .HasColumnName("NOTES");
            entity.Property(e => e.Orders).HasColumnName("ORDERS");
            entity.Property(e => e.Parentid).HasColumnName("PARENTID");
            entity.Property(e => e.Slug)
                .HasMaxLength(500)
                .HasColumnName("SLUG");
            entity.Property(e => e.Status)
                .HasDefaultValue((byte)1)
                .HasColumnName("STATUS");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("TITLE");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
        });

        modelBuilder.Entity<InforCompany>(entity =>
        {
            entity.ToTable("INFOR_COMPANY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.AdminCreated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_CREATED");
            entity.Property(e => e.AdminUpdated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_UPDATED");
            entity.Property(e => e.CreatedDate).HasColumnName("CREATED_DATE");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Facebook)
                .HasMaxLength(500)
                .HasColumnName("FACEBOOK");
            entity.Property(e => e.Instagram)
                .HasMaxLength(500)
                .HasColumnName("INSTAGRAM");
            entity.Property(e => e.Logo)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("LOGO");
            entity.Property(e => e.MetaDescription)
                .HasMaxLength(500)
                .HasColumnName("META_DESCRIPTION");
            entity.Property(e => e.MetaKeyword)
                .HasMaxLength(500)
                .HasColumnName("META_KEYWORD");
            entity.Property(e => e.MetaTitle)
                .HasMaxLength(500)
                .HasColumnName("META_TITLE");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("NAME");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("PHONE");
            entity.Property(e => e.UpdateDate).HasColumnName("UPDATE_DATE");
            entity.Property(e => e.Youtube)
                .HasMaxLength(500)
                .HasColumnName("YOUTUBE");
        });

        modelBuilder.Entity<Introduction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__INTRODUC__3214EC2715DFAD94");

            entity.ToTable("INTRODUCTIONS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdminCreated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_CREATED");
            entity.Property(e => e.AdminUpdated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_UPDATED");
            entity.Property(e => e.Content).HasColumnName("CONTENT");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Description).HasColumnName("DESCRIPTION");
            entity.Property(e => e.Home).HasColumnName("HOME");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasDefaultValue("NO_IMAGE_AVAILABLE.jpg")
                .HasColumnName("IMAGE");
            entity.Property(e => e.Isdelete).HasColumnName("ISDELETE");
            entity.Property(e => e.MetaDescription)
                .HasMaxLength(4000)
                .HasColumnName("META_DESCRIPTION");
            entity.Property(e => e.MetaKeyword)
                .HasMaxLength(500)
                .HasColumnName("META_KEYWORD");
            entity.Property(e => e.MetaTitle)
                .HasMaxLength(500)
                .HasColumnName("META_TITLE");
            entity.Property(e => e.Orders).HasColumnName("ORDERS");
            entity.Property(e => e.Parentid).HasColumnName("PARENTID");
            entity.Property(e => e.Slug)
                .HasMaxLength(500)
                .HasColumnName("SLUG");
            entity.Property(e => e.Status)
                .HasDefaultValue((byte)1)
                .HasColumnName("STATUS");
            entity.Property(e => e.Title)
                .HasMaxLength(300)
                .HasColumnName("TITLE");
            entity.Property(e => e.Type).HasColumnName("TYPE");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MATERIAL___EXTENSION");

            entity.ToTable("MATERIAL");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdminCreated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_CREATED");
            entity.Property(e => e.AdminUpdated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_UPDATED");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Icon)
                .HasMaxLength(200)
                .HasColumnName("ICON");
            entity.Property(e => e.Isdelete).HasColumnName("ISDELETE");
            entity.Property(e => e.MetaDescription)
                .HasMaxLength(500)
                .HasColumnName("META_DESCRIPTION");
            entity.Property(e => e.MetaKeyword)
                .HasMaxLength(500)
                .HasColumnName("META_KEYWORD");
            entity.Property(e => e.MetaTitle)
                .HasMaxLength(500)
                .HasColumnName("META_TITLE");
            entity.Property(e => e.Notes)
                .HasColumnType("ntext")
                .HasColumnName("NOTES");
            entity.Property(e => e.Orders).HasColumnName("ORDERS");
            entity.Property(e => e.Parentid).HasColumnName("PARENTID");
            entity.Property(e => e.Slug)
                .HasMaxLength(500)
                .HasColumnName("SLUG");
            entity.Property(e => e.Status).HasColumnName("STATUS");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("TITLE");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NEWS__3214EC27E639B94D");

            entity.ToTable("NEWS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdminCreated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_CREATED");
            entity.Property(e => e.AdminUpdated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_UPDATED");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasColumnName("CODE");
            entity.Property(e => e.Content)
                .HasColumnType("ntext")
                .HasColumnName("CONTENT");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Description).HasColumnName("DESCRIPTION");
            entity.Property(e => e.Image)
                .HasDefaultValue("NO_IMAGE_AVAILABLE.jpg")
                .HasColumnName("IMAGE");
            entity.Property(e => e.Isdelete)
                .HasDefaultValue(false)
                .HasColumnName("ISDELETE");
            entity.Property(e => e.Likes).HasColumnName("LIKES");
            entity.Property(e => e.MainKeyword)
                .HasMaxLength(500)
                .HasColumnName("MAIN_KEYWORD");
            entity.Property(e => e.MetaDescription)
                .HasMaxLength(500)
                .HasColumnName("META_DESCRIPTION");
            entity.Property(e => e.MetaKeyword)
                .HasMaxLength(500)
                .HasColumnName("META_KEYWORD");
            entity.Property(e => e.MetaTitle)
                .HasMaxLength(500)
                .HasColumnName("META_TITLE");
            entity.Property(e => e.Slug)
                .HasMaxLength(500)
                .HasColumnName("SLUG");
            entity.Property(e => e.Star).HasColumnName("STAR");
            entity.Property(e => e.Status)
                .HasDefaultValue((byte)1)
                .HasColumnName("STATUS");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("TITLE");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
            entity.Property(e => e.Views).HasColumnName("VIEWS");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ORDERS__3214EC27993EE4AE");

            entity.ToTable("ORDERS");

            entity.HasIndex(e => e.Idorders, "UQ__ORDERS__99356D843C30ABDF").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Idcustomer).HasColumnName("IDCUSTOMER");
            entity.Property(e => e.Idorders)
                .HasMaxLength(100)
                .HasColumnName("IDORDERS");
            entity.Property(e => e.Idpayment).HasColumnName("IDPAYMENT");
            entity.Property(e => e.Isactive)
                .HasDefaultValue(true)
                .HasColumnName("ISACTIVE");
            entity.Property(e => e.Isdelete)
                .HasDefaultValue(false)
                .HasColumnName("ISDELETE");
            entity.Property(e => e.NameReceiver)
                .HasMaxLength(255)
                .HasColumnName("NAME_RECEIVER");
            entity.Property(e => e.Notes).HasColumnName("NOTES");
            entity.Property(e => e.OrdersDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ORDERS_DATE");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("PHONE");
            entity.Property(e => e.TotalMoney)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TOTAL_MONEY");

            entity.HasOne(d => d.IdcustomerNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Idcustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ORDERS__IDCUSTOM__0E6E26BF");
        });

        modelBuilder.Entity<OrdersDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ORDERS_D__3214EC27394477F4");

            entity.ToTable("ORDERS_DETAILS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idord).HasColumnName("IDORD");
            entity.Property(e => e.Idproduct).HasColumnName("IDPRODUCT");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PRICE");
            entity.Property(e => e.Qty).HasColumnName("QTY");
            entity.Property(e => e.ReturnQty)
                .HasDefaultValue(0)
                .HasColumnName("RETURN_QTY");
            entity.Property(e => e.Total)
                .HasComputedColumnSql("([PRICE]*[QTY])", true)
                .HasColumnType("decimal(29, 2)")
                .HasColumnName("TOTAL");

            entity.HasOne(d => d.IdordNavigation).WithMany(p => p.OrdersDetails)
                .HasForeignKey(d => d.Idord)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ORDERS_DE__IDORD__123EB7A3");

            entity.HasOne(d => d.IdproductNavigation).WithMany(p => p.OrdersDetails)
                .HasForeignKey(d => d.Idproduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ORDERS_DE__IDPRO__1332DBDC");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PARTNER__3214EC27FF6F5E7C");

            entity.ToTable("PARTNER");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdminCreated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_CREATED");
            entity.Property(e => e.AdminUpdated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_UPDATED");
            entity.Property(e => e.Content).HasColumnName("CONTENT");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Isdelete)
                .HasDefaultValue(false)
                .HasColumnName("ISDELETE");
            entity.Property(e => e.Logo)
                .HasMaxLength(255)
                .HasDefaultValue("NO_IMAGE_AVAILABLE.jpg")
                .HasColumnName("LOGO");
            entity.Property(e => e.Orders)
                .HasDefaultValue((byte)1)
                .HasColumnName("ORDERS");
            entity.Property(e => e.Status)
                .HasDefaultValue((byte)1)
                .HasColumnName("STATUS");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("TITLE");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("URL");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.ToTable("PAYMENT_METHOD");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Isactive).HasColumnName("ISACTIVE");
            entity.Property(e => e.Isdelete).HasColumnName("ISDELETE");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("NAME");
            entity.Property(e => e.Notes)
                .HasColumnType("ntext")
                .HasColumnName("NOTES");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PRODUCT__3214EC27E639B94D");

            entity.ToTable("PRODUCT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdminCreated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_CREATED");
            entity.Property(e => e.AdminUpdated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_UPDATED");
            entity.Property(e => e.Cid).HasColumnName("CID");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .HasColumnName("CODE");
            entity.Property(e => e.Content).HasColumnName("CONTENT");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Description).HasColumnName("DESCRIPTION");
            entity.Property(e => e.Home)
                .HasDefaultValue((byte)0)
                .HasColumnName("HOME");
            entity.Property(e => e.Hot).HasColumnName("HOT");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasDefaultValue("NO_IMAGE_AVAILABLE.jpg")
                .HasColumnName("IMAGE");
            entity.Property(e => e.Isdelete)
                .HasDefaultValue(false)
                .HasColumnName("ISDELETE");
            entity.Property(e => e.Likes).HasColumnName("LIKES");
            entity.Property(e => e.MetaDescription)
                .HasMaxLength(500)
                .HasColumnName("META_DESCRIPTION");
            entity.Property(e => e.MetaKeyword)
                .HasMaxLength(500)
                .HasColumnName("META_KEYWORD");
            entity.Property(e => e.MetaTitle)
                .HasMaxLength(500)
                .HasColumnName("META_TITLE");
            entity.Property(e => e.PriceNew)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PRICE_NEW");
            entity.Property(e => e.PriceOld)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("PRICE_OLD");
            entity.Property(e => e.Size)
                .HasMaxLength(500)
                .HasColumnName("SIZE");
            entity.Property(e => e.Slug)
                .HasMaxLength(500)
                .HasColumnName("SLUG");
            entity.Property(e => e.Star).HasColumnName("STAR");
            entity.Property(e => e.Status)
                .HasDefaultValue((byte)1)
                .HasColumnName("STATUS");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("TITLE");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
            entity.Property(e => e.Views).HasColumnName("VIEWS");
        });

        modelBuilder.Entity<ProductExtension>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PRODUCTEXTENSIONS");

            entity.ToTable("PRODUCT_EXTENSIONS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Content)
                .HasColumnType("ntext")
                .HasColumnName("CONTENT");
            entity.Property(e => e.Eid).HasColumnName("EID");
            entity.Property(e => e.Pid).HasColumnName("PID");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PRODUCTIMAGES");

            entity.ToTable("PRODUCT_IMAGES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Image)
                .HasMaxLength(500)
                .HasColumnName("IMAGE");
            entity.Property(e => e.Pid).HasColumnName("PID");
        });

        modelBuilder.Entity<ProductMaterial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PRODUCTMATERIALS");

            entity.ToTable("PRODUCT_MATERIALS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Mid).HasColumnName("MID");
            entity.Property(e => e.Pid).HasColumnName("PID");
        });

        modelBuilder.Entity<Slide>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SLIDES__3214EC27A3DAC42D");

            entity.ToTable("SLIDES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdminCreated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_CREATED");
            entity.Property(e => e.AdminUpdated)
                .HasMaxLength(255)
                .HasColumnName("ADMIN_UPDATED");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasDefaultValue("NO_IMAGE_AVAILABLE.jpg")
                .HasColumnName("IMAGE");
            entity.Property(e => e.Isdelete).HasColumnName("ISDELETE");
            entity.Property(e => e.Notes).HasColumnName("NOTES");
            entity.Property(e => e.Orders).HasColumnName("ORDERS");
            entity.Property(e => e.Status)
                .HasDefaultValue((byte)1)
                .HasColumnName("STATUS");
            entity.Property(e => e.SubTitle)
                .HasMaxLength(255)
                .HasColumnName("SUB_TITLE");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("TITLE");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_DATE");
            entity.Property(e => e.Urls)
                .HasMaxLength(255)
                .HasColumnName("URLS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
