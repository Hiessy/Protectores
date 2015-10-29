using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Protectores.Models;

namespace Protectores.DAL
{
    public class ProtectoredInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ProtectoresContext>
    {
        protected override void Seed(ProtectoresContext context)
        {
            var usuarios = new List<Usuario>
            {
                new Usuario { Nombre = "Martin", Apellido = "Diaz", Correo = "darkpig@gmail.com", Organizacion = "Martines Unidos", Password = "Tomahawk23", Perfil=Perfil.Protector, Telefono = "98438327" },
                new Usuario { Nombre = "Agustin", Apellido = "Dib", Correo = "dib@gmail.com", Organizacion = "Agustin Unidos", Password = "Tomahawk22", Perfil=Perfil.Ambos, Telefono = "45363432" },
               /* new Usuario { },
                new Usuario { },
                new Usuario { }*/
            };
            usuarios.ForEach(s => context.Usuarios.Add(s));
            context.SaveChanges();
        }
    }
}