using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class ProductTransactionInvoiceRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceDetailId",
                table: "inventory_prodcuts_transactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_inventory_prodcuts_transactions_InvoiceDetailId",
                table: "inventory_prodcuts_transactions",
                column: "InvoiceDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_prodcuts_transactions_sales_invoices_details_InvoiceDetailId",
                table: "inventory_prodcuts_transactions",
                column: "InvoiceDetailId",
                principalTable: "sales_invoices_details",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventory_prodcuts_transactions_sales_invoices_details_InvoiceDetailId",
                table: "inventory_prodcuts_transactions");

            migrationBuilder.DropIndex(
                name: "IX_inventory_prodcuts_transactions_InvoiceDetailId",
                table: "inventory_prodcuts_transactions");

            migrationBuilder.DropColumn(
                name: "InvoiceDetailId",
                table: "inventory_prodcuts_transactions");
        }
    }
}
