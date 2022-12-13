using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using paycalc.core.Entities;

namespace paycalc.core.dbContext;

public partial class dbContext : DbContext
{
    public dbContext()
    {
    }

    public dbContext(DbContextOptions<dbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Award> Awards { get; set; }

    public virtual DbSet<AwardType> AwardTypes { get; set; }

    public virtual DbSet<Day> Days { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Week> Weeks { get; set; }

    public virtual DbSet<WorkDay> WorkDays { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=FRNCM-LPTP\\SQLEXPRESS;Database=paycalc_db;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Award>(entity =>
        {
            entity.HasKey(e => e.AwardId).HasName("PK__award__994F7452C81831B7");

            entity.ToTable("award");

            entity.Property(e => e.AwardId).HasColumnName("awardID");
            entity.Property(e => e.AwardTypeId).HasColumnName("awardTypeID");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.AwardType).WithMany(p => p.Awards)
                .HasForeignKey(d => d.AwardTypeId)
                .HasConstraintName("FK_AwardType_Award");

            entity.HasOne(d => d.User).WithMany(p => p.Awards)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_User_Award");
        });

        modelBuilder.Entity<AwardType>(entity =>
        {
            entity.HasKey(e => e.AwardTypeId).HasName("PK__awardTyp__0F1CCDBE83A37FE2");

            entity.ToTable("awardType");

            entity.Property(e => e.AwardTypeId).HasColumnName("AwardTypeID");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Day>(entity =>
        {
            entity.HasKey(e => e.DayId).HasName("PK__day__BF3DD825DE9AFBC8");

            entity.ToTable("day");

            entity.Property(e => e.DayId).HasColumnName("DayID");
            entity.Property(e => e.DayName).HasMaxLength(9);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__user__CB9A1CDF863C212D");

            entity.ToTable("user");

            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.BaseRate).HasColumnName("baseRate");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("dateOfBirth");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .HasColumnName("fullname");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Salt)
                .HasMaxLength(32)
                .HasColumnName("salt");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Week>(entity =>
        {
            entity.HasKey(e => e.WeekId).HasName("PK__Week__982269DE4D05D57F");

            entity.ToTable("Week");

            entity.Property(e => e.WeekId).HasColumnName("weekID");
            entity.Property(e => e.TotalPay).HasColumnName("totalPay");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.User).WithMany(p => p.Weeks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_User_Week");
        });

        modelBuilder.Entity<WorkDay>(entity =>
        {
            entity.HasKey(e => e.WordDayId).HasName("PK__workDay__A59C0CC49319AE56");

            entity.ToTable("workDay");

            entity.Property(e => e.WordDayId).HasColumnName("wordDayID");
            entity.Property(e => e.AwardId).HasColumnName("AwardID");
            entity.Property(e => e.WeekId).HasColumnName("weekID");

            entity.HasOne(d => d.Award).WithMany(p => p.WorkDays)
                .HasForeignKey(d => d.AwardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Award_WorkDay");

            entity.HasOne(d => d.Week).WithMany(p => p.WorkDays)
                .HasForeignKey(d => d.WeekId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Week_WorkDay");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
