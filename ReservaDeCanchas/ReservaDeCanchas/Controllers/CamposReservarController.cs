using DatosRC.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ReservaDeCanchas.Controllers
{
    
    public class CamposReservarController : Controller
    {
        private DatosModel db = new DatosModel();
        // GET: CamposReservar
        public ActionResult Index()
        {
            var campoSet = db.CampoSet;
            return View(campoSet.ToList());
        }

        public ActionResult Horarios(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampoSet campoSet = db.CampoSet.Find(id);
            if (campoSet == null)
            {
                return HttpNotFound();
            }
            return View(campoSet);
        }
    }


}