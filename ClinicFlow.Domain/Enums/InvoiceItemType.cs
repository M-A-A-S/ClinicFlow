using ClinicFlow.Domain.Resources.Shared;
using System.ComponentModel.DataAnnotations;

namespace ClinicFlow.Domain.Enums
{
    public enum InvoiceItemType
    {
        [Display(Name = nameof(SharedResource.Visit), ResourceType = typeof(SharedResource))]
        Visit = 1,

        [Display(Name = nameof(SharedResource.Lab), ResourceType = typeof(SharedResource))]
        Lab = 2,

        [Display(Name = nameof(SharedResource.Medicine), ResourceType = typeof(SharedResource))]
        Medicine = 3,

        [Display(Name = nameof(SharedResource.Service), ResourceType = typeof(SharedResource))]
        Service = 4,
    }

}
