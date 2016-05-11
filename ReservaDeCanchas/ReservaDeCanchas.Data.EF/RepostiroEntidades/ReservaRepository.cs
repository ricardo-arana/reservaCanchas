using ReservaDeCanchas.Data.Repositorio.EF;
using ReservaDeCanchas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaDeCanchas.Data.EF.RepostiroEntidades
{
    public class ReservaRepository : GenericRepository<EFReservaDeCanchasRepository, ReservaSet>
    {
        public ReservaRepository(EFReservaDeCanchasRepository contexto) :base(contexto)
        {

        }
    }
}
