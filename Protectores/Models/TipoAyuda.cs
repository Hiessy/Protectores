using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Protectores.Models
{
    public enum TipoAnimal
    {
        Perro,
        Gato
    }

    public class TipoAyuda
    {
        [Key]
        public int id { get; set; }

        [Required]
        public TipoAnimal TipoAnimal { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}