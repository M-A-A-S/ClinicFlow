using ClinicFlow.Domain.DTOs.Invoice;
using ClinicFlow.Domain.DTOs.PaymentMethod;
using ClinicFlow.Domain.Enums;
using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.InvoicePayment
{
    public class InvoicePaymentDTO
    {
        public int Id { get; set; }

        [Display(
            Name = nameof(SharedResource.ReceiptNumber),
            ResourceType = typeof(SharedResource)
        )]
        public string ReceiptNumber { get; set; } = string.Empty;

        [Display(
            Name = nameof(SharedResource.Invoice),
            ResourceType = typeof(SharedResource)
        )]
        public int InvoiceId { get; set; }

        [Display(
            Name = nameof(SharedResource.Type),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public BondType Type { get; set; } = BondType.Receipt;

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
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public int PaymentMethodId { get; set; }

        [Display(
            Name = nameof(SharedResource.PaymentDate),
            ResourceType = typeof(SharedResource)
        )]
        public DateTime PaymentDate { get; set; } = DateTime.Now;

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

        public virtual PaymentMethodDTO? PaymentMethod { get; set; } = null!;
        public virtual InvoiceDTO? Invoice { get; set; } = null!;
    }
}
