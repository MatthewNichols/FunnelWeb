namespace FunnelWeb.Core.DatabaseDeployer
{
    public interface IDatabaseUpgradeDetector
    {
        bool UpdateNeeded();
        void Reset();
    }
}
