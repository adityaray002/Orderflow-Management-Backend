using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFlow_Management.Migrations
{
    /// <inheritdoc />
    public partial class initDb3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ElectronicName",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "ElectronicId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ElectronicsId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_ElectronicsId",
                table: "Order",
                column: "ElectronicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_StatusId",
                table: "Order",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserInfoId",
                table: "Order",
                column: "UserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Electronics_ElectronicsId",
                table: "Order",
                column: "ElectronicsId",
                principalTable: "Electronics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Status_StatusId",
                table: "Order",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_UserInfoId",
                table: "Order",
                column: "UserInfoId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Electronics_ElectronicsId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Status_StatusId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_UserInfoId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ElectronicsId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_StatusId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_UserInfoId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ElectronicId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ElectronicsId",
                table: "Order");

            migrationBuilder.AddColumn<string>(
                name: "ElectronicName",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
