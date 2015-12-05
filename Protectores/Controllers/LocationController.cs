using Protectores.DAL;
using Protectores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization.Json;


namespace Protectores.Controllers
{
    public class LocationController : Controller
    {
        private ProtectoresContext db = new ProtectoresContext();

        // GET: /Location/
        public ActionResult Index()
        {
            return View();
        }


        // POST: /Location/GetResult
        [HttpPost]
        public ActionResult GetResult(String data)
        {
            var messages = new List<Contacto>();

            int valor = data.IndexOf(':', data.IndexOf(':') + 1) + 1;

            string lat = data.Substring(5,(data.IndexOf(',')-5));
            string lon = data.Substring(valor, data.IndexOf('}') - valor); 
            string query = "select ContactoID,UsuarioID,Latitud,Longitud,AddressNumber,StreetName,CityName,CountryName,Telefono,IsProtector from dbo.FNT_GETDIST ("+lat+", "+lon+")";
            List<Contacto> contactos = db.Contacto.SqlQuery(query).ToList();
            //foreach (Contacto cont in contactos)
            //{
            //    cont.Usuario = new Usuario();
            //}
            //messages.AddRange(contactos);

            //return View(messages);
            /*        string lat = data.
                   lat:,

                    lon:}
                */
            return View();
        }
	}
}

