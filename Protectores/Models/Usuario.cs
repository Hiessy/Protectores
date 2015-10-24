using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Protectores.Models
{
    public enum Perfil
    {
        Protector, Adoptador, Basico
    }
    public class Usuario
    {
        public string CorreoID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Organizacion { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public ICollection<Perfil> Perfil { get; set; }

    }
}