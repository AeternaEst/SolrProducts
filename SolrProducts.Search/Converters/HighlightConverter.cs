using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolrNet.Commands.Parameters;

namespace SolrProducts.Search.Converters
{
    public static class HighlightConverter
    {
        public static HighlightingParameters GetSolrNetHighlightingParameters(string searchText)
        {
            return !string.IsNullOrEmpty(searchText)
                ? new HighlightingParameters
                {
                    BeforeTerm = "<span class=\"highlight\">",
                    AfterTerm = "</span>"
                }
                : null;
        }
    }
}
