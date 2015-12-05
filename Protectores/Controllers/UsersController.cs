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
    public class UsersController : Controller
    {
        private ProtectoresContext db = new ProtectoresContext();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Adress);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.AdressId = new SelectList(db.Adresses, "AdressId", "AddressNumber");
            return View();
        }

        // POST: Users/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,AdressId,Nombre,Apellido,Correo,Password")] User user, Adress adress)
        {
            if (ModelState.IsValid)
            {
                // Meter la lógica para que carge la latitud y la longitud
                string pais = adress.CountryName.ToString();

                GeocodeResponse geoPosicion = GoogleConnector.MakeRequest(adress.AddressNumber, adress.StreetName, adress.CityName, pais);
                Console.WriteLine(geoPosicion);
                adress.Latitud = geoPosicion.results[0].geometry.location.lat;
                adress.Longitud = geoPosicion.results[0].geometry.location.lng;

                user.Adress = adress;

                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Fijarnos que hace si el modelo no es válido
            ViewBag.AdressId = new SelectList(db.Adresses, "AdressId", "AddressNumber", user.AdressId);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdressId = new SelectList(db.Adresses, "AdressId", "AddressNumber", user.AdressId);
            return View(user);
        }

        // POST: Users/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,AdressId,Nombre,Apellido,Correo,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdressId = new SelectList(db.Adresses, "AdressId", "AddressNumber", user.AdressId);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
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
    }
}
