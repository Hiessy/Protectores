using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Protectores.Models
{
    public class Contacto
    {

        [Key]
        public int ContactoID { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Organizacion { get; set; }
        public string AddressNumber { get; set; }
        public string StreetName { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public string Telefono { get; set; }

    }
}