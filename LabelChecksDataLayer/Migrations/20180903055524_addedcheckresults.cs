using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LabelChecksDataLayer.Migrations
{
    public partial class addedcheckresults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LabelCheckResult",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsSuccessful = table.Column<bool>(nullable: false, defaultValue: false),
                    CheckProcessStartTime = table.Column<DateTime>(nullable: false),
                    CheckProcessEndTime = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    LabelCheckId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelCheckResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabelCheckResult_LabelChecks_LabelCheckId",
                        column: x => x.LabelCheckId,
                        principalTable: "LabelChecks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabelCheckResult_LabelCheckId",
                table: "LabelCheckResult",
                column: "LabelCheckId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabelCheckResult");
        }
    }
}
