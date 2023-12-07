using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionHopital.Migrations
{
    public partial class mg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Charges_Per_Visit",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "MonthlySalary",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Patients_Treated",
                table: "Doctors");

            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img",
                table: "Doctors");

            migrationBuilder.AddColumn<float>(
                name: "Charges_Per_Visit",
                table: "Doctors",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MonthlySalary",
                table: "Doctors",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Patients_Treated",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
