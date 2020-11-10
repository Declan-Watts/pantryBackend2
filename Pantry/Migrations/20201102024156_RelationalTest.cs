using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pantry.Migrations
{
    public partial class RelationalTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "PantryItems_Stock");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "PantryItems");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoriesID",
                table: "PantryItems",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PantryItems_Stock_PantryItemsID",
                table: "PantryItems_Stock",
                column: "PantryItemsID");

            migrationBuilder.CreateIndex(
                name: "IX_PantryItems_CategoriesID",
                table: "PantryItems",
                column: "CategoriesID");

            migrationBuilder.AddForeignKey(
                name: "FK_PantryItems_Categories_CategoriesID",
                table: "PantryItems",
                column: "CategoriesID",
                principalTable: "Categories",
                principalColumn: "CategoriesID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PantryItems_Stock_PantryItems_PantryItemsID",
                table: "PantryItems_Stock",
                column: "PantryItemsID",
                principalTable: "PantryItems",
                principalColumn: "PantryItemsID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PantryItems_Categories_CategoriesID",
                table: "PantryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PantryItems_Stock_PantryItems_PantryItemsID",
                table: "PantryItems_Stock");

            migrationBuilder.DropIndex(
                name: "IX_PantryItems_Stock_PantryItemsID",
                table: "PantryItems_Stock");

            migrationBuilder.DropIndex(
                name: "IX_PantryItems_CategoriesID",
                table: "PantryItems");

            migrationBuilder.DropColumn(
                name: "CategoriesID",
                table: "PantryItems");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "PantryItems_Stock",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryID",
                table: "PantryItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
