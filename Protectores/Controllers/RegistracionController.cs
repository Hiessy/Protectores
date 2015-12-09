using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Protectores.DAL;
using Protectores.Models;
using GoogleEntities;
using GoogleApiRequest;

namespace Protectores.Controllers
{
    public class RegistracionController : Controller
    {
        private ProtectoresContext db = new ProtectoresContext();

        // GET: Registracion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registracion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contacto contacto)
        {
            GeocodeResponse geoPosicion = GoogleConnector.MakeRequest(contacto.AddressNumber, contacto.StreetName, contacto.CityName, contacto.CountryName.ToString());
            Console.WriteLine(geoPosicion);
            contacto.Latitud = geoPosicion.results[0].geometry.location.lat;
            contacto.Longitud = geoPosicion.results[0].geometry.location.lng;

            db.Contacto.Add(contacto);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        // GET: Registracion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
            Contacto contacto = db.Contacto.Find(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            return View(contacto);
        }

        // POST: Registracion/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                GeocodeResponse geoPosicion = GoogleConnector.MakeRequest(contacto.AddressNumber, contacto.StreetName, contacto.CityName, contacto.CountryName.ToString());
                Console.WriteLine(geoPosicion);
                contacto.Latitud = geoPosicion.results[0].geometry.location.lat;
                contacto.Longitud = geoPosicion.results[0].geometry.location.lng;
                contacto.Usuario.UsuarioId = int.Parse(Session["UsuarioId"].ToString());
                contacto.UsuarioId = contacto.Usuario.UsuarioId;
                db.Entry(contacto.Usuario).State = EntityState.Modified;
                db.Entry(contacto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
