using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebQuanLySuKienAmNhac.Models;

public partial class QlskmsContext : DbContext
{
    public QlskmsContext()
    {
    }

    public QlskmsContext(DbContextOptions<QlskmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventArtist> EventArtists { get; set; }

    public virtual DbSet<EventSponsor> EventSponsors { get; set; }

    public virtual DbSet<Sponsor> Sponsors { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-RUUP3FM6\\SQLEXPRESS;Database=QLSKMS;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Events__7944C87002AD5B33");

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EventDate).HasColumnType("datetime");
            entity.Property(e => e.EventName).HasMaxLength(200);
            entity.Property(e => e.Venue).HasMaxLength(200);
        });

        modelBuilder.Entity<EventArtist>(entity =>
        {
            entity.HasKey(e => e.EventArtistId).HasName("PK__EventArt__8C50A8457D662006");

            entity.Property(e => e.EventArtistId).HasColumnName("EventArtistID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Event).WithMany(p => p.EventArtists)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventArti__Event__3E52440B");

            entity.HasOne(d => d.User).WithMany(p => p.EventArtists)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventArti__UserI__3F466844");
        });

        modelBuilder.Entity<EventSponsor>(entity =>
        {
            entity.HasKey(e => e.EventSponsorId).HasName("PK__EventSpo__8AE4D1B57FC9DDB5");

            entity.Property(e => e.EventSponsorId).HasColumnName("EventSponsorID");
            entity.Property(e => e.Contribution).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.SponsorId).HasColumnName("SponsorID");

            entity.HasOne(d => d.Event).WithMany(p => p.EventSponsors)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventSpon__Event__4BAC3F29");

            entity.HasOne(d => d.Sponsor).WithMany(p => p.EventSponsors)
                .HasForeignKey(d => d.SponsorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventSpon__Spons__4CA06362");
        });

        modelBuilder.Entity<Sponsor>(entity =>
        {
            entity.HasKey(e => e.SponsorId).HasName("PK__Sponsors__3B609EF5A711AF8F");

            entity.HasIndex(e => e.ContactEmail, "UQ__Sponsors__FFA796CDBF8944C2").IsUnique();

            entity.Property(e => e.SponsorId).HasColumnName("SponsorID");
            entity.Property(e => e.ContactEmail).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.SponsorName).HasMaxLength(200);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Tickets__712CC627A416A2E0");

            entity.Property(e => e.TicketId).HasColumnName("TicketID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.IssuedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TicketType).HasMaxLength(10);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Event).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tickets__EventID__440B1D61");

            entity.HasOne(d => d.User).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tickets__UserID__44FF419A");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC86DD8397");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534DCB54897").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.UserType).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
