using ReservadeCanchas.Negocio;
using ReservaDeCanchas.Infraestructura;
using ReservaDeCanchas.Negocio.ViewModels;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace ReservaDeCanchas.Controllers
{
    public class CampoController : Controller
    {
        private ReservasConsultas reservasConsultas;
        
        public CampoController()
        {
            reservasConsultas = ConstructorServicios.ReservasConsultas();
        }
        // GET: Campo
        public ActionResult Index()
        {
            IEnumerable<CampoListViewModel> CampoLista = reservasConsultas.CampoListar();
            return View(CampoLista);
        }

        // GET: Campo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampoListViewModel Campo = reservasConsultas.CampoFindId(id);
            if (Campo == null)
            {
                return HttpNotFound();
            }
            return View(Campo);
        }

        // GET: Campo/Create
        //public ActionResult Create()
        //{
        //    ViewBag.Tipo_campo_Id = new SelectList(db.Tipo_campoSet, "Id", "Nombre");
        //    return View();
        //}

        //// POST: Campo/Create
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        //// más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,Estado,Fecha_Creacion,Fecha_Mod,Tipo_campo_Id")] CampoSet campoSet)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        campoSet.Fecha_Creacion = DateTime.Now;
        //        campoSet.Fecha_Mod = DateTime.Now;
        //        campoSet.Estado = "A"; //activo por default
        //        db.CampoSet.Add(campoSet);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.Tipo_campo_Id = new SelectList(db.Tipo_campoSet, "Id", "Nombre", campoSet.Tipo_campo_Id);
        //    return View(campoSet);
        //}

        //// GET: Campo/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CampoSet campoSet = db.CampoSet.Find(id);
        //    if (campoSet == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.Tipo_campo_Id = new SelectList(db.Tipo_campoSet, "Id", "Nombre", campoSet.Tipo_campo_Id);
        //    return View(campoSet);
        //}

        //// POST: Campo/Edit/5
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        //// más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Estado,Fecha_Creacion,Fecha_Mod,Tipo_campo_Id")] CampoSet campoSet)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        campoSet.Fecha_Mod = DateTime.Now;
        //        db.Entry(campoSet).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Tipo_campo_Id = new SelectList(db.Tipo_campoSet, "Id", "Nombre", campoSet.Tipo_campo_Id);
        //    return View(campoSet);
        //}

        //// GET: Campo/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CampoSet campoSet = db.CampoSet.Find(id);
        //    if (campoSet == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(campoSet);
        //}

        //// POST: Campo/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    CampoSet campoSet = db.CampoSet.Find(id);
        //    db.CampoSet.Remove(campoSet);
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
