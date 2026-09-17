using ClinicFlow.Domain.Resources.Shared;
using System.ComponentModel.DataAnnotations;

namespace ClinicFlow.Domain.Enums
{
    public enum LabResultFlag
    {
        [Display(Name = nameof(SharedResource.None), ResourceType = typeof(SharedResource))]
        None = 0,

        [Display(Name = nameof(SharedResource.Normal), ResourceType = typeof(SharedResource))]
        Normal = 1,

        [Display(Name = nameof(SharedResource.Abnormal), ResourceType = typeof(SharedResource))]
        Abnormal = 2,

        [Display(Name = nameof(SharedResource.Critical), ResourceType = typeof(SharedResource))]
        Critical = 3
    }

}
