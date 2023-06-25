using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodOrderSystemAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class lastSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "6c406ee7-a7d5-4fa0-8d33-c6d49dee512e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "a3aab654-97ac-4ca2-a7e9-b3041acafd74");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 100,
                column: "ConcurrencyStamp",
                value: "a2219fb7-7192-4314-9ba9-f7bc7e03631a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 101,
                column: "ConcurrencyStamp",
                value: "44ae5f6a-3776-44a4-b933-7a519a588ff4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 102,
                column: "ConcurrencyStamp",
                value: "c9b47bad-4569-4671-9c1c-dba382b31cb2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 103,
                column: "ConcurrencyStamp",
                value: "ab3d72e8-0212-461f-8a5d-387569c4e47a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 104,
                column: "ConcurrencyStamp",
                value: "93a235c9-2948-4899-935b-9d3542599e33");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 105,
                column: "ConcurrencyStamp",
                value: "ce3c26d8-28e2-418c-b917-272b9737d640");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 106,
                column: "ConcurrencyStamp",
                value: "744a81d7-ff8c-475e-8225-1464f47b04c0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "e9e05d2e-62bb-417c-addd-ed25a0886905");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "68b9bef8-195a-4780-a2de-629501f4c4b8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 100,
                column: "ConcurrencyStamp",
                value: "e7fdae8b-b8ce-4bf7-932f-e6d1dbcc3b8c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 101,
                column: "ConcurrencyStamp",
                value: "355d3213-428c-4cf3-aee2-f38b09c05812");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 102,
                column: "ConcurrencyStamp",
                value: "45e658a5-ed1f-4ff8-a38c-08433e859273");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 103,
                column: "ConcurrencyStamp",
                value: "2a791202-319a-4b38-b181-97292111928c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 104,
                column: "ConcurrencyStamp",
                value: "906cda7f-d424-4c42-963a-75b734227dd5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 105,
                column: "ConcurrencyStamp",
                value: "6ca1447f-f662-433c-947c-39dfc655e1ba");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 106,
                column: "ConcurrencyStamp",
                value: "f8e065cc-9315-43a5-b85f-fdc9a1460fd5");
        }
    }
}
