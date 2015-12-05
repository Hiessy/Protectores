using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Protectores.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Correo { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }
}