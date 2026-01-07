using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Juego.Models
{
    public class Preguntas
{
    [Key]
    public int IdPregunta { get; set; }

    [Required]
    public required string Enunciado { get; set; }

    // ⏱️ Tiempo límite en segundos (ej: 50)
    public int TiempoSegundos { get; set; }

    public ICollection<Respuestas> Respuestas { get; set; }
        = new List<Respuestas>(); // 🔴 CLAVE
}
}