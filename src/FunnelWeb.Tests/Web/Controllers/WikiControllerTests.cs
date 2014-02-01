﻿//using System.Collections.Generic;
//using System.Web.Mvc;
//using FunnelWeb.Domain.Dao;
//using FunnelWeb.Domain.Interfaces.Repositories;
//using FunnelWeb.Domain.Model;
//using FunnelWeb.Web.Application.Spam;
//using FunnelWeb.Web.Controllers;
//using FunnelWeb.Web.Views.Wiki;
//using NSubstitute;
//using NUnit.Framework;
//using PageModel = FunnelWeb.Web.Views.Wiki.PageModel;

//namespace FunnelWeb.Tests.Web.Controllers
//{
//    [TestFixture]
//    public class WikiControllerTests: ControllerTests
//    {
//        protected WikiController Controller { get; set; }
//        protected ISpamChecker SpamChecker { get; set; }
//        private IEntryRevisionRepository entryRevisionRepository { get; set; }
//        private IEntrySummaryRepository entrySummaryRepository { get; set; }
        
//        [SetUp]
//        public void SetUp()
//        {
//            entryRevisionRepository = Substitute.For<IEntryRevisionRepository>();
//            entrySummaryRepository = Substitute.For<IEntrySummaryRepository>();
//            Controller = new WikiController
//                             {
//                                 EntrySummaryRepository = entrySummaryRepository,
//                                 SpamChecker = SpamChecker = Substitute.For<ISpamChecker>(),
//                                 ControllerContext = ControllerContext,
//                                 SettingsProvider = SettingsProvider
//                             };
//        }

//        [Test]
//        public void Search()
//        {
//            var entries = new PagedResult<EntryRevision>(new List<EntryRevision>(), 0, 0, 50);
//            entryRevisionRepository.Search() .Find(Arg.Is<SwitchingSearchEntriesQuery>(q=>q.SearchText == "search"), Arg.Any<int>(), Arg.Any<int>()).Returns(entries);

//            var result = (ViewResult)Controller.Search("search", false);

//            Repository.Received().Find(Arg.Is<SwitchingSearchEntriesQuery>(q => q.SearchText == "search"), Arg.Any<int>(), Arg.Any<int>());
//            Assert.That(result.ViewName, Is.EqualTo("Search"));
//            Assert.IsInstanceOf<SearchModel>(result.ViewData.Model);
//            Assert.AreEqual(entries, ((SearchModel)result.ViewData.Model).Results);
//        }

//        [Test]
//        public void PageLoggedInAndRedirectsToNewEntry()
//        {
//            Repository.FindFirstOrDefault(Arg.Any<EntryByNameQuery>()).Returns(x => null);
//            Identity.IsAuthenticated.Returns(true);
            
//            var result = (RedirectToRouteResult)Controller.Page("page", 0);

//            Assert.AreEqual("Edit", result.RouteValues["Action"]);
//            Repository.Received().FindFirstOrDefault(Arg.Is<EntryByNameAndRevisionQuery>(q=>q.PageName =="page" && q.Revision == 0));
//        }

//        [Test]
//        public void WikiControllerTestsPageReturnsNotFoundForNewPageAndNotLoggedIn()
//        {
//            var entries = new List<EntryRevision>();
//            var searchResults = new PagedResult<EntryRevision>(entries, 0, 0, 50);
//            Repository.FindFirstOrDefault(Arg.Any<EntryByNameQuery>()).Returns(x => null);
//            Repository.Find(Arg.Any<SwitchingSearchEntriesQuery>(), Arg.Any<int>(), Arg.Any<int>()).Returns(searchResults);
//            Identity.IsAuthenticated.Returns(false);
            
//            var result = (ViewResult)Controller.Page("page", 0);

//            Assert.AreEqual("Search", result.ViewName);
//            Assert.IsNotNull(result.ViewData.Model);
//            Assert.IsInstanceOf(typeof(SearchModel), result.ViewData.Model);

//            var model = (SearchModel)result.ViewData.Model;
//            Assert.AreSame(searchResults, model.Results);

//            Repository.Received().Find(Arg.Is<SwitchingSearchEntriesQuery>(q => q.SearchText == "page"), Arg.Any<int>(), Arg.Any<int>());
//            Repository.Received().FindFirstOrDefault(Arg.Is<EntryByNameAndRevisionQuery>(q => q.PageName == "page" && q.Revision == 0));
//        }

//        [Test]
//        public void WikiControllerTestsPageReturnsFoundPage()
//        {
//            var entry = new EntryRevision { Name = "page" };
//            Repository.FindFirstOrDefault(Arg.Any<EntryByNameQuery>()).Returns(entry);

//            Controller.Page(entry.Name, (int?)null);

//            Assert.IsNotNull(Controller.ViewData.Model);
//            Assert.IsInstanceOf<PageModel>(Controller.ViewData.Model);

//            var model = (PageModel)Controller.ViewData.Model;
//            Assert.AreEqual(entry, model.Entry);
//            Repository.Received().FindFirstOrDefault(Arg.Is<EntryByNameQuery>(q=>q.PageName == entry.Name));
//        }
//    }
//}
