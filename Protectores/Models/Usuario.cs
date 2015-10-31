﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Protectores.Models
{
    public enum Perfil {
        Basico, Protector, Adoptador, Ambos
    }
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Organizacion { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

        public string Password { get; set; }
        public string Telefono { get; set; }
        public Perfil Perfil { get; set; }
    }
}