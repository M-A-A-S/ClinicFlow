using ClinicFlow.Domain.DTOs.Bond;
using ClinicFlow.Domain.Enums;
using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.BondCategory
{
    public class BondCategoryDTO
    {
        public int Id { get; set; }

        [Display(
            Name = nameof(SharedResource.NameEn),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public string NameEn { get; set; }

        [Display(
            Name = nameof(SharedResource.NameAr),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public string NameAr { get; set; }

        [Display(
            Name = nameof(SharedResource.Type),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public BondType Type { get; set; }

        [Display(
            Name = nameof(SharedResource.IsActive),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public bool IsActive { get; set; } = true;
        public ICollection<BondDTO> Bonds { get; set; } = new List<BondDTO>();
    }
}
