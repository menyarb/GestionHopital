using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionHopital.Migrations
{
    public partial class mg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LoginID",
                table: "OtherStaffs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "OtherStaffs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LoginID",
                table: "Admins",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_OtherStaffs_LoginID",
                table: "OtherStaffs",
                column: "LoginID");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_LoginID",
                table: "Admins",
                column: "LoginID");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Logins_LoginID",
                table: "Admins",
                column: "LoginID",
                principalTable: "Logins",
                principalColumn: "LoginID");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherStaffs_Logins_LoginID",
                table: "OtherStaffs",
                column: "LoginID",
                principalTable: "Logins",
                principalColumn: "LoginID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Logins_LoginID",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherStaffs_Logins_LoginID",
                table: "OtherStaffs");

            migrationBuilder.DropIndex(
                name: "IX_OtherStaffs_LoginID",
                table: "OtherStaffs");

            migrationBuilder.DropIndex(
                name: "IX_Admins_LoginID",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "role",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "LoginID",
                table: "OtherStaffs");

            migrationBuilder.DropColumn(
                name: "role",
                table: "OtherStaffs");

            migrationBuilder.DropColumn(
                name: "LoginID",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "role",
                table: "Admins");
        }
    }
}
