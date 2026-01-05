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
    public class PersonasController : Controller
    {
          private readonly DataContext _context;
          private readonly SeguridadService _seguridadService;

        public PersonasController(DataContext context, SeguridadService seguridadService)
        {
            _context = context;
            _seguridadService = seguridadService;
        }

        [HttpGet]
         [Authorize(Roles = "2")]
        public  async Task<IActionResult> Index()
        {
            var personas = await _context.Personas.ToListAsync();
            return View(personas);
        }
        [HttpGet]
         [AllowAnonymous]
        public  IActionResult Create()
        {
            return View();
        }
        [HttpPost]
         [AllowAnonymous]
        public async Task<IActionResult> Create(Personas persona)
        {

             if (!ModelState.IsValid)
                    return View(persona);

                // 1️⃣ Verificar si existe el email
                bool emailExiste = await _context.Personas
                    .AnyAsync(p => p.Email == persona.Email);

                if (emailExiste)
                {
                    ModelState.AddModelError("Email", "El correo ya está registrado");
                    return View(persona);
                }

                // 2️⃣ Asignar rol por defecto
                persona.IdRol = 1;

                // 3️⃣ Datos del sistema
                persona.Existe = true;
                persona.Clave = _seguridadService.HashearContraseña(persona.Clave);

                // 4️⃣ Guardar
                _context.Personas.Add(persona);
                await _context.SaveChangesAsync();

                // 5️⃣ Redirigir al login
                return RedirectToAction("Index", "Login");
        }
}
}