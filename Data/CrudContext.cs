using System;
using System.Collections.Generic;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Data;

public partial class CrudContext : DbContext
{
    public CrudContext()
    {
    }

    public CrudContext(DbContextOptions<CrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Initial Catalog=CRUD;Persist Security Info=False;User ID=sa;Password=aptech;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DId).HasName("PK__departme__D95F582BF621B248");

            entity.ToTable("department");

            entity.Property(e => e.DId).HasColumnName("d_id");
            entity.Property(e => e.Department1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("department");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07CDCE3FD0");

            entity.ToTable("Employee");

            entity.Property(e => e.DId).HasColumnName("d_Id");
            entity.Property(e => e.EDesig)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("e_desig");
            entity.Property(e => e.EEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("e_email");
            entity.Property(e => e.EName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("e_name");

            entity.HasOne(d => d.DIdNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DId)
                .HasConstraintName("FK__Employee__d_Id__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
