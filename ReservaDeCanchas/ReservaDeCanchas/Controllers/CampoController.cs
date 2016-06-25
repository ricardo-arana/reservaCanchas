using ReservadeCanchas.Negocio;
using ReservaDeCanchas.Helpers;
using ReservaDeCanchas.Infraestructura;
using ReservaDeCanchas.Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace ReservaDeCanchas.Controllers
{
    [Authorize(Roles = "Admin")]
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

        //GET: Campo/Create
        public ActionResult Create()
        {
            ViewBag.Tipo_campo_Id = new SelectList(reservasConsultas.GetTiposCampo(), "Id", "Nombre");
            return View();
        }

        // POST: Campo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,Estado,Fecha_Creacion,Fecha_Mod,Tipo_campo_Id")] CampoListViewModel campoSet, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                
                //imagen
                //string ruta = Server.MapPath("~/Images/Campos");
                try
                {
                    string nombreArchivo = ""+DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + imagen.FileName;
                    GrabarImagen(imagen, nombreArchivo);

                    campoSet.Fecha_Creacion = DateTime.Now;
                    campoSet.Fecha_Mod = DateTime.Now;
                    campoSet.Estado = "A"; //activo por default
                    reservasConsultas.addCampo(campoSet, nombreArchivo);

                    
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(campoSet);
                }
                
            }

            ViewBag.Tipo_campo_Id = new SelectList(reservasConsultas.GetTiposCampo(), "Id", "Nombre", campoSet.Tipo_campoSet.Id);
            return View(campoSet);
        }

        // GET: Campo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampoListViewModel campoSet = reservasConsultas.CampoFindId(id);
            if (campoSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tipo_campo_Id = new SelectList(reservasConsultas.GetTiposCampo(), "Id", "Nombre", campoSet.Tipo_campo_Id);
            return View(campoSet);
        }

        // POST: Campo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Estado,Fecha_Creacion,Fecha_Mod,Tipo_campo_Id")] CampoListViewModel campoSet, IEnumerable<HttpPostedFileBase> imagenes)
        {
            if (ModelState.IsValid)
            {
                int i = 0;
                foreach(HttpPostedFileBase imagen in imagenes)
                {
                    string nombreArchivo = "" + DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + "" + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Second + ""+ i + imagen.FileName;
                    GrabarImagen(imagen, nombreArchivo);
                    i++;
                    reservasConsultas.AddFoto(nombreArchivo, campoSet.id);
                }
                campoSet.Fecha_Mod = DateTime.Now;
                reservasConsultas.UpdateCampo(campoSet);
                return RedirectToAction("Index");
            }
            ViewBag.Tipo_campo_Id = new SelectList(reservasConsultas.GetTiposCampo(), "Id", "Nombre", campoSet.Tipo_campo_Id);
            return View(campoSet);
        }

        // GET: Campo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampoListViewModel campoSet = reservasConsultas.CampoFindId(id);
            if (campoSet == null)
            {
                return HttpNotFound();
            }
            return View(campoSet);
        }

        // POST: Campo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CampoListViewModel campoSet = reservasConsultas.CampoFindId(id);
            reservasConsultas.DelCampo(campoSet);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private Imagen ObtenerImagen(HttpPostedFileBase image, string ruta)
        {
            if (image == null) return null;
            var stream = new MemoryStream();
            image.InputStream.CopyTo(stream);
            return new Imagen(
                stream,
                image.FileName,
                image.ContentType,
                ruta);
        }

        private void GrabarImagen(HttpPostedFileBase archivo, string nombreArchivo)
        {
            
            MemoryStream ms = new MemoryStream();
            archivo.InputStream.CopyTo(ms);
            Imagen imagen = new Imagen(ms,
                archivo.FileName,
                archivo.ContentType,
                Server.MapPath("~/Images/Campos"));
            imagen.Grabar(nombreArchivo, Server.MapPath("~/Images/Campos/thumbnails"));
        }
    }
}
