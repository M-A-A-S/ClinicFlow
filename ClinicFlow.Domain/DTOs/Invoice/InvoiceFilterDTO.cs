using ClinicFlow.Domain.DTOs.Common;
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
    public class InvoiceFilterDTO : BaseFilterDTO
    {
        [Display(
            Name = nameof(SharedResource.Patient),
            ResourceType = typeof(SharedResource)
        )]
        public int? PatientId {  get; set; }

        [Display(
            Name = nameof(SharedResource.Status),
            ResourceType = typeof(SharedResource)
        )]
        public InvoiceStatus? Status { get; set; }

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
            Name = nameof(SharedResource.MinGrandTotal),
            ResourceType = typeof(SharedResource)
        )]
        public decimal? MinGrandTotal { get; set; }

        [Display(
            Name = nameof(SharedResource.MaxGrandTotal),
            ResourceType = typeof(SharedResource)
        )]
        public decimal? MaxGrandTotal { get; set; }

    }
}
