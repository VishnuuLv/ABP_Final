using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Flight.Services.CouponAPI.Migrations
{
    public partial class newone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    couponId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    couponCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    discountPercentage = table.Column<double>(type: "float", nullable: false),
                    maxAmount = table.Column<int>(type: "int", nullable: false),
                    flightId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    validityStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    validityEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.couponId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");
        }
    }
}
