using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClinicFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddClinicsClinicDoctorsAndDiagnoses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
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
                    table.PrimaryKey("PK_Clinics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diagnoses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
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
                    table.PrimaryKey("PK_Diagnoses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClinicDoctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_ClinicDoctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicDoctors_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClinicDoctors_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 276, DateTimeKind.Utc).AddTicks(1194));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 276, DateTimeKind.Utc).AddTicks(1198));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 276, DateTimeKind.Utc).AddTicks(1200));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 276, DateTimeKind.Utc).AddTicks(1201));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 276, DateTimeKind.Utc).AddTicks(1202));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 276, DateTimeKind.Utc).AddTicks(1205));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 276, DateTimeKind.Utc).AddTicks(1207));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 276, DateTimeKind.Utc).AddTicks(1208));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 276, DateTimeKind.Utc).AddTicks(5511));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 276, DateTimeKind.Utc).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 276, DateTimeKind.Utc).AddTicks(5521));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 276, DateTimeKind.Utc).AddTicks(5522));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 276, DateTimeKind.Utc).AddTicks(5524));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 276, DateTimeKind.Utc).AddTicks(5528));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 276, DateTimeKind.Utc).AddTicks(5530));

            migrationBuilder.InsertData(
                table: "Clinics",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "DescriptionAr", "DescriptionEn", "IsActive", "IsDeleted", "NameAr", "NameEn", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 7, 7, 49, 52, 277, DateTimeKind.Utc).AddTicks(2172), null, null, null, "تشخيص وعلاج أمراض الباطنة لدى البالغين.", "Diagnosis and treatment of adult internal medicine conditions.", true, false, "عيادة الباطنة", "Internal Medicine Clinic", null, null },
                    { 2, new DateTime(2026, 9, 7, 7, 49, 52, 277, DateTimeKind.Utc).AddTicks(2181), null, null, null, "تشخيص وعلاج أمراض القلب والأوعية الدموية.", "Diagnosis and treatment of cardiovascular diseases.", true, false, "عيادة القلب", "Cardiology Clinic", null, null },
                    { 3, new DateTime(2026, 9, 7, 7, 49, 52, 277, DateTimeKind.Utc).AddTicks(2183), null, null, null, "الرعاية الطبية للرضع والأطفال والمراهقين.", "Medical care for infants, children, and adolescents.", true, false, "عيادة الأطفال", "Pediatric Clinic", null, null },
                    { 4, new DateTime(2026, 9, 7, 7, 49, 52, 277, DateTimeKind.Utc).AddTicks(2184), null, null, null, "تشخيص وعلاج أمراض الأسنان والفم.", "Diagnosis and treatment of dental and oral conditions.", true, false, "عيادة الأسنان", "Dental Clinic", null, null },
                    { 5, new DateTime(2026, 9, 7, 7, 49, 52, 277, DateTimeKind.Utc).AddTicks(2186), null, null, null, "تشخيص وعلاج أمراض الجلد والشعر والأظافر.", "Diagnosis and treatment of skin, hair, and nail conditions.", true, false, "عيادة الجلدية", "Dermatology Clinic", null, null },
                    { 6, new DateTime(2026, 9, 7, 7, 49, 52, 277, DateTimeKind.Utc).AddTicks(2190), null, null, null, "تشخيص وعلاج أمراض الأنف والأذن والحنجرة.", "Diagnosis and treatment of ear, nose, and throat conditions.", true, false, "عيادة الأنف والأذن والحنجرة", "ENT Clinic", null, null },
                    { 7, new DateTime(2026, 9, 7, 7, 49, 52, 277, DateTimeKind.Utc).AddTicks(2191), null, null, null, "تشخيص وعلاج أمراض العيون ومشاكل النظر.", "Diagnosis and treatment of eye and vision conditions.", true, false, "عيادة العيون", "Ophthalmology Clinic", null, null },
                    { 8, new DateTime(2026, 9, 7, 7, 49, 52, 277, DateTimeKind.Utc).AddTicks(2193), null, null, null, "الرعاية الأولية للحالات الطبية الشائعة.", "Primary care for common medical conditions.", true, false, "عيادة الطب العام", "General Practice Clinic", null, null }
                });

            migrationBuilder.InsertData(
                table: "Diagnoses",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "DescriptionAr", "DescriptionEn", "IsActive", "IsDeleted", "NameAr", "NameEn", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 7, 7, 49, 52, 280, DateTimeKind.Utc).AddTicks(3821), null, null, null, "ارتفاع ضغط الدم الأساسي دون سبب ثانوي محدد.", "Primary hypertension without a specified secondary cause.", true, false, "ارتفاع ضغط الدم الأساسي", "Essential hypertension", null, null },
                    { 2, new DateTime(2026, 9, 7, 7, 49, 52, 280, DateTimeKind.Utc).AddTicks(3828), null, null, null, "داء السكري من النوع الثاني دون مضاعفات مسجلة.", "Type 2 diabetes mellitus without documented complications.", true, false, "داء السكري من النوع الثاني دون مضاعفات", "Type 2 diabetes mellitus without complications", null, null },
                    { 3, new DateTime(2026, 9, 7, 7, 49, 52, 280, DateTimeKind.Utc).AddTicks(3829), null, null, null, "عدوى حادة في الجهاز التنفسي العلوي دون تحديد السبب.", "Acute upper respiratory infection without a specified cause.", true, false, "عدوى الجهاز التنفسي العلوي الحادة غير المحددة", "Acute upper respiratory infection, unspecified", null, null },
                    { 4, new DateTime(2026, 9, 7, 7, 49, 52, 280, DateTimeKind.Utc).AddTicks(3831), null, null, null, "مرض الربو دون تحديد نوع أو تفاصيل إضافية.", "Asthma without further specification.", true, false, "الربو غير المحدد", "Asthma, unspecified", null, null },
                    { 5, new DateTime(2026, 9, 7, 7, 49, 52, 280, DateTimeKind.Utc).AddTicks(3832), null, null, null, "ارتفاع مستوى الدهون في الدم دون تحديد إضافي.", "Elevated blood lipids without further specification.", true, false, "فرط شحميات الدم غير المحدد", "Hyperlipidemia, unspecified", null, null },
                    { 6, new DateTime(2026, 9, 7, 7, 49, 52, 280, DateTimeKind.Utc).AddTicks(3836), null, null, null, "مرض الارتجاع المعدي المريئي دون التهاب في المريء.", "Gastro-esophageal reflux disease without esophagitis.", true, false, "مرض الارتجاع المعدي المريئي دون التهاب المريء", "Gastro-esophageal reflux disease without esophagitis", null, null },
                    { 7, new DateTime(2026, 9, 7, 7, 49, 52, 280, DateTimeKind.Utc).AddTicks(3837), null, null, null, "ألم في منطقة أسفل الظهر.", "Pain located in the lower back.", true, false, "ألم أسفل الظهر", "Low back pain", null, null },
                    { 8, new DateTime(2026, 9, 7, 7, 49, 52, 280, DateTimeKind.Utc).AddTicks(3838), null, null, null, "الصداع النصفي دون تحديد إضافي.", "Migraine without further specification.", true, false, "الصداع النصفي غير المحدد", "Migraine, unspecified", null, null },
                    { 9, new DateTime(2026, 9, 7, 7, 49, 52, 280, DateTimeKind.Utc).AddTicks(3840), null, null, null, "التهاب رئوي دون تحديد الكائن المسبب.", "Pneumonia without identification of the causative organism.", true, false, "الالتهاب الرئوي غير المحدد", "Pneumonia, unspecified organism", null, null },
                    { 10, new DateTime(2026, 9, 7, 7, 49, 52, 280, DateTimeKind.Utc).AddTicks(3842), null, null, null, "التهاب في المسالك البولية دون تحديد الموقع.", "Urinary tract infection without a specified site.", true, false, "التهاب المسالك البولية غير المحدد", "Urinary tract infection, site not specified", null, null },
                    { 11, new DateTime(2026, 9, 7, 7, 49, 52, 280, DateTimeKind.Utc).AddTicks(3843), null, null, null, "التهاب الجلد التأتبي دون تحديد إضافي.", "Atopic dermatitis without further specification.", true, false, "التهاب الجلد التأتبي غير المحدد", "Atopic dermatitis, unspecified", null, null },
                    { 12, new DateTime(2026, 9, 7, 7, 49, 52, 280, DateTimeKind.Utc).AddTicks(3844), null, null, null, "التهاب ملتحمة العين دون تحديد إضافي.", "Inflammation of the conjunctiva without further specification.", true, false, "التهاب الملتحمة غير المحدد", "Conjunctivitis, unspecified", null, null },
                    { 13, new DateTime(2026, 9, 7, 7, 49, 52, 280, DateTimeKind.Utc).AddTicks(3845), null, null, null, "التهاب بطانة المعدة دون تحديد إضافي.", "Inflammation of the stomach lining without further specification.", true, false, "التهاب المعدة غير المحدد", "Gastritis, unspecified", null, null },
                    { 14, new DateTime(2026, 9, 7, 7, 49, 52, 280, DateTimeKind.Utc).AddTicks(3846), null, null, null, "فقر الدم دون تحديد نوعه.", "Anemia without further specification.", true, false, "فقر الدم غير المحدد", "Anemia, unspecified", null, null },
                    { 15, new DateTime(2026, 9, 7, 7, 49, 52, 280, DateTimeKind.Utc).AddTicks(3847), null, null, null, "قصور الغدة الدرقية دون تحديد إضافي.", "Hypothyroidism without further specification.", true, false, "قصور الغدة الدرقية غير المحدد", "Hypothyroidism, unspecified", null, null }
                });

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 281, DateTimeKind.Utc).AddTicks(4546));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 281, DateTimeKind.Utc).AddTicks(4551));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 281, DateTimeKind.Utc).AddTicks(4552));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 281, DateTimeKind.Utc).AddTicks(4553));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 281, DateTimeKind.Utc).AddTicks(4553));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 281, DateTimeKind.Utc).AddTicks(4556));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 281, DateTimeKind.Utc).AddTicks(4557));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 281, DateTimeKind.Utc).AddTicks(4558));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 281, DateTimeKind.Utc).AddTicks(4558));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 281, DateTimeKind.Utc).AddTicks(4560));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 280, DateTimeKind.Utc).AddTicks(8426));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 280, DateTimeKind.Utc).AddTicks(8432));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 280, DateTimeKind.Utc).AddTicks(8434));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 280, DateTimeKind.Utc).AddTicks(8436));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 280, DateTimeKind.Utc).AddTicks(8437));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 280, DateTimeKind.Utc).AddTicks(8440));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 280, DateTimeKind.Utc).AddTicks(8441));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 280, DateTimeKind.Utc).AddTicks(8443));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 282, DateTimeKind.Utc).AddTicks(1364));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 282, DateTimeKind.Utc).AddTicks(1371));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 282, DateTimeKind.Utc).AddTicks(1373));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 282, DateTimeKind.Utc).AddTicks(1374));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 282, DateTimeKind.Utc).AddTicks(7518));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 282, DateTimeKind.Utc).AddTicks(7525));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 282, DateTimeKind.Utc).AddTicks(7527));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 282, DateTimeKind.Utc).AddTicks(7529));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 282, DateTimeKind.Utc).AddTicks(7531));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 283, DateTimeKind.Utc).AddTicks(1636));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 283, DateTimeKind.Utc).AddTicks(1644));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 283, DateTimeKind.Utc).AddTicks(1646));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 283, DateTimeKind.Utc).AddTicks(1648));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 283, DateTimeKind.Utc).AddTicks(1680));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 283, DateTimeKind.Utc).AddTicks(4756));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 283, DateTimeKind.Utc).AddTicks(4761));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 283, DateTimeKind.Utc).AddTicks(4762));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 283, DateTimeKind.Utc).AddTicks(4764));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 283, DateTimeKind.Utc).AddTicks(4765));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 283, DateTimeKind.Utc).AddTicks(4768));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 283, DateTimeKind.Utc).AddTicks(4769));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 283, DateTimeKind.Utc).AddTicks(4771));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 283, DateTimeKind.Utc).AddTicks(4772));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 283, DateTimeKind.Utc).AddTicks(4774));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 283, DateTimeKind.Utc).AddTicks(4776));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 7, 7, 49, 52, 283, DateTimeKind.Utc).AddTicks(4777));

            migrationBuilder.InsertData(
                table: "ClinicDoctors",
                columns: new[] { "Id", "ClinicId", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "DoctorId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 9, 7, 7, 49, 52, 278, DateTimeKind.Utc).AddTicks(2056), null, null, null, 1, false, null, null },
                    { 2, 2, new DateTime(2026, 9, 7, 7, 49, 52, 278, DateTimeKind.Utc).AddTicks(2061), null, null, null, 2, false, null, null },
                    { 3, 3, new DateTime(2026, 9, 7, 7, 49, 52, 278, DateTimeKind.Utc).AddTicks(2062), null, null, null, 3, false, null, null },
                    { 4, 4, new DateTime(2026, 9, 7, 7, 49, 52, 278, DateTimeKind.Utc).AddTicks(2063), null, null, null, 4, false, null, null },
                    { 5, 5, new DateTime(2026, 9, 7, 7, 49, 52, 278, DateTimeKind.Utc).AddTicks(2064), null, null, null, 5, false, null, null },
                    { 6, 6, new DateTime(2026, 9, 7, 7, 49, 52, 278, DateTimeKind.Utc).AddTicks(2066), null, null, null, 6, false, null, null },
                    { 7, 8, new DateTime(2026, 9, 7, 7, 49, 52, 278, DateTimeKind.Utc).AddTicks(2067), null, null, null, 1, false, null, null },
                    { 8, 1, new DateTime(2026, 9, 7, 7, 49, 52, 278, DateTimeKind.Utc).AddTicks(2068), null, null, null, 2, false, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClinicDoctors_ClinicId",
                table: "ClinicDoctors",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "UX_ClinicDoctors_Doctor_Clinic",
                table: "ClinicDoctors",
                columns: new[] { "DoctorId", "ClinicId" },
                unique: true,
                filter: "[IsDeleted] = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClinicDoctors");

            migrationBuilder.DropTable(
                name: "Diagnoses");

            migrationBuilder.DropTable(
                name: "Clinics");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 207, DateTimeKind.Utc).AddTicks(3697));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 207, DateTimeKind.Utc).AddTicks(3703));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 207, DateTimeKind.Utc).AddTicks(3704));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 207, DateTimeKind.Utc).AddTicks(3706));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 207, DateTimeKind.Utc).AddTicks(3707));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 207, DateTimeKind.Utc).AddTicks(3710));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 207, DateTimeKind.Utc).AddTicks(3711));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 207, DateTimeKind.Utc).AddTicks(3713));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 207, DateTimeKind.Utc).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 207, DateTimeKind.Utc).AddTicks(8086));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 207, DateTimeKind.Utc).AddTicks(8088));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 207, DateTimeKind.Utc).AddTicks(8089));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 207, DateTimeKind.Utc).AddTicks(8091));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 207, DateTimeKind.Utc).AddTicks(8096));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 207, DateTimeKind.Utc).AddTicks(8098));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 208, DateTimeKind.Utc).AddTicks(9050));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 208, DateTimeKind.Utc).AddTicks(9054));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 208, DateTimeKind.Utc).AddTicks(9055));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 208, DateTimeKind.Utc).AddTicks(9056));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 208, DateTimeKind.Utc).AddTicks(9057));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 208, DateTimeKind.Utc).AddTicks(9059));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 208, DateTimeKind.Utc).AddTicks(9060));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 208, DateTimeKind.Utc).AddTicks(9061));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 208, DateTimeKind.Utc).AddTicks(9062));

            migrationBuilder.UpdateData(
                table: "DoctorSpecialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 208, DateTimeKind.Utc).AddTicks(9064));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 208, DateTimeKind.Utc).AddTicks(2163));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 208, DateTimeKind.Utc).AddTicks(2169));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 208, DateTimeKind.Utc).AddTicks(2170));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 208, DateTimeKind.Utc).AddTicks(2172));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 208, DateTimeKind.Utc).AddTicks(2173));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 208, DateTimeKind.Utc).AddTicks(2176));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 208, DateTimeKind.Utc).AddTicks(2177));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 208, DateTimeKind.Utc).AddTicks(2179));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 209, DateTimeKind.Utc).AddTicks(5345));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 209, DateTimeKind.Utc).AddTicks(5351));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 209, DateTimeKind.Utc).AddTicks(5353));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 209, DateTimeKind.Utc).AddTicks(5355));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 210, DateTimeKind.Utc).AddTicks(1012));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 210, DateTimeKind.Utc).AddTicks(1018));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 210, DateTimeKind.Utc).AddTicks(1047));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 210, DateTimeKind.Utc).AddTicks(1049));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 210, DateTimeKind.Utc).AddTicks(1050));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 210, DateTimeKind.Utc).AddTicks(5064));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 210, DateTimeKind.Utc).AddTicks(5070));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 210, DateTimeKind.Utc).AddTicks(5073));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 210, DateTimeKind.Utc).AddTicks(5075));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 210, DateTimeKind.Utc).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 210, DateTimeKind.Utc).AddTicks(7937));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 210, DateTimeKind.Utc).AddTicks(7941));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 210, DateTimeKind.Utc).AddTicks(7943));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 210, DateTimeKind.Utc).AddTicks(7944));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 210, DateTimeKind.Utc).AddTicks(7945));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 210, DateTimeKind.Utc).AddTicks(7948));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 210, DateTimeKind.Utc).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 210, DateTimeKind.Utc).AddTicks(7951));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 210, DateTimeKind.Utc).AddTicks(7952));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 210, DateTimeKind.Utc).AddTicks(7955));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 210, DateTimeKind.Utc).AddTicks(7956));

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 12, 9, 28, 210, DateTimeKind.Utc).AddTicks(7957));
        }
    }
}
