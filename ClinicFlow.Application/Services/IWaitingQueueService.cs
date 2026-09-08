using ClinicFlow.Domain.DTOs.WaitingQueue;
using ClinicFlow.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Application.Services
{
    public interface IWaitingQueueService
    {
        Task<Result<int>> AddAsync(WaitingQueueDTO dto);
        Task<Result<bool>> UpdateAsync(int id, WaitingQueueDTO dto);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<WaitingQueueDTO>> GetByIdAsync(int id);
        Task<Result<IEnumerable<WaitingQueueDTO>>> GetAllAsync();
        Task<Result<PagedResult<WaitingQueueDTO>>> GetAllAsync(WaitingQueueFilterDTO filter);

    }
}
