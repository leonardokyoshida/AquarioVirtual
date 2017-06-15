using AquarioVirtual.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AquarioVirtual.Web.Controllers
{
    public class ArtigoController : Controller
    {
        static System.Net.Http.HttpClient api = new System.Net.Http.HttpClient();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(string id)
        {
            var artigo = HomeController.artigos.Find(x => x.Id == id);

            return View(artigo);
        }

        public ActionResult Create()
        {
            var artigo = new Artigo();
            return View(artigo);
        }

        public ActionResult Edit(string id)
        {
            var artigo = HomeController.artigos.Find(x => x.Id == id);
            return View("Create",artigo);
        }

        [HttpPost]
        public ActionResult Create(Artigo artigo, HttpPostedFileBase fileFoto)
        {
            var filename = Path.GetFileName(fileFoto.FileName);
            var path = Path.Combine(Server.MapPath("~/Imagens"), filename);
            fileFoto.SaveAs(path);
            var url = Path.Combine("http://aquariovirtual.azurewebsites.net/Imagens/", filename);
            artigo.Fotos = new string[] { url };
            var result = Artigo.Save(api,artigo);
            var artigos = result.Result;
            //return RedirectToAction("Index","Home");
            return View(artigo);
           
        }
    }
}