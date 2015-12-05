using Protectores.DAL;
using Protectores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Protectores.Controllers
{
    public class LocationController : Controller
    {
        private ProtectoresContext db = new ProtectoresContext();

        // GET: /Location/
        public ActionResult Index()
        {
            //var messages = new List<Contacto>();
            //using (var db = new ProtectoresContext())
            {
                //string query = "select ContactoID,UsuarioID,Latitud,Longitud,Organizacion,AddressNumber,StreetName,CityName,CountryName,Telefono from dbo.FNT_GETDIST (-34.610111, - 58.428953)";
                //List<Contacto> contactos = db.Contacto.SqlQuery(query).ToList();
              /*  foreach (Contacto cont in contactos)
                {
                    cont.Usuario = new Usuario();
                }*/
                //messages.AddRange(contactos);
            }

            //return View(messages);
            return View();
        }


        // POST: /Location/GetResult
        [HttpPost]
        public ActionResult GetResult(String data)
        {
    /*        string lat = data.
           lat:,

            lon:}
        */
            return View();
        }
	}
}

