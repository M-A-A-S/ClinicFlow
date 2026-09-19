using ClinicFlow.Domain.DTOs.Invoice;
using ClinicFlow.Domain.DTOs.InvoiceItem;
using ClinicFlow.Domain.DTOs.InvoicePayment;
using ClinicFlow.Domain.DTOs.LabResult;
using ClinicFlow.Domain.DTOs.LabTest;
using ClinicFlow.Domain.DTOs.Patient;
using ClinicFlow.Domain.DTOs.PaymentMethod;
using ClinicFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.Extensions
{
    public static class InvoiceExtensions
    {
        public static Expression<Func<Invoice, InvoiceDTO>>
            ToDTOExpression => Entity => new InvoiceDTO
            {
                Id = Entity.Id,
                InvoiceNumber = Entity.InvoiceNumber,
                PatientId = Entity.PatientId,
                InvoiceDate = Entity.InvoiceDate,
                Status = Entity.Status,
                Subtotal = Entity.Subtotal,
                DiscountAmount = Entity.DiscountAmount,
                TaxAmount = Entity.TaxAmount,
                GrandTotal = Entity.GrandTotal,
                PaidAmount = Entity.PaidAmount,
                RemainingAmount = Entity.RemainingAmount,

                Patient = Entity.Patient == null ? null : new PatientDTO()
                {
                    Id = Entity.Patient.Id,
                    FullName = Entity.Patient.FullName,
                    PhoneNumber = Entity.Patient.PhoneNumber
                },

                Items = Entity.Items
                    .Select(x => new InvoiceItemDTO
                    {
                        InvoiceId = x.InvoiceId,
                        ItemType = x.ItemType,
                        ReferenceId = x.ReferenceId,
                        Quantity = x.Quantity,
                        UnitPrice = x.UnitPrice,
                        Total = x.Total,
                        Description = x.Description,
                    })
                .ToList(),

                Payments = Entity.Payments
                    .Select(x => new InvoicePaymentDTO
                    {
                        InvoiceId = x.InvoiceId,
                        ReceiptNumber = x.ReceiptNumber,
                        Type = x.Type,
                        Amount = x.Amount,
                        PaymentMethodId = x.PaymentMethodId,
                        PaymentDate = x.PaymentDate,
                        ReferenceNumber = x.ReferenceNumber,

                        PaymentMethod = x.PaymentMethod == null ? null : new PaymentMethodDTO
                        {
                            Id = x.PaymentMethod.Id,
                            NameEn = x.PaymentMethod.NameEn,
                            NameAr = x.PaymentMethod.NameAr,
                            Type = x.PaymentMethod.Type,
                        }
                    })
                .ToList()

            };


        public static InvoiceDTO ToDTO(this Invoice Entity)
        {
            if (Entity == null)
            {
                return null;
            }

            return new InvoiceDTO
            {
                Id = Entity.Id,
                InvoiceNumber = Entity.InvoiceNumber,
                PatientId = Entity.PatientId,
                InvoiceDate = Entity.InvoiceDate,
                Status = Entity.Status,
                Subtotal = Entity.Subtotal,
                DiscountAmount = Entity.DiscountAmount,
                TaxAmount = Entity.TaxAmount,
                GrandTotal = Entity.GrandTotal,
                PaidAmount = Entity.PaidAmount,
                RemainingAmount = Entity.RemainingAmount,

                Patient = Entity.Patient == null ? null : new PatientDTO()
                {
                    Id = Entity.Patient.Id,
                    FullName = Entity.Patient.FullName,
                    PhoneNumber = Entity.Patient.PhoneNumber
                },

                Items = Entity.Items
                    .Select(x => new InvoiceItemDTO
                    {
                        InvoiceId = x.InvoiceId,
                        ItemType = x.ItemType,
                        ReferenceId = x.ReferenceId,
                        Quantity = x.Quantity,
                        UnitPrice = x.UnitPrice,
                        Total = x.Total,
                        Description = x.Description,
                    })
                .ToList(),

                Payments = Entity.Payments
                    .Select(x => new InvoicePaymentDTO
                    {
                        InvoiceId = x.InvoiceId,
                        ReceiptNumber = x.ReceiptNumber,
                        Type = x.Type,
                        Amount = x.Amount,
                        PaymentMethodId = x.PaymentMethodId,
                        PaymentDate = x.PaymentDate,
                        ReferenceNumber = x.ReferenceNumber,

                        PaymentMethod = x.PaymentMethod == null ? null : new PaymentMethodDTO
                        {
                            Id = x.PaymentMethod.Id,
                            NameEn = x.PaymentMethod.NameEn,
                            NameAr = x.PaymentMethod.NameAr,
                            Type = x.PaymentMethod.Type,
                        }
                    })
                .ToList()
            };
        }

        public static Invoice ToEntity(this InvoiceDTO DTO)
        {
            if (DTO == null)
            {
                return null;
            }

            return new Invoice
            {
                Id = DTO.Id,
                InvoiceNumber = DTO.InvoiceNumber,
                PatientId = DTO.PatientId,
                InvoiceDate = DTO.InvoiceDate,
                Status = DTO.Status,
                Subtotal = DTO.Subtotal,
                DiscountAmount = DTO.DiscountAmount,
                TaxAmount = DTO.TaxAmount,
                GrandTotal = DTO.GrandTotal,

                Items = DTO.Items
                    .Select(x => new InvoiceItem
                    {
                        InvoiceId = x.InvoiceId,
                        ItemType = x.ItemType,
                        ReferenceId = x.ReferenceId,
                        Quantity = x.Quantity,
                        UnitPrice = x.UnitPrice,
                        Total = x.Total,
                        Description = x.Description,
                    })
                .ToList(),

                Payments = DTO.Payments
                    .Select(x => new InvoicePayment
                    {
                        InvoiceId = x.InvoiceId,
                        ReceiptNumber = x.ReceiptNumber,
                        Type = x.Type,
                        Amount = x.Amount,
                        PaymentMethodId = x.PaymentMethodId,
                        PaymentDate = x.PaymentDate,
                        ReferenceNumber = x.ReferenceNumber,
                    })
                .ToList()

            };
        }

        public static void UpdateEntity(this Invoice Entity, InvoiceDTO DTO)
        {

            ArgumentNullException.ThrowIfNull(Entity);
            ArgumentNullException.ThrowIfNull(DTO);

            Entity.InvoiceNumber = Entity.InvoiceNumber;
            Entity.PatientId = Entity.PatientId;
            Entity.InvoiceDate = Entity.InvoiceDate;
            Entity.Status = Entity.Status;
            Entity.Subtotal = Entity.Subtotal;
            Entity.DiscountAmount = Entity.DiscountAmount;
            Entity.TaxAmount = Entity.TaxAmount;
            Entity.GrandTotal = Entity.GrandTotal;

            Entity.UpdatedAt = DateTime.UtcNow;

        }

    }
}
