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
            EstablecimientoDeSalud objEst = new EstablecimientoDeSalud();
            List<EstablecimientoDeSaludViewModel> listEstvm = new List<EstablecimientoDeSaludViewModel>();
            Ep objEp = new Ep();
            var listEst = new List<EstablecimientoDeSalud>();
            if (criterio == "" || criterio == null)
            {
                listEst = objEst.Listar().Where(x => x.EpsId == epsid).ToList();
            }
            else
            {
                listEst = objEst.Buscar(criterio).Where(x => x.EpsId == epsid).ToList();
            }
            foreach (var item in listEst)
            {
                EstablecimientoDeSaludViewModel objEstvm = new EstablecimientoDeSaludViewModel();
                objEstvm.estSalud = item;
                objEstvm.eps = objEp.BuscarId(item.EpsId);
                listEstvm.Add(objEstvm);
            }
            return View(listEstvm);
        }
        public IActionResult Detalle(int EstId)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Valorar(Valoracion objVal)
        {
            objVal.Guardar();
            return RedirectToAction("Detalle", new { EstId = objVal.EstablecimientoId }); ;
        }
    }
}
