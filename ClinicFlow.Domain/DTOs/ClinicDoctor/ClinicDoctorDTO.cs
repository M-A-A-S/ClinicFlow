using ClinicFlow.Domain.DTOs.Clinic;
using ClinicFlow.Domain.DTOs.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.ClinicDoctor
{
    public class ClinicDoctorDTO
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DoctorDTO Doctor { get; set; }
        public int ClinicId { get; set; }
        public ClinicDTO Clinic { get; set; }

    }
}
