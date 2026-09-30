using ClinicFlow.Domain.DTOs.Bond;
using ClinicFlow.Domain.Utilities;

namespace ClinicFlow.WebUI.ViewModels.Bond
{
    public class BondIndexVM
    {
        public PagedResult<BondDTO> PagedResult { get; set; } = new();
        public BondFilterDTO Filter { get; set; } = new();

    }
}
