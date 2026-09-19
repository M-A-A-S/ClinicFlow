using ClinicFlow.Domain.DTOs.InvoiceItem;
using ClinicFlow.Domain.DTOs.InvoicePayment;
using ClinicFlow.Domain.DTOs.Patient;
using ClinicFlow.Domain.Enums;
using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.Invoice
{
    public class InvoiceDTO
    {
        public int Id { get; set; }

        [Display(
            Name = nameof(SharedResource.InvoiceNumber),
            ResourceType = typeof(SharedResource)
        )]
        public string InvoiceNumber { get; set; } = string.Empty;

        [Display(
            Name = nameof(SharedResource.Patient),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public int? PatientId { get; set; }

        [Display(
            Name = nameof(SharedResource.InvoiceDate),
            ResourceType = typeof(SharedResource)
        )]
        public DateTime InvoiceDate { get; set; } = DateTime.Now;

        [Display(
            Name = nameof(SharedResource.Status),
            ResourceType = typeof(SharedResource)
        )]
        public InvoiceStatus Status { get; set; } = InvoiceStatus.Unpaid;

        [Display(
            Name = nameof(SharedResource.Subtotal),
            ResourceType = typeof(SharedResource)
        )]
        public decimal Subtotal { get; set; }

        [Display(
            Name = nameof(SharedResource.DiscountAmount),
            ResourceType = typeof(SharedResource)
        )]
        public decimal DiscountAmount { get; set; }

        [Display(
            Name = nameof(SharedResource.TaxAmount),
            ResourceType = typeof(SharedResource)
        )]
        public decimal TaxAmount { get; set; }

        [Display(
            Name = nameof(SharedResource.GrandTotal),
            ResourceType = typeof(SharedResource)
        )]
        public decimal GrandTotal { get; set; }
        
        [Display(
            Name = nameof(SharedResource.PaidAmount),
            ResourceType = typeof(SharedResource)
        )]
        public decimal PaidAmount { get; private set; }

        [Display(
            Name = nameof(SharedResource.RemainingAmount),
            ResourceType = typeof(SharedResource)
        )]
        public decimal RemainingAmount { get; private set; }

        public PatientDTO? Patient { get; set; }

        public ICollection<InvoiceItemDTO> Items { get; set; }
            = new List<InvoiceItemDTO>();
        public ICollection<InvoicePaymentDTO> Payments { get; set; }
            = new List<InvoicePaymentDTO>();
    }
}
