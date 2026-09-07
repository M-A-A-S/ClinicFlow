using ClinicFlow.Domain.Enums;

namespace ClinicFlow.WebUI.Extensions
{
    public static class AppointmentStatusExtensions
    {
        public static string ToCssClass(this AppointmentStatus status)
        {
            return status switch
            {
                AppointmentStatus.Scheduled => "bg-secondary",
                AppointmentStatus.Confirmed => "bg-primary",
                AppointmentStatus.CheckedIn => "bg-info text-dark",
                AppointmentStatus.Completed => "bg-success",
                AppointmentStatus.Cancelled => "bg-danger",
                AppointmentStatus.NoShow => "bg-warning text-dark",
                _ => "bg-secondary"
            };
        }

    }
}
