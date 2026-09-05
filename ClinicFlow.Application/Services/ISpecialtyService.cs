using ClinicFlow.Domain.DTOs.Specialty;
using ClinicFlow.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Application.Services
{
    public interface ISpecialtyService
    {
        Task<Result<int>> AddAsync(SpecialtyDTO dto);
        Task<Result<bool>> UpdateAsync(int id, SpecialtyDTO dto);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<SpecialtyDTO>> GetByIdAsync(int id);
        Task<Result<IEnumerable<SpecialtyDTO>>> GetAllAsync();
        Task<Result<IEnumerable<SpecialtySearchDTO>>> SearchAsync(string search);
        Task<Result<PagedResult<SpecialtyDTO>>> GetAllAsync(SpecialtyFilterDTO filter);
        Task<Result<IEnumerable<SpecialtySearchDTO>>> GetForSelectAsync();

    }
}
