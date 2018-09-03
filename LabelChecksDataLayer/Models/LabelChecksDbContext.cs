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
        public DbSet<LabelCheckResult> LabelCheckResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //
            // Configure pspmeasurements from other project
            //
            PSPMeasDbContext.FluentMethods(modelBuilder);

            //
            // Configure label checks
            //
            // Configure primary key
            modelBuilder.Entity<LabelCheck>().HasKey(l => l.Id);
            //Configure NotNull Columns
            modelBuilder.Entity<LabelCheck>().Property(l => l.CheckType).IsRequired();
            modelBuilder.Entity<LabelCheck>().Property(l => l.ConsiderStartTime).IsRequired().HasDefaultValue(LabelCheckUtils.DefaultCheckConsiderStartTime);
            modelBuilder.Entity<LabelCheck>().Property(l => l.ConsiderEndTime).IsRequired().HasDefaultValue(LabelCheckUtils.DefaultCheckConsiderEndTime);
            modelBuilder.Entity<LabelCheck>().Property(l => l.PspMeasurementId).IsRequired();
            //Configure foriegn keys
            modelBuilder.Entity<LabelCheck>().HasOne(l => l.PspMeasurement).WithMany().HasForeignKey(m => m.PspMeasurementId);
            // set seeds
            modelBuilder.Entity<LabelCheck>().HasData(DbInitializer.GetLabelSeeds());

            //
            // Configure label check results
            //
            // Configure table name
            modelBuilder.Entity<LabelCheckResult>().ToTable("LabelCheckResults");
            // Configure primary key
            modelBuilder.Entity<LabelCheckResult>().HasKey(r => r.Id);
            //Configure NotNull Columns
            modelBuilder.Entity<LabelCheckResult>().Property(r => r.IsSuccessful).IsRequired().HasDefaultValue(false);
            modelBuilder.Entity<LabelCheckResult>().Property(r => r.LabelCheckId).IsRequired();
            modelBuilder.Entity<LabelCheckResult>().Property(r => r.CheckProcessStartTime).IsRequired();
            modelBuilder.Entity<LabelCheckResult>().Property(r => r.CheckProcessEndTime).IsRequired();
            //Configure foriegn keys
            modelBuilder.Entity<LabelCheckResult>().HasOne(r => r.LabelCheck).WithMany().HasForeignKey(r => r.LabelCheckId);
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
