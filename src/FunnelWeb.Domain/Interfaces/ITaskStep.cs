namespace FunnelWeb.Domain.Interfaces
{
    public interface ITaskStep
    {
        int? ProgressEstimate { get; }
        string LogMessage { get; }
    }
}