using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.Enums
{
    public enum Gender
    {
        [Display(Name = nameof(SharedResource.Male), ResourceType = typeof(SharedResource))]
        Male = 1,

        [Display(Name = nameof(SharedResource.Female), ResourceType = typeof(SharedResource))]
        Female = 2,

        [Display(Name = nameof(SharedResource.Other), ResourceType = typeof(SharedResource))]
        Other = 3
    }

}
