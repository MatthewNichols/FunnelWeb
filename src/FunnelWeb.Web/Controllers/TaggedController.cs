using System.Web.Mvc;
using FunnelWeb.Core.Filters;
using FunnelWeb.Domain.Interfaces;
using FunnelWeb.Domain.Interfaces.Repositories;
using FunnelWeb.Domain.Model;

namespace FunnelWeb.Web.Controllers
{
    [FunnelWebRequest]
    public class TaggedController : Controller
    {
        private readonly IEntrySummaryRepository entityRepository;

        public TaggedController(IEntrySummaryRepository entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        public ActionResult Index(string tag)
        {
            var tagItems = entityRepository.GetByTag(tag); //.Find(new GetEntriesByTagQuery(tag, EntryStatus.PublicBlog), 0, 30);
            ViewBag.Tag = tag;
            return View(tagItems);
        }
    }
}
