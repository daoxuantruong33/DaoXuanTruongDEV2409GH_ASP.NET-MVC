using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NetCoreMVCLab09.Models;

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

    public virtual DbSet<Banner> Banners { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Extension> Extensions { get; set; }

    public virtual DbSet<InforCompany> InforCompanies { get; set; }

    public virtual DbSet<Introduction> Introductions { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

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
