using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFlow_Management.Migrations
{
    /// <inheritdoc />
    public partial class initDb4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ElectronicId",
                table: "Order");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ElectronicId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
