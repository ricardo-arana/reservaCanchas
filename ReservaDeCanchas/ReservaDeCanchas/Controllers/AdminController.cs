using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservaDeCanchas.Controllers
{
    
    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
        // GET: Admin/TipoCancha
        [Authorize(Roles = "Admin")]
        public ActionResult TipoCancha()
        {
            return View();
        }
    }
}