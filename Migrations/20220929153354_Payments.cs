using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class Payments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccounReceivabletId",
                table: "accounts_receivable_details",
                newName: "AccounReceivableId");

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
                name: "globals_payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CardNumber = table.Column<int>(type: "int", nullable: true),
                    BankId = table.Column<int>(type: "int", nullable: true),
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference = table.Column<int>(type: "int", nullable: false),
                    ReferenceId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_globals_payments_globals_payments_types_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "globals_payments_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_globals_payments_sales_invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "sales_invoices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_globals_payments_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_globals_payments_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id");
                });

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
                name: "IX_globals_payments_InvoiceId",
                table: "globals_payments",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_globals_payments_PaymentTypeId",
                table: "globals_payments",
                column: "PaymentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "globals_payments");

            migrationBuilder.DropTable(
                name: "globals_payments_banks");

            migrationBuilder.DropTable(
                name: "globals_payments_types");

            migrationBuilder.RenameColumn(
                name: "AccounReceivableId",
                table: "accounts_receivable_details",
                newName: "AccounReceivabletId");
        }
    }
}
