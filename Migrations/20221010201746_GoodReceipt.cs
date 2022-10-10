using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class GoodReceipt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_payable_inventory_supplier_SupplierId",
                table: "accounts_payable");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_payable_sales_ncf_types_NcfTypeId",
                table: "accounts_payable");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_payments_globals_payments_types_PaymentTypeId",
                table: "globals_payments");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_supplier_system_branches_BranchId",
                table: "inventory_supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_supplier_system_companies_CompanyId",
                table: "inventory_supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_supplier_system_currency_CurrencyId",
                table: "inventory_supplier");

            migrationBuilder.DropTable(
                name: "sales_clients_addresses");

            migrationBuilder.DropTable(
                name: "sales_clients_contacts");

            migrationBuilder.DropIndex(
                name: "IX_accounts_payable_NcfTypeId",
                table: "accounts_payable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventory_supplier",
                table: "inventory_supplier");

            migrationBuilder.DropColumn(
                name: "NcfTypeId",
                table: "accounts_payable");

            migrationBuilder.RenameTable(
                name: "inventory_supplier",
                newName: "inventory_suppliers");

            migrationBuilder.RenameColumn(
                name: "PaymentTypeId",
                table: "globals_payments",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_globals_payments_PaymentTypeId",
                table: "globals_payments",
                newName: "IX_globals_payments_TypeId");

            migrationBuilder.RenameColumn(
                name: "Dias",
                table: "inventory_suppliers",
                newName: "DaysToPay");

            migrationBuilder.RenameColumn(
                name: "Descuento",
                table: "inventory_suppliers",
                newName: "Discount");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "inventory_suppliers",
                newName: "Email");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_supplier_CurrencyId",
                table: "inventory_suppliers",
                newName: "IX_inventory_suppliers_CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_supplier_CompanyId",
                table: "inventory_suppliers",
                newName: "IX_inventory_suppliers_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_supplier_BranchId",
                table: "inventory_suppliers",
                newName: "IX_inventory_suppliers_BranchId");

            migrationBuilder.AddColumn<int>(
                name: "GoodReceiptId",
                table: "globals_payments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "accounts_payable",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Document",
                table: "accounts_payable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Descripction",
                table: "inventory_suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventory_suppliers",
                table: "inventory_suppliers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "globals_addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Main = table.Column<bool>(type: "bit", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_globals_addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_globals_addresses_inventory_suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "inventory_suppliers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_globals_addresses_sales_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "sales_clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "globals_contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Main = table.Column<bool>(type: "bit", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_globals_contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_globals_contacts_inventory_suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "inventory_suppliers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_globals_contacts_sales_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "sales_clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "inventory_goods_receipt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventory_goods_receipt_inventory_suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "inventory_suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventory_goods_receipt_sales_ncf_types_NcfTypeId",
                        column: x => x.NcfTypeId,
                        principalTable: "sales_ncf_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventory_goods_receipt_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_inventory_goods_receipt_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id");
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventory_goods_receipt_details_inventory_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "inventory_products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventory_goods_receipt_details_inventory_warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "inventory_warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_globals_payments_GoodReceiptId",
                table: "globals_payments",
                column: "GoodReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_globals_addresses_ClientId",
                table: "globals_addresses",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_globals_addresses_SupplierId",
                table: "globals_addresses",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_globals_contacts_ClientId",
                table: "globals_contacts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_globals_contacts_SupplierId",
                table: "globals_contacts",
                column: "SupplierId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_payable_inventory_suppliers_SupplierId",
                table: "accounts_payable",
                column: "SupplierId",
                principalTable: "inventory_suppliers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_globals_payments_globals_payments_types_TypeId",
                table: "globals_payments",
                column: "TypeId",
                principalTable: "globals_payments_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_globals_payments_inventory_goods_receipt_GoodReceiptId",
                table: "globals_payments",
                column: "GoodReceiptId",
                principalTable: "inventory_goods_receipt",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_suppliers_system_branches_BranchId",
                table: "inventory_suppliers",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_suppliers_system_companies_CompanyId",
                table: "inventory_suppliers",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_suppliers_system_currency_CurrencyId",
                table: "inventory_suppliers",
                column: "CurrencyId",
                principalTable: "system_currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_payable_inventory_suppliers_SupplierId",
                table: "accounts_payable");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_payments_globals_payments_types_TypeId",
                table: "globals_payments");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_payments_inventory_goods_receipt_GoodReceiptId",
                table: "globals_payments");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_suppliers_system_branches_BranchId",
                table: "inventory_suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_suppliers_system_companies_CompanyId",
                table: "inventory_suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_suppliers_system_currency_CurrencyId",
                table: "inventory_suppliers");

            migrationBuilder.DropTable(
                name: "globals_addresses");

            migrationBuilder.DropTable(
                name: "globals_contacts");

            migrationBuilder.DropTable(
                name: "inventory_goods_receipt_details");

            migrationBuilder.DropTable(
                name: "inventory_goods_receipt");

            migrationBuilder.DropIndex(
                name: "IX_globals_payments_GoodReceiptId",
                table: "globals_payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inventory_suppliers",
                table: "inventory_suppliers");

            migrationBuilder.DropColumn(
                name: "GoodReceiptId",
                table: "globals_payments");

            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "accounts_payable");

            migrationBuilder.DropColumn(
                name: "Document",
                table: "accounts_payable");

            migrationBuilder.DropColumn(
                name: "Descripction",
                table: "inventory_suppliers");

            migrationBuilder.RenameTable(
                name: "inventory_suppliers",
                newName: "inventory_supplier");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "globals_payments",
                newName: "PaymentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_globals_payments_TypeId",
                table: "globals_payments",
                newName: "IX_globals_payments_PaymentTypeId");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "inventory_supplier",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "inventory_supplier",
                newName: "Descuento");

            migrationBuilder.RenameColumn(
                name: "DaysToPay",
                table: "inventory_supplier",
                newName: "Dias");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_suppliers_CurrencyId",
                table: "inventory_supplier",
                newName: "IX_inventory_supplier_CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_suppliers_CompanyId",
                table: "inventory_supplier",
                newName: "IX_inventory_supplier_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_inventory_suppliers_BranchId",
                table: "inventory_supplier",
                newName: "IX_inventory_supplier_BranchId");

            migrationBuilder.AddColumn<int>(
                name: "NcfTypeId",
                table: "accounts_payable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_inventory_supplier",
                table: "inventory_supplier",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "sales_clients_addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_sales_clients_addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sales_clients_addresses_sales_clients_ClientId",
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
                    ClientId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_sales_clients_contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sales_clients_contacts_sales_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "sales_clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_payable_NcfTypeId",
                table: "accounts_payable",
                column: "NcfTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_clients_addresses_ClientId",
                table: "sales_clients_addresses",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_sales_clients_contacts_ClientId",
                table: "sales_clients_contacts",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_payable_inventory_supplier_SupplierId",
                table: "accounts_payable",
                column: "SupplierId",
                principalTable: "inventory_supplier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_payable_sales_ncf_types_NcfTypeId",
                table: "accounts_payable",
                column: "NcfTypeId",
                principalTable: "sales_ncf_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_globals_payments_globals_payments_types_PaymentTypeId",
                table: "globals_payments",
                column: "PaymentTypeId",
                principalTable: "globals_payments_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_supplier_system_branches_BranchId",
                table: "inventory_supplier",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_supplier_system_companies_CompanyId",
                table: "inventory_supplier",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_supplier_system_currency_CurrencyId",
                table: "inventory_supplier",
                column: "CurrencyId",
                principalTable: "system_currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
