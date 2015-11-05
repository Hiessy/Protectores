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
        public DbSet<Contacto> Contacto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
              
    }
}