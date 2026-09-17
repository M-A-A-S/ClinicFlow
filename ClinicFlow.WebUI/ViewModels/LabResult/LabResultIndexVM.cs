using ClinicFlow.Domain.DTOs.LabResult;
using ClinicFlow.Domain.Utilities;

namespace ClinicFlow.WebUI.ViewModels.LabResult
{
    public class LabResultIndexVM
    {
        public PagedResult<LabResultDTO> PagedResult { get; set; } = new();
        public LabResultFilterDTO Filter { get; set; } = new();

    }
}
