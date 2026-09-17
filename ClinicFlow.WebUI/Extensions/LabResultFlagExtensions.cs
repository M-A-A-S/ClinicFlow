using ClinicFlow.Domain.Enums;

namespace ClinicFlow.WebUI.Extensions
{
    public static class LabResultFlagExtensions
    {
        public static string ToCssClass(this LabResultFlag flag)
        {
            return flag switch
            {
                LabResultFlag.None => "bg-secondary",
                LabResultFlag.Normal => "bg-success",
                LabResultFlag.Abnormal => "bg-warning text-dark",
                LabResultFlag.Critical => "bg-danger",
                _ => "bg-secondary"
            };
        }
    }
}
