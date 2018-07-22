using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolrProducts.Search.Queries;
using SolrProducts.Search.Sorting;
using SolrNet;
using SortOrder = SolrNet.SortOrder;

namespace SolrProducts.Search.Converters
{
    public static class SortOrderConverter
    {
        public static ICollection<SortOrder> GetSortOrder(Query query)
        {
            if (string.IsNullOrEmpty(query.SortOrder?.SortField))
                return null;

            Order order = query.SortOrder.Direction == Direction.Descending ? Order.DESC : Order.ASC;

            return new[] {new SortOrder(query.SortOrder.SortField, order)};
        } 
    }
}
