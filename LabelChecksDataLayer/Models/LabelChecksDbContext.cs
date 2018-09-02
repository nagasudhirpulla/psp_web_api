using Microsoft.EntityFrameworkCore;
using PSPDataFetchLayer.Models;
using System;

namespace LabelChecksDataLayer.Models
{
    public class LabelChecksDbContext : DbContext
    {
        public LabelChecksDbContext(DbContextOptions<LabelChecksDbContext> options) : base(options) {
            //DbInitializer.SetLabelSeeds(this);
        }

        public DbSet<PspMeasurement> PspDbMeasurements { get; set; }
        public DbSet<LabelCheck> LabelChecks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PSPMeasDbContext.FluentMethods(modelBuilder);
            // Configure primary key
            modelBuilder.Entity<LabelCheck>().HasKey(l => l.Id);

            //Configure NotNull Columns
            modelBuilder.Entity<LabelCheck>().Property(l => l.CheckType).IsRequired();
            modelBuilder.Entity<LabelCheck>().Property(l => l.ConsiderStartTime).HasDefaultValue(DateTime.Parse("2018-01-01"));
            modelBuilder.Entity<LabelCheck>().Property(l => l.ConsiderEndTime).HasDefaultValue(DateTime.Parse("2030-01-01"));
            modelBuilder.Entity<LabelCheck>().Property(l => l.PspMeasurementId).IsRequired();

            //Configure foriegn keys
            modelBuilder.Entity<LabelCheck>().HasOne(l => l.PspMeasurement).WithMany().HasForeignKey(m => m.PspMeasurementId);

            // set seeds
            //modelBuilder.Entity<PspMeasurement>().HasData(DbInitializer.GetSeeds());
            //DbInitializer.SetLabelSeeds(this);
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
