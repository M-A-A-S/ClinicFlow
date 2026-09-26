using ClinicFlow.Domain.Enums;

namespace ClinicFlow.WebUI.Extensions
{
    public static class BloodTypeExtensions
    {
        public static string ToCssClass(this BloodType type)
        {
            return type switch
            {
                BloodType.Unknown => "bg-secondary",
                BloodType.APositive => "bg-danger",
                BloodType.ANegative => "bg-danger",
                BloodType.BPositive => "bg-danger",
                BloodType.BNegative => "bg-danger",
                BloodType.ABPositive => "bg-danger",
                BloodType.ABNegative => "bg-danger",
                BloodType.OPositive => "bg-danger",
                BloodType.ONegative => "bg-danger",
                _ => "bg-secondary"
            };
        }

    }
}
