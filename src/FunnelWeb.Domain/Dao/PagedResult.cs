using System.Collections;
using System.Collections.Generic;

namespace FunnelWeb.Domain.Dao
{
    public class PagedResult<T> : IEnumerable<T>
    {
        private readonly IList<T> results;

        public PagedResult(IList<T> results, int skipped, int itemsPerPage)
        {
            this.results = results;
//            TotalResults = totalCount;
            ItemsPerPage = itemsPerPage == 0 ? 10 : itemsPerPage;
            Page = (int) ((decimal) skipped/ItemsPerPage);
            TotalPages = (int) ((decimal) results.Count/ItemsPerPage + 1);
        }

        public int TotalResults { get; private set; }

        /// <summary>
        /// Page Number is 0 based
        /// </summary>
        public int Page { get; private set; }
        public int TotalPages { get; private set; }
        public int ItemsPerPage { get; private set; }

        public int Count
        {
            get { return results.Count; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return results.GetEnumerator();
        }

        public T this[int index]
        {
            get { return results[index]; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}