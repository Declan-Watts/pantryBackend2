using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pantry.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PantryItems",
                columns: table => new
                {
                    PantryItemsID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PantryItems", x => x.PantryItemsID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PantryItems");
        }
    }
}
