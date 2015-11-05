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
    public class RegistracionViewModelsController : Controller
    {
        private ProtectoresContext db = new ProtectoresContext();

        // GET: RegistracionViewModels
        public ActionResult Index()
        {
            return View();
        }

        // GET: RegistracionViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        /*    RegistracionViewModel registracionViewModel = db.RegistracionViewModels.Find(id);
            if (registracionViewModel == null)
            {
                return HttpNotFound();
            }*/
            return View();
        }

        // GET: RegistracionViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistracionViewModels/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario2)
        {
            GeocodeResponse geoPosicion = GoogleConnector.MakeRequest(usuario2.Contacto.AddressNumber, usuario2.Contacto.StreetName, usuario2.Contacto.CityName, usuario2.Contacto.CountryName);
            Console.WriteLine(geoPosicion);
            usuario2.Contacto.Latitud = geoPosicion.results[0].geometry.location.lat;
            usuario2.Contacto.Longitud = geoPosicion.results[0].geometry.location.lng;
            
            db.Contacto.Add(usuario2.Contacto);
            db.Usuarios.Add(usuario2);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        // GET: RegistracionViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        /*    RegistracionViewModel registracionViewModel = db.RegistracionViewModels.Find(id);
            if (registracionViewModel == null)
            {
                return HttpNotFound();
            }*/
            return View();
        }

        // POST: RegistracionViewModels/Edit/5
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

        // GET: RegistracionViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
      /*      RegistracionViewModel registracionViewModel = db.RegistracionViewModels.Find(id);
            if (registracionViewModel == null)
            {
                return HttpNotFound();
            }*/
            return View();
        }

        // POST: RegistracionViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            /*RegistracionViewModel registracionViewModel = db.RegistracionViewModels.Find(id);
            db.RegistracionViewModels.Remove(registracionViewModel);
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
