using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFlow_Management.Migrations
{
    /// <inheritdoc />
    public partial class initDb5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "ElectronicsId",
                table: "Order",
                newName: "ElectronicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ElectronicId",
                table: "Order",
                newName: "ElectronicsId");

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
    }
}
