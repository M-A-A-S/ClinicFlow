using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RestrictPaymentMethodDeletion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 497, DateTimeKind.Utc).AddTicks(8447));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 497, DateTimeKind.Utc).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 497, DateTimeKind.Utc).AddTicks(8461));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 497, DateTimeKind.Utc).AddTicks(8462));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 497, DateTimeKind.Utc).AddTicks(8464));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 497, DateTimeKind.Utc).AddTicks(8466));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 497, DateTimeKind.Utc).AddTicks(8468));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 497, DateTimeKind.Utc).AddTicks(8469));

            migrationBuilder.UpdateData(
                table: "BondCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 499, DateTimeKind.Utc).AddTicks(7898));

            migrationBuilder.UpdateData(
                table: "BondCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 499, DateTimeKind.Utc).AddTicks(7912));

            migrationBuilder.UpdateData(
                table: "BondCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 499, DateTimeKind.Utc).AddTicks(7913));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 500, DateTimeKind.Utc).AddTicks(9546));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 500, DateTimeKind.Utc).AddTicks(9561));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 500, DateTimeKind.Utc).AddTicks(9562));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 500, DateTimeKind.Utc).AddTicks(9564));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 500, DateTimeKind.Utc).AddTicks(9565));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 500, DateTimeKind.Utc).AddTicks(9594));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 500, DateTimeKind.Utc).AddTicks(9595));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(497));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(507));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(508));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(509));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(510));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(512));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(513));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(514));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 501, DateTimeKind.Utc).AddTicks(3136));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 501, DateTimeKind.Utc).AddTicks(3150));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 501, DateTimeKind.Utc).AddTicks(3152));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 501, DateTimeKind.Utc).AddTicks(3153));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 501, DateTimeKind.Utc).AddTicks(3155));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 501, DateTimeKind.Utc).AddTicks(3158));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 501, DateTimeKind.Utc).AddTicks(3164));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 501, DateTimeKind.Utc).AddTicks(3166));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(4273));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(4287));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(4288));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(4290));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(4291));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(4294));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(4295));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(4296));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(4297));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(4299));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(4301));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(4302));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(4303));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(4304));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(4306));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 503, DateTimeKind.Utc).AddTicks(4647));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 503, DateTimeKind.Utc).AddTicks(4662));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 503, DateTimeKind.Utc).AddTicks(4663));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 503, DateTimeKind.Utc).AddTicks(4664));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 503, DateTimeKind.Utc).AddTicks(4665));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 503, DateTimeKind.Utc).AddTicks(4667));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 503, DateTimeKind.Utc).AddTicks(4668));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 503, DateTimeKind.Utc).AddTicks(4669));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 503, DateTimeKind.Utc).AddTicks(4670));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 503, DateTimeKind.Utc).AddTicks(4671));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(7728));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(7741));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(7743));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(7745));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(7747));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(7750));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(7752));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 502, DateTimeKind.Utc).AddTicks(7753));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 506, DateTimeKind.Utc).AddTicks(3545));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 506, DateTimeKind.Utc).AddTicks(3565));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 506, DateTimeKind.Utc).AddTicks(3566));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 506, DateTimeKind.Utc).AddTicks(3568));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 506, DateTimeKind.Utc).AddTicks(3569));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 506, DateTimeKind.Utc).AddTicks(3572));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 506, DateTimeKind.Utc).AddTicks(3573));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 506, DateTimeKind.Utc).AddTicks(3690));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1005));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1024));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1026));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1027));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1028));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1031));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1033));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1034));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1036));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1037));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1039));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1040));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1042));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1043));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1045));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1046));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1047));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1049));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1051));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1052));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1054));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1055));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1056));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1058));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1059));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1061));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1062));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1063));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1065));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1066));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1067));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1069));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1095));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1098));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1099));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1100));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1102));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1103));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1104));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1106));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1107));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1109));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1110));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1111));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1113));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1114));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1116));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1117));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1118));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1120));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1121));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1123));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(1124));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 510, DateTimeKind.Utc).AddTicks(5372));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 510, DateTimeKind.Utc).AddTicks(5388));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 510, DateTimeKind.Utc).AddTicks(5390));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 510, DateTimeKind.Utc).AddTicks(5392));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 510, DateTimeKind.Utc).AddTicks(5393));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 510, DateTimeKind.Utc).AddTicks(5396));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 510, DateTimeKind.Utc).AddTicks(5397));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 510, DateTimeKind.Utc).AddTicks(5399));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 510, DateTimeKind.Utc).AddTicks(5400));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 510, DateTimeKind.Utc).AddTicks(5402));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 510, DateTimeKind.Utc).AddTicks(5404));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 510, DateTimeKind.Utc).AddTicks(5405));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 510, DateTimeKind.Utc).AddTicks(5407));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 510, DateTimeKind.Utc).AddTicks(5408));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 510, DateTimeKind.Utc).AddTicks(5410));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 510, DateTimeKind.Utc).AddTicks(5411));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 510, DateTimeKind.Utc).AddTicks(5413));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 510, DateTimeKind.Utc).AddTicks(5415));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 510, DateTimeKind.Utc).AddTicks(5416));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 510, DateTimeKind.Utc).AddTicks(5425));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 510, DateTimeKind.Utc).AddTicks(5427));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(5289));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(5300));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(5302));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(5304));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(5307));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(5310));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(5312));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(5314));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(5316));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(5319));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(5321));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 511, DateTimeKind.Utc).AddTicks(5324));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 512, DateTimeKind.Utc).AddTicks(2117));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 512, DateTimeKind.Utc).AddTicks(2136));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 512, DateTimeKind.Utc).AddTicks(2138));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 512, DateTimeKind.Utc).AddTicks(2139));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 513, DateTimeKind.Utc).AddTicks(1167));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 513, DateTimeKind.Utc).AddTicks(1189));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 513, DateTimeKind.Utc).AddTicks(1196));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 513, DateTimeKind.Utc).AddTicks(1198));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 513, DateTimeKind.Utc).AddTicks(1200));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 513, DateTimeKind.Utc).AddTicks(7582));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 513, DateTimeKind.Utc).AddTicks(7603));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 513, DateTimeKind.Utc).AddTicks(7607));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 513, DateTimeKind.Utc).AddTicks(7610));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 513, DateTimeKind.Utc).AddTicks(7613));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 514, DateTimeKind.Utc).AddTicks(979));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 514, DateTimeKind.Utc).AddTicks(988));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 514, DateTimeKind.Utc).AddTicks(989));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 514, DateTimeKind.Utc).AddTicks(990));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 514, DateTimeKind.Utc).AddTicks(992));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 515, DateTimeKind.Utc).AddTicks(5934));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 515, DateTimeKind.Utc).AddTicks(5949));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 515, DateTimeKind.Utc).AddTicks(5950));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 515, DateTimeKind.Utc).AddTicks(5952));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 515, DateTimeKind.Utc).AddTicks(5953));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 515, DateTimeKind.Utc).AddTicks(5955));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 515, DateTimeKind.Utc).AddTicks(5957));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 515, DateTimeKind.Utc).AddTicks(5958));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 515, DateTimeKind.Utc).AddTicks(5959));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 515, DateTimeKind.Utc).AddTicks(5961));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 515, DateTimeKind.Utc).AddTicks(5963));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 1, 11, 45, 11, 515, DateTimeKind.Utc).AddTicks(5964));
        }
    }
}
