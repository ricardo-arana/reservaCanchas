using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaDeCanchas.Negocio.ViewModels
{
    public class PagoViewModel
    {
        public int idReserva { get; set; }
        public string tipoPago { get; set; }
        public string descripcion { get; set; }
        public decimal monto { get; set; }
        public decimal MontoFaltante { get; set; }
    }
}
