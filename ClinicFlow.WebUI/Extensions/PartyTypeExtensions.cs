using ClinicFlow.Domain.Enums;

namespace ClinicFlow.WebUI.Extensions
{
    public static class PartyTypeExtensions
    {
        public static string ToCssClass(this PartyType type)
        {
            return type switch
            {
                PartyType.General => "bg-secondary",
                PartyType.Patient => "bg-primary",
                PartyType.Supplier => "bg-warning text-dark",
                PartyType.Doctor => "bg-info",
                _ => "bg-secondary"
            };
        }

    }
}
