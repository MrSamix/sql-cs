using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DbInitilizer.Migrations
{
    /// <inheritdoc />
    public partial class AddSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Login", "Password" },
                values: new object[,]
                {
                    { 1, "admin", "admin" },
                    { 2, "user", "user" },
                    { 3, "user2", "user2" }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "Discount", "EndDate", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, 50, new DateTime(2025, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Week sales", new DateTime(2025, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 30, new DateTime(2025, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Holidays sales!", new DateTime(2025, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 70, new DateTime(2025, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "School holidays!", new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AccountReservationId", "Author", "BookSize", "DistributorName", "Genre", "InsertDate", "Price", "SaleId", "SalePrice", "SubBookId", "Title", "Year" },
                values: new object[,]
                {
                    { 1, 1, "Author1", 100, "Distributor1", "Genre1", new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 1, 50, null, "Book1", 2021 },
                    { 2, null, "Author2", 200, "Distributor2", "Genre2", new DateTime(2025, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 200, 2, 100, 1, "Book2", 2022 },
                    { 3, 2, "Author3", 300, "Distributor3", "Genre3", new DateTime(2025, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 300, 3, 150, 2, "Book3", 2023 }
                });

            migrationBuilder.InsertData(
                table: "Sells",
                columns: new[] { "Id", "AccountId", "BookId", "SellDate" },
                values: new object[] { 1, 2, 2, new DateTime(2025, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sells",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
