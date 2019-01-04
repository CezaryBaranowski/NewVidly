using Microsoft.EntityFrameworkCore.Migrations;

namespace NewVidly2.Migrations
{
    public partial class AddedBoxofficeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Boxoffice",
                table: "Movies",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Boxoffice",
                table: "Movies");
        }
    }
}
