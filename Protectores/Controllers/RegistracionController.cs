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

        // GET: Registracion
        public ActionResult Index()
        {
            return View();
        }

        // GET: Registracion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        /*    Registracion registracion = db.RegistracionViewModels.Find(id);
            if (registracion == null)
            {
                return HttpNotFound();
            }*/
            return View();
        }

        // GET: Registracion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registracion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contacto contacto)
        {
            GeocodeResponse geoPosicion = GoogleConnector.MakeRequest(contacto.AddressNumber, contacto.StreetName, contacto.CityName, contacto.CountryName);
            Console.WriteLine(geoPosicion);
            contacto.Latitud = geoPosicion.results[0].geometry.location.lat;
            contacto.Longitud = geoPosicion.results[0].geometry.location.lng;
            
 //           db.Contacto.Add(usuario2.Contacto);
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
        /*    Registracion registracion = db.Registracion.Find(id);
            if (registracion == null)
            {
                return HttpNotFound();
            }*/
            return View();
        }

        // POST: Registracion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            if (ModelState.IsValid)
            {
           /*     db.Entry().State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");*/
            }
            return View();
        }

        // GET: Registracion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
      /*      Registracion registracion = db.Registracion.Find(id);
            if (registracion == null)
            {
                return HttpNotFound();
            }*/
            return View();
        }

        // POST: Registracion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            /*Registracion registracion = db.Registracion.Find(id);
            db.Registracion.Remove(registracion);
            db.SaveChanges();*/
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public Boolean selectedPerfil() {
            return true;

        }
    }
}
