using ClinicFlow.Domain.DTOs.LabTest;
using ClinicFlow.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Application.Services
{
    public interface ILabTestService
    {
        Task<Result<int>> AddAsync(LabTestDTO dto);
        Task<Result<bool>> UpdateAsync(int id, LabTestDTO dto);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<LabTestDTO>> GetByIdAsync(int id);
        Task<Result<IEnumerable<LabTestDTO>>> GetAllAsync();
        Task<Result<PagedResult<LabTestDTO>>> GetAllAsync(LabTestFilterDTO filter);
        Task<Result<IEnumerable<LabTestSearchDTO>>> GetForSelectAsync();


    }
}
