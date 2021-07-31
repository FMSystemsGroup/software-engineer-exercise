using Microsoft.EntityFrameworkCore.Migrations;

namespace FMSystems.WeatherForecast.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Country", "Latitude", "Longitude", "Name", "State" },
                values: new object[,]
                {
                    { 1, "US", 33.448376000000003, -112.07403600000001, "Phoenix", "AZ" },
                    { 2, "US", 35.787742999999999, -78.644256999999996, "Raleigh", "NC" },
                    { 3, "CA", 45.273918000000002, -66.067656999999997, "Saint John", "NB" },
                    { 4, "US", 32.715736, -117.16108699999999, "San Diego", "CA" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
