using Microsoft.EntityFrameworkCore.Migrations;

namespace Spango_Kitchen.Migrations
{
    public partial class RemovedForeignKeysforDishes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_CookingTime_CookingTimeId",
                table: "Dish");

            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Cousine_CousineId",
                table: "Dish");

            migrationBuilder.AlterColumn<int>(
                name: "CousineId",
                table: "Dish",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CookingTimeId",
                table: "Dish",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_CookingTime_CookingTimeId",
                table: "Dish",
                column: "CookingTimeId",
                principalTable: "CookingTime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Cousine_CousineId",
                table: "Dish",
                column: "CousineId",
                principalTable: "Cousine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_CookingTime_CookingTimeId",
                table: "Dish");

            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Cousine_CousineId",
                table: "Dish");

            migrationBuilder.AlterColumn<int>(
                name: "CousineId",
                table: "Dish",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CookingTimeId",
                table: "Dish",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_CookingTime_CookingTimeId",
                table: "Dish",
                column: "CookingTimeId",
                principalTable: "CookingTime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Cousine_CousineId",
                table: "Dish",
                column: "CousineId",
                principalTable: "Cousine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
