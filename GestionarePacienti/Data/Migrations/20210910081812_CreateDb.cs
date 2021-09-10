using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionarePacienti.Data.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    County = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    City = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfAppointment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Symptoms = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Diagnostic = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DiagnosticCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Recommandation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentDetails_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppointmentDetails_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "Email", "Name", "Specialization" },
                values: new object[,]
                {
                    { 1, "", "Dr. Test Unu", 1 },
                    { 2, "", "Dr. Test Doi", 4 },
                    { 3, "", "Dr. Test Trei", 3 }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "Address", "City", "County", "DateOfBirth", "Email", "Gender", "MaritalStatus", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "no 51, Test Street", "Oradea", "Bihor", new DateTime(1980, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, "John Doe", "0777777777" },
                    { 2, "no 10, Test2 Street", "Alesd", "Bihor", new DateTime(1990, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, 1, "Jane Doe", "0777111222" },
                    { 3, "no 20, Test3 Street", "Marghita", "Bihor", new DateTime(2000, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, 0, "Jessica Doe", "0772333444" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDetails_DoctorId",
                table: "AppointmentDetails",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDetails_PatientId",
                table: "AppointmentDetails",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentDetails");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
