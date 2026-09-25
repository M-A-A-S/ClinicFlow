using ClinicFlow.Domain.Resources.Shared;
using System.ComponentModel.DataAnnotations;

namespace ClinicFlow.Domain.Enums
{
    public enum BondType
    {
        [Display(Name = nameof(SharedResource.Receipt), ResourceType = typeof(SharedResource))]
        Receipt = 1, // Money In (e.g., patient deposit, misc income)

        [Display(Name = nameof(SharedResource.Payment), ResourceType = typeof(SharedResource))]
        Payment = 2 // Money Out (e.g., office rent, utilities, refunds)
    }

}
