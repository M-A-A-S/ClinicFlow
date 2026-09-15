using ClinicFlow.Domain.DTOs.LabTest;
using ClinicFlow.Domain.Utilities;

namespace ClinicFlow.WebUI.ViewModels.LabTest
{
    public class LabTestIndexVM
    {
        public PagedResult<LabTestDTO> PagedResult { get; set; } = new();
        public LabTestFilterDTO Filter { get; set; } = new();

    }
}
