using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hai.MedicalSystem.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamePatientDiseasesKeysToSnakeCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patient_diseases_diseases_DiseasesId",
                table: "patient_diseases");

            migrationBuilder.DropForeignKey(
                name: "FK_patient_diseases_patients_PatientsId",
                table: "patient_diseases");

            migrationBuilder.RenameColumn(
                name: "PatientsId",
                table: "patient_diseases",
                newName: "disease_id");

            migrationBuilder.RenameColumn(
                name: "DiseasesId",
                table: "patient_diseases",
                newName: "patient_id");

            migrationBuilder.RenameIndex(
                name: "IX_patient_diseases_PatientsId",
                table: "patient_diseases",
                newName: "IX_patient_diseases_disease_id");

            migrationBuilder.AddForeignKey(
                name: "FK_patient_diseases_diseases_disease_id",
                table: "patient_diseases",
                column: "disease_id",
                principalTable: "diseases",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_patient_diseases_patients_patient_id",
                table: "patient_diseases",
                column: "patient_id",
                principalTable: "patients",
                principalColumn: "patient_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patient_diseases_diseases_disease_id",
                table: "patient_diseases");

            migrationBuilder.DropForeignKey(
                name: "FK_patient_diseases_patients_patient_id",
                table: "patient_diseases");

            migrationBuilder.RenameColumn(
                name: "disease_id",
                table: "patient_diseases",
                newName: "PatientsId");

            migrationBuilder.RenameColumn(
                name: "patient_id",
                table: "patient_diseases",
                newName: "DiseasesId");

            migrationBuilder.RenameIndex(
                name: "IX_patient_diseases_disease_id",
                table: "patient_diseases",
                newName: "IX_patient_diseases_PatientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_patient_diseases_diseases_DiseasesId",
                table: "patient_diseases",
                column: "DiseasesId",
                principalTable: "diseases",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_patient_diseases_patients_PatientsId",
                table: "patient_diseases",
                column: "PatientsId",
                principalTable: "patients",
                principalColumn: "patient_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
