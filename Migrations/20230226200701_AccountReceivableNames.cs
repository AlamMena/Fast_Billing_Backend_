using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class AccountReceivableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_receivable_details_accounts_recivable_AccountId",
                table: "accounts_receivable_details");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_recivable_sales_clients_ClientId",
                table: "accounts_recivable");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_recivable_sales_invoices_InvoiceId",
                table: "accounts_recivable");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_recivable_system_branches_BranchId",
                table: "accounts_recivable");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_recivable_system_companies_CompanyId",
                table: "accounts_recivable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_accounts_recivable",
                table: "accounts_recivable");

            migrationBuilder.RenameTable(
                name: "accounts_recivable",
                newName: "accounts_receivable");

            migrationBuilder.RenameColumn(
                name: "InitialDate",
                table: "accounts_receivable",
                newName: "Date");

            migrationBuilder.RenameIndex(
                name: "IX_accounts_recivable_InvoiceId",
                table: "accounts_receivable",
                newName: "IX_accounts_receivable_InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_accounts_recivable_CompanyId",
                table: "accounts_receivable",
                newName: "IX_accounts_receivable_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_accounts_recivable_ClientId",
                table: "accounts_receivable",
                newName: "IX_accounts_receivable_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_accounts_recivable_BranchId",
                table: "accounts_receivable",
                newName: "IX_accounts_receivable_BranchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_accounts_receivable",
                table: "accounts_receivable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_receivable_sales_clients_ClientId",
                table: "accounts_receivable",
                column: "ClientId",
                principalTable: "sales_clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_receivable_sales_invoices_InvoiceId",
                table: "accounts_receivable",
                column: "InvoiceId",
                principalTable: "sales_invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_receivable_system_branches_BranchId",
                table: "accounts_receivable",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_receivable_system_companies_CompanyId",
                table: "accounts_receivable",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_receivable_details_accounts_receivable_AccountId",
                table: "accounts_receivable_details",
                column: "AccountId",
                principalTable: "accounts_receivable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_receivable_sales_clients_ClientId",
                table: "accounts_receivable");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_receivable_sales_invoices_InvoiceId",
                table: "accounts_receivable");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_receivable_system_branches_BranchId",
                table: "accounts_receivable");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_receivable_system_companies_CompanyId",
                table: "accounts_receivable");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_receivable_details_accounts_receivable_AccountId",
                table: "accounts_receivable_details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_accounts_receivable",
                table: "accounts_receivable");

            migrationBuilder.RenameTable(
                name: "accounts_receivable",
                newName: "accounts_recivable");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "accounts_recivable",
                newName: "InitialDate");

            migrationBuilder.RenameIndex(
                name: "IX_accounts_receivable_InvoiceId",
                table: "accounts_recivable",
                newName: "IX_accounts_recivable_InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_accounts_receivable_CompanyId",
                table: "accounts_recivable",
                newName: "IX_accounts_recivable_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_accounts_receivable_ClientId",
                table: "accounts_recivable",
                newName: "IX_accounts_recivable_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_accounts_receivable_BranchId",
                table: "accounts_recivable",
                newName: "IX_accounts_recivable_BranchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_accounts_recivable",
                table: "accounts_recivable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_receivable_details_accounts_recivable_AccountId",
                table: "accounts_receivable_details",
                column: "AccountId",
                principalTable: "accounts_recivable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_recivable_sales_clients_ClientId",
                table: "accounts_recivable",
                column: "ClientId",
                principalTable: "sales_clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_recivable_sales_invoices_InvoiceId",
                table: "accounts_recivable",
                column: "InvoiceId",
                principalTable: "sales_invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_recivable_system_branches_BranchId",
                table: "accounts_recivable",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_recivable_system_companies_CompanyId",
                table: "accounts_recivable",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
