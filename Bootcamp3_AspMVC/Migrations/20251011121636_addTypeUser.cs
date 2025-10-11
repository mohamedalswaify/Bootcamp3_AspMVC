using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bootcamp3_AspMVC.Migrations
{
    /// <inheritdoc />
    public partial class addTypeUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeUser",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeUser",
                table: "Employees");
        }
    }
}
