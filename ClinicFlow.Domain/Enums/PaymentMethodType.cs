using ClinicFlow.Domain.Resources.Shared;
using System.ComponentModel.DataAnnotations;

namespace ClinicFlow.Domain.Enums
{
    public enum PaymentMethodType
    {
        [Display(Name = nameof(SharedResource.Cash), ResourceType = typeof(SharedResource))]
        Cash = 1,

        [Display(Name = nameof(SharedResource.NetworkCard), ResourceType = typeof(SharedResource))]
        NetworkCard = 2,

        [Display(Name = nameof(SharedResource.BankTransfer), ResourceType = typeof(SharedResource))]
        BankTransfer = 3
    }

}
