using Protectores.DAL;
using Protectores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;


namespace Protectores.Controllers
{
    public class LocationController : Controller
    {
        private ProtectoresContext db = new ProtectoresContext();

        // POST: /Location/GetResult
        public ActionResult GetResults(Coordenadas coords)
        {
            var messages = new List<Contacto>();

            string query = "select ContactoID,UsuarioID,Latitud,Longitud,AddressNumber,StreetName,CityName,CountryName,Telefono,IsProtector from dbo.FNT_GETDIST (" + coords.Latitud + ", " + coords.Longitud + ")";
            List<Contacto> contactos = db.Contacto.SqlQuery(query).ToList();
            messages.AddRange(contactos);

            return View(messages);
        }
    }
}