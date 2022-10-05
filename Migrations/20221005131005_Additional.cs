using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class Additional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_accounts_recivable_InvoiceId",
                table: "accounts_recivable");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_recivable_InvoiceId",
                table: "accounts_recivable",
                column: "InvoiceId",
                unique: true,
                filter: "[InvoiceId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_accounts_recivable_InvoiceId",
                table: "accounts_recivable");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_recivable_InvoiceId",
                table: "accounts_recivable",
                column: "InvoiceId");
        }
    }
}
