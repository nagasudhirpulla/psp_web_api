﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PSPWebApi.Models;

namespace PSPWebApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180819084106_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

            modelBuilder.Entity("PSPWebApi.Models.PspDbMeasurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EntityCol");

                    b.Property<string>("EntityVal");

                    b.Property<string>("Label")
                        .IsRequired();

                    b.Property<string>("PspTable")
                        .IsRequired();

                    b.Property<string>("PspTimeCol");

                    b.Property<string>("PspValCol")
                        .IsRequired();

                    b.Property<string>("QueryParamVals");

                    b.Property<string>("QueryParams");

                    b.Property<string>("SqlStr");

                    b.HasKey("Id");

                    b.HasIndex("Label")
                        .IsUnique();

                    b.ToTable("PspDbMeasurements");

                    b.HasData(
                        new { Id = 1, EntityCol = "STATE_NAME", EntityVal = "GUJARAT", Label = "gujarat_thermal_mu", PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL" },
                        new { Id = 2, EntityCol = "STATE_NAME", EntityVal = "MAHARASHTRA", Label = "maharashtra_thermal_mu", PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL" },
                        new { Id = 3, EntityCol = "STATE_NAME", EntityVal = "MADHYA PRADESH", Label = "madhya_pradesh_thermal_mu", PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL" },
                        new { Id = 4, EntityCol = "STATE_NAME", EntityVal = "DAMAN AND DIU", Label = "dd_thermal_mu", PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL" },
                        new { Id = 5, EntityCol = "STATE_NAME", EntityVal = "DADRA AND NAGAR HAVELI", Label = "dnh_thermal_mu", PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL" },
                        new { Id = 6, EntityCol = "STATE_NAME", EntityVal = "ESIL", Label = "esil_thermal_mu", PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL" },
                        new { Id = 7, EntityCol = "STATE_NAME", EntityVal = "CHHATISGARH", Label = "chhattisgarh_thermal_mu", PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL" },
                        new { Id = 8, EntityCol = "STATE_NAME", EntityVal = "GOA", Label = "goa_thermal_mu", PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}