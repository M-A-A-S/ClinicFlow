using ClinicFlow.Domain.DTOs.Bond;
using ClinicFlow.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Application.Services
{
    public interface IBondService
    {
        Task<Result<int>> AddAsync(BondDTO dto);
        Task<Result<bool>> UpdateAsync(int id, BondDTO dto);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<BondDTO>> GetByIdAsync(int id);
        Task<Result<IEnumerable<BondDTO>>> GetAllAsync();
        Task<Result<PagedResult<BondDTO>>> GetAllAsync(BondFilterDTO filter);

    }
}
