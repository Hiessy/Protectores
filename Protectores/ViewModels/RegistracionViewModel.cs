using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Protectores.Models;

namespace Protectores.ViewModels
{
    public class RegistracionViewModel
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Contacto Direccion { get; set; }
    }
}