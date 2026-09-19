using ClinicFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.Entities
{

    public class Invoice : BaseEntity
    {    
        public string InvoiceNumber { get; set; }
        public int? PatientId { get; set; }
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public InvoiceStatus Status { get; set; } = InvoiceStatus.Unpaid;
        public decimal Subtotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal GrandTotal { get; set; }

        // Persisted financial state prevents N+1 lazy-loading performance issue
        public decimal PaidAmount { get; private set; }
        public decimal RemainingAmount { get; private set; }

        public Patient? Patient { get; set; }

        public ICollection<InvoiceItem> Items { get; set; }
            = new List<InvoiceItem>();
        public ICollection<InvoicePayment> Payments { get; set; }
            = new List<InvoicePayment>();


        public void RecalculateTotals()
        {
            Subtotal = Items.Sum(x => x.Total);
            GrandTotal = Math.Max(0, (Subtotal - DiscountAmount) + TaxAmount);

            var receipts = Payments
                    .Where(x => x.Type == BondType.Receipt)
                    .Sum(x => x.Amount);

            var payments = Payments
                    .Where(x => x.Type == BondType.Payment)
                    .Sum(x => x.Amount);

            PaidAmount = Math.Max(0, receipts - payments);
            RemainingAmount = Math.Max(0, GrandTotal - PaidAmount);

            if (PaidAmount <= 0)
            {
                Status = InvoiceStatus.Unpaid;
            }
            else if (PaidAmount < GrandTotal)
            {
                Status = InvoiceStatus.PartiallyPaid;
            }
            else
            {
                Status = InvoiceStatus.Paid;
            }  

        }

    }

}
