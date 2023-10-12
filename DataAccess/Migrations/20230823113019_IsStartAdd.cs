using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class IsStartAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CR",
                table: "Workshop",
                type: "varchar(300)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "LaborRate",
                table: "Workshop",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Vat",
                table: "Workshop",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsJobStarted",
                table: "ActivityLog",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CR",
                table: "Workshop");

            migrationBuilder.DropColumn(
                name: "LaborRate",
                table: "Workshop");

            migrationBuilder.DropColumn(
                name: "Vat",
                table: "Workshop");

            migrationBuilder.DropColumn(
                name: "IsJobStarted",
                table: "ActivityLog");
        }
    }
}
