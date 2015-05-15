using System.Linq;
using System.Web.Mvc;
using Dominio;
using Repositorio;
using Web.Models;

namespace Web.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
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

        public ActionResult Refresco()
        {
            var estacionamientos = repositorio.Listar<Estacionamiento>();
            return View("Estacionamientos",new IndexDto { Estacionamientos = estacionamientos.ToList() });
        }

        public ActionResult LogActividad(int id)
        {
            var zocalo = repositorio.Obtener<Zocalo>(x => x.Id == id);
            return View(new ListaLogActividadDto
                {
                    Estados = zocalo.EstadosHistoricos.OrderByDescending(x => x.Id).ToList(),
                    EstadoActual = zocalo.Estado,
                    Titulo = "Slot " + zocalo.Id
                });
        }
    }
}
