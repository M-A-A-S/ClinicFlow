using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureInvoiceRelationshipsWithSetNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "WaitingQueues",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Visits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "LabOrders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 539, DateTimeKind.Utc).AddTicks(3069));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 539, DateTimeKind.Utc).AddTicks(3082));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 539, DateTimeKind.Utc).AddTicks(3084));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 539, DateTimeKind.Utc).AddTicks(3085));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 539, DateTimeKind.Utc).AddTicks(3087));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 539, DateTimeKind.Utc).AddTicks(3090));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 539, DateTimeKind.Utc).AddTicks(3091));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 539, DateTimeKind.Utc).AddTicks(3092));

            migrationBuilder.UpdateData(
                table: "BondCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 541, DateTimeKind.Utc).AddTicks(5612));

            migrationBuilder.UpdateData(
                table: "BondCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 541, DateTimeKind.Utc).AddTicks(5627));

            migrationBuilder.UpdateData(
                table: "BondCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 541, DateTimeKind.Utc).AddTicks(5629));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 543, DateTimeKind.Utc).AddTicks(2646));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 543, DateTimeKind.Utc).AddTicks(2667));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 543, DateTimeKind.Utc).AddTicks(2669));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 543, DateTimeKind.Utc).AddTicks(2670));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 543, DateTimeKind.Utc).AddTicks(2672));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 543, DateTimeKind.Utc).AddTicks(2675));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 543, DateTimeKind.Utc).AddTicks(2676));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 544, DateTimeKind.Utc).AddTicks(8211));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 544, DateTimeKind.Utc).AddTicks(8228));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 544, DateTimeKind.Utc).AddTicks(8229));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 544, DateTimeKind.Utc).AddTicks(8230));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 544, DateTimeKind.Utc).AddTicks(8231));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 544, DateTimeKind.Utc).AddTicks(8233));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 544, DateTimeKind.Utc).AddTicks(8234));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 544, DateTimeKind.Utc).AddTicks(8235));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 543, DateTimeKind.Utc).AddTicks(8131));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 543, DateTimeKind.Utc).AddTicks(8147));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 543, DateTimeKind.Utc).AddTicks(8149));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 543, DateTimeKind.Utc).AddTicks(8151));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 543, DateTimeKind.Utc).AddTicks(8153));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 543, DateTimeKind.Utc).AddTicks(8156));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 543, DateTimeKind.Utc).AddTicks(8196));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 543, DateTimeKind.Utc).AddTicks(8197));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 545, DateTimeKind.Utc).AddTicks(3466));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 545, DateTimeKind.Utc).AddTicks(3479));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 545, DateTimeKind.Utc).AddTicks(3481));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 545, DateTimeKind.Utc).AddTicks(3482));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 545, DateTimeKind.Utc).AddTicks(3484));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 545, DateTimeKind.Utc).AddTicks(3487));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 545, DateTimeKind.Utc).AddTicks(3488));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 545, DateTimeKind.Utc).AddTicks(3489));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 545, DateTimeKind.Utc).AddTicks(3491));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 545, DateTimeKind.Utc).AddTicks(3493));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 545, DateTimeKind.Utc).AddTicks(3494));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 545, DateTimeKind.Utc).AddTicks(3495));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 545, DateTimeKind.Utc).AddTicks(3497));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 545, DateTimeKind.Utc).AddTicks(3498));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 545, DateTimeKind.Utc).AddTicks(3499));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 546, DateTimeKind.Utc).AddTicks(5608));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 546, DateTimeKind.Utc).AddTicks(5623));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 546, DateTimeKind.Utc).AddTicks(5624));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 546, DateTimeKind.Utc).AddTicks(5625));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 546, DateTimeKind.Utc).AddTicks(5626));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 546, DateTimeKind.Utc).AddTicks(5629));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 546, DateTimeKind.Utc).AddTicks(5630));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 546, DateTimeKind.Utc).AddTicks(5630));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 546, DateTimeKind.Utc).AddTicks(5631));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 546, DateTimeKind.Utc).AddTicks(5633));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 545, DateTimeKind.Utc).AddTicks(7445));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 545, DateTimeKind.Utc).AddTicks(7456));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 545, DateTimeKind.Utc).AddTicks(7459));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 545, DateTimeKind.Utc).AddTicks(7460));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 545, DateTimeKind.Utc).AddTicks(7462));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 545, DateTimeKind.Utc).AddTicks(7466));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 545, DateTimeKind.Utc).AddTicks(7468));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 545, DateTimeKind.Utc).AddTicks(7469));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 550, DateTimeKind.Utc).AddTicks(8638));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 550, DateTimeKind.Utc).AddTicks(8666));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 550, DateTimeKind.Utc).AddTicks(8670));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 550, DateTimeKind.Utc).AddTicks(8674));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 550, DateTimeKind.Utc).AddTicks(8678));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 550, DateTimeKind.Utc).AddTicks(8685));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 550, DateTimeKind.Utc).AddTicks(8689));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 550, DateTimeKind.Utc).AddTicks(8692));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1539));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1557));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1559));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1560));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1562));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1565));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1566));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1568));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1569));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1571));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1573));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1574));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1575));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1577));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1578));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1580));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1581));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1583));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1585));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1588));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1589));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1590));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1592));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1593));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1595));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1596));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1598));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1599));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1600));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1602));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1603));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1604));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1607));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1608));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1609));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1611));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1612));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1637));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1639));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1641));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1643));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1644));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1646));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1647));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1648));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1650));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1651));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1653));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1654));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1656));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(1657));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 555, DateTimeKind.Utc).AddTicks(4937));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 555, DateTimeKind.Utc).AddTicks(4955));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 555, DateTimeKind.Utc).AddTicks(4957));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 555, DateTimeKind.Utc).AddTicks(4959));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 555, DateTimeKind.Utc).AddTicks(4960));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 555, DateTimeKind.Utc).AddTicks(4963));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 555, DateTimeKind.Utc).AddTicks(4964));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 555, DateTimeKind.Utc).AddTicks(4966));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 555, DateTimeKind.Utc).AddTicks(4967));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 555, DateTimeKind.Utc).AddTicks(4969));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 555, DateTimeKind.Utc).AddTicks(4971));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 555, DateTimeKind.Utc).AddTicks(4972));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 555, DateTimeKind.Utc).AddTicks(4974));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 555, DateTimeKind.Utc).AddTicks(4975));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 555, DateTimeKind.Utc).AddTicks(4977));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 555, DateTimeKind.Utc).AddTicks(4978));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 555, DateTimeKind.Utc).AddTicks(4980));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 555, DateTimeKind.Utc).AddTicks(4982));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 555, DateTimeKind.Utc).AddTicks(4984));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 555, DateTimeKind.Utc).AddTicks(4995));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 555, DateTimeKind.Utc).AddTicks(4997));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(7408));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(7417));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(7420));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(7422));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(7424));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(7428));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(7430));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(7432));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(7435));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(7437));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(7440));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 556, DateTimeKind.Utc).AddTicks(7442));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 557, DateTimeKind.Utc).AddTicks(6198));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 557, DateTimeKind.Utc).AddTicks(6219));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 557, DateTimeKind.Utc).AddTicks(6224));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 557, DateTimeKind.Utc).AddTicks(6226));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 558, DateTimeKind.Utc).AddTicks(6681));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 558, DateTimeKind.Utc).AddTicks(6707));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 558, DateTimeKind.Utc).AddTicks(6709));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 558, DateTimeKind.Utc).AddTicks(6711));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 558, DateTimeKind.Utc).AddTicks(6712));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 559, DateTimeKind.Utc).AddTicks(3107));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 559, DateTimeKind.Utc).AddTicks(3124));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 559, DateTimeKind.Utc).AddTicks(3127));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 559, DateTimeKind.Utc).AddTicks(3130));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 559, DateTimeKind.Utc).AddTicks(3132));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 559, DateTimeKind.Utc).AddTicks(6650));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 559, DateTimeKind.Utc).AddTicks(6658));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 559, DateTimeKind.Utc).AddTicks(6660));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 559, DateTimeKind.Utc).AddTicks(6661));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 559, DateTimeKind.Utc).AddTicks(6663));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 561, DateTimeKind.Utc).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 561, DateTimeKind.Utc).AddTicks(4968));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 561, DateTimeKind.Utc).AddTicks(4969));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 561, DateTimeKind.Utc).AddTicks(4971));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 561, DateTimeKind.Utc).AddTicks(4972));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 561, DateTimeKind.Utc).AddTicks(4975));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 561, DateTimeKind.Utc).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 561, DateTimeKind.Utc).AddTicks(4978));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 561, DateTimeKind.Utc).AddTicks(4979));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 561, DateTimeKind.Utc).AddTicks(4981));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 561, DateTimeKind.Utc).AddTicks(4982));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 8, 2, 59, 561, DateTimeKind.Utc).AddTicks(4984));

            migrationBuilder.CreateIndex(
                name: "IX_WaitingQueues_InvoiceId",
                table: "WaitingQueues",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_InvoiceId",
                table: "Visits",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_LabOrders_InvoiceId",
                table: "LabOrders",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_InvoiceId",
                table: "Appointments",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Invoices_InvoiceId",
                table: "Appointments",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_LabOrders_Invoices_InvoiceId",
                table: "LabOrders",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Invoices_InvoiceId",
                table: "Visits",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_WaitingQueues_Invoices_InvoiceId",
                table: "WaitingQueues",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Invoices_InvoiceId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_LabOrders_Invoices_InvoiceId",
                table: "LabOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Invoices_InvoiceId",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_WaitingQueues_Invoices_InvoiceId",
                table: "WaitingQueues");

            migrationBuilder.DropIndex(
                name: "IX_WaitingQueues_InvoiceId",
                table: "WaitingQueues");

            migrationBuilder.DropIndex(
                name: "IX_Visits_InvoiceId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_LabOrders_InvoiceId",
                table: "LabOrders");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_InvoiceId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "WaitingQueues");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "LabOrders");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Appointments");

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
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(2088));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(2095));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(2097));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(2099));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(2103));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(2105));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(2107));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(2109));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(2113));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(2115));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 9, 45, 37, 549, DateTimeKind.Utc).AddTicks(2117));

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
    }
}
