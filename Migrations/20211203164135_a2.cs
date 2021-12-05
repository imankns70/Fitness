using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fitness.Migrations
{
    public partial class a2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "Workouts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "UserMeals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelectedDay = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

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
                        name: "FK_UserWorkouts_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionKey = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ScheduleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_SectionId",
                table: "Workouts",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeals_SectionId",
                table: "UserMeals",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_ScheduleId",
                table: "Sections",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkouts_WorkoutId",
                table: "UserWorkouts",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMeals_Sections_SectionId",
                table: "UserMeals",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Sections_SectionId",
                table: "Workouts",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMeals_Sections_SectionId",
                table: "UserMeals");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Sections_SectionId",
                table: "Workouts");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "UserWorkouts");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_SectionId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_UserMeals_SectionId",
                table: "UserMeals");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "UserMeals");
        }
    }
}
