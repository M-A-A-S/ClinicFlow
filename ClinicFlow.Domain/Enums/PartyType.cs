using ClinicFlow.Domain.Resources.Shared;
using System.ComponentModel.DataAnnotations;

namespace ClinicFlow.Domain.Enums
{
    public enum PartyType
    {
        [Display(Name = nameof(SharedResource.General), ResourceType = typeof(SharedResource))]
        General = 1,

        [Display(Name = nameof(SharedResource.Patient), ResourceType = typeof(SharedResource))]
        Patient = 2,

        [Display(Name = nameof(SharedResource.Supplier), ResourceType = typeof(SharedResource))]
        Supplier = 3,

        [Display(Name = nameof(SharedResource.Doctor), ResourceType = typeof(SharedResource))]
        Doctor = 4
    }

}
