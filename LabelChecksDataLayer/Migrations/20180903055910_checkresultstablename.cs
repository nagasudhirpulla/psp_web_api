using Microsoft.EntityFrameworkCore.Migrations;

namespace LabelChecksDataLayer.Migrations
{
    public partial class checkresultstablename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabelCheckResult_LabelChecks_LabelCheckId",
                table: "LabelCheckResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LabelCheckResult",
                table: "LabelCheckResult");

            migrationBuilder.RenameTable(
                name: "LabelCheckResult",
                newName: "LabelCheckResults");

            migrationBuilder.RenameIndex(
                name: "IX_LabelCheckResult_LabelCheckId",
                table: "LabelCheckResults",
                newName: "IX_LabelCheckResults_LabelCheckId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LabelCheckResults",
                table: "LabelCheckResults",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LabelCheckResults_LabelChecks_LabelCheckId",
                table: "LabelCheckResults",
                column: "LabelCheckId",
                principalTable: "LabelChecks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabelCheckResults_LabelChecks_LabelCheckId",
                table: "LabelCheckResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LabelCheckResults",
                table: "LabelCheckResults");

            migrationBuilder.RenameTable(
                name: "LabelCheckResults",
                newName: "LabelCheckResult");

            migrationBuilder.RenameIndex(
                name: "IX_LabelCheckResults_LabelCheckId",
                table: "LabelCheckResult",
                newName: "IX_LabelCheckResult_LabelCheckId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LabelCheckResult",
                table: "LabelCheckResult",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LabelCheckResult_LabelChecks_LabelCheckId",
                table: "LabelCheckResult",
                column: "LabelCheckId",
                principalTable: "LabelChecks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
