using Microsoft.EntityFrameworkCore.Migrations;

namespace praca_magisterska.DAL.Migrations
{
    public partial class four : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USER_CLASS_ClassID",
                table: "USER");

            migrationBuilder.DropForeignKey(
                name: "FK_USER_ROLE_RoleID",
                table: "USER");

            migrationBuilder.DropIndex(
                name: "IX_USER_RoleID",
                table: "USER");

            migrationBuilder.AlterColumn<long>(
                name: "RoleID",
                table: "USER",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ClassID",
                table: "USER",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_USER_RoleID",
                table: "USER",
                column: "RoleID",
                unique: true,
                filter: "[RoleID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_USER_CLASS_ClassID",
                table: "USER",
                column: "ClassID",
                principalTable: "CLASS",
                principalColumn: "ClassID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_USER_ROLE_RoleID",
                table: "USER",
                column: "RoleID",
                principalTable: "ROLE",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USER_CLASS_ClassID",
                table: "USER");

            migrationBuilder.DropForeignKey(
                name: "FK_USER_ROLE_RoleID",
                table: "USER");

            migrationBuilder.DropIndex(
                name: "IX_USER_RoleID",
                table: "USER");

            migrationBuilder.AlterColumn<long>(
                name: "RoleID",
                table: "USER",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ClassID",
                table: "USER",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_USER_RoleID",
                table: "USER",
                column: "RoleID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_USER_CLASS_ClassID",
                table: "USER",
                column: "ClassID",
                principalTable: "CLASS",
                principalColumn: "ClassID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_USER_ROLE_RoleID",
                table: "USER",
                column: "RoleID",
                principalTable: "ROLE",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
