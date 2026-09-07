using ClinicFlow.Domain.Resources.Shared;
using System.ComponentModel.DataAnnotations;

namespace ClinicFlow.Domain.Enums
{
    public enum QueuePriority
    {

        [Display(Name = nameof(SharedResource.Normal), ResourceType = typeof(SharedResource))]
        Normal = 1,

        [Display(Name = nameof(SharedResource.Urgent), ResourceType = typeof(SharedResource))]
        Urgent = 2,

        [Display(Name = nameof(SharedResource.Emergency), ResourceType = typeof(SharedResource))]
        Emergency = 3
    }
}
