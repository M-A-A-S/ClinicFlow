using ClinicFlow.Domain.Entities;
using ClinicFlow.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Infrastructure.Configurations
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable("PaymentMethods");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NameEn)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.NameAr)
                .IsRequired()
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.Type)
                .HasConversion<string>()
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

            builder.HasData(LoadPaymentMethods());

        }

        private static List<PaymentMethod> LoadPaymentMethods()
        {
            return new()
            {
                new PaymentMethod
                {
                    Id = 1,
                    NameEn = "Cash",
                    NameAr = "نقداً",
                    Type = PaymentMethodType.Cash,
                    IsActive = true
                },

                new PaymentMethod
                {
                    Id = 2,
                    NameEn = "Bankak",
                    NameAr = "بنكك",
                    Type = PaymentMethodType.BankTransfer,
                    IsActive = true
                },

                new PaymentMethod
                {
                    Id = 3,
                    NameEn = "Fawry",
                    NameAr = "فوري",
                    Type = PaymentMethodType.BankTransfer,
                    IsActive = true
                },

                new PaymentMethod
                {
                    Id = 4,
                    NameEn = "Salih",
                    NameAr = "ساهل",
                    Type = PaymentMethodType.BankTransfer,
                    IsActive = true
                },

                new PaymentMethod
                {
                    Id = 5,
                    NameEn = "OCash",
                    NameAr = "أوكاش",
                    Type = PaymentMethodType.BankTransfer,
                    IsActive = true
                }
            };

        }
    }
}
