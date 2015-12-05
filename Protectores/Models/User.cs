using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Protectores.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [ForeignKey("Adress")]
        public int AdressId { get; set; }
        public virtual Adress Adress { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
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