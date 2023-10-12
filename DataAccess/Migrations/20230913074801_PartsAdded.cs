using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PartsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ABSLight",
                table: "Vehicle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AirCondition",
                table: "Vehicle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AirbagsLight",
                table: "Vehicle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Batteries",
                table: "Vehicle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CarKey",
                table: "Vehicle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CdPlay",
                table: "Vehicle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CheckEngineLight",
                table: "Vehicle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FloorMats",
                table: "Vehicle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NumberPlates",
                table: "Vehicle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SpareTyre",
                table: "Vehicle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ToolKit",
                table: "Vehicle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WheelCaps",
                table: "Vehicle",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ABSLight",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "AirCondition",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "AirbagsLight",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Batteries",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "CarKey",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "CdPlay",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "CheckEngineLight",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "FloorMats",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "NumberPlates",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "SpareTyre",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "ToolKit",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "WheelCaps",
                table: "Vehicle");
        }
    }
}
