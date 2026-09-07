using ClinicFlow.Domain.DTOs.Appointment;
using ClinicFlow.Domain.Utilities;

namespace ClinicFlow.WebUI.ViewModels.Appointment
{
    public class AppointmentIndexVM
    {
        public PagedResult<AppointmentDTO> PagedResult { get; set; } = new();
        public AppointmentFilterDTO Filter { get; set; } = new();

    }
}
