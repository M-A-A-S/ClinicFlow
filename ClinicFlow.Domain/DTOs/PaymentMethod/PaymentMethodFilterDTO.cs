using ClinicFlow.Domain.DTOs.Common;
using ClinicFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.PaymentMethod
{
    public class PaymentMethodFilterDTO : BaseFilterDTO
    {
        public PaymentMethodType? Type { get; set; }
    }
}
