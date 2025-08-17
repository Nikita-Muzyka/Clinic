using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateBrith",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "DateBrith",
                table: "Patients");

            migrationBuilder.AlterColumn<DateTime>(
                name: "YearsCreate",
                table: "Workers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Workers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "YearsCreate",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "YearsCreate",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "DateBrith",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "YearsCreate",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "DateBrith",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
