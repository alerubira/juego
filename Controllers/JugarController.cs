using Juego.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Juego.Models;
using Microsoft.EntityFrameworkCore;


namespace Juego.Controllers
{
    public class JugarController : Controller
    {
          private readonly DataContext _context;
          private readonly SeguridadService _seguridadService;

        public JugarController(DataContext context, SeguridadService seguridadService)
        {
            _context = context;
            _seguridadService = seguridadService;
        }

        [HttpGet]
         [Authorize(Roles = "1")]
        public  async Task<IActionResult> Index()
        {
             var idPersonaClaim = User.FindFirst("IdPersona")?.Value;

            if (idPersonaClaim == null)
                return RedirectToAction("Index", "Login");

            int idPersona = int.Parse(idPersonaClaim);

            var persona = await _context.Personas
                .FirstOrDefaultAsync(p => p.IdPersona == idPersona);

            if (persona == null)
                return NotFound();

            return View(persona);
        }
    }
}