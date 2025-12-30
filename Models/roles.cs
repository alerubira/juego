using System.ComponentModel.DataAnnotations;


namespace juego.Models
{
	public class Roles
	{
		[Key]
		[Display(Name = "Código Int.")]
		public int IdRol { get; set; }
		[Required(ErrorMessage = "El nombre del rol es obligatorio")]
		[StringLength(30, ErrorMessage = "El nombre del rol no puede superar los 30 caracteres")]
		public required string NombreRol { get; set; }
		
    }
}