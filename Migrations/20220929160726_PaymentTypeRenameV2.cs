using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class PaymentTypeRenameV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymenTypeId",
                table: "globals_payments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymenTypeId",
                table: "globals_payments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
