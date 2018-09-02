﻿// <auto-generated />
using System;
using LabelChecksDataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LabelChecksDataLayer.Migrations
{
    [DbContext(typeof(LabelChecksDbContext))]
    [Migration("20180902191945_addedseed")]
    partial class addedseed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LabelChecksDataLayer.Models.LabelCheck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CheckType")
                        .IsRequired();

                    b.Property<DateTime>("ConsiderEndTime")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2030, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<DateTime>("ConsiderStartTime")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

                    b.Property<int>("Num1");

                    b.Property<int>("Num2");

                    b.Property<int>("PspMeasurementId");

                    b.HasKey("Id");

                    b.HasIndex("PspMeasurementId");

                    b.ToTable("LabelChecks");
                });

            modelBuilder.Entity("PSPDataFetchLayer.Models.PspMeasurement", b =>
                {
                    b.Property<int>("MeasId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.HasKey("MeasId");

                    b.HasIndex("Label")
                        .IsUnique();

                    b.ToTable("PspDbMeasurements");

                    b.HasData(
                        new { MeasId = 1, EntityCol = "STATE_NAME", EntityVal = "GUJARAT", Label = "gujarat_thermal_mu", PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL" },
                        new { MeasId = 2, EntityCol = "STATE_NAME", EntityVal = "MAHARASHTRA", Label = "maharashtra_thermal_mu", PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL" },
                        new { MeasId = 3, EntityCol = "STATE_NAME", EntityVal = "MADHYA PRADESH", Label = "madhya_pradesh_thermal_mu", PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL" },
                        new { MeasId = 4, EntityCol = "STATE_NAME", EntityVal = "DAMAN AND DIU", Label = "dd_thermal_mu", PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL" },
                        new { MeasId = 5, EntityCol = "STATE_NAME", EntityVal = "DADRA AND NAGAR HAVELI", Label = "dnh_thermal_mu", PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL" },
                        new { MeasId = 6, EntityCol = "STATE_NAME", EntityVal = "ESIL", Label = "esil_thermal_mu", PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL" },
                        new { MeasId = 7, EntityCol = "STATE_NAME", EntityVal = "CHHATISGARH", Label = "chhattisgarh_thermal_mu", PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL" },
                        new { MeasId = 8, EntityCol = "STATE_NAME", EntityVal = "GOA", Label = "goa_thermal_mu", PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL" }
                    );
                });

            modelBuilder.Entity("LabelChecksDataLayer.Models.LabelCheck", b =>
                {
                    b.HasOne("PSPDataFetchLayer.Models.PspMeasurement", "PspMeasurement")
                        .WithMany()
                        .HasForeignKey("PspMeasurementId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
