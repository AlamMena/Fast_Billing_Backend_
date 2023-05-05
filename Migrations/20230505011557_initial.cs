using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Errors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Errors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "globals_payments_banks",
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
                    table.PrimaryKey("PK_globals_payments_banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "globals_payments_types",
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
                    table.PrimaryKey("PK_globals_payments_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sales_clients_types",
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
                    table.PrimaryKey("PK_sales_clients_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sales_invoices_types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales_invoices_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sales_ncf_types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales_ncf_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "system_companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoIdentification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_system_companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "system_currency",
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
                    table.PrimaryKey("PK_system_currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "system_branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_system_branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_system_branches_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "globals_users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirebaseId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_globals_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_globals_users_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_globals_users_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inventory_brands",
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
                    table.PrimaryKey("PK_inventory_brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventory_brands_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_brands_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inventory_categories",
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
                    table.PrimaryKey("PK_inventory_categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventory_categories_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_categories_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inventory_suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoIdentification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DaysToPay = table.Column<int>(type: "int", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_inventory_suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventory_suppliers_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_suppliers_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_suppliers_system_currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "system_currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inventory_warehouses",
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
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocNum = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory_warehouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventory_warehouses_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_warehouses_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sales_ncf_sequences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NCFTypeId = table.Column<int>(type: "int", nullable: false),
                    LastNumber = table.Column<int>(type: "int", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SequenceSince = table.Column<int>(type: "int", nullable: false),
                    SequenceUntil = table.Column<int>(type: "int", nullable: false),
                    Alert = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_sales_ncf_sequences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sales_ncf_sequences_sales_ncf_types_NCFTypeId",
                        column: x => x.NCFTypeId,
                        principalTable: "sales_ncf_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sales_ncf_sequences_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sales_ncf_sequences_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inventory_subcategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_inventory_subcategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventory_subcategories_inventory_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "inventory_categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_subcategories_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_subcategories_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "accounts_payable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ncf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierReceipt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierNoIdentification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierDocNum = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DisccountAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Confirmed = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_accounts_payable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accounts_payable_inventory_suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "inventory_suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_accounts_payable_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_accounts_payable_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inventory_suppliers_addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Main = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory_suppliers_addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventory_suppliers_addresses_inventory_suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "inventory_suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inventory_suppliers_contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Main = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory_suppliers_contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventory_suppliers_contacts_inventory_suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "inventory_suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inventory_products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    UnityPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Large = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Anchor = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuyUnity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellUnity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasTax = table.Column<bool>(type: "bit", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    OnStock = table.Column<bool>(type: "bit", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_inventory_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventory_products_inventory_brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "inventory_brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_products_inventory_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "inventory_categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_products_inventory_subcategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "inventory_subcategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_products_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_products_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "accounts_payable_transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountPayableId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Sign = table.Column<int>(type: "int", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts_payable_transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accounts_payable_transactions_accounts_payable_AccountPayableId",
                        column: x => x.AccountPayableId,
                        principalTable: "accounts_payable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inventory_goods_receipt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    NumeroFactura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierNoIdentification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Days = table.Column<int>(type: "int", nullable: false),
                    SellerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Applied = table.Column<bool>(type: "bit", nullable: false),
                    NcfTypeId = table.Column<int>(type: "int", nullable: false),
                    Ncf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NcfName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceNcf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Confirmed = table.Column<bool>(type: "bit", nullable: false),
                    UpdateCost = table.Column<bool>(type: "bit", nullable: false),
                    UpdatePrice = table.Column<bool>(type: "bit", nullable: false),
                    IncludeTaxes = table.Column<bool>(type: "bit", nullable: true),
                    TypedSubtotal = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TypedDiscount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TypedTotalTax = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TypedTotalCharge = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TypedTotal = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TotalPayed = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Return = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TotalDiscount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TotalTax = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TotalCharge = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_inventory_goods_receipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventory_goods_receipt_accounts_payable_AccountId",
                        column: x => x.AccountId,
                        principalTable: "accounts_payable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_goods_receipt_inventory_suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "inventory_suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_goods_receipt_inventory_warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "inventory_warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_goods_receipt_sales_ncf_types_NcfTypeId",
                        column: x => x.NcfTypeId,
                        principalTable: "sales_ncf_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_goods_receipt_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_goods_receipt_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inventory_products_images",
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
                    table.PrimaryKey("PK_inventory_products_images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventory_products_images_inventory_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "inventory_products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inventory_products_prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    MarginBenefit = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
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
                    table.PrimaryKey("PK_inventory_products_prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventory_products_prices_inventory_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "inventory_products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_products_prices_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_products_prices_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inventory_products_stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stock = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_inventory_products_stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventory_products_stock_inventory_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "inventory_products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_products_stock_inventory_warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "inventory_warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_products_stock_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_products_stock_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sales_clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoIdentification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    AllowCredit = table.Column<bool>(type: "bit", nullable: false),
                    CreditLimit = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CreditDays = table.Column<int>(type: "int", nullable: false),
                    AllowDiscount = table.Column<bool>(type: "bit", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
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
                    table.PrimaryKey("PK_sales_clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sales_clients_inventory_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "inventory_products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sales_clients_sales_clients_types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "sales_clients_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sales_clients_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sales_clients_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inventory_goods_receipt_details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    OldCost = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    OldPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Exento = table.Column<bool>(type: "bit", nullable: false),
                    MarginBenefit = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Excent = table.Column<bool>(type: "bit", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    BuyUnity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Empaque = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    SellUnity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoodReceiptId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory_goods_receipt_details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventory_goods_receipt_details_inventory_goods_receipt_GoodReceiptId",
                        column: x => x.GoodReceiptId,
                        principalTable: "inventory_goods_receipt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_goods_receipt_details_inventory_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "inventory_products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_goods_receipt_details_inventory_warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "inventory_warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sales_clients_addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Main = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales_clients_addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sales_clients_addresses_sales_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "sales_clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sales_clients_cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastDigits = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales_clients_cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sales_clients_cards_sales_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "sales_clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sales_clients_contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Main = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales_clients_contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sales_clients_contacts_sales_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "sales_clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sales_invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: true),
                    NcfName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ncf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NcfExpiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NcfDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreditDates = table.Column<int>(type: "int", nullable: false),
                    ClientNoIdentification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientCardNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientCardExpirationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subtotal = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    WithTax = table.Column<bool>(type: "bit", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ExcentTax = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TotalGrab = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    SaveAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    AccountAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Confirmed = table.Column<bool>(type: "bit", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TotalPayed = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Return = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated = table.Column<bool>(type: "bit", nullable: false),
                    WareHouseId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    NcfTypeId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ClientCardId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_sales_invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sales_invoices_inventory_warehouses_WareHouseId",
                        column: x => x.WareHouseId,
                        principalTable: "inventory_warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sales_invoices_sales_clients_cards_ClientCardId",
                        column: x => x.ClientCardId,
                        principalTable: "sales_clients_cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sales_invoices_sales_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "sales_clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sales_invoices_sales_invoices_types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "sales_invoices_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sales_invoices_sales_ncf_types_NcfTypeId",
                        column: x => x.NcfTypeId,
                        principalTable: "sales_ncf_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sales_invoices_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sales_invoices_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "accounts_receivable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientDocNum = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference = table.Column<int>(type: "int", nullable: false),
                    Confirmed = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_accounts_receivable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accounts_receivable_sales_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "sales_clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_accounts_receivable_sales_invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "sales_invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_accounts_receivable_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_accounts_receivable_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "globals_payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CardNumber = table.Column<int>(type: "int", nullable: true),
                    BankId = table.Column<int>(type: "int", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference = table.Column<int>(type: "int", nullable: false),
                    ReferenceId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GoodReceiptId = table.Column<int>(type: "int", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_globals_payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_globals_payments_globals_payments_banks_BankId",
                        column: x => x.BankId,
                        principalTable: "globals_payments_banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_globals_payments_globals_payments_types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "globals_payments_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_globals_payments_inventory_goods_receipt_GoodReceiptId",
                        column: x => x.GoodReceiptId,
                        principalTable: "inventory_goods_receipt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_globals_payments_sales_invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "sales_invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_globals_payments_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_globals_payments_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sales_invoices_details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Offert = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Excent = table.Column<bool>(type: "bit", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Avarage = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Comision = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    SellUnity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pending = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales_invoices_details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sales_invoices_details_inventory_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "inventory_products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sales_invoices_details_sales_invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "sales_invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "accounts_receivable_details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Sign = table.Column<int>(type: "int", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Reference = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts_receivable_details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accounts_receivable_details_accounts_receivable_AccountId",
                        column: x => x.AccountId,
                        principalTable: "accounts_receivable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inventory_products_transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductCost = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Sign = table.Column<int>(type: "int", nullable: false),
                    OldQuantity = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    OldCost = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    NewQuantity = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    NewCost = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentReferenceId = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceDetailId = table.Column<int>(type: "int", nullable: true),
                    ProductStockId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_inventory_products_transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventory_products_transactions_inventory_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "inventory_products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_products_transactions_inventory_products_stock_ProductStockId",
                        column: x => x.ProductStockId,
                        principalTable: "inventory_products_stock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_products_transactions_inventory_warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "inventory_warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_products_transactions_sales_invoices_details_InvoiceDetailId",
                        column: x => x.InvoiceDetailId,
                        principalTable: "sales_invoices_details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_products_transactions_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_products_transactions_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_payable_BranchId",
                table: "accounts_payable",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_payable_CompanyId",
                table: "accounts_payable",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_payable_SupplierId",
                table: "accounts_payable",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_payable_transactions_AccountPayableId",
                table: "accounts_payable_transactions",
                column: "AccountPayableId");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_receivable_BranchId",
                table: "accounts_receivable",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_receivable_ClientId",
                table: "accounts_receivable",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_receivable_CompanyId",
                table: "accounts_receivable",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_receivable_InvoiceId",
                table: "accounts_receivable",
                column: "InvoiceId",
                unique: true,
                filter: "[InvoiceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_receivable_details_AccountId",
                table: "accounts_receivable_details",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_globals_payments_BankId",
                table: "globals_payments",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_globals_payments_BranchId",
                table: "globals_payments",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_globals_payments_CompanyId",
                table: "globals_payments",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_globals_payments_GoodReceiptId",
                table: "globals_payments",
                column: "GoodReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_globals_payments_InvoiceId",
                table: "globals_payments",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_globals_payments_TypeId",
                table: "globals_payments",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_globals_users_BranchId",
                table: "globals_users",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_globals_users_CompanyId",
                table: "globals_users",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_brands_BranchId",
                table: "inventory_brands",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_brands_CompanyId",
                table: "inventory_brands",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_categories_BranchId",
                table: "inventory_categories",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_categories_CompanyId",
                table: "inventory_categories",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_goods_receipt_AccountId",
                table: "inventory_goods_receipt",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_goods_receipt_BranchId",
                table: "inventory_goods_receipt",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_goods_receipt_CompanyId",
                table: "inventory_goods_receipt",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_goods_receipt_NcfTypeId",
                table: "inventory_goods_receipt",
                column: "NcfTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_goods_receipt_SupplierId",
                table: "inventory_goods_receipt",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_goods_receipt_WarehouseId",
                table: "inventory_goods_receipt",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_goods_receipt_details_GoodReceiptId",
                table: "inventory_goods_receipt_details",
                column: "GoodReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_goods_receipt_details_ProductId",
                table: "inventory_goods_receipt_details",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_goods_receipt_details_WarehouseId",
                table: "inventory_goods_receipt_details",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_products_BranchId",
                table: "inventory_products",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_products_BrandId",
                table: "inventory_products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_products_CategoryId",
                table: "inventory_products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_products_CompanyId",
                table: "inventory_products",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_products_SubCategoryId",
                table: "inventory_products",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_products_images_ProductId",
                table: "inventory_products_images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_products_prices_BranchId",
                table: "inventory_products_prices",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_products_prices_CompanyId",
                table: "inventory_products_prices",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_products_prices_ProductId",
                table: "inventory_products_prices",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_products_stock_BranchId",
                table: "inventory_products_stock",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_products_stock_CompanyId",
                table: "inventory_products_stock",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_products_stock_ProductId",
                table: "inventory_products_stock",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_products_stock_WarehouseId",
                table: "inventory_products_stock",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_products_transactions_BranchId",
                table: "inventory_products_transactions",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_products_transactions_CompanyId",
                table: "inventory_products_transactions",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_products_transactions_InvoiceDetailId",
                table: "inventory_products_transactions",
                column: "InvoiceDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_products_transactions_ProductId",
                table: "inventory_products_transactions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_products_transactions_ProductStockId",
                table: "inventory_products_transactions",
                column: "ProductStockId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_products_transactions_WarehouseId",
                table: "inventory_products_transactions",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_subcategories_BranchId",
                table: "inventory_subcategories",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_subcategories_CategoryId",
                table: "inventory_subcategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_subcategories_CompanyId",
                table: "inventory_subcategories",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_suppliers_BranchId",
                table: "inventory_suppliers",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_suppliers_CompanyId",
                table: "inventory_suppliers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_suppliers_CurrencyId",
                table: "inventory_suppliers",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_suppliers_addresses_SupplierId",
                table: "inventory_suppliers_addresses",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_suppliers_contacts_SupplierId",
                table: "inventory_suppliers_contacts",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_warehouses_BranchId",
                table: "inventory_warehouses",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_warehouses_CompanyId",
                table: "inventory_warehouses",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_clients_BranchId",
                table: "sales_clients",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_clients_CompanyId",
                table: "sales_clients",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_clients_ProductId",
                table: "sales_clients",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_clients_TypeId",
                table: "sales_clients",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_clients_addresses_ClientId",
                table: "sales_clients_addresses",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_clients_cards_ClientId",
                table: "sales_clients_cards",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_clients_contacts_ClientId",
                table: "sales_clients_contacts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_invoices_BranchId",
                table: "sales_invoices",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_invoices_ClientCardId",
                table: "sales_invoices",
                column: "ClientCardId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_invoices_ClientId",
                table: "sales_invoices",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_invoices_CompanyId",
                table: "sales_invoices",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_invoices_NcfTypeId",
                table: "sales_invoices",
                column: "NcfTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_invoices_TypeId",
                table: "sales_invoices",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_invoices_WareHouseId",
                table: "sales_invoices",
                column: "WareHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_invoices_details_InvoiceId",
                table: "sales_invoices_details",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_invoices_details_ProductId",
                table: "sales_invoices_details",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_ncf_sequences_BranchId",
                table: "sales_ncf_sequences",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_ncf_sequences_CompanyId",
                table: "sales_ncf_sequences",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_ncf_sequences_NCFTypeId",
                table: "sales_ncf_sequences",
                column: "NCFTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_system_branches_CompanyId",
                table: "system_branches",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accounts_payable_transactions");

            migrationBuilder.DropTable(
                name: "accounts_receivable_details");

            migrationBuilder.DropTable(
                name: "Errors");

            migrationBuilder.DropTable(
                name: "globals_payments");

            migrationBuilder.DropTable(
                name: "globals_users");

            migrationBuilder.DropTable(
                name: "inventory_goods_receipt_details");

            migrationBuilder.DropTable(
                name: "inventory_products_images");

            migrationBuilder.DropTable(
                name: "inventory_products_prices");

            migrationBuilder.DropTable(
                name: "inventory_products_transactions");

            migrationBuilder.DropTable(
                name: "inventory_suppliers_addresses");

            migrationBuilder.DropTable(
                name: "inventory_suppliers_contacts");

            migrationBuilder.DropTable(
                name: "sales_clients_addresses");

            migrationBuilder.DropTable(
                name: "sales_clients_contacts");

            migrationBuilder.DropTable(
                name: "sales_ncf_sequences");

            migrationBuilder.DropTable(
                name: "accounts_receivable");

            migrationBuilder.DropTable(
                name: "globals_payments_banks");

            migrationBuilder.DropTable(
                name: "globals_payments_types");

            migrationBuilder.DropTable(
                name: "inventory_goods_receipt");

            migrationBuilder.DropTable(
                name: "inventory_products_stock");

            migrationBuilder.DropTable(
                name: "sales_invoices_details");

            migrationBuilder.DropTable(
                name: "accounts_payable");

            migrationBuilder.DropTable(
                name: "sales_invoices");

            migrationBuilder.DropTable(
                name: "inventory_suppliers");

            migrationBuilder.DropTable(
                name: "inventory_warehouses");

            migrationBuilder.DropTable(
                name: "sales_clients_cards");

            migrationBuilder.DropTable(
                name: "sales_invoices_types");

            migrationBuilder.DropTable(
                name: "sales_ncf_types");

            migrationBuilder.DropTable(
                name: "system_currency");

            migrationBuilder.DropTable(
                name: "sales_clients");

            migrationBuilder.DropTable(
                name: "inventory_products");

            migrationBuilder.DropTable(
                name: "sales_clients_types");

            migrationBuilder.DropTable(
                name: "inventory_brands");

            migrationBuilder.DropTable(
                name: "inventory_subcategories");

            migrationBuilder.DropTable(
                name: "inventory_categories");

            migrationBuilder.DropTable(
                name: "system_branches");

            migrationBuilder.DropTable(
                name: "system_companies");
        }
    }
}
