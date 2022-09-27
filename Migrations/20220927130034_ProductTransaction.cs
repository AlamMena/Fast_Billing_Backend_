using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class ProductTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "inventory_prodcuts_transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductCost = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Sign = table.Column<int>(type: "int", nullable: false),
                    OldQuantity = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    OldCost = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    NewQuantity = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    NewCost = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentReferenceId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_inventory_prodcuts_transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventory_prodcuts_transactions_inventory_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "inventory_products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventory_prodcuts_transactions_inventory_warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "inventory_warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventory_prodcuts_transactions_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_inventory_prodcuts_transactions_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_inventory_prodcuts_transactions_BranchId",
                table: "inventory_prodcuts_transactions",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_prodcuts_transactions_CompanyId",
                table: "inventory_prodcuts_transactions",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_prodcuts_transactions_ProductId",
                table: "inventory_prodcuts_transactions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_prodcuts_transactions_WarehouseId",
                table: "inventory_prodcuts_transactions",
                column: "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inventory_prodcuts_transactions");
        }
    }
}
