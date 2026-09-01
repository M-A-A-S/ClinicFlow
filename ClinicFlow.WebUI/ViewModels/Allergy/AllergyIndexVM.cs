using ClinicFlow.Domain.DTOs.Allergy;
using ClinicFlow.Domain.Utilities;

namespace ClinicFlow.WebUI.ViewModels.Allergy
{
    public class AllergyIndexVM
    {
        public PagedResult<AllergyDTO> PagedResult { get; set; } = new();
        public AllergyFilterDTO Filter { get; set; } = new();
    }
}
