using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class SubcategoryID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "inventory_subcategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_inventory_subcategories_CategoryId",
                table: "inventory_subcategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_subcategories_inventory_categories_CategoryId",
                table: "inventory_subcategories",
                column: "CategoryId",
                principalTable: "inventory_categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventory_subcategories_inventory_categories_CategoryId",
                table: "inventory_subcategories");

            migrationBuilder.DropIndex(
                name: "IX_inventory_subcategories_CategoryId",
                table: "inventory_subcategories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "inventory_subcategories");
        }
    }
}
