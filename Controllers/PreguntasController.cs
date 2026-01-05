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
    public class PreguntasController : Controller
    {
          private readonly DataContext _context;
          private readonly SeguridadService _seguridadService;

        public PreguntasController(DataContext context, SeguridadService seguridadService)
        {
            _context = context;
            _seguridadService = seguridadService;
        }

        [HttpGet]
         [Authorize(Roles = "2,3")]
        public  async Task<IActionResult> Index()
        {
            var preguntas = await _context.Preguntas.ToListAsync();
            return View(preguntas);
        }
        [HttpGet]
         [Authorize(Roles = "2,3")]
        public  IActionResult Create()
        {
            return View();
        }
       
}
}