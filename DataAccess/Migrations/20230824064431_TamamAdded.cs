using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TamamAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TamamAddress",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "varchar(50)", nullable: true),
                    City = table.Column<string>(type: "varchar(50)", nullable: true),
                    Street = table.Column<string>(type: "varchar(50)", nullable: true),
                    AreaCode = table.Column<string>(type: "varchar(50)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TamamAddress", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "TamamUser",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", nullable: false),
                    EmailId = table.Column<string>(type: "varchar(50)", nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", nullable: true),
                    MobileNo = table.Column<string>(type: "varchar(50)", nullable: false),
                    VerificationPin = table.Column<string>(type: "varchar(10)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TamamUser", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "TamamVehicle",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    VehicleMake = table.Column<string>(type: "varchar(50)", nullable: true),
                    VehicleModel = table.Column<string>(type: "varchar(50)", nullable: true),
                    Year = table.Column<string>(type: "varchar(50)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChassisNumber = table.Column<string>(type: "varchar(50)", nullable: true),
                    PlateNumber = table.Column<string>(type: "varchar(50)", nullable: true),
                    Odometer = table.Column<string>(type: "varchar(50)", nullable: true),
                    IsInsured = table.Column<bool>(type: "bit", nullable: true),
                    IsCorporate = table.Column<bool>(type: "bit", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TamamVehicle", x => x.VehicleId);
                });

            migrationBuilder.CreateTable(
                name: "TamamClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "varchar(50)", nullable: true),
                    Description = table.Column<string>(type: "varchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TamamClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TamamClaim_TamamAddress_AddressId",
                        column: x => x.AddressId,
                        principalTable: "TamamAddress",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TamamClaim_TamamUser_UserId",
                        column: x => x.UserId,
                        principalTable: "TamamUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TamamClaim_TamamVehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "TamamVehicle",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TamamClaim_AddressId",
                table: "TamamClaim",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_TamamClaim_UserId",
                table: "TamamClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TamamClaim_VehicleId",
                table: "TamamClaim",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TamamClaim");

            migrationBuilder.DropTable(
                name: "TamamAddress");

            migrationBuilder.DropTable(
                name: "TamamUser");

            migrationBuilder.DropTable(
                name: "TamamVehicle");
        }
    }
}
