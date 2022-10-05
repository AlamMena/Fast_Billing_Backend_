using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class InvoiceWarehouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventory_prodcuts_transactions_inventory_products_ProductId",
                table: "inventory_prodcuts_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_prodcuts_transactions_inventory_warehouses_WarehouseId",
                table: "inventory_prodcuts_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_prodcuts_transactions_sales_invoices_details_InvoiceDetailId",
                table: "inventory_prodcuts_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_prodcuts_transactions_system_branches_BranchId",
                table: "inventory_prodcuts_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_prodcuts_transactions_system_companies_CompanyId",
                table: "inventory_prodcuts_transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventory_prodcuts_transactions",
                table: "inventory_prodcuts_transactions");

            migrationBuilder.RenameTable(
                name: "inventory_prodcuts_transactions",
                newName: "inventory_products_transactions");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_prodcuts_transactions_WarehouseId",
                table: "inventory_products_transactions",
                newName: "IX_inventory_products_transactions_WarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_prodcuts_transactions_ProductId",
                table: "inventory_products_transactions",
                newName: "IX_inventory_products_transactions_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_prodcuts_transactions_InvoiceDetailId",
                table: "inventory_products_transactions",
                newName: "IX_inventory_products_transactions_InvoiceDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_prodcuts_transactions_CompanyId",
                table: "inventory_products_transactions",
                newName: "IX_inventory_products_transactions_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_prodcuts_transactions_BranchId",
                table: "inventory_products_transactions",
                newName: "IX_inventory_products_transactions_BranchId");

            migrationBuilder.AlterColumn<string>(
                name: "NcfName",
                table: "sales_invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceTypeName",
                table: "sales_invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WareHouseId",
                table: "sales_invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventory_products_transactions",
                table: "inventory_products_transactions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_sales_invoices_WareHouseId",
                table: "sales_invoices",
                column: "WareHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_transactions_inventory_products_ProductId",
                table: "inventory_products_transactions",
                column: "ProductId",
                principalTable: "inventory_products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_transactions_inventory_warehouses_WarehouseId",
                table: "inventory_products_transactions",
                column: "WarehouseId",
                principalTable: "inventory_warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_transactions_sales_invoices_details_InvoiceDetailId",
                table: "inventory_products_transactions",
                column: "InvoiceDetailId",
                principalTable: "sales_invoices_details",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_transactions_system_branches_BranchId",
                table: "inventory_products_transactions",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_transactions_system_companies_CompanyId",
                table: "inventory_products_transactions",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sales_invoices_inventory_warehouses_WareHouseId",
                table: "sales_invoices",
                column: "WareHouseId",
                principalTable: "inventory_warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_transactions_inventory_products_ProductId",
                table: "inventory_products_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_transactions_inventory_warehouses_WarehouseId",
                table: "inventory_products_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_transactions_sales_invoices_details_InvoiceDetailId",
                table: "inventory_products_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_transactions_system_branches_BranchId",
                table: "inventory_products_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_transactions_system_companies_CompanyId",
                table: "inventory_products_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_invoices_inventory_warehouses_WareHouseId",
                table: "sales_invoices");

            migrationBuilder.DropIndex(
                name: "IX_sales_invoices_WareHouseId",
                table: "sales_invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventory_products_transactions",
                table: "inventory_products_transactions");

            migrationBuilder.DropColumn(
                name: "WareHouseId",
                table: "sales_invoices");

            migrationBuilder.RenameTable(
                name: "inventory_products_transactions",
                newName: "inventory_prodcuts_transactions");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_products_transactions_WarehouseId",
                table: "inventory_prodcuts_transactions",
                newName: "IX_inventory_prodcuts_transactions_WarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_products_transactions_ProductId",
                table: "inventory_prodcuts_transactions",
                newName: "IX_inventory_prodcuts_transactions_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_products_transactions_InvoiceDetailId",
                table: "inventory_prodcuts_transactions",
                newName: "IX_inventory_prodcuts_transactions_InvoiceDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_products_transactions_CompanyId",
                table: "inventory_prodcuts_transactions",
                newName: "IX_inventory_prodcuts_transactions_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_products_transactions_BranchId",
                table: "inventory_prodcuts_transactions",
                newName: "IX_inventory_prodcuts_transactions_BranchId");

            migrationBuilder.AlterColumn<string>(
                name: "NcfName",
                table: "sales_invoices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceTypeName",
                table: "sales_invoices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventory_prodcuts_transactions",
                table: "inventory_prodcuts_transactions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_prodcuts_transactions_inventory_products_ProductId",
                table: "inventory_prodcuts_transactions",
                column: "ProductId",
                principalTable: "inventory_products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_prodcuts_transactions_inventory_warehouses_WarehouseId",
                table: "inventory_prodcuts_transactions",
                column: "WarehouseId",
                principalTable: "inventory_warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_prodcuts_transactions_sales_invoices_details_InvoiceDetailId",
                table: "inventory_prodcuts_transactions",
                column: "InvoiceDetailId",
                principalTable: "sales_invoices_details",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_prodcuts_transactions_system_branches_BranchId",
                table: "inventory_prodcuts_transactions",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_prodcuts_transactions_system_companies_CompanyId",
                table: "inventory_prodcuts_transactions",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id");
        }
    }
}
