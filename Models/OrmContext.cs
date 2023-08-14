using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ORM.Models;

public partial class OrmContext : DbContext
{
    public OrmContext()
    {
    }

    public OrmContext(DbContextOptions<OrmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Professor> Professors { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=ORM;user=root;password=Kode1234!", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PRIMARY");

            entity.ToTable("address");

            entity.HasIndex(e => e.CityId, "CityID");

            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.Street).HasMaxLength(255);

            entity.HasOne(d => d.City).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("address_ibfk_1");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PRIMARY");

            entity.ToTable("city");

            entity.HasIndex(e => e.CountryId, "CountryID");

            entity.Property(e => e.CityId)
                .ValueGeneratedNever()
                .HasColumnName("CityID");
            entity.Property(e => e.CityName).HasMaxLength(255);
            entity.Property(e => e.CountryId).HasColumnName("CountryID");

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("city_ibfk_1");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PRIMARY");

            entity.ToTable("class");

            entity.HasIndex(e => e.ProfessorId, "ProfessorID");

            entity.Property(e => e.ClassId)
                .ValueGeneratedNever()
                .HasColumnName("ClassID");
            entity.Property(e => e.ClassName).HasMaxLength(255);
            entity.Property(e => e.ProfessorId).HasColumnName("ProfessorID");

            entity.HasOne(d => d.Professor).WithMany(p => p.Classes)
                .HasForeignKey(d => d.ProfessorId)
                .HasConstraintName("class_ibfk_1");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PRIMARY");

            entity.ToTable("country");

            entity.Property(e => e.CountryId)
                .ValueGeneratedNever()
                .HasColumnName("CountryID");
            entity.Property(e => e.CountryName).HasMaxLength(255);
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PRIMARY");

            entity.ToTable("grade");

            entity.HasIndex(e => e.ProfessorId, "ProfessorID");

            entity.HasIndex(e => e.StudentId, "StudentID");

            entity.Property(e => e.GradeId).HasColumnName("GradeID");
            entity.Property(e => e.ProfessorId).HasColumnName("ProfessorID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Professor).WithMany(p => p.Grades)
                .HasForeignKey(d => d.ProfessorId)
                .HasConstraintName("grade_ibfk_2");

            entity.HasOne(d => d.Student).WithMany(p => p.Grades)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("grade_ibfk_1");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PRIMARY");

            entity.ToTable("person");

            entity.HasIndex(e => e.AddressId, "AddressID");

            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.EmailAddress).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);

            entity.HasOne(d => d.Address).WithMany(p => p.People)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("person_ibfk_1");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PRIMARY");

            entity.ToTable("professor");

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnName("PersonID");

            entity.HasOne(d => d.Person).WithOne(p => p.Professor)
                .HasForeignKey<Professor>(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("professor_ibfk_1");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PRIMARY");

            entity.ToTable("student");

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnName("PersonID");
            entity.Property(e => e.StudentNumber).HasMaxLength(255);

            entity.HasOne(d => d.Person).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("student_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
