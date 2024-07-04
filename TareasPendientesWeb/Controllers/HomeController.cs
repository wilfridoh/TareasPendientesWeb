using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TareasPendientesWeb.Models;
using TareasPendientesWeb.Service;

namespace TareasPendientesWeb.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LoginService _authService;
        private static readonly HttpClient client = new HttpClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            var httpClient = new HttpClient();
            _authService = new LoginService(httpClient);
        }

        public IActionResult Index()
        {
            return View();
        }

        // POST: Account/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Llama al servicio de autenticación
                var token = await _authService.AuthenticateUserAsync(model.Username, model.Password);
                if (!string.IsNullOrEmpty(token))
                {
                    // Guarda el token en una cookie
                    //Response.Cookies.Add(new HttpCookie("auth_token", token));
                    return RedirectToAction("Index", "Tareas");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password is incorrect.");
                }
            }

            return View(model);
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
