using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodOrderSystemAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class _4th_seeded_products : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "bfb8d6ce-080f-4556-ad3b-21bb61226362", "test", false, false, null, "", "", null, null, false, 0, null, false, "Mohamed Ahmed" });

            migrationBuilder.InsertData(
                table: "RestaurantModel",
                columns: new[] { "Id", "Address", "Logo", "PaymentMethods", "Phone", "RestaurantName" },
                values: new object[] { 1, "test", "", 1, "", "Mohamed Ahmed" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Productname", "RestaurantID", "describtion", "img", "offer", "price", "rate" },
                values: new object[,]
                {
                    { 1, "Flafel", 1, "flafel so5na", "https://www.holidaysmart.com/sites/default/files/daily/2020/falafel-shs_1500.jpg", 0.45555f, 3f, 4f },
                    { 2, "fool", 1, "fool so5n", "https://kitchen.sayidaty.net/uploads/small/42/423203a50a85745ee5ff98ff201043f7_w750_h500.jpg", 0f, 5f, 2f },
                    { 3, "Koshary", 1, "Koshary so5n", "https://i.pinimg.com/originals/4c/37/99/4c37995da59d3e4cdf0da7c57084e2f5.jpg", 0.5f, 20f, 4f },
                    { 4, "kebda", 1, "kebda so5na", "https://egy-news.net/im0photos/20220919/T16635700676390e53d7bc4b1cbbd92af455195f691image.jpg&w=1200&h=675&img.jpg", 0.1f, 30f, 3f }
                });

            migrationBuilder.InsertData(
                table: "ProductTags",
                columns: new[] { "ProductId", "tag" },
                values: new object[,]
                {
                    { 1, "local" },
                    { 1, "vegetarian" },
                    { 2, "local" },
                    { 2, "vegetarian" },
                    { 3, "local" },
                    { 3, "vegetarian" },
                    { 4, "local" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductTags",
                keyColumns: new[] { "ProductId", "tag" },
                keyValues: new object[] { 1, "local" });

            migrationBuilder.DeleteData(
                table: "ProductTags",
                keyColumns: new[] { "ProductId", "tag" },
                keyValues: new object[] { 1, "vegetarian" });

            migrationBuilder.DeleteData(
                table: "ProductTags",
                keyColumns: new[] { "ProductId", "tag" },
                keyValues: new object[] { 2, "local" });

            migrationBuilder.DeleteData(
                table: "ProductTags",
                keyColumns: new[] { "ProductId", "tag" },
                keyValues: new object[] { 2, "vegetarian" });

            migrationBuilder.DeleteData(
                table: "ProductTags",
                keyColumns: new[] { "ProductId", "tag" },
                keyValues: new object[] { 3, "local" });

            migrationBuilder.DeleteData(
                table: "ProductTags",
                keyColumns: new[] { "ProductId", "tag" },
                keyValues: new object[] { 3, "vegetarian" });

            migrationBuilder.DeleteData(
                table: "ProductTags",
                keyColumns: new[] { "ProductId", "tag" },
                keyValues: new object[] { 4, "local" });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RestaurantModel",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
