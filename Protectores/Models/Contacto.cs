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
        public int ContactoId { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public double Latitud { get; set; }
        public double Longitud { get; set; }

        [StringLength(50)]
        [Display(Name = "Organización")]
        public string Organizacion { get; set; }

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
        [StringLength(50)]
        [Display(Name = "País")]
        public string CountryName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
    }
}