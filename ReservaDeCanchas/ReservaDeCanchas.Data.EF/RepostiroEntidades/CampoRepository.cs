using ReservaDeCanchas.Data.Repositorio.EF;
using ReservaDeCanchas.Dominio;


namespace ReservaDeCanchas.Data.EF.RepostiroEntidades
{
    public class CampoRepository : GenericRepository<EFReservaDeCanchasRepository, CampoSet>
    {
        public CampoRepository(EFReservaDeCanchasRepository contexto):base(contexto)
        {

        }
    }
}
