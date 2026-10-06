using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureOneToOneVisitQueueRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Appointments_AppointmentId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "UX_Visits_Appointment",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Visits");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 106, DateTimeKind.Utc).AddTicks(1393));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 106, DateTimeKind.Utc).AddTicks(1400));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 106, DateTimeKind.Utc).AddTicks(1404));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 106, DateTimeKind.Utc).AddTicks(1408));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 106, DateTimeKind.Utc).AddTicks(1412));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 106, DateTimeKind.Utc).AddTicks(1419));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 106, DateTimeKind.Utc).AddTicks(1422));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 106, DateTimeKind.Utc).AddTicks(1426));

            migrationBuilder.UpdateData(
                table: "BondCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 110, DateTimeKind.Utc).AddTicks(2636));

            migrationBuilder.UpdateData(
                table: "BondCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 110, DateTimeKind.Utc).AddTicks(2643));

            migrationBuilder.UpdateData(
                table: "BondCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 110, DateTimeKind.Utc).AddTicks(2647));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 113, DateTimeKind.Utc).AddTicks(964));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 113, DateTimeKind.Utc).AddTicks(972));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 113, DateTimeKind.Utc).AddTicks(977));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 113, DateTimeKind.Utc).AddTicks(980));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 113, DateTimeKind.Utc).AddTicks(984));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 113, DateTimeKind.Utc).AddTicks(990));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 113, DateTimeKind.Utc).AddTicks(994));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 115, DateTimeKind.Utc).AddTicks(8812));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 115, DateTimeKind.Utc).AddTicks(8818));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 115, DateTimeKind.Utc).AddTicks(8820));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 115, DateTimeKind.Utc).AddTicks(8823));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 115, DateTimeKind.Utc).AddTicks(8825));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 115, DateTimeKind.Utc).AddTicks(8831));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 115, DateTimeKind.Utc).AddTicks(8834));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 115, DateTimeKind.Utc).AddTicks(8836));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 114, DateTimeKind.Utc).AddTicks(4));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 114, DateTimeKind.Utc).AddTicks(103));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 114, DateTimeKind.Utc).AddTicks(108));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 114, DateTimeKind.Utc).AddTicks(113));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 114, DateTimeKind.Utc).AddTicks(117));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 114, DateTimeKind.Utc).AddTicks(125));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 114, DateTimeKind.Utc).AddTicks(150));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 114, DateTimeKind.Utc).AddTicks(155));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 116, DateTimeKind.Utc).AddTicks(7969));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 116, DateTimeKind.Utc).AddTicks(7976));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 116, DateTimeKind.Utc).AddTicks(7980));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 116, DateTimeKind.Utc).AddTicks(7984));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 116, DateTimeKind.Utc).AddTicks(7988));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 116, DateTimeKind.Utc).AddTicks(7994));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 116, DateTimeKind.Utc).AddTicks(7998));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 116, DateTimeKind.Utc).AddTicks(8001));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 116, DateTimeKind.Utc).AddTicks(8005));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 116, DateTimeKind.Utc).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 116, DateTimeKind.Utc).AddTicks(8013));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 116, DateTimeKind.Utc).AddTicks(8017));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 116, DateTimeKind.Utc).AddTicks(8020));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 116, DateTimeKind.Utc).AddTicks(8024));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 116, DateTimeKind.Utc).AddTicks(8028));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 119, DateTimeKind.Utc).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 119, DateTimeKind.Utc).AddTicks(4705));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 119, DateTimeKind.Utc).AddTicks(4707));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 119, DateTimeKind.Utc).AddTicks(4710));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 119, DateTimeKind.Utc).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 119, DateTimeKind.Utc).AddTicks(4718));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 119, DateTimeKind.Utc).AddTicks(4720));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 119, DateTimeKind.Utc).AddTicks(4723));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 119, DateTimeKind.Utc).AddTicks(4775));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 119, DateTimeKind.Utc).AddTicks(4779));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 117, DateTimeKind.Utc).AddTicks(7078));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 117, DateTimeKind.Utc).AddTicks(7092));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 117, DateTimeKind.Utc).AddTicks(7097));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 117, DateTimeKind.Utc).AddTicks(7102));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 117, DateTimeKind.Utc).AddTicks(7107));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 117, DateTimeKind.Utc).AddTicks(7115));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 117, DateTimeKind.Utc).AddTicks(7315));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 117, DateTimeKind.Utc).AddTicks(7322));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 126, DateTimeKind.Utc).AddTicks(5999));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 126, DateTimeKind.Utc).AddTicks(6004));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 126, DateTimeKind.Utc).AddTicks(6007));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 126, DateTimeKind.Utc).AddTicks(6010));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 126, DateTimeKind.Utc).AddTicks(6014));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 126, DateTimeKind.Utc).AddTicks(6122));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 126, DateTimeKind.Utc).AddTicks(6125));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 126, DateTimeKind.Utc).AddTicks(6127));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(1983));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(1990));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(1994));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(1997));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2000));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2007));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2010));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2013));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2016));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2020));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2023));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2026));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2029));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2033));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2036));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2039));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2042));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2047));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2050));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2053));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2117));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2121));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2124));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2128));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2131));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2134));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2137));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2140));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2143));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2147));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2150));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2153));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2156));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2161));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2164));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2167));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2171));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2174));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2177));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2180));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2183));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2189));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2193));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2196));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2199));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2202));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2205));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2208));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2211));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2214));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2217));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 134, DateTimeKind.Utc).AddTicks(2221));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 133, DateTimeKind.Utc).AddTicks(915));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 133, DateTimeKind.Utc).AddTicks(927));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 133, DateTimeKind.Utc).AddTicks(931));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 133, DateTimeKind.Utc).AddTicks(934));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 133, DateTimeKind.Utc).AddTicks(938));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 133, DateTimeKind.Utc).AddTicks(943));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 133, DateTimeKind.Utc).AddTicks(946));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 133, DateTimeKind.Utc).AddTicks(950));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 133, DateTimeKind.Utc).AddTicks(953));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 133, DateTimeKind.Utc).AddTicks(957));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 133, DateTimeKind.Utc).AddTicks(961));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 133, DateTimeKind.Utc).AddTicks(964));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 133, DateTimeKind.Utc).AddTicks(968));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 133, DateTimeKind.Utc).AddTicks(971));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 133, DateTimeKind.Utc).AddTicks(974));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 133, DateTimeKind.Utc).AddTicks(1122));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 133, DateTimeKind.Utc).AddTicks(1126));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 133, DateTimeKind.Utc).AddTicks(1131));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 133, DateTimeKind.Utc).AddTicks(1134));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 133, DateTimeKind.Utc).AddTicks(1154));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 133, DateTimeKind.Utc).AddTicks(1158));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 135, DateTimeKind.Utc).AddTicks(666));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 135, DateTimeKind.Utc).AddTicks(672));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 135, DateTimeKind.Utc).AddTicks(677));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 135, DateTimeKind.Utc).AddTicks(682));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 135, DateTimeKind.Utc).AddTicks(769));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 135, DateTimeKind.Utc).AddTicks(776));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 135, DateTimeKind.Utc).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 135, DateTimeKind.Utc).AddTicks(787));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 135, DateTimeKind.Utc).AddTicks(792));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 135, DateTimeKind.Utc).AddTicks(798));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 135, DateTimeKind.Utc).AddTicks(803));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 135, DateTimeKind.Utc).AddTicks(809));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 136, DateTimeKind.Utc).AddTicks(4373));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 136, DateTimeKind.Utc).AddTicks(4383));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 136, DateTimeKind.Utc).AddTicks(4387));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 136, DateTimeKind.Utc).AddTicks(4391));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 137, DateTimeKind.Utc).AddTicks(9739));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 137, DateTimeKind.Utc).AddTicks(9751));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 137, DateTimeKind.Utc).AddTicks(9757));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 137, DateTimeKind.Utc).AddTicks(9761));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 137, DateTimeKind.Utc).AddTicks(9765));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 138, DateTimeKind.Utc).AddTicks(9784));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 138, DateTimeKind.Utc).AddTicks(9798));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 138, DateTimeKind.Utc).AddTicks(9805));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 138, DateTimeKind.Utc).AddTicks(9810));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 138, DateTimeKind.Utc).AddTicks(9816));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 139, DateTimeKind.Utc).AddTicks(7522));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 139, DateTimeKind.Utc).AddTicks(7526));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 139, DateTimeKind.Utc).AddTicks(7530));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 139, DateTimeKind.Utc).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 139, DateTimeKind.Utc).AddTicks(7536));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 143, DateTimeKind.Utc).AddTicks(5481));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 143, DateTimeKind.Utc).AddTicks(5488));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 143, DateTimeKind.Utc).AddTicks(5491));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 143, DateTimeKind.Utc).AddTicks(5494));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 143, DateTimeKind.Utc).AddTicks(5497));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 143, DateTimeKind.Utc).AddTicks(5502));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 143, DateTimeKind.Utc).AddTicks(5505));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 143, DateTimeKind.Utc).AddTicks(5508));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 143, DateTimeKind.Utc).AddTicks(5511));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 143, DateTimeKind.Utc).AddTicks(5515));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 143, DateTimeKind.Utc).AddTicks(5518));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 6, 7, 27, 40, 143, DateTimeKind.Utc).AddTicks(5521));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Visits",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 932, DateTimeKind.Utc).AddTicks(4427));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 932, DateTimeKind.Utc).AddTicks(4432));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 932, DateTimeKind.Utc).AddTicks(4433));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 932, DateTimeKind.Utc).AddTicks(4435));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 932, DateTimeKind.Utc).AddTicks(4436));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 932, DateTimeKind.Utc).AddTicks(4438));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 932, DateTimeKind.Utc).AddTicks(4440));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 932, DateTimeKind.Utc).AddTicks(4441));

            migrationBuilder.UpdateData(
                table: "BondCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 934, DateTimeKind.Utc).AddTicks(2875));

            migrationBuilder.UpdateData(
                table: "BondCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 934, DateTimeKind.Utc).AddTicks(2882));

            migrationBuilder.UpdateData(
                table: "BondCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 934, DateTimeKind.Utc).AddTicks(2884));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 935, DateTimeKind.Utc).AddTicks(3073));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 935, DateTimeKind.Utc).AddTicks(3077));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 935, DateTimeKind.Utc).AddTicks(3079));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 935, DateTimeKind.Utc).AddTicks(3109));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 935, DateTimeKind.Utc).AddTicks(3110));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 935, DateTimeKind.Utc).AddTicks(3113));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 935, DateTimeKind.Utc).AddTicks(3115));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 936, DateTimeKind.Utc).AddTicks(3403));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 936, DateTimeKind.Utc).AddTicks(3407));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 936, DateTimeKind.Utc).AddTicks(3408));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 936, DateTimeKind.Utc).AddTicks(3409));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 936, DateTimeKind.Utc).AddTicks(3410));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 936, DateTimeKind.Utc).AddTicks(3412));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 936, DateTimeKind.Utc).AddTicks(3413));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 936, DateTimeKind.Utc).AddTicks(3414));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 935, DateTimeKind.Utc).AddTicks(6371));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 935, DateTimeKind.Utc).AddTicks(6377));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 935, DateTimeKind.Utc).AddTicks(6378));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 935, DateTimeKind.Utc).AddTicks(6380));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 935, DateTimeKind.Utc).AddTicks(6382));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 935, DateTimeKind.Utc).AddTicks(6385));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 935, DateTimeKind.Utc).AddTicks(6391));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 935, DateTimeKind.Utc).AddTicks(6392));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 936, DateTimeKind.Utc).AddTicks(7883));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 936, DateTimeKind.Utc).AddTicks(7887));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 936, DateTimeKind.Utc).AddTicks(7889));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 936, DateTimeKind.Utc).AddTicks(7890));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 936, DateTimeKind.Utc).AddTicks(7891));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 936, DateTimeKind.Utc).AddTicks(7894));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 936, DateTimeKind.Utc).AddTicks(7896));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 936, DateTimeKind.Utc).AddTicks(7897));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 936, DateTimeKind.Utc).AddTicks(7898));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 936, DateTimeKind.Utc).AddTicks(7901));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 936, DateTimeKind.Utc).AddTicks(7902));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 936, DateTimeKind.Utc).AddTicks(7903));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 936, DateTimeKind.Utc).AddTicks(7904));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 936, DateTimeKind.Utc).AddTicks(7906));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 936, DateTimeKind.Utc).AddTicks(7907));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 938, DateTimeKind.Utc).AddTicks(1016));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 938, DateTimeKind.Utc).AddTicks(1023));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 938, DateTimeKind.Utc).AddTicks(1024));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 938, DateTimeKind.Utc).AddTicks(1025));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 938, DateTimeKind.Utc).AddTicks(1026));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 938, DateTimeKind.Utc).AddTicks(1028));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 938, DateTimeKind.Utc).AddTicks(1029));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 938, DateTimeKind.Utc).AddTicks(1030));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 938, DateTimeKind.Utc).AddTicks(1031));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 938, DateTimeKind.Utc).AddTicks(1032));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 937, DateTimeKind.Utc).AddTicks(2681));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 937, DateTimeKind.Utc).AddTicks(2688));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 937, DateTimeKind.Utc).AddTicks(2720));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 937, DateTimeKind.Utc).AddTicks(2722));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 937, DateTimeKind.Utc).AddTicks(2724));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 937, DateTimeKind.Utc).AddTicks(2727));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 937, DateTimeKind.Utc).AddTicks(2729));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 937, DateTimeKind.Utc).AddTicks(2731));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 940, DateTimeKind.Utc).AddTicks(7979));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 940, DateTimeKind.Utc).AddTicks(7984));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 940, DateTimeKind.Utc).AddTicks(7985));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 940, DateTimeKind.Utc).AddTicks(8016));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 940, DateTimeKind.Utc).AddTicks(8017));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 940, DateTimeKind.Utc).AddTicks(8020));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 940, DateTimeKind.Utc).AddTicks(8021));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 940, DateTimeKind.Utc).AddTicks(8022));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2650));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2655));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2657));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2658));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2659));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2662));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2664));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2665));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2667));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2669));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2670));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2671));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2673));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2674));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2675));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2677));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2678));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2680));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2682));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2683));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2685));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2686));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2687));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2689));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2690));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2691));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2693));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2694));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2696));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2697));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2698));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2700));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2701));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2703));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2705));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2706));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2708));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2709));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2710));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2712));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2713));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2714));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2716));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2717));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2719));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2720));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2721));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2747));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2748));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2750));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2751));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2752));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(2754));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 943, DateTimeKind.Utc).AddTicks(6186));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 943, DateTimeKind.Utc).AddTicks(6192));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 943, DateTimeKind.Utc).AddTicks(6194));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 943, DateTimeKind.Utc).AddTicks(6195));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 943, DateTimeKind.Utc).AddTicks(6197));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 943, DateTimeKind.Utc).AddTicks(6200));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 943, DateTimeKind.Utc).AddTicks(6201));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 943, DateTimeKind.Utc).AddTicks(6203));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 943, DateTimeKind.Utc).AddTicks(6204));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 943, DateTimeKind.Utc).AddTicks(6206));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 943, DateTimeKind.Utc).AddTicks(6208));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 943, DateTimeKind.Utc).AddTicks(6209));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 943, DateTimeKind.Utc).AddTicks(6211));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 943, DateTimeKind.Utc).AddTicks(6212));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 943, DateTimeKind.Utc).AddTicks(6214));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 943, DateTimeKind.Utc).AddTicks(6215));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 943, DateTimeKind.Utc).AddTicks(6217));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 943, DateTimeKind.Utc).AddTicks(6219));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 943, DateTimeKind.Utc).AddTicks(6220));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 943, DateTimeKind.Utc).AddTicks(6234));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 943, DateTimeKind.Utc).AddTicks(6236));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(7985));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(7990));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(7992));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(7994));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(7996));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(8000));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(8002));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(8005));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(8007));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(8012));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 944, DateTimeKind.Utc).AddTicks(8014));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 945, DateTimeKind.Utc).AddTicks(5096));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 945, DateTimeKind.Utc).AddTicks(5102));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 945, DateTimeKind.Utc).AddTicks(5104));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 945, DateTimeKind.Utc).AddTicks(5106));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 946, DateTimeKind.Utc).AddTicks(2948));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 946, DateTimeKind.Utc).AddTicks(2954));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 946, DateTimeKind.Utc).AddTicks(2958));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 946, DateTimeKind.Utc).AddTicks(2959));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 946, DateTimeKind.Utc).AddTicks(2961));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 946, DateTimeKind.Utc).AddTicks(7689));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 946, DateTimeKind.Utc).AddTicks(7698));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 946, DateTimeKind.Utc).AddTicks(7700));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 946, DateTimeKind.Utc).AddTicks(7703));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 946, DateTimeKind.Utc).AddTicks(7706));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 947, DateTimeKind.Utc).AddTicks(1345));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 947, DateTimeKind.Utc).AddTicks(1349));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 947, DateTimeKind.Utc).AddTicks(1351));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 947, DateTimeKind.Utc).AddTicks(1352));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 947, DateTimeKind.Utc).AddTicks(1354));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 948, DateTimeKind.Utc).AddTicks(9720));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 948, DateTimeKind.Utc).AddTicks(9758));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 948, DateTimeKind.Utc).AddTicks(9760));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 948, DateTimeKind.Utc).AddTicks(9761));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 948, DateTimeKind.Utc).AddTicks(9762));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 948, DateTimeKind.Utc).AddTicks(9765));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 948, DateTimeKind.Utc).AddTicks(9767));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 948, DateTimeKind.Utc).AddTicks(9768));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 948, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 948, DateTimeKind.Utc).AddTicks(9772));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 948, DateTimeKind.Utc).AddTicks(9773));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 13, 59, 29, 948, DateTimeKind.Utc).AddTicks(9774));

            migrationBuilder.CreateIndex(
                name: "UX_Visits_Appointment",
                table: "Visits",
                column: "AppointmentId",
                unique: true,
                filter: "[AppointmentId] IS NOT NULL AND [IsDeleted] = 0");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Appointments_AppointmentId",
                table: "Visits",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
