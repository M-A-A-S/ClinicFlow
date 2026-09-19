using ClinicFlow.Domain.DTOs.BondCategory;
using ClinicFlow.Domain.DTOs.PaymentMethod;
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
    public class BondDTO
    {
        public int Id { get; set; }

        [Display(
            Name = nameof(SharedResource.BondNumber),
            ResourceType = typeof(SharedResource)
        )]
        public string BondNumber { get; set; } = string.Empty;

        [Display(
            Name = nameof(SharedResource.IssueDate),
            ResourceType = typeof(SharedResource)
        )]
        public DateTime IssueDate { get; set; } = DateTime.Now;

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
            Name = nameof(SharedResource.PartyType),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public PartyType Party { get; set; } = PartyType.General;

        [Display(
            Name = nameof(SharedResource.Party),
            ResourceType = typeof(SharedResource)
        )]
        public int? PartyId { get; set; } // PatientId or SupplierId if Party != General

        [Display(
            Name = nameof(SharedResource.Category),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public int CategoryId { get; set; }

        [Display(
            Name = nameof(SharedResource.Amount),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public decimal Amount { get; set; }

        [Display(
            Name = nameof(SharedResource.PaymentMethod),
            ResourceType = typeof(SharedResource)
        )]
        public int PaymentMethodId { get; set; }

        [Display(
            Name = nameof(SharedResource.Notes),
            ResourceType = typeof(SharedResource)
        )]
        public string? Notes { get; set; }

        [Display(
            Name = nameof(SharedResource.ReferenceNumber),
            ResourceType = typeof(SharedResource)
        )]
        public string? ReferenceNumber { get; set; } 

        public virtual BondCategoryDTO? Category { get; set; } = null!;
        public virtual PaymentMethodDTO? PaymentMethod { get; set; } = null!;

    }
}
