using ReservaDeCanchas.Data.Repositorio.EF;
using ReservaDeCanchas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaDeCanchas.Data.EF.RepostiroEntidades
{
    public class PagoRepository : GenericRepository<EFReservaDeCanchasRepository, PagoSet>
    {
        public PagoRepository(EFReservaDeCanchasRepository contexto):base(contexto)
        {

        }
    }
}
