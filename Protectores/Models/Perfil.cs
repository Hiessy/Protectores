using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Protectores.Models
{
    public enum TipoPerfil
    {
        Protector,
        Adopciones
    }

    public class Perfil
    {
        [Key]
        public int PerfilId { get; set; }

        [Required]
        public TipoPerfil TipoPerfil { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}