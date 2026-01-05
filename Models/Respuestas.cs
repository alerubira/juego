using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Juego.Models
{
    public class Respuestas
{
    [Key]
    public int Id { get; set; }

    [Required]

    public required string Enunciado { get; set; }

    public bool EsCorrecta { get; set; }

    public int IdPregunta { get; set; }

    public Preguntas? Pregunta { get; set; }
}
}