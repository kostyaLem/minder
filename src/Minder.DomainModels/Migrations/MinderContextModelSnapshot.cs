﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Minder.DomainModels.Context;

namespace Minder.DomainModels.Migrations
{
    [DbContext(typeof(MinderDbContext))]
    partial class MinderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Minder.DomainModels.Models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeviceTypeId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "DeviceTypeId" }, "IX_Devices_DeviceTypeId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("Minder.DomainModels.Models.DeviceMetadata", b =>
                {
                    b.Property<int>("MetadataId")
                        .HasColumnType("int");

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.HasKey("MetadataId", "DeviceId")
                        .HasName("PK_DeviceMetadata");

                    b.HasIndex(new[] { "MetadataId", "DeviceId" }, "IX_DeviceMetadata")
                        .IsUnique();

                    b.HasIndex(new[] { "DeviceId" }, "IX_DeviceMetadatas_DeviceId");

                    b.ToTable("DeviceMetadatas");
                });

            modelBuilder.Entity("Minder.DomainModels.Models.DevicePart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<int?>("ParentDevicePartId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "DeviceId" }, "IX_DeviceParts_DeviceId");

                    b.HasIndex(new[] { "ParentDevicePartId" }, "IX_DeviceParts_ParentDevicePartId");

                    b.ToTable("DeviceParts");
                });

            modelBuilder.Entity("Minder.DomainModels.Models.DeviceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DeviceTypes");
                });

            modelBuilder.Entity("Minder.DomainModels.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationInOffice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "PositionId" }, "IX_Employees_PositionId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Minder.DomainModels.Models.EmployeesPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmployeesPositions");
                });

            modelBuilder.Entity("Minder.DomainModels.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime");

                    b.Property<int?>("UsedByEmpolyeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UsedByEmpolyeeId" }, "IX_Equipments_UsedByEmpolyeeId");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("Minder.DomainModels.Models.EquipmentDevicePart", b =>
                {
                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.Property<int>("DevicePartId")
                        .HasColumnType("int");

                    b.HasKey("EquipmentId", "DevicePartId")
                        .HasName("PK_EquipmentDevicePart");

                    b.HasIndex(new[] { "EquipmentId", "DevicePartId" }, "IX_EquipmentDevicePart")
                        .IsUnique();

                    b.HasIndex(new[] { "DevicePartId" }, "IX_EquipmentDeviceParts_DevicePartId");

                    b.ToTable("EquipmentDeviceParts");
                });

            modelBuilder.Entity("Minder.DomainModels.Models.EquipmentsSoftwary", b =>
                {
                    b.Property<int>("SoftwareId")
                        .HasColumnType("int");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.HasKey("SoftwareId", "EquipmentId");

                    b.HasIndex(new[] { "EquipmentId" }, "IX_EquipmentsSoftwaries_EquipmentId");

                    b.ToTable("EquipmentsSoftwaries");
                });

            modelBuilder.Entity("Minder.DomainModels.Models.Metadata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Metadatas");
                });

            modelBuilder.Entity("Minder.DomainModels.Models.Software", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Price")
                        .HasColumnType("real");

                    b.Property<string>("ProductKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Software");
                });

            modelBuilder.Entity("Minder.DomainModels.Models.Device", b =>
                {
                    b.HasOne("Minder.DomainModels.Models.DeviceType", "DeviceType")
                        .WithMany("Devices")
                        .HasForeignKey("DeviceTypeId")
                        .HasConstraintName("FK_Device_DeviceType")
                        .IsRequired();

                    b.Navigation("DeviceType");
                });

            modelBuilder.Entity("Minder.DomainModels.Models.DeviceMetadata", b =>
                {
                    b.HasOne("Minder.DomainModels.Models.Device", "Device")
                        .WithMany("DeviceMetadata")
                        .HasForeignKey("DeviceId")
                        .HasConstraintName("FK_DeviceMetadata_Device")
                        .IsRequired();

                    b.HasOne("Minder.DomainModels.Models.Metadata", "Metadata")
                        .WithMany("DeviceMetadata")
                        .HasForeignKey("MetadataId")
                        .HasConstraintName("FK_DeviceMetadata_Metadata")
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("Metadata");
                });

            modelBuilder.Entity("Minder.DomainModels.Models.DevicePart", b =>
                {
                    b.HasOne("Minder.DomainModels.Models.Device", "Device")
                        .WithMany("DeviceParts")
                        .HasForeignKey("DeviceId")
                        .HasConstraintName("FK_DevicePart_Device")
                        .IsRequired();

                    b.HasOne("Minder.DomainModels.Models.DevicePart", "ParentDevicePart")
                        .WithMany("InverseParentDevicePart")
                        .HasForeignKey("ParentDevicePartId")
                        .HasConstraintName("FK_DevicePart_DevicePart1");

                    b.Navigation("Device");

                    b.Navigation("ParentDevicePart");
                });

            modelBuilder.Entity("Minder.DomainModels.Models.Employee", b =>
                {
                    b.HasOne("Minder.DomainModels.Models.EmployeesPosition", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionId")
                        .HasConstraintName("FK_Employees_EmployeesPositions")
                        .IsRequired();

                    b.Navigation("Position");
                });

            modelBuilder.Entity("Minder.DomainModels.Models.Equipment", b =>
                {
                    b.HasOne("Minder.DomainModels.Models.Employee", "UsedByEmpolyee")
                        .WithMany("Equipment")
                        .HasForeignKey("UsedByEmpolyeeId")
                        .HasConstraintName("FK_Equipments_Employees");

                    b.Navigation("UsedByEmpolyee");
                });

            modelBuilder.Entity("Minder.DomainModels.Models.EquipmentDevicePart", b =>
                {
                    b.HasOne("Minder.DomainModels.Models.DevicePart", "DevicePart")
                        .WithMany("EquipmentDeviceParts")
                        .HasForeignKey("DevicePartId")
                        .HasConstraintName("FK_EquipmentDevicePart_DevicePart")
                        .IsRequired();

                    b.HasOne("Minder.DomainModels.Models.Equipment", "Equipment")
                        .WithMany("EquipmentDeviceParts")
                        .HasForeignKey("EquipmentId")
                        .HasConstraintName("FK_EquipmentDevicePart_Equipment")
                        .IsRequired();

                    b.Navigation("DevicePart");

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("Minder.DomainModels.Models.EquipmentsSoftwary", b =>
                {
                    b.HasOne("Minder.DomainModels.Models.Equipment", "Equipment")
                        .WithMany("EquipmentsSoftwaries")
                        .HasForeignKey("EquipmentId")
                        .HasConstraintName("FK_EquipmentsSoftwaries_Equipments")
                        .IsRequired();

                    b.HasOne("Minder.DomainModels.Models.Software", "Software")
                        .WithMany("EquipmentsSoftwaries")
                        .HasForeignKey("SoftwareId")
                        .HasConstraintName("FK_EquipmentsSoftwaries_Software")
                        .IsRequired();

                    b.Navigation("Equipment");

                    b.Navigation("Software");
                });

            modelBuilder.Entity("Minder.DomainModels.Models.Device", b =>
                {
                    b.Navigation("DeviceMetadata");

                    b.Navigation("DeviceParts");
                });

            modelBuilder.Entity("Minder.DomainModels.Models.DevicePart", b =>
                {
                    b.Navigation("EquipmentDeviceParts");

                    b.Navigation("InverseParentDevicePart");
                });

            modelBuilder.Entity("Minder.DomainModels.Models.DeviceType", b =>
                {
                    b.Navigation("Devices");
                });

            modelBuilder.Entity("Minder.DomainModels.Models.Employee", b =>
                {
                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("Minder.DomainModels.Models.EmployeesPosition", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Minder.DomainModels.Models.Equipment", b =>
                {
                    b.Navigation("EquipmentDeviceParts");

                    b.Navigation("EquipmentsSoftwaries");
                });

            modelBuilder.Entity("Minder.DomainModels.Models.Metadata", b =>
                {
                    b.Navigation("DeviceMetadata");
                });

            modelBuilder.Entity("Minder.DomainModels.Models.Software", b =>
                {
                    b.Navigation("EquipmentsSoftwaries");
                });
#pragma warning restore 612, 618
        }
    }
}
