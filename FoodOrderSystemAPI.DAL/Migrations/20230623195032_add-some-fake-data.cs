using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodOrderSystemAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addsomefakedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "df60442c-dccb-478f-90f1-5da4ebc300fe");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 2, 0, "96d084e4-0099-4b1b-8f43-e61afe3716dc", "", false, false, null, "", "", null, null, false, 0, null, false, "" },
                    { 3, 0, "507d4db6-f74e-40e9-b670-a215d3cda8b5", "", false, false, null, "", "", null, null, false, 0, null, false, "" }
                });

            migrationBuilder.InsertData(
                table: "RestaurantModel",
                columns: new[] { "Id", "Address", "Logo", "PaymentMethods", "Phone", "RestaurantName" },
                values: new object[,]
                {
                    { 2, "Address 1", "Logo 1", 1, "1234567890", "Restaurant 1" },
                    { 3, "Address 2", "Logo 2", 0, "9876543210", "Restaurant 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RestaurantModel",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RestaurantModel",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "bfb8d6ce-080f-4556-ad3b-21bb61226362");
        }
    }
}
