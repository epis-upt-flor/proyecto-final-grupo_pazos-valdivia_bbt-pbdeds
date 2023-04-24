using Microsoft.AspNetCore.Mvc;
using BBT_Plataforma_Establecimientos_De_Salud.Models.DB;
using BBT_Plataforma_Establecimientos_De_Salud.ViewModel;

namespace BBT_Plataforma_Establecimientos_De_Salud.Controllers
{
    public class EstablecimientoDeSaludController : Controller
    {
        EstablecimientoDeSalud Est = new EstablecimientoDeSalud();
        public IActionResult Buscar(string criterio)
        {
            EstablecimientoDeSalud objEst = new EstablecimientoDeSalud();
            var listEst = objEst.Buscar(criterio);
            return View(listEst);
        }
        public IActionResult Detalle(int EstId)
        {
            EstablecimientoDeSalud objEst = new EstablecimientoDeSalud();
            EstablecimientoDeSaludViewModel objEstvm = new EstablecimientoDeSaludViewModel();
            Valoracion objVal = new Valoracion();
            var IdEst = objEst.BuscarId(EstId);
            objEstvm.estSalud = IdEst;
            objEstvm.valoracion = objVal.BuscarId(IdEst.Id);
            objEstvm.listValoracion = objVal.ListarId(IdEst.Id);
            objEstvm.TotalValoraciones = (objEstvm.listValoracion.Count() == 0) ? 0 : Convert.ToInt32(objEstvm.listValoracion.Sum(x => x.Valoracion1) / objEstvm.listValoracion.Count());
            return View(objEstvm);
        }
        [HttpPost]
        public IActionResult Valorar(Valoracion objVal)
        {

            objVal.Guardar();
            return RedirectToAction("Detalle", new { EstId = objVal.EstablecimientoId }); ;
        }
    }
}
