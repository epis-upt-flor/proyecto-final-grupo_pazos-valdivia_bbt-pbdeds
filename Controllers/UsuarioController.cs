using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BBT_Plataforma_Establecimientos_De_Salud.Models;
using BBT_Plataforma_Establecimientos_De_Salud.Models.DB;

namespace BBT_Plataforma_Establecimientos_De_Salud.Controllers
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
    }
}
