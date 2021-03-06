﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSPDataFetchLayer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PspDbMeasurements",
                columns: table => new
                {
                    MeasId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Label = table.Column<string>(nullable: false),
                    PspTable = table.Column<string>(nullable: false),
                    PspValCol = table.Column<string>(nullable: false),
                    PspTimeCol = table.Column<string>(nullable: true),
                    EntityCol = table.Column<string>(nullable: true),
                    EntityVal = table.Column<string>(nullable: true),
                    SqlStr = table.Column<string>(nullable: true),
                    QueryParams = table.Column<string>(nullable: true),
                    QueryParamVals = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PspDbMeasurements", x => x.MeasId);
                });

            migrationBuilder.InsertData(
                table: "PspDbMeasurements",
                columns: new[] { "MeasId", "EntityCol", "EntityVal", "Label", "PspTable", "PspTimeCol", "PspValCol", "QueryParamVals", "QueryParams", "SqlStr" },
                values: new object[,]
                {
                    { 1, "STATE_NAME", "GUJARAT", "gujarat_thermal_mu", "STATE_LOAD_DETAILS", "DATE_KEY", "THERMAL", null, null, null },
                    { 2, "STATE_NAME", "MAHARASHTRA", "maharashtra_thermal_mu", "STATE_LOAD_DETAILS", "DATE_KEY", "THERMAL", null, null, null },
                    { 3, "STATE_NAME", "MADHYA PRADESH", "madhya_pradesh_thermal_mu", "STATE_LOAD_DETAILS", "DATE_KEY", "THERMAL", null, null, null },
                    { 4, "STATE_NAME", "DAMAN AND DIU", "dd_thermal_mu", "STATE_LOAD_DETAILS", "DATE_KEY", "THERMAL", null, null, null },
                    { 5, "STATE_NAME", "DADRA AND NAGAR HAVELI", "dnh_thermal_mu", "STATE_LOAD_DETAILS", "DATE_KEY", "THERMAL", null, null, null },
                    { 6, "STATE_NAME", "ESIL", "esil_thermal_mu", "STATE_LOAD_DETAILS", "DATE_KEY", "THERMAL", null, null, null },
                    { 7, "STATE_NAME", "CHHATISGARH", "chhattisgarh_thermal_mu", "STATE_LOAD_DETAILS", "DATE_KEY", "THERMAL", null, null, null },
                    { 8, "STATE_NAME", "GOA", "goa_thermal_mu", "STATE_LOAD_DETAILS", "DATE_KEY", "THERMAL", null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PspDbMeasurements_Label",
                table: "PspDbMeasurements",
                column: "Label",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PspDbMeasurements");
        }
    }
}
