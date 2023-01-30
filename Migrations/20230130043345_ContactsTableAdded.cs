using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class ContactsTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_globals_addresses_inventory_suppliers_SupplierId",
                table: "globals_addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_addresses_sales_clients_ClientId",
                table: "globals_addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_contacts_inventory_suppliers_SupplierId",
                table: "globals_contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_contacts_sales_clients_ClientId",
                table: "globals_contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_globals_contacts",
                table: "globals_contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_globals_addresses",
                table: "globals_addresses");

            migrationBuilder.RenameTable(
                name: "globals_contacts",
                newName: "Contact");

            migrationBuilder.RenameTable(
                name: "globals_addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_globals_contacts_SupplierId",
                table: "Contact",
                newName: "IX_Contact_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_globals_contacts_ClientId",
                table: "Contact",
                newName: "IX_Contact_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_globals_addresses_SupplierId",
                table: "Address",
                newName: "IX_Address_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_globals_addresses_ClientId",
                table: "Address",
                newName: "IX_Address_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_inventory_suppliers_SupplierId",
                table: "Address",
                column: "SupplierId",
                principalTable: "inventory_suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_sales_clients_ClientId",
                table: "Address",
                column: "ClientId",
                principalTable: "sales_clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_inventory_suppliers_SupplierId",
                table: "Contact",
                column: "SupplierId",
                principalTable: "inventory_suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_sales_clients_ClientId",
                table: "Contact",
                column: "ClientId",
                principalTable: "sales_clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_inventory_suppliers_SupplierId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_sales_clients_ClientId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_inventory_suppliers_SupplierId",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_sales_clients_ClientId",
                table: "Contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "globals_contacts");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "globals_addresses");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_SupplierId",
                table: "globals_contacts",
                newName: "IX_globals_contacts_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_ClientId",
                table: "globals_contacts",
                newName: "IX_globals_contacts_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_SupplierId",
                table: "globals_addresses",
                newName: "IX_globals_addresses_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_ClientId",
                table: "globals_addresses",
                newName: "IX_globals_addresses_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_globals_contacts",
                table: "globals_contacts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_globals_addresses",
                table: "globals_addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_globals_addresses_inventory_suppliers_SupplierId",
                table: "globals_addresses",
                column: "SupplierId",
                principalTable: "inventory_suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_globals_addresses_sales_clients_ClientId",
                table: "globals_addresses",
                column: "ClientId",
                principalTable: "sales_clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_globals_contacts_inventory_suppliers_SupplierId",
                table: "globals_contacts",
                column: "SupplierId",
                principalTable: "inventory_suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_globals_contacts_sales_clients_ClientId",
                table: "globals_contacts",
                column: "ClientId",
                principalTable: "sales_clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
