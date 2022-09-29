using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class DiscountRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisscountAmount",
                table: "sales_invoices_details",
                newName: "DiscountAmount");

            migrationBuilder.RenameColumn(
                name: "Disccount",
                table: "sales_invoices_details",
                newName: "Discount");

            migrationBuilder.RenameColumn(
                name: "Disccount",
                table: "sales_invoices",
                newName: "Discount");

            migrationBuilder.RenameColumn(
                name: "Disccount",
                table: "sales_clients",
                newName: "Discount");

            migrationBuilder.RenameColumn(
                name: "AllowDisccount",
                table: "sales_clients",
                newName: "AllowDiscount");

            migrationBuilder.RenameColumn(
                name: "DisccountAmount",
                table: "accounts_payable_transactions",
                newName: "DiscountAmount");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "sales_clients_addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "accounts_recivable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_accounts_recivable_InvoiceId",
                table: "accounts_recivable",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_recivable_sales_invoices_InvoiceId",
                table: "accounts_recivable",
                column: "InvoiceId",
                principalTable: "sales_invoices",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_recivable_sales_invoices_InvoiceId",
                table: "accounts_recivable");

            migrationBuilder.DropIndex(
                name: "IX_accounts_recivable_InvoiceId",
                table: "accounts_recivable");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "sales_clients_addresses");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "accounts_recivable");

            migrationBuilder.RenameColumn(
                name: "DiscountAmount",
                table: "sales_invoices_details",
                newName: "DisscountAmount");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "sales_invoices_details",
                newName: "Disccount");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "sales_invoices",
                newName: "Disccount");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "sales_clients",
                newName: "Disccount");

            migrationBuilder.RenameColumn(
                name: "AllowDiscount",
                table: "sales_clients",
                newName: "AllowDisccount");

            migrationBuilder.RenameColumn(
                name: "DiscountAmount",
                table: "accounts_payable_transactions",
                newName: "DisccountAmount");
        }
    }
}
