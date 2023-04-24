using Microsoft.AspNetCore.Mvc;
using BBT_Plataforma_Establecimientos_De_Salud.Models.DB;

namespace BBT_Plataforma_Establecimientos_De_Salud.Controllers
{
    public class LoginController : Controller
    {
        Usuario usuario = new Usuario();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuario objU)
        {
            Usuario LogUsuario = new Usuario();
            LogUsuario = usuario.Login(objU.Email, objU.Contrasena);
            HttpContext.Session.SetString("UsuarioNombre", LogUsuario.Nombre);
            HttpContext.Session.SetString("UsuarioId", LogUsuario.Id.ToString());
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
