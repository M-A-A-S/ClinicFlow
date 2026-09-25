using ClinicFlow.Domain.DTOs.PaymentMethod;
using ClinicFlow.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Application.Services
{
    public interface IPaymentMethodService
    {
        Task<Result<int>> AddAsync(PaymentMethodDTO dto);
        Task<Result<bool>> UpdateAsync(int id, PaymentMethodDTO dto);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<PaymentMethodDTO>> GetByIdAsync(int id);
        Task<Result<IEnumerable<PaymentMethodDTO>>> GetAllAsync();
        Task<Result<IEnumerable<PaymentMethodSearchDTO>>> SearchAsync(string search);
        Task<Result<PagedResult<PaymentMethodDTO>>> GetAllAsync(PaymentMethodFilterDTO filter);
        Task<Result<IEnumerable<PaymentMethodSearchDTO>>> GetForSelectAsync();

    }
}
