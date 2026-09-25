using ClinicFlow.Domain.DTOs.Invoice;
using ClinicFlow.Domain.Utilities;

namespace ClinicFlow.WebUI.ViewModels.Invoice
{
    public class InvoiceIndexVM
    {
        public PagedResult<InvoiceDTO> PagedResult { get; set; } = new();
        public InvoiceFilterDTO Filter { get; set; } = new();
    }
}
