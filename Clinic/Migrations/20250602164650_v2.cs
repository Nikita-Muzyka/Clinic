using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_TitleWorker_TitleId",
                table: "Workers");

            migrationBuilder.DropTable(
                name: "TitleWorker");

            migrationBuilder.DropIndex(
                name: "IX_Workers_TitleId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "Workers");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Workers");

            migrationBuilder.AddColumn<int>(
                name: "TitleId",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TitleWorker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessTitle = table.Column<byte>(type: "tinyint", nullable: false),
                    NameTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitleWorker", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_TitleId",
                table: "Workers",
                column: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_TitleWorker_TitleId",
                table: "Workers",
                column: "TitleId",
                principalTable: "TitleWorker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
