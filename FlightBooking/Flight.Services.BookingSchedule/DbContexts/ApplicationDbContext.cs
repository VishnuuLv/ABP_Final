using Flight.Services.BookingSchedule.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.BookingSchedule.DbContexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }



        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Airline> Flight { get; set; }
        public DbSet<ScheduleDetail> ScheduleDetails { get; set; }

        public DbSet<Coupon> coupons { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);


        //    modelBuilder.Entity<Airline>().HasData(new Airline
        //    {
        //        flightId = 1,
        //        flightName = "Air India",
        //        contactNumber = "1234567890",
        //        contactAddress = "Mumbai",
        //        logoURL = "Null"
        //    });
        //    modelBuilder.Entity<Airline>().HasData(new Airline
        //    {
        //        flightId = 2,
        //        flightName = "Vistara",
        //        contactNumber = "1234657890",
        //        contactAddress = "Delhi",
        //        logoURL = "Null"
        //    });
        //    modelBuilder.Entity<Airline>().HasData(new Airline
        //    {
        //        flightId = 3,
        //        flightName = "Go Air",
        //        contactNumber = "1243657890",
        //        contactAddress = "Bangalore",
        //        logoURL = "Null"
        //    });
        //    modelBuilder.Entity<Airline>().HasData(new Airline
        //    {
        //        flightId = 4,
        //        flightName = "Indigo",
        //        contactNumber = "1243658790",
        //        contactAddress = "Mumbai",
        //        logoURL = "Null"
        //    });
        //    modelBuilder.Entity<Airline>().HasData(new Airline
        //    {
        //        flightId = 5,
        //        flightName = "Spice Jet",
        //        contactNumber = "1253658790",
        //        contactAddress = "Chennai",
        //        logoURL = "Null"
        //    });
        //}
    }
}
