using Microsoft.EntityFrameworkCore;
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
        public virtual DbSet<DeviceMetadatum> DeviceMetadata { get; set; }
        public virtual DbSet<DevicePart> DeviceParts { get; set; }
        public virtual DbSet<DeviceType> DeviceTypes { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<EquipmentDevicePart> EquipmentDeviceParts { get; set; }
        public virtual DbSet<Metadatum> Metadata { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=minderdb;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("Device");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.DeviceType)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.DeviceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Device_DeviceType");
            });

            modelBuilder.Entity<DeviceMetadatum>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => new { e.MetadataId, e.DeviceId }, "IX_DeviceMetadata")
                    .IsUnique();

                entity.HasOne(d => d.Device)
                    .WithMany()
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeviceMetadata_Device");

                entity.HasOne(d => d.Metadata)
                    .WithMany()
                    .HasForeignKey(d => d.MetadataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeviceMetadata_Metadata");
            });

            modelBuilder.Entity<DevicePart>(entity =>
            {
                entity.ToTable("DevicePart");

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
                entity.ToTable("DeviceType");

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
                entity.HasNoKey();

                entity.ToTable("EquipmentDevicePart");

                entity.HasIndex(e => new { e.EquipmentId, e.DevicePartId }, "IX_EquipmentDevicePart")
                    .IsUnique();

                entity.HasOne(d => d.DevicePart)
                    .WithMany()
                    .HasForeignKey(d => d.DevicePartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentDevicePart_DevicePart");

                entity.HasOne(d => d.Equipment)
                    .WithMany()
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentDevicePart_Equipment");
            });

            modelBuilder.Entity<Metadatum>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Value).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
