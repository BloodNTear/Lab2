using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Presses",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Books_Presses_PressId",
                        column: x => x.PressId,
                        principalTable: "Presses",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    City = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.City);
                    table.ForeignKey(
                        name: "FK_Addresses_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Presses",
                columns: new[] { "ID", "Category", "Name" },
                values: new object[,]
                {
                    { new Guid("66cc1f7d-97f3-4ec7-9423-0ef2c75cb914"), 2, "E Book" },
                    { new Guid("949707e7-ec5c-43b0-9d50-669a067d584f"), 0, "Book" },
                    { new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"), 1, "Magazine" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "Password", "Role" },
                values: new object[,]
                {
                    { "admin", "admin", 1 },
                    { "staff", "staff", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_BookID",
                table: "Addresses",
                column: "BookID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_PressId",
                table: "Books",
                column: "PressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Presses");
        }
    }
}
