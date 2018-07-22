using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolrProducts.Search.Documents;
using SolrProducts.Search.Facets;
using SolrProducts.Search.Sorting;

namespace SolrProducts.Search.Queries
{
    public class QueryResult<T> where T : Product
    {
        public int TotalResults { get; set; }

        public IEnumerable<T> Results { get; set; }

        public IEnumerable<FacetResult> FacetResults { get; set; }

        public IEnumerable<SortOrder> AvailableSorting { get; set; }

        public bool Success { get; set; }

        public IEnumerable<string> ErrorMessages { get; set; }

        public IEnumerable<Highlight.Highlight> Highlights { get; set; }
    }
}
