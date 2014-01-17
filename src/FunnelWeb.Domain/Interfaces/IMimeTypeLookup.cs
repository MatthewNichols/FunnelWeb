namespace FunnelWeb.Domain.Interfaces
{
    public interface IMimeTypeLookup
    {
        string GetMimeType(string fileNameOrPathWithExtension);
    }
}
