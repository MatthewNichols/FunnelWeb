namespace FunnelWeb.Domain.Settings
{
    public interface IAppHarborSettings
    {
        string SqlServerConnectionString { get; set; }
    }
}