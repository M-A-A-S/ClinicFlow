using ClinicFlow.Domain.DTOs.Medicine;
using ClinicFlow.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Application.Services
{
    public interface IMedicineService
    {
        Task<Result<int>> AddAsync(MedicineDTO dto);
        Task<Result<bool>> UpdateAsync(int id, MedicineDTO dto);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<MedicineDTO>> GetByIdAsync(int id);
        Task<Result<IEnumerable<MedicineDTO>>> GetAllAsync();
        Task<Result<IEnumerable<MedicineSearchDTO>>> SearchAsync(string search);
        Task<Result<PagedResult<MedicineDTO>>> GetAllAsync(MedicineFilterDTO filter);
        Task<Result<IEnumerable<MedicineSearchDTO>>> GetForSelectAsync();

    }
}
