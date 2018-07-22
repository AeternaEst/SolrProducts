using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolrProducts.Search.Documents;
using SolrNet;
using SolrNet.Impl;

namespace SolrProducts.Search
{
    public static class InitSolr
    {
        public static void Init()
        {
            Startup.Init<Product>(new SolrConnection("http://127.0.0.1:8983/solr/Products"));
        }
    }
}
