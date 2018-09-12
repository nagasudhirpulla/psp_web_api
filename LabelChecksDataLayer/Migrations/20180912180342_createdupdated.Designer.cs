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
    [Migration("20180912180342_createdupdated")]
    partial class createdupdated
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

                    b.Property<int?>("Num1");

                    b.Property<int?>("Num2");

                    b.Property<int>("PspMeasurementId");

                    b.HasKey("Id");

                    b.HasIndex("PspMeasurementId");

                    b.ToTable("LabelChecks");
                });

            modelBuilder.Entity("LabelChecksDataLayer.Models.LabelCheckResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CheckProcessEndTime");

                    b.Property<DateTime>("CheckProcessStartTime");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<bool>("IsSuccessful");

                    b.Property<int>("LabelCheckId");

                    b.Property<string>("Remarks");

                    b.HasKey("Id");

                    b.HasIndex("LabelCheckId");

                    b.ToTable("LabelCheckResults");
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
                });

            modelBuilder.Entity("LabelChecksDataLayer.Models.LabelCheck", b =>
                {
                    b.HasOne("PSPDataFetchLayer.Models.PspMeasurement", "PspMeasurement")
                        .WithMany()
                        .HasForeignKey("PspMeasurementId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LabelChecksDataLayer.Models.LabelCheckResult", b =>
                {
                    b.HasOne("LabelChecksDataLayer.Models.LabelCheck", "LabelCheck")
                        .WithMany()
                        .HasForeignKey("LabelCheckId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
