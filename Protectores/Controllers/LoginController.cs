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
        private ProtectoresContext dc = new ProtectoresContext();

        // GET: Registracion
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario u)
        {
            var v = dc.Usuarios.Where(a => a.Correo.Equals(u.Correo) && a.Password.Equals(u.Password)).FirstOrDefault();
            if (v != null)
            {
                Session["LogedUserID"] = v.Correo.ToString();
                Session["LogedUserFullname"] = v.Nombre.ToString();
                return RedirectToAction("Create", "Registracion");
            }

            return View();
        }

     }
}