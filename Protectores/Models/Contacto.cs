using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Protectores.Models
{
    public enum Country
    {
        Argentina,
        Uruguay
    }
    public class Contacto
    {

        [Key]
        public int ContactoId { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

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
        [StringLength(50)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required]
        [Display(Name = "País")]
        public Country CountryName { get; set; }

        [Required]
        [Display(Name = "¿Es Protector?")]
        public bool IsProtector { get; set; }
    }
}