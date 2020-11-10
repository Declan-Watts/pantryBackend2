using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pantry.Migrations
{
    public partial class PantryItemsStockModelInit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PantryItems_Stock",
                columns: table => new
                {
                    StockID = table.Column<Guid>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    DateBought = table.Column<DateTime>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    PantryItemsID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PantryItems_Stock", x => x.StockID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PantryItems_Stock");
        }
    }
}
