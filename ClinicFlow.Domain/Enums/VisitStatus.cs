using ClinicFlow.Domain.Resources.Shared;
using System.ComponentModel.DataAnnotations;

namespace ClinicFlow.Domain.Enums
{
    public enum VisitStatus
    {

        [Display(Name = nameof(SharedResource.Open), ResourceType = typeof(SharedResource))]
        Open = 1,

        [Display(Name = nameof(SharedResource.InProgress), ResourceType = typeof(SharedResource))]
        InProgress = 2,

        [Display(Name = nameof(SharedResource.Completed), ResourceType = typeof(SharedResource))]
        Completed = 3,

        [Display(Name = nameof(SharedResource.Cancelled), ResourceType = typeof(SharedResource))]
        Cancelled = 4
    }
}
