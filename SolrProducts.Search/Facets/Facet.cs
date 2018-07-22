using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrProducts.Search.Facets
{
    public class Facet
    {
        public string FieldName { get; set; }
        public int? MinCount { get; set; }
    }
}
