﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleOrderApp.Infrastructure.Persistence;

#nullable disable

namespace SimpleOrderApp.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221105214927_Initial-Migration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SimpleOrderApp.Domain.Entities.CurrencyRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("EffectiveDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ExchangeRate")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("FromCurrencyId")
                        .HasColumnType("int");

                    b.Property<int>("ToCurrencyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromCurrencyId");

                    b.HasIndex("ToCurrencyId");

                    b.ToTable("CurrencyRate");
                });

            modelBuilder.Entity("SimpleOrderApp.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal?>("ConvertedTotal")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderTypeId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal?>("Total")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("OrderTypeId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("SimpleOrderApp.Domain.Entities.Referentials.RefCurrency", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.ToTable("RefCurrency");
                });

            modelBuilder.Entity("SimpleOrderApp.Domain.Entities.Referentials.RefOrderType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("RefOrderType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Vehicles"
                        });
                });

            modelBuilder.Entity("SimpleOrderApp.Domain.Entities.Referentials.RefVehicleType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("RefVehicleType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Truck"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Minivan"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sedan"
                        });
                });

            modelBuilder.Entity("SimpleOrderApp.Domain.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<decimal>("PricePerDay")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Vehicle");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Make = "Audi",
                            Model = "A4",
                            PricePerDay = 30m,
                            TypeId = 3
                        },
                        new
                        {
                            Id = -2,
                            Make = "BMW",
                            Model = "3",
                            PricePerDay = 30m,
                            TypeId = 3
                        },
                        new
                        {
                            Id = -3,
                            Make = "Mercedes",
                            Model = "C",
                            PricePerDay = 30m,
                            TypeId = 3
                        },
                        new
                        {
                            Id = -4,
                            Make = "Toyota",
                            Model = "Corolla",
                            PricePerDay = 20m,
                            TypeId = 3
                        },
                        new
                        {
                            Id = -5,
                            Make = "Volkswagen",
                            Model = "Golf",
                            PricePerDay = 20m,
                            TypeId = 3
                        },
                        new
                        {
                            Id = -6,
                            Make = "Ford",
                            Model = "Transit",
                            PricePerDay = 35m,
                            TypeId = 2
                        },
                        new
                        {
                            Id = -7,
                            Make = "Volswagen",
                            Model = "Transporter",
                            PricePerDay = 35m,
                            TypeId = 2
                        },
                        new
                        {
                            Id = -8,
                            Make = "Toyota",
                            Model = "Hilux",
                            PricePerDay = 35m,
                            TypeId = 1
                        },
                        new
                        {
                            Id = -9,
                            Make = "Volswagen",
                            Model = "Amarok",
                            PricePerDay = 35m,
                            TypeId = 1
                        });
                });

            modelBuilder.Entity("SimpleOrderApp.Domain.Entities.VehicleOrder", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<decimal?>("ConvertedPricePerDay")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool?>("IsCarIntact")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsTankFull")
                        .HasColumnType("bit");

                    b.Property<decimal>("PricePerDay")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("VehicleOrder");
                });

            modelBuilder.Entity("SimpleOrderApp.Domain.Entities.CurrencyRate", b =>
                {
                    b.HasOne("SimpleOrderApp.Domain.Entities.Referentials.RefCurrency", "FromCurrency")
                        .WithMany("CurrencyRateFrom")
                        .HasForeignKey("FromCurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_CurrencyRate_RefCurrency_From");

                    b.HasOne("SimpleOrderApp.Domain.Entities.Referentials.RefCurrency", "ToCurrency")
                        .WithMany("CurrencyRateTo")
                        .HasForeignKey("ToCurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_CurrencyRate_RefCurrency_To");

                    b.Navigation("FromCurrency");

                    b.Navigation("ToCurrency");
                });

            modelBuilder.Entity("SimpleOrderApp.Domain.Entities.Order", b =>
                {
                    b.HasOne("SimpleOrderApp.Domain.Entities.Referentials.RefCurrency", "RefCurrency")
                        .WithMany("Order")
                        .HasForeignKey("CurrencyId")
                        .HasConstraintName("FK_Order_RefCurrency");

                    b.HasOne("SimpleOrderApp.Domain.Entities.Referentials.RefOrderType", "RefOrderType")
                        .WithMany("Order")
                        .HasForeignKey("OrderTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Order_RefOrderType");

                    b.Navigation("RefCurrency");

                    b.Navigation("RefOrderType");
                });

            modelBuilder.Entity("SimpleOrderApp.Domain.Entities.Vehicle", b =>
                {
                    b.HasOne("SimpleOrderApp.Domain.Entities.Referentials.RefVehicleType", "RefVehicleType")
                        .WithMany("Vehicle")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Vehicle_RefVehicle");

                    b.Navigation("RefVehicleType");
                });

            modelBuilder.Entity("SimpleOrderApp.Domain.Entities.VehicleOrder", b =>
                {
                    b.HasOne("SimpleOrderApp.Domain.Entities.Order", "Order")
                        .WithOne("VehicleOrder")
                        .HasForeignKey("SimpleOrderApp.Domain.Entities.VehicleOrder", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_VehicleOrder_Order");

                    b.HasOne("SimpleOrderApp.Domain.Entities.Vehicle", "Vehicle")
                        .WithMany("VehicleOrders")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_VehicleOrder_Vehicle");

                    b.Navigation("Order");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("SimpleOrderApp.Domain.Entities.Order", b =>
                {
                    b.Navigation("VehicleOrder")
                        .IsRequired();
                });

            modelBuilder.Entity("SimpleOrderApp.Domain.Entities.Referentials.RefCurrency", b =>
                {
                    b.Navigation("CurrencyRateFrom");

                    b.Navigation("CurrencyRateTo");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("SimpleOrderApp.Domain.Entities.Referentials.RefOrderType", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("SimpleOrderApp.Domain.Entities.Referentials.RefVehicleType", b =>
                {
                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("SimpleOrderApp.Domain.Entities.Vehicle", b =>
                {
                    b.Navigation("VehicleOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
