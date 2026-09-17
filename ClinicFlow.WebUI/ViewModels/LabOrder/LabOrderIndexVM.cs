using ClinicFlow.Domain.DTOs.LabOrder;
using ClinicFlow.Domain.Utilities;

namespace ClinicFlow.WebUI.ViewModels.LabOrder
{
    public class LabOrderIndexVM
    {
        public PagedResult<LabOrderDTO> PagedResult { get; set; } = new();
        public LabOrderFilterDTO Filter { get; set; } = new();

    }
}
