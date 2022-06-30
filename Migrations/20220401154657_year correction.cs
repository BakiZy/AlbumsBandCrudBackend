using Microsoft.EntityFrameworkCore.Migrations;

namespace ZavrsniTest.Migrations
{
    public partial class yearcorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 5,
                column: "YearPublish",
                value: 1969);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 5,
                column: "YearPublish",
                value: 11969971);
        }
    }
}
