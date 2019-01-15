using Microsoft.EntityFrameworkCore.Migrations;

namespace NewVidly2.Migrations
{
    public partial class removeNewsletterProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSubscribedToNewsletter",
                table: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSubscribedToNewsletter",
                table: "Customers",
                nullable: false,
                defaultValue: false);
        }
    }
}
