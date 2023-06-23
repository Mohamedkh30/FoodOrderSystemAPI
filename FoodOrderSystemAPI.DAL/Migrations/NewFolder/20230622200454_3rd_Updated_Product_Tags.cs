using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodOrderSystemAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class _3rd_Updated_Product_Tags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_RestaurantModel_restaurantId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PaymentDetails",
                table: "RestaurantModel");

            migrationBuilder.DropColumn(
                name: "type",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "restaurantId",
                table: "Products",
                newName: "RestaurantID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_restaurantId",
                table: "Products",
                newName: "IX_Products_RestaurantID");

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantName",
                table: "RestaurantModel",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "RestaurantModel",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "RestaurantModel",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethods",
                table: "RestaurantModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductTags",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    tag = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTags", x => new { x.ProductId, x.tag });
                    table.ForeignKey(
                        name: "FK_ProductTags_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_RestaurantModel_RestaurantID",
                table: "Products",
                column: "RestaurantID",
                principalTable: "RestaurantModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_RestaurantModel_RestaurantID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductTags");

            migrationBuilder.DropColumn(
                name: "PaymentMethods",
                table: "RestaurantModel");

            migrationBuilder.RenameColumn(
                name: "RestaurantID",
                table: "Products",
                newName: "restaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_RestaurantID",
                table: "Products",
                newName: "IX_Products_restaurantId");

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantName",
                table: "RestaurantModel",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "RestaurantModel",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "RestaurantModel",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "PaymentDetails",
                table: "RestaurantModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_RestaurantModel_restaurantId",
                table: "Products",
                column: "restaurantId",
                principalTable: "RestaurantModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
