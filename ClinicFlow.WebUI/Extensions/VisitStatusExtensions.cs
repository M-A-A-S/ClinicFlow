using ClinicFlow.Domain.Enums;

namespace ClinicFlow.WebUI.Extensions
{
    public static class VisitStatusExtensions
    {
        public static string ToCssClass(this VisitStatus status)
        {
            return status switch
            {
                VisitStatus.Open => "bg-secondary",
                VisitStatus.InProgress => "bg-primary",
                VisitStatus.Completed => "bg-success",
                VisitStatus.Cancelled => "bg-danger",

                _ => "bg-secondary"
            };
        }

    }
}
