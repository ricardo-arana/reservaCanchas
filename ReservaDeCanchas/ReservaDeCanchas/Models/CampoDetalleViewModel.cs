using DatosRC.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservaDeCanchas.Models
{
    public class CampoDetalleViewModel
    {
        
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public IEnumerable<ReservaSet> Reserva { get; set; }
    }
}