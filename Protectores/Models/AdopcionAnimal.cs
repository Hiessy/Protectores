using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Protectores.Models
{
    public class AdopcionAnimal
    {
        [Key]
        public int AdopcionAnimalId { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

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