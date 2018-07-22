using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolrProducts.Search.Documents;
using SolrProducts.Search.Queries;

namespace SolrProducts.Search.Index
{
    public interface ISearcher
    {
        IEnumerable<Product> GetAllProducts();

        QueryResult<Product> Search(Query query);
    }
}
