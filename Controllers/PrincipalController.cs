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
    public class PrincipalController : Controller
    {
        
        private readonly DataContext _context;

        public PrincipalController(DataContext context)
        {
            
             _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "2,3")]
        public IActionResult Index()
        {
            return View();
        }
    }
}