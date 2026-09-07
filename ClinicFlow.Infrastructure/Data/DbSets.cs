using ClinicFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Infrastructure.Data
{
    public partial class AppDbContext
    {
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<PatientAllergy> PatientAllergies { get; set; }
        public DbSet<ChronicCondition> ChronicConditions { get; set; }
        public DbSet<PatientChronicCondition> PatientChronicConditions { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorSpecialty> DoctorSpecialties { get; set; }

        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<ClinicDoctor> ClinicDoctors { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<WaitingQueue> WaitingQueues { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<VitalSign> VitalSigns { get; set; }
        public DbSet<VisitDiagnosis> VisitDiagnoses { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionItem> PrescriptionItems { get; set; }
        public DbSet<Medicine> Medicines { get; set; }

    }
}
