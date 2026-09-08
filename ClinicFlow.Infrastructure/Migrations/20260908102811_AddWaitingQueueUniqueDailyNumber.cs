using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddWaitingQueueUniqueDailyNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UX_Queues_Clinic_Date_Number",
                table: "WaitingQueues");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 381, DateTimeKind.Utc).AddTicks(1556));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 381, DateTimeKind.Utc).AddTicks(1564));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 381, DateTimeKind.Utc).AddTicks(1568));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 381, DateTimeKind.Utc).AddTicks(1572));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 381, DateTimeKind.Utc).AddTicks(1575));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 381, DateTimeKind.Utc).AddTicks(1582));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 381, DateTimeKind.Utc).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 381, DateTimeKind.Utc).AddTicks(1589));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 387, DateTimeKind.Utc).AddTicks(2352));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 387, DateTimeKind.Utc).AddTicks(2359));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 387, DateTimeKind.Utc).AddTicks(2363));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 387, DateTimeKind.Utc).AddTicks(2367));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 387, DateTimeKind.Utc).AddTicks(2371));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 387, DateTimeKind.Utc).AddTicks(2379));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 387, DateTimeKind.Utc).AddTicks(2382));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 390, DateTimeKind.Utc).AddTicks(6521));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 390, DateTimeKind.Utc).AddTicks(6527));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 390, DateTimeKind.Utc).AddTicks(6530));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 390, DateTimeKind.Utc).AddTicks(6533));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 390, DateTimeKind.Utc).AddTicks(6535));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 390, DateTimeKind.Utc).AddTicks(6540));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 390, DateTimeKind.Utc).AddTicks(6557));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 390, DateTimeKind.Utc).AddTicks(6560));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 388, DateTimeKind.Utc).AddTicks(6088));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 388, DateTimeKind.Utc).AddTicks(6103));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 388, DateTimeKind.Utc).AddTicks(6108));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 388, DateTimeKind.Utc).AddTicks(6112));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 388, DateTimeKind.Utc).AddTicks(6117));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 388, DateTimeKind.Utc).AddTicks(6136));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 388, DateTimeKind.Utc).AddTicks(6142));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 388, DateTimeKind.Utc).AddTicks(6146));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 391, DateTimeKind.Utc).AddTicks(6546));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 391, DateTimeKind.Utc).AddTicks(6569));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 391, DateTimeKind.Utc).AddTicks(6573));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 391, DateTimeKind.Utc).AddTicks(6577));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 391, DateTimeKind.Utc).AddTicks(6580));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 391, DateTimeKind.Utc).AddTicks(6586));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 391, DateTimeKind.Utc).AddTicks(6590));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 391, DateTimeKind.Utc).AddTicks(6594));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 391, DateTimeKind.Utc).AddTicks(6597));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 391, DateTimeKind.Utc).AddTicks(6602));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 391, DateTimeKind.Utc).AddTicks(6606));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 391, DateTimeKind.Utc).AddTicks(6609));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 391, DateTimeKind.Utc).AddTicks(6613));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 391, DateTimeKind.Utc).AddTicks(6617));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 391, DateTimeKind.Utc).AddTicks(6620));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 394, DateTimeKind.Utc).AddTicks(7908));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 394, DateTimeKind.Utc).AddTicks(7925));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 394, DateTimeKind.Utc).AddTicks(7928));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 394, DateTimeKind.Utc).AddTicks(7931));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 394, DateTimeKind.Utc).AddTicks(7934));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 394, DateTimeKind.Utc).AddTicks(7944));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 394, DateTimeKind.Utc).AddTicks(7946));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 394, DateTimeKind.Utc).AddTicks(7949));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 394, DateTimeKind.Utc).AddTicks(7952));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 394, DateTimeKind.Utc).AddTicks(7955));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 392, DateTimeKind.Utc).AddTicks(6745));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 392, DateTimeKind.Utc).AddTicks(6758));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 392, DateTimeKind.Utc).AddTicks(6763));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 392, DateTimeKind.Utc).AddTicks(6768));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 392, DateTimeKind.Utc).AddTicks(6774));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 392, DateTimeKind.Utc).AddTicks(6781));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 392, DateTimeKind.Utc).AddTicks(6785));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 392, DateTimeKind.Utc).AddTicks(6790));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 396, DateTimeKind.Utc).AddTicks(4508));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 396, DateTimeKind.Utc).AddTicks(4519));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 396, DateTimeKind.Utc).AddTicks(4525));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 396, DateTimeKind.Utc).AddTicks(4531));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 396, DateTimeKind.Utc).AddTicks(4537));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 396, DateTimeKind.Utc).AddTicks(4545));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 396, DateTimeKind.Utc).AddTicks(4550));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 396, DateTimeKind.Utc).AddTicks(4556));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 396, DateTimeKind.Utc).AddTicks(4562));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 396, DateTimeKind.Utc).AddTicks(4568));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 396, DateTimeKind.Utc).AddTicks(4574));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 396, DateTimeKind.Utc).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 398, DateTimeKind.Utc).AddTicks(3980));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 398, DateTimeKind.Utc).AddTicks(3991));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 398, DateTimeKind.Utc).AddTicks(3996));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 398, DateTimeKind.Utc).AddTicks(4001));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 400, DateTimeKind.Utc).AddTicks(1182));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 400, DateTimeKind.Utc).AddTicks(1192));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 400, DateTimeKind.Utc).AddTicks(1197));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 400, DateTimeKind.Utc).AddTicks(1202));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 400, DateTimeKind.Utc).AddTicks(1207));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 401, DateTimeKind.Utc).AddTicks(2771));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 401, DateTimeKind.Utc).AddTicks(2788));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 401, DateTimeKind.Utc).AddTicks(2796));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 401, DateTimeKind.Utc).AddTicks(2803));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 401, DateTimeKind.Utc).AddTicks(2810));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 405, DateTimeKind.Utc).AddTicks(4407));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 405, DateTimeKind.Utc).AddTicks(4416));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 405, DateTimeKind.Utc).AddTicks(4420));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 405, DateTimeKind.Utc).AddTicks(4424));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 405, DateTimeKind.Utc).AddTicks(4427));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 405, DateTimeKind.Utc).AddTicks(4433));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 405, DateTimeKind.Utc).AddTicks(4437));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 405, DateTimeKind.Utc).AddTicks(4441));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 405, DateTimeKind.Utc).AddTicks(4445));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 405, DateTimeKind.Utc).AddTicks(4449));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 405, DateTimeKind.Utc).AddTicks(4453));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 8, 10, 28, 6, 405, DateTimeKind.Utc).AddTicks(4469));

            migrationBuilder.CreateIndex(
                name: "UX_Queues_Clinic_Doctor_Date_Number",
                table: "WaitingQueues",
                columns: new[] { "ClinicId", "DoctorId", "WaitingQueueDate", "WaitingQueueNumber" },
                unique: true,
                filter: "[IsDeleted] = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UX_Queues_Clinic_Doctor_Date_Number",
                table: "WaitingQueues");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 854, DateTimeKind.Utc).AddTicks(674));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 854, DateTimeKind.Utc).AddTicks(678));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 854, DateTimeKind.Utc).AddTicks(679));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 854, DateTimeKind.Utc).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 854, DateTimeKind.Utc).AddTicks(682));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 854, DateTimeKind.Utc).AddTicks(685));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 854, DateTimeKind.Utc).AddTicks(686));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 854, DateTimeKind.Utc).AddTicks(687));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 855, DateTimeKind.Utc).AddTicks(4932));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 855, DateTimeKind.Utc).AddTicks(4937));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 855, DateTimeKind.Utc).AddTicks(4939));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 855, DateTimeKind.Utc).AddTicks(4940));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 855, DateTimeKind.Utc).AddTicks(4941));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 855, DateTimeKind.Utc).AddTicks(4944));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 855, DateTimeKind.Utc).AddTicks(4946));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 856, DateTimeKind.Utc).AddTicks(6629));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 856, DateTimeKind.Utc).AddTicks(6635));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 856, DateTimeKind.Utc).AddTicks(6636));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 856, DateTimeKind.Utc).AddTicks(6637));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 856, DateTimeKind.Utc).AddTicks(6638));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 856, DateTimeKind.Utc).AddTicks(6641));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 856, DateTimeKind.Utc).AddTicks(6642));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 856, DateTimeKind.Utc).AddTicks(6642));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 855, DateTimeKind.Utc).AddTicks(8500));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 855, DateTimeKind.Utc).AddTicks(8512));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 855, DateTimeKind.Utc).AddTicks(8515));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 855, DateTimeKind.Utc).AddTicks(8516));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 855, DateTimeKind.Utc).AddTicks(8518));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 855, DateTimeKind.Utc).AddTicks(8521));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 855, DateTimeKind.Utc).AddTicks(8523));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 855, DateTimeKind.Utc).AddTicks(8525));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 857, DateTimeKind.Utc).AddTicks(2364));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 857, DateTimeKind.Utc).AddTicks(2368));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 857, DateTimeKind.Utc).AddTicks(2370));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 857, DateTimeKind.Utc).AddTicks(2371));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 857, DateTimeKind.Utc).AddTicks(2381));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 857, DateTimeKind.Utc).AddTicks(2384));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 857, DateTimeKind.Utc).AddTicks(2385));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 857, DateTimeKind.Utc).AddTicks(2386));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 857, DateTimeKind.Utc).AddTicks(2388));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 857, DateTimeKind.Utc).AddTicks(2390));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 857, DateTimeKind.Utc).AddTicks(2391));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 857, DateTimeKind.Utc).AddTicks(2393));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 857, DateTimeKind.Utc).AddTicks(2394));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 857, DateTimeKind.Utc).AddTicks(2395));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 857, DateTimeKind.Utc).AddTicks(2397));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 858, DateTimeKind.Utc).AddTicks(4310));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 858, DateTimeKind.Utc).AddTicks(4314));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 858, DateTimeKind.Utc).AddTicks(4314));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 858, DateTimeKind.Utc).AddTicks(4315));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 858, DateTimeKind.Utc).AddTicks(4316));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 858, DateTimeKind.Utc).AddTicks(4319));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 858, DateTimeKind.Utc).AddTicks(4320));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 858, DateTimeKind.Utc).AddTicks(4321));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 858, DateTimeKind.Utc).AddTicks(4322));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 858, DateTimeKind.Utc).AddTicks(4323));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 857, DateTimeKind.Utc).AddTicks(6771));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 857, DateTimeKind.Utc).AddTicks(6781));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 857, DateTimeKind.Utc).AddTicks(6783));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 857, DateTimeKind.Utc).AddTicks(6785));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 857, DateTimeKind.Utc).AddTicks(6787));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 857, DateTimeKind.Utc).AddTicks(6790));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 857, DateTimeKind.Utc).AddTicks(6792));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 857, DateTimeKind.Utc).AddTicks(6794));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 858, DateTimeKind.Utc).AddTicks(8760));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 858, DateTimeKind.Utc).AddTicks(8770));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 858, DateTimeKind.Utc).AddTicks(8772));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 858, DateTimeKind.Utc).AddTicks(8774));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 858, DateTimeKind.Utc).AddTicks(8776));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 858, DateTimeKind.Utc).AddTicks(8780));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 858, DateTimeKind.Utc).AddTicks(8782));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 858, DateTimeKind.Utc).AddTicks(8784));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 858, DateTimeKind.Utc).AddTicks(8786));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 858, DateTimeKind.Utc).AddTicks(8789));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 858, DateTimeKind.Utc).AddTicks(8791));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 858, DateTimeKind.Utc).AddTicks(8793));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 859, DateTimeKind.Utc).AddTicks(5324));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 859, DateTimeKind.Utc).AddTicks(5335));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 859, DateTimeKind.Utc).AddTicks(5338));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 859, DateTimeKind.Utc).AddTicks(5339));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 860, DateTimeKind.Utc).AddTicks(4023));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 860, DateTimeKind.Utc).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 860, DateTimeKind.Utc).AddTicks(4039));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 860, DateTimeKind.Utc).AddTicks(4041));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 860, DateTimeKind.Utc).AddTicks(4043));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 860, DateTimeKind.Utc).AddTicks(8901));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 860, DateTimeKind.Utc).AddTicks(8908));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 860, DateTimeKind.Utc).AddTicks(8910));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 860, DateTimeKind.Utc).AddTicks(8913));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 860, DateTimeKind.Utc).AddTicks(8915));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 862, DateTimeKind.Utc).AddTicks(1871));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 862, DateTimeKind.Utc).AddTicks(1876));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 862, DateTimeKind.Utc).AddTicks(1877));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 862, DateTimeKind.Utc).AddTicks(1878));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 862, DateTimeKind.Utc).AddTicks(1880));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 862, DateTimeKind.Utc).AddTicks(1882));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 862, DateTimeKind.Utc).AddTicks(1884));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 862, DateTimeKind.Utc).AddTicks(1885));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 862, DateTimeKind.Utc).AddTicks(1886));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 862, DateTimeKind.Utc).AddTicks(1888));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 862, DateTimeKind.Utc).AddTicks(1890));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 11, 58, 28, 862, DateTimeKind.Utc).AddTicks(1891));

            migrationBuilder.CreateIndex(
                name: "UX_Queues_Clinic_Date_Number",
                table: "WaitingQueues",
                columns: new[] { "ClinicId", "WaitingQueueDate", "WaitingQueueNumber" },
                unique: true,
                filter: "[IsDeleted] = 0");
        }
    }
}
