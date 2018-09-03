using Microsoft.EntityFrameworkCore.Migrations;

namespace LabelChecksDataLayer.Migrations
{
    public partial class nullablenumbers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Num2",
                table: "LabelChecks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Num1",
                table: "LabelChecks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "LabelChecks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Num1", "Num2" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "LabelChecks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Num1", "Num2" },
                values: new object[] { null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Num2",
                table: "LabelChecks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Num1",
                table: "LabelChecks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "LabelChecks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Num1", "Num2" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "LabelChecks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Num1", "Num2" },
                values: new object[] { 0, 0 });
        }
    }
}
