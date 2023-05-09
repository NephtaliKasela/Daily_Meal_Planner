using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class ProductMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gramms = table.Column<double>(type: "float", nullable: false),
                    Protein = table.Column<double>(type: "float", nullable: false),
                    Fats = table.Column<double>(type: "float", nullable: false),
                    Carbs = table.Column<double>(type: "float", nullable: false),
                    Calories = table.Column<double>(type: "float", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Calories", "Carbs", "CategoryName", "Fats", "Gramms", "Name", "Protein" },
                values: new object[,]
                {
                    { 1, 225.0, 0.5, "Алкоголь", 0.0, 100.0, "Бренди 40% алкоголя", 0.0 },
                    { 2, 158.0, 15.9, "Алкоголь", 0.0, 100.0, "Вермут 13% алкоголя", 0.0 },
                    { 3, 78.0, 4.5, "Алкоголь", 0.0, 100.0, "Вино белое 10% алкоголя", 0.0 },
                    { 4, 223.0, 23.199999999999999, "Готовые блюда", 10.0, 100.0, "Беляши", 11.0 },
                    { 5, 640.0, 55.200000000000003, "Готовые блюда", 33.100000000000001, 100.0, "Блинчики с творогом и сметаной", 25.800000000000001 },
                    { 6, 23.0, 1.1000000000000001, "Грибы", 1.7, 100.0, "Белые грибы", 3.7000000000000002 },
                    { 7, 152.0, 7.5999999999999996, "Грибы", 4.7999999999999998, 100.0, "Белые грибы сушеные", 20.100000000000001 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
