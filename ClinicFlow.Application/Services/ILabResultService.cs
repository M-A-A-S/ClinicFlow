using ClinicFlow.Domain.DTOs.LabResult;
using ClinicFlow.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Application.Services
{
    public interface ILabResultService
    {
        Task<Result<int>> AddAsync(LabResultDTO dto);
        Task<Result<bool>> UpdateAsync(int id, LabResultDTO dto);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<LabResultDTO>> GetByIdAsync(int id);
        Task<Result<LabResultDTO>> GetByOrderItemIdAsync(int orderItemId);
        Task<Result<IEnumerable<LabResultDTO>>> GetAllAsync();
        Task<Result<PagedResult<LabResultDTO>>> GetAllAsync(LabResultFilterDTO filter);

    }
}
