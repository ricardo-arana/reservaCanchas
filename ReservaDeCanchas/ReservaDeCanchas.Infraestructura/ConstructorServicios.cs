using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservaDeCanchas.Data.EF;
using ReservaDeCanchas.Data.Repositorio.EF;
using ReservadeCanchas.Negocio;

namespace ReservaDeCanchas.Infraestructura
{
    public class ConstructorServicios
    {
        public static ReservasConsultas ReservasConsultas()
        {
            return new ReservasConsultas(new EFReservaDeCanchasRepository());
        }
    }
}
