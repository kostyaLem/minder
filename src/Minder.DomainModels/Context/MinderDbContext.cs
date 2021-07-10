using Microsoft.EntityFrameworkCore;
using Minder.DomainModels.Models;

#nullable disable

namespace Minder.DomainModels.Context
{
    public class MinderDbContext : DbContext
    {
        public MinderDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<DeviceMetadata> DeviceMetadatas { get; set; }
        public virtual DbSet<DevicePart> DeviceParts { get; set; }
        public virtual DbSet<DeviceType> DeviceTypes { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeesPosition> EmployeesPositions { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<EquipmentDevicePart> EquipmentDeviceParts { get; set; }
        public virtual DbSet<EquipmentsSoftwary> EquipmentsSoftwaries { get; set; }
        public virtual DbSet<Metadata> Metadatas { get; set; }
        public virtual DbSet<Software> Softwares { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }

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

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.PositionId, "IX_Employees_PositionId");

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullName).IsRequired();

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_EmployeesPositions");
            });

            modelBuilder.Entity<EmployeesPosition>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.HasIndex(e => e.UsedByEmpolyeeId, "IX_Equipments_UsedByEmpolyeeId");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.UsedByEmpolyee)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.UsedByEmpolyeeId)
                    .HasConstraintName("FK_Equipments_Employees");
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

                entity.HasIndex(e => e.EquipmentId, "IX_EquipmentsSoftwaries_EquipmentId");

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
        }
    }
}
