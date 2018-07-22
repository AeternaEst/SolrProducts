using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SolrProducts.Logic.Interfaces;

namespace SolrProducts.Logic.Services
{
    public class Service : IService
    {
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}