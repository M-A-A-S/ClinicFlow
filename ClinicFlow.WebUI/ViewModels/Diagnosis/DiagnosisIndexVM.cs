using ClinicFlow.Domain.DTOs.Diagnosis;
using ClinicFlow.Domain.Utilities;

namespace ClinicFlow.WebUI.ViewModels.Diagnosis
{
    public class DiagnosisIndexVM
    {
        public PagedResult<DiagnosisDTO> PagedResult { get; set; } = new();
        public DiagnosisFilterDTO Filter { get; set; } = new();

    }
}
