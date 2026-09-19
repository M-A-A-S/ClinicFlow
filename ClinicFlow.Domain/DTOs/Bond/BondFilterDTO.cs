using ClinicFlow.Domain.DTOs.Common;
using ClinicFlow.Domain.Enums;
using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.Bond
{
    public class BondFilterDTO : BaseFilterDTO
    {
        [Display(
            Name = nameof(SharedResource.Type),
            ResourceType = typeof(SharedResource)
        )]
        public BondType? Type { get; set; }

        [Display(
            Name = nameof(SharedResource.PartyType),
            ResourceType = typeof(SharedResource)
        )]
        public PartyType? Party { get; set; }

        [Display(
            Name = nameof(SharedResource.Party),
            ResourceType = typeof(SharedResource)
        )]
        public int? PartyId { get; set; }

        [Display(
            Name = nameof(SharedResource.Category),
            ResourceType = typeof(SharedResource)
        )]
        public int? CategoryId { get; set; }

        [Display(
            Name = nameof(SharedResource.PaymentMethod),
            ResourceType = typeof(SharedResource)
        )]
        public int? PaymentMethodId { get; set; }

        [Display(
            Name = nameof(SharedResource.FromDate),
            ResourceType = typeof(SharedResource)
        )]
        public DateTime? FromDate { get; set; }

        [Display(
            Name = nameof(SharedResource.ToDate),
            ResourceType = typeof(SharedResource)
        )]
        public DateTime? ToDate { get; set; }

        [Display(
            Name = nameof(SharedResource.MinAmount),
            ResourceType = typeof(SharedResource)
        )]
        public decimal? MinAmount { get; set; }

        [Display(
            Name = nameof(SharedResource.MaxAmount),
            ResourceType = typeof(SharedResource)
        )]
        public decimal? MaxAmount { get; set; }
    }
}
