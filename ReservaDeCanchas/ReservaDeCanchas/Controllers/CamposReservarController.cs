
using System.Collections.Generic;
using System.Web.Mvc;
using ReservaDeCanchas.Infraestructura;
using ReservadeCanchas.Negocio;
using ReservaDeCanchas.Negocio.ViewModels;
using System.Net;
using System;

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
            IEnumerable<ReservaSet> reservasLista = db.ReservaSet.Where(r => r.FechaHoraAlquiler > fecha && r.Campo_Id == campoSet.Id).ToList();
            var model = new CampoDetalleViewModel { campo = campoSet, semana = diasSemana, reservas = reservasLista };

            return View(campoSet);
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

        //[Authorize]
        //[HttpPost]
        //public ActionResult ReservarCrear(string ifechaAlquiler, string iHora, string iFechaVencimiento, string iIdCampo)
        //{
        //    decimal montoAlquiler = 160;
        //    ServicioReserva sericioReserva = new ServicioReserva();
        //    ViewBag.ok = sericioReserva.CrearReserva(ifechaAlquiler, iHora, iFechaVencimiento, iIdCampo, User.Identity.GetUserId(),montoAlquiler,0);
        //    return View();
        //}

        //[Authorize]
        //public ActionResult MisReservas()
        //{
        //    string idUser = User.Identity.GetUserId();
        //    var Reservas = db.ReservaSet.Where(r => r.Usuario_Id == idUser);
        //    IEnumerable<ReservaSet> reservasUsuario = Reservas.ToList();
        //    return View(reservasUsuario);
        //}


        //public PartialViewResult HorariosResultado(int campoId, string FechaInicio)
        //{

        //    CampoSet campoSet = db.CampoSet.Find(campoId);

        //    Fechas fechas = new Fechas();
        //    DateTime fecha = DateTime.ParseExact(FechaInicio.Substring(0,10), "yyyy-MM-dd", CultureInfo.InvariantCulture);
        //    IEnumerable<Dias> diasSemana = fechas.ObtenerSemana(fecha);
        //    IEnumerable<ReservaSet> reservasLista = db.ReservaSet.Where(r => r.FechaHoraAlquiler > fecha && r.Campo_Id == campoSet.Id).ToList();
        //    var model = new CampoDetalleViewModel { campo = campoSet, semana = diasSemana, reservas = reservasLista };


        //    return PartialView("_HorarioDetalle", model);
        //}
    }


}