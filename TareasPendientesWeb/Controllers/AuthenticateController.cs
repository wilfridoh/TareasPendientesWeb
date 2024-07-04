using Microsoft.AspNetCore.Mvc;
using TareasPendientesWeb.Service;

[Route("api/[controller]")]
public class AuthenticateController : Controller
{
    private readonly LoginService _authService;

    public AuthenticateController()
    {
        var httpClient = new HttpClient();
        _authService = new LoginService(httpClient);
    }

}
