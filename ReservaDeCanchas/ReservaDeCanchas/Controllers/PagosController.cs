using ReservadeCanchas.Negocio;
using ReservaDeCanchas.Infraestructura;
using ReservaDeCanchas.Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservaDeCanchas.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PagosController : Controller
    {
        private ReservasConsultas reservaConsulta;

        public PagosController()
        {
            reservaConsulta = ConstructorServicios.ReservasConsultas();
        }
        // GET: Pagos
        public ActionResult Index()
        {
            IEnumerable<PagoAdminViewModel> model = reservaConsulta.getPagos();
            return View(model);
        }

        //GET: ProcesaPago
        public ActionResult ProcesaPago(int id, string flag)
        {
            reservaConsulta.ProcesaPago(id, flag);
            return RedirectToAction("Index");
        }
    }
}