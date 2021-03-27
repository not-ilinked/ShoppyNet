using System.Collections;
using System.Collections.Generic;

namespace Shoppy
{
    public class ShoppyPaginatedList<T> : IEnumerable<T>
    {
        public List<T> Items { get; private set; }

        internal ShoppyPaginatedList(ParsedResponse response)
        {
            Items = response.Body.ToObject<List<T>>();
            Total = int.Parse(response.Headers["X-Total-Pages"]);
            ItemsPerPage = int.Parse(response.Headers["X-Items-Per-Page"]);
        }

        public int Total { get; private set; }
        public int ItemsPerPage { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}
