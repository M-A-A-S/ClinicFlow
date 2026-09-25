using ClinicFlow.Domain.Resources.Shared;
using System.ComponentModel.DataAnnotations;

namespace ClinicFlow.Domain.Enums
{
    public enum InvoiceStatus
    {
        [Display(Name = nameof(SharedResource.Unpaid), ResourceType = typeof(SharedResource))]
        Unpaid = 1,

        [Display(Name = nameof(SharedResource.PartiallyPaid), ResourceType = typeof(SharedResource))]
        PartiallyPaid = 2,

        [Display(Name = nameof(SharedResource.Paid), ResourceType = typeof(SharedResource))]
        Paid = 3
    }

}
