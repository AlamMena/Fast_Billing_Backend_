using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class ProductsAndConctsInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Branches_BranchId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Companies_CompanyId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Branches_BranchId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Companies_CompanyId",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Inv_Categories");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "Inv_Brands");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_CompanyId",
                table: "Inv_Categories",
                newName: "IX_Inv_Categories_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_BranchId",
                table: "Inv_Categories",
                newName: "IX_Inv_Categories_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Brands_CompanyId",
                table: "Inv_Brands",
                newName: "IX_Inv_Brands_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Brands_BranchId",
                table: "Inv_Brands",
                newName: "IX_Inv_Brands_BranchId");

            migrationBuilder.AddColumn<int>(
                name: "DocNum",
                table: "Usr_User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DocNum",
                table: "Inv_Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DocNum",
                table: "Inv_Brands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inv_Categories",
                table: "Inv_Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inv_Brands",
                table: "Inv_Brands",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Contacts_Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inv_SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocNum = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inv_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inv_SubCategories_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inv_SubCategories_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Inventory_Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocNum = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory_Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Brands_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inventory_Brands_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Inventory_Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnityPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Large = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Anchor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuyUnity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellUnity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasTax = table.Column<bool>(type: "bit", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OnStock = table.Column<bool>(type: "bit", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    ContactId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocNum = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Products_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inventory_Products_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inventory_Products_Inv_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Inv_Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inventory_Products_Inv_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "Inv_SubCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inventory_Products_Inventory_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Inventory_Brands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    AllowCredit = table.Column<bool>(type: "bit", nullable: false),
                    CreditLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreditDays = table.Column<int>(type: "int", nullable: false),
                    AllowDisccount = table.Column<bool>(type: "bit", nullable: false),
                    Disccount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocNum = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contacts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contacts_Contacts_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Contacts_Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contacts_Inventory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Inventory_Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Inventory_Product_Prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MarginBenefit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BuyUnity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SellUnity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocNum = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory_Product_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Product_Prices_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inventory_Product_Prices_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inventory_Product_Prices_Inventory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Inventory_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory_Products_Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory_Products_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Products_Images_Inventory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Inventory_Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Inventory_Products_Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stock = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocNum = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory_Products_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Products_Stock_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inventory_Products_Stock_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inventory_Products_Stock_Inventory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Inventory_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts_Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Main = table.Column<bool>(type: "bit", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Addresses_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_BranchId",
                table: "Contacts",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CompanyId",
                table: "Contacts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ProductId",
                table: "Contacts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_TypeId",
                table: "Contacts",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Addresses_ContactId",
                table: "Contacts_Addresses",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Inv_SubCategories_BranchId",
                table: "Inv_SubCategories",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Inv_SubCategories_CompanyId",
                table: "Inv_SubCategories",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Brands_BranchId",
                table: "Inventory_Brands",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Brands_CompanyId",
                table: "Inventory_Brands",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Product_Prices_BranchId",
                table: "Inventory_Product_Prices",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Product_Prices_CompanyId",
                table: "Inventory_Product_Prices",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Product_Prices_ProductId",
                table: "Inventory_Product_Prices",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Products_BranchId",
                table: "Inventory_Products",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Products_BrandId",
                table: "Inventory_Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Products_CategoryId",
                table: "Inventory_Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Products_CompanyId",
                table: "Inventory_Products",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Products_SubCategoryId",
                table: "Inventory_Products",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Products_Images_ProductId",
                table: "Inventory_Products_Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Products_Stock_BranchId",
                table: "Inventory_Products_Stock",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Products_Stock_CompanyId",
                table: "Inventory_Products_Stock",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Products_Stock_ProductId",
                table: "Inventory_Products_Stock",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inv_Brands_Branches_BranchId",
                table: "Inv_Brands",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inv_Brands_Companies_CompanyId",
                table: "Inv_Brands",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inv_Brands_Branches_BranchId",
                table: "Inv_Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Inv_Brands_Companies_CompanyId",
                table: "Inv_Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Inv_Categories_Branches_BranchId",
                table: "Inv_Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inv_Categories_Companies_CompanyId",
                table: "Inv_Categories");

            migrationBuilder.DropTable(
                name: "Contacts_Addresses");

            migrationBuilder.DropTable(
                name: "Inventory_Product_Prices");

            migrationBuilder.DropTable(
                name: "Inventory_Products_Images");

            migrationBuilder.DropTable(
                name: "Inventory_Products_Stock");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Contacts_Types");

            migrationBuilder.DropTable(
                name: "Inventory_Products");

            migrationBuilder.DropTable(
                name: "Inv_SubCategories");

            migrationBuilder.DropTable(
                name: "Inventory_Brands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inv_Categories",
                table: "Inv_Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inv_Brands",
                table: "Inv_Brands");

            migrationBuilder.DropColumn(
                name: "DocNum",
                table: "Usr_User");

            migrationBuilder.DropColumn(
                name: "DocNum",
                table: "Inv_Categories");

            migrationBuilder.DropColumn(
                name: "DocNum",
                table: "Inv_Brands");

            migrationBuilder.RenameTable(
                name: "Inv_Categories",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Inv_Brands",
                newName: "Brands");

            migrationBuilder.RenameIndex(
                name: "IX_Inv_Categories_CompanyId",
                table: "Categories",
                newName: "IX_Categories_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Inv_Categories_BranchId",
                table: "Categories",
                newName: "IX_Categories_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Inv_Brands_CompanyId",
                table: "Brands",
                newName: "IX_Brands_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Inv_Brands_BranchId",
                table: "Brands",
                newName: "IX_Brands_BranchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Branches_BranchId",
                table: "Brands",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Companies_CompanyId",
                table: "Brands",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Branches_BranchId",
                table: "Categories",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Companies_CompanyId",
                table: "Categories",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
