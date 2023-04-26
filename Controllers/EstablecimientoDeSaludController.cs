using Microsoft.AspNetCore.Mvc;
using BBT_EstablecimientosDeSalud.Models.DB;
using BBT_EstablecimientosDeSalud.ViewModels;

namespace BBT_EstablecimientosDeSalud.Controllers
{
    public class EstablecimientoDeSaludController : Controller
    {
        EstablecimientoDeSalud Est = new EstablecimientoDeSalud();
        public IActionResult Buscar(string criterio, int epsid)
        {
            return View();
        }
        public IActionResult Detalle(int EstId)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Valorar(Valoracion objVal)
        {
            return View(objVal);
        }
    }
}
