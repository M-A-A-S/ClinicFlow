using ClinicFlow.Domain.DTOs.BondCategory;
using ClinicFlow.Domain.Utilities;

namespace ClinicFlow.WebUI.ViewModels.BondCategory
{
    public class BondCategoryIndexVM
    {
        public PagedResult<BondCategoryDTO> PagedResult { get; set; } = new();
        public BondCategoryFilterDTO Filter { get; set; } = new();

    }
}
