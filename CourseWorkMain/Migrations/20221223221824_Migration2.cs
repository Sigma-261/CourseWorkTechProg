using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseWorkMain.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Budget1",
                table: "Localities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Localities",
                keyColumn: "id",
                keyValue: 1,
                column: "Budget1",
                value: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Budget1",
                table: "Localities");
        }
    }
}
