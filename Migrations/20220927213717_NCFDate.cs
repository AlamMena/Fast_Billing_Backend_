using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class NCFDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExiprationDate",
                table: "sales_ncf_sequences",
                newName: "ExpirationDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "sales_invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "sales_invoices");

            migrationBuilder.RenameColumn(
                name: "ExpirationDate",
                table: "sales_ncf_sequences",
                newName: "ExiprationDate");
        }
    }
}
