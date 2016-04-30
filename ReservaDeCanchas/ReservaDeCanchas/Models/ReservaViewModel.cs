using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservaDeCanchas.Models
{
    public class ReservaViewModel
    {
        public DateTime FechaHoraAlquiler { get; set; }
        public Decimal montoAlquier { get; set; }
        public Decimal montoPagado { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int campoId { get; set; }
    }
}