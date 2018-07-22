using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolrNet.Attributes;

namespace SolrProducts.Search.Documents
{
    public class Product
    {
        [SolrField("id")]
        public string Id { get; set; }
        [SolrField("name")]
        public string Name { get; set; }
        [SolrField("category")]
        public string Category { get; set; }
        [SolrField("type")]
        public string Type { get; set; }
        [SolrField("manufac")]
        public string Manufacture { get; set; }
        [SolrField("description")]
        public string Description { get; set; }
        [SolrField("price")]
        public int Price { get; set; }
        [SolrField("intro_date")]
        public DateTime IntroDate { get; set; }
        [SolrField("reviews")]
        public IEnumerable<string> Reviews { get; set; }
    }
}