using Microsoft.EntityFrameworkCore;

namespace PSPWebApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<PspDbMeasurement> PspDbMeasurements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PspDbMeasurement>().HasData(
                 new PspDbMeasurement { Id = 1, Label = "Gujarat Demand MU", PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "Date", PspValCol = "GujaratDemMu" }
             );

            modelBuilder.Entity<PspDbMeasurement>()
            .HasIndex(m => m.Label)
            .IsUnique();
        }
    }
}

/*
 * https://docs.microsoft.com/en-us/ef/core/modeling/indexes
 * documentation available at https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding 
 * 
 * examples
 * https://www.c-sharpcorner.com/article/getting-started-with-entity-framework-core-2-0-asp-net-core-2-0/
 * 
 */
