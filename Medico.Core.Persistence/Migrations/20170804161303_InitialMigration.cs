using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Medico.Core.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    MedicationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HumanReadableName = table.Column<string>(nullable: true),
                    InitialDoseTime = table.Column<DateTime>(nullable: true),
                    MaximumNumberOfDoses = table.Column<int>(nullable: false),
                    MedicalName = table.Column<string>(nullable: true),
                    MedicationNoLongerActiveDate = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    PerscribedDosage = table.Column<int>(nullable: false),
                    TimeBetweenDoses = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.MedicationId);
                });

            migrationBuilder.CreateTable(
                name: "MedicationActionTimes",
                columns: table => new
                {
                    MedicationActionTimeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MedicationId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    TimeActioned = table.Column<DateTime>(nullable: true),
                    TimeToAction = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationActionTimes", x => x.MedicationActionTimeId);
                    table.ForeignKey(
                        name: "FK_MedicationActionTimes_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "MedicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicationActionTimes_MedicationId",
                table: "MedicationActionTimes",
                column: "MedicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicationActionTimes");

            migrationBuilder.DropTable(
                name: "Medications");
        }
    }
}
