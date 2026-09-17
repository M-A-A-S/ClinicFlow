using ClinicFlow.Domain.Resources.Shared;
using System.ComponentModel.DataAnnotations;

namespace ClinicFlow.Domain.Enums
{
    public enum LabStatus
    {
        [Display(Name = nameof(SharedResource.Pending), ResourceType = typeof(SharedResource))]
        Pending = 1,

        [Display(Name = nameof(SharedResource.SampleCollected), ResourceType = typeof(SharedResource))]
        SampleCollected = 2,

        [Display(Name = nameof(SharedResource.InProgress), ResourceType = typeof(SharedResource))]
        InProgress = 3,

        [Display(Name = nameof(SharedResource.Completed), ResourceType = typeof(SharedResource))]
        Completed = 4,

        [Display(Name = nameof(SharedResource.Cancelled), ResourceType = typeof(SharedResource))]
        Cancelled = 5
    }

}
