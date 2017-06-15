using AquarioVirtual.Web.Models;
using System.Web.Mvc;

namespace AquarioVirtual.Web.Controllers
{
    public class UsuarioController : Controller
    {
        static System.Net.Http.HttpClient api = new System.Net.Http.HttpClient();

        public ActionResult Logout()
        {
            Session["userId"] = null;
            Session["userName"] = null;

            return RedirectToAction("Index", "Home");
        }

        public PartialViewResult Modal()
        {
            return PartialView("_Login", new Usuario());
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            var result = Usuario.Autentica(api, usuario);
            Usuario user = result.Result;
            if (user != null)
            {
                Session["userId"] = user.Id.ToString();
                Session["userName"] = $"{user.Nome} {user.UltimoNome}";

            }

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Register(Usuario usuario)
        {
            var user = Usuario.Registrar(api, usuario);
            if(user !=null)
            {
                Session["userId"] = user.Result.Id;
                Session["userName"] = $"{user.Result.Nome} {user.Result.UltimoNome}";
            }

            return RedirectToAction("Index", "Home");
        }
    }
}