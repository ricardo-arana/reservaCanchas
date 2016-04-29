using DatosRC.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReservadeCanchas.Negocio.Reserva;
using ReservadeCanchas.Negocio.Modelos;
using ReservaDeCanchas.Models;

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


            
            DateTime fecha = DateTime.Now.Date;
            
            Fechas fechas = new Fechas();
            IEnumerable<Dias> diasSemana = fechas.ObtenerSemana(fecha);
            IEnumerable<ReservaSet> reservasLista = db.ReservaSet.Where(r => r.FechaHoraAlquiler > fecha).ToList();
            var model = new CampoDetalleViewModel {campo = campoSet, semana = diasSemana, reservas = reservasLista };

            return View(model);
        }

        public PartialViewResult HorariosDetalle(DateTime fecha)
        {
            if (fecha == null)
            {
                fecha = DateTime.Now;
            }
            DateTime fecha2 = fecha.AddDays(7);
            Fechas fechas = new Fechas();
            IEnumerable<Dias> diasSemana = fechas.ObtenerSemana(fecha);
            var semana = diasSemana;
            
            //var model = db.ReservaSet.Where(p => p.FechaHoraAlquiler >= fecha && p.FechaHoraAlquiler <= fecha2);
            
            return PartialView("_HorariosDetalle", semana);
        }
    }


}