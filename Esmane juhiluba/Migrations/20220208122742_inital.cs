using Microsoft.EntityFrameworkCore.Migrations;

namespace Esmane_juhiluba.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eksam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Eesnimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Perenimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Teooria = table.Column<int>(type: "int", nullable: false),
                    Sõidu = table.Column<int>(type: "int", nullable: false),
                    Luba = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eksam", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eksam");
        }
    }
}
