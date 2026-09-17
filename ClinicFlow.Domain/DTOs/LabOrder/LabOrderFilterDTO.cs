using ClinicFlow.Domain.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.LabOrder
{
    public class LabOrderFilterDTO : BaseFilterDTO
    {
        public int? VisitId { get; set; }
        public int? PatientId { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

    }
}
