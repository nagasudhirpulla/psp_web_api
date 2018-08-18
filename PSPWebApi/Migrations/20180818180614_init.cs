using Microsoft.EntityFrameworkCore.Migrations;

namespace PSPWebApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PspDbMeasurements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Label = table.Column<string>(nullable: false),
                    PspTable = table.Column<string>(nullable: false),
                    PspValCol = table.Column<string>(nullable: false),
                    PspTimeCol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PspDbMeasurements", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PspDbMeasurements",
                columns: new[] { "Id", "Label", "PspTable", "PspTimeCol", "PspValCol" },
                values: new object[] { 1, "Gujarat Demand MU", "STATE_LOAD_DETAILS", "Date", "GujaratDemMu" });

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
