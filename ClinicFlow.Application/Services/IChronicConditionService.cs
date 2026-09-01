using ClinicFlow.Domain.DTOs.ChronicCondition;
using ClinicFlow.Domain.Utilities;

namespace ClinicFlow.Application.Services
{
    public interface IChronicConditionService
    {
        Task<Result<int>> AddAsync(ChronicConditionDTO dto);
        Task<Result<bool>> UpdateAsync(int id, ChronicConditionDTO dto);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<ChronicConditionDTO>> GetByIdAsync(int id);
        Task<Result<IEnumerable<ChronicConditionDTO>>> GetAllAsync();
        Task<Result<IEnumerable<ChronicConditionSearchDTO>>> SearchAsync(string search);
        Task<Result<PagedResult<ChronicConditionDTO>>> GetAllAsync(ChronicConditionFilterDTO filter);
        Task<Result<IEnumerable<ChronicConditionSearchDTO>>> GetForSelectAsync();

    }
}
