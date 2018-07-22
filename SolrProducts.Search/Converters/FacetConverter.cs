using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolrProducts.Search.Defaults;
using SolrProducts.Search.Queries;
using SolrNet;
using SolrNet.Commands.Parameters;

namespace SolrProducts.Search.Converters
{
    public static class FacetConverter
    {
        public static FacetParameters GetSolrNetFacetParameters(Query query, string facetNameToExclude = null)
        {
            if (query.Facets != null && query.Facets.Any())
            {
                var facetParams = new FacetParameters
                {
                    Queries = new List<ISolrFacetQuery>()
                };

                foreach (var facet in query.Facets)
                {
                    string facetName = facet.FieldName;
                    if (!string.IsNullOrEmpty(facetNameToExclude) && facet.FieldName == facetNameToExclude)
                    {
                        facetName = new LocalParams {
                            {
                                "ex", DefaultSettings.DefaultExcludePrefix + facetNameToExclude
                            } } + facetNameToExclude;
                    }

                    facetParams.Queries.Add(new SolrFacetFieldQuery(facetName)
                    {
                        MinCount = facet.MinCount ?? 1
                    });
                }

                return facetParams;
            }

            return null;
        } 
    }
}
