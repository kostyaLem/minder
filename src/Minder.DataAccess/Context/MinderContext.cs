using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Minder.DataAccess.Models;

#nullable disable

namespace Minder.DataAccess.Context
{
    public partial class MinderContext : DbContext
    {
        public MinderContext()
        {
        }

        public MinderContext(DbContextOptions<MinderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<DeviceMetadata> DeviceMetadatas { get; set; }
        public virtual DbSet<DevicePart> DeviceParts { get; set; }
        public virtual DbSet<DeviceType> DeviceTypes { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<EquipmentDevicePart> EquipmentDeviceParts { get; set; }
        public virtual DbSet<EquipmentsSoftwary> EquipmentsSoftwaries { get; set; }
        public virtual DbSet<Metadata> Metadatas { get; set; }
        public virtual DbSet<Software> Softwares { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=minderdb;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Device>(entity =>
            {
                entity.HasIndex(e => e.DeviceTypeId, "IX_Devices_DeviceTypeId");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.DeviceType)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.DeviceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Device_DeviceType");
            });

            modelBuilder.Entity<DeviceMetadata>(entity =>
            {
                entity.HasKey(e => new { e.MetadataId, e.DeviceId })
                    .HasName("PK_DeviceMetadata");

                entity.HasIndex(e => new { e.MetadataId, e.DeviceId }, "IX_DeviceMetadata")
                    .IsUnique();

                entity.HasIndex(e => e.DeviceId, "IX_DeviceMetadatas_DeviceId");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.DeviceMetadata)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeviceMetadata_Device");

                entity.HasOne(d => d.Metadata)
                    .WithMany(p => p.DeviceMetadata)
                    .HasForeignKey(d => d.MetadataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeviceMetadata_Metadata");
            });

            modelBuilder.Entity<DevicePart>(entity =>
            {
                entity.HasIndex(e => e.DeviceId, "IX_DeviceParts_DeviceId");

                entity.HasIndex(e => e.ParentDevicePartId, "IX_DeviceParts_ParentDevicePartId");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.DeviceParts)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DevicePart_Device");

                entity.HasOne(d => d.ParentDevicePart)
                    .WithMany(p => p.InverseParentDevicePart)
                    .HasForeignKey(d => d.ParentDevicePartId)
                    .HasConstraintName("FK_DevicePart_DevicePart1");
            });

            modelBuilder.Entity<DeviceType>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<EquipmentDevicePart>(entity =>
            {
                entity.HasKey(e => new { e.EquipmentId, e.DevicePartId })
                    .HasName("PK_EquipmentDevicePart");

                entity.HasIndex(e => new { e.EquipmentId, e.DevicePartId }, "IX_EquipmentDevicePart")
                    .IsUnique();

                entity.HasIndex(e => e.DevicePartId, "IX_EquipmentDeviceParts_DevicePartId");

                entity.HasOne(d => d.DevicePart)
                    .WithMany(p => p.EquipmentDeviceParts)
                    .HasForeignKey(d => d.DevicePartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentDevicePart_DevicePart");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.EquipmentDeviceParts)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentDevicePart_Equipment");
            });

            modelBuilder.Entity<EquipmentsSoftwary>(entity =>
            {
                entity.HasKey(e => new { e.SoftwareId, e.EquipmentId });

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.EquipmentsSoftwaries)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentsSoftwaries_Equipments");

                entity.HasOne(d => d.Software)
                    .WithMany(p => p.EquipmentsSoftwaries)
                    .HasForeignKey(d => d.SoftwareId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentsSoftwaries_Software");
            });

            modelBuilder.Entity<Metadata>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Value).IsRequired();
            });

            modelBuilder.Entity<Software>(entity =>
            {
                entity.ToTable("Software");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
