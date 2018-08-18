using PSPWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PSPWebApi.Data
{
    public class LabelsDbContext : DbContext
    {
        public LabelsDbContext(DbContextOptions<DbContext> options)
            : base(options)
        {

        }

        public DbSet<PspDbMeasurement> PspDbMeasurements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PspDbMeasurement>()
            .HasKey(m => m.ID);

            //modelBuilder.Entity<PspDbMeasurement>()
            //  .Property(p => p.ID).ValueGeneratedOnAdd();

            //modelBuilder.Entity<PspDbMeasurement>()
            //.HasAlternateKey(m => m.Label);

            // AddSeeds
            //modelBuilder.Entity<PspDbMeasurement>().HasData(GetSeeds());

        }

        private object[] GetSeeds()
        {
            object[] objs = new object[] {
                new { Label= "wr_demand", TableName="", TimeColName="", ValColName=""},
                new { Label= "gujarat_demand", TableName="", TimeColName="", ValColName=""}
            };
            return objs;
        }
    }
}

/*
 * https://docs.microsoft.com/en-us/ef/core/modeling/indexes
 * documentation available at https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding 
 */
