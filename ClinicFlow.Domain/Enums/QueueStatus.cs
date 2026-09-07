namespace ClinicFlow.Domain.Enums
{
    public enum QueueStatus
    {
        Waiting = 1,
        Called = 2,
        InConsultation = 3,
        Completed = 4,
        Skipped = 5,
        Cancelled = 6,
        NoShow = 7
    }
}
