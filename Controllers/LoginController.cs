using BBT_EstablecimientosDeSalud.Models.DB;
using Microsoft.AspNetCore.Mvc;

namespace BBT_EstablecimientosDeSalud.Controllers
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
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
