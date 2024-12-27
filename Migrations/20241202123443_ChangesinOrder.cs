using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFlow_Management.Migrations
{
    /// <inheritdoc />
    public partial class ChangesinOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ElectronicId",
                table: "Order",
                newName: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Order",
                newName: "ElectronicId");
        }
    }
}
