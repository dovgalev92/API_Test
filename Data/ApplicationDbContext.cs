using API_Test.Models.Entity;
using Microsoft.EntityFrameworkCore;
namespace API_Test.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options) { }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseRoom> WarehouseRooms { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
