using Microsoft.EntityFrameworkCore.Migrations;

namespace SimbirsoftWorkshop.WebApi.Migrations
{
    public partial class AddUniqueIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_LibraryCards_BookId",
                table: "LibraryCards",
                column: "BookId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LibraryCards_BookId",
                table: "LibraryCards");
        }
    }
}
