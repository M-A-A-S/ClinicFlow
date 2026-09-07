using ClinicFlow.Domain.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.Entities
{
    //Appointment patient:
    //Patient → Appointment → Queue → Visit
    public class Appointment : BaseEntity
    {
        public string AppointmentNumber { get; set; }

        public int PatientId { get; set; }     
        public int ClinicId { get; set; }
        public int DoctorId { get; set; }

        public DateTime StartAt { get; set; } 
        public DateTime EndAt { get; set; } 

        public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;
        
        public string? Reason { get; set; }
        public string? Notes { get; set; }

        public Patient Patient { get; set; }
        public Clinic Clinic { get; set; }
        public Doctor Doctor { get; set; }

        public WaitingQueue? WaitingQueue { get; set; }
        public Visit? Visit { get; set; }



    }
}
