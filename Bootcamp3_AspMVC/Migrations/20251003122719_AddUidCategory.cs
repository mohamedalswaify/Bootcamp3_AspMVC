using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bootcamp3_AspMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddUidCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Uid",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uid",
                table: "Categories");
        }
    }
}
