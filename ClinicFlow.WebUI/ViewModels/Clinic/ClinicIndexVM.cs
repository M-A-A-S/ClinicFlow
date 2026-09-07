using ClinicFlow.Domain.DTOs.Clinic;
using ClinicFlow.Domain.Utilities;

namespace ClinicFlow.WebUI.ViewModels.Clinic
{
    public class ClinicIndexVM
    {
        public PagedResult<ClinicDTO> PagedResult { get; set; } = new();
        public ClinicFilterDTO Filter { get; set; } = new();

    }
}
