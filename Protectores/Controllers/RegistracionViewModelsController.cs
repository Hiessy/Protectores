using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Protectores.DAL;
using Protectores.ViewModels;

namespace Protectores.Controllers
{
    public class RegistracionViewModelsController : Controller
    {
        private ProtectoresContext db = new ProtectoresContext();

        // GET: RegistracionViewModels
        public ActionResult Index()
        {
            return View(db.RegistracionViewModels.ToList());
        }

        // GET: RegistracionViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistracionViewModel registracionViewModel = db.RegistracionViewModels.Find(id);
            if (registracionViewModel == null)
            {
                return HttpNotFound();
            }
            return View(registracionViewModel);
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
        public ActionResult Create([Bind(Include = "Id")] RegistracionViewModel registracionViewModel)
        {
            if (ModelState.IsValid)
            {
                db.RegistracionViewModels.Add(registracionViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registracionViewModel);
        }

        // GET: RegistracionViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistracionViewModel registracionViewModel = db.RegistracionViewModels.Find(id);
            if (registracionViewModel == null)
            {
                return HttpNotFound();
            }
            return View(registracionViewModel);
        }

        // POST: RegistracionViewModels/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] RegistracionViewModel registracionViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registracionViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registracionViewModel);
        }

        // GET: RegistracionViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistracionViewModel registracionViewModel = db.RegistracionViewModels.Find(id);
            if (registracionViewModel == null)
            {
                return HttpNotFound();
            }
            return View(registracionViewModel);
        }

        // POST: RegistracionViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistracionViewModel registracionViewModel = db.RegistracionViewModels.Find(id);
            db.RegistracionViewModels.Remove(registracionViewModel);
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

        public Boolean selectedPerfil() {
            return true;

        }
    }
}
