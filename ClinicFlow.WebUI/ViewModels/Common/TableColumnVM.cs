namespace ClinicFlow.WebUI.ViewModels.Common
{
    public class TableColumnVM
    {
        public string Column { get; set; }
        public string Title { get; set; }
        public bool IsSortable { get; set; } = true;
    }
}
