using Microsoft.EntityFrameworkCore;
using Flight.Services.ManageAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.ManageAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        
        }
        public DbSet<Airline> Flight { get; set; }
        //public DbSet<ScheduleDetails> ScheduleDetail { get; set; }
    }
}
