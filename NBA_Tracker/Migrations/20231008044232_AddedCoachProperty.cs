using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NBA_Tracker.Migrations
{
    /// <inheritdoc />
    public partial class AddedCoachProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Coach",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coach",
                table: "Teams");
        }
    }
}
