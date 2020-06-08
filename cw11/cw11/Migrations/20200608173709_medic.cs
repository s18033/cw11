using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cw11.Migrations
{
    public partial class medic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    IdDoctor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.IdDoctor);
                });

            migrationBuilder.CreateTable(
                name: "Medicaments",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicaments", x => x.IdMedicament);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    IdPatient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.IdPatient);
                });

            migrationBuilder.CreateTable(
                name: "Prescription_Medicaments",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(nullable: false),
                    IdPrescription = table.Column<int>(nullable: false),
                    Dose = table.Column<int>(nullable: true),
                    Details = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription_Medicaments", x => new { x.IdMedicament, x.IdPrescription });
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    IdPatient = table.Column<int>(nullable: false),
                    IdDoctor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.IdPrescription);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "jan.kowal@poczta.pl", "Jan", "Kowalski" },
                    { 2, "mat.nowak@poczta.pl", "Mateusz", "Nowak" },
                    { 3, "piotr.kwiatek@poczta.pl", "Piotr", "Kwiatek" },
                    { 4, "doktor.dolittle@poczta.pl", "Doktor", "Dolittle" }
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Lek na wszystko, media nie kłamią", "Etopiryna", "Tabletka" },
                    { 2, "Na katar", "Roznosol", "Dożylnie" },
                    { 3, "Na skórę i paznokcie", "WigorPlus", "Proszki" },
                    { 4, "Na problemy z oddychaniem", "Wkurzosol", "Dożylnie" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 4, new DateTime(1930, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stanisław", "Czapka" },
                    { 3, new DateTime(1925, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maria", "NapewnonieCurieXD" },
                    { 1, new DateTime(1970, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chory", "Nowacki" },
                    { 2, new DateTime(1983, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Janina", "Malarska" }
                });

            migrationBuilder.InsertData(
                table: "Prescription_Medicaments",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[,]
                {
                    { 2, 2, "Raz dziennie rano", 1 },
                    { 1, 1, "Dwa razy dziennie po posiłku", 2 },
                    { 3, 3, "Trzy razy dziennie przed posiłkiem", 3 }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 8, 19, 37, 8, 939, DateTimeKind.Local).AddTicks(7459), new DateTime(2020, 7, 8, 19, 37, 8, 943, DateTimeKind.Local).AddTicks(8182), 1, 1 },
                    { 2, new DateTime(2020, 6, 8, 19, 37, 8, 944, DateTimeKind.Local).AddTicks(323), new DateTime(2020, 11, 8, 19, 37, 8, 944, DateTimeKind.Local).AddTicks(365), 1, 2 },
                    { 3, new DateTime(2020, 6, 8, 19, 37, 8, 944, DateTimeKind.Local).AddTicks(402), new DateTime(2020, 8, 8, 19, 37, 8, 944, DateTimeKind.Local).AddTicks(408), 3, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Medicaments");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Prescription_Medicaments");

            migrationBuilder.DropTable(
                name: "Prescriptions");
        }
    }
}
