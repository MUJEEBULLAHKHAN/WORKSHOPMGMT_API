using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class colornameadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Color_ColorId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_ColorId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Vehicle");

            migrationBuilder.AddColumn<string>(
                name: "ColorName",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VehicleParts",
                table: "Job",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkshopAddress",
                table: "Job",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customer",
                type: "nvarchar(500)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorName",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "WorkshopAddress",
                table: "Job");

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "VehicleParts",
                table: "Job",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customer",
                type: "nvarchar(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ColorId",
                table: "Vehicle",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Color_ColorId",
                table: "Vehicle",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "ColorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
