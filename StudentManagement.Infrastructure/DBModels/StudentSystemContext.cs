using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Infrastructure.DBModels;

public partial class StudentSystemContext : DbContext
{
    public StudentSystemContext()
    {
    }

    public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblApiversion> TblApiversions { get; set; }

    public virtual DbSet<TblStandard> TblStandards { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblUserType> TblUserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-V06VDPI\\SQLEXPRESS;Database=StudentSystem;User Id=sa;Password=sa@123;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblApiversion>(entity =>
        {
            entity.ToTable("tblAPIVersion");

            entity.Property(e => e.Apiversion).HasColumnName("APIVersion");
        });

        modelBuilder.Entity<TblStandard>(entity =>
        {
            entity.ToTable("tblStandard");

            entity.Property(e => e.Standard)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblStudent");

            entity.ToTable("tblUsers");

            entity.Property(e => e.Address)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.ContactNo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FatherOccupation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MotherOcuupation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Photo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.StandardNavigation).WithMany(p => p.TblUsers)
                .HasForeignKey(d => d.Standard)
                .HasConstraintName("FK_tblUsers_tblStandard");

            entity.HasOne(d => d.UserTypeNavigation).WithMany(p => p.TblUsers)
                .HasForeignKey(d => d.UserType)
                .HasConstraintName("FK_tblUsers_tblUserType");
        });

        modelBuilder.Entity<TblUserType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblUser");

            entity.ToTable("tblUserType");

            entity.Property(e => e.UserType)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
