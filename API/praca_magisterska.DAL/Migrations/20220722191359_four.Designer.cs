// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using praca_magisterska.DAL.DbModels;

namespace praca_magisterska.DAL.Migrations
{
    [DbContext(typeof(DiaryDataSourceContext))]
    [Migration("20220722191359_four")]
    partial class four
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("praca_magisterska.DAL.DbModels.Class", b =>
                {
                    b.Property<long>("ClassID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Capacity")
                        .HasColumnType("numeric(9,3)")
                        .HasColumnName("Capacity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Name");

                    b.HasKey("ClassID");

                    b.ToTable("CLASS");
                });

            modelBuilder.Entity("praca_magisterska.DAL.DbModels.Grade", b =>
                {
                    b.Property<long>("GradeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Name");

                    b.Property<long>("StudentID")
                        .HasMaxLength(64)
                        .HasColumnType("bigint")
                        .HasColumnName("Student_ID");

                    b.Property<long>("SubjectID")
                        .HasColumnType("bigint");

                    b.Property<long>("TeacherID")
                        .HasMaxLength(64)
                        .HasColumnType("bigint")
                        .HasColumnName("Subject_ID");

                    b.HasKey("GradeID");

                    b.ToTable("GRADE");
                });

            modelBuilder.Entity("praca_magisterska.DAL.DbModels.Role", b =>
                {
                    b.Property<long>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Name");

                    b.HasKey("RoleID");

                    b.ToTable("ROLE");
                });

            modelBuilder.Entity("praca_magisterska.DAL.DbModels.Subject", b =>
                {
                    b.Property<long>("SubjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ClassID")
                        .HasMaxLength(64)
                        .HasColumnType("bigint")
                        .HasColumnName("Class_ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Name");

                    b.HasKey("SubjectID");

                    b.ToTable("SUBJECTS");
                });

            modelBuilder.Entity("praca_magisterska.DAL.DbModels.User", b =>
                {
                    b.Property<long>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("AccountName");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Address");

                    b.Property<DateTime>("BornDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("BornDate");

                    b.Property<long?>("ClassID")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("FirstName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(254)
                        .IsUnicode(false)
                        .HasColumnType("varchar(254)")
                        .HasColumnName("Password");

                    b.Property<long?>("RoleID")
                        .HasColumnType("bigint");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("SecondName");

                    b.HasKey("UserID");

                    b.HasIndex("ClassID");

                    b.HasIndex("RoleID")
                        .IsUnique()
                        .HasFilter("[RoleID] IS NOT NULL");

                    b.ToTable("USER");
                });

            modelBuilder.Entity("praca_magisterska.DAL.DbModels.User", b =>
                {
                    b.HasOne("praca_magisterska.DAL.DbModels.Class", "Class")
                        .WithMany("Users")
                        .HasForeignKey("ClassID");

                    b.HasOne("praca_magisterska.DAL.DbModels.Role", "Role")
                        .WithOne("User")
                        .HasForeignKey("praca_magisterska.DAL.DbModels.User", "RoleID");

                    b.Navigation("Class");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("praca_magisterska.DAL.DbModels.Class", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("praca_magisterska.DAL.DbModels.Role", b =>
                {
                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
