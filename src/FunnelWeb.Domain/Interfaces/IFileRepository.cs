using System.IO;
using System.Web.Mvc;
using FunnelWeb.Domain.Model;

namespace FunnelWeb.Domain.Interfaces
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