using Microsoft.EntityFrameworkCore.Migrations;

namespace SimbirsoftWorkshop.WebApi.Migrations
{
    public partial class Alter_Indexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_People_FirstName_LastName_MiddleName",
                table: "People");

            migrationBuilder.CreateIndex(
                name: "IX_People_FirstName_LastName_MiddleName_Birthday",
                table: "People",
                columns: new[] { "FirstName", "LastName", "MiddleName", "Birthday" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_People_FirstName_LastName_MiddleName_Birthday",
                table: "People");

            migrationBuilder.CreateIndex(
                name: "IX_People_FirstName_LastName_MiddleName",
                table: "People",
                columns: new[] { "FirstName", "LastName", "MiddleName" },
                unique: true);
        }
    }
}
