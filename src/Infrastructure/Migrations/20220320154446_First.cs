using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoneyCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonthlyBudget = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "MoneyEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Details = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoneyCategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoneyEntries_MoneyCategories_MoneyCategoryId",
                        column: x => x.MoneyCategoryId,
                        principalTable: "MoneyCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoneyEntries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MoneyCategories",
                columns: new[] { "Id", "Icon", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "shopping_cart", "Shopping", 0 },
                    { 2, "restaurant", "Food", 0 },
                    { 3, "health_and_safety", "Health", 0 },
                    { 4, "school", "Education", 0 },
                    { 5, "receipt_long", "Bills & Utilities", 0 },
                    { 6, "commute", "Transportation", 0 },
                    { 7, "sports_esports", "Entertainment", 0 },
                    { 8, "volunteer_activism", "Donations", 0 },
                    { 9, "family_restroom", "Family", 0 },
                    { 10, "public", "Other", 0 },
                    { 11, "payments", "Salary", 1 },
                    { 12, "sell", "Sale", 1 },
                    { 13, "currency_exchange", "Trading", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoneyEntries_MoneyCategoryId",
                table: "MoneyEntries",
                column: "MoneyCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyEntries_UserId",
                table: "MoneyEntries",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoneyEntries");

            migrationBuilder.DropTable(
                name: "MoneyCategories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
