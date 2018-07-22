using SolrProducts.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using SolrProducts.Search.Defaults;
using SolrProducts.Search.Index;

namespace SolrProducts.Controllers.View
{
    public class HomeController : Controller
    {

        protected IService Service;
        protected ISearcher Searcher;

        public HomeController(IService service, ISearcher searcher)
        {
            Service = service;
            Searcher = searcher;
        }

        public ActionResult Index()
        {
            //return RedirectToAction("TestDi");

            Searcher.GetAllProducts();

            return View(DefaultSettings.DefaultNumToReturn);
        }

        public ActionResult TestDi()
        {
            var model = Service.HelloWorld();

            return View((object)model);
        }
    }
}