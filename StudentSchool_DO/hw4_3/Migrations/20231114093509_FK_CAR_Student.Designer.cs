﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Provider;

#nullable disable

namespace hw_2.Migrations
{
    [DbContext(typeof(OfficeDB))]
    [Migration("20231114093509_FK_CAR_Student")]
    partial class FK_CAR_Student
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DbCarDbSalesOffice", b =>
                {
                    b.Property<Guid>("CarsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SalesOfficesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CarsId", "SalesOfficesId");

                    b.HasIndex("SalesOfficesId");

                    b.ToTable("DbCarDbSalesOffice");
                });

            modelBuilder.Entity("DbModel.DbCar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrandCar")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("CoastCar")
                        .HasColumnType("int");

                    b.Property<Guid>("DbUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModelCar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DbUserId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("DbModel.DbSalesOffice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressSalesOffice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameSalesOffice")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SalesOffices");
                });

            modelBuilder.Entity("DbModel.DbUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DbCarDbSalesOffice", b =>
                {
                    b.HasOne("DbModel.DbCar", null)
                        .WithMany()
                        .HasForeignKey("CarsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbModel.DbSalesOffice", null)
                        .WithMany()
                        .HasForeignKey("SalesOfficesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DbModel.DbCar", b =>
                {
                    b.HasOne("DbModel.DbUser", "DbUser")
                        .WithMany("Cars")
                        .HasForeignKey("DbUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DbUser");
                });

            modelBuilder.Entity("DbModel.DbUser", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
