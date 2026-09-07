using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.Entities
{
    public class Clinic : BaseEntity
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<ClinicDoctor> ClinicDoctors { get; set; }
            = new List<ClinicDoctor>();

        public ICollection<Appointment> Appointments { get; set; }
            = new List<Appointment>();

        public ICollection<WaitingQueue> WaitingQueues { get; set; }
            = new List<WaitingQueue>();

        public ICollection<Visit> Visits { get; set; }
            = new List<Visit>();
    }
}
