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


            context.SaveChanges();
        }
    }
}