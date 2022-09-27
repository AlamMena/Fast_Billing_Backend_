using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class Warehouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyUnity",
                table: "inventory_products_prices");

            migrationBuilder.DropColumn(
                name: "DetailQuantity",
                table: "inventory_products_prices");

            migrationBuilder.DropColumn(
                name: "SellUnity",
                table: "inventory_products_prices");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "inventory_products");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "system_currency",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "inventory_products_stock",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "inventory_warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocNum = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory_warehouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventory_warehouses_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_inventory_warehouses_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_inventory_products_stock_WarehouseId",
                table: "inventory_products_stock",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_warehouses_BranchId",
                table: "inventory_warehouses",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_warehouses_CompanyId",
                table: "inventory_warehouses",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_stock_inventory_warehouses_WarehouseId",
                table: "inventory_products_stock",
                column: "WarehouseId",
                principalTable: "inventory_warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_stock_inventory_warehouses_WarehouseId",
                table: "inventory_products_stock");

            migrationBuilder.DropTable(
                name: "inventory_warehouses");

            migrationBuilder.DropIndex(
                name: "IX_inventory_products_stock_WarehouseId",
                table: "inventory_products_stock");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "inventory_products_stock");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "system_currency",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyUnity",
                table: "inventory_products_prices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DetailQuantity",
                table: "inventory_products_prices",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellUnity",
                table: "inventory_products_prices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "inventory_products",
                type: "int",
                nullable: true);
        }
    }
}
