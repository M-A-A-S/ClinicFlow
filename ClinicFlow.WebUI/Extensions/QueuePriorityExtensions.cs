using ClinicFlow.Domain.Enums;

namespace ClinicFlow.WebUI.Extensions
{
    public static class QueuePriorityExtensions
    {
        public static string ToCssClass(this QueuePriority priority)
        {
            return priority switch
            {
                QueuePriority.Normal => "bg-secondary",
                QueuePriority.Urgent => "bg-warning text-dark",
                QueuePriority.Emergency => "bg-danger",
                _ => "bg-secondary"
            };
        }

    }
}
