using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class Ncfs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_payable_NcfTypes_NcfTypeId",
                table: "accounts_payable");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_invoices_NcfTypes_NcfTypeId",
                table: "sales_invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NcfTypes",
                table: "NcfTypes");

            migrationBuilder.RenameTable(
                name: "NcfTypes",
                newName: "sales_ncf_types");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sales_ncf_types",
                table: "sales_ncf_types",
                column: "Id");

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
                    ExiprationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sales_ncf_sequences_system_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "system_branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_sales_ncf_sequences_system_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "system_companies",
                        principalColumn: "Id");
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_payable_sales_ncf_types_NcfTypeId",
                table: "accounts_payable",
                column: "NcfTypeId",
                principalTable: "sales_ncf_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_invoices_sales_ncf_types_NcfTypeId",
                table: "sales_invoices",
                column: "NcfTypeId",
                principalTable: "sales_ncf_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_payable_sales_ncf_types_NcfTypeId",
                table: "accounts_payable");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_invoices_sales_ncf_types_NcfTypeId",
                table: "sales_invoices");

            migrationBuilder.DropTable(
                name: "sales_ncf_sequences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sales_ncf_types",
                table: "sales_ncf_types");

            migrationBuilder.RenameTable(
                name: "sales_ncf_types",
                newName: "NcfTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NcfTypes",
                table: "NcfTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_payable_NcfTypes_NcfTypeId",
                table: "accounts_payable",
                column: "NcfTypeId",
                principalTable: "NcfTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sales_invoices_NcfTypes_NcfTypeId",
                table: "sales_invoices",
                column: "NcfTypeId",
                principalTable: "NcfTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
