using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherFetchAPI.Migrations
{
    public partial class AddCityFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeZone",
                table: "Cities",
                newName: "OlsonTimeZone");

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Cities",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Cities",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OlsonTimeZone",
                table: "Cities",
                newName: "TimeZone");

            migrationBuilder.AlterColumn<long>(
                name: "Longitude",
                table: "Cities",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<long>(
                name: "Latitude",
                table: "Cities",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }
    }
}
