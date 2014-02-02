using System;
using System.Linq;
using System.Web.Mvc;
//using FunnelWeb.Core.Filters;
using FunnelWeb.Domain.Dao;
using FunnelWeb.Domain.Eventing;
using FunnelWeb.Domain.Interfaces;
using FunnelWeb.Domain.Interfaces.Repositories;
using FunnelWeb.Domain.Model;
using FunnelWeb.Domain.Model.Strings;
using FunnelWeb.Domain.Settings;
using FunnelWeb.Web.Application.Mvc;
using FunnelWeb.Web.Application.Mvc.ActionResults;
using FunnelWeb.Web.Application.Spam;
using FunnelWeb.Web.Views.Wiki;

namespace FunnelWeb.Web.Controllers
{
    //[FunnelWebRequest]
    [HandleError]
    [ValidateInput(false)]
    public class WikiController : Controller
    {
        private const int ItemsPerPage = 30;
        public IEntryRepository EntryRepository { get; set; }
        public IEntrySummaryRepository EntrySummaryRepository { get; set; }
        public IEntryRevisionRepository EntryRevisionRepository { get; set; }
        public ISpamChecker SpamChecker { get; set; }
        public IEventPublisher EventPublisher { get; set; }
        public ISettingsProvider SettingsProvider { get; set; }

        public virtual ActionResult Home(int? pageNumber)
        {
            var settings = SettingsProvider.GetSettings<FunnelWebSettings>();
            if (!string.IsNullOrWhiteSpace(settings.CustomHomePage))
            {
                var entry = EntryRevisionRepository.GetByName(settings.CustomHomePage); // .FindFirstOrDefault(new EntryByNameQuery(settings.CustomHomePage));
                if (entry != null)
                {
                    ViewData.Model = new PageModel(entry.Name, entry);
                    return new PageTemplateActionResult(
                        pageTemplate: entry.PageTemplate,
                        actionName: "Page"
                    );
                }
            }

            return Recent(pageNumber ?? 0);
        }

        public virtual ActionResult Recent(int pageNumber)
        {
            //TODO: Handle the paging
            var result = EntrySummaryRepository.GetByStatus(EntryStatus.PublicBlog);
            var pagedResult = new PagedResult<EntrySummary>(result, 0, 0);
            ViewData.Model = new RecentModel("Recent Posts", pagedResult, ControllerContext.RouteData.Values["action"].ToString());
            return View("Recent");
        }

        public virtual ActionResult Search([Bind(Prefix = "q")] string searchText, bool? is404)
        {
            //var results = EntryRevisionRepository.Find(new SwitchingSearchEntriesQuery(searchText), 0, 30);
            var results = EntryRevisionRepository.Search(searchText);
            var entryRevisions = new PagedResult<EntryRevision>(results.ToList(), 0, 0);
            return View("Search", new SearchModel(searchText, is404 ?? false, entryRevisions));
        }

        public virtual ActionResult Page(PageName page, int? revision)
        {
            if (revision != null && !SettingsProvider.GetSettings<FunnelWebSettings>().EnablePublicHistory)
            {
                return RedirectToAction("Page", "Wiki", new { page, revision = (int?)null });
            }

            //var entry = revision == null
            //                ? EntryRevisionRepository.FindFirstOrDefault(new EntryByNameQuery(page))
            //                : EntryRepository.FindFirstOrDefault(new EntryByNameAndRevisionQuery(page, revision.Value));

            var entry = revision == null
                            ? EntryRevisionRepository.GetByName(page)
                            : EntryRevisionRepository.GetByNameAndRevision(page, revision.Value);

            if (entry == null)
            {
                if (HttpContext.User.Identity.IsAuthenticated)
                    return RedirectToAction("Edit", "WikiAdmin", new { Area = "Admin", page });
                return Search(page, true);
            }

            if (entry.Status == EntryStatus.Private && !HttpContext.User.Identity.IsAuthenticated)
            {
                return Search(page, true);
            }

            ViewData.Model = new PageModel(page, entry);
            return new PageTemplateActionResult(
                pageTemplate: entry.PageTemplate
            );
        }

        // Posting a comment
        [HttpPost]
        public virtual ActionResult Page(PageName page, PageModel model)
        {
            //var entry = EntryRepository.FindFirstOrDefault(new EntryByNameQuery(page));
            var entry = EntryRevisionRepository.GetByName(page);
            if (entry == null)
                return RedirectToAction("Recent");

            if (!ModelState.IsValid)
            {
                model.Entry = entry;
                model.Page = page;
                ViewData.Model = model;
                return new PageTemplateActionResult(entry.PageTemplate, "Page");
            }

            var comment = entry.Entry.Value.Comment();
            comment.AuthorEmail = model.CommenterEmail ?? string.Empty;
            comment.AuthorName = model.CommenterName ?? string.Empty;
            comment.AuthorUrl = model.CommenterBlog ?? string.Empty;
            comment.AuthorIp = Request.UserHostAddress;
            comment.EntryRevisionNumber = entry.LatestRevisionNumber;
            comment.Body = model.Comments;

            try
            {
                SpamChecker.Verify(comment);
            }
            catch (Exception ex)
            {
                HttpContext.Trace.Warn("Akismet is offline, comment cannot be validated: " + ex);
            }

            // Anything posted after the disable date is considered spam (the comment box shouldn't be visible anyway)
            var settings = SettingsProvider.GetSettings<FunnelWebSettings>();
            if (settings.DisableCommentsOlderThan > 0 && DateTime.UtcNow.AddDays(settings.DisableCommentsOlderThan) > entry.Published)
            {
                comment.IsSpam = true;
                entry.Entry.Value.CommentCount = entry.Entry.Value.Comments.Count(c => !c.IsSpam);
            }

            EventPublisher.Publish(new CommentPostedEvent(entry.Entry.Value, comment));

            return RedirectToAction("Page", new { page })
                .AndFlash("Thanks, your comment has been posted.");
        }

        public virtual ActionResult Revisions(PageName page)
        {
            var settings = SettingsProvider.GetSettings<FunnelWebSettings>();
            if (!settings.EnablePublicHistory)
            {
                return RedirectToAction("Page", "Wiki", new { page });
            }

            //var entry = EntryRepository.FindFirstOrDefault(new EntryByNameQuery(page));
            var entry = EntryRevisionRepository.GetByName(page);
            if (entry == null)
            {
                return RedirectToAction("Edit", "WikiAdmin", new { page });
            }

            ViewData.Model = new RevisionsModel(page, entry.Entry.Value);
            return View();
        }

        public virtual ActionResult SiteMap()
        {
            //var allPosts = EntryRepository.Find(new GetFullEntriesQuery(true), 0, 500);
            var allPosts = EntryRevisionRepository.GetFullEntries(true);
            ViewData.Model = new SiteMapModel(allPosts);
            return View();
        }

        public virtual ActionResult Pingbacks(PageName page)
        {
            //var entry = EntryRepository.FindFirst(new GetEntryWithPingbacksQuery(page));
            var entry = EntryRevisionRepository.GetEntryWithPingbacks(page);
            return View(entry);
        }
    }
}
