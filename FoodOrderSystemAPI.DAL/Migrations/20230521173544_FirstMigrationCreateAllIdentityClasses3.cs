using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodOrderSystemAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigrationCreateAllIdentityClasses3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Location",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "CreditCard",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Location_CustomerId",
                table: "Location",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCard_CustomerId",
                table: "CreditCard",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCard_CustomerModel_CustomerId",
                table: "CreditCard",
                column: "CustomerId",
                principalTable: "CustomerModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_CustomerModel_CustomerId",
                table: "Location",
                column: "CustomerId",
                principalTable: "CustomerModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCard_CustomerModel_CustomerId",
                table: "CreditCard");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_CustomerModel_CustomerId",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_CustomerId",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_CreditCard_CustomerId",
                table: "CreditCard");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CreditCard");
        }
    }
}
