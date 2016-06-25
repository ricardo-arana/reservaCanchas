using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservaDeCanchas.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index404()
        {
            return View();
        }

        public ActionResult Index500()
        {
            return View();
        }

        public ActionResult Index401()
        {
            return View();
        }
    }
}