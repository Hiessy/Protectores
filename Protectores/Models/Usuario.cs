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
        public int id { get; set; }

        [ForeignKey("Contacto")]
        public int ContactoId { get; set; }
        public virtual Contacto Contacto { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo Electrónico")]
        public string Correo { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }
}