using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Protectores.Models
{
    public enum Pais
    {
        Argentina,
        Uruguay
    }

    public class Adress
    {
        [Key]
        public int AdressId { get; set; }

        public double Latitud { get; set; }
        public double Longitud { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Número")]
        public string AddressNumber { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Calle")]
        public string StreetName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Ciudad")]
        public string CityName { get; set; }

        [Required]
        [Display(Name = "País")]
        public Pais CountryName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required]
        [Display(Name = "¿Es Protector?")]
        public bool EsProtector { get; set; }
    }
}