using System.Web.Mvc;
using FunnelWeb.Core.Filters;
using FunnelWeb.DataAccess.Sql.Repositories.Queries;
using FunnelWeb.Domain.Interfaces;
using FunnelWeb.Domain.Model;

namespace FunnelWeb.Web.Controllers
{
    [FunnelWebRequest]
    public class TaggedController : Controller
    {
        private readonly IRepository repository;

        public TaggedController(IRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index(string tag)
        {
            var tagItems = repository.Find(new GetEntriesByTagQuery(tag, EntryStatus.PublicBlog), 0, 30);
            ViewBag.Tag = tag;
            return View(tagItems);
        }
    }
}
