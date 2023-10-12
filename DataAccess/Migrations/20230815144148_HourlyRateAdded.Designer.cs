﻿// <auto-generated />
using System;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230815144148_HourlyRateAdded")]
    partial class HourlyRateAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.DBEntities.ActivityLog", b =>
                {
                    b.Property<int>("ActivityLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActivityLogId"));

                    b.Property<int?>("JobId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("LoggedOn")
                        .HasColumnType("datetime");

                    b.Property<int?>("StageId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ActivityLogId");

                    b.HasIndex("JobId");

                    b.HasIndex("StageId");

                    b.HasIndex("UserId");

                    b.ToTable("ActivityLog");
                });

            modelBuilder.Entity("DataAccess.DBEntities.Color", b =>
                {
                    b.Property<int>("ColorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ColorId"));

                    b.Property<string>("ColorName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("ColorId");

                    b.ToTable("Color");
                });

            modelBuilder.Entity("DataAccess.DBEntities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("CustomerTypeId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime");

                    b.HasKey("CustomerId");

                    b.HasIndex("CustomerTypeId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("DataAccess.DBEntities.CustomerType", b =>
                {
                    b.Property<int>("CustomerTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerTypeId"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("CustomerTypeName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime");

                    b.HasKey("CustomerTypeId");

                    b.ToTable("CustomerType");
                });

            modelBuilder.Entity("DataAccess.DBEntities.ErrorLog", b =>
                {
                    b.Property<int>("ErrorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ErrorId"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("ErrorMessage")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.HasKey("ErrorId");

                    b.ToTable("ErrorLog");
                });

            modelBuilder.Entity("DataAccess.DBEntities.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobId"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<int?>("CustomerId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("JobName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("JobStatusId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("StageId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("StartedOn")
                        .HasColumnType("datetime");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.Property<int?>("WorkshopId")
                        .HasColumnType("int");

                    b.HasKey("JobId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("JobStatusId");

                    b.HasIndex("StageId");

                    b.HasIndex("UserId");

                    b.HasIndex("VehicleId");

                    b.HasIndex("WorkshopId");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("DataAccess.DBEntities.JobStatus", b =>
                {
                    b.Property<int>("JobStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobStatusId"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("JobStatusName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("JobStatusId");

                    b.ToTable("JobStatus");
                });

            modelBuilder.Entity("DataAccess.DBEntities.Owner", b =>
                {
                    b.Property<int>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OwnerId"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime");

                    b.HasKey("OwnerId");

                    b.ToTable("Owner");
                });

            modelBuilder.Entity("DataAccess.DBEntities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("WorkshopId")
                        .HasColumnType("int");

                    b.HasKey("RoleId");

                    b.HasIndex("WorkshopId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("DataAccess.DBEntities.Stage", b =>
                {
                    b.Property<int>("StageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StageId"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("StageNo")
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime");

                    b.Property<int>("WorkshopId")
                        .HasColumnType("int");

                    b.HasKey("StageId");

                    b.HasIndex("WorkshopId");

                    b.ToTable("Stage");
                });

            modelBuilder.Entity("DataAccess.DBEntities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<double>("HourlyRate")
                        .HasColumnType("float");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("RoleId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime");

                    b.Property<int?>("WorkshopId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.HasIndex("WorkshopId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DataAccess.DBEntities.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleId"));

                    b.Property<string>("ChassisNumber")
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("ColorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsCorporate")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsInsured")
                        .HasColumnType("bit");

                    b.Property<string>("Odometer")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PlateNumber")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime");

                    b.Property<int?>("VehicleMakeId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("VehicleModelId")
                        .HasColumnType("int");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("VehicleId");

                    b.HasIndex("ColorId");

                    b.HasIndex("VehicleMakeId");

                    b.HasIndex("VehicleModelId");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("DataAccess.DBEntities.VehicleMake", b =>
                {
                    b.Property<int>("VehicleMakeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleMakeId"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("VehicleMakeName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("VehicleMakeId");

                    b.ToTable("VehicleMake");
                });

            modelBuilder.Entity("DataAccess.DBEntities.VehicleModel", b =>
                {
                    b.Property<int>("VehicleModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleModelId"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("VehicleMakeId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("VehicleModelName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("VehicleModelId");

                    b.HasIndex("VehicleMakeId");

                    b.ToTable("VehicleModel");
                });

            modelBuilder.Entity("DataAccess.DBEntities.VehiclePics", b =>
                {
                    b.Property<int>("VehiclePicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehiclePicId"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.Property<string>("VehiclePic")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.HasKey("VehiclePicId");

                    b.HasIndex("VehicleId");

                    b.ToTable("VehiclePics");
                });

            modelBuilder.Entity("DataAccess.DBEntities.Workshop", b =>
                {
                    b.Property<int>("WorkshopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkshopId"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("WorkshopAddress")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("WorkshopName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("WorkshopId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Workshop");
                });

            modelBuilder.Entity("DataAccess.DBEntities.ActivityLog", b =>
                {
                    b.HasOne("DataAccess.DBEntities.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.DBEntities.Stage", "Stage")
                        .WithMany()
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DataAccess.DBEntities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Job");

                    b.Navigation("Stage");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccess.DBEntities.Customer", b =>
                {
                    b.HasOne("DataAccess.DBEntities.CustomerType", "CustomerType")
                        .WithMany()
                        .HasForeignKey("CustomerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerType");
                });

            modelBuilder.Entity("DataAccess.DBEntities.Job", b =>
                {
                    b.HasOne("DataAccess.DBEntities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.DBEntities.JobStatus", "JobStatus")
                        .WithMany()
                        .HasForeignKey("JobStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.DBEntities.Stage", "Stage")
                        .WithMany()
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.DBEntities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DataAccess.DBEntities.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DataAccess.DBEntities.Workshop", "Workshop")
                        .WithMany()
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Customer");

                    b.Navigation("JobStatus");

                    b.Navigation("Stage");

                    b.Navigation("User");

                    b.Navigation("Vehicle");

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("DataAccess.DBEntities.Role", b =>
                {
                    b.HasOne("DataAccess.DBEntities.Workshop", "Workshop")
                        .WithMany()
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("DataAccess.DBEntities.Stage", b =>
                {
                    b.HasOne("DataAccess.DBEntities.Workshop", "Workshop")
                        .WithMany()
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("DataAccess.DBEntities.User", b =>
                {
                    b.HasOne("DataAccess.DBEntities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.DBEntities.Workshop", "Workshop")
                        .WithMany()
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Role");

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("DataAccess.DBEntities.Vehicle", b =>
                {
                    b.HasOne("DataAccess.DBEntities.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.DBEntities.VehicleMake", "VehicleMake")
                        .WithMany()
                        .HasForeignKey("VehicleMakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.DBEntities.VehicleModel", "VehicleModel")
                        .WithMany()
                        .HasForeignKey("VehicleModelId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Color");

                    b.Navigation("VehicleMake");

                    b.Navigation("VehicleModel");
                });

            modelBuilder.Entity("DataAccess.DBEntities.VehicleModel", b =>
                {
                    b.HasOne("DataAccess.DBEntities.VehicleMake", "VehicleMake")
                        .WithMany()
                        .HasForeignKey("VehicleMakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehicleMake");
                });

            modelBuilder.Entity("DataAccess.DBEntities.VehiclePics", b =>
                {
                    b.HasOne("DataAccess.DBEntities.Vehicle", "Vehicle")
                        .WithMany("VehiclePics")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("DataAccess.DBEntities.Workshop", b =>
                {
                    b.HasOne("DataAccess.DBEntities.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("DataAccess.DBEntities.Vehicle", b =>
                {
                    b.Navigation("VehiclePics");
                });
#pragma warning restore 612, 618
        }
    }
}
