using Microsoft.EntityFrameworkCore.Migrations;

namespace Fitness.Migrations
{
    public partial class addworkouttomodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Ingredients",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Ingredients", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Meals",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Meals", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Reps = table.Column<int>(nullable: false),
                    Sets = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Distance = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "MealIngredients",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        MealId = table.Column<int>(nullable: false),
            //        IngredientId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MealIngredients", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_MealIngredients_Ingredients_IngredientId",
            //            column: x => x.IngredientId,
            //            principalTable: "Ingredients",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_MealIngredients_Meals_MealId",
            //            column: x => x.MealId,
            //            principalTable: "Meals",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserMeals",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        MealId = table.Column<int>(nullable: false),
            //        UserId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserMeals", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_UserMeals_Meals_MealId",
            //            column: x => x.MealId,
            //            principalTable: "Meals",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_UserMeals_Users_UserId",
            //            column: x => x.UserId,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateTable(
                name: "UserWorkouts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    WorkoutId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWorkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserWorkouts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWorkouts_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_MealIngredients_IngredientId",
            //    table: "MealIngredients",
            //    column: "IngredientId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_MealIngredients_MealId",
            //    table: "MealIngredients",
            //    column: "MealId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UserMeals_MealId",
            //    table: "UserMeals",
            //    column: "MealId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UserMeals_UserId",
            //    table: "UserMeals",
            //    column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkouts_UserId",
                table: "UserWorkouts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkouts_WorkoutId",
                table: "UserWorkouts",
                column: "WorkoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "MealIngredients");

            //migrationBuilder.DropTable(
            //    name: "UserMeals");

            //migrationBuilder.DropTable(
            //    name: "UserWorkouts");

            //migrationBuilder.DropTable(
            //    name: "Ingredients");

            //migrationBuilder.DropTable(
            //    name: "Meals");

            migrationBuilder.DropTable(
                name: "Workouts");
        }
    }
}
