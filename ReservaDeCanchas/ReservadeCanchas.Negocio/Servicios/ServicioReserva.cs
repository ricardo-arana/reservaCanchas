using ReservaDeCanchas.Data.Repositorio;
using ReservaDeCanchas.Dominio;
using System;
using System.Globalization;


namespace ReservaDeCanchas.Negocio.Servicios
{
    public class ServicioReserva
    {
        private IReservaDeCanchasRepository db;

        public ServicioReserva()
        {
        }

        public ServicioReserva(IReservaDeCanchasRepository repositorio)
        {
            db = repositorio;
        }
        public bool CrearReserva(string fechaAlquilar, string hora, string fechaVencimiento, string idCampo, string userid, decimal MontoAlquiler, decimal MontoPagado)
        {
            int dia = int.Parse(fechaAlquilar.Substring(0,2));
            int mes = int.Parse(fechaAlquilar.Substring(3, 2));
            int anio = int.Parse(fechaAlquilar.Substring(6, 4));
            int horac = int.Parse(hora.Substring(0,hora.IndexOf(":")));
            DateTime FechaHoraAlquiler = new DateTime(anio,mes,dia,horac,0,0);
            DateTime FechaDeVencimiento = DateTime.ParseExact(fechaVencimiento, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

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
            db.Reservas.Add(reserva);

            try
            {
                db.Commit();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
