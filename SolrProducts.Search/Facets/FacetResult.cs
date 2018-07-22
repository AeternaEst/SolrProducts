using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrProducts.Search.Facets
{
    public class FacetResult
    {
        public string FacetName { get; set; }
        public IEnumerable<KeyValuePair<string, int>> Results { get; set; }
    }
}
