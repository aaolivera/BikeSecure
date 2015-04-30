using System.Linq;
using System.Web.Mvc;
using Dominio;
using Repositorio;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private RepositorioEf repositorio;
        public HomeController()
        {
            var context = new DbContexto();
            repositorio = new RepositorioEf(context);
        }

        public ActionResult Index()
        {
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

        public ActionResult LogActividad(int id)
        {
            return View(new ListaLogActividadDto
                {
                    LogActividades = repositorio.Listar<LogActividad>(x => x.Zocalo.Id == id).ToList(),
                    Titulo = "Slot " + repositorio.Obtener<Zocalo>(x => x.Id == id).Id
                });
        }
    }
}
