using Microsoft.EntityFrameworkCore.Migrations;

namespace Spango_Kitchen.Migrations
{
    public partial class ExendingDishes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Calories",
                table: "Dish",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Carbs",
                table: "Dish",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Fat",
                table: "Dish",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Protein",
                table: "Dish",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calories",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "Carbs",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "Fat",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "Dish");
        }
    }
}
