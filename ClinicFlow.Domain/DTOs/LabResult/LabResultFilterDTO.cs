using ClinicFlow.Domain.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.LabResult
{
    public class LabResultFilterDTO : BaseFilterDTO
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public int? PatientId { get; set; }

    }
}
