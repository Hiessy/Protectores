using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Protectores.Models
{
    public class AdopcionAnimal
    {
        [Key]
        public int id { get; set; }

        public int usuarioId { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Nombre de la mascota")]
        public string nombre { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression(@"\d{0,20}", ErrorMessage = "La especie debe tener menos de 20 caracteres.")]
        [Display(Name = "Especie")]
        public string especie { get; set; }
    }
}