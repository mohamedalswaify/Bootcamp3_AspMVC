using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bootcamp3_AspMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddUidProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Uid",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uid",
                table: "Products");
        }
    }
}
