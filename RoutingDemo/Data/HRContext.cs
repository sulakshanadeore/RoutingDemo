using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RoutingDemo.ModelsData;

namespace RoutingDemo.Data;

public partial class HRContext : DbContext
{
    //public HRContext()
    //{
    //}

    public HRContext(DbContextOptions<HRContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<EmpSkill> EmpSkills { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentSubject> StudentSubjects { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=desktop-bo7rkuv;Initial Catalog=HRSecond;User Id=sa;Password=User$2025;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptId);

            entity.Property(e => e.DeptId).HasColumnName("DeptID");
        });

        modelBuilder.Entity<EmpSkill>(entity =>
        {
            entity.HasKey(e => new { e.Empdid, e.SkillId });

            entity.HasIndex(e => e.SkillId, "IX_EmpSkills_SkillId");

            entity.HasOne(d => d.Empd).WithMany(p => p.EmpSkills).HasForeignKey(d => d.Empdid);

            entity.HasOne(d => d.Skill).WithMany(p => p.EmpSkills).HasForeignKey(d => d.SkillId);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId);

            entity.HasIndex(e => e.DeptId, "IX_Employees_DeptID");

            entity.Property(e => e.DeptId).HasColumnName("DeptID");

            entity.HasOne(d => d.Dept).WithMany(p => p.Employees).HasForeignKey(d => d.DeptId);
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.Property(e => e.SkillId).HasColumnName("SkillID");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.RollNo);
        });

        modelBuilder.Entity<StudentSubject>(entity =>
        {
            entity.HasKey(e => new { e.RollNo, e.SubId });

            entity.HasIndex(e => e.SubId, "IX_StudentSubjects_SubID");

            entity.Property(e => e.SubId).HasColumnName("SubID");

            entity.HasOne(d => d.RollNoNavigation).WithMany(p => p.StudentSubjects).HasForeignKey(d => d.RollNo);

            entity.HasOne(d => d.Sub).WithMany(p => p.StudentSubjects).HasForeignKey(d => d.SubId);
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubId);

            entity.Property(e => e.SubId).HasColumnName("SubID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
