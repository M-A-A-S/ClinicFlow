using ClinicFlow.Domain.Enums;

namespace ClinicFlow.WebUI.Extensions
{
    public static class PaymentMethodTypeExtensions
    {
        public static string ToCssClass(this PaymentMethodType type)
        {
            return type switch
            {
                PaymentMethodType.Cash => "bg-success",
                PaymentMethodType.NetworkCard => "bg-primary",
                PaymentMethodType.BankTransfer => "bg-info",
                _ => "bg-secondary"
            };
        }

    }
}
