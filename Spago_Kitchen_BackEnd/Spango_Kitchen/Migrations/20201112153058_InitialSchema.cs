using Microsoft.EntityFrameworkCore.Migrations;

namespace Spango_Kitchen.Migrations
{
    public partial class InitialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CookingTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookingTime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cousine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CousineName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cousine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CousineId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CookingTimeId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dish_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dish_CookingTime_CookingTimeId",
                        column: x => x.CookingTimeId,
                        principalTable: "CookingTime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dish_Cousine_CousineId",
                        column: x => x.CousineId,
                        principalTable: "Cousine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishIngredientsDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishId = table.Column<int>(type: "int", nullable: false),
                    IngredientsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishIngredientsDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DishIngredientsDetails_Dish_DishId",
                        column: x => x.DishId,
                        principalTable: "Dish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishIngredientsDetails_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dish_CategoryId",
                table: "Dish",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_CookingTimeId",
                table: "Dish",
                column: "CookingTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_CousineId",
                table: "Dish",
                column: "CousineId");

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredientsDetails_DishId",
                table: "DishIngredientsDetails",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredientsDetails_IngredientsId",
                table: "DishIngredientsDetails",
                column: "IngredientsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishIngredientsDetails");

            migrationBuilder.DropTable(
                name: "Dish");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "CookingTime");

            migrationBuilder.DropTable(
                name: "Cousine");
        }
    }
}
