using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Juego.Models
{
	public class Personas
	{
		[Key]
		[Display(Name = "Código Int.")]
		public int IdPersona { get; set; }
        [Required(ErrorMessage = "El DNI es obligatorio")]
		[StringLength(10, ErrorMessage = "El DNI no puede superar los 10 caracteres")]
		public required int Dni { get; set; } 
		[Required(ErrorMessage = "El apellido es obligatorio")]
		[StringLength(30, ErrorMessage = "El apellido no puede superar los 30 caracteres")]
		public required string Apellido { get; set; } 
		[Required(ErrorMessage = "El nombre es obligatorio")]
		[StringLength(40, ErrorMessage = "El nombre no puede superar los 40 caracteres")]
		public required string Nombre { get; set; } 

        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public required DateTime FechaNacimiento{ get; set; }

        public string? ImgPerfil { get; set; } 

        [Display(Name = "Correo Electronico")]
        [Required, EmailAddress]
		public required string Email { get; set; } 
		
		[Display(Name = "Teléfono")]
		[StringLength(30, ErrorMessage = "El teléfono no puede superar los 30 caracteres")]
		public required string Telefono { get; set; } 

		[StringLength(100, ErrorMessage = "La clave no puede superar los 100 caracteres")]
		public required string Clave { get; set; } 
		
        [StringLength(100, ErrorMessage = "La clave no puede superar los 100 caracteres")]
		public string? ClaveProvisoria { get; set; } 

           [Required]
       [ForeignKey("Roles")]
        public int IdRol { get; set; }
         
         [Required]
        public bool Existe { get; set; } 
		
    }
}