using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pantry.Migrations
{
    public partial class CategoriesForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PantryItems_Categories_CategoryCategoriesID",
                table: "PantryItems");

            migrationBuilder.DropIndex(
                name: "IX_PantryItems_CategoryCategoriesID",
                table: "PantryItems");

            migrationBuilder.DropColumn(
                name: "CategoryCategoriesID",
                table: "PantryItems");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryID",
                table: "PantryItems",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "PantryItems");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryCategoriesID",
                table: "PantryItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PantryItems_CategoryCategoriesID",
                table: "PantryItems",
                column: "CategoryCategoriesID");

            migrationBuilder.AddForeignKey(
                name: "FK_PantryItems_Categories_CategoryCategoriesID",
                table: "PantryItems",
                column: "CategoryCategoriesID",
                principalTable: "Categories",
                principalColumn: "CategoriesID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
