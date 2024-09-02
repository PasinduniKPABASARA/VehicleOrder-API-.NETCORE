using Microsoft.EntityFrameworkCore;
using VehicleOrderAPI.Models;

namespace VehicleOrderAPI.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { 
        }
    }

}

