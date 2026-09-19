using ClinicFlow.Domain.DTOs.Invoice;
using ClinicFlow.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Application.Services
{
    public interface IInvoiceService
    {
        Task<Result<int>> AddAsync(InvoiceDTO dto);
        Task<Result<IEnumerable<InvoiceDTO>>> GetAllAsync();
        Task<Result<PagedResult<InvoiceDTO>>> GetAllAsync(InvoiceFilterDTO filter);
        Task<Result<InvoiceDTO>> GetByIdAsync(int id);
        Task<Result<bool>> UpdateAsync(int id, InvoiceDTO dto);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
