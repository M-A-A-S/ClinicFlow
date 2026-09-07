using ClinicFlow.Domain.Resources.Shared;
using System.ComponentModel.DataAnnotations;

namespace ClinicFlow.Domain.Enums
{
    public enum QueueStatus
    {
        [Display(Name = nameof(SharedResource.Waiting), ResourceType = typeof(SharedResource))]
        Waiting = 1,

        [Display(Name = nameof(SharedResource.Called), ResourceType = typeof(SharedResource))]
        Called = 2,

        [Display(Name = nameof(SharedResource.InConsultation), ResourceType = typeof(SharedResource))]
        InConsultation = 3,

        [Display(Name = nameof(SharedResource.Completed), ResourceType = typeof(SharedResource))]
        Completed = 4,

        [Display(Name = nameof(SharedResource.Skipped), ResourceType = typeof(SharedResource))]
        Skipped = 5,

        [Display(Name = nameof(SharedResource.Cancelled), ResourceType = typeof(SharedResource))]
        Cancelled = 6,

        [Display(Name = nameof(SharedResource.NoShow), ResourceType = typeof(SharedResource))]
        NoShow = 7
    }
}
