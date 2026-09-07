using ClinicFlow.Domain.DTOs.Clinic;
using ClinicFlow.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Application.Services
{
    public interface IClinicService
    {
        Task<Result<int>> AddAsync(ClinicDTO dto);
        Task<Result<bool>> UpdateAsync(int id, ClinicDTO dto);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<ClinicDTO>> GetByIdAsync(int id);
        Task<Result<IEnumerable<ClinicDTO>>> GetAllAsync();
        Task<Result<IEnumerable<ClinicSearchDTO>>> SearchAsync(string search);
        Task<Result<PagedResult<ClinicDTO>>> GetAllAsync(ClinicFilterDTO filter);
        Task<Result<IEnumerable<ClinicSearchDTO>>> GetForSelectAsync();

    }
}
