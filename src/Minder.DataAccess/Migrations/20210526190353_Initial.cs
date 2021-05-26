using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Minder.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Metadata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metadata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeviceTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Device_DeviceType",
                        column: x => x.DeviceTypeId,
                        principalTable: "DeviceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeviceMetadata",
                columns: table => new
                {
                    MetadataId = table.Column<int>(type: "int", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_DeviceMetadata_Device",
                        column: x => x.DeviceId,
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeviceMetadata_Metadata",
                        column: x => x.MetadataId,
                        principalTable: "Metadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DevicePart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    ParentDevicePartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevicePart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DevicePart_Device",
                        column: x => x.DeviceId,
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DevicePart_DevicePart1",
                        column: x => x.ParentDevicePartId,
                        principalTable: "DevicePart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentDevicePart",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(type: "int", nullable: false),
                    DevicePartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_EquipmentDevicePart_DevicePart",
                        column: x => x.DevicePartId,
                        principalTable: "DevicePart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentDevicePart_Equipment",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Device_DeviceTypeId",
                table: "Device",
                column: "DeviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceMetadata",
                table: "DeviceMetadata",
                columns: new[] { "MetadataId", "DeviceId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceMetadata_DeviceId",
                table: "DeviceMetadata",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DevicePart_DeviceId",
                table: "DevicePart",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DevicePart_ParentDevicePartId",
                table: "DevicePart",
                column: "ParentDevicePartId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentDevicePart",
                table: "EquipmentDevicePart",
                columns: new[] { "EquipmentId", "DevicePartId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentDevicePart_DevicePartId",
                table: "EquipmentDevicePart",
                column: "DevicePartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceMetadata");

            migrationBuilder.DropTable(
                name: "EquipmentDevicePart");

            migrationBuilder.DropTable(
                name: "Metadata");

            migrationBuilder.DropTable(
                name: "DevicePart");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropTable(
                name: "DeviceType");
        }
    }
}
