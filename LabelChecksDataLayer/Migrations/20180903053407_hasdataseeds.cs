using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LabelChecksDataLayer.Migrations
{
    public partial class hasdataseeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LabelChecks",
                columns: new[] { "Id", "CheckType", "ConsiderEndTime", "ConsiderStartTime", "Num1", "Num2", "PspMeasurementId" },
                values: new object[] { 1, "not_null", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, 1 });

            migrationBuilder.InsertData(
                table: "LabelChecks",
                columns: new[] { "Id", "CheckType", "ConsiderEndTime", "ConsiderStartTime", "Num1", "Num2", "PspMeasurementId" },
                values: new object[] { 2, "not_null", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LabelChecks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LabelChecks",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
