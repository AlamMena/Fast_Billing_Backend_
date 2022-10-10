using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class ReceiptUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "inventory_goods_receipt",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_inventory_goods_receipt_WarehouseId",
                table: "inventory_goods_receipt",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_goods_receipt_inventory_warehouses_WarehouseId",
                table: "inventory_goods_receipt",
                column: "WarehouseId",
                principalTable: "inventory_warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventory_goods_receipt_inventory_warehouses_WarehouseId",
                table: "inventory_goods_receipt");

            migrationBuilder.DropIndex(
                name: "IX_inventory_goods_receipt_WarehouseId",
                table: "inventory_goods_receipt");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "inventory_goods_receipt");
        }
    }
}
