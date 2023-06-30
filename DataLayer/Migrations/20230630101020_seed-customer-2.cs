using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class seedcustomer2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: new Guid("65f7d88c-d1ea-4a42-8ff4-4c3e1f3bade2"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: new Guid("701629b1-8da3-466f-9918-e850956fb911"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: new Guid("9d8c7115-89cc-47f8-980f-ffb02a8de248"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: new Guid("a088fbfa-a0e3-4762-9fd4-80be40162175"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: new Guid("c0e10b86-80e4-40b6-9e6b-2a761df7525e"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: new Guid("d8300ac5-7ac5-4ca1-9d20-87fa34980af1"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: new Guid("df9dd9c9-8a09-477b-bbe9-4860b2cbc89e"));

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "AddressCity", "Author", "ISBN", "PressId", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("1a90b265-4bee-4406-acd4-e93401a0e9c8"), "Ha Noi", "Benjamin Hartman", "978-7-77-777777-0", new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"), 176300.0, "Galactic Empire" },
                    { new Guid("2e662bd7-17f0-4f71-9236-408a413badc8"), "Ha Noi", "Nathan Greenfield", "978-9-87-654321-0", new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"), 203750.0, "Time Rift Chronicles" },
                    { new Guid("795a174f-4e53-4954-8f20-aefd439a3c96"), "Ha Noi", "Oliver Armstrong", "978-2-22-333333-0", new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"), 185900.0, "Quantum Paradox" },
                    { new Guid("a5bd69ca-7ca1-4e95-b861-1e5145592361"), "Ha Noi", "Maya Thompson", "978-0-98-765432-0", new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"), 92800.0, "Stellar Convergence" },
                    { new Guid("c364fcbc-c19f-4ff9-9972-9290226d46f5"), "Ha Noi", "Aristotle", "978-3-16-148410-0", new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"), 150000.0, "Science Fiction" },
                    { new Guid("d197437c-f28f-4c64-967d-d9f62c943e62"), "Ha Noi", "Stella Blackwood", "978-1-23-456789-0", new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"), 87500.0, "The Galactic Voyage" },
                    { new Guid("f0858110-d3ac-4f5d-8d37-5d23df8354c7"), "Ha Noi", "Erika Silverstone", "978-5-55-555555-0", new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"), 121250.0, "Cybernetic Dreams" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "Password", "Role" },
                values: new object[] { "customer", "customer", 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: new Guid("1a90b265-4bee-4406-acd4-e93401a0e9c8"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: new Guid("2e662bd7-17f0-4f71-9236-408a413badc8"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: new Guid("795a174f-4e53-4954-8f20-aefd439a3c96"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: new Guid("a5bd69ca-7ca1-4e95-b861-1e5145592361"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: new Guid("c364fcbc-c19f-4ff9-9972-9290226d46f5"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: new Guid("d197437c-f28f-4c64-967d-d9f62c943e62"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: new Guid("f0858110-d3ac-4f5d-8d37-5d23df8354c7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "customer");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "AddressCity", "Author", "ISBN", "PressId", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("65f7d88c-d1ea-4a42-8ff4-4c3e1f3bade2"), "Ha Noi", "Nathan Greenfield", "978-9-87-654321-0", new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"), 203750.0, "Time Rift Chronicles" },
                    { new Guid("701629b1-8da3-466f-9918-e850956fb911"), "Ha Noi", "Aristotle", "978-3-16-148410-0", new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"), 150000.0, "Science Fiction" },
                    { new Guid("9d8c7115-89cc-47f8-980f-ffb02a8de248"), "Ha Noi", "Erika Silverstone", "978-5-55-555555-0", new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"), 121250.0, "Cybernetic Dreams" },
                    { new Guid("a088fbfa-a0e3-4762-9fd4-80be40162175"), "Ha Noi", "Oliver Armstrong", "978-2-22-333333-0", new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"), 185900.0, "Quantum Paradox" },
                    { new Guid("c0e10b86-80e4-40b6-9e6b-2a761df7525e"), "Ha Noi", "Maya Thompson", "978-0-98-765432-0", new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"), 92800.0, "Stellar Convergence" },
                    { new Guid("d8300ac5-7ac5-4ca1-9d20-87fa34980af1"), "Ha Noi", "Stella Blackwood", "978-1-23-456789-0", new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"), 87500.0, "The Galactic Voyage" },
                    { new Guid("df9dd9c9-8a09-477b-bbe9-4860b2cbc89e"), "Ha Noi", "Benjamin Hartman", "978-7-77-777777-0", new Guid("d75cefaf-2361-4251-a2ff-6cbe36182899"), 176300.0, "Galactic Empire" }
                });
        }
    }
}
