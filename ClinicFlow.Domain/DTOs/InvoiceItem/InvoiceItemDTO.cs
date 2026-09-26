using ClinicFlow.Domain.DTOs.Invoice;
using ClinicFlow.Domain.Enums;
using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.InvoiceItem
{
    public class InvoiceItemDTO
    {
        public int Id { get; set; }

        [Display(
            Name = nameof(SharedResource.Invoice),
            ResourceType = typeof(SharedResource)
        )]
        public int InvoiceId { get; set; }

        [Display(
            Name = nameof(SharedResource.ItemType),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public InvoiceItemType ItemType { get; set; }

        [Display(
            Name = nameof(SharedResource.ReferenceId),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public int ReferenceId { get; set; }

        [Display(
            Name = nameof(SharedResource.Quantity),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public decimal Quantity { get; set; }

        [Display(
            Name = nameof(SharedResource.UnitPrice),
            ResourceType = typeof(SharedResource)
        )]
        public decimal UnitPrice { get; set; }

        [Display(
            Name = nameof(SharedResource.Total),
            ResourceType = typeof(SharedResource)
        )]
        public decimal Total { get; set; }

        [Display(
            Name = nameof(SharedResource.Description),
            ResourceType = typeof(SharedResource)
        )]
        public string? Description { get; set; }

        public InvoiceDTO? Invoice { get; set; }

        // for just UI
        public string? ReferenceName { get; set; }
    }
}
