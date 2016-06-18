using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaDeCanchas.Negocio.ViewModels
{
    public class PagoViewModel
    {
        public int idReserva { get; set; }
        public string tipoPago { get; set; }
        [DataType(DataType.MultilineText)]
        public string descripcion { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public decimal monto { get; set; }
        public decimal MontoFaltante { get; set; }
        public string Estado { get; set; }
    }

    public class PagoDetalleViewModel
    {
        public int PagoId { get; set; }
        public string TipoPago { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public string Estado { get; set; }
    }

    public class PagoAdminViewModel
    {
        public int PagoId { get; set; }
        public string TipoPago { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public string Estado { get; set; }
        public int ReservaId { get; set; }
        public string NombreCampo { get; set; }
    }

}
