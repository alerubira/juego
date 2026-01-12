using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Juego.Models
{
    public class PreguntaJuegoModel
    {
        public int IdPregunta { get; set; }

        [Required]
        public string Enunciado { get; set; } = string.Empty;

        public int TiempoSegundos { get; set; }

        // Para crear
        [Required]
        public string RespuestaCorrecta { get; set; } = string.Empty;

        [Required]
        public string RespuestaIncorrecta1 { get; set; } = string.Empty;

        [Required]
        public string RespuestaIncorrecta2 { get; set; } = string.Empty;

        [Required]
        public string RespuestaIncorrecta3 { get; set; } = string.Empty;

        // Para jugar (mostrar opciones)
        public List<RespuestaJuegoModel> Respuestas { get; set; } = new();

        // Para capturar elección del jugador
        public int? RespuestaSeleccionadaId { get; set; }
    }
}
