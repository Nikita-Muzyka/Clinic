using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    /// <inheritdoc />
    public partial class _110 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Workers",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Contact",
                table: "Workers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Contact",
                table: "Patients",
                newName: "Phone");

            migrationBuilder.AlterColumn<string>(
                name: "Place",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Workers",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Workers",
                newName: "Contact");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Patients",
                newName: "Contact");

            migrationBuilder.AlterColumn<string>(
                name: "Place",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
