using ClinicFlow.Domain.DTOs.Visit;
using ClinicFlow.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Application.Services
{
    public interface IVisitService
    {
        Task<Result<int>> AddAsync(VisitDTO dto);
        Task<Result<bool>> UpdateAsync(int id, VisitDTO dto);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<VisitDTO>> GetByIdAsync(int id);
        Task<Result<IEnumerable<VisitDTO>>> GetAllAsync();
        Task<Result<PagedResult<VisitDTO>>> GetAllAsync(VisitFilterDTO filter);

    }
}
