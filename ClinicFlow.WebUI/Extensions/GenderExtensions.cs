using ClinicFlow.Domain.Enums;

namespace ClinicFlow.WebUI.Extensions
{
    public static class GenderExtensions
    {
        public static string ToCssClass(this Gender gender)
        {
            return gender switch
            {
                Gender.Male => "bg-primary",
                Gender.Female => "bg-danger",
                Gender.Other => "bg-secondary",
                _ => "bg-secondary"
            };
        }

    }
}
