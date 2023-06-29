using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class seedmorebook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "AddressCity", "Author", "ISBN", "PressId", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("13511bde-7439-4e91-9916-63ff9831b740"), "Ha Noi", "Oliver Armstrong", "978-2-22-333333-0", new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"), 185900.0, "Quantum Paradox" },
                    { new Guid("7392b7b9-d9b5-4817-b050-c625bbd94c2b"), "Ha Noi", "Nathan Greenfield", "978-9-87-654321-0", new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"), 203750.0, "Time Rift Chronicles" },
                    { new Guid("8591a71d-d322-4143-8839-a8b264a9664e"), "Ha Noi", "Erika Silverstone", "978-5-55-555555-0", new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"), 121250.0, "Cybernetic Dreams" },
                    { new Guid("99a8785d-2dc7-4a4c-a437-a2d72ba2a603"), "Ha Noi", "Stella Blackwood", "978-1-23-456789-0", new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"), 87500.0, "The Galactic Voyage" },
                    { new Guid("9dba4c64-4bae-41e4-9860-e3a461595195"), "Ha Noi", "Maya Thompson", "978-0-98-765432-0", new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"), 92800.0, "Stellar Convergence" },
                    { new Guid("b604bf0a-0071-43f7-9e2e-69df31c28982"), "Ha Noi", "Aristotle", "978-3-16-148410-0", new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"), 150000.0, "Science Fiction" },
                    { new Guid("f7d3326a-6237-49c4-b403-9f702425b5ac"), "Ha Noi", "Benjamin Hartman", "978-7-77-777777-0", new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"), 176300.0, "Galactic Empire" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: new Guid("13511bde-7439-4e91-9916-63ff9831b740"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: new Guid("7392b7b9-d9b5-4817-b050-c625bbd94c2b"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: new Guid("8591a71d-d322-4143-8839-a8b264a9664e"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: new Guid("99a8785d-2dc7-4a4c-a437-a2d72ba2a603"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: new Guid("9dba4c64-4bae-41e4-9860-e3a461595195"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: new Guid("b604bf0a-0071-43f7-9e2e-69df31c28982"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: new Guid("f7d3326a-6237-49c4-b403-9f702425b5ac"));
        }
    }
}
