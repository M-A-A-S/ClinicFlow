using ClinicFlow.Domain.Enums;

namespace ClinicFlow.WebUI.Extensions
{
    public static class QueueStatusExtensions
    {

        public static string ToCssClass(this QueueStatus status)
        {
            return status switch
            {
                QueueStatus.Waiting => "bg-secondary",
                QueueStatus.Called => "bg-primary",
                QueueStatus.InConsultation => "bg-info text-dark",
                QueueStatus.Completed => "bg-success",
                QueueStatus.Skipped => "bg-warning text-dark",
                QueueStatus.Cancelled => "bg-danger",
                QueueStatus.NoShow => "bg-warning text-dark",
                _ => "bg-secondary"
            };
        }

    }
}
