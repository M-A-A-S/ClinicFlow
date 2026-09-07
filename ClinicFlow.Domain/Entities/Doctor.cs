using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.Entities
{
    public class Doctor : BaseEntity
    {
        public string FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public decimal ConsultationFee { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<DoctorSpecialty> DoctorSpecialties { get; set; }
            = new List<DoctorSpecialty>();

        public ICollection<ClinicDoctor> ClinicDoctors { get; set; }
            = new List<ClinicDoctor>();

        public ICollection<Appointment> Appointments { get; set; }
            = new List<Appointment>();

        public ICollection<Visit> Visits { get; set; }
            = new List<Visit>();

        public ICollection<WaitingQueue> WaitingQueues { get; set; }
            = new List<WaitingQueue>();

    }

}
