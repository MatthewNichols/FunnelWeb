using System.IO;
using System.Web.Mvc;
using FunnelWeb.DataAccess.Sql.Model;
using FunnelWeb.Domain.Model;

namespace FunnelWeb.DataAccess.Sql.Providers.File
{
    public interface IFileRepository
    {
        bool IsFile(string path);
        FileItem[] GetItems(string path);

        void Move(string oldPath, string newPath);
        void Delete(string filePath);

        void CreateDirectory(string path, string name);
        void Save(Stream inputStream, string path, bool unzip);
        ActionResult Render(string path);
    }
}