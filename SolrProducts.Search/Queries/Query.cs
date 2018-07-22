using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolrProducts.Search.Facets;
using SolrProducts.Search.Filters;
using SolrProducts.Search.Sorting;

namespace SolrProducts.Search.Queries
{
    public class Query
    {
        public int? NumToReturn { get; set; }
        public string SearchText { get; set; }
        public IEnumerable<Filter> Filters { get; set; }
        public IEnumerable<Facet> Facets { get; set; }
        public int? Page { get; set; }
        public SortOrder SortOrder { get; set; }
    }
}
