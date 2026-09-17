using ClinicFlow.Domain.DTOs.LabOrder;
using ClinicFlow.Domain.DTOs.LabTest;
using ClinicFlow.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Application.Services
{
    public interface ILabOrderService
    {
        Task<Result<int>> AddAsync(LabOrderDTO dto);
        Task<Result<bool>> UpdateAsync(int id, LabOrderDTO dto);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<LabOrderDTO>> GetByIdAsync(int id);
        Task<Result<IEnumerable<LabOrderDTO>>> GetAllAsync();
        Task<Result<PagedResult<LabOrderDTO>>> GetAllAsync(LabOrderFilterDTO filter);
        

    }
}
