using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LabelChecksDataLayer.Migrations
{
    public partial class checkparamstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LabelCheckParam",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false),
                    LabelCheckId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelCheckParam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabelCheckParam_LabelChecks_LabelCheckId",
                        column: x => x.LabelCheckId,
                        principalTable: "LabelChecks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabelCheckParam_LabelCheckId",
                table: "LabelCheckParam",
                column: "LabelCheckId");

            migrationBuilder.CreateIndex(
                name: "IX_LabelCheckParam_Name_LabelCheckId",
                table: "LabelCheckParam",
                columns: new[] { "Name", "LabelCheckId" },
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabelCheckParam");
        }
    }
}
