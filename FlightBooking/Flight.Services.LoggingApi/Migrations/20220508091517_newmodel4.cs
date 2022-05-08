using Microsoft.EntityFrameworkCore.Migrations;

namespace Flight.Services.LoggingApi.Migrations
{
    public partial class newmodel4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "task",
                table: "logs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "task",
                table: "logs");
        }
    }
}
