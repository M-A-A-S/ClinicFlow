using ClinicFlow.Domain.Resources.Shared;
using System.ComponentModel.DataAnnotations;

namespace ClinicFlow.Domain.Enums
{
    public enum AppointmentStatus
    {
        [Display(Name = nameof(SharedResource.Scheduled), ResourceType = typeof(SharedResource))]
        Scheduled = 1,

        [Display(Name = nameof(SharedResource.Confirmed), ResourceType = typeof(SharedResource))]
        Confirmed = 2,

        [Display(Name = nameof(SharedResource.CheckedIn), ResourceType = typeof(SharedResource))]
        CheckedIn = 3,

        [Display(Name = nameof(SharedResource.Completed), ResourceType = typeof(SharedResource))]
        Completed = 4,

        [Display(Name = nameof(SharedResource.Cancelled), ResourceType = typeof(SharedResource))]
        Cancelled = 5,

        [Display(Name = nameof(SharedResource.NoShow), ResourceType = typeof(SharedResource))]
        NoShow = 6
    }
}
