using ClinicFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.Entities
{
    public class Patient : BaseEntity
    {
        public string FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public Gender Gender { get; set; }
        public string? NationalId { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public BloodType? BloodType { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<PatientAllergy> PatientAllergies { get; set; }
            = new List<PatientAllergy>();

        public ICollection<PatientChronicCondition> PatientChronicConditions { get; set; }
            = new List<PatientChronicCondition>();

        //public ICollection<Appointment> Appointments { get; set; }
        //    = new List<Appointment>();

        //public ICollection<Visit> Visits { get; set; }
        //    = new List<Visit>();

        //public ICollection<Invoice> Invoices { get; set; }
        //    = new List<Invoice>();

    }

}
