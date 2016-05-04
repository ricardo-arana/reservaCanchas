using DatosRC.ADO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservadeCanchas.Negocio.Servicios
{
    public class ServicioReserva
    {
        private DatosModel db = new DatosModel();
        public bool CrearReserva(string fechaAlquilar, string hora, string fechaVencimiento, string idCampo, string userid, decimal MontoAlquiler, decimal MontoPagado)
        {
            int dia = int.Parse(fechaAlquilar.Substring(0,2));
            int mes = int.Parse(fechaAlquilar.Substring(3, 2));
            int anio = int.Parse(fechaAlquilar.Substring(6, 4));
            int horac = int.Parse(hora.Substring(0,hora.IndexOf(":")));
            DateTime FechaHoraAlquiler = new DateTime(anio,mes,dia,horac,0,0);
            DateTime FechaDeVencimiento = DateTime.ParseExact(fechaVencimiento, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            //CampoSet campo = db.CampoSet.Find(idCampo);

            ReservaSet reserva = new ReservaSet {
                CreadoPor = userid,
                Estado = "P",
                Fecha =DateTime.Now,
                FechaHoraAlquiler = FechaHoraAlquiler,
            FechaHoraVencimiento = FechaDeVencimiento,
            MontoAlquiler = MontoAlquiler,
            MontoPagado = MontoPagado,
            Campo_Id = int.Parse(idCampo),
            Usuario_Id = userid
            };
            db.ReservaSet.Add(reserva);

            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
