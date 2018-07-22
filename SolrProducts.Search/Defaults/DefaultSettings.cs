using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolrProducts.Search.Facets;
using SolrProducts.Search.Sorting;

namespace SolrProducts.Search.Defaults
{
    public static class DefaultSettings
    {
        public static int? DefaultNumToReturn => 3;

        public static int? DefaultFacetMinCount => 1;

        public static string DefaultExcludePrefix => "exclude";

        private static IEnumerable<Facet> _defaultFacets;

        public static IEnumerable<Facet> DefaultFacets => _defaultFacets ?? (_defaultFacets = new List<Facet>
        {
            new Facet { FieldName = "category", MinCount = DefaultFacetMinCount },
            new Facet { FieldName = "type", MinCount = DefaultFacetMinCount },
            new Facet { FieldName = "manufac", MinCount = DefaultFacetMinCount }
        });

        private static IEnumerable<SortOrder> _defaultSortOrders;

        public static IEnumerable<SortOrder> DefaultSortOrders => _defaultSortOrders ?? (_defaultSortOrders =
            new List<SortOrder>
            {
                new SortOrder { SortField = "price" },
                new SortOrder { SortField = "intro_date"}
            });
    }
}
