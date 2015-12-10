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

        [Required(ErrorMessage = "Por favor, ingrese el número de su dirección")]
        [StringLength(20)]
        [Display(Name = "Número")]
        public string AddressNumber { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese la calle de su dirección")]
        [StringLength(50)]
        [Display(Name = "Calle")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese la ciudad de su dirección")]
        [StringLength(50)]
        [Display(Name = "Ciudad")]
        public string CityName { get; set; }

        [Required(ErrorMessage = "Por favor, ingrese el teléfono")]
        [StringLength(50)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Por favor, seleccione el pais de su dirección")]
        [Display(Name = "País")]
        public Country CountryName { get; set; }

        [Required]
        [Display(Name = "¿Es Protector?")]
        public bool IsProtector { get; set; }
    }
}