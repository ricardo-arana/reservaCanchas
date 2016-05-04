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
using Microsoft.AspNet.Identity;
using ReservadeCanchas.Negocio.Servicios;

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
            IEnumerable<ReservaSet> reservasLista = db.ReservaSet.Where(r => r.FechaHoraAlquiler > fecha && r.Campo_Id == campoSet.Id).ToList();
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

        [Authorize]
        public ActionResult Reservar(ReservaSet reserva)
        {
            reserva.Fecha = DateTime.Now;
            reserva.FechaHoraVencimiento = DateTime.Now.AddDays(1);
            reserva.Estado = "P";
            reserva.CreadoPor = User.Identity.Name;
            reserva.UsuarioSet = db.UsuarioSet.Find(User.Identity.GetUserId());
            reserva.CampoSet = db.CampoSet.Find(reserva.Campo_Id);
            
            return View(reserva);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ReservarCrear(string ifechaAlquiler, string iHora, string iFechaVencimiento, string iIdCampo)
        {
            decimal montoAlquiler = 160;
            ServicioReserva sericioReserva = new ServicioReserva();
            ViewBag.ok = sericioReserva.CrearReserva(ifechaAlquiler, iHora, iFechaVencimiento, iIdCampo, User.Identity.GetUserId(),montoAlquiler,0);
                
            
            
            return View();
        }
    }


}