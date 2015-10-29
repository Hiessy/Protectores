using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Protectores.Models
{
    public enum Perfil {
        Basico, Protector, Adoptador, Ambos
    }
    public class Usuario
    {
        public int ProtectorID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Organizacion { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public Perfil Perfil { get; set; }
    }
}