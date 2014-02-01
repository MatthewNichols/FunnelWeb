using System.Linq;
using System.Web.Mvc;
using FunnelWeb.Domain.Interfaces;
using FunnelWeb.Domain.Interfaces.Repositories;

namespace FunnelWeb.Web.Controllers
{
    [Authorize]
    public class TagController : Controller
    {
        private readonly ITagRepository tagRepository;

        public TagController(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        [HttpGet]
        public ActionResult Index(string tagName = null)
        {
            var tags = tagRepository.SearchByName(tagName);
            return Json(tags.Select(x => new { Id = x.Id, Name = x.Name }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Tag(string tagName)
        {
            var tag = tagRepository.SearchByName(tagName).FirstOrDefault();
            return Json(tag);
        }
    }
}
