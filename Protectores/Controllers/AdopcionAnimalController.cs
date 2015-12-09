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
    }
}
