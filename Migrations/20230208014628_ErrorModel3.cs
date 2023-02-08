using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class ErrorModel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Errors",
                newName: "UpdatedDate");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Errors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Errors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Errors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Errors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Errors");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Errors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Errors");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Errors");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Errors",
                newName: "Date");
        }
    }
}
