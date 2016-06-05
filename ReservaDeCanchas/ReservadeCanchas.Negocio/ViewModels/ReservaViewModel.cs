using ReservaDeCanchas.Negocio.Modelos;
using System;
using System.Collections.Generic;

namespace ReservaDeCanchas.Negocio.ViewModels
{
    public class ReservaViewModel
    {
        public string Estado { get; set; }
        public DateTime FechaHoraAlquiler { get; set; }
        public decimal MontoAlquiler { get; set; }
    }

    public class HorarioViewModel
    {
        public int idCampo { get; set; }
        public IEnumerable<Dias> semana { get; set; }
        public IEnumerable<ReservaViewModel> Reservas { get; set; }

    }

    public class MisReservasViewModel
    {
        public int idReserva { get; set; }
        public string NombreCampo { get; set; }
        public string Estado { get; set; }
        public DateTime FechaHoraAlquiler { get; set; }
        public decimal montoAlquiler { get; set; }
        public decimal montoPagado { get; set; }
        public DateTime fechaVencimiento { get; set; }

    }
}
