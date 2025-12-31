using Juego.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Juego.Controllers
{
    public class LoginController : Controller
    {
        private readonly SeguridadService _seguridadService;

        public LoginController(SeguridadService seguridadService)
        {
            _seguridadService = seguridadService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}