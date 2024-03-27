using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreWebApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonAndAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "EmailAddress", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "john@smith.com", "John", "Smith" },
                    { 2, "john@smith.com", "Susan", "Jones" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "City", "Country", "PersonId", "State", "ZipCode" },
                values: new object[,]
                {
                    { 1, "123 Test St", "", "Beverly Hills", "USA", 1, "CA", "90210" },
                    { 2, "123 Michigan Ave", "", "Chicago", "USA", 2, "IL", "60612" },
                    { 3, "100 1St St", "", "Chicago", "USA", 2, "IL", "60612" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
