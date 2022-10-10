using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class CascadeNone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_payable_inventory_suppliers_SupplierId",
                table: "accounts_payable");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_payable_system_branches_BranchId",
                table: "accounts_payable");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_payable_system_companies_CompanyId",
                table: "accounts_payable");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_payable_transactions_accounts_payable_AccountPayableId",
                table: "accounts_payable_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_receivable_details_accounts_recivable_AccountId",
                table: "accounts_receivable_details");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_recivable_sales_clients_ClientId",
                table: "accounts_recivable");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_recivable_sales_invoices_InvoiceId",
                table: "accounts_recivable");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_recivable_system_branches_BranchId",
                table: "accounts_recivable");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_recivable_system_companies_CompanyId",
                table: "accounts_recivable");

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

            migrationBuilder.DropForeignKey(
                name: "FK_globals_payments_globals_payments_banks_BankId",
                table: "globals_payments");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_payments_globals_payments_types_TypeId",
                table: "globals_payments");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_payments_inventory_goods_receipt_GoodReceiptId",
                table: "globals_payments");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_payments_sales_invoices_InvoiceId",
                table: "globals_payments");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_payments_system_branches_BranchId",
                table: "globals_payments");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_payments_system_companies_CompanyId",
                table: "globals_payments");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_users_system_branches_BranchId",
                table: "globals_users");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_users_system_companies_CompanyId",
                table: "globals_users");

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
                name: "FK_inventory_goods_receipt_accounts_payable_AccountId",
                table: "inventory_goods_receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_goods_receipt_inventory_suppliers_SupplierId",
                table: "inventory_goods_receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_goods_receipt_sales_ncf_types_NcfTypeId",
                table: "inventory_goods_receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_goods_receipt_system_branches_BranchId",
                table: "inventory_goods_receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_goods_receipt_system_companies_CompanyId",
                table: "inventory_goods_receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_goods_receipt_details_inventory_goods_receipt_GoodReceiptId",
                table: "inventory_goods_receipt_details");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_goods_receipt_details_inventory_products_ProductId",
                table: "inventory_goods_receipt_details");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_goods_receipt_details_inventory_warehouses_WarehouseId",
                table: "inventory_goods_receipt_details");

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
                name: "FK_inventory_products_prices_inventory_products_ProductId",
                table: "inventory_products_prices");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_prices_system_branches_BranchId",
                table: "inventory_products_prices");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_prices_system_companies_CompanyId",
                table: "inventory_products_prices");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_stock_inventory_products_ProductId",
                table: "inventory_products_stock");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_stock_inventory_warehouses_WarehouseId",
                table: "inventory_products_stock");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_stock_system_branches_BranchId",
                table: "inventory_products_stock");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_stock_system_companies_CompanyId",
                table: "inventory_products_stock");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_transactions_inventory_products_ProductId",
                table: "inventory_products_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_transactions_inventory_warehouses_WarehouseId",
                table: "inventory_products_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_transactions_sales_invoices_details_InvoiceDetailId",
                table: "inventory_products_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_transactions_system_branches_BranchId",
                table: "inventory_products_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_transactions_system_companies_CompanyId",
                table: "inventory_products_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_subcategories_inventory_categories_CategoryId",
                table: "inventory_subcategories");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_subcategories_system_branches_BranchId",
                table: "inventory_subcategories");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_subcategories_system_companies_CompanyId",
                table: "inventory_subcategories");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_suppliers_system_branches_BranchId",
                table: "inventory_suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_suppliers_system_companies_CompanyId",
                table: "inventory_suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_suppliers_system_currency_CurrencyId",
                table: "inventory_suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_warehouses_system_branches_BranchId",
                table: "inventory_warehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_warehouses_system_companies_CompanyId",
                table: "inventory_warehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_clients_inventory_products_ProductId",
                table: "sales_clients");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_clients_sales_clients_types_TypeId",
                table: "sales_clients");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_clients_system_branches_BranchId",
                table: "sales_clients");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_clients_system_companies_CompanyId",
                table: "sales_clients");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_clients_cards_sales_clients_ClientId",
                table: "sales_clients_cards");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_invoices_inventory_warehouses_WareHouseId",
                table: "sales_invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_invoices_sales_clients_cards_ClientCardId",
                table: "sales_invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_invoices_sales_clients_ClientId",
                table: "sales_invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_invoices_sales_invoices_types_TypeId",
                table: "sales_invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_invoices_sales_ncf_types_NcfTypeId",
                table: "sales_invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_invoices_system_branches_BranchId",
                table: "sales_invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_invoices_system_companies_CompanyId",
                table: "sales_invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_invoices_details_inventory_products_ProductId",
                table: "sales_invoices_details");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_invoices_details_sales_invoices_InvoiceId",
                table: "sales_invoices_details");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_ncf_sequences_sales_ncf_types_NCFTypeId",
                table: "sales_ncf_sequences");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_ncf_sequences_system_branches_BranchId",
                table: "sales_ncf_sequences");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_ncf_sequences_system_companies_CompanyId",
                table: "sales_ncf_sequences");

            migrationBuilder.DropForeignKey(
                name: "FK_system_branches_system_companies_CompanyId",
                table: "system_branches");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_payable_inventory_suppliers_SupplierId",
                table: "accounts_payable",
                column: "SupplierId",
                principalTable: "inventory_suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_payable_system_branches_BranchId",
                table: "accounts_payable",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_payable_system_companies_CompanyId",
                table: "accounts_payable",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_payable_transactions_accounts_payable_AccountPayableId",
                table: "accounts_payable_transactions",
                column: "AccountPayableId",
                principalTable: "accounts_payable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_receivable_details_accounts_recivable_AccountId",
                table: "accounts_receivable_details",
                column: "AccountId",
                principalTable: "accounts_recivable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_recivable_sales_clients_ClientId",
                table: "accounts_recivable",
                column: "ClientId",
                principalTable: "sales_clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_recivable_sales_invoices_InvoiceId",
                table: "accounts_recivable",
                column: "InvoiceId",
                principalTable: "sales_invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_recivable_system_branches_BranchId",
                table: "accounts_recivable",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_recivable_system_companies_CompanyId",
                table: "accounts_recivable",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_globals_payments_globals_payments_banks_BankId",
                table: "globals_payments",
                column: "BankId",
                principalTable: "globals_payments_banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_globals_payments_globals_payments_types_TypeId",
                table: "globals_payments",
                column: "TypeId",
                principalTable: "globals_payments_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_globals_payments_inventory_goods_receipt_GoodReceiptId",
                table: "globals_payments",
                column: "GoodReceiptId",
                principalTable: "inventory_goods_receipt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_globals_payments_sales_invoices_InvoiceId",
                table: "globals_payments",
                column: "InvoiceId",
                principalTable: "sales_invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_globals_payments_system_branches_BranchId",
                table: "globals_payments",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_globals_payments_system_companies_CompanyId",
                table: "globals_payments",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_globals_users_system_branches_BranchId",
                table: "globals_users",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_globals_users_system_companies_CompanyId",
                table: "globals_users",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_brands_system_branches_BranchId",
                table: "inventory_brands",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_brands_system_companies_CompanyId",
                table: "inventory_brands",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_categories_system_branches_BranchId",
                table: "inventory_categories",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_categories_system_companies_CompanyId",
                table: "inventory_categories",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_goods_receipt_accounts_payable_AccountId",
                table: "inventory_goods_receipt",
                column: "AccountId",
                principalTable: "accounts_payable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_goods_receipt_inventory_suppliers_SupplierId",
                table: "inventory_goods_receipt",
                column: "SupplierId",
                principalTable: "inventory_suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_goods_receipt_sales_ncf_types_NcfTypeId",
                table: "inventory_goods_receipt",
                column: "NcfTypeId",
                principalTable: "sales_ncf_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_goods_receipt_system_branches_BranchId",
                table: "inventory_goods_receipt",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_goods_receipt_system_companies_CompanyId",
                table: "inventory_goods_receipt",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_goods_receipt_details_inventory_goods_receipt_GoodReceiptId",
                table: "inventory_goods_receipt_details",
                column: "GoodReceiptId",
                principalTable: "inventory_goods_receipt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_goods_receipt_details_inventory_products_ProductId",
                table: "inventory_goods_receipt_details",
                column: "ProductId",
                principalTable: "inventory_products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_goods_receipt_details_inventory_warehouses_WarehouseId",
                table: "inventory_goods_receipt_details",
                column: "WarehouseId",
                principalTable: "inventory_warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_inventory_brands_BrandId",
                table: "inventory_products",
                column: "BrandId",
                principalTable: "inventory_brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_inventory_categories_CategoryId",
                table: "inventory_products",
                column: "CategoryId",
                principalTable: "inventory_categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_inventory_subcategories_SubCategoryId",
                table: "inventory_products",
                column: "SubCategoryId",
                principalTable: "inventory_subcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_system_branches_BranchId",
                table: "inventory_products",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_system_companies_CompanyId",
                table: "inventory_products",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_images_inventory_products_ProductId",
                table: "inventory_products_images",
                column: "ProductId",
                principalTable: "inventory_products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_prices_inventory_products_ProductId",
                table: "inventory_products_prices",
                column: "ProductId",
                principalTable: "inventory_products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_prices_system_branches_BranchId",
                table: "inventory_products_prices",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_prices_system_companies_CompanyId",
                table: "inventory_products_prices",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_stock_inventory_products_ProductId",
                table: "inventory_products_stock",
                column: "ProductId",
                principalTable: "inventory_products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_stock_inventory_warehouses_WarehouseId",
                table: "inventory_products_stock",
                column: "WarehouseId",
                principalTable: "inventory_warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_stock_system_branches_BranchId",
                table: "inventory_products_stock",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_stock_system_companies_CompanyId",
                table: "inventory_products_stock",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_transactions_inventory_products_ProductId",
                table: "inventory_products_transactions",
                column: "ProductId",
                principalTable: "inventory_products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_transactions_inventory_warehouses_WarehouseId",
                table: "inventory_products_transactions",
                column: "WarehouseId",
                principalTable: "inventory_warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_transactions_sales_invoices_details_InvoiceDetailId",
                table: "inventory_products_transactions",
                column: "InvoiceDetailId",
                principalTable: "sales_invoices_details",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_transactions_system_branches_BranchId",
                table: "inventory_products_transactions",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_transactions_system_companies_CompanyId",
                table: "inventory_products_transactions",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_subcategories_inventory_categories_CategoryId",
                table: "inventory_subcategories",
                column: "CategoryId",
                principalTable: "inventory_categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_subcategories_system_branches_BranchId",
                table: "inventory_subcategories",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_subcategories_system_companies_CompanyId",
                table: "inventory_subcategories",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_suppliers_system_branches_BranchId",
                table: "inventory_suppliers",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_suppliers_system_companies_CompanyId",
                table: "inventory_suppliers",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_suppliers_system_currency_CurrencyId",
                table: "inventory_suppliers",
                column: "CurrencyId",
                principalTable: "system_currency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_warehouses_system_branches_BranchId",
                table: "inventory_warehouses",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_warehouses_system_companies_CompanyId",
                table: "inventory_warehouses",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_clients_inventory_products_ProductId",
                table: "sales_clients",
                column: "ProductId",
                principalTable: "inventory_products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_clients_sales_clients_types_TypeId",
                table: "sales_clients",
                column: "TypeId",
                principalTable: "sales_clients_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_clients_system_branches_BranchId",
                table: "sales_clients",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_clients_system_companies_CompanyId",
                table: "sales_clients",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_clients_cards_sales_clients_ClientId",
                table: "sales_clients_cards",
                column: "ClientId",
                principalTable: "sales_clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_invoices_inventory_warehouses_WareHouseId",
                table: "sales_invoices",
                column: "WareHouseId",
                principalTable: "inventory_warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_invoices_sales_clients_cards_ClientCardId",
                table: "sales_invoices",
                column: "ClientCardId",
                principalTable: "sales_clients_cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_invoices_sales_clients_ClientId",
                table: "sales_invoices",
                column: "ClientId",
                principalTable: "sales_clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_invoices_sales_invoices_types_TypeId",
                table: "sales_invoices",
                column: "TypeId",
                principalTable: "sales_invoices_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_invoices_sales_ncf_types_NcfTypeId",
                table: "sales_invoices",
                column: "NcfTypeId",
                principalTable: "sales_ncf_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_invoices_system_branches_BranchId",
                table: "sales_invoices",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_invoices_system_companies_CompanyId",
                table: "sales_invoices",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_invoices_details_inventory_products_ProductId",
                table: "sales_invoices_details",
                column: "ProductId",
                principalTable: "inventory_products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_invoices_details_sales_invoices_InvoiceId",
                table: "sales_invoices_details",
                column: "InvoiceId",
                principalTable: "sales_invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_ncf_sequences_sales_ncf_types_NCFTypeId",
                table: "sales_ncf_sequences",
                column: "NCFTypeId",
                principalTable: "sales_ncf_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_ncf_sequences_system_branches_BranchId",
                table: "sales_ncf_sequences",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_ncf_sequences_system_companies_CompanyId",
                table: "sales_ncf_sequences",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_system_branches_system_companies_CompanyId",
                table: "system_branches",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_payable_inventory_suppliers_SupplierId",
                table: "accounts_payable");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_payable_system_branches_BranchId",
                table: "accounts_payable");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_payable_system_companies_CompanyId",
                table: "accounts_payable");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_payable_transactions_accounts_payable_AccountPayableId",
                table: "accounts_payable_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_receivable_details_accounts_recivable_AccountId",
                table: "accounts_receivable_details");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_recivable_sales_clients_ClientId",
                table: "accounts_recivable");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_recivable_sales_invoices_InvoiceId",
                table: "accounts_recivable");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_recivable_system_branches_BranchId",
                table: "accounts_recivable");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_recivable_system_companies_CompanyId",
                table: "accounts_recivable");

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

            migrationBuilder.DropForeignKey(
                name: "FK_globals_payments_globals_payments_banks_BankId",
                table: "globals_payments");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_payments_globals_payments_types_TypeId",
                table: "globals_payments");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_payments_inventory_goods_receipt_GoodReceiptId",
                table: "globals_payments");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_payments_sales_invoices_InvoiceId",
                table: "globals_payments");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_payments_system_branches_BranchId",
                table: "globals_payments");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_payments_system_companies_CompanyId",
                table: "globals_payments");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_users_system_branches_BranchId",
                table: "globals_users");

            migrationBuilder.DropForeignKey(
                name: "FK_globals_users_system_companies_CompanyId",
                table: "globals_users");

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
                name: "FK_inventory_goods_receipt_accounts_payable_AccountId",
                table: "inventory_goods_receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_goods_receipt_inventory_suppliers_SupplierId",
                table: "inventory_goods_receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_goods_receipt_sales_ncf_types_NcfTypeId",
                table: "inventory_goods_receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_goods_receipt_system_branches_BranchId",
                table: "inventory_goods_receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_goods_receipt_system_companies_CompanyId",
                table: "inventory_goods_receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_goods_receipt_details_inventory_goods_receipt_GoodReceiptId",
                table: "inventory_goods_receipt_details");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_goods_receipt_details_inventory_products_ProductId",
                table: "inventory_goods_receipt_details");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_goods_receipt_details_inventory_warehouses_WarehouseId",
                table: "inventory_goods_receipt_details");

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
                name: "FK_inventory_products_prices_inventory_products_ProductId",
                table: "inventory_products_prices");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_prices_system_branches_BranchId",
                table: "inventory_products_prices");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_prices_system_companies_CompanyId",
                table: "inventory_products_prices");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_stock_inventory_products_ProductId",
                table: "inventory_products_stock");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_stock_inventory_warehouses_WarehouseId",
                table: "inventory_products_stock");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_stock_system_branches_BranchId",
                table: "inventory_products_stock");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_stock_system_companies_CompanyId",
                table: "inventory_products_stock");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_transactions_inventory_products_ProductId",
                table: "inventory_products_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_transactions_inventory_warehouses_WarehouseId",
                table: "inventory_products_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_transactions_sales_invoices_details_InvoiceDetailId",
                table: "inventory_products_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_transactions_system_branches_BranchId",
                table: "inventory_products_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_products_transactions_system_companies_CompanyId",
                table: "inventory_products_transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_subcategories_inventory_categories_CategoryId",
                table: "inventory_subcategories");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_subcategories_system_branches_BranchId",
                table: "inventory_subcategories");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_subcategories_system_companies_CompanyId",
                table: "inventory_subcategories");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_suppliers_system_branches_BranchId",
                table: "inventory_suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_suppliers_system_companies_CompanyId",
                table: "inventory_suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_suppliers_system_currency_CurrencyId",
                table: "inventory_suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_warehouses_system_branches_BranchId",
                table: "inventory_warehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_inventory_warehouses_system_companies_CompanyId",
                table: "inventory_warehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_clients_inventory_products_ProductId",
                table: "sales_clients");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_clients_sales_clients_types_TypeId",
                table: "sales_clients");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_clients_system_branches_BranchId",
                table: "sales_clients");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_clients_system_companies_CompanyId",
                table: "sales_clients");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_clients_cards_sales_clients_ClientId",
                table: "sales_clients_cards");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_invoices_inventory_warehouses_WareHouseId",
                table: "sales_invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_invoices_sales_clients_cards_ClientCardId",
                table: "sales_invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_invoices_sales_clients_ClientId",
                table: "sales_invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_invoices_sales_invoices_types_TypeId",
                table: "sales_invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_invoices_sales_ncf_types_NcfTypeId",
                table: "sales_invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_invoices_system_branches_BranchId",
                table: "sales_invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_invoices_system_companies_CompanyId",
                table: "sales_invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_invoices_details_inventory_products_ProductId",
                table: "sales_invoices_details");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_invoices_details_sales_invoices_InvoiceId",
                table: "sales_invoices_details");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_ncf_sequences_sales_ncf_types_NCFTypeId",
                table: "sales_ncf_sequences");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_ncf_sequences_system_branches_BranchId",
                table: "sales_ncf_sequences");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_ncf_sequences_system_companies_CompanyId",
                table: "sales_ncf_sequences");

            migrationBuilder.DropForeignKey(
                name: "FK_system_branches_system_companies_CompanyId",
                table: "system_branches");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_payable_inventory_suppliers_SupplierId",
                table: "accounts_payable",
                column: "SupplierId",
                principalTable: "inventory_suppliers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_payable_system_branches_BranchId",
                table: "accounts_payable",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_payable_system_companies_CompanyId",
                table: "accounts_payable",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_payable_transactions_accounts_payable_AccountPayableId",
                table: "accounts_payable_transactions",
                column: "AccountPayableId",
                principalTable: "accounts_payable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_receivable_details_accounts_recivable_AccountId",
                table: "accounts_receivable_details",
                column: "AccountId",
                principalTable: "accounts_recivable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_recivable_sales_clients_ClientId",
                table: "accounts_recivable",
                column: "ClientId",
                principalTable: "sales_clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_recivable_sales_invoices_InvoiceId",
                table: "accounts_recivable",
                column: "InvoiceId",
                principalTable: "sales_invoices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_recivable_system_branches_BranchId",
                table: "accounts_recivable",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_recivable_system_companies_CompanyId",
                table: "accounts_recivable",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_globals_addresses_inventory_suppliers_SupplierId",
                table: "globals_addresses",
                column: "SupplierId",
                principalTable: "inventory_suppliers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_globals_addresses_sales_clients_ClientId",
                table: "globals_addresses",
                column: "ClientId",
                principalTable: "sales_clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_globals_contacts_inventory_suppliers_SupplierId",
                table: "globals_contacts",
                column: "SupplierId",
                principalTable: "inventory_suppliers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_globals_contacts_sales_clients_ClientId",
                table: "globals_contacts",
                column: "ClientId",
                principalTable: "sales_clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_globals_payments_globals_payments_banks_BankId",
                table: "globals_payments",
                column: "BankId",
                principalTable: "globals_payments_banks",
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
                name: "FK_globals_payments_sales_invoices_InvoiceId",
                table: "globals_payments",
                column: "InvoiceId",
                principalTable: "sales_invoices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_globals_payments_system_branches_BranchId",
                table: "globals_payments",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_globals_payments_system_companies_CompanyId",
                table: "globals_payments",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id");

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
                name: "FK_inventory_goods_receipt_accounts_payable_AccountId",
                table: "inventory_goods_receipt",
                column: "AccountId",
                principalTable: "accounts_payable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_goods_receipt_inventory_suppliers_SupplierId",
                table: "inventory_goods_receipt",
                column: "SupplierId",
                principalTable: "inventory_suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_goods_receipt_sales_ncf_types_NcfTypeId",
                table: "inventory_goods_receipt",
                column: "NcfTypeId",
                principalTable: "sales_ncf_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_goods_receipt_system_branches_BranchId",
                table: "inventory_goods_receipt",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_goods_receipt_system_companies_CompanyId",
                table: "inventory_goods_receipt",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_goods_receipt_details_inventory_goods_receipt_GoodReceiptId",
                table: "inventory_goods_receipt_details",
                column: "GoodReceiptId",
                principalTable: "inventory_goods_receipt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_goods_receipt_details_inventory_products_ProductId",
                table: "inventory_goods_receipt_details",
                column: "ProductId",
                principalTable: "inventory_products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_goods_receipt_details_inventory_warehouses_WarehouseId",
                table: "inventory_goods_receipt_details",
                column: "WarehouseId",
                principalTable: "inventory_warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_stock_inventory_products_ProductId",
                table: "inventory_products_stock",
                column: "ProductId",
                principalTable: "inventory_products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_stock_inventory_warehouses_WarehouseId",
                table: "inventory_products_stock",
                column: "WarehouseId",
                principalTable: "inventory_warehouses",
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
                name: "FK_inventory_products_transactions_inventory_products_ProductId",
                table: "inventory_products_transactions",
                column: "ProductId",
                principalTable: "inventory_products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_transactions_inventory_warehouses_WarehouseId",
                table: "inventory_products_transactions",
                column: "WarehouseId",
                principalTable: "inventory_warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_transactions_sales_invoices_details_InvoiceDetailId",
                table: "inventory_products_transactions",
                column: "InvoiceDetailId",
                principalTable: "sales_invoices_details",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_transactions_system_branches_BranchId",
                table: "inventory_products_transactions",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_products_transactions_system_companies_CompanyId",
                table: "inventory_products_transactions",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_subcategories_inventory_categories_CategoryId",
                table: "inventory_subcategories",
                column: "CategoryId",
                principalTable: "inventory_categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_warehouses_system_branches_BranchId",
                table: "inventory_warehouses",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_warehouses_system_companies_CompanyId",
                table: "inventory_warehouses",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sales_clients_inventory_products_ProductId",
                table: "sales_clients",
                column: "ProductId",
                principalTable: "inventory_products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sales_clients_sales_clients_types_TypeId",
                table: "sales_clients",
                column: "TypeId",
                principalTable: "sales_clients_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_clients_system_branches_BranchId",
                table: "sales_clients",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sales_clients_system_companies_CompanyId",
                table: "sales_clients",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sales_clients_cards_sales_clients_ClientId",
                table: "sales_clients_cards",
                column: "ClientId",
                principalTable: "sales_clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_invoices_inventory_warehouses_WareHouseId",
                table: "sales_invoices",
                column: "WareHouseId",
                principalTable: "inventory_warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_invoices_sales_clients_cards_ClientCardId",
                table: "sales_invoices",
                column: "ClientCardId",
                principalTable: "sales_clients_cards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sales_invoices_sales_clients_ClientId",
                table: "sales_invoices",
                column: "ClientId",
                principalTable: "sales_clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_invoices_sales_invoices_types_TypeId",
                table: "sales_invoices",
                column: "TypeId",
                principalTable: "sales_invoices_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_invoices_sales_ncf_types_NcfTypeId",
                table: "sales_invoices",
                column: "NcfTypeId",
                principalTable: "sales_ncf_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_invoices_system_branches_BranchId",
                table: "sales_invoices",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sales_invoices_system_companies_CompanyId",
                table: "sales_invoices",
                column: "CompanyId",
                principalTable: "system_companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sales_invoices_details_inventory_products_ProductId",
                table: "sales_invoices_details",
                column: "ProductId",
                principalTable: "inventory_products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_invoices_details_sales_invoices_InvoiceId",
                table: "sales_invoices_details",
                column: "InvoiceId",
                principalTable: "sales_invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_ncf_sequences_sales_ncf_types_NCFTypeId",
                table: "sales_ncf_sequences",
                column: "NCFTypeId",
                principalTable: "sales_ncf_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_ncf_sequences_system_branches_BranchId",
                table: "sales_ncf_sequences",
                column: "BranchId",
                principalTable: "system_branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sales_ncf_sequences_system_companies_CompanyId",
                table: "sales_ncf_sequences",
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
    }
}
