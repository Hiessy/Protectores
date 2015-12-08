using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Protectores.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (HttpContext.Session["Logged"] == null)
            {
                HttpContext.Session["Logged"] = false;
            }
            return View();
        }
    }
}