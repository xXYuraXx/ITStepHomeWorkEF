using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _01_Intro_Migrations.Migrations
{
    /// <inheritdoc />
    public partial class TeamGoals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountGoals",
                table: "FootballTeams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountMissedGoals",
                table: "FootballTeams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountGoals",
                table: "FootballTeams");

            migrationBuilder.DropColumn(
                name: "CountMissedGoals",
                table: "FootballTeams");
        }
    }
}
