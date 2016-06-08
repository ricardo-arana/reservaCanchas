using ReservadeCanchas.Negocio;
using ReservaDeCanchas.Infraestructura;
using ReservaDeCanchas.Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ReservaDeCanchas.Controllers
{
    public class Tipo_campoController : Controller
    {
        //private DatosModel db = new DatosModel();
        private ReservasConsultas reservasConsultas;

        public Tipo_campoController()
        {
            reservasConsultas = ConstructorServicios.ReservasConsultas();
        }
        // GET: Tipo_campo
        [Authorize]
        public ActionResult Index()
        {
            return View(reservasConsultas.GetTiposCampo());
        }

        //// GET: Tipo_campo/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Tipo_campoSet tipo_campoSet = db.Tipo_campoSet.Find(id);
        //    if (tipo_campoSet == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tipo_campoSet);
        //}

        // GET: Tipo_campo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_campo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion")] TipoCampoViewModel tipo_campoSet)
        {
            if (ModelState.IsValid)
            {
                reservasConsultas.addTipoCampo(tipo_campoSet);
                return RedirectToAction("Index");
            }

            return View(tipo_campoSet);
        }

        // GET: Tipo_campo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCampoViewModel tipo_campo = reservasConsultas.GetTiposCampoId(id);
            if (tipo_campo == null)
            {
                return HttpNotFound();
            }
            return View(tipo_campo);
        }

        // POST: Tipo_campo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion")] TipoCampoViewModel tipo_campo)
        {
            if (ModelState.IsValid)
            {
                reservasConsultas.UpdateTipoCampo(tipo_campo);
                return RedirectToAction("Index");
            }
            return View(tipo_campo);
        }

        //// GET: Tipo_campo/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Tipo_campoSet tipo_campoSet = db.Tipo_campoSet.Find(id);
        //    if (tipo_campoSet == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tipo_campoSet);
        //}

        //// POST: Tipo_campo/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Tipo_campoSet tipo_campoSet = db.Tipo_campoSet.Find(id);
        //    db.Tipo_campoSet.Remove(tipo_campoSet);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
