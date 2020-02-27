using Microsoft.EntityFrameworkCore.Migrations;

namespace LivePass.Migrations
{
    public partial class AtualizarCasaShow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "CasaShows",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "CasaShows");
        }
    }
}
