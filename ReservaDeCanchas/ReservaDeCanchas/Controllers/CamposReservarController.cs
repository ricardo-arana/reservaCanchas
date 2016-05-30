
using System.Collections.Generic;
using System.Web.Mvc;
using ReservaDeCanchas.Infraestructura;
using ReservadeCanchas.Negocio;
using ReservaDeCanchas.Negocio.ViewModels;
using System.Net;
using System;
using ReservaDeCanchas.Negocio.Reserva;
using ReservaDeCanchas.Negocio.Modelos;
using System.Globalization;
using ReservaDeCanchas.Negocio.Servicios;
using Microsoft.AspNet.Identity;

namespace ReservaDeCanchas.Controllers
{
    
    public class CamposReservarController : Controller
    {
        private ReservasConsultas reservasConsultas;

        public CamposReservarController()
        {
            reservasConsultas = ConstructorServicios.ReservasConsultas();
        }
        // GET: CamposReservar
        public ActionResult Index()
        {
            IEnumerable<CampoReservaViewModel> campos = reservasConsultas.CampoReservaListar();
            return View(campos);
        }

        public ActionResult Horarios(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampoReservaViewModel campoSet = reservasConsultas.CampoReservaFindId(id);
            if (campoSet == null)
            {
                return HttpNotFound();
            }
            
            DateTime fecha = DateTime.Now.Date;

            Fechas fechas = new Fechas();
            IEnumerable<Dias> diasSemana = fechas.ObtenerSemana(fecha);
            CampoReservaHorariosViewModel model = new CampoReservaHorariosViewModel
            {
                id = campoSet.id,
                Nombre = campoSet.Nombre,
                Descripcion = campoSet.Descripcion,
                Semana = diasSemana,
                TipoCampo = campoSet.TipoCampo,
                Reservas = reservasConsultas.ReservasPorCampo(campoSet.id, fecha)
            };
            

            return View(model);
        }

        ////public PartialViewResult HorariosDetalle(DateTime fecha)
        ////{
        ////    if (fecha == null)
        ////    {
        ////        fecha = DateTime.Now;
        ////    }
        ////    DateTime fecha2 = fecha.AddDays(7);
        ////    Fechas fechas = new Fechas();
        ////    IEnumerable<Dias> diasSemana = fechas.ObtenerSemana(fecha);
        ////    var semana = diasSemana;

        ////    //var model = db.ReservaSet.Where(p => p.FechaHoraAlquiler >= fecha && p.FechaHoraAlquiler <= fecha2);

        ////    return PartialView("_HorariosDetalle", semana);
        ////}

        //[Authorize]
        //public ActionResult Reservar(ReservaSet reserva)
        //{
        //    reserva.Fecha = DateTime.Now;
        //    reserva.FechaHoraVencimiento = DateTime.Now.AddDays(1);
        //    reserva.Estado = "P";
        //    reserva.CreadoPor = User.Identity.Name;
        //    reserva.UsuarioSet = db.UsuarioSet.Find(User.Identity.GetUserId());
        //    reserva.CampoSet = db.CampoSet.Find(reserva.Campo_Id);

        //    return View(reserva);
        //}

        [Authorize]
        [HttpPost]
        public ActionResult ReservarCrear(string ifechaAlquiler, string iHora, string iFechaVencimiento, string iIdCampo)
        {
            decimal montoAlquiler = 160;
           
            ViewBag.ok = reservasConsultas.CrearReserva(ifechaAlquiler, iHora, iFechaVencimiento, iIdCampo, User.Identity.GetUserId(), montoAlquiler, 0);
            return View();
        }

        [Authorize]
        public ActionResult MisReservas()
        {
            string idUser = User.Identity.GetUserId();
            var reservasUsuario = reservasConsultas.GetMisReservas(idUser);
            return View(reservasUsuario);
        }


        public PartialViewResult HorariosResultado(int campoId, string FechaInicio)
        {
            Fechas fechas = new Fechas();
            DateTime fecha = DateTime.ParseExact(FechaInicio.Substring(0, 10), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            IEnumerable<Dias> diasSemana = fechas.ObtenerSemana(fecha);

            var model = new HorarioViewModel {idCampo = campoId,
                semana = diasSemana,
                Reservas = reservasConsultas.ReservasPorCampo(campoId, fecha)
            };


            return PartialView("_HorarioDetalle", model);
        }

        public ActionResult AgregarPago(int id)
        {
            
            return View();
        }
    }


}