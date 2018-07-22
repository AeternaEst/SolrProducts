using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolrProducts.Search.Defaults;
using SolrNet;

namespace SolrProducts.Search.Converters
{
    public static class OffsetConverter
    {
        public static StartOrCursor GetOffsetFromCurrentPage(int? currentPage)
        {
            var offset = 0;
            if (currentPage != null)
            {
                try
                {
                    var i = DefaultSettings.DefaultNumToReturn * currentPage - DefaultSettings.DefaultNumToReturn;
                    if (i != null)
                        offset = i.Value;
                }
                catch (Exception e) { }
            }

            return new StartOrCursor.Start(offset);
        }
    }
}
