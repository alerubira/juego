using Juego.Services;
using Juego.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;


namespace Juego.Controllers
{
    public class LoginController : Controller
    {
        private readonly SeguridadService _seguridadService;
        private readonly DataContext _context;

        public LoginController(SeguridadService seguridadService,DataContext context)
        {
            _seguridadService = seguridadService;
             _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
         [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Loguearse(string usuario, string clave)
        {
             // 1️⃣ Buscar persona por Email (usuario)
            var persona = await _context.Personas
                .FirstOrDefaultAsync(p => p.Email == usuario && p.Existe);

            if (persona == null)
            {
                ModelState.AddModelError("", "Usuario o clave incorrectos");
                return View("Index");
            }

            // 2️⃣ Verificar clave
            if (!_seguridadService.VerificarContraseña(clave, persona.Clave))
            {
                ModelState.AddModelError("", "Usuario o clave incorrectos");
                return View("Index");
            }

            // 3️⃣ Crear claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, persona.Email),
                new Claim("IdPersona", persona.IdPersona.ToString()),
                new Claim(ClaimTypes.Role, persona.IdRol.ToString())
            };

            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            var principal = new ClaimsPrincipal(identity);

            // 4️⃣ Login con cookie
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                }
            );
            if(persona.IdRol != 1){
                 return View("~/Views/Principal/Index.cshtml");
            }
            return RedirectToAction("Index", "Home");
        }
    }
        }

    