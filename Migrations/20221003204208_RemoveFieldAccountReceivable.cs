using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class RemoveFieldAccountReceivable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenceId",
                table: "accounts_recivable");

            migrationBuilder.DropColumn(
                name: "AccounReceivableId",
                table: "accounts_receivable_details");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReferenceId",
                table: "accounts_recivable",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccounReceivableId",
                table: "accounts_receivable_details",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
