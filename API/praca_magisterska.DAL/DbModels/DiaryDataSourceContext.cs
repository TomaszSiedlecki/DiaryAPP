using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace praca_magisterska.DAL.DbModels
{
    public partial class DiaryDataSourceContext : DbContext
    {
        public DiaryDataSourceContext (DbContextOptions<DiaryDataSourceContext> options)
            : base(options)
        {

        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER")
                    .HasKey(e => e.UserID);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FirstName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecondName)
                    .IsRequired()
                    .HasColumnName("SecondName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("Address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasColumnName("AccountName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("Password")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.BornDate)
                    .IsRequired()
                    .HasColumnName("BornDate");

                entity.HasOne(e => e.Class)
                    .WithMany(fs => fs.Users)
                    .HasForeignKey(fs => fs.ClassID);

                entity.HasOne(e => e.Role)
                    .WithOne(fs => fs.User)
                    .HasForeignKey<User>(e => e.RoleID);
            });


            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("SUBJECTS")
                    .HasKey(e => e.SubjectID);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClassID)
                    .IsRequired()
                    .HasColumnName("Class_ID")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE")
                    .HasKey(e => e.RoleID);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("Description")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("GRADE")
                    .HasKey(e => e.GradeID);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentID)
                    .IsRequired()
                    .HasColumnName("Student_ID")
                    .HasMaxLength(64);
                
                entity.Property(e => e.TeacherID)
                    .IsRequired()
                    .HasColumnName("Teacher_ID")
                    .HasMaxLength(64);

                entity.Property(e => e.TeacherID)
                    .IsRequired()
                    .HasColumnName("Subject_ID")
                    .HasMaxLength(64);
    
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("CLASS")
                    .HasKey(e => e.ClassID);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Capacity)
                    .IsRequired()
                    .HasColumnName("Capacity")
                    .HasColumnType("numeric(9,3)");

            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
