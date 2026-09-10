using ClinicFlow.Domain.DTOs.Visit;
using ClinicFlow.Domain.Utilities;

namespace ClinicFlow.WebUI.ViewModels.Visit
{
    public class VisitIndexVM
    {
        public PagedResult<VisitDTO> PagedResult { get; set; } = new();
        public VisitFilterDTO Filter { get; set; } = new();

    }
}
