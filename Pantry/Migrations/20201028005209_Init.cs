using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pantry.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoriesID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoriesID);
                });

            migrationBuilder.CreateTable(
                name: "PantryItems",
                columns: table => new
                {
                    PantryItemsID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CategoryCategoriesID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PantryItems", x => x.PantryItemsID);
                    table.ForeignKey(
                        name: "FK_PantryItems_Categories_CategoryCategoriesID",
                        column: x => x.CategoryCategoriesID,
                        principalTable: "Categories",
                        principalColumn: "CategoriesID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PantryItems_CategoryCategoriesID",
                table: "PantryItems",
                column: "CategoryCategoriesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PantryItems");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
