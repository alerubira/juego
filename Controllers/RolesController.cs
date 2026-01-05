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
    public class RolesController : Controller
    {
          private readonly DataContext _context;

        public RolesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "2")]
        public async Task<IActionResult> Index()
        {
            var roles = await _context.Roles.ToListAsync();
            return View(roles);
        }
    }
}