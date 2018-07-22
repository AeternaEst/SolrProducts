using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrProducts.Search.Filters
{
    public class Filter
    {
        public string Name { get; set; }

        public IEnumerable<string> Values { get; set; }

        public string Tag { get; set; }

        public bool UseAndCondition { get; set; }
    }
}
