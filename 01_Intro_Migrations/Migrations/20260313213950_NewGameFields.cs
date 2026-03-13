using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _01_Intro_Migrations.Migrations
{
    /// <inheritdoc />
    public partial class NewGameFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConnectionType",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CountSales",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectionType",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CountSales",
                table: "Games");
        }
    }
}
