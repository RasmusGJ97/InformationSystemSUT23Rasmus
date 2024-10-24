﻿// <auto-generated />
using System;
using InformationSystemSUT23Rasmus.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InformationSystemSUT23Rasmus.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InformationSystemSUT23Rasmus.Models.Driver", b =>
                {
                    b.Property<int>("DriverID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DriverID"));

                    b.Property<decimal>("BeloppIn")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BeloppUt")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CarReg")
                        .IsRequired()
                        .HasColumnType("nvarChar(7)");

                    b.Property<string>("DriverName")
                        .IsRequired()
                        .HasColumnType("nvarChar(50)");

                    b.Property<DateTime>("NoteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoteDescription")
                        .HasColumnType("nvarChar(150)");

                    b.Property<string>("ResponsibleEmployee")
                        .IsRequired()
                        .HasColumnType("nvarChar(50)");

                    b.Property<decimal>("TotalBeloppIn")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalBeloppUt")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DriverID");

                    b.ToTable("Drivers");

                    b.HasData(
                        new
                        {
                            DriverID = 1,
                            BeloppIn = 1000.00m,
                            BeloppUt = 200.00m,
                            CarReg = "ABC123",
                            DriverName = "Peter",
                            NoteDate = new DateTime(2024, 10, 23, 14, 56, 22, 366, DateTimeKind.Local).AddTicks(2894),
                            NoteDescription = "Delivered supplies",
                            ResponsibleEmployee = "Sven",
                            TotalBeloppIn = 1000.00m,
                            TotalBeloppUt = 200.00m
                        },
                        new
                        {
                            DriverID = 2,
                            BeloppIn = 0.00m,
                            BeloppUt = 500.00m,
                            CarReg = "DEF456",
                            DriverName = "Anja",
                            NoteDate = new DateTime(2024, 10, 19, 14, 56, 22, 366, DateTimeKind.Local).AddTicks(2925),
                            NoteDescription = "Added Fuel",
                            ResponsibleEmployee = "Göran",
                            TotalBeloppIn = 0.00m,
                            TotalBeloppUt = 500.00m
                        },
                        new
                        {
                            DriverID = 3,
                            BeloppIn = 1000.00m,
                            BeloppUt = 100.00m,
                            CarReg = "GHI789",
                            DriverName = "Chris",
                            NoteDate = new DateTime(2024, 10, 21, 14, 56, 22, 366, DateTimeKind.Local).AddTicks(2950),
                            NoteDescription = "Delivered supplies",
                            ResponsibleEmployee = "Sven",
                            TotalBeloppIn = 1000.00m,
                            TotalBeloppUt = 100.00m
                        },
                        new
                        {
                            DriverID = 4,
                            BeloppIn = 2000.00m,
                            BeloppUt = 200.00m,
                            CarReg = "CBA321",
                            DriverName = "Lena",
                            NoteDate = new DateTime(2024, 10, 21, 14, 56, 22, 366, DateTimeKind.Local).AddTicks(2970),
                            NoteDescription = "Delivered supplies",
                            ResponsibleEmployee = "Göran",
                            TotalBeloppIn = 2000.00m,
                            TotalBeloppUt = 200.00m
                        },
                        new
                        {
                            DriverID = 5,
                            BeloppIn = 1000.00m,
                            BeloppUt = 500.00m,
                            CarReg = "FED654",
                            DriverName = "Fredrik",
                            NoteDate = new DateTime(2024, 10, 20, 14, 56, 22, 366, DateTimeKind.Local).AddTicks(2990),
                            NoteDescription = "Delivered supplies",
                            ResponsibleEmployee = "Sven",
                            TotalBeloppIn = 1000.00m,
                            TotalBeloppUt = 500.00m
                        });
                });

            modelBuilder.Entity("InformationSystemSUT23Rasmus.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeID = 1,
                            Email = "rasmus@email.com",
                            Name = "Rasmus",
                            Password = "Rasmus@1",
                            Role = "Admin"
                        },
                        new
                        {
                            EmployeeID = 2,
                            Email = "göran@email.com",
                            Name = "Göran",
                            Password = "Göran@2",
                            Role = "Employee"
                        },
                        new
                        {
                            EmployeeID = 3,
                            Email = "sven@email.com",
                            Name = "Sven",
                            Password = "Sven@3",
                            Role = "Employee"
                        });
                });

            modelBuilder.Entity("InformationSystemSUT23Rasmus.Models.Event", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventID"));

                    b.Property<decimal>("BeloppIn")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BeloppUt")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("DriverID")
                        .HasColumnType("int");

                    b.Property<DateTime>("NoteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoteDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventID");

                    b.HasIndex("DriverID");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventID = 1,
                            BeloppIn = 1000.00m,
                            BeloppUt = 0.00m,
                            DriverID = 1,
                            NoteDate = new DateTime(2024, 10, 20, 14, 56, 22, 366, DateTimeKind.Local).AddTicks(3021),
                            NoteDescription = "Delivered supplies"
                        },
                        new
                        {
                            EventID = 2,
                            BeloppIn = 0.00m,
                            BeloppUt = 1000.00m,
                            DriverID = 2,
                            NoteDate = new DateTime(2024, 10, 23, 14, 56, 22, 366, DateTimeKind.Local).AddTicks(3119),
                            NoteDescription = "Fueled Car"
                        },
                        new
                        {
                            EventID = 3,
                            BeloppIn = 500.00m,
                            BeloppUt = 0.00m,
                            DriverID = 3,
                            NoteDate = new DateTime(2024, 10, 19, 14, 56, 22, 366, DateTimeKind.Local).AddTicks(3139),
                            NoteDescription = "Delivered supplies"
                        },
                        new
                        {
                            EventID = 4,
                            BeloppIn = 0.00m,
                            BeloppUt = 2000.00m,
                            DriverID = 4,
                            NoteDate = new DateTime(2024, 10, 22, 14, 56, 22, 366, DateTimeKind.Local).AddTicks(3159),
                            NoteDescription = "Car Service"
                        },
                        new
                        {
                            EventID = 5,
                            BeloppIn = 1800.00m,
                            BeloppUt = 0.00m,
                            DriverID = 5,
                            NoteDate = new DateTime(2024, 10, 22, 14, 56, 22, 366, DateTimeKind.Local).AddTicks(3180),
                            NoteDescription = "Delivered supplies"
                        },
                        new
                        {
                            EventID = 6,
                            BeloppIn = 700.00m,
                            BeloppUt = 0.00m,
                            DriverID = 1,
                            NoteDate = new DateTime(2024, 10, 21, 14, 56, 22, 366, DateTimeKind.Local).AddTicks(3202),
                            NoteDescription = "Delivered supplies"
                        },
                        new
                        {
                            EventID = 7,
                            BeloppIn = 1200.00m,
                            BeloppUt = 0.00m,
                            DriverID = 2,
                            NoteDate = new DateTime(2024, 10, 20, 14, 56, 22, 366, DateTimeKind.Local).AddTicks(3221),
                            NoteDescription = "Delivered supplies"
                        });
                });

            modelBuilder.Entity("InformationSystemSUT23Rasmus.Models.Event", b =>
                {
                    b.HasOne("InformationSystemSUT23Rasmus.Models.Driver", "Driver")
                        .WithMany("Events")
                        .HasForeignKey("DriverID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("InformationSystemSUT23Rasmus.Models.Driver", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
