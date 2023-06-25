using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodOrderSystemAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addphone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PhoneNumber" },
                values: new object[] { "7c7749b9-80ea-4c81-9482-a60a6f13c906", "1234567890" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PhoneNumber" },
                values: new object[] { "bf20cbca-6151-43d3-8b74-101147a27501", "1234237890" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 100,
                column: "ConcurrencyStamp",
                value: "4aa3a48e-d727-4a4b-a5ab-085089b0f823");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 101,
                column: "ConcurrencyStamp",
                value: "a81a4da6-1a11-4f11-b25c-b8ee2deb3acf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 102,
                column: "ConcurrencyStamp",
                value: "caed42cc-f776-48d1-99e0-ed07855adec8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 103,
                column: "ConcurrencyStamp",
                value: "1a43099f-3da7-49e2-acbb-bb3f5bdc313d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 104,
                column: "ConcurrencyStamp",
                value: "99b05f64-daf7-4511-b558-084708ff1618");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 105,
                column: "ConcurrencyStamp",
                value: "5152619c-db35-4ef8-8006-d86eb7569c06");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 106,
                column: "ConcurrencyStamp",
                value: "0f125164-4437-4247-8f5e-67403c141d4e");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PhoneNumber" },
                values: new object[] { "76149bcd-0d3f-4ccf-a7ea-dad579a5a5c2", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PhoneNumber" },
                values: new object[] { "447beeae-0e13-4da8-8dde-3d6b36b2986c", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 100,
                column: "ConcurrencyStamp",
                value: "f65576c6-d925-486d-9309-96072f1fef83");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 101,
                column: "ConcurrencyStamp",
                value: "d91fb2a0-1264-4b10-8e21-af47e255de1b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 102,
                column: "ConcurrencyStamp",
                value: "a3a15e30-2bf3-48b8-b760-446f3bdf07f3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 103,
                column: "ConcurrencyStamp",
                value: "891e262e-8419-4cad-88fd-b3111c89276b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 104,
                column: "ConcurrencyStamp",
                value: "8ace5a4e-f493-4490-8782-6e169a7e9190");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 105,
                column: "ConcurrencyStamp",
                value: "4d09ca9b-0c81-4058-8d22-f242867eb309");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 106,
                column: "ConcurrencyStamp",
                value: "cee36d6a-f01b-4bbd-a42d-ff41f1b3e499");
        }
    }
}
