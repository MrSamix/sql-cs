using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbInitilizer.Migrations
{
    /// <inheritdoc />
    public partial class ConfigReferences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Sells_AccountId",
                table: "Sells",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sells_BookId",
                table: "Sells",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_AccountReservationId",
                table: "Books",
                column: "AccountReservationId",
                unique: true,
                filter: "[AccountReservationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Books_SaleId",
                table: "Books",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_SubBookId",
                table: "Books",
                column: "SubBookId",
                unique: true,
                filter: "[SubBookId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Accounts_AccountReservationId",
                table: "Books",
                column: "AccountReservationId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Books_SubBookId",
                table: "Books",
                column: "SubBookId",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Sales_SaleId",
                table: "Books",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sells_Accounts_AccountId",
                table: "Sells",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sells_Books_BookId",
                table: "Sells",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Accounts_AccountReservationId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Books_SubBookId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Sales_SaleId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Sells_Accounts_AccountId",
                table: "Sells");

            migrationBuilder.DropForeignKey(
                name: "FK_Sells_Books_BookId",
                table: "Sells");

            migrationBuilder.DropIndex(
                name: "IX_Sells_AccountId",
                table: "Sells");

            migrationBuilder.DropIndex(
                name: "IX_Sells_BookId",
                table: "Sells");

            migrationBuilder.DropIndex(
                name: "IX_Books_AccountReservationId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_SaleId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_SubBookId",
                table: "Books");
        }
    }
}
