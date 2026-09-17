using ClinicFlow.Domain.Enums;

namespace ClinicFlow.WebUI.Extensions
{
    public static class LabStatusExtensions
    {
        public static string ToCssClass(this LabStatus status)
        {
            return status switch
            {
                LabStatus.Pending => "bg-secondary",
                LabStatus.SampleCollected => "bg-info text-dark",
                LabStatus.InProgress => "bg-warning text-dark",
                LabStatus.Completed => "bg-success",
                LabStatus.Cancelled => "bg-danger",
                _ => "bg-secondary"
            };
        }
    }
}
