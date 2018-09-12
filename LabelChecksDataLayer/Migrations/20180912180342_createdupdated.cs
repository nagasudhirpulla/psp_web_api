using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LabelChecksDataLayer.Migrations
{
    public partial class createdupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "LabelCheckResults",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "LabelCheckResults",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "LabelCheckResults");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "LabelCheckResults");
        }
    }
}
