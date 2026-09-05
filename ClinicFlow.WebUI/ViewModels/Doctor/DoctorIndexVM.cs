using ClinicFlow.Domain.DTOs.Doctor;
using ClinicFlow.Domain.Utilities;

namespace ClinicFlow.WebUI.ViewModels.Doctor
{
    public class DoctorIndexVM
    {
        public PagedResult<DoctorDTO> PagedResult { get; set; } = new();
        public DoctorFilterDTO Filter { get; set; } = new();

    }
}
