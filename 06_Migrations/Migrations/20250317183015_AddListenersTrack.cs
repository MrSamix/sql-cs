using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _06_Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddListenersTrack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Listeners",
                table: "Tracks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Listeners",
                table: "Tracks");
        }
    }
}
