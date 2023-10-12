using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class LogoAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkshopAddress",
                table: "Job");

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Workshop",
                type: "nvarchar(600)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Workshop");

            migrationBuilder.AddColumn<string>(
                name: "WorkshopAddress",
                table: "Job",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
