using ClinicFlow.Domain.DTOs.Allergy;
using ClinicFlow.Domain.DTOs.ChronicCondition;
using ClinicFlow.Domain.Utilities;

namespace ClinicFlow.WebUI.ViewModels.ChronicCondition
{
    public class ChronicConditionIndexVM
    {
        public PagedResult<ChronicConditionDTO> PagedResult { get; set; } = new();
        public ChronicConditionFilterDTO Filter { get; set; } = new();

    }
}
