using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _06_Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddRatingTrackAlbum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Tracks",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Albums",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Albums");
        }
    }
}
