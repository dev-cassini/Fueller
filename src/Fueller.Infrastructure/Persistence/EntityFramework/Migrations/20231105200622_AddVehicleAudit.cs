using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fueller.Infrastructure.Persistence.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleAudit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehiclesAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Vehicle = table.Column<string>(type: "text", nullable: true),
                    VehicleId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesAudit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclesAudit_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehiclesAuditMetadata",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AuditRecordId = table.Column<Guid>(type: "uuid", nullable: false),
                    PropertyName = table.Column<string>(type: "text", nullable: false),
                    OriginalValue = table.Column<string>(type: "text", nullable: true),
                    UpdatedValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesAuditMetadata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclesAuditMetadata_VehiclesAudit_AuditRecordId",
                        column: x => x.AuditRecordId,
                        principalTable: "VehiclesAudit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesAudit_VehicleId",
                table: "VehiclesAudit",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesAuditMetadata_AuditRecordId",
                table: "VehiclesAuditMetadata",
                column: "AuditRecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehiclesAuditMetadata");

            migrationBuilder.DropTable(
                name: "VehiclesAudit");
        }
    }
}
