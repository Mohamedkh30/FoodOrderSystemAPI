using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodOrderSystemAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class tobedeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "UserName" },
                values: new object[] { "486ad818-eda1-4822-92b9-071f43c262c6", "MohamedAhmed", "MohamedAhmed" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 2, 0, "e80b5b9c-85c1-45a6-8467-875e1ed7d2a4", "test", false, false, null, "", "KFC", null, null, false, 0, null, false, "KFC" },
                    { 3, 0, "87ffa2d7-a8d7-444f-b635-9c7bde9007eb", "test", false, false, null, "", "Central", null, null, false, 0, null, false, "Central" },
                    { 4, 0, "b36e6553-2894-4db5-b44c-ce44bd862cf2", "info@tastybistro.com", false, false, null, "", "TheTastyBistro", null, null, false, 0, null, false, "TheTastyBistro" },
                    { 5, 0, "92256cfc-18bd-4056-b959-4991b10f8588", "www.ChezGaby.com", false, false, null, "", "ChezGaby", null, null, false, 0, null, false, "ChezGaby" },
                    { 6, 0, "bfd72951-5a7d-4bc4-96c9-cc53b920de73", "www.Negro.com", false, false, null, "", "Negro", null, null, false, 0, null, false, "Negro" },
                    { 7, 0, "40cd6f0a-63b1-4761-af4c-b2e4124c112a", "567 Walnut Lane", false, false, null, "", "seafoodshack", null, null, false, 0, null, false, "seafoodshack" }
                });

            migrationBuilder.UpdateData(
                table: "RestaurantModel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Logo", "Phone" },
                values: new object[] { "https://images.deliveryhero.io/image/talabat/restaurants/21167986_13580950369_637438183491941065.jpg?width=180", "+20 111 111 1111" });

            migrationBuilder.InsertData(
                table: "RestaurantModel",
                columns: new[] { "Id", "Address", "Logo", "PaymentMethods", "Phone", "RestaurantName" },
                values: new object[,]
                {
                    { 2, "test", "https://upload.wikimedia.org/wikipedia/sco/b/bf/KFC_logo.svg", 1, "+20 111 111 1111", "KFC" },
                    { 3, "Av. Pedro de Osma 301, Barranco, Lima, Peru", "https://centralrestaurante.com.pe/assets/images/facebook.jpg", 2, "+51 1 242 8515", "Central" },
                    { 4, "123 Main Street", "https://img.freepik.com/free-vector/detailed-chef-logo-template_23-2148987940.jpg?size=626&ext=jpg&ga=GA1.1.118802800.1685470637&semt=ais", 1, "+20 111 111 1111", "The Tasty Bistro" },
                    { 5, "off of Fouad Street, close to the Alexandria Opera House", "https://www.zumtaugwald.ch/uploads/8iADQWOr/chezgaby_farbig_gross_198.gif", 1, "+20 111 111 1111", "Chez Gaby" },
                    { 6, "test", "https://cerronegrorestaurant.com/wp-content/uploads/2022/06/logo-1.png", 1, "+20 111 111 1111", "Negro" },
                    { 7, "test", "https://img.freepik.com/premium-vector/fresh-seafood-restaurant-premium-logo_187482-625.jpg?w=2000", 1, "+20 111 111 1111", "The Seafood Shack" }
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
                table: "RestaurantModel",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RestaurantModel",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RestaurantModel",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RestaurantModel",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "UserName" },
                values: new object[] { "919abc56-efae-4f3b-bce5-dc7e21e0d8b5", "", "Mohamed Ahmed" });

            migrationBuilder.UpdateData(
                table: "RestaurantModel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Logo", "Phone" },
                values: new object[] { "", "" });
        }
    }
}
