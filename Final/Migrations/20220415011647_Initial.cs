using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    QuoteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quote = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Citation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.QuoteId);
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuoteId", "Author", "Citation", "Date", "Quote", "Subject" },
                values: new object[] { 1, "Cairo", null, null, "hello there", null });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuoteId", "Author", "Citation", "Date", "Quote", "Subject" },
                values: new object[] { 2, "Hilton", null, null, "gotcha", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");
        }
    }
}
