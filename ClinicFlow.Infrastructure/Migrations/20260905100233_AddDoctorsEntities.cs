using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClinicFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorsEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ConsultationFee = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
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
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
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
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSpecialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    SpecialtyId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_DoctorSpecialties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorSpecialties_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorSpecialties_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 356, DateTimeKind.Utc).AddTicks(4221));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 356, DateTimeKind.Utc).AddTicks(4226));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 356, DateTimeKind.Utc).AddTicks(4228));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 356, DateTimeKind.Utc).AddTicks(4230));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 356, DateTimeKind.Utc).AddTicks(4232));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 356, DateTimeKind.Utc).AddTicks(4235));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 356, DateTimeKind.Utc).AddTicks(4237));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 356, DateTimeKind.Utc).AddTicks(4238));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 356, DateTimeKind.Utc).AddTicks(9057));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 356, DateTimeKind.Utc).AddTicks(9060));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 356, DateTimeKind.Utc).AddTicks(9061));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 356, DateTimeKind.Utc).AddTicks(9063));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 356, DateTimeKind.Utc).AddTicks(9064));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 356, DateTimeKind.Utc).AddTicks(9067));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 356, DateTimeKind.Utc).AddTicks(9068));

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "ConsultationFee", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "Email", "FullName", "IsActive", "IsDeleted", "PhoneNumber", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, 50.00m, new DateTime(2026, 9, 5, 10, 2, 31, 357, DateTimeKind.Utc).AddTicks(2011), null, null, null, "ahmed.mohamed@clinic.com", "Dr. Ahmed Mohamed", true, false, "0912345678", null, null },
                    { 2, 60.00m, new DateTime(2026, 9, 5, 10, 2, 31, 357, DateTimeKind.Utc).AddTicks(2016), null, null, null, "sara.ali@clinic.com", "Dr. Sara Ali", true, false, "0923456789", null, null },
                    { 3, 45.00m, new DateTime(2026, 9, 5, 10, 2, 31, 357, DateTimeKind.Utc).AddTicks(2018), null, null, null, "mohamed.hassan@clinic.com", "Dr. Mohamed Hassan", true, false, "0934567890", null, null },
                    { 4, 55.00m, new DateTime(2026, 9, 5, 10, 2, 31, 357, DateTimeKind.Utc).AddTicks(2019), null, null, null, "fatima.ahmed@clinic.com", "Dr. Fatima Ahmed", true, false, "0945678901", null, null },
                    { 5, 50.00m, new DateTime(2026, 9, 5, 10, 2, 31, 357, DateTimeKind.Utc).AddTicks(2021), null, null, null, "khalid.osman@clinic.com", "Dr. Khalid Osman", true, false, "0956789012", null, null },
                    { 6, 65.00m, new DateTime(2026, 9, 5, 10, 2, 31, 357, DateTimeKind.Utc).AddTicks(2024), null, null, null, "huda.ibrahim@clinic.com", "Dr. Huda Ibrahim", true, false, "0967890123", null, null },
                    { 7, 50.00m, new DateTime(2026, 9, 5, 10, 2, 31, 357, DateTimeKind.Utc).AddTicks(2025), null, null, null, "yousif.omar@clinic.com", "Dr. Yousif Omar", true, false, "0978901234", null, null },
                    { 8, 70.00m, new DateTime(2026, 9, 5, 10, 2, 31, 357, DateTimeKind.Utc).AddTicks(2027), null, null, null, "maryam.ibrahim@clinic.com", "Dr. Maryam Ibrahim", true, false, "0989012345", null, null }
                });

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 358, DateTimeKind.Utc).AddTicks(4496));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 358, DateTimeKind.Utc).AddTicks(4503));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 358, DateTimeKind.Utc).AddTicks(4505));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 358, DateTimeKind.Utc).AddTicks(4506));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 359, DateTimeKind.Utc).AddTicks(1410));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 359, DateTimeKind.Utc).AddTicks(1418));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 359, DateTimeKind.Utc).AddTicks(1420));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 359, DateTimeKind.Utc).AddTicks(1422));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 359, DateTimeKind.Utc).AddTicks(1423));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 359, DateTimeKind.Utc).AddTicks(5581));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 359, DateTimeKind.Utc).AddTicks(5588));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 359, DateTimeKind.Utc).AddTicks(5590));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 359, DateTimeKind.Utc).AddTicks(5592));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 5, 10, 2, 31, 359, DateTimeKind.Utc).AddTicks(5595));

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "DescriptionAr", "DescriptionEn", "IsActive", "IsDeleted", "NameAr", "NameEn", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 5, 10, 2, 31, 359, DateTimeKind.Utc).AddTicks(8245), null, null, null, "تشخيص وعلاج أمراض القلب والأوعية الدموية", "Diagnosis and treatment of heart and cardiovascular diseases", true, false, "أمراض القلب", "Cardiology", null, null },
                    { 2, new DateTime(2026, 9, 5, 10, 2, 31, 359, DateTimeKind.Utc).AddTicks(8249), null, null, null, "تشخيص وعلاج أمراض الجلد والشعر والأظافر", "Diagnosis and treatment of skin, hair, and nail conditions", true, false, "الأمراض الجلدية", "Dermatology", null, null },
                    { 3, new DateTime(2026, 9, 5, 10, 2, 31, 359, DateTimeKind.Utc).AddTicks(8250), null, null, null, "الرعاية الطبية للرضع والأطفال والمراهقين", "Medical care for infants, children, and adolescents", true, false, "طب الأطفال", "Pediatrics", null, null },
                    { 4, new DateTime(2026, 9, 5, 10, 2, 31, 359, DateTimeKind.Utc).AddTicks(8252), null, null, null, "تشخيص وعلاج الأمراض التي تصيب الأعضاء الداخلية", "Diagnosis and treatment of diseases affecting internal organs", true, false, "الطب الباطني", "Internal Medicine", null, null },
                    { 5, new DateTime(2026, 9, 5, 10, 2, 31, 359, DateTimeKind.Utc).AddTicks(8253), null, null, null, "العلاج الجراحي لمجموعة واسعة من الحالات الطبية", "Surgical treatment of a wide range of medical conditions", true, false, "الجراحة العامة", "General Surgery", null, null },
                    { 6, new DateTime(2026, 9, 5, 10, 2, 31, 359, DateTimeKind.Utc).AddTicks(8256), null, null, null, "تشخيص وعلاج أمراض وإصابات الجهاز العضلي الهيكلي", "Diagnosis and treatment of musculoskeletal conditions", true, false, "جراحة العظام", "Orthopedics", null, null },
                    { 7, new DateTime(2026, 9, 5, 10, 2, 31, 359, DateTimeKind.Utc).AddTicks(8257), null, null, null, "تشخيص وعلاج اضطرابات الجهاز العصبي", "Diagnosis and treatment of disorders of the nervous system", true, false, "طب الأعصاب", "Neurology", null, null },
                    { 8, new DateTime(2026, 9, 5, 10, 2, 31, 359, DateTimeKind.Utc).AddTicks(8259), null, null, null, "تشخيص وعلاج أمراض العيون واضطرابات الرؤية", "Diagnosis and treatment of eye diseases and vision disorders", true, false, "طب العيون", "Ophthalmology", null, null },
                    { 9, new DateTime(2026, 9, 5, 10, 2, 31, 359, DateTimeKind.Utc).AddTicks(8260), null, null, null, "الوقاية وتشخيص وعلاج أمراض الأسنان والفم", "Prevention, diagnosis, and treatment of dental conditions", true, false, "طب الأسنان", "Dentistry", null, null },
                    { 10, new DateTime(2026, 9, 5, 10, 2, 31, 359, DateTimeKind.Utc).AddTicks(8262), null, null, null, "الرعاية الطبية المتعلقة بالحمل والولادة وصحة المرأة الإنجابية", "Medical care related to pregnancy, childbirth, and women's reproductive health", true, false, "النساء والتوليد", "Obstetrics and Gynecology", null, null },
                    { 11, new DateTime(2026, 9, 5, 10, 2, 31, 359, DateTimeKind.Utc).AddTicks(8263), null, null, null, "تشخيص وعلاج أمراض الأنف والأذن والحنجرة", "Diagnosis and treatment of ear, nose, and throat conditions", true, false, "الأنف والأذن والحنجرة", "ENT", null, null },
                    { 12, new DateTime(2026, 9, 5, 10, 2, 31, 359, DateTimeKind.Utc).AddTicks(8265), null, null, null, "تشخيص وعلاج اضطرابات الصحة النفسية", "Diagnosis and treatment of mental health conditions", true, false, "الطب النفسي", "Psychiatry", null, null }
                });

            migrationBuilder.InsertData(
                table: "DoctorSpecialties",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "DoctorId", "IsDeleted", "SpecialtyId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 5, 10, 2, 31, 357, DateTimeKind.Utc).AddTicks(7787), null, null, null, 1, false, 1, null, null },
                    { 2, new DateTime(2026, 9, 5, 10, 2, 31, 357, DateTimeKind.Utc).AddTicks(7790), null, null, null, 1, false, 4, null, null },
                    { 3, new DateTime(2026, 9, 5, 10, 2, 31, 357, DateTimeKind.Utc).AddTicks(7791), null, null, null, 2, false, 3, null, null },
                    { 4, new DateTime(2026, 9, 5, 10, 2, 31, 357, DateTimeKind.Utc).AddTicks(7792), null, null, null, 3, false, 6, null, null },
                    { 5, new DateTime(2026, 9, 5, 10, 2, 31, 357, DateTimeKind.Utc).AddTicks(7793), null, null, null, 3, false, 5, null, null },
                    { 6, new DateTime(2026, 9, 5, 10, 2, 31, 357, DateTimeKind.Utc).AddTicks(7796), null, null, null, 4, false, 10, null, null },
                    { 7, new DateTime(2026, 9, 5, 10, 2, 31, 357, DateTimeKind.Utc).AddTicks(7796), null, null, null, 5, false, 7, null, null },
                    { 8, new DateTime(2026, 9, 5, 10, 2, 31, 357, DateTimeKind.Utc).AddTicks(7797), null, null, null, 6, false, 2, null, null },
                    { 9, new DateTime(2026, 9, 5, 10, 2, 31, 357, DateTimeKind.Utc).AddTicks(7798), null, null, null, 7, false, 11, null, null },
                    { 10, new DateTime(2026, 9, 5, 10, 2, 31, 357, DateTimeKind.Utc).AddTicks(7800), null, null, null, 8, false, 8, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecialties_SpecialtyId",
                table: "DoctorSpecialties",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "UX_DoctorSpecialties_DoctorId_SpecialtyId",
                table: "DoctorSpecialties",
                columns: new[] { "DoctorId", "SpecialtyId" },
                unique: true,
                filter: "[IsDeleted] = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorSpecialties");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(102));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(107));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(108));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(109));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(111));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(116));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(117));

            migrationBuilder.UpdateData(
                table: "Allergies",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(118));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(3697));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(3701));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(3737));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(3738));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(3739));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(3743));

            migrationBuilder.UpdateData(
                table: "ChronicConditions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(3744));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(9206));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(9208));

            migrationBuilder.UpdateData(
                table: "PatientAllergies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 37, DateTimeKind.Utc).AddTicks(9210));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 38, DateTimeKind.Utc).AddTicks(4649));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 38, DateTimeKind.Utc).AddTicks(4655));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 38, DateTimeKind.Utc).AddTicks(4657));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 38, DateTimeKind.Utc).AddTicks(4659));

            migrationBuilder.UpdateData(
                table: "PatientChronicConditions",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 38, DateTimeKind.Utc).AddTicks(4660));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 38, DateTimeKind.Utc).AddTicks(8673));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 38, DateTimeKind.Utc).AddTicks(8679));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 38, DateTimeKind.Utc).AddTicks(8682));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 38, DateTimeKind.Utc).AddTicks(8684));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 8, 31, 14, 29, 59, 38, DateTimeKind.Utc).AddTicks(8686));
        }
    }
}
