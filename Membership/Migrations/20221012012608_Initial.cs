using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Membership.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MembershipNumber = table.Column<int>(type: "int", nullable: false),
                    AccountBalance = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Membership_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Email", "FirstName", "Surname" },
                values: new object[] { new Guid("6ebc3dbe-2e7b-4132-8c33-e089d47694cd"), "ayokunle@mailinator.com", "Mile", "Montego" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Email", "FirstName", "Surname" },
                values: new object[] { new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"), "olowoniwa.ayokunle@gmail.com", "Ayokunle", "Olowoniwa" });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "Id", "AccountBalance", "MembershipNumber", "PersonId", "Type" },
                values: new object[] { new Guid("150c81c6-2458-466e-907a-2df11325e2b8"), 600.0, 113, new Guid("6ebc3dbe-2e7b-4132-8c33-e089d47694cd"), 1 });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "Id", "AccountBalance", "MembershipNumber", "PersonId", "Type" },
                values: new object[] { new Guid("98474b8e-d713-401e-8aee-acb7353f97bb"), 5000.0, 111, new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"), 0 });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "Id", "AccountBalance", "MembershipNumber", "PersonId", "Type" },
                values: new object[] { new Guid("bfe902af-3cf0-4a1c-8a83-66be60b028ba"), 64000.0, 112, new Guid("6ebc3dbe-2e7b-4132-8c33-e089d47694cd"), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Membership_PersonId",
                table: "Membership",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Membership");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
