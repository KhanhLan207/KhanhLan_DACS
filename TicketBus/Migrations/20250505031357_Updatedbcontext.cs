﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketBus.Migrations
{
    /// <inheritdoc />
    public partial class Updatedbcontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceDetails");

            migrationBuilder.DropTable(
                name: "Services");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    IdService = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameService = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.IdService);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDetails",
                columns: table => new
                {
                    IdType = table.Column<int>(type: "int", nullable: false),
                    IdService = table.Column<int>(type: "int", nullable: false),
                    VehicleTypeIdType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDetails", x => new { x.IdType, x.IdService });
                    table.ForeignKey(
                        name: "FK_ServiceDetails_Services_IdService",
                        column: x => x.IdService,
                        principalTable: "Services",
                        principalColumn: "IdService");
                    table.ForeignKey(
                        name: "FK_ServiceDetails_VehicleTypes_IdType",
                        column: x => x.IdType,
                        principalTable: "VehicleTypes",
                        principalColumn: "IdType");
                    table.ForeignKey(
                        name: "FK_ServiceDetails_VehicleTypes_VehicleTypeIdType",
                        column: x => x.VehicleTypeIdType,
                        principalTable: "VehicleTypes",
                        principalColumn: "IdType");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDetails_IdService",
                table: "ServiceDetails",
                column: "IdService");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDetails_VehicleTypeIdType",
                table: "ServiceDetails",
                column: "VehicleTypeIdType");
        }
    }
}
