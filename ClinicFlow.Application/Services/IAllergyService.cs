using ClinicFlow.Domain.DTOs.Allergy;
using ClinicFlow.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Application.Services
{
    public interface IAllergyService
    {
        Task<Result<int>> AddAsync(AllergyDTO dto);
        Task<Result<bool>> UpdateAsync(int id, AllergyDTO dto);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<AllergyDTO>> GetByIdAsync(int id);
        Task<Result<IEnumerable<AllergyDTO>>> GetAllAsync();
        Task<Result<IEnumerable<AllergySearchDTO>>> SearchAsync(string search);
        Task<Result<PagedResult<AllergyDTO>>> GetAllAsync(AllergyFilterDTO filter);
        Task<Result<IEnumerable<AllergySearchDTO>>> GetForSelectAsync();

    }
}
