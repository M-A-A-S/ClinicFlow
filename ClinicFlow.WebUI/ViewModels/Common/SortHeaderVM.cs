using ClinicFlow.Domain.DTOs.Common;

namespace ClinicFlow.WebUI.ViewModels.Common
{
    public class SortHeaderVM
    {
        public string Column { get; set; } = "";
        public string Title { get; set; } = "";
        public BaseFilterDTO Filter { get; set; } = default!;
        public Dictionary<string, string> Routes { get; set; } = new();
    }
}
