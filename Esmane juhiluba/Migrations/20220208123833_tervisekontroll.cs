using Microsoft.EntityFrameworkCore.Migrations;

namespace Esmane_juhiluba.Migrations
{
    public partial class tervisekontroll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Perenimi",
                table: "Eksam",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Eesnimi",
                table: "Eksam",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tervisekontroll",
                table: "Eksam",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Eksam_Eesnimi_Perenimi",
                table: "Eksam",
                columns: new[] { "Eesnimi", "Perenimi" },
                unique: true,
                filter: "[Eesnimi] IS NOT NULL AND [Perenimi] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Eksam_Eesnimi_Perenimi",
                table: "Eksam");

            migrationBuilder.DropColumn(
                name: "Tervisekontroll",
                table: "Eksam");

            migrationBuilder.AlterColumn<string>(
                name: "Perenimi",
                table: "Eksam",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Eesnimi",
                table: "Eksam",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
