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

        public PersonasController(DataContext context)
        {
            _context = context;
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

            if (ModelState.IsValid)
            {
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(persona);
        }
}
}