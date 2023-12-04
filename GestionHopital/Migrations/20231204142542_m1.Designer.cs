﻿// <auto-generated />
using System;
using GestionHopital.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionHopital.Migrations
{
    [DbContext(typeof(HopitalDbContext))]
    [Migration("20231204142542_m1")]
    partial class m1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GestionHopital.Models.Appointment", b =>
                {
                    b.Property<int>("AppointID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointID"), 1L, 1);

                    b.Property<int>("Appointment_Status")
                        .HasColumnType("int");

                    b.Property<float?>("Bill_Amount")
                        .HasColumnType("real");

                    b.Property<int?>("Bill_Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Disease")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.Property<string>("Prescription")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Progress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AppointID");

                    b.HasIndex("DoctorID");

                    b.HasIndex("PatientID");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("GestionHopital.Models.Department", b =>
                {
                    b.Property<int>("DeptNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeptNo"), 1L, 1);

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeptNo");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("GestionHopital.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Charges_Per_Visit")
                        .HasColumnType("real");

                    b.Property<int>("DeptNo")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<float?>("MonthlySalary")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Patients_Treated")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Qualification")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float?>("ReputeIndex")
                        .HasColumnType("real");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("Work_Experience")
                        .HasColumnType("int");

                    b.HasKey("DoctorID");

                    b.HasIndex("DeptNo");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("GestionHopital.Models.OtherStaff", b =>
                {
                    b.Property<int>("StaffID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Highest_Qualification")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<float?>("Salary")
                        .HasColumnType("real");

                    b.HasKey("StaffID");

                    b.ToTable("OtherStaffs");
                });

            modelBuilder.Entity("GestionHopital.Models.Patient", b =>
                {
                    b.Property<int>("PatientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<int?>("LoginID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("PatientID");

                    b.HasIndex("LoginID");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Login", b =>
                {
                    b.Property<int>("LoginID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoginID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("LoginID");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("GestionHopital.Models.Appointment", b =>
                {
                    b.HasOne("GestionHopital.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionHopital.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("GestionHopital.Models.Doctor", b =>
                {
                    b.HasOne("GestionHopital.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DeptNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("GestionHopital.Models.Patient", b =>
                {
                    b.HasOne("Login", "Login")
                        .WithMany()
                        .HasForeignKey("LoginID");

                    b.Navigation("Login");
                });
#pragma warning restore 612, 618
        }
    }
}
