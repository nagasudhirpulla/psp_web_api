using Microsoft.EntityFrameworkCore;


namespace PSPDataFetchLayer.Models
{
    public class PSPMeasDbContext : DbContext
    {
        public PSPMeasDbContext(DbContextOptions<PSPMeasDbContext> options) : base(options) { }

        //public PSPMeasDbContext(string connStr) {
        //    var builder = new DbContextOptionsBuilder<PSPMeasDbContext>()
        //        .UseSqlServer<PSPMeasDbContext>(connStr);
        //}

        public DbSet<PspMeasurement> PspDbMeasurements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //// Configure primary key
            //modelBuilder.Entity<PspMeasurement>().HasKey(s => s.MeasId);

            //// Configure uniue/alternate key
            //modelBuilder.Entity<PspMeasurement>().HasIndex(m => m.Label).IsUnique();

            ////Configure NotNull Columns
            //modelBuilder.Entity<PspMeasurement>().Property(p => p.Label).IsRequired();
            //modelBuilder.Entity<PspMeasurement>().Property(p => p.PspTable).IsRequired();
            //modelBuilder.Entity<PspMeasurement>().Property(p => p.PspValCol).IsRequired();

            //// set seeds
            //modelBuilder.Entity<PspMeasurement>().HasData(DbInitializer.GetSeeds());
            FluentMethods(modelBuilder);
        }

        public static void FluentMethods(ModelBuilder modelBuilder)
        {
            // Configure primary key
            modelBuilder.Entity<PspMeasurement>().HasKey(s => s.MeasId);

            // Configure uniue/alternate key
            modelBuilder.Entity<PspMeasurement>().HasIndex(m => m.Label).IsUnique();

            //Configure NotNull Columns
            modelBuilder.Entity<PspMeasurement>().Property(p => p.Label).IsRequired();
            modelBuilder.Entity<PspMeasurement>().Property(p => p.PspTable).IsRequired();
            modelBuilder.Entity<PspMeasurement>().Property(p => p.PspValCol).IsRequired();

            // set seeds
            //modelBuilder.Entity<PspMeasurement>().HasData(DbInitializer.GetSeeds());
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseOracle(@"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SID=xe)));User Id=psplabels;Password=123;");
        //}
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
