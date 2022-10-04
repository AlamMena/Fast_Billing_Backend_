using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class Invoicetyperename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sales_invoices_sales_invoices_types_InvoiceTypeId",
                table: "sales_invoices");

            migrationBuilder.RenameColumn(
                name: "InvoiceTypeId",
                table: "sales_invoices",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_sales_invoices_InvoiceTypeId",
                table: "sales_invoices",
                newName: "IX_sales_invoices_TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_sales_invoices_sales_invoices_types_TypeId",
                table: "sales_invoices",
                column: "TypeId",
                principalTable: "sales_invoices_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sales_invoices_sales_invoices_types_TypeId",
                table: "sales_invoices");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "sales_invoices",
                newName: "InvoiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_sales_invoices_TypeId",
                table: "sales_invoices",
                newName: "IX_sales_invoices_InvoiceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_sales_invoices_sales_invoices_types_InvoiceTypeId",
                table: "sales_invoices",
                column: "InvoiceTypeId",
                principalTable: "sales_invoices_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
