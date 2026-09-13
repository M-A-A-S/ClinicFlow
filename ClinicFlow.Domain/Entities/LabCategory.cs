using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.Entities
{

    public class LabCategory : BaseEntity
    {
        public required string NameEn { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; } = true; 

        public ICollection<LabTest> Tests { get; set; }
            = new List<LabTest>();
    }

}
