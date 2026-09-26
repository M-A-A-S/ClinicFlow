using ClinicFlow.Domain.Enums;

namespace ClinicFlow.WebUI.Extensions
{
    public static class InvoiceItemTypeExtensions
    {
        public static string ToCssClass(this InvoiceItemType type)
        {
            return type switch
            {
                InvoiceItemType.Visit => "bg-primary",
                InvoiceItemType.Lab => "bg-info",
                InvoiceItemType.Medicine => "bg-success",
                InvoiceItemType.Service => "bg-warning text-dark",
                _ => "bg-secondary"
            };
        }

    }
}
