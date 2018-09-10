using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LabelChecksDataLayer.Migrations
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

            migrationBuilder.CreateTable(
                name: "LabelChecks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckType = table.Column<string>(nullable: false),
                    Num1 = table.Column<int>(nullable: true),
                    Num2 = table.Column<int>(nullable: true),
                    ConsiderStartTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    ConsiderEndTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2030, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    PspMeasurementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelChecks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabelChecks_PspDbMeasurements_PspMeasurementId",
                        column: x => x.PspMeasurementId,
                        principalTable: "PspDbMeasurements",
                        principalColumn: "MeasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LabelCheckResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsSuccessful = table.Column<bool>(nullable: false),
                    CheckProcessStartTime = table.Column<DateTime>(nullable: false),
                    CheckProcessEndTime = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    LabelCheckId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelCheckResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabelCheckResults_LabelChecks_LabelCheckId",
                        column: x => x.LabelCheckId,
                        principalTable: "LabelChecks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabelCheckResults_LabelCheckId",
                table: "LabelCheckResults",
                column: "LabelCheckId");

            migrationBuilder.CreateIndex(
                name: "IX_LabelChecks_PspMeasurementId",
                table: "LabelChecks",
                column: "PspMeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_PspDbMeasurements_Label",
                table: "PspDbMeasurements",
                column: "Label",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabelCheckResults");

            migrationBuilder.DropTable(
                name: "LabelChecks");

            migrationBuilder.DropTable(
                name: "PspDbMeasurements");
        }
    }
}
