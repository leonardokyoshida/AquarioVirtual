using AquarioVirtual.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AquarioVirtual.Web.Controllers
{

    public class HomeController : Controller
    {
        static System.Net.Http.HttpClient api = new System.Net.Http.HttpClient();
        public static List<Artigo> artigos = new List<Artigo>();

        public ActionResult Index()
        {
            var result = Artigo.Get(api);
            artigos = result.Result.OrderByDescending(x=> x.DataPublicacao).ToList();
            return View(artigos);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}