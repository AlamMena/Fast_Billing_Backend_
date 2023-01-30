using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class ContactsTableAddedv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientContact_sales_clients_ClientId",
                table: "ClientContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientContact",
                table: "ClientContact");

            migrationBuilder.RenameTable(
                name: "ClientContact",
                newName: "sales_clients_contacts");

            migrationBuilder.RenameIndex(
                name: "IX_ClientContact_ClientId",
                table: "sales_clients_contacts",
                newName: "IX_sales_clients_contacts_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sales_clients_contacts",
                table: "sales_clients_contacts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sales_clients_contacts_sales_clients_ClientId",
                table: "sales_clients_contacts",
                column: "ClientId",
                principalTable: "sales_clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sales_clients_contacts_sales_clients_ClientId",
                table: "sales_clients_contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sales_clients_contacts",
                table: "sales_clients_contacts");

            migrationBuilder.RenameTable(
                name: "sales_clients_contacts",
                newName: "ClientContact");

            migrationBuilder.RenameIndex(
                name: "IX_sales_clients_contacts_ClientId",
                table: "ClientContact",
                newName: "IX_ClientContact_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientContact",
                table: "ClientContact",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientContact_sales_clients_ClientId",
                table: "ClientContact",
                column: "ClientId",
                principalTable: "sales_clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
