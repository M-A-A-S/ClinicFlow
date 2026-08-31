using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.Entities
{
    public class Allergy : BaseEntity
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<PatientAllergy> PatientAllergies { get; set; }
            = new List<PatientAllergy>();

    }

}
