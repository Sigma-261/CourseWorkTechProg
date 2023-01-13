using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseWorkMain.Migrations
{
    /// <inheritdoc />
    public partial class Migration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BusinessTrips",
                columns: new[] { "id", "City", "Days", "Employee", "Wage" },
                values: new object[,]
                {
                    { 2, "Севастополь", 30, "Михаил Михайлович Минин", 20000 },
                    { 3, "Москва", 25, "Беляев Рудольф Максович", 130000 },
                    { 4, "Волгоград", 11, "Гусев Святослав Антонович", 10000 },
                    { 5, "Крым", 17, "Муравьёв Роман Семенович", 100600 },
                    { 6, "Вологда", 31, "Гусев Святослав Антонович", 100000 },
                    { 7, "Воронеж", 15, "Андреев Лавр Иосифович", 100000 },
                    { 8, "Калининград", 5, "Беляев Рудольф Максович", 15000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BusinessTrips",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BusinessTrips",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BusinessTrips",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BusinessTrips",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BusinessTrips",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BusinessTrips",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BusinessTrips",
                keyColumn: "id",
                keyValue: 8);
        }
    }
}
