using ClinicFlow.Domain.DTOs.LabCategory;
using ClinicFlow.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Application.Services
{
    public interface ILabCategoryService
    {
        Task<Result<int>> AddAsync(LabCategoryDTO dto);
        Task<Result<bool>> UpdateAsync(int id, LabCategoryDTO dto);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<LabCategoryDTO>> GetByIdAsync(int id);
        Task<Result<IEnumerable<LabCategoryDTO>>> GetAllAsync();
        Task<Result<IEnumerable<LabCategorySearchDTO>>> SearchAsync(string search);
        Task<Result<PagedResult<LabCategoryDTO>>> GetAllAsync(LabCategoryFilterDTO filter);
        Task<Result<IEnumerable<LabCategorySearchDTO>>> GetForSelectAsync();

    }
}
