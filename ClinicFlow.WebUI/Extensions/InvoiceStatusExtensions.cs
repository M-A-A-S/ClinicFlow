using ClinicFlow.Domain.Enums;

namespace ClinicFlow.WebUI.Extensions
{
    public static class InvoiceStatusExtensions
    {
        public static string ToCssClass(this InvoiceStatus status)
        {
            return status switch
            {
                InvoiceStatus.Unpaid => "bg-danger",
                InvoiceStatus.PartiallyPaid => "bg-warning text-dark",
                InvoiceStatus.Paid => "bg-success",
                _ => "bg-secondary"
            };
        }

    }
}
