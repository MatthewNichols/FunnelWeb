using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
//using FunnelWeb.Core.Filters;
using FunnelWeb.Domain.Eventing;
using FunnelWeb.Domain.Interfaces;
using FunnelWeb.Domain.Interfaces.Repositories;
using FunnelWeb.Domain.Model;
using FunnelWeb.Domain.Model.Strings;
using FunnelWeb.Domain.Settings;
using FunnelWeb.Domain.Utilities;
using FunnelWeb.Web.Application.Mvc;
using FunnelWeb.Web.Application.Spam;

namespace FunnelWeb.Web.Areas.Admin.Controllers
{
    //[FunnelWebRequest]
    [HandleError]
    [ValidateInput(false)]
    public class WikiAdminController : Controller
    {
        public IAuthenticator Authenticator { get; set; }
        public ITagRepository TagRepository { get; set; }
        public IEntryRevisionRepository EntryRevisionRepository { get; set; }
        public IEntryRepository EntryRepository { get; set; }
        public ISpamChecker SpamChecker { get; set; }
        public IEventPublisher EventPublisher { get; set; }
        public ISettingsProvider SettingsProvider { get; set; }

        [Authorize(Roles = "Moderator")]
        public virtual ActionResult Edit(PageName page, int? revertToRevision)
        {
            var allTags = TagRepository.FindAll();

            var entry =
                revertToRevision == null
                    ? EntryRevisionRepository.GetByName(page)
                    : EntryRevisionRepository.GetByNameAndRevision(page, revertToRevision.Value);

            if (entry == null)
            {
                entry = new EntryRevision
                            {
                                Title = "New post",
                                MetaTitle = "New post",
                                Name = page
                            };
            }

            entry.ChangeSummary = entry.Id == 0
                                      ? "Initial create"
                                      : (revertToRevision == null ? "" : "Reverted to version " + revertToRevision);
            entry.AllTags = allTags;

            if (revertToRevision != null)
            {
                return View("Edit", entry).AndFlash("You are editing an old version of this page. This will become the current version when you save.");
            }
            return View("Edit", entry);
        }

        [HttpPost]
        [Authorize(Roles = "Moderator")]
        public virtual ActionResult Edit(EntryRevision model)
        {
            model.AllTags = TagRepository.FindAll();

            if (!ModelState.IsValid)
            {
                model.SelectedTags = GetEditTags(model);
                return View(model);
            }

            var author = Authenticator.GetName();
            var entry = EntryRepository.Get(model.Id);
            if (entry == null && CurrentEntryExistsWithName(model.Name))
            {
                model.SelectedTags = GetEditTags(model);
                ModelState.AddModelError("PageExists", string.Format("A page with SLUG '{0}' already exists. You should edit that page instead", model.Name));
                return View(model);
            }

            if (entry == null && CurrentEntryExistsWithName(model.Title) && model.Name == "")
            {
                model.SelectedTags = GetEditTags(model);
                ModelState.AddModelError("PageExists", string.Format("A page with SLUG '{0}' already exists. Please add a unique SLUG here.", model.Title));
                return View(model);
            }

            entry = entry ?? new Entry {Author = author};
            entry.Name = string.IsNullOrWhiteSpace(model.Name) ? model.Title.Slugify() : model.Name.ToString();
            entry.PageTemplate = string.IsNullOrEmpty(model.PageTemplate) ? null : model.PageTemplate;
            entry.Title = model.Title ?? string.Empty;
            entry.Summary = model.Summary ?? string.Empty;
            entry.MetaTitle = string.IsNullOrWhiteSpace(model.MetaTitle) ? model.Title : model.MetaTitle;
            entry.IsDiscussionEnabled = !model.DisableComments;
            entry.MetaDescription = model.MetaDescription ?? string.Empty;
            entry.HideChrome = model.HideChrome;

            //Only change the publish date if the dates no longer match, this means that
            //time changes wont be tracked.
            var published = DateTime.Parse(model.PublishDate + " " + DateTime.Now.ToShortTimeString(), CultureInfo.CurrentCulture).ToUniversalTime();
            if(entry.Published.Date != published.Date)
                entry.Published = published;

            entry.Status = model.Status;

            var revision = entry.Revise();
            revision.Author = author;
            revision.Body = model.Body;
            revision.Reason = model.ChangeSummary ?? string.Empty;
            revision.Format = model.Format;

            var editTags = GetEditTags(model);
            var toDelete = entry.Tags.Where(t => !editTags.Contains(t)).ToList();
            var toAdd = editTags.Where(t => !entry.Tags.Contains(t)).ToList();

            foreach (var tag in toDelete)
                tag.Remove(entry);
            foreach (var tag in toAdd)
            {
                if (tag.Id == 0)
                {
                    TagRepository.Add(tag);
                }
                tag.Add(entry);
            }

            EventPublisher.Publish(new EntrySavedEvent(entry));

            if (model.IsNew)
            {
                EntryRepository.Add(entry);
            }

            return RedirectToAction("Page", "Wiki", new { Area = "", page = entry.Name});
        }

        private bool CurrentEntryExistsWithName(string name)
        {
            return EntryRevisionRepository.GetByName(name) != null;
        }

        private List<Tag> GetEditTags(EntryRevision model)
        {
            var tagList = new List<Tag>();
            foreach (var tagName in model.TagsCommaSeparated.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Where(s => s != "0"))
            {
                int id;
                var tag = int.TryParse(tagName, out id) ? TagRepository.Get(id) : new Tag {Name = tagName};
                tagList.Add(tag);
            }

            return tagList;
        }

        [Authorize(Roles = "Moderator")]
        [HttpPost]
        public virtual ActionResult DeletePage(int id)
        {
            EntryRepository.Remove(EntryRepository.Get(id));
            return RedirectToAction("PageList", "Admin");
        }
    }
}
