using ClinicFlow.Domain.DTOs.Common;
using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.LabTest
{
    public class LabTestFilterDTO : BaseFilterDTO
    {
        [Display(
            Name = nameof(SharedResource.Category),
            ResourceType = typeof(SharedResource)
        )]
        public int? CategoryId { get; set; }

        [Display(
            Name = nameof(SharedResource.IsActive),
            ResourceType = typeof(SharedResource)
        )]
        public bool? IsActive { get; set; }

        [Display(
            Name = nameof(SharedResource.MinPrice),
            ResourceType = typeof(SharedResource)
        )]
        public decimal? MinPrice { get; set; }

        [Display(
            Name = nameof(SharedResource.MaxPrice),
            ResourceType = typeof(SharedResource)
        )]
        public decimal? MaxPrice { get; set; }

    }
}
