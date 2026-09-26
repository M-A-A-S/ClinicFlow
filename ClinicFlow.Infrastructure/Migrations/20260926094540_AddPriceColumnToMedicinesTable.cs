using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceColumnToMedicinesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Medicines",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0.00m);

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 531, DateTimeKind.Utc).AddTicks(8903));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 531, DateTimeKind.Utc).AddTicks(8908));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 531, DateTimeKind.Utc).AddTicks(8909));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 531, DateTimeKind.Utc).AddTicks(8911));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 531, DateTimeKind.Utc).AddTicks(8912));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 531, DateTimeKind.Utc).AddTicks(8915));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 531, DateTimeKind.Utc).AddTicks(8916));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 531, DateTimeKind.Utc).AddTicks(8918));

            migrationBuilder.UpdateData(
                table: "BondCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 533, DateTimeKind.Utc).AddTicks(9643));

            migrationBuilder.UpdateData(
                table: "BondCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 533, DateTimeKind.Utc).AddTicks(9648));

            migrationBuilder.UpdateData(
                table: "BondCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 533, DateTimeKind.Utc).AddTicks(9649));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 535, DateTimeKind.Utc).AddTicks(3220));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 535, DateTimeKind.Utc).AddTicks(3224));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 535, DateTimeKind.Utc).AddTicks(3263));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 535, DateTimeKind.Utc).AddTicks(3264));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 535, DateTimeKind.Utc).AddTicks(3265));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 535, DateTimeKind.Utc).AddTicks(3269));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 535, DateTimeKind.Utc).AddTicks(3270));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 536, DateTimeKind.Utc).AddTicks(5390));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 536, DateTimeKind.Utc).AddTicks(5398));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 536, DateTimeKind.Utc).AddTicks(5399));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 536, DateTimeKind.Utc).AddTicks(5400));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 536, DateTimeKind.Utc).AddTicks(5401));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 536, DateTimeKind.Utc).AddTicks(5403));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 536, DateTimeKind.Utc).AddTicks(5404));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 536, DateTimeKind.Utc).AddTicks(5405));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 535, DateTimeKind.Utc).AddTicks(7350));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 535, DateTimeKind.Utc).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 535, DateTimeKind.Utc).AddTicks(7357));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 535, DateTimeKind.Utc).AddTicks(7358));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 535, DateTimeKind.Utc).AddTicks(7360));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 535, DateTimeKind.Utc).AddTicks(7363));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 535, DateTimeKind.Utc).AddTicks(7365));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 535, DateTimeKind.Utc).AddTicks(7366));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 536, DateTimeKind.Utc).AddTicks(9705));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 536, DateTimeKind.Utc).AddTicks(9710));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 536, DateTimeKind.Utc).AddTicks(9711));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 536, DateTimeKind.Utc).AddTicks(9713));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 536, DateTimeKind.Utc).AddTicks(9714));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 536, DateTimeKind.Utc).AddTicks(9717));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 536, DateTimeKind.Utc).AddTicks(9718));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 536, DateTimeKind.Utc).AddTicks(9720));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 536, DateTimeKind.Utc).AddTicks(9721));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 536, DateTimeKind.Utc).AddTicks(9723));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 536, DateTimeKind.Utc).AddTicks(9724));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 536, DateTimeKind.Utc).AddTicks(9725));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 536, DateTimeKind.Utc).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 536, DateTimeKind.Utc).AddTicks(9728));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 536, DateTimeKind.Utc).AddTicks(9729));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 538, DateTimeKind.Utc).AddTicks(1854));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 538, DateTimeKind.Utc).AddTicks(1862));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 538, DateTimeKind.Utc).AddTicks(1863));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 538, DateTimeKind.Utc).AddTicks(1864));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 538, DateTimeKind.Utc).AddTicks(1865));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 538, DateTimeKind.Utc).AddTicks(1874));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 538, DateTimeKind.Utc).AddTicks(1875));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 538, DateTimeKind.Utc).AddTicks(1876));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 538, DateTimeKind.Utc).AddTicks(1877));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 538, DateTimeKind.Utc).AddTicks(1879));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 537, DateTimeKind.Utc).AddTicks(3583));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 537, DateTimeKind.Utc).AddTicks(3620));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 537, DateTimeKind.Utc).AddTicks(3623));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 537, DateTimeKind.Utc).AddTicks(3624));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 537, DateTimeKind.Utc).AddTicks(3626));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 537, DateTimeKind.Utc).AddTicks(3630));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 537, DateTimeKind.Utc).AddTicks(3632));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 537, DateTimeKind.Utc).AddTicks(3634));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 544, DateTimeKind.Utc).AddTicks(1180));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 544, DateTimeKind.Utc).AddTicks(1187));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 544, DateTimeKind.Utc).AddTicks(1189));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 544, DateTimeKind.Utc).AddTicks(1190));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 544, DateTimeKind.Utc).AddTicks(1191));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 544, DateTimeKind.Utc).AddTicks(1193));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 544, DateTimeKind.Utc).AddTicks(1194));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 544, DateTimeKind.Utc).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7468));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7473));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7474));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7475));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7477));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7480));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7481));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7482));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7484));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7486));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7487));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7489));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7490));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7491));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7493));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7494));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7495));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7498));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7499));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7500));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7502));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7503));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7504));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7506));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7507));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7508));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7510));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7511));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7512));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7514));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7515));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7516));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7518));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7520));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7521));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7522));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7524));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7525));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7527));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7528));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7529));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7531));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7558));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7559));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7560));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7562));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7563));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7564));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7566));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7567));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7568));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7570));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 548, DateTimeKind.Utc).AddTicks(7571));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 547, DateTimeKind.Utc).AddTicks(8993));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 547, DateTimeKind.Utc).AddTicks(8999));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 547, DateTimeKind.Utc).AddTicks(9001));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 547, DateTimeKind.Utc).AddTicks(9002));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 547, DateTimeKind.Utc).AddTicks(9004));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 547, DateTimeKind.Utc).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 547, DateTimeKind.Utc).AddTicks(9008));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 547, DateTimeKind.Utc).AddTicks(9010));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 547, DateTimeKind.Utc).AddTicks(9011));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 547, DateTimeKind.Utc).AddTicks(9014));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 547, DateTimeKind.Utc).AddTicks(9015));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 547, DateTimeKind.Utc).AddTicks(9017));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 547, DateTimeKind.Utc).AddTicks(9018));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 547, DateTimeKind.Utc).AddTicks(9019));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 547, DateTimeKind.Utc).AddTicks(9021));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 547, DateTimeKind.Utc).AddTicks(9022));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 547, DateTimeKind.Utc).AddTicks(9024));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 547, DateTimeKind.Utc).AddTicks(9026));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 547, DateTimeKind.Utc).AddTicks(9028));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 547, DateTimeKind.Utc).AddTicks(9040));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 547, DateTimeKind.Utc).AddTicks(9042));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Price" },
                values: new object[] { new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(2088), 100m });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Price" },
                values: new object[] { new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(2092), 100m });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Price" },
                values: new object[] { new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(2095), 100m });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Price" },
                values: new object[] { new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(2097), 100m });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Price" },
                values: new object[] { new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(2099), 100m });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Price" },
                values: new object[] { new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(2103), 100m });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Price" },
                values: new object[] { new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(2105), 100m });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Price" },
                values: new object[] { new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(2107), 100m });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Price" },
                values: new object[] { new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(2109), 100m });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Price" },
                values: new object[] { new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(2113), 100m });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Price" },
                values: new object[] { new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(2115), 100m });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Price" },
                values: new object[] { new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(2117), 100m });

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(9044));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(9050));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(9052));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(9054));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 550, DateTimeKind.Utc).AddTicks(6998));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 550, DateTimeKind.Utc).AddTicks(7005));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 550, DateTimeKind.Utc).AddTicks(7007));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 550, DateTimeKind.Utc).AddTicks(7009));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 550, DateTimeKind.Utc).AddTicks(7011));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 551, DateTimeKind.Utc).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 551, DateTimeKind.Utc).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 551, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 551, DateTimeKind.Utc).AddTicks(2201));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 551, DateTimeKind.Utc).AddTicks(2203));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 551, DateTimeKind.Utc).AddTicks(5262));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 551, DateTimeKind.Utc).AddTicks(5266));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 551, DateTimeKind.Utc).AddTicks(5267));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 551, DateTimeKind.Utc).AddTicks(5268));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 551, DateTimeKind.Utc).AddTicks(5270));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 553, DateTimeKind.Utc).AddTicks(335));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 553, DateTimeKind.Utc).AddTicks(340));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 553, DateTimeKind.Utc).AddTicks(371));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 553, DateTimeKind.Utc).AddTicks(372));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 553, DateTimeKind.Utc).AddTicks(374));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 553, DateTimeKind.Utc).AddTicks(377));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 553, DateTimeKind.Utc).AddTicks(378));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 553, DateTimeKind.Utc).AddTicks(379));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 553, DateTimeKind.Utc).AddTicks(381));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 553, DateTimeKind.Utc).AddTicks(383));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 553, DateTimeKind.Utc).AddTicks(384));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 553, DateTimeKind.Utc).AddTicks(385));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Medicines");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 697, DateTimeKind.Utc).AddTicks(462));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 697, DateTimeKind.Utc).AddTicks(505));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 697, DateTimeKind.Utc).AddTicks(506));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 697, DateTimeKind.Utc).AddTicks(508));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 697, DateTimeKind.Utc).AddTicks(509));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 697, DateTimeKind.Utc).AddTicks(511));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 697, DateTimeKind.Utc).AddTicks(513));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 697, DateTimeKind.Utc).AddTicks(514));

            migrationBuilder.UpdateData(
                table: "BondCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 699, DateTimeKind.Utc).AddTicks(5243));

            migrationBuilder.UpdateData(
                table: "BondCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 699, DateTimeKind.Utc).AddTicks(5245));

            migrationBuilder.UpdateData(
                table: "BondCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 699, DateTimeKind.Utc).AddTicks(5246));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 701, DateTimeKind.Utc).AddTicks(2095));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 701, DateTimeKind.Utc).AddTicks(2099));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 701, DateTimeKind.Utc).AddTicks(2100));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 701, DateTimeKind.Utc).AddTicks(2102));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 701, DateTimeKind.Utc).AddTicks(2103));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 701, DateTimeKind.Utc).AddTicks(2105));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 701, DateTimeKind.Utc).AddTicks(2107));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 702, DateTimeKind.Utc).AddTicks(7076));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 702, DateTimeKind.Utc).AddTicks(7079));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 702, DateTimeKind.Utc).AddTicks(7080));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 702, DateTimeKind.Utc).AddTicks(7081));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 702, DateTimeKind.Utc).AddTicks(7081));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 702, DateTimeKind.Utc).AddTicks(7083));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 702, DateTimeKind.Utc).AddTicks(7084));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 702, DateTimeKind.Utc).AddTicks(7085));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 701, DateTimeKind.Utc).AddTicks(7002));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 701, DateTimeKind.Utc).AddTicks(7008));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 701, DateTimeKind.Utc).AddTicks(7009));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 701, DateTimeKind.Utc).AddTicks(7011));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 701, DateTimeKind.Utc).AddTicks(7012));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 701, DateTimeKind.Utc).AddTicks(7015));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 701, DateTimeKind.Utc).AddTicks(7025));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 701, DateTimeKind.Utc).AddTicks(7027));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 703, DateTimeKind.Utc).AddTicks(3207));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 703, DateTimeKind.Utc).AddTicks(3211));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 703, DateTimeKind.Utc).AddTicks(3212));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 703, DateTimeKind.Utc).AddTicks(3214));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 703, DateTimeKind.Utc).AddTicks(3215));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 703, DateTimeKind.Utc).AddTicks(3217));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 703, DateTimeKind.Utc).AddTicks(3219));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 703, DateTimeKind.Utc).AddTicks(3220));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 703, DateTimeKind.Utc).AddTicks(3221));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 703, DateTimeKind.Utc).AddTicks(3223));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 703, DateTimeKind.Utc).AddTicks(3224));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 703, DateTimeKind.Utc).AddTicks(3225));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 703, DateTimeKind.Utc).AddTicks(3285));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 703, DateTimeKind.Utc).AddTicks(3286));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 703, DateTimeKind.Utc).AddTicks(3288));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 705, DateTimeKind.Utc).AddTicks(1457));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 705, DateTimeKind.Utc).AddTicks(1460));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 705, DateTimeKind.Utc).AddTicks(1460));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 705, DateTimeKind.Utc).AddTicks(1461));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 705, DateTimeKind.Utc).AddTicks(1462));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 705, DateTimeKind.Utc).AddTicks(1465));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 705, DateTimeKind.Utc).AddTicks(1466));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 705, DateTimeKind.Utc).AddTicks(1467));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 705, DateTimeKind.Utc).AddTicks(1468));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 705, DateTimeKind.Utc).AddTicks(1469));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 703, DateTimeKind.Utc).AddTicks(9279));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 703, DateTimeKind.Utc).AddTicks(9342));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 703, DateTimeKind.Utc).AddTicks(9344));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 703, DateTimeKind.Utc).AddTicks(9346));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 703, DateTimeKind.Utc).AddTicks(9348));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 703, DateTimeKind.Utc).AddTicks(9351));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 703, DateTimeKind.Utc).AddTicks(9353));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 703, DateTimeKind.Utc).AddTicks(9354));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 708, DateTimeKind.Utc).AddTicks(5719));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 708, DateTimeKind.Utc).AddTicks(5721));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 708, DateTimeKind.Utc).AddTicks(5723));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 708, DateTimeKind.Utc).AddTicks(5724));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 708, DateTimeKind.Utc).AddTicks(5725));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 708, DateTimeKind.Utc).AddTicks(5727));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 708, DateTimeKind.Utc).AddTicks(5728));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 708, DateTimeKind.Utc).AddTicks(5729));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6062));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6072));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6074));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6076));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6077));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6087));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6190));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6192));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6193));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6196));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6198));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6199));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6201));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6202));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6204));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6206));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6207));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6210));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6211));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6213));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6214));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6216));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6218));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6219));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6221));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6222));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6224));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6226));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6227));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6229));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6230));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6232));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6233));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6236));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6238));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6239));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6241));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6242));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6244));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6246));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6247));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6249));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6250));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6252));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6257));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6258));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6260));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6262));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6263));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6265));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6266));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6268));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 719, DateTimeKind.Utc).AddTicks(6269));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 712, DateTimeKind.Utc).AddTicks(6972));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 712, DateTimeKind.Utc).AddTicks(6980));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 712, DateTimeKind.Utc).AddTicks(6981));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 712, DateTimeKind.Utc).AddTicks(6983));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 712, DateTimeKind.Utc).AddTicks(6984));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 712, DateTimeKind.Utc).AddTicks(6987));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 712, DateTimeKind.Utc).AddTicks(6988));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 712, DateTimeKind.Utc).AddTicks(6990));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 712, DateTimeKind.Utc).AddTicks(6991));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 712, DateTimeKind.Utc).AddTicks(6994));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 712, DateTimeKind.Utc).AddTicks(6995));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 712, DateTimeKind.Utc).AddTicks(6997));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 712, DateTimeKind.Utc).AddTicks(6998));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 712, DateTimeKind.Utc).AddTicks(7000));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 712, DateTimeKind.Utc).AddTicks(7001));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 712, DateTimeKind.Utc).AddTicks(7003));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 712, DateTimeKind.Utc).AddTicks(7004));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 712, DateTimeKind.Utc).AddTicks(7006));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 712, DateTimeKind.Utc).AddTicks(7008));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 712, DateTimeKind.Utc).AddTicks(7021));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 712, DateTimeKind.Utc).AddTicks(7023));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 720, DateTimeKind.Utc).AddTicks(7938));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 720, DateTimeKind.Utc).AddTicks(7941));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 720, DateTimeKind.Utc).AddTicks(7943));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 720, DateTimeKind.Utc).AddTicks(7945));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 720, DateTimeKind.Utc).AddTicks(7947));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 720, DateTimeKind.Utc).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 720, DateTimeKind.Utc).AddTicks(7952));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 720, DateTimeKind.Utc).AddTicks(7954));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 720, DateTimeKind.Utc).AddTicks(7956));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 720, DateTimeKind.Utc).AddTicks(7958));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 720, DateTimeKind.Utc).AddTicks(7960));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 720, DateTimeKind.Utc).AddTicks(7962));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 722, DateTimeKind.Utc).AddTicks(240));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 722, DateTimeKind.Utc).AddTicks(246));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 722, DateTimeKind.Utc).AddTicks(248));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 722, DateTimeKind.Utc).AddTicks(250));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 723, DateTimeKind.Utc).AddTicks(3006));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 723, DateTimeKind.Utc).AddTicks(3013));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 723, DateTimeKind.Utc).AddTicks(3015));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 723, DateTimeKind.Utc).AddTicks(3017));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 723, DateTimeKind.Utc).AddTicks(3018));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 723, DateTimeKind.Utc).AddTicks(9710));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 723, DateTimeKind.Utc).AddTicks(9721));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 723, DateTimeKind.Utc).AddTicks(9725));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 723, DateTimeKind.Utc).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 723, DateTimeKind.Utc).AddTicks(9730));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 724, DateTimeKind.Utc).AddTicks(4348));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 724, DateTimeKind.Utc).AddTicks(4351));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 724, DateTimeKind.Utc).AddTicks(4454));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 724, DateTimeKind.Utc).AddTicks(4456));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 724, DateTimeKind.Utc).AddTicks(4457));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 727, DateTimeKind.Utc).AddTicks(3984));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 727, DateTimeKind.Utc).AddTicks(3988));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 727, DateTimeKind.Utc).AddTicks(3990));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 727, DateTimeKind.Utc).AddTicks(3991));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 727, DateTimeKind.Utc).AddTicks(3992));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 727, DateTimeKind.Utc).AddTicks(3995));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 727, DateTimeKind.Utc).AddTicks(3996));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 727, DateTimeKind.Utc).AddTicks(3997));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 727, DateTimeKind.Utc).AddTicks(3998));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 727, DateTimeKind.Utc).AddTicks(4000));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 727, DateTimeKind.Utc).AddTicks(4002));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 19, 8, 28, 41, 727, DateTimeKind.Utc).AddTicks(4003));
        }
    }
}
