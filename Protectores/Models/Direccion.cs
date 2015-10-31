using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Protectores.Models
{
    public class Direccion
    {
        [Key]
        public int UsuarioID { get; set; }

        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}