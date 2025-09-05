using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bootcamp3_AspMVC.Migrations
{
    /// <inheritdoc />
    public partial class addDescriptionColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discraption",
                table: "Categories",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Categories",
                newName: "Discraption");
        }
    }
}
