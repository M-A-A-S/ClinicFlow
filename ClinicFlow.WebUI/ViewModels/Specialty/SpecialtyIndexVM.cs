using ClinicFlow.Domain.DTOs.Specialty;
using ClinicFlow.Domain.Utilities;

namespace ClinicFlow.WebUI.ViewModels.Specialty
{
    public class SpecialtyIndexVM
    {
        public PagedResult<SpecialtyDTO> PagedResult { get; set; } = new();
        public SpecialtyFilterDTO Filter { get; set; } = new();

    }
}
