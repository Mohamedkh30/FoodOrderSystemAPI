using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodOrderSystemAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedIntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 2, 0, "76149bcd-0d3f-4ccf-a7ea-dad579a5a5c2", "hassan@gmail.com", false, false, null, "", "testmohamed", null, null, false, 0, null, false, "testmohamed" },
                    { 3, 0, "447beeae-0e13-4da8-8dde-3d6b36b2986c", "hamdy@gmail.com", false, false, null, "", "ramymohamed", null, null, false, 0, null, false, "ramymohamed" },
                    { 100, 0, "f65576c6-d925-486d-9309-96072f1fef83", "test", false, false, null, "", "MohamedAhmed", null, null, false, 0, null, false, "MohamedAhmed" },
                    { 101, 0, "d91fb2a0-1264-4b10-8e21-af47e255de1b", "test", false, false, null, "", "KFC", null, null, false, 0, null, false, "KFC" },
                    { 102, 0, "a3a15e30-2bf3-48b8-b760-446f3bdf07f3", "test", false, false, null, "", "Central", null, null, false, 0, null, false, "Central" },
                    { 103, 0, "891e262e-8419-4cad-88fd-b3111c89276b", "info@tastybistro.com", false, false, null, "", "TheTastyBistro", null, null, false, 0, null, false, "TheTastyBistro" },
                    { 104, 0, "8ace5a4e-f493-4490-8782-6e169a7e9190", "www.ChezGaby.com", false, false, null, "", "ChezGaby", null, null, false, 0, null, false, "ChezGaby" },
                    { 105, 0, "4d09ca9b-0c81-4058-8d22-f242867eb309", "www.Negro.com", false, false, null, "", "Negro", null, null, false, 0, null, false, "Negro" },
                    { 106, 0, "cee36d6a-f01b-4bbd-a42d-ff41f1b3e499", "567 Walnut Lane", false, false, null, "", "seafoodshack", null, null, false, 0, null, false, "seafoodshack" }
                });

            migrationBuilder.InsertData(
                table: "CustomerModel",
                columns: new[] { "Id", "BirthDate", "CustomerAddress" },
                values: new object[,]
                {
                    { 2, new DateTime(1999, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gleem" },
                    { 3, new DateTime(2002, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sanstifano" }
                });

            migrationBuilder.InsertData(
                table: "RestaurantModel",
                columns: new[] { "Id", "Address", "Logo", "PaymentMethods", "Phone", "RestaurantName" },
                values: new object[,]
                {
                    { 100, "test", "https://images.deliveryhero.io/image/talabat/restaurants/21167986_13580950369_637438183491941065.jpg?width=180", 1, "+20 111 111 1111", "Mohamed Ahmed" },
                    { 101, "test", "https://upload.wikimedia.org/wikipedia/sco/b/bf/KFC_logo.svg", 1, "+20 111 111 1111", "KFC" },
                    { 102, "Av. Pedro de Osma 301, Barranco, Lima, Peru", "https://centralrestaurante.com.pe/assets/images/facebook.jpg", 2, "+51 1 242 8515", "Central" },
                    { 103, "123 Main Street", "https://img.freepik.com/free-vector/detailed-chef-logo-template_23-2148987940.jpg?size=626&ext=jpg&ga=GA1.1.118802800.1685470637&semt=ais", 1, "+20 111 111 1111", "The Tasty Bistro" },
                    { 104, "off of Fouad Street, close to the Alexandria Opera House", "https://www.zumtaugwald.ch/uploads/8iADQWOr/chezgaby_farbig_gross_198.gif", 1, "+20 111 111 1111", "Chez Gaby" },
                    { 105, "test", "https://cerronegrorestaurant.com/wp-content/uploads/2022/06/logo-1.png", 1, "+20 111 111 1111", "Negro" },
                    { 106, "test", "https://img.freepik.com/premium-vector/fresh-seafood-restaurant-premium-logo_187482-625.jpg?w=2000", 1, "+20 111 111 1111", "The Seafood Shack" }
                });

            migrationBuilder.InsertData(
                table: "CreditCards",
                columns: new[] { "CreditId", "CVV", "Card_Expiration_Date", "Card_Number", "CustomerId" },
                values: new object[,]
                {
                    { 1, "333", new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "1234123412341234", 2 },
                    { 2, "229", new DateTime(2026, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "1212121212121212", 3 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Productname", "RestaurantID", "describtion", "img", "offer", "price", "rate" },
                values: new object[,]
                {
                    { 1, "Flafel", 100, "flafel so5na", "https://www.holidaysmart.com/sites/default/files/daily/2020/falafel-shs_1500.jpg", 0.45555f, 3f, 4f },
                    { 2, "fool", 100, "fool so5n", "https://kitchen.sayidaty.net/uploads/small/42/423203a50a85745ee5ff98ff201043f7_w750_h500.jpg", 0f, 5f, 2f },
                    { 3, "Koshary", 101, "Koshary so5n", "https://i.pinimg.com/originals/4c/37/99/4c37995da59d3e4cdf0da7c57084e2f5.jpg", 0.5f, 20f, 4f },
                    { 4, "kebda", 102, "kebda so5na", "https://egy-news.net/im0photos/20220919/T16635700676390e53d7bc4b1cbbd92af455195f691image.jpg&w=1200&h=675&img.jpg", 0.1f, 30f, 3f }
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
                table: "CreditCards",
                keyColumn: "CreditId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CreditCards",
                keyColumn: "CreditId",
                keyValue: 2);

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
                table: "RestaurantModel",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "RestaurantModel",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "RestaurantModel",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "RestaurantModel",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "CustomerModel",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CustomerModel",
                keyColumn: "Id",
                keyValue: 3);

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
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RestaurantModel",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "RestaurantModel",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "RestaurantModel",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 102);
        }
    }
}
