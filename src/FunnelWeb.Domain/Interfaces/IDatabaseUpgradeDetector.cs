namespace FunnelWeb.Domain.Interfaces
{
    public interface IDatabaseUpgradeDetector
    {
        bool UpdateNeeded();
        void Reset();
    }
}
