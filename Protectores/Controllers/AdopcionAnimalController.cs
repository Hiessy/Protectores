using Protectores.DAL;
using Protectores.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Protectores.Controllers
{
    public class AdopcionAnimalController : Controller
    {
        private ProtectoresContext db = new ProtectoresContext();

        // GET: AdopcionAnimal
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdopcionAnimal/List
        public ActionResult List()
        {
            return View(db.AdopcionAnimal);
        }

        // GET: AdopcionAnimal/Details/5
        public ActionResult Details(int id)
        {
            return View(db.AdopcionAnimal.Find(id));
        }

        // GET: AdopcionAnimal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdopcionAnimal/Create
        [HttpPost]
        public ActionResult Create(AdopcionAnimal adopcion)
        {
            try
            {
                int formID = int.Parse(Session["UsuarioId"].ToString());
                adopcion.Usuario = db.Usuarios.Find(formID);
                db.AdopcionAnimal.Add(adopcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdopcionAnimal/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdopcionAnimal/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AdopcionAnimal adopcion)
        {
            try
            {
                AdopcionAnimal adopcionPersist = db.AdopcionAnimal.Find(id);
                adopcionPersist.nombre = adopcion.nombre;
                adopcionPersist.especie = adopcion.especie;
                db.Entry(adopcionPersist).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdopcionAnimal/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.AdopcionAnimal.Find(id));
        }

        // POST: AdopcionAnimal/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                AdopcionAnimal adopcionAnimal = db.AdopcionAnimal.Find(id);
                db.AdopcionAnimal.Remove(adopcionAnimal);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
    }
}
