using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Protectores.Models
{
    public class Pedido
    {
        public string CorreoID { get; set; }
        public DateTime FechaHora { get; set; }
        public double Longitud { get; set; }
        public double Latitud { get; set; }
    }
}