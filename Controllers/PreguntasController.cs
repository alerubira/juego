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
         [HttpPost]
         [Authorize(Roles = "2,3")]
         [ValidateAntiForgeryToken]
        public  async Task<IActionResult>  Create(PreguntaJuegoModel model)
        {
             if (!ModelState.IsValid)
                return View(model);

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // 1️⃣ Crear pregunta
                var pregunta = new Preguntas
                {
                    Enunciado = model.Enunciado,
                    TiempoSegundos = model.TiempoSegundos
                };

                _context.Preguntas.Add(pregunta);
                await _context.SaveChangesAsync();

                // 2️⃣ Crear respuestas
                var respuestas = new List<Respuestas>
                {
                    new Respuestas
                    {
                        Enunciado = model.RespuestaCorrecta,
                        EsCorrecta = true,
                        IdPregunta = pregunta.IdPregunta
                    },
                    new Respuestas
                    {
                        Enunciado = model.RespuestaIncorrecta1,
                        EsCorrecta = false,
                        IdPregunta = pregunta.IdPregunta
                    },
                    new Respuestas
                    {
                        Enunciado = model.RespuestaIncorrecta2,
                        EsCorrecta = false,
                        IdPregunta = pregunta.IdPregunta
                    },
                    new Respuestas
                    {
                        Enunciado = model.RespuestaIncorrecta3,
                        EsCorrecta = false,
                        IdPregunta = pregunta.IdPregunta
                    }
                };

                _context.Respuestas.AddRange(respuestas);
                await _context.SaveChangesAsync();

                // 3️⃣ Confirmar transacción
                await transaction.CommitAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                await transaction.RollbackAsync();
                ModelState.AddModelError("", "Error al crear la pregunta");
                return View(model);
            }

        }
       
}
}