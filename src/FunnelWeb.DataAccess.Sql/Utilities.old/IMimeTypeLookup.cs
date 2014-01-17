namespace FunnelWeb.DataAccess.Sql.Utilities
{
    public interface IMimeTypeLookup
    {
        string GetMimeType(string fileNameOrPathWithExtension);
    }
}
