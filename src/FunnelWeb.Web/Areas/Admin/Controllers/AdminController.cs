using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using FunnelWeb.Core.Filters;
using FunnelWeb.Core.Tasks;
//using FunnelWeb.DataAccess.Sql.Repositories;
//using FunnelWeb.DataAccess.Sql.Repositories.Queries;
using FunnelWeb.Domain.Dao;
using FunnelWeb.Domain.Interfaces;
using FunnelWeb.Domain.Interfaces.Repositories;
using FunnelWeb.Domain.Model;
using FunnelWeb.Domain.Settings;
using FunnelWeb.Web.Application.Mvc;
using FunnelWeb.Web.Application.Themes;
using FunnelWeb.Web.Areas.Admin.Views.Admin;
using NHibernate;

namespace FunnelWeb.Web.Areas.Admin.Controllers
{
    [FunnelWebRequest]
    [ValidateInput(false)]
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        public IAdminRepository AdminRepository { get; set; }
        public ISettingsProvider SettingsProvider { get; set; }
        public IThemeProvider ThemeProvider { get; set; }
        public ICommentRepository CommentRepository { get; set; }
        public IEntrySummaryRepository EntrySummaryRepository { get; set; }
        public IPingbackRepository PingbackRepository { get; set; }
        public ITaskStateRepository TaskRepository { get; set; }
        public ISession DatabaseSession { get; set; }
        public ITaskExecutor<BlogMLImportTask> ImportTask { get; set; }
        public Func<IProviderInfo<IFileRepository>> FileRepositoriesInfo { get; set; }

        public virtual ActionResult Index()
        {
            return View(new IndexModel());
        }

        public virtual ActionResult Settings()
        {
            var settings = SettingsProvider.GetSettings<FunnelWebSettings>();
            ViewBag.Themes = ThemeProvider.GetThemes();
            ViewBag.FileRepositories = FileRepositoriesInfo().Keys;
            return View(settings);
        }

        [HttpPost]
        public virtual ActionResult Settings(FunnelWebSettings settings)
        {
            ViewBag.Themes = ThemeProvider.GetThemes();
            ViewBag.FileRepositories = FileRepositoriesInfo().Keys;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Your settings could not be saved. Please fix the errors shown below.");
                return View(settings);
            }

            SettingsProvider.SaveSettings(settings);

            return RedirectToAction("Settings", "Admin")
                .AndFlash("Your changes have been saved");
        }

        #region Comments

        public virtual ActionResult Comments(int? pageNumber)
        {
            var page = pageNumber ?? 0;

            var results = CommentRepository.GetQueryable(); // .Find(new GetAllCommentsQuery(), page, 20);
            var comments = new PagedResult<Comment>(results.ToList(), 0, 0);
            return View(new CommentsModel(page, comments));
        }

        public virtual ActionResult DeleteComment(int id)
        {
            var item = CommentRepository.Get(id);
            CommentRepository.Remove(item);
            
            AdminRepository.UpdateCommentCountFor(item.Entry.Id);
            return RedirectToAction("Comments", "Admin");
        }

        public virtual ActionResult DeleteAllSpam()
        {
            var comments = CommentRepository.GetSpam().ToList();
            foreach (var comment in comments)
            {
                CommentRepository.Remove(comment);
            }

            foreach (var entryToUpdate in comments.Select(c=>c.Entry.Id).GroupBy(id=>id))
            {
                AdminRepository.UpdateCommentCountFor(entryToUpdate.Key);
            }

            return RedirectToAction("Comments", "Admin");
        }

        public virtual ActionResult ToggleSpam(int id)
        {
            var item = CommentRepository.Get(id);
            if (item != null)
            {
                item.IsSpam = !item.IsSpam;
                AdminRepository.UpdateCommentCountFor(item.Entry.Id);
            }
            return RedirectToAction("Comments", "Admin");
        }

        #endregion

        #region Pingbacks

        public virtual ActionResult Pingbacks()
        {
            var pingbacks = PingbackRepository.FindAll();
            return View(new PingbacksModel(pingbacks));
        }

        public virtual ActionResult DeletePingback(int id)
        {
            //var item = Repository.Get<Pingback>(id);
            var item = PingbackRepository.Get(id);
            PingbackRepository.Remove(item);
            return RedirectToAction("Pingbacks", "Admin");
        }

        public virtual ActionResult TogglePingbackSpam(int id)
        {
            var item = PingbackRepository.Get(id);
            if (item != null)
            {
                item.IsSpam = !item.IsSpam;
            }
            return RedirectToAction("Pingbacks", "Admin");
        }

        #endregion

        #region Tasks

        public virtual ActionResult Tasks()
        {
            var tasks = TaskRepository.GetAll().OrderByDescending(x => x.Started);
            return View("Tasks", new TasksModel(tasks.ToList()));
        }

        public virtual ActionResult Task(int id)
        {
            var task = TaskRepository.Get(id);
            return View("Task", new TaskModel(task));
        }

        #endregion

        #region Import

        public virtual ActionResult BlogMLImport()
        {
            return View(new BlogMLImportModel());
        }

        [HttpPost]
        public virtual ActionResult BlogMLImport(FileUpload upload)
        {
            if (upload == null || string.IsNullOrWhiteSpace(upload.FileName))
            {
                ModelState.AddModelError("File", "Please select a file to upload.");
                return View();
            }

            var fullPath = Server.MapPath(SettingsProvider.GetSettings<FunnelWebSettings>().UploadPath);
            fullPath = Path.Combine(fullPath, upload.FileName);
            upload.SaveTo(fullPath);

            var id = ImportTask.Execute(new { inputFile = fullPath });
            return RedirectToAction("Task", new { id });
        }

        #endregion

        public virtual ActionResult PageList(EntriesSortColumn? sort, bool? asc)
        {
            if (sort == null)
                sort = EntriesSortColumn.Slug;

            //var entries = EntrySummaryRepository.Find(new GetEntriesQuery(EntryStatus.All, sort.Value, asc ?? true), 0, 500);
            var entries = EntrySummaryRepository.FindAll();

            return View(new PageListModel(entries) { SortAscending = asc.GetValueOrDefault() });
        }
    }
}
