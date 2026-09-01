using ClinicFlow.Domain.DTOs.ChronicCondition;
using ClinicFlow.Domain.DTOs.Patient;
using ClinicFlow.Domain.Utilities;

namespace ClinicFlow.WebUI.ViewModels.Patient
{
    public class PatientIndexVM
    {
        public PagedResult<PatientDTO> PagedResult { get; set; } = new();
        public PatientFilterDTO Filter { get; set; } = new();
    }
}
