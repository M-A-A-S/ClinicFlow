using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.LabTest
{
    public class LabTestSearchDTO
    {
        public int Id { get; set; }

        [Display(
            Name = nameof(SharedResource.NameEn),
            ResourceType = typeof(SharedResource)
        )]
        public required string NameEn { get; set; }

        [Display(
            Name = nameof(SharedResource.NameAr),
            ResourceType = typeof(SharedResource)
        )]
        public string? NameAr { get; set; }

        [Display(
            Name = nameof(SharedResource.Price),
            ResourceType = typeof(SharedResource)
        )]
        public decimal Price { get; set; }

    }
}
