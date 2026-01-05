using System.ComponentModel.DataAnnotations;

namespace Juego.Models
{
    public class RespuestaJuegoModel
    {
        public int IdRespuesta { get; set; }

        [Required]
        public string Enunciado { get; set; } = string.Empty;

        public bool EsCorrecta { get; set; }

        // FK lógica (no para EF, sino para el juego)
        public int IdPregunta { get; set; }
    }
}
