using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class InvoiceEntitities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "global_contacts_addresses");

            migrationBuilder.DropTable(
                name: "global_contacts_cards");

            migrationBuilder.DropTable(
                name: "global_contacts_phone_numbers");

            migrationBuilder.DropTable(
                name: "global_contacts");

            migrationBuilder.DropTable(
                name: "global_contacts_types");

            migrationBuilder.CreateTable(
                name: "NcfTypes",
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
                    table.PrimaryKey("PK_NcfTypes", x => x.Id);
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
                name: "system_currency",
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
                    table.PrimaryKey("PK_system_currency", x => x.Id);
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
                    CreditLimit = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    CreditDays = table.Column<int>(type: "int", nullable: false),
                    AllowDisccount = table.Column<bool>(type: "bit", nullable: false),
                    Disccount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_sales_clients_sales_clients_types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "sales_clients_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sales_clients_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_sales_clients_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "inventory_supplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoIdentification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Dias = table.Column<int>(type: "int", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    NCFTipoId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_inventory_supplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventory_supplier_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_inventory_supplier_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_inventory_supplier_system_currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "system_currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "accounts_recivable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientDocNum = table.Column<int>(type: "int", nullable: true),
                    InitialDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference = table.Column<int>(type: "int", nullable: false),
                    ReferenceId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_accounts_recivable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accounts_recivable_sales_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "sales_clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_accounts_recivable_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_accounts_recivable_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "sales_clients_addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Main = table.Column<bool>(type: "bit", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales_clients_addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sales_clients_addresses_sales_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "sales_clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sales_clients_contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales_clients_contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sales_clients_contacts_sales_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "sales_clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "accounts_payable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NcfTypeId = table.Column<int>(type: "int", nullable: false),
                    Ncf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reference = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierReceipt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierNoIdentification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierDocNum = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    DisccountAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
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
                        name: "FK_accounts_payable_inventory_supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "inventory_supplier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_accounts_payable_NcfTypes_NcfTypeId",
                        column: x => x.NcfTypeId,
                        principalTable: "NcfTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_accounts_payable_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_accounts_payable_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "accounts_receivable_details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Sign = table.Column<int>(type: "int", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccounReceivabletId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Reference = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_accounts_receivable_details_accounts_recivable_AccountId",
                        column: x => x.AccountId,
                        principalTable: "accounts_recivable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sales_invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceTypeId = table.Column<int>(type: "int", nullable: false),
                    InvoiceTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: true),
                    NcfTypeId = table.Column<int>(type: "int", nullable: false),
                    NcfName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ncf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NcfExpiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NcfDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreditDates = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ClientNoIdentification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientCardId = table.Column<int>(type: "int", nullable: true),
                    ClientCardNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientCardExpirationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subtotal = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    WithTax = table.Column<bool>(type: "bit", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ExcentTax = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TotalGrab = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    SaveAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    AccountAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Disccount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Confirmed = table.Column<bool>(type: "bit", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TotalPayed = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Return = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated = table.Column<bool>(type: "bit", nullable: false),
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
                        name: "FK_sales_invoices_NcfTypes_NcfTypeId",
                        column: x => x.NcfTypeId,
                        principalTable: "NcfTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sales_invoices_sales_clients_cards_ClientCardId",
                        column: x => x.ClientCardId,
                        principalTable: "sales_clients_cards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_sales_invoices_sales_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "sales_clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sales_invoices_sales_invoices_types_InvoiceTypeId",
                        column: x => x.InvoiceTypeId,
                        principalTable: "sales_invoices_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sales_invoices_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_sales_invoices_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "accounts_payable_transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisccountAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Sign = table.Column<int>(type: "int", nullable: false),
                    AccountPayableId = table.Column<int>(type: "int", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefNo = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts_payable_transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accounts_payable_transactions_accounts_payable_AccountPayableId",
                        column: x => x.AccountPayableId,
                        principalTable: "accounts_payable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Quantity = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Offert = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Excent = table.Column<bool>(type: "bit", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Avarage = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Disccount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    DisscountAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Comision = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sales_invoices_details_sales_invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "sales_invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_accounts_payable_NcfTypeId",
                table: "accounts_payable",
                column: "NcfTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_payable_SupplierId",
                table: "accounts_payable",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_payable_transactions_AccountPayableId",
                table: "accounts_payable_transactions",
                column: "AccountPayableId");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_receivable_details_AccountId",
                table: "accounts_receivable_details",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_recivable_BranchId",
                table: "accounts_recivable",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_recivable_ClientId",
                table: "accounts_recivable",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_recivable_CompanyId",
                table: "accounts_recivable",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_supplier_BranchId",
                table: "inventory_supplier",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_supplier_CompanyId",
                table: "inventory_supplier",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_supplier_CurrencyId",
                table: "inventory_supplier",
                column: "CurrencyId");

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
                name: "IX_sales_invoices_InvoiceTypeId",
                table: "sales_invoices",
                column: "InvoiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_invoices_NcfTypeId",
                table: "sales_invoices",
                column: "NcfTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_invoices_details_InvoiceId",
                table: "sales_invoices_details",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_invoices_details_ProductId",
                table: "sales_invoices_details",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accounts_payable_transactions");

            migrationBuilder.DropTable(
                name: "accounts_receivable_details");

            migrationBuilder.DropTable(
                name: "sales_clients_addresses");

            migrationBuilder.DropTable(
                name: "sales_clients_contacts");

            migrationBuilder.DropTable(
                name: "sales_invoices_details");

            migrationBuilder.DropTable(
                name: "accounts_payable");

            migrationBuilder.DropTable(
                name: "accounts_recivable");

            migrationBuilder.DropTable(
                name: "sales_invoices");

            migrationBuilder.DropTable(
                name: "inventory_supplier");

            migrationBuilder.DropTable(
                name: "NcfTypes");

            migrationBuilder.DropTable(
                name: "sales_clients_cards");

            migrationBuilder.DropTable(
                name: "sales_invoices_types");

            migrationBuilder.DropTable(
                name: "system_currency");

            migrationBuilder.DropTable(
                name: "sales_clients");

            migrationBuilder.DropTable(
                name: "sales_clients_types");

            migrationBuilder.CreateTable(
                name: "global_contacts_types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_global_contacts_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "global_contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    AllowCredit = table.Column<bool>(type: "bit", nullable: false),
                    AllowDisccount = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreditDays = table.Column<int>(type: "int", nullable: false),
                    CreditLimit = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Disccount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    DocNum = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_global_contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_global_contacts_global_contacts_types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "global_contacts_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_global_contacts_inventory_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "inventory_products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_global_contacts_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_global_contacts_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "global_contacts_addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Main = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_global_contacts_addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_global_contacts_addresses_global_contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "global_contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "global_contacts_cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    CardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastDigits = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_global_contacts_cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_global_contacts_cards_global_contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "global_contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "global_contacts_phone_numbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_global_contacts_phone_numbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_global_contacts_phone_numbers_global_contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "global_contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_global_contacts_BranchId",
                table: "global_contacts",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_global_contacts_CompanyId",
                table: "global_contacts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_global_contacts_ProductId",
                table: "global_contacts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_global_contacts_TypeId",
                table: "global_contacts",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_global_contacts_addresses_ContactId",
                table: "global_contacts_addresses",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_global_contacts_cards_ContactId",
                table: "global_contacts_cards",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_global_contacts_phone_numbers_ContactId",
                table: "global_contacts_phone_numbers",
                column: "ContactId");
        }
    }
}
