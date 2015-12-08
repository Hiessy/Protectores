using Protectores.DAL;
using Protectores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Protectores.Controllers
{
    public class LoginController : Controller
    {
        private ProtectoresContext db = new ProtectoresContext();

        // GET: Registracion
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario u)
        {
            Usuario v = db.Usuarios.Where(a => a.Correo.Equals(u.Correo) && a.Password.Equals(u.Password)).FirstOrDefault();
            if (v != null)
            {
                HttpContext.Session["Logged"] = true;
                Session["UsuarioId"] = v.UsuarioId;
                Session["Nombre"] = v.Nombre.ToString();
                return RedirectToAction("Edit/" + v.UsuarioId, "Registracion");
            }
            return View();
        }
    }
}