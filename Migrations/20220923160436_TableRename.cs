using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class TableRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Companies_CompanyId",
                table: "Branches");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Branches_BranchId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Companies_CompanyId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Contacts_Types_TypeId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Inventory_Products_ProductId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Addresses_Contacts_ContactId",
                table: "Contacts_Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Inv_Categories_Branches_BranchId",
                table: "Inv_Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inv_Categories_Companies_CompanyId",
                table: "Inv_Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inv_SubCategories_Branches_BranchId",
                table: "Inv_SubCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inv_SubCategories_Companies_CompanyId",
                table: "Inv_SubCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Brands_Branches_BranchId",
                table: "Inventory_Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Brands_Companies_CompanyId",
                table: "Inventory_Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Product_Prices_Branches_BranchId",
                table: "Inventory_Product_Prices");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Product_Prices_Companies_CompanyId",
                table: "Inventory_Product_Prices");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Product_Prices_Inventory_Products_ProductId",
                table: "Inventory_Product_Prices");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Products_Branches_BranchId",
                table: "Inventory_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Products_Companies_CompanyId",
                table: "Inventory_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Products_Inv_Categories_CategoryId",
                table: "Inventory_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Products_Inv_SubCategories_SubCategoryId",
                table: "Inventory_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Products_Inventory_Brands_BrandId",
                table: "Inventory_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Products_Images_Inventory_Products_ProductId",
                table: "Inventory_Products_Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Products_Stock_Branches_BranchId",
                table: "Inventory_Products_Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Products_Stock_Companies_CompanyId",
                table: "Inventory_Products_Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Products_Stock_Inventory_Products_ProductId",
                table: "Inventory_Products_Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_Usr_User_Branches_BranchId",
                table: "Usr_User");

            migrationBuilder.DropForeignKey(
                name: "FK_Usr_User_Companies_CompanyId",
                table: "Usr_User");

            migrationBuilder.DropTable(
                name: "Inv_Brands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventory_Products_Stock",
                table: "Inventory_Products_Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventory_Products_Images",
                table: "Inventory_Products_Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventory_Products",
                table: "Inventory_Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventory_Product_Prices",
                table: "Inventory_Product_Prices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventory_Brands",
                table: "Inventory_Brands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts_Types",
                table: "Contacts_Types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usr_User",
                table: "Usr_User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inv_SubCategories",
                table: "Inv_SubCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inv_Categories",
                table: "Inv_Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts_Addresses",
                table: "Contacts_Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branches",
                table: "Branches");

            migrationBuilder.RenameTable(
                name: "Inventory_Products_Stock",
                newName: "inventory_products_stock");

            migrationBuilder.RenameTable(
                name: "Inventory_Products_Images",
                newName: "inventory_products_images");

            migrationBuilder.RenameTable(
                name: "Inventory_Products",
                newName: "inventory_products");

            migrationBuilder.RenameTable(
                name: "Inventory_Product_Prices",
                newName: "inventory_product_prices");

            migrationBuilder.RenameTable(
                name: "Inventory_Brands",
                newName: "inventory_brands");

            migrationBuilder.RenameTable(
                name: "Contacts_Types",
                newName: "contacts_types");

            migrationBuilder.RenameTable(
                name: "Usr_User",
                newName: "globals_user");

            migrationBuilder.RenameTable(
                name: "Inv_SubCategories",
                newName: "inventory_subcategories");

            migrationBuilder.RenameTable(
                name: "Inv_Categories",
                newName: "inventory_categories");

            migrationBuilder.RenameTable(
                name: "Contacts_Addresses",
                newName: "global_contacts_addresses");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "global_contacts");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "system_companies");

            migrationBuilder.RenameTable(
                name: "Branches",
                newName: "system_branches");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_Products_Stock_ProductId",
                table: "inventory_products_stock",
                newName: "IX_inventory_products_stock_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_Products_Stock_CompanyId",
                table: "inventory_products_stock",
                newName: "IX_inventory_products_stock_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_Products_Stock_BranchId",
                table: "inventory_products_stock",
                newName: "IX_inventory_products_stock_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_Products_Images_ProductId",
                table: "inventory_products_images",
                newName: "IX_inventory_products_images_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_Products_SubCategoryId",
                table: "inventory_products",
                newName: "IX_inventory_products_SubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_Products_CompanyId",
                table: "inventory_products",
                newName: "IX_inventory_products_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_Products_CategoryId",
                table: "inventory_products",
                newName: "IX_inventory_products_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_Products_BrandId",
                table: "inventory_products",
                newName: "IX_inventory_products_BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_Products_BranchId",
                table: "inventory_products",
                newName: "IX_inventory_products_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_Product_Prices_ProductId",
                table: "inventory_product_prices",
                newName: "IX_inventory_product_prices_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_Product_Prices_CompanyId",
                table: "inventory_product_prices",
                newName: "IX_inventory_product_prices_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_Product_Prices_BranchId",
                table: "inventory_product_prices",
                newName: "IX_inventory_product_prices_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_Brands_CompanyId",
                table: "inventory_brands",
                newName: "IX_inventory_brands_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_Brands_BranchId",
                table: "inventory_brands",
                newName: "IX_inventory_brands_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Usr_User_CompanyId",
                table: "globals_user",
                newName: "IX_globals_user_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Usr_User_BranchId",
                table: "globals_user",
                newName: "IX_globals_user_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Inv_SubCategories_CompanyId",
                table: "inventory_subcategories",
                newName: "IX_inventory_subcategories_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Inv_SubCategories_BranchId",
                table: "inventory_subcategories",
                newName: "IX_inventory_subcategories_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Inv_Categories_CompanyId",
                table: "inventory_categories",
                newName: "IX_inventory_categories_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Inv_Categories_BranchId",
                table: "inventory_categories",
                newName: "IX_inventory_categories_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_Addresses_ContactId",
                table: "global_contacts_addresses",
                newName: "IX_global_contacts_addresses_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_TypeId",
                table: "global_contacts",
                newName: "IX_global_contacts_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_ProductId",
                table: "global_contacts",
                newName: "IX_global_contacts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_CompanyId",
                table: "global_contacts",
                newName: "IX_global_contacts_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_BranchId",
                table: "global_contacts",
                newName: "IX_global_contacts_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Branches_CompanyId",
                table: "system_branches",
                newName: "IX_system_branches_CompanyId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Stock",
                table: "inventory_products_stock",
                type: "decimal(18,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Tax",
                table: "inventory_products",
                type: "decimal(18,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "inventory_products",
                type: "decimal(18,6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Large",
                table: "inventory_products",
                type: "decimal(18,6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Capacity",
                table: "inventory_products",
                type: "decimal(18,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Anchor",
                table: "inventory_products",
                type: "decimal(18,6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "inventory_product_prices",
                type: "decimal(18,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MarginBenefit",
                table: "inventory_product_prices",
                type: "decimal(18,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DetailQuantity",
                table: "inventory_product_prices",
                type: "decimal(18,6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "inventory_product_prices",
                type: "decimal(18,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Disccount",
                table: "global_contacts",
                type: "decimal(18,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CreditLimit",
                table: "global_contacts",
                type: "decimal(18,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventory_products_stock",
                table: "inventory_products_stock",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventory_products_images",
                table: "inventory_products_images",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventory_products",
                table: "inventory_products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventory_product_prices",
                table: "inventory_product_prices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventory_brands",
                table: "inventory_brands",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contacts_types",
                table: "contacts_types",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_globals_user",
                table: "globals_user",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventory_subcategories",
                table: "inventory_subcategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventory_categories",
                table: "inventory_categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_global_contacts_addresses",
                table: "global_contacts_addresses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_global_contacts",
                table: "global_contacts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_system_companies",
                table: "system_companies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_system_branches",
                table: "system_branches",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "globals_contacts_Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastDigits = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_globals_contacts_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_globals_contacts_Cards_global_contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "global_contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "globals_contacts_phone_numbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_globals_contacts_phone_numbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_globals_contacts_phone_numbers_global_contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "global_contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_globals_contacts_Cards_ContactId",
                table: "globals_contacts_Cards",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_globals_contacts_phone_numbers_ContactId",
                table: "globals_contacts_phone_numbers",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_global_contacts_contacts_types_TypeId",
                table: "global_contacts",
                column: "TypeId",
                principalTable: "contacts_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_global_contacts_inventory_products_ProductId",
                table: "global_contacts",
                column: "ProductId",
                principalTable: "inventory_products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_global_contacts_system_branches_BranchId",
                table: "global_contacts",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_global_contacts_system_companies_CompanyId",
                table: "global_contacts",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_global_contacts_addresses_global_contacts_ContactId",
                table: "global_contacts_addresses",
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
                name: "FK_inventory_brands_system_branches_BranchId",
                table: "inventory_brands",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_brands_system_companies_CompanyId",
                table: "inventory_brands",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_categories_system_branches_BranchId",
                table: "inventory_categories",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_categories_system_companies_CompanyId",
                table: "inventory_categories",
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

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_inventory_brands_BrandId",
                table: "inventory_products",
                column: "BrandId",
                principalTable: "inventory_brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_inventory_categories_CategoryId",
                table: "inventory_products",
                column: "CategoryId",
                principalTable: "inventory_categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_inventory_subcategories_SubCategoryId",
                table: "inventory_products",
                column: "SubCategoryId",
                principalTable: "inventory_subcategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_system_branches_BranchId",
                table: "inventory_products",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_system_companies_CompanyId",
                table: "inventory_products",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_images_inventory_products_ProductId",
                table: "inventory_products_images",
                column: "ProductId",
                principalTable: "inventory_products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_stock_inventory_products_ProductId",
                table: "inventory_products_stock",
                column: "ProductId",
                principalTable: "inventory_products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_stock_system_branches_BranchId",
                table: "inventory_products_stock",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_stock_system_companies_CompanyId",
                table: "inventory_products_stock",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_subcategories_system_branches_BranchId",
                table: "inventory_subcategories",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_subcategories_system_companies_CompanyId",
                table: "inventory_subcategories",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_system_branches_system_companies_CompanyId",
                table: "system_branches",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_global_contacts_contacts_types_TypeId",
                table: "global_contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_global_contacts_inventory_products_ProductId",
                table: "global_contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_global_contacts_system_branches_BranchId",
                table: "global_contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_global_contacts_system_companies_CompanyId",
                table: "global_contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_global_contacts_addresses_global_contacts_ContactId",
                table: "global_contacts_addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_user_system_branches_BranchId",
                table: "globals_user");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_user_system_companies_CompanyId",
                table: "globals_user");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_brands_system_branches_BranchId",
                table: "inventory_brands");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_brands_system_companies_CompanyId",
                table: "inventory_brands");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_categories_system_branches_BranchId",
                table: "inventory_categories");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_categories_system_companies_CompanyId",
                table: "inventory_categories");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_product_prices_inventory_products_ProductId",
                table: "inventory_product_prices");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_product_prices_system_branches_BranchId",
                table: "inventory_product_prices");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_product_prices_system_companies_CompanyId",
                table: "inventory_product_prices");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_inventory_brands_BrandId",
                table: "inventory_products");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_inventory_categories_CategoryId",
                table: "inventory_products");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_inventory_subcategories_SubCategoryId",
                table: "inventory_products");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_system_branches_BranchId",
                table: "inventory_products");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_system_companies_CompanyId",
                table: "inventory_products");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_images_inventory_products_ProductId",
                table: "inventory_products_images");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_stock_inventory_products_ProductId",
                table: "inventory_products_stock");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_stock_system_branches_BranchId",
                table: "inventory_products_stock");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_stock_system_companies_CompanyId",
                table: "inventory_products_stock");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_subcategories_system_branches_BranchId",
                table: "inventory_subcategories");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_subcategories_system_companies_CompanyId",
                table: "inventory_subcategories");

            migrationBuilder.DropForeignKey(
                name: "FK_system_branches_system_companies_CompanyId",
                table: "system_branches");

            migrationBuilder.DropTable(
                name: "globals_contacts_Cards");

            migrationBuilder.DropTable(
                name: "globals_contacts_phone_numbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventory_products_stock",
                table: "inventory_products_stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventory_products_images",
                table: "inventory_products_images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventory_products",
                table: "inventory_products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventory_product_prices",
                table: "inventory_product_prices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventory_brands",
                table: "inventory_brands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contacts_types",
                table: "contacts_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_system_companies",
                table: "system_companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_system_branches",
                table: "system_branches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventory_subcategories",
                table: "inventory_subcategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventory_categories",
                table: "inventory_categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_globals_user",
                table: "globals_user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_global_contacts_addresses",
                table: "global_contacts_addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_global_contacts",
                table: "global_contacts");

            migrationBuilder.RenameTable(
                name: "inventory_products_stock",
                newName: "Inventory_Products_Stock");

            migrationBuilder.RenameTable(
                name: "inventory_products_images",
                newName: "Inventory_Products_Images");

            migrationBuilder.RenameTable(
                name: "inventory_products",
                newName: "Inventory_Products");

            migrationBuilder.RenameTable(
                name: "inventory_product_prices",
                newName: "Inventory_Product_Prices");

            migrationBuilder.RenameTable(
                name: "inventory_brands",
                newName: "Inventory_Brands");

            migrationBuilder.RenameTable(
                name: "contacts_types",
                newName: "Contacts_Types");

            migrationBuilder.RenameTable(
                name: "system_companies",
                newName: "Companies");

            migrationBuilder.RenameTable(
                name: "system_branches",
                newName: "Branches");

            migrationBuilder.RenameTable(
                name: "inventory_subcategories",
                newName: "Inv_SubCategories");

            migrationBuilder.RenameTable(
                name: "inventory_categories",
                newName: "Inv_Categories");

            migrationBuilder.RenameTable(
                name: "globals_user",
                newName: "Usr_User");

            migrationBuilder.RenameTable(
                name: "global_contacts_addresses",
                newName: "Contacts_Addresses");

            migrationBuilder.RenameTable(
                name: "global_contacts",
                newName: "Contacts");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_products_stock_ProductId",
                table: "Inventory_Products_Stock",
                newName: "IX_Inventory_Products_Stock_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_products_stock_CompanyId",
                table: "Inventory_Products_Stock",
                newName: "IX_Inventory_Products_Stock_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_products_stock_BranchId",
                table: "Inventory_Products_Stock",
                newName: "IX_Inventory_Products_Stock_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_products_images_ProductId",
                table: "Inventory_Products_Images",
                newName: "IX_Inventory_Products_Images_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_products_SubCategoryId",
                table: "Inventory_Products",
                newName: "IX_Inventory_Products_SubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_products_CompanyId",
                table: "Inventory_Products",
                newName: "IX_Inventory_Products_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_products_CategoryId",
                table: "Inventory_Products",
                newName: "IX_Inventory_Products_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_products_BrandId",
                table: "Inventory_Products",
                newName: "IX_Inventory_Products_BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_products_BranchId",
                table: "Inventory_Products",
                newName: "IX_Inventory_Products_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_product_prices_ProductId",
                table: "Inventory_Product_Prices",
                newName: "IX_Inventory_Product_Prices_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_product_prices_CompanyId",
                table: "Inventory_Product_Prices",
                newName: "IX_Inventory_Product_Prices_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_product_prices_BranchId",
                table: "Inventory_Product_Prices",
                newName: "IX_Inventory_Product_Prices_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_brands_CompanyId",
                table: "Inventory_Brands",
                newName: "IX_Inventory_Brands_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_brands_BranchId",
                table: "Inventory_Brands",
                newName: "IX_Inventory_Brands_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_system_branches_CompanyId",
                table: "Branches",
                newName: "IX_Branches_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_subcategories_CompanyId",
                table: "Inv_SubCategories",
                newName: "IX_Inv_SubCategories_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_subcategories_BranchId",
                table: "Inv_SubCategories",
                newName: "IX_Inv_SubCategories_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_categories_CompanyId",
                table: "Inv_Categories",
                newName: "IX_Inv_Categories_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_categories_BranchId",
                table: "Inv_Categories",
                newName: "IX_Inv_Categories_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_globals_user_CompanyId",
                table: "Usr_User",
                newName: "IX_Usr_User_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_globals_user_BranchId",
                table: "Usr_User",
                newName: "IX_Usr_User_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_global_contacts_addresses_ContactId",
                table: "Contacts_Addresses",
                newName: "IX_Contacts_Addresses_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_global_contacts_TypeId",
                table: "Contacts",
                newName: "IX_Contacts_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_global_contacts_ProductId",
                table: "Contacts",
                newName: "IX_Contacts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_global_contacts_CompanyId",
                table: "Contacts",
                newName: "IX_Contacts_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_global_contacts_BranchId",
                table: "Contacts",
                newName: "IX_Contacts_BranchId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Stock",
                table: "Inventory_Products_Stock",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Tax",
                table: "Inventory_Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Inventory_Products",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Large",
                table: "Inventory_Products",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Capacity",
                table: "Inventory_Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Anchor",
                table: "Inventory_Products",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Inventory_Product_Prices",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MarginBenefit",
                table: "Inventory_Product_Prices",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DetailQuantity",
                table: "Inventory_Product_Prices",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Inventory_Product_Prices",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Disccount",
                table: "Contacts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CreditLimit",
                table: "Contacts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventory_Products_Stock",
                table: "Inventory_Products_Stock",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventory_Products_Images",
                table: "Inventory_Products_Images",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventory_Products",
                table: "Inventory_Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventory_Product_Prices",
                table: "Inventory_Product_Prices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventory_Brands",
                table: "Inventory_Brands",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts_Types",
                table: "Contacts_Types",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branches",
                table: "Branches",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inv_SubCategories",
                table: "Inv_SubCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inv_Categories",
                table: "Inv_Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usr_User",
                table: "Usr_User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts_Addresses",
                table: "Contacts_Addresses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Inv_Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocNum = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inv_Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inv_Brands_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inv_Brands_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inv_Brands_BranchId",
                table: "Inv_Brands",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Inv_Brands_CompanyId",
                table: "Inv_Brands",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Companies_CompanyId",
                table: "Branches",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Branches_BranchId",
                table: "Contacts",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Companies_CompanyId",
                table: "Contacts",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Contacts_Types_TypeId",
                table: "Contacts",
                column: "TypeId",
                principalTable: "Contacts_Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Inventory_Products_ProductId",
                table: "Contacts",
                column: "ProductId",
                principalTable: "Inventory_Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Addresses_Contacts_ContactId",
                table: "Contacts_Addresses",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inv_Categories_Branches_BranchId",
                table: "Inv_Categories",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inv_Categories_Companies_CompanyId",
                table: "Inv_Categories",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inv_SubCategories_Branches_BranchId",
                table: "Inv_SubCategories",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inv_SubCategories_Companies_CompanyId",
                table: "Inv_SubCategories",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Brands_Branches_BranchId",
                table: "Inventory_Brands",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Brands_Companies_CompanyId",
                table: "Inventory_Brands",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Product_Prices_Branches_BranchId",
                table: "Inventory_Product_Prices",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Product_Prices_Companies_CompanyId",
                table: "Inventory_Product_Prices",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Product_Prices_Inventory_Products_ProductId",
                table: "Inventory_Product_Prices",
                column: "ProductId",
                principalTable: "Inventory_Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Products_Branches_BranchId",
                table: "Inventory_Products",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Products_Companies_CompanyId",
                table: "Inventory_Products",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Products_Inv_Categories_CategoryId",
                table: "Inventory_Products",
                column: "CategoryId",
                principalTable: "Inv_Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Products_Inv_SubCategories_SubCategoryId",
                table: "Inventory_Products",
                column: "SubCategoryId",
                principalTable: "Inv_SubCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Products_Inventory_Brands_BrandId",
                table: "Inventory_Products",
                column: "BrandId",
                principalTable: "Inventory_Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Products_Images_Inventory_Products_ProductId",
                table: "Inventory_Products_Images",
                column: "ProductId",
                principalTable: "Inventory_Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Products_Stock_Branches_BranchId",
                table: "Inventory_Products_Stock",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Products_Stock_Companies_CompanyId",
                table: "Inventory_Products_Stock",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Products_Stock_Inventory_Products_ProductId",
                table: "Inventory_Products_Stock",
                column: "ProductId",
                principalTable: "Inventory_Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usr_User_Branches_BranchId",
                table: "Usr_User",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usr_User_Companies_CompanyId",
                table: "Usr_User",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
