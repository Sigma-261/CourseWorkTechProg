using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseWorkMain.Migrations
{
    /// <inheritdoc />
    public partial class Migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Localities");

            migrationBuilder.CreateTable(
                name: "BusinessTrips",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Days = table.Column<int>(type: "int", nullable: false),
                    Wage = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessTrips", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "BusinessTrips",
                columns: new[] { "id", "City", "Days", "Employee", "Wage" },
                values: new object[] { 1, "Волгоград", 15, "Владимир Васильевич Марченко", 100000 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessTrips");

            migrationBuilder.CreateTable(
                name: "Localities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Budget = table.Column<int>(type: "int", nullable: false),
                    Budget1 = table.Column<int>(type: "int", nullable: false),
                    Mayor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberResidants = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localities", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Localities",
                columns: new[] { "id", "Budget", "Budget1", "Mayor", "Name", "NumberResidants", "Type" },
                values: new object[] { 1, 100000, 50, "Владимир Васильевич Марченко", "Волгоград", 100000, "City" });
        }
    }
}
