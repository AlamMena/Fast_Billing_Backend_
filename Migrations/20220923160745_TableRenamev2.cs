using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class TableRenamev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_global_contacts_contacts_types_TypeId",
                table: "global_contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_global_contacts_addresses_global_contacts_ContactId",
                table: "global_contacts_addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_contacts_Cards_global_contacts_ContactId",
                table: "globals_contacts_Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_contacts_phone_numbers_global_contacts_ContactId",
                table: "globals_contacts_phone_numbers");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_user_system_branches_BranchId",
                table: "globals_user");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_user_system_companies_CompanyId",
                table: "globals_user");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_product_prices_inventory_products_ProductId",
                table: "inventory_product_prices");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_product_prices_system_branches_BranchId",
                table: "inventory_product_prices");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_product_prices_system_companies_CompanyId",
                table: "inventory_product_prices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventory_product_prices",
                table: "inventory_product_prices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_globals_user",
                table: "globals_user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_globals_contacts_phone_numbers",
                table: "globals_contacts_phone_numbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_globals_contacts_Cards",
                table: "globals_contacts_Cards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_global_contacts_addresses",
                table: "global_contacts_addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contacts_types",
                table: "contacts_types");

            migrationBuilder.RenameTable(
                name: "inventory_product_prices",
                newName: "inventory_products_prices");

            migrationBuilder.RenameTable(
                name: "globals_user",
                newName: "globals_users");

            migrationBuilder.RenameTable(
                name: "globals_contacts_phone_numbers",
                newName: "global_contacts_phone_numbers");

            migrationBuilder.RenameTable(
                name: "globals_contacts_Cards",
                newName: "global_contacts_cards");

            migrationBuilder.RenameTable(
                name: "global_contacts_addresses",
                newName: "global_contact_addresses");

            migrationBuilder.RenameTable(
                name: "contacts_types",
                newName: "global_contacts_types");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_product_prices_ProductId",
                table: "inventory_products_prices",
                newName: "IX_inventory_products_prices_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_product_prices_CompanyId",
                table: "inventory_products_prices",
                newName: "IX_inventory_products_prices_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_product_prices_BranchId",
                table: "inventory_products_prices",
                newName: "IX_inventory_products_prices_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_globals_user_CompanyId",
                table: "globals_users",
                newName: "IX_globals_users_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_globals_user_BranchId",
                table: "globals_users",
                newName: "IX_globals_users_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_globals_contacts_phone_numbers_ContactId",
                table: "global_contacts_phone_numbers",
                newName: "IX_global_contacts_phone_numbers_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_globals_contacts_Cards_ContactId",
                table: "global_contacts_cards",
                newName: "IX_global_contacts_cards_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_global_contacts_addresses_ContactId",
                table: "global_contact_addresses",
                newName: "IX_global_contact_addresses_ContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventory_products_prices",
                table: "inventory_products_prices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_globals_users",
                table: "globals_users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_global_contacts_phone_numbers",
                table: "global_contacts_phone_numbers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_global_contacts_cards",
                table: "global_contacts_cards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_global_contact_addresses",
                table: "global_contact_addresses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_global_contacts_types",
                table: "global_contacts_types",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_global_contact_addresses_global_contacts_ContactId",
                table: "global_contact_addresses",
                column: "ContactId",
                principalTable: "global_contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_global_contacts_global_contacts_types_TypeId",
                table: "global_contacts",
                column: "TypeId",
                principalTable: "global_contacts_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_global_contacts_cards_global_contacts_ContactId",
                table: "global_contacts_cards",
                column: "ContactId",
                principalTable: "global_contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_global_contacts_phone_numbers_global_contacts_ContactId",
                table: "global_contacts_phone_numbers",
                column: "ContactId",
                principalTable: "global_contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_globals_users_system_branches_BranchId",
                table: "globals_users",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_globals_users_system_companies_CompanyId",
                table: "globals_users",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_prices_inventory_products_ProductId",
                table: "inventory_products_prices",
                column: "ProductId",
                principalTable: "inventory_products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_prices_system_branches_BranchId",
                table: "inventory_products_prices",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_prices_system_companies_CompanyId",
                table: "inventory_products_prices",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_global_contact_addresses_global_contacts_ContactId",
                table: "global_contact_addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_global_contacts_global_contacts_types_TypeId",
                table: "global_contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_global_contacts_cards_global_contacts_ContactId",
                table: "global_contacts_cards");

            migrationBuilder.DropForeignKey(
                name: "FK_global_contacts_phone_numbers_global_contacts_ContactId",
                table: "global_contacts_phone_numbers");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_users_system_branches_BranchId",
                table: "globals_users");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_users_system_companies_CompanyId",
                table: "globals_users");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_prices_inventory_products_ProductId",
                table: "inventory_products_prices");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_prices_system_branches_BranchId",
                table: "inventory_products_prices");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_prices_system_companies_CompanyId",
                table: "inventory_products_prices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventory_products_prices",
                table: "inventory_products_prices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_globals_users",
                table: "globals_users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_global_contacts_types",
                table: "global_contacts_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_global_contacts_phone_numbers",
                table: "global_contacts_phone_numbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_global_contacts_cards",
                table: "global_contacts_cards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_global_contact_addresses",
                table: "global_contact_addresses");

            migrationBuilder.RenameTable(
                name: "inventory_products_prices",
                newName: "inventory_product_prices");

            migrationBuilder.RenameTable(
                name: "globals_users",
                newName: "globals_user");

            migrationBuilder.RenameTable(
                name: "global_contacts_types",
                newName: "contacts_types");

            migrationBuilder.RenameTable(
                name: "global_contacts_phone_numbers",
                newName: "globals_contacts_phone_numbers");

            migrationBuilder.RenameTable(
                name: "global_contacts_cards",
                newName: "globals_contacts_Cards");

            migrationBuilder.RenameTable(
                name: "global_contact_addresses",
                newName: "global_contacts_addresses");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_products_prices_ProductId",
                table: "inventory_product_prices",
                newName: "IX_inventory_product_prices_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_products_prices_CompanyId",
                table: "inventory_product_prices",
                newName: "IX_inventory_product_prices_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_products_prices_BranchId",
                table: "inventory_product_prices",
                newName: "IX_inventory_product_prices_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_globals_users_CompanyId",
                table: "globals_user",
                newName: "IX_globals_user_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_globals_users_BranchId",
                table: "globals_user",
                newName: "IX_globals_user_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_global_contacts_phone_numbers_ContactId",
                table: "globals_contacts_phone_numbers",
                newName: "IX_globals_contacts_phone_numbers_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_global_contacts_cards_ContactId",
                table: "globals_contacts_Cards",
                newName: "IX_globals_contacts_Cards_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_global_contact_addresses_ContactId",
                table: "global_contacts_addresses",
                newName: "IX_global_contacts_addresses_ContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventory_product_prices",
                table: "inventory_product_prices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_globals_user",
                table: "globals_user",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contacts_types",
                table: "contacts_types",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_globals_contacts_phone_numbers",
                table: "globals_contacts_phone_numbers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_globals_contacts_Cards",
                table: "globals_contacts_Cards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_global_contacts_addresses",
                table: "global_contacts_addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_global_contacts_contacts_types_TypeId",
                table: "global_contacts",
                column: "TypeId",
                principalTable: "contacts_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_global_contacts_addresses_global_contacts_ContactId",
                table: "global_contacts_addresses",
                column: "ContactId",
                principalTable: "global_contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_globals_contacts_Cards_global_contacts_ContactId",
                table: "globals_contacts_Cards",
                column: "ContactId",
                principalTable: "global_contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_globals_contacts_phone_numbers_global_contacts_ContactId",
                table: "globals_contacts_phone_numbers",
                column: "ContactId",
                principalTable: "global_contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_globals_user_system_branches_BranchId",
                table: "globals_user",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_globals_user_system_companies_CompanyId",
                table: "globals_user",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_product_prices_inventory_products_ProductId",
                table: "inventory_product_prices",
                column: "ProductId",
                principalTable: "inventory_products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_product_prices_system_branches_BranchId",
                table: "inventory_product_prices",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_product_prices_system_companies_CompanyId",
                table: "inventory_product_prices",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id");
        }
    }
}
