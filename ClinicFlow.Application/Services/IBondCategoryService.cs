using ClinicFlow.Domain.DTOs.BondCategory;
using ClinicFlow.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Application.Services
{
    public interface IBondCategoryService
    {
        Task<Result<int>> AddAsync(BondCategoryDTO dto);
        Task<Result<bool>> UpdateAsync(int id, BondCategoryDTO dto);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<BondCategoryDTO>> GetByIdAsync(int id);
        Task<Result<IEnumerable<BondCategoryDTO>>> GetAllAsync();
        Task<Result<IEnumerable<BondCategorySearchDTO>>> SearchAsync(string search);
        Task<Result<PagedResult<BondCategoryDTO>>> GetAllAsync(BondCategoryFilterDTO filter);
        Task<Result<IEnumerable<BondCategorySearchDTO>>> GetForSelectAsync();

    }
}
