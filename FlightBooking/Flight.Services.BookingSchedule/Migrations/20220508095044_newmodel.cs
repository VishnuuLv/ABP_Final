using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Flight.Services.BookingSchedule.Migrations
{
    public partial class newmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    bookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PNR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    scheduleDetailsId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    noOfSeats = table.Column<int>(type: "int", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    departureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    arrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    couponCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    originalTicketCost = table.Column<double>(type: "float", nullable: false),
                    finalticketCost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.bookingId);
                });

            migrationBuilder.CreateTable(
                name: "coupons",
                columns: table => new
                {
                    CouponId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    couponCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    discountPercentage = table.Column<double>(type: "float", nullable: false),
                    maxAmount = table.Column<int>(type: "int", nullable: false),
                    flightId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    validityStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    validityEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coupons", x => x.CouponId);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    flightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    flightName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contactAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    logoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.flightId);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleDetails",
                columns: table => new
                {
                    scheduleDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    flightId = table.Column<int>(type: "int", nullable: false),
                    flightNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fromPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    toPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    scheduledDays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    instrumentused = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    economySeats = table.Column<int>(type: "int", nullable: false),
                    businessClassSeats = table.Column<int>(type: "int", nullable: false),
                    totalSeats = table.Column<int>(type: "int", nullable: false),
                    availableEconomySeats = table.Column<int>(type: "int", nullable: false),
                    availableBusinessClassSeats = table.Column<int>(type: "int", nullable: false),
                    availableTotalSeats = table.Column<int>(type: "int", nullable: false),
                    economyCost = table.Column<double>(type: "float", nullable: false),
                    businessClassCost = table.Column<double>(type: "float", nullable: false),
                    noOfRows = table.Column<int>(type: "int", nullable: false),
                    meal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleDetails", x => x.scheduleDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    passengerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookingId = table.Column<int>(type: "int", nullable: false),
                    passengerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    passengerGender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    passengerAge = table.Column<int>(type: "int", nullable: false),
                    typeOfSeats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    optForMeal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.passengerId);
                    table.ForeignKey(
                        name: "FK_Passengers_Bookings_bookingId",
                        column: x => x.bookingId,
                        principalTable: "Bookings",
                        principalColumn: "bookingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_bookingId",
                table: "Passengers",
                column: "bookingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coupons");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "ScheduleDetails");

            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
