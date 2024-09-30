﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("api.Models.BatteryReceiving", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Batteryserial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateReceived")
                        .HasColumnType("datetime2");

                    b.Property<string>("DebossedNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DrsiNo")
                        .HasColumnType("int");

                    b.Property<string>("ItemCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PoNo")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Receivedby")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Supplier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unitofmeasurement")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BatteryReceiving");
                });

            modelBuilder.Entity("api.Models.BatteryReleasing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BatteryId")
                        .HasColumnType("int");

                    b.Property<string>("BusinessUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imjno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Receivedby")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserplateNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BatteryId")
                        .IsUnique()
                        .HasFilter("[BatteryId] IS NOT NULL");

                    b.ToTable("BatteryReleasing");
                });

            modelBuilder.Entity("api.Models.BatteryReturn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BatteryReleasingId")
                        .HasColumnType("int");

                    b.Property<string>("Endorsedby")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReceivedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BatteryReleasingId");

                    b.ToTable("BatteryReturn");
                });

            modelBuilder.Entity("api.Models.BatteryTransfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BusinessUnitFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessUnitTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlateNoFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlateNoTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReleasingId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TransferDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ReleasingId");

                    b.ToTable("BatteryTransfer");
                });

            modelBuilder.Entity("api.Models.BusinessUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BusinessLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessunitDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessunitName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BusinessUnit");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BusinessLocation = "Binugao, Toril, Davao City",
                            BusinessunitDescription = "Ana's Breeders Farm Central Office",
                            BusinessunitName = "ABFI Central"
                        },
                        new
                        {
                            Id = 2,
                            BusinessLocation = "Binugao, Toril, Davao City",
                            BusinessunitDescription = "SouthMin FeedMill Unit",
                            BusinessunitName = "SFC"
                        },
                        new
                        {
                            Id = 3,
                            BusinessLocation = "Davao City",
                            BusinessunitDescription = "GSII Unit",
                            BusinessunitName = "GSII"
                        },
                        new
                        {
                            Id = 4,
                            BusinessLocation = "Binugao, Toril, Davao City",
                            BusinessunitDescription = "SubZero Unit",
                            BusinessunitName = "SubZero"
                        },
                        new
                        {
                            Id = 5,
                            BusinessLocation = "Dumoy, Toril, Davao City",
                            BusinessunitDescription = "JPPI Unit",
                            BusinessunitName = "JPPI"
                        },
                        new
                        {
                            Id = 6,
                            BusinessLocation = "Lanang, Davao City",
                            BusinessunitDescription = "QPMI Unit",
                            BusinessunitName = "QPMI"
                        },
                        new
                        {
                            Id = 7,
                            BusinessLocation = "FAIP Complex, Biao, Tugbok District, Davao City",
                            BusinessunitDescription = "FAIP Unit",
                            BusinessunitName = "FAIP"
                        });
                });

            modelBuilder.Entity("api.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Admin role for FAIP",
                            Name = "FAIPadmin"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Warehouse role for FAIP",
                            Name = "FAIPwarehouse"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Business Unit role",
                            Name = "BusinessUnit"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Super Admin Role",
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("api.Models.TireDisposal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DisposalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EndorsedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TireReturnId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TireReturnId")
                        .IsUnique()
                        .HasFilter("[TireReturnId] IS NOT NULL");

                    b.ToTable("TireDisposal");
                });

            modelBuilder.Entity("api.Models.TireRecap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EndorsedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RecappedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TireReturnId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TireReturnId")
                        .IsUnique()
                        .HasFilter("[TireReturnId] IS NOT NULL");

                    b.ToTable("TireRecap");
                });

            modelBuilder.Entity("api.Models.TireReceiving", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateReceived")
                        .HasColumnType("datetime2");

                    b.Property<string>("DebossedNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DrciNo")
                        .HasColumnType("int");

                    b.Property<string>("ItemCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PoNo")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Receivedby")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Supplier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TireSerial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TireType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tirebrand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tiresize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unitofmeasurement")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TireReceiving");
                });

            modelBuilder.Entity("api.Models.TireReleasing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Abfiserialno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Driver")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imjno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlateNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Receivedby")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TireId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TireId")
                        .IsUnique()
                        .HasFilter("[TireId] IS NOT NULL");

                    b.ToTable("TireReleasing");
                });

            modelBuilder.Entity("api.Models.TireReturn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EndorsedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Purpose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReceivedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TireReleasingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TireReleasingId")
                        .IsUnique()
                        .HasFilter("[TireReleasingId] IS NOT NULL");

                    b.ToTable("TireReturn");
                });

            modelBuilder.Entity("api.Models.TireTransfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BusinessUnitFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessUnitTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlateNoFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlateNoTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReleasingId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TransferDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ReleasingId");

                    b.ToTable("TireTransfer");
                });

            modelBuilder.Entity("api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BusinessUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BusinessUnit = "ABFI Central",
                            DateCreated = new DateTime(2024, 9, 30, 14, 31, 11, 700, DateTimeKind.Local).AddTicks(5666),
                            FirstName = "Admin",
                            LastName = "User",
                            MiddleName = "Admin",
                            PasswordHash = "$2a$11$UowM8huLMa3ljaEkG2io1eEh0/p4.JHhj/t.jNhmRujl9X0/3JZeW",
                            Role = "Admin",
                            Username = "000-001"
                        },
                        new
                        {
                            Id = 2,
                            BusinessUnit = "FAIP",
                            DateCreated = new DateTime(2024, 9, 30, 14, 31, 11, 846, DateTimeKind.Local).AddTicks(4952),
                            FirstName = "Warehouse",
                            LastName = "User",
                            MiddleName = "Test",
                            PasswordHash = "$2a$11$WGrHProE9pBtl1oZqIHX6.H3xBd3XEvbaow6nAX8fAYvmF6qlMCSW",
                            Role = "FAIPwarehouse",
                            Username = "000-002"
                        },
                        new
                        {
                            Id = 3,
                            BusinessUnit = "FAIP",
                            DateCreated = new DateTime(2024, 9, 30, 14, 31, 11, 995, DateTimeKind.Local).AddTicks(348),
                            FirstName = "FAIP",
                            LastName = "User",
                            MiddleName = "Admin",
                            PasswordHash = "$2a$11$SFr6P1pmrFB96ag3/uWlu.JpNignsEtUBhOnKqawb3yHketMY2uWy",
                            Role = "FAIPadmin",
                            Username = "000-003"
                        },
                        new
                        {
                            Id = 4,
                            BusinessUnit = "SubZero",
                            DateCreated = new DateTime(2024, 9, 30, 14, 31, 12, 140, DateTimeKind.Local).AddTicks(6327),
                            FirstName = "Business",
                            LastName = "User",
                            MiddleName = "Unit",
                            PasswordHash = "$2a$11$NRl8u8dJr/BoON7PxePDWeRmlKMMdvcpq9RT4WKSlyGyAr3.wFD5K",
                            Role = "BusinessUnit",
                            Username = "000-004"
                        });
                });

            modelBuilder.Entity("api.Models.BatteryReleasing", b =>
                {
                    b.HasOne("api.Models.BatteryReceiving", "BReceiving")
                        .WithOne("BatteryReleasing")
                        .HasForeignKey("api.Models.BatteryReleasing", "BatteryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("BReceiving");
                });

            modelBuilder.Entity("api.Models.BatteryReturn", b =>
                {
                    b.HasOne("api.Models.BatteryReleasing", "BatteryReleasing")
                        .WithMany("BatteryReturn")
                        .HasForeignKey("BatteryReleasingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("BatteryReleasing");
                });

            modelBuilder.Entity("api.Models.BatteryTransfer", b =>
                {
                    b.HasOne("api.Models.BatteryReleasing", "BatteryReleasing")
                        .WithMany("BatteryTransfer")
                        .HasForeignKey("ReleasingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("BatteryReleasing");
                });

            modelBuilder.Entity("api.Models.TireDisposal", b =>
                {
                    b.HasOne("api.Models.TireReturn", "TireReturn")
                        .WithOne("TireDisposal")
                        .HasForeignKey("api.Models.TireDisposal", "TireReturnId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("TireReturn");
                });

            modelBuilder.Entity("api.Models.TireRecap", b =>
                {
                    b.HasOne("api.Models.TireReturn", "TireReturn")
                        .WithOne("TireRecap")
                        .HasForeignKey("api.Models.TireRecap", "TireReturnId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("TireReturn");
                });

            modelBuilder.Entity("api.Models.TireReleasing", b =>
                {
                    b.HasOne("api.Models.TireReceiving", "TReceiving")
                        .WithOne("TireReleasing")
                        .HasForeignKey("api.Models.TireReleasing", "TireId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("TReceiving");
                });

            modelBuilder.Entity("api.Models.TireReturn", b =>
                {
                    b.HasOne("api.Models.TireReleasing", "TireReleasing")
                        .WithOne("TireReturn")
                        .HasForeignKey("api.Models.TireReturn", "TireReleasingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("TireReleasing");
                });

            modelBuilder.Entity("api.Models.TireTransfer", b =>
                {
                    b.HasOne("api.Models.TireReleasing", "TireReleasing")
                        .WithMany("TireTransfer")
                        .HasForeignKey("ReleasingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("TireReleasing");
                });

            modelBuilder.Entity("api.Models.BatteryReceiving", b =>
                {
                    b.Navigation("BatteryReleasing");
                });

            modelBuilder.Entity("api.Models.BatteryReleasing", b =>
                {
                    b.Navigation("BatteryReturn");

                    b.Navigation("BatteryTransfer");
                });

            modelBuilder.Entity("api.Models.TireReceiving", b =>
                {
                    b.Navigation("TireReleasing");
                });

            modelBuilder.Entity("api.Models.TireReleasing", b =>
                {
                    b.Navigation("TireReturn");

                    b.Navigation("TireTransfer");
                });

            modelBuilder.Entity("api.Models.TireReturn", b =>
                {
                    b.Navigation("TireDisposal");

                    b.Navigation("TireRecap");
                });
#pragma warning restore 612, 618
        }
    }
}
