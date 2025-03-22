using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _06_Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddTextTrack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Tracks");
        }
    }
}
