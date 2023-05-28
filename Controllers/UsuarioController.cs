using BBT_EstablecimientosDeSalud.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BBT_EstablecimientosDeSalud.Models;

namespace BBT_EstablecimientosDeSalud.Controllers
{
    public class UsuarioController : Controller
    {
        //GET: Usuario
        private Usuario objUsu = new Usuario();
        public IActionResult Perfil()
        {
            return View();
        }
        public IActionResult Registrar(Usuario objUsu)
        {
            if (ModelState.IsValid)
            {
                objUsu.Registrar();
                return View(objUsu);
            }
            else
            {
                return View(objUsu);
            }
        }

        [HttpGet]
        public IActionResult Perfil(int idUs)
        {
            var resultado = objUsu.BuscarId(idUs);
            return View(resultado);
        }

        [HttpPost]
        public IActionResult Perfil(Usuario objUsu)
        {
            objUsu.Registrar();
            return Redirect("~/Usuario/Perfil?idUs=" + objUsu.Id);
        }
    }
}
