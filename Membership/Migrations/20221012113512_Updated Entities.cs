using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Membership.Migrations
{
    public partial class UpdatedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Membership",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "Id",
                keyValue: new Guid("150c81c6-2458-466e-907a-2df11325e2b8"),
                column: "Type",
                value: "Secondary");

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "Id",
                keyValue: new Guid("98474b8e-d713-401e-8aee-acb7353f97bb"),
                column: "Type",
                value: "Primary");

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "Id",
                keyValue: new Guid("bfe902af-3cf0-4a1c-8a83-66be60b028ba"),
                column: "Type",
                value: "Secondary");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Membership",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "Id",
                keyValue: new Guid("150c81c6-2458-466e-907a-2df11325e2b8"),
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "Id",
                keyValue: new Guid("98474b8e-d713-401e-8aee-acb7353f97bb"),
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "Id",
                keyValue: new Guid("bfe902af-3cf0-4a1c-8a83-66be60b028ba"),
                column: "Type",
                value: 1);
        }
    }
}
