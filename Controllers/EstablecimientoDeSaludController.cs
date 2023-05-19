using Microsoft.AspNetCore.Mvc;
using BBT_EstablecimientosDeSalud.Models.DB;
using BBT_EstablecimientosDeSalud.ViewModels;
using BBT_EstablecimientosDeSalud.Models;

namespace BBT_EstablecimientosDeSalud.Controllers
{
    public class EstablecimientoDeSaludController : Controller
    {
        EstablecimientoDeSalud Est = new EstablecimientoDeSalud();
        public IActionResult Buscar(string criterio, int epsid)
        {
            EstablecimientoDeSalud objEst = new EstablecimientoDeSalud();
            EpsEstablecimientoDeSalud objEpsEst = new EpsEstablecimientoDeSalud();
            Busquedum objBusc = new Busquedum();
            List<EstablecimientoDeSaludViewModel> listEstvm = new List<EstablecimientoDeSaludViewModel>();
            Ep objEp = new Ep();
            var listEst = new List<EstablecimientoDeSalud>();
            var listEpsEst = new List<EpsEstablecimientoDeSalud>();
            if (criterio == "" || criterio == null)
            {
                listEst = objEst.Listar(epsid).ToList();
            }
            else
            {
                listEst = objEst.Buscar(criterio, epsid).ToList();
            }
            foreach (var item in listEst)
            {
                EstablecimientoResponse objEstResp = new EstablecimientoResponse();
                EstablecimientoDeSaludViewModel objEstvm = new EstablecimientoDeSaludViewModel();
                objEstvm.estSalud = item;
                objEstvm.eps = objEp.BuscarId(objEpsEst.BuscarId(item.Id).EpsId);
                objEstvm.Clasificacion = objEstResp.ObtenerEstablecimiento(item.Id).Result.clasfreal;
                listEstvm.Add(objEstvm);
            }
            objBusc.TerminoBusqueda = objEp.BuscarId(epsid).Nombre + " " + criterio;
            objBusc.UsuarioId = Convert.ToInt32(HttpContext.Session.GetString("UsuarioId"));
            objBusc.Fecha = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            objBusc.Registrar();
            return View(listEstvm);
        }
        public IActionResult Detalle(int EstId)
        {
            Ep objEp = new Ep();
            EstablecimientoDeSalud objEst = new EstablecimientoDeSalud();
            EstablecimientoDeSaludViewModel objEstvm = new EstablecimientoDeSaludViewModel();
            EpsEstablecimientoDeSalud objEpsEst = new EpsEstablecimientoDeSalud();
            Valoracion objVal = new Valoracion();
            var IdEst = objEst.BuscarId(EstId);
            objEstvm.estSalud = IdEst;
            objEstvm.eps = objEpsEst.BuscarIdEps(EstId);
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
