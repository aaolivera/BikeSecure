using System.Linq;
using System.Web.Mvc;
using Dominio;
using Repositorio;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new DbContexto();
            var repositorio = new RepositorioEf(context);
            var estacionamientos = repositorio.Listar<Estacionamiento>();
            return View(new IndexDto { Estacionamientos = estacionamientos.ToList() });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
