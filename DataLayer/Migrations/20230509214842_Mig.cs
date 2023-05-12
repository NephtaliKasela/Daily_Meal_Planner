using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealTime");

            migrationBuilder.AddColumn<int>(
                name: "UserCategoryId",
                table: "UserProducts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserMealtime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealtimeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMealtime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMealtime_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mealtime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserMealtimeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCategory_UserMealtime_UserMealtimeId",
                        column: x => x.UserMealtimeId,
                        principalTable: "UserMealtime",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProducts_UserCategoryId",
                table: "UserProducts",
                column: "UserCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategory_UserMealtimeId",
                table: "UserCategory",
                column: "UserMealtimeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMealtime_UserId",
                table: "UserMealtime",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProducts_UserCategory_UserCategoryId",
                table: "UserProducts",
                column: "UserCategoryId",
                principalTable: "UserCategory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProducts_UserCategory_UserCategoryId",
                table: "UserProducts");

            migrationBuilder.DropTable(
                name: "UserCategory");

            migrationBuilder.DropTable(
                name: "UserMealtime");

            migrationBuilder.DropIndex(
                name: "IX_UserProducts_UserCategoryId",
                table: "UserProducts");

            migrationBuilder.DropColumn(
                name: "UserCategoryId",
                table: "UserProducts");

            migrationBuilder.CreateTable(
                name: "MealTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealTime_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealTime_UserId",
                table: "MealTime",
                column: "UserId");
        }
    }
}
