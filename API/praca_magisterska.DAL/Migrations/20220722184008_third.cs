using Microsoft.EntityFrameworkCore.Migrations;

namespace praca_magisterska.DAL.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClassID",
                table: "SUBJECTS",
                newName: "Class_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Class_ID",
                table: "SUBJECTS",
                newName: "ClassID");
        }
    }
}
