using Microsoft.EntityFrameworkCore;
namespace Hall_App.Models
{
    public class Hall_DbContext : DbContext
    {
        public DbSet<ArcadeHall> arcadeHall { get; set; }

        public Hall_DbContext(DbContextOptions<Hall_DbContext> options) : base(options) {
            Database.EnsureCreated();
                }
    }

}
