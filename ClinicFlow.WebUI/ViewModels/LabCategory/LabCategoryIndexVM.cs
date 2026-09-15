using ClinicFlow.Domain.DTOs.LabCategory;
using ClinicFlow.Domain.Utilities;

namespace ClinicFlow.WebUI.ViewModels.LabCategory
{
    public class LabCategoryIndexVM
    {
        public PagedResult<LabCategoryDTO> PagedResult { get; set; } = new();
        public LabCategoryFilterDTO Filter { get; set; } = new();

    }
}
