using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClinicFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientsEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DescriptionEn = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DescriptionAr = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_Allergies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChronicConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DescriptionEn = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DescriptionAr = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_ChronicConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BloodType = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientAllergies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    AllergyId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IdentifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_PatientAllergies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientAllergies_Allergies_AllergyId",
                        column: x => x.AllergyId,
                        principalTable: "Allergies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientAllergies_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientChronicConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    ChronicConditionId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    DiagnosedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_PatientChronicConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientChronicConditions_ChronicConditions_ChronicConditionId",
                        column: x => x.ChronicConditionId,
                        principalTable: "ChronicConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientChronicConditions_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Allergies",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "DescriptionAr", "DescriptionEn", "IsActive", "IsDeleted", "NameAr", "NameEn", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(102), null, null, null, "حساسية تجاه المضادات الحيوية من نوع البنسلين", "Allergy to penicillin antibiotics", true, false, "البنسلين", "Penicillin", null, null },
                    { 2, new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(107), null, null, null, "حساسية تجاه الأسبرين", "Allergy to aspirin", true, false, "الأسبرين", "Aspirin", null, null },
                    { 3, new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(108), null, null, null, "حساسية تجاه الإيبوبروفين", "Allergy to ibuprofen", true, false, "الإيبوبروفين", "Ibuprofen", null, null },
                    { 4, new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(109), null, null, null, "حساسية تجاه مادة اللاتكس", "Allergy to latex", true, false, "اللاتكس", "Latex", null, null },
                    { 5, new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(111), null, null, null, "حساسية تجاه الفول السوداني", "Allergy to peanuts", true, false, "الفول السوداني", "Peanuts", null, null },
                    { 6, new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(116), null, null, null, "حساسية تجاه الحليب أو منتجات الألبان", "Allergy to milk or dairy products", true, false, "الحليب", "Milk", null, null },
                    { 7, new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(117), null, null, null, "حساسية تجاه البيض", "Allergy to eggs", true, false, "البيض", "Eggs", null, null },
                    { 8, new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(118), null, null, null, "حساسية تجاه المحار", "Allergy to shellfish", true, false, "المحار", "Shellfish", null, null }
                });

            migrationBuilder.InsertData(
                table: "ChronicConditions",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "DescriptionAr", "DescriptionEn", "IsActive", "IsDeleted", "NameAr", "NameEn", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(3697), null, null, null, "اضطراب أيضي يتميز بارتفاع مستوى سكر الدم", "A metabolic disorder characterized by elevated blood glucose levels", true, false, "داء السكري", "Diabetes Mellitus", null, null },
                    { 2, new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(3701), null, null, null, "ارتفاع مستمر في ضغط الدم", "Persistently elevated blood pressure", true, false, "ارتفاع ضغط الدم", "Hypertension", null, null },
                    { 3, new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(3737), null, null, null, "حالة تنفسية مزمنة تؤثر على الشعب الهوائية", "A chronic respiratory condition affecting the airways", true, false, "الربو", "Asthma", null, null },
                    { 4, new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(3738), null, null, null, "ضعف طويل الأمد في وظائف الكلى", "Long-term impairment of kidney function", true, false, "مرض الكلى المزمن", "Chronic Kidney Disease", null, null },
                    { 5, new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(3739), null, null, null, "حالة مزمنة تؤثر على القلب", "A chronic condition affecting the heart", true, false, "أمراض القلب", "Heart Disease", null, null },
                    { 6, new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(3743), null, null, null, "اضطراب يؤثر على وظائف الغدة الدرقية", "A disorder affecting thyroid function", true, false, "اضطراب الغدة الدرقية", "Thyroid Disorder", null, null },
                    { 7, new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(3744), null, null, null, "مرض رئوي مزمن يسبب محدودية تدفق الهواء", "A chronic lung disease causing airflow limitation", true, false, "مرض الانسداد الرئوي المزمن", "Chronic Obstructive Pulmonary Disease", null, null }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "BloodType", "CreatedAt", "CreatedByUserId", "DateOfBirth", "DeletedAt", "DeletedByUserId", "Email", "FullName", "Gender", "IsActive", "IsDeleted", "NationalId", "PhoneNumber", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, "Khartoum", 7, new DateTime(2026, 8, 31, 14, 29, 59, 38, DateTimeKind.Utc).AddTicks(8673), null, new DateTime(1985, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "ahmed.hassan@example.com", "Ahmed Hassan", 1, true, false, "1234567890", "0912345678", null, null },
                    { 2, "Omdurman", 1, new DateTime(2026, 8, 31, 14, 29, 59, 38, DateTimeKind.Utc).AddTicks(8679), null, new DateTime(1992, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "sara.mohamed@example.com", "Sara Mohamed", 2, true, false, "0987654321", "0998765432", null, null },
                    { 3, "Bahri", 3, new DateTime(2026, 8, 31, 14, 29, 59, 38, DateTimeKind.Utc).AddTicks(8682), null, new DateTime(1978, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "mohamed.ali@example.com", "Mohamed Ali", 1, true, false, "1122334455", "0911223344", null, null },
                    { 4, "Khartoum", 6, new DateTime(2026, 8, 31, 14, 29, 59, 38, DateTimeKind.Utc).AddTicks(8684), null, new DateTime(2000, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "fatima.ahmed@example.com", "Fatima Ahmed", 2, true, false, "2233445566", "0922334455", null, null },
                    { 5, "Omdurman", 8, new DateTime(2026, 8, 31, 14, 29, 59, 38, DateTimeKind.Utc).AddTicks(8686), null, new DateTime(1969, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "omar.ibrahim@example.com", "Omar Ibrahim", 1, true, false, "3344556677", "0933445566", null, null }
                });

            migrationBuilder.InsertData(
                table: "PatientAllergies",
                columns: new[] { "Id", "AllergyId", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IdentifiedAt", "IsDeleted", "Notes", "PatientId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(9168), null, null, null, new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Known penicillin allergy", 1, null, null },
                    { 2, 4, new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(9206), null, null, null, new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Avoid latex products", 1, null, null },
                    { 3, 2, new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(9208), null, null, null, new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Reported by patient", 2, null, null },
                    { 4, 5, new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(9210), null, null, null, new DateTime(2018, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Food allergy", 3, null, null }
                });

            migrationBuilder.InsertData(
                table: "PatientChronicConditions",
                columns: new[] { "Id", "ChronicConditionId", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "DiagnosedAt", "IsDeleted", "Notes", "PatientId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 8, 31, 14, 29, 59, 38, DateTimeKind.Utc).AddTicks(4649), null, null, null, new DateTime(2018, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Type 2 diabetes", 1, null, null },
                    { 2, 2, new DateTime(2026, 8, 31, 14, 29, 59, 38, DateTimeKind.Utc).AddTicks(4655), null, null, null, new DateTime(2020, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Currently under treatment", 1, null, null },
                    { 3, 3, new DateTime(2026, 8, 31, 14, 29, 59, 38, DateTimeKind.Utc).AddTicks(4657), null, null, null, new DateTime(2016, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Intermittent asthma", 2, null, null },
                    { 4, 2, new DateTime(2026, 8, 31, 14, 29, 59, 38, DateTimeKind.Utc).AddTicks(4659), null, null, null, new DateTime(2019, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Regular blood pressure monitoring", 3, null, null },
                    { 5, 4, new DateTime(2026, 8, 31, 14, 29, 59, 38, DateTimeKind.Utc).AddTicks(4660), null, null, null, new DateTime(2022, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Requires regular kidney function monitoring", 5, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "UX_Allergies_NameAr",
                table: "Allergies",
                column: "NameAr",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "UX_Allergies_NameEn",
                table: "Allergies",
                column: "NameEn",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "UX_ChronicConditions_NameAr",
                table: "ChronicConditions",
                column: "NameAr",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "UX_ChronicConditions_NameEn",
                table: "ChronicConditions",
                column: "NameEn",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAllergies_AllergyId",
                table: "PatientAllergies",
                column: "AllergyId");

            migrationBuilder.CreateIndex(
                name: "UX_PatientAllergies_Patient_Allergy",
                table: "PatientAllergies",
                columns: new[] { "PatientId", "AllergyId" },
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_PatientChronicConditions_ChronicConditionId",
                table: "PatientChronicConditions",
                column: "ChronicConditionId");

            migrationBuilder.CreateIndex(
                name: "UX_PatientChronicConditions_Patient_Condition",
                table: "PatientChronicConditions",
                columns: new[] { "PatientId", "ChronicConditionId" },
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Email",
                table: "Patients",
                column: "Email",
                filter: "[Email] IS NOT NULL AND [IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PhoneNumber",
                table: "Patients",
                column: "PhoneNumber",
                filter: "[PhoneNumber] IS NOT NULL AND [IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "UX_Patients_NationalId",
                table: "Patients",
                column: "NationalId",
                unique: true,
                filter: "[NationalId] IS NOT NULL AND [IsDeleted] = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientAllergies");

            migrationBuilder.DropTable(
                name: "PatientChronicConditions");

            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "ChronicConditions");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
