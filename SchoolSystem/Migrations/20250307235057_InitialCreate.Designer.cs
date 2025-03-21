﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolSystem.Context;

#nullable disable

namespace SchoolSystem.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20250307235057_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SchoolSystem.Entiits.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("SchoolSystem.Entiits.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("SchoolSystem.Entiits.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("BD")
                        .HasColumnType("datetime2");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("HiringDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Job")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NationalID")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Qualification")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("QualificationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SchoolID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SchoolID");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("SchoolSystem.Entiits.TeacherTransfare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FromSchoolID")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<int?>("ToSchoolID")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransferDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FromSchoolID");

                    b.HasIndex("TeacherId");

                    b.HasIndex("ToSchoolID");

                    b.ToTable("Transfares");
                });

            modelBuilder.Entity("SchoolSystem.Entiits.School", b =>
                {
                    b.HasOne("SchoolSystem.Entiits.Department", null)
                        .WithMany("Schools")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolSystem.Entiits.Teacher", b =>
                {
                    b.HasOne("SchoolSystem.Entiits.School", "School")
                        .WithMany("Teachers")
                        .HasForeignKey("SchoolID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("SchoolSystem.Entiits.TeacherTransfare", b =>
                {
                    b.HasOne("SchoolSystem.Entiits.School", "FromSchool")
                        .WithMany("TransfersFrom")
                        .HasForeignKey("FromSchoolID");

                    b.HasOne("SchoolSystem.Entiits.Teacher", "Teacher")
                        .WithMany("Transfares")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystem.Entiits.School", "ToSchool")
                        .WithMany("TransfersTo")
                        .HasForeignKey("ToSchoolID");

                    b.Navigation("FromSchool");

                    b.Navigation("Teacher");

                    b.Navigation("ToSchool");
                });

            modelBuilder.Entity("SchoolSystem.Entiits.Department", b =>
                {
                    b.Navigation("Schools");
                });

            modelBuilder.Entity("SchoolSystem.Entiits.School", b =>
                {
                    b.Navigation("Teachers");

                    b.Navigation("TransfersFrom");

                    b.Navigation("TransfersTo");
                });

            modelBuilder.Entity("SchoolSystem.Entiits.Teacher", b =>
                {
                    b.Navigation("Transfares");
                });
#pragma warning restore 612, 618
        }
    }
}
