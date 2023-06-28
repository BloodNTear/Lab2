using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class seedbooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Books_BookID",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_BookID",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "BookID",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "AddressCity",
                table: "Books",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "City", "Street" },
                values: new object[,]
                {
                    { "Ha Noi", "Tran Duy Hung" },
                    { "Ho Chi Minh", "Bui Vien" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "AddressCity", "Author", "ISBN", "PressId", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("88316682-e17d-48d4-808d-c703182f5a89"), "Ha Noi", "Aristotle", "978-3-16-148410-0", new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"), 150000.0, "Science Fiction" },
                    { new Guid("925823c7-b48a-44fb-9d57-b4e58165fdf6"), "Ho Chi Minh", "Aristotle", "978-3-16-148410-0", new Guid("66cc1f7d-97f3-4ec7-9423-0ef2c75cb914"), 100000.0, "Philosophy" },
                    { new Guid("b2c9e028-3ca6-494c-8030-378c8999e9a6"), "Ho Chi Minh", "Einstein", "978-3-16-148410-0", new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"), 200000.0, "Physics" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AddressCity",
                table: "Books",
                column: "AddressCity");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Addresses_AddressCity",
                table: "Books",
                column: "AddressCity",
                principalTable: "Addresses",
                principalColumn: "City",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Addresses_AddressCity",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AddressCity",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: new Guid("88316682-e17d-48d4-808d-c703182f5a89"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: new Guid("925823c7-b48a-44fb-9d57-b4e58165fdf6"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: new Guid("b2c9e028-3ca6-494c-8030-378c8999e9a6"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "City",
                keyValue: "Ha Noi");

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "City",
                keyValue: "Ho Chi Minh");

            migrationBuilder.DropColumn(
                name: "AddressCity",
                table: "Books");

            migrationBuilder.AddColumn<Guid>(
                name: "BookID",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_BookID",
                table: "Addresses",
                column: "BookID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Books_BookID",
                table: "Addresses",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
