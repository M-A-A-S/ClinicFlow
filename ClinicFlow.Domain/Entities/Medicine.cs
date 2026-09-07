using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.Entities
{
    public class Medicine : BaseEntity
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }

        public string GenericNameEn { get; set; }
        public string GenericNameAr { get; set; }

        public string? Strength { get; set; }
        public string? DosageForm { get; set; } // e.g., Tablet, Capsule, Syrup
        public string? Route { get; set; } // e.g., Oral, IV, Topical

        public bool IsActive { get; set; } = true;

        public ICollection<PrescriptionItem> PrescriptionItems { get; set; }
            = new List<PrescriptionItem>();
    }
}
