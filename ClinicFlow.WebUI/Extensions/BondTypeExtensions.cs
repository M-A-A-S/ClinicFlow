using ClinicFlow.Domain.Enums;

namespace ClinicFlow.WebUI.Extensions
{
    public static class BondTypeExtensions
    {
        public static string ToCssClass(this BondType type)
        {
            return type switch
            {
                BondType.Receipt => "bg-success",
                BondType.Payment => "bg-danger",
                _ => "bg-secondary"
            };
        }

    }
}
