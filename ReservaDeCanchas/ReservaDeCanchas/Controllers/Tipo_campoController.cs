using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatosRC.ADO;

namespace ReservaDeCanchas.Controllers
{
    public class Tipo_campoController : Controller
    {
        private DatosModel db = new DatosModel();

        // GET: Tipo_campo
        public ActionResult Index()
        {
            return View(db.Tipo_campoSet.ToList());
        }

        // GET: Tipo_campo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_campoSet tipo_campoSet = db.Tipo_campoSet.Find(id);
            if (tipo_campoSet == null)
            {
                return HttpNotFound();
            }
            return View(tipo_campoSet);
        }

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
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion")] Tipo_campoSet tipo_campoSet)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_campoSet.Add(tipo_campoSet);
                db.SaveChanges();
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
            Tipo_campoSet tipo_campoSet = db.Tipo_campoSet.Find(id);
            if (tipo_campoSet == null)
            {
                return HttpNotFound();
            }
            return View(tipo_campoSet);
        }

        // POST: Tipo_campo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion")] Tipo_campoSet tipo_campoSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_campoSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_campoSet);
        }

        // GET: Tipo_campo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_campoSet tipo_campoSet = db.Tipo_campoSet.Find(id);
            if (tipo_campoSet == null)
            {
                return HttpNotFound();
            }
            return View(tipo_campoSet);
        }

        // POST: Tipo_campo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_campoSet tipo_campoSet = db.Tipo_campoSet.Find(id);
            db.Tipo_campoSet.Remove(tipo_campoSet);
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
    }
}
