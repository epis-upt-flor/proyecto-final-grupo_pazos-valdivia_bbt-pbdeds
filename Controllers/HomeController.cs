using BBT_EstablecimientosDeSalud.Models;
using BBT_EstablecimientosDeSalud.Models.DB;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BBT_EstablecimientosDeSalud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            EstablecimientoDeSalud objEst = new EstablecimientoDeSalud();
            var listEst = objEst.Listar();
            return View(listEst);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}