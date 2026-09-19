using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClinicFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountingEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BondCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true),
                    DeletedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BondCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0.00m),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0.00m),
                    GrandTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0.00m),
                    RemainingAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true),
                    DeletedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true),
                    DeletedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ItemType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ReferenceId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true),
                    DeletedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bonds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BondNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Party = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PartyId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true),
                    DeletedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bonds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bonds_BondCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "BondCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bonds_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoicePayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true),
                    DeletedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoicePayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoicePayments_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoicePayments_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.InsertData(
                table: "BondCategories",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsActive", "IsDeleted", "NameAr", "NameEn", "Type", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 19, 8, 28, 41, 699, DateTimeKind.Utc).AddTicks(5243), null, null, null, true, false, "قبض عام", "General Receipt", "Receipt", null, null },
                    { 2, new DateTime(2026, 9, 19, 8, 28, 41, 699, DateTimeKind.Utc).AddTicks(5245), null, null, null, true, false, "مصروفات عامة", "General Expense", "Payment", null, null },
                    { 3, new DateTime(2026, 9, 19, 8, 28, 41, 699, DateTimeKind.Utc).AddTicks(5246), null, null, null, true, false, "دفعة للمورد", "Supplier Payment", "Payment", null, null }
                });

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

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsActive", "IsDeleted", "NameAr", "NameEn", "Type", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 19, 8, 28, 41, 724, DateTimeKind.Utc).AddTicks(4348), null, null, null, true, false, "نقداً", "Cash", "Cash", null, null },
                    { 2, new DateTime(2026, 9, 19, 8, 28, 41, 724, DateTimeKind.Utc).AddTicks(4351), null, null, null, true, false, "بنكك", "Bankak", "BankTransfer", null, null },
                    { 3, new DateTime(2026, 9, 19, 8, 28, 41, 724, DateTimeKind.Utc).AddTicks(4454), null, null, null, true, false, "فوري", "Fawry", "BankTransfer", null, null },
                    { 4, new DateTime(2026, 9, 19, 8, 28, 41, 724, DateTimeKind.Utc).AddTicks(4456), null, null, null, true, false, "ساهل", "Salih", "BankTransfer", null, null },
                    { 5, new DateTime(2026, 9, 19, 8, 28, 41, 724, DateTimeKind.Utc).AddTicks(4457), null, null, null, true, false, "أوكاش", "OCash", "BankTransfer", null, null }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Bonds_CategoryId",
                table: "Bonds",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Bonds_PaymentMethodId",
                table: "Bonds",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "UX_Bonds_BondNumber",
                table: "Bonds",
                column: "BondNumber",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_InvoiceId",
                table: "InvoiceItems",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePayments_InvoiceId",
                table: "InvoicePayments",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePayments_PaymentMethodId",
                table: "InvoicePayments",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "UX_InvoicePayments_ReceiptNumber",
                table: "InvoicePayments",
                column: "ReceiptNumber",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PatientId",
                table: "Invoices",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "UX_Invoices_InvoiceNumber",
                table: "Invoices",
                column: "InvoiceNumber",
                unique: true,
                filter: "[IsDeleted] = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bonds");

            migrationBuilder.DropTable(
                name: "InvoiceItems");

            migrationBuilder.DropTable(
                name: "InvoicePayments");

            migrationBuilder.DropTable(
                name: "BondCategories");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

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

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 463, DateTimeKind.Utc).AddTicks(412));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 463, DateTimeKind.Utc).AddTicks(414));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 463, DateTimeKind.Utc).AddTicks(415));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 463, DateTimeKind.Utc).AddTicks(416));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 463, DateTimeKind.Utc).AddTicks(417));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 463, DateTimeKind.Utc).AddTicks(420));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 463, DateTimeKind.Utc).AddTicks(421));

            migrationBuilder.UpdateData(
                table: "LabCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 463, DateTimeKind.Utc).AddTicks(422));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6870));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6875));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6876));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6877));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6879));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6882));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6883));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6985));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6987));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6989));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6991));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6992));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6993));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6995));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6996));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6997));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(6999));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7001));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7002));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7004));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7005));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7006));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7008));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7009));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7010));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7012));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7013));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7014));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7016));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7017));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7018));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7020));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7021));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7023));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7025));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7026));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7027));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7029));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7030));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7031));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7033));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7034));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7035));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7037));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7038));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7039));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7041));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7042));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7043));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7045));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7046));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7047));

            migrationBuilder.UpdateData(
                table: "LabTestParameters",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(7049));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(707));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(713));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(714));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(716));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(717));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(764));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(766));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(767));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(769));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(771));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(773));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(774));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(776));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(777));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(779));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(780));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(784));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(785));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(787));

            migrationBuilder.UpdateData(
                table: "LabTests",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 13, 11, 35, 38, 466, DateTimeKind.Utc).AddTicks(788));

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
        }
    }
}
