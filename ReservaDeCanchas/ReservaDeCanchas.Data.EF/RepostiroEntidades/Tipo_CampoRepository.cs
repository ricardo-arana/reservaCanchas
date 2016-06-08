using ReservaDeCanchas.Data.Repositorio.EF;
using ReservaDeCanchas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaDeCanchas.Data.EF.RepostiroEntidades
{
    public class Tipo_CampoRepository : GenericRepository<EFReservaDeCanchasRepository, Tipo_campoSet>
    {
        public Tipo_CampoRepository(EFReservaDeCanchasRepository contexto):base(contexto)
        {

        }
    }
}
