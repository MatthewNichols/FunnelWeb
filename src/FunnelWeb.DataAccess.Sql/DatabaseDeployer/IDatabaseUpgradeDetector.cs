namespace FunnelWeb.DataAccess.Sql.DatabaseDeployer
{
    public interface IDatabaseUpgradeDetector
    {
        bool UpdateNeeded();
        void Reset();
    }
}
