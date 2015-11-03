using System;
using Protectores.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Protectores.DAL
{
    public class ProtectoresContext : DbContext
    {
        public ProtectoresContext() : base("ProtectoresContext")
        {            
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Contacto> Direcciones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<Protectores.ViewModels.RegistracionViewModel> RegistracionViewModels { get; set; }
    }
}