using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClinicFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLabEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LabCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true),
                    DeletedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LabOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitId = table.Column<int>(type: "int", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true),
                    DeletedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabOrders_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabOrders_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LabTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true),
                    DeletedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabTests_LabCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "LabCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LabOrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabOrderId = table.Column<int>(type: "int", nullable: false),
                    LabTestId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true),
                    DeletedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabOrderItems_LabOrders_LabOrderId",
                        column: x => x.LabOrderId,
                        principalTable: "LabOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabOrderItems_LabTests_LabTestId",
                        column: x => x.LabTestId,
                        principalTable: "LabTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LabTestParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabTestId = table.Column<int>(type: "int", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NormalRange = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true),
                    DeletedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTestParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabTestParameters_LabTests_LabTestId",
                        column: x => x.LabTestId,
                        principalTable: "LabTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LabResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabOrderItemId = table.Column<int>(type: "int", nullable: false),
                    ResultDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true),
                    DeletedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabResults_LabOrderItems_LabOrderItemId",
                        column: x => x.LabOrderItemId,
                        principalTable: "LabOrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LabResultValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabResultId = table.Column<int>(type: "int", nullable: false),
                    ParameterId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NumericValue = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NormalRange = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Flag = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true),
                    DeletedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabResultValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabResultValues_LabResults_LabResultId",
                        column: x => x.LabResultId,
                        principalTable: "LabResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabResultValues_LabTestParameters_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "LabTestParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 458, DateTimeKind.Utc).AddTicks(5374));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 458, DateTimeKind.Utc).AddTicks(5379));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 458, DateTimeKind.Utc).AddTicks(5381));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 458, DateTimeKind.Utc).AddTicks(5382));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 458, DateTimeKind.Utc).AddTicks(5383));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 458, DateTimeKind.Utc).AddTicks(5387));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 458, DateTimeKind.Utc).AddTicks(5388));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 458, DateTimeKind.Utc).AddTicks(5390));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 460, DateTimeKind.Utc).AddTicks(3099));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 460, DateTimeKind.Utc).AddTicks(3103));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 460, DateTimeKind.Utc).AddTicks(3105));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 460, DateTimeKind.Utc).AddTicks(3106));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 460, DateTimeKind.Utc).AddTicks(3108));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 460, DateTimeKind.Utc).AddTicks(3111));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 460, DateTimeKind.Utc).AddTicks(3112));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(2776));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(2782));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(2783));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(2784));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(2784));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(2787));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(2788));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(2789));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 460, DateTimeKind.Utc).AddTicks(6100));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 460, DateTimeKind.Utc).AddTicks(6105));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 460, DateTimeKind.Utc).AddTicks(6107));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 460, DateTimeKind.Utc).AddTicks(6109));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 460, DateTimeKind.Utc).AddTicks(6110));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 460, DateTimeKind.Utc).AddTicks(6113));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 460, DateTimeKind.Utc).AddTicks(6115));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 460, DateTimeKind.Utc).AddTicks(6116));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(6194));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(6199));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(6200));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(6202));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(6203));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(6205));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(6207));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(6208));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(6209));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(6245));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(6246));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(6248));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(6249));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(6250));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(6251));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 462, DateTimeKind.Utc).AddTicks(6276));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 462, DateTimeKind.Utc).AddTicks(6279));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 462, DateTimeKind.Utc).AddTicks(6280));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 462, DateTimeKind.Utc).AddTicks(6281));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 462, DateTimeKind.Utc).AddTicks(6282));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 462, DateTimeKind.Utc).AddTicks(6284));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 462, DateTimeKind.Utc).AddTicks(6285));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 462, DateTimeKind.Utc).AddTicks(6286));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 462, DateTimeKind.Utc).AddTicks(6287));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 462, DateTimeKind.Utc).AddTicks(6288));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(9782));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(9788));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(9790));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(9792));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(9794));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(9797));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(9799));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 461, DateTimeKind.Utc).AddTicks(9801));

            migrationBuilder.InsertData(
                table: "LabCategories",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsActive", "IsDeleted", "NameAr", "NameEn", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 13, 11, 35, 38, 463, DateTimeKind.Utc).AddTicks(412), null, null, null, true, false, "أمراض الدم", "Hematology", null, null },
                    { 2, new DateTime(2026, 9, 13, 11, 35, 38, 463, DateTimeKind.Utc).AddTicks(414), null, null, null, true, false, "الكيمياء الحيوية", "Biochemistry", null, null },
                    { 3, new DateTime(2026, 9, 13, 11, 35, 38, 463, DateTimeKind.Utc).AddTicks(415), null, null, null, true, false, "المناعة", "Immunology", null, null },
                    { 4, new DateTime(2026, 9, 13, 11, 35, 38, 463, DateTimeKind.Utc).AddTicks(416), null, null, null, true, false, "الأحياء الدقيقة", "Microbiology", null, null },
                    { 5, new DateTime(2026, 9, 13, 11, 35, 38, 463, DateTimeKind.Utc).AddTicks(417), null, null, null, true, false, "الهرمونات", "Hormones", null, null },
                    { 6, new DateTime(2026, 9, 13, 11, 35, 38, 463, DateTimeKind.Utc).AddTicks(420), null, null, null, true, false, "تحليل البول", "Urinalysis", null, null },
                    { 7, new DateTime(2026, 9, 13, 11, 35, 38, 463, DateTimeKind.Utc).AddTicks(421), null, null, null, true, false, "الأمصال", "Serology", null, null },
                    { 8, new DateTime(2026, 9, 13, 11, 35, 38, 463, DateTimeKind.Utc).AddTicks(422), null, null, null, true, false, "الطفيليات", "Parasitology", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 467, DateTimeKind.Utc).AddTicks(547));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 467, DateTimeKind.Utc).AddTicks(551));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 467, DateTimeKind.Utc).AddTicks(553));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 467, DateTimeKind.Utc).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 467, DateTimeKind.Utc).AddTicks(557));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 467, DateTimeKind.Utc).AddTicks(560));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 467, DateTimeKind.Utc).AddTicks(562));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 467, DateTimeKind.Utc).AddTicks(564));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 467, DateTimeKind.Utc).AddTicks(566));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 467, DateTimeKind.Utc).AddTicks(569));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 467, DateTimeKind.Utc).AddTicks(571));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 467, DateTimeKind.Utc).AddTicks(573));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 467, DateTimeKind.Utc).AddTicks(6653));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 467, DateTimeKind.Utc).AddTicks(6660));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 467, DateTimeKind.Utc).AddTicks(6662));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 467, DateTimeKind.Utc).AddTicks(6663));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 468, DateTimeKind.Utc).AddTicks(3040));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 468, DateTimeKind.Utc).AddTicks(3045));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 468, DateTimeKind.Utc).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 468, DateTimeKind.Utc).AddTicks(3049));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 468, DateTimeKind.Utc).AddTicks(3050));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 468, DateTimeKind.Utc).AddTicks(7522));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 468, DateTimeKind.Utc).AddTicks(7528));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 468, DateTimeKind.Utc).AddTicks(7531));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 468, DateTimeKind.Utc).AddTicks(7534));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 468, DateTimeKind.Utc).AddTicks(7536));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 470, DateTimeKind.Utc).AddTicks(1740));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 470, DateTimeKind.Utc).AddTicks(1744));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 470, DateTimeKind.Utc).AddTicks(1746));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 470, DateTimeKind.Utc).AddTicks(1747));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 470, DateTimeKind.Utc).AddTicks(1749));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 470, DateTimeKind.Utc).AddTicks(1752));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 470, DateTimeKind.Utc).AddTicks(1753));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 470, DateTimeKind.Utc).AddTicks(1755));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 470, DateTimeKind.Utc).AddTicks(1756));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 470, DateTimeKind.Utc).AddTicks(1758));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 470, DateTimeKind.Utc).AddTicks(1760));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 470, DateTimeKind.Utc).AddTicks(1763));

            migrationBuilder.InsertData(
                table: "LabTests",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsActive", "IsDeleted", "NameAr", "NameEn", "Price", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(707), null, null, null, true, false, "تعداد الدم الكامل", "Complete Blood Count", 15.00m, null, null },
                    { 2, 1, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(713), null, null, null, true, false, "سرعة ترسيب كريات الدم الحمراء", "Erythrocyte Sedimentation Rate", 10.00m, null, null },
                    { 3, 1, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(714), null, null, null, true, false, "الهيموغلوبين", "Hemoglobin", 8.00m, null, null },
                    { 4, 1, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(716), null, null, null, true, false, "فصيلة الدم وعامل ريسوس", "Blood Group and Rh", 10.00m, null, null },
                    { 5, 2, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(717), null, null, null, true, false, "وظائف الكبد", "Liver Function Test", 30.00m, null, null },
                    { 6, 2, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(764), null, null, null, true, false, "وظائف الكلى", "Kidney Function Test", 30.00m, null, null },
                    { 7, 2, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(766), null, null, null, true, false, "سكر الدم الصائم", "Fasting Blood Glucose", 10.00m, null, null },
                    { 8, 2, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(767), null, null, null, true, false, "سكر الدم العشوائي", "Random Blood Glucose", 10.00m, null, null },
                    { 9, 2, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(769), null, null, null, true, false, "السكر التراكمي", "HbA1c", 25.00m, null, null },
                    { 10, 2, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(771), null, null, null, true, false, "دهون الدم", "Lipid Profile", 35.00m, null, null },
                    { 11, 2, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(773), null, null, null, true, false, "حمض اليوريك", "Uric Acid", 12.00m, null, null },
                    { 12, 5, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(774), null, null, null, true, false, "الهرمون المنبه للغدة الدرقية", "Thyroid Stimulating Hormone", 25.00m, null, null },
                    { 13, 5, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(776), null, null, null, true, false, "الثيروكسين الحر", "Free Thyroxine", 25.00m, null, null },
                    { 14, 5, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(777), null, null, null, true, false, "هرمون الحمل", "Beta hCG", 20.00m, null, null },
                    { 15, 6, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(779), null, null, null, true, false, "تحليل البول", "Urinalysis", 15.00m, null, null },
                    { 16, 7, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(780), null, null, null, true, false, "اختبار فيدال", "Widal Test", 15.00m, null, null },
                    { 17, 7, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(782), null, null, null, true, false, "مستضد سطح التهاب الكبد B", "Hepatitis B Surface Antigen", 20.00m, null, null },
                    { 18, 7, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(784), null, null, null, true, false, "الأجسام المضادة لالتهاب الكبد C", "Hepatitis C Antibody", 20.00m, null, null },
                    { 19, 7, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(785), null, null, null, true, false, "فحص فيروس نقص المناعة البشرية", "HIV Screening Test", 20.00m, null, null },
                    { 20, 8, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(787), null, null, null, true, false, "فحص الملاريا", "Malaria Test", 15.00m, null, null },
                    { 21, 8, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(788), null, null, null, true, false, "فحص البراز", "Stool Examination", 15.00m, null, null }
                });

            migrationBuilder.InsertData(
                table: "LabTestParameters",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "DisplayOrder", "IsActive", "IsDeleted", "LabTestId", "NameAr", "NameEn", "NormalRange", "Unit", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6870), null, null, null, 1, true, false, 1, "الهيموغلوبين", "Hemoglobin", "Male: 13.0 - 17.0; Female: 12.0 - 15.0", "g/dL", null, null },
                    { 2, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6875), null, null, null, 2, true, false, 1, "عدد كريات الدم البيضاء", "White Blood Cell Count", "4.0 - 11.0", "10^3/µL", null, null },
                    { 3, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6876), null, null, null, 3, true, false, 1, "عدد كريات الدم الحمراء", "Red Blood Cell Count", "Male: 4.5 - 5.9; Female: 4.0 - 5.2", "10^6/µL", null, null },
                    { 4, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6877), null, null, null, 4, true, false, 1, "الهيماتوكريت", "Hematocrit", "Male: 41 - 53; Female: 36 - 46", "%", null, null },
                    { 5, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6879), null, null, null, 5, true, false, 1, "متوسط حجم كريات الدم الحمراء", "Mean Corpuscular Volume", "80 - 100", "fL", null, null },
                    { 6, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6882), null, null, null, 6, true, false, 1, "متوسط هيموغلوبين الكرية", "Mean Corpuscular Hemoglobin", "27 - 33", "pg", null, null },
                    { 7, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6883), null, null, null, 7, true, false, 1, "متوسط تركيز هيموغلوبين الكرية", "Mean Corpuscular Hemoglobin Concentration", "32 - 36", "g/dL", null, null },
                    { 8, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6985), null, null, null, 8, true, false, 1, "عدد الصفائح الدموية", "Platelet Count", "150 - 450", "10^3/µL", null, null },
                    { 9, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6987), null, null, null, 9, true, false, 1, "العدلات", "Neutrophils", "40 - 70", "%", null, null },
                    { 10, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6989), null, null, null, 10, true, false, 1, "الخلايا اللمفاوية", "Lymphocytes", "20 - 40", "%", null, null },
                    { 11, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6991), null, null, null, 1, true, false, 2, "سرعة ترسيب كريات الدم الحمراء", "Erythrocyte Sedimentation Rate", "Male: 0 - 15; Female: 0 - 20", "mm/hr", null, null },
                    { 12, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6992), null, null, null, 1, true, false, 3, "الهيموغلوبين", "Hemoglobin", "Male: 13.0 - 17.0; Female: 12.0 - 15.0", "g/dL", null, null },
                    { 13, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6993), null, null, null, 1, true, false, 4, "فصيلة الدم ABO", "ABO Blood Group", "A, B, AB, O", null, null, null },
                    { 14, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6995), null, null, null, 2, true, false, 4, "عامل ريسوس", "Rh Factor", "Positive / Negative", null, null, null },
                    { 15, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6996), null, null, null, 1, true, false, 5, "إنزيم ALT", "ALT", "7 - 56", "U/L", null, null },
                    { 16, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6997), null, null, null, 2, true, false, 5, "إنزيم AST", "AST", "10 - 40", "U/L", null, null },
                    { 17, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6999), null, null, null, 3, true, false, 5, "الفوسفاتاز القلوي", "Alkaline Phosphatase", "44 - 147", "U/L", null, null },
                    { 18, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7001), null, null, null, 4, true, false, 5, "البيليروبين الكلي", "Total Bilirubin", "0.1 - 1.2", "mg/dL", null, null },
                    { 19, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7002), null, null, null, 5, true, false, 5, "البيليروبين المباشر", "Direct Bilirubin", "0.0 - 0.3", "mg/dL", null, null },
                    { 20, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7004), null, null, null, 6, true, false, 5, "الألبومين", "Albumin", "3.5 - 5.0", "g/dL", null, null },
                    { 21, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7005), null, null, null, 1, true, false, 6, "الكرياتينين", "Creatinine", "Male: 0.74 - 1.35; Female: 0.59 - 1.04", "mg/dL", null, null },
                    { 22, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7006), null, null, null, 2, true, false, 6, "اليوريا", "Urea", "15 - 45", "mg/dL", null, null },
                    { 23, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7008), null, null, null, 1, true, false, 7, "سكر الدم الصائم", "Fasting Blood Glucose", "70 - 99", "mg/dL", null, null },
                    { 24, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7009), null, null, null, 1, true, false, 8, "سكر الدم العشوائي", "Random Blood Glucose", "< 200", "mg/dL", null, null },
                    { 25, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7010), null, null, null, 1, true, false, 9, "السكر التراكمي", "HbA1c", "4.0 - 5.6", "%", null, null },
                    { 26, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7012), null, null, null, 1, true, false, 10, "الكوليسترول الكلي", "Total Cholesterol", "< 200", "mg/dL", null, null },
                    { 27, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7013), null, null, null, 2, true, false, 10, "الكوليسترول عالي الكثافة HDL", "HDL Cholesterol", "Male: > 40; Female: > 50", "mg/dL", null, null },
                    { 28, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7014), null, null, null, 3, true, false, 10, "الكوليسترول منخفض الكثافة LDL", "LDL Cholesterol", "< 100", "mg/dL", null, null },
                    { 29, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7016), null, null, null, 4, true, false, 10, "الدهون الثلاثية", "Triglycerides", "< 150", "mg/dL", null, null },
                    { 30, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7017), null, null, null, 1, true, false, 11, "حمض اليوريك", "Uric Acid", "Male: 3.4 - 7.0; Female: 2.4 - 6.0", "mg/dL", null, null },
                    { 31, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7018), null, null, null, 1, true, false, 12, "الهرمون المنبه للغدة الدرقية", "TSH", "0.4 - 4.0", "mIU/L", null, null },
                    { 32, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7020), null, null, null, 1, true, false, 13, "الثيروكسين الحر", "Free T4", "0.8 - 1.8", "ng/dL", null, null },
                    { 33, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7021), null, null, null, 1, true, false, 14, "هرمون الحمل بيتا", "Beta hCG", "< 5", "mIU/mL", null, null },
                    { 34, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7023), null, null, null, 1, true, false, 15, "اللون", "Color", "Yellow", null, null, null },
                    { 35, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7025), null, null, null, 2, true, false, 15, "المظهر", "Appearance", "Clear", null, null, null },
                    { 36, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7026), null, null, null, 3, true, false, 15, "الكثافة النوعية", "Specific Gravity", "1.005 - 1.030", null, null, null },
                    { 37, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7027), null, null, null, 4, true, false, 15, "درجة الحموضة", "pH", "5.0 - 8.0", null, null, null },
                    { 38, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7029), null, null, null, 5, true, false, 15, "البروتين", "Protein", "Negative", null, null, null },
                    { 39, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7030), null, null, null, 6, true, false, 15, "الجلوكوز", "Glucose", "Negative", null, null, null },
                    { 40, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7031), null, null, null, 7, true, false, 15, "الدم", "Blood", "Negative", null, null, null },
                    { 41, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7033), null, null, null, 8, true, false, 15, "كريات الدم البيضاء", "White Blood Cells", "0 - 5", "/HPF", null, null },
                    { 42, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7034), null, null, null, 9, true, false, 15, "كريات الدم الحمراء", "Red Blood Cells", "0 - 2", "/HPF", null, null },
                    { 43, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7035), null, null, null, 1, true, false, 16, "السالمونيلا O", "Salmonella O", "Negative", null, null, null },
                    { 44, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7037), null, null, null, 2, true, false, 16, "السالمونيلا H", "Salmonella H", "Negative", null, null, null },
                    { 45, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7038), null, null, null, 1, true, false, 17, "مستضد سطح التهاب الكبد B", "HBsAg", "Non-reactive", null, null, null },
                    { 46, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7039), null, null, null, 1, true, false, 18, "الأجسام المضادة لالتهاب الكبد C", "HCV Antibody", "Non-reactive", null, null, null },
                    { 47, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7041), null, null, null, 1, true, false, 19, "فحص فيروس نقص المناعة البشرية", "HIV Screening", "Non-reactive", null, null, null },
                    { 48, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7042), null, null, null, 1, true, false, 20, "طفيليات الملاريا", "Malaria Parasite", "Not detected", null, null, null },
                    { 49, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7043), null, null, null, 1, true, false, 21, "اللون", "Color", "Brown", null, null, null },
                    { 50, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7045), null, null, null, 2, true, false, 21, "القوام", "Consistency", "Formed", null, null, null },
                    { 51, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7046), null, null, null, 3, true, false, 21, "الدم الخفي", "Occult Blood", "Negative", null, null, null },
                    { 52, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7047), null, null, null, 4, true, false, 21, "البيض", "Ova", "Not detected", null, null, null },
                    { 53, new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7049), null, null, null, 5, true, false, 21, "الطفيليات", "Parasites", "Not detected", null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabOrderItems_LabOrderId",
                table: "LabOrderItems",
                column: "LabOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_LabOrderItems_LabTestId",
                table: "LabOrderItems",
                column: "LabTestId");

            migrationBuilder.CreateIndex(
                name: "IX_LabOrders_PatientId",
                table: "LabOrders",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_LabOrders_VisitId",
                table: "LabOrders",
                column: "VisitId");

            migrationBuilder.CreateIndex(
                name: "IX_LabResults_LabOrderItemId",
                table: "LabResults",
                column: "LabOrderItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LabResultValues_ParameterId",
                table: "LabResultValues",
                column: "ParameterId");

            migrationBuilder.CreateIndex(
                name: "UX_LabResultValues_Result_Parameter",
                table: "LabResultValues",
                columns: new[] { "LabResultId", "ParameterId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_LabTestParameters_Test_DisplayOrder",
                table: "LabTestParameters",
                columns: new[] { "LabTestId", "DisplayOrder" },
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_LabTests_CategoryId",
                table: "LabTests",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabResultValues");

            migrationBuilder.DropTable(
                name: "LabResults");

            migrationBuilder.DropTable(
                name: "LabTestParameters");

            migrationBuilder.DropTable(
                name: "LabOrderItems");

            migrationBuilder.DropTable(
                name: "LabOrders");

            migrationBuilder.DropTable(
                name: "LabTests");

            migrationBuilder.DropTable(
                name: "LabCategories");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 315, DateTimeKind.Utc).AddTicks(8793));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 315, DateTimeKind.Utc).AddTicks(8797));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 315, DateTimeKind.Utc).AddTicks(8798));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 315, DateTimeKind.Utc).AddTicks(8800));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 315, DateTimeKind.Utc).AddTicks(8801));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 315, DateTimeKind.Utc).AddTicks(8803));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 315, DateTimeKind.Utc).AddTicks(8805));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 315, DateTimeKind.Utc).AddTicks(8806));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 317, DateTimeKind.Utc).AddTicks(7603));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 317, DateTimeKind.Utc).AddTicks(7608));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 317, DateTimeKind.Utc).AddTicks(7609));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 317, DateTimeKind.Utc).AddTicks(7611));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 317, DateTimeKind.Utc).AddTicks(7612));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 317, DateTimeKind.Utc).AddTicks(7614));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 317, DateTimeKind.Utc).AddTicks(7616));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 318, DateTimeKind.Utc).AddTicks(8975));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 318, DateTimeKind.Utc).AddTicks(8977));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 318, DateTimeKind.Utc).AddTicks(8978));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 318, DateTimeKind.Utc).AddTicks(8979));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 318, DateTimeKind.Utc).AddTicks(8980));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 318, DateTimeKind.Utc).AddTicks(8982));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 318, DateTimeKind.Utc).AddTicks(8983));

            migrationBuilder.UpdateData(
                table: "ClinicDoctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 318, DateTimeKind.Utc).AddTicks(8984));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 318, DateTimeKind.Utc).AddTicks(2016));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 318, DateTimeKind.Utc).AddTicks(2019));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 318, DateTimeKind.Utc).AddTicks(2021));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 318, DateTimeKind.Utc).AddTicks(2023));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 318, DateTimeKind.Utc).AddTicks(2025));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 318, DateTimeKind.Utc).AddTicks(2027));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 318, DateTimeKind.Utc).AddTicks(2029));

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 318, DateTimeKind.Utc).AddTicks(2031));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 319, DateTimeKind.Utc).AddTicks(2635));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 319, DateTimeKind.Utc).AddTicks(2640));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 319, DateTimeKind.Utc).AddTicks(2641));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 319, DateTimeKind.Utc).AddTicks(2643));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 319, DateTimeKind.Utc).AddTicks(2644));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 319, DateTimeKind.Utc).AddTicks(2646));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 319, DateTimeKind.Utc).AddTicks(2648));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 319, DateTimeKind.Utc).AddTicks(2649));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 319, DateTimeKind.Utc).AddTicks(2650));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 319, DateTimeKind.Utc).AddTicks(2652));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 319, DateTimeKind.Utc).AddTicks(2654));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 319, DateTimeKind.Utc).AddTicks(2655));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 319, DateTimeKind.Utc).AddTicks(2656));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 319, DateTimeKind.Utc).AddTicks(2658));

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 319, DateTimeKind.Utc).AddTicks(2664));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 320, DateTimeKind.Utc).AddTicks(1388));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 320, DateTimeKind.Utc).AddTicks(1392));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 320, DateTimeKind.Utc).AddTicks(1393));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 320, DateTimeKind.Utc).AddTicks(1394));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 320, DateTimeKind.Utc).AddTicks(1394));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 320, DateTimeKind.Utc).AddTicks(1397));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 320, DateTimeKind.Utc).AddTicks(1397));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 320, DateTimeKind.Utc).AddTicks(1398));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 320, DateTimeKind.Utc).AddTicks(1399));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 320, DateTimeKind.Utc).AddTicks(1401));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 319, DateTimeKind.Utc).AddTicks(5442));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 319, DateTimeKind.Utc).AddTicks(5448));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 319, DateTimeKind.Utc).AddTicks(5450));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 319, DateTimeKind.Utc).AddTicks(5451));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 319, DateTimeKind.Utc).AddTicks(5453));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 319, DateTimeKind.Utc).AddTicks(5456));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 319, DateTimeKind.Utc).AddTicks(5458));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 319, DateTimeKind.Utc).AddTicks(5460));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 320, DateTimeKind.Utc).AddTicks(5366));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 320, DateTimeKind.Utc).AddTicks(5369));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 320, DateTimeKind.Utc).AddTicks(5372));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 320, DateTimeKind.Utc).AddTicks(5374));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 320, DateTimeKind.Utc).AddTicks(5376));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 320, DateTimeKind.Utc).AddTicks(5379));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 320, DateTimeKind.Utc).AddTicks(5381));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 320, DateTimeKind.Utc).AddTicks(5388));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 320, DateTimeKind.Utc).AddTicks(5390));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 320, DateTimeKind.Utc).AddTicks(5393));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 320, DateTimeKind.Utc).AddTicks(5395));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 320, DateTimeKind.Utc).AddTicks(5397));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 321, DateTimeKind.Utc).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 321, DateTimeKind.Utc).AddTicks(2201));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 321, DateTimeKind.Utc).AddTicks(2206));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 321, DateTimeKind.Utc).AddTicks(2207));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 321, DateTimeKind.Utc).AddTicks(8809));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 321, DateTimeKind.Utc).AddTicks(8814));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 321, DateTimeKind.Utc).AddTicks(8818));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 321, DateTimeKind.Utc).AddTicks(8819));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 321, DateTimeKind.Utc).AddTicks(8821));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 322, DateTimeKind.Utc).AddTicks(3092));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 322, DateTimeKind.Utc).AddTicks(3099));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 322, DateTimeKind.Utc).AddTicks(3102));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 322, DateTimeKind.Utc).AddTicks(3104));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 322, DateTimeKind.Utc).AddTicks(3107));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 324, DateTimeKind.Utc).AddTicks(1062));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 324, DateTimeKind.Utc).AddTicks(1066));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 324, DateTimeKind.Utc).AddTicks(1068));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 324, DateTimeKind.Utc).AddTicks(1069));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 324, DateTimeKind.Utc).AddTicks(1070));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 324, DateTimeKind.Utc).AddTicks(1073));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 324, DateTimeKind.Utc).AddTicks(1074));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 324, DateTimeKind.Utc).AddTicks(1076));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 324, DateTimeKind.Utc).AddTicks(1077));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 324, DateTimeKind.Utc).AddTicks(1079));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 324, DateTimeKind.Utc).AddTicks(1080));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 10, 13, 45, 27, 324, DateTimeKind.Utc).AddTicks(1082));
        }
    }
}
