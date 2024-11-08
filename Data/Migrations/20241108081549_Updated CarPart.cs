using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveWorks_MVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCarPart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPartAccessible",
                table: "CarParts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CarParts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPartAccessible",
                table: "CarParts");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CarParts");
        }
    }
}
