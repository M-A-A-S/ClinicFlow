using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.Enums
{
    public enum BloodType
    {
        [Display(Name = nameof(SharedResource.Unknown), ResourceType = typeof(SharedResource))]
        Unknown = 0,

        [Display(Name = nameof(SharedResource.APositive), ResourceType = typeof(SharedResource))]
        APositive = 1,

        [Display(Name = nameof(SharedResource.ANegative), ResourceType = typeof(SharedResource))]
        ANegative = 2,

        [Display(Name = nameof(SharedResource.BPositive), ResourceType = typeof(SharedResource))]
        BPositive = 3,

        [Display(Name = nameof(SharedResource.BNegative), ResourceType = typeof(SharedResource))]
        BNegative = 4,

        [Display(Name = nameof(SharedResource.ABPositive), ResourceType = typeof(SharedResource))]
        ABPositive = 5,

        [Display(Name = nameof(SharedResource.ABNegative), ResourceType = typeof(SharedResource))]
        ABNegative = 6,

        [Display(Name = nameof(SharedResource.OPositive), ResourceType = typeof(SharedResource))]
        OPositive = 7,

        [Display(Name = nameof(SharedResource.ONegative), ResourceType = typeof(SharedResource))]
        ONegative = 8
    }

}
