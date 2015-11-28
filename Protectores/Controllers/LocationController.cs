using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Protectores.Controllers
{
    public class LocationController : Controller
    {
        //
        // GET: /Location/
        public ActionResult Index()
        {

            return View();
        }

        // POST: /Location/GetResult
        [HttpPost]
        public ActionResult GetResult(String data)
        {
    /*        string lat = data.
           lat:,

            lon:}
        */
            return View();
        }
	}
}
