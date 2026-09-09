using ClinicFlow.Domain.DTOs.Medicine;
using ClinicFlow.Domain.Utilities;

namespace ClinicFlow.WebUI.ViewModels.Medicine
{
    public class MedicineIndexVM
    {
        public PagedResult<MedicineDTO> PagedResult { get; set; } = new();
        public MedicineFilterDTO Filter { get; set; } = new();

    }
}
