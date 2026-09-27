using ClinicFlow.Domain.DTOs.PaymentMethod;
using ClinicFlow.Domain.Utilities;

namespace ClinicFlow.WebUI.ViewModels.PaymentMethod
{
    public class PaymentMethodIndexVM
    {
        public PagedResult<PaymentMethodDTO> PagedResult { get; set; } = new();
        public PaymentMethodFilterDTO Filter { get; set; } = new();

    }
}
