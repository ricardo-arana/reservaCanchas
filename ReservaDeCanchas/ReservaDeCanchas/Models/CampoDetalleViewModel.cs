
using ReservaDeCanchas.Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservaDeCanchas.Web.Models
{
    public class CampoDetalleViewModel
    {
        
       
       // public CampoSet campo { get; set; }

        public IEnumerable<Dias> semana { get; set; }

      //  public IEnumerable<ReservaSet> reservas { get; set; }
    }
}