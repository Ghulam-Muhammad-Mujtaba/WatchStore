using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchStore.DataAccess.Migrations
{
    public partial class AddDialToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diameter = table.Column<int>(type: "int", nullable: false),
                    Thickness = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dials", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dials");
        }
    }
}
