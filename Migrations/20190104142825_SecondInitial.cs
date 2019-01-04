using Microsoft.EntityFrameworkCore.Migrations;

namespace NewVidly2.Migrations
{
    public partial class SecondInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Genres",
            //    columns: table => new
            //    {
            //        Id = table.Column<byte>(nullable: false),
            //        Name = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Genres", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "MembershipTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<byte>(nullable: false),
            //        SignUpFee = table.Column<short>(nullable: false),
            //        DurationInMonths = table.Column<byte>(nullable: false),
            //        DiscountRate = table.Column<byte>(nullable: false),
            //        Name = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MembershipTypes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Movies",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: false),
            //        Description = table.Column<string>(nullable: true),
            //        GenreId = table.Column<byte>(nullable: false),
            //        ReleasedDate = table.Column<DateTime>(nullable: true),
            //        DateAdded = table.Column<DateTime>(nullable: false),
            //        NumberInStock = table.Column<int>(nullable: true),
            //        NumberAvailable = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Movies", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Movies_Genres_GenreId",
            //            column: x => x.GenreId,
            //            principalTable: "Genres",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Customers",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(maxLength: 255, nullable: false),
            //        IsSubscribetToNewsletter = table.Column<bool>(nullable: false),
            //        MembershipTypeId = table.Column<byte>(nullable: false),
            //        BirthdayDate = table.Column<DateTime>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Customers", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Customers_MembershipTypes_MembershipTypeId",
            //            column: x => x.MembershipTypeId,
            //            principalTable: "MembershipTypes",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Rentals",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        MovieId = table.Column<int>(nullable: false),
            //        CustomerId = table.Column<int>(nullable: false),
            //        DateRented = table.Column<DateTime>(nullable: false),
            //        DateReturned = table.Column<DateTime>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Rentals", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Rentals_Customers_CustomerId",
            //            column: x => x.CustomerId,
            //            principalTable: "Customers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Rentals_Movies_MovieId",
            //            column: x => x.MovieId,
            //            principalTable: "Movies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Customers_MembershipTypeId",
            //    table: "Customers",
            //    column: "MembershipTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Movies_GenreId",
            //    table: "Movies",
            //    column: "GenreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Rentals_CustomerId",
            //    table: "Rentals",
            //    column: "CustomerId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Rentals_MovieId",
            //    table: "Rentals",
            //    column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Rentals");

            //migrationBuilder.DropTable(
            //    name: "Customers");

            //migrationBuilder.DropTable(
            //    name: "Movies");

            //migrationBuilder.DropTable(
            //    name: "MembershipTypes");

            //migrationBuilder.DropTable(
            //    name: "Genres");
        }
    }
}
