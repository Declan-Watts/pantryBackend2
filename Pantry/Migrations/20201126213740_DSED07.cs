using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Pantry.Migrations
{
    public partial class DSED07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "AspNetUsers");
            Guid beefGuid = Guid.NewGuid();
            Guid dairyGuid = Guid.NewGuid();
            Guid fruitGuid = Guid.NewGuid();

            Guid milkGuid = Guid.NewGuid();
            Guid yoghurtGuid = Guid.NewGuid();
            Guid steakGuid = Guid.NewGuid();
            Guid appleGuid = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoriesID", "Name", "Status" },
                values: new object[] { beefGuid, "Beef", "Approved" }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoriesID", "Name", "Status" },
                values: new object[] { dairyGuid, "Dairy", "Approved" }
            );
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoriesID", "Name", "Status" },
                values: new object[] { fruitGuid, "Fruit", "Approved" }
            );


            migrationBuilder.InsertData(
                table: "PantryItems",
                columns: new[] { "PantryItemsID", "Name", "CategoriesID" },
                values: new object[] { milkGuid, "Milk", dairyGuid }
            );
            migrationBuilder.InsertData(
                table: "PantryItems",
                columns: new[] { "PantryItemsID", "Name", "CategoriesID" },
                values: new object[] { yoghurtGuid, "Yoghurt", dairyGuid }
            );
            migrationBuilder.InsertData(
                table: "PantryItems",
                columns: new[] { "PantryItemsID", "Name", "CategoriesID" },
                values: new object[] { steakGuid, "Steak", beefGuid }
            );
            migrationBuilder.InsertData(
                table: "PantryItems",
                columns: new[] { "PantryItemsID", "Name", "CategoriesID" },
                values: new object[] { appleGuid, "Apple", fruitGuid }
            );


            migrationBuilder.InsertData(
                table: "PantryItems_Stock",
                columns: new[] { "StockID", "Qty", "ExpirationDate", "DateBought", "PantryItemsID" },
                values: new object[] { Guid.NewGuid(), 1, "2020-12-12", "2020-11-12", steakGuid }
            );
            migrationBuilder.InsertData(
                table: "PantryItems_Stock",
                columns: new[] { "StockID", "Qty", "ExpirationDate", "DateBought", "PantryItemsID" },
                values: new object[] { Guid.NewGuid(), 2, "2020-12-12", "2020-11-12", milkGuid }
            );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
