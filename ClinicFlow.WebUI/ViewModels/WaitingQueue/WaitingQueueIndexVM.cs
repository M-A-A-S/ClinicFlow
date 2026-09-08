using ClinicFlow.Domain.DTOs.WaitingQueue;
using ClinicFlow.Domain.Utilities;

namespace ClinicFlow.WebUI.ViewModels.WaitingQueue
{
    public class WaitingQueueIndexVM
    {
        public PagedResult<WaitingQueueDTO> PagedResult { get; set; } = new();
        public WaitingQueueFilterDTO Filter { get; set; } = new();

    }
}
