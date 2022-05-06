using Microsoft.EntityFrameworkCore.Migrations;

namespace Flight.Services.BookingSchedule.Migrations
{
    public partial class changecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "flightnumber",
                table: "ScheduleDetails",
                newName: "flightNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "flightNumber",
                table: "ScheduleDetails",
                newName: "flightnumber");
        }
    }
}
