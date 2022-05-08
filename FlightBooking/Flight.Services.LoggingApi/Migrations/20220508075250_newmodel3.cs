using Microsoft.EntityFrameworkCore.Migrations;

namespace Flight.Services.LoggingApi.Migrations
{
    public partial class newmodel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "logs",
                table: "logs",
                newName: "senderAPI");

            migrationBuilder.AddColumn<string>(
                name: "log",
                table: "logs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "log",
                table: "logs");

            migrationBuilder.RenameColumn(
                name: "senderAPI",
                table: "logs",
                newName: "logs");
        }
    }
}
