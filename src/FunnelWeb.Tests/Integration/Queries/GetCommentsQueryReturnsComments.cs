﻿using System;
using FunnelWeb.DataAccess.Sql.Repositories.Queries;
using FunnelWeb.Domain.Model;
using FunnelWeb.Tests.Helpers;
using NUnit.Framework;

namespace FunnelWeb.Tests.Integration.Queries
{
    [TestFixture]
    public class GetCommentsQueryReturnsComments : QueryIntegrationTest
    {
        public GetCommentsQueryReturnsComments()
            : base(TheDatabase.CanBeDirty)
        {
        }

        public override void TestQuery()
        {
            var name = "test-" + Guid.NewGuid();

            Database.WithRepository(
                repo =>
                {
                    var entry = new Entry { Name = name, Author = "A1" };
                    var revision = entry.Revise();
                    revision.Body = "Hello";
                    repo.Add(entry);
                    var comment = new Comment
                    {
                        AuthorName = "Test",
                        AuthorEmail = "test@test.net",
                        AuthorUrl = "",
                        Body = "Comment",
                        Posted = DateTime.Now,
                        Entry = entry,
                        IsSpam = false
                    };
                    var comment2 = new Comment
                    {
                        AuthorName = "Test2",
                        AuthorEmail = "test2@test.net",
                        AuthorUrl = "",
                        Body = "Comment2",
                        Posted = DateTime.Now,
                        Entry = entry,
                        IsSpam = false
                    };
                    entry.Comments.Add(comment);
                    entry.Comments.Add(comment2);
                    repo.Add(comment);
                    repo.Add(comment2);
                });

            Database.WithRepository(
                repo =>
                {
                    var result = repo.Find(new GetCommentsQuery(), 0, 1);
                    Assert.AreEqual(1, result.Count);
                    Assert.GreaterOrEqual(result.TotalResults, 2);
                });
        }
    }
}
