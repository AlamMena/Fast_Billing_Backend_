using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class TableRenamev3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_global_contact_addresses_global_contacts_ContactId",
                table: "global_contact_addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_global_contact_addresses",
                table: "global_contact_addresses");

            migrationBuilder.RenameTable(
                name: "global_contact_addresses",
                newName: "global_contacts_addresses");

            migrationBuilder.RenameIndex(
                name: "IX_global_contact_addresses_ContactId",
                table: "global_contacts_addresses",
                newName: "IX_global_contacts_addresses_ContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_global_contacts_addresses",
                table: "global_contacts_addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_global_contacts_addresses_global_contacts_ContactId",
                table: "global_contacts_addresses",
                column: "ContactId",
                principalTable: "global_contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_global_contacts_addresses_global_contacts_ContactId",
                table: "global_contacts_addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_global_contacts_addresses",
                table: "global_contacts_addresses");

            migrationBuilder.RenameTable(
                name: "global_contacts_addresses",
                newName: "global_contact_addresses");

            migrationBuilder.RenameIndex(
                name: "IX_global_contacts_addresses_ContactId",
                table: "global_contact_addresses",
                newName: "IX_global_contact_addresses_ContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_global_contact_addresses",
                table: "global_contact_addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_global_contact_addresses_global_contacts_ContactId",
                table: "global_contact_addresses",
                column: "ContactId",
                principalTable: "global_contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
