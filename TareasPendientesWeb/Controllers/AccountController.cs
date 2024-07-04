using Microsoft.AspNetCore.Mvc;

namespace TareasPendientesWeb.Controllers
{
    public class AccountController : Controller
    {
        private static readonly HttpClient client = new HttpClient();

        // GET: Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

    }
}



