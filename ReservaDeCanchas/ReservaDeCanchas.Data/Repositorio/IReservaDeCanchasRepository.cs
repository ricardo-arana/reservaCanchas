using ReservaDeCanchas.Dominio;
using System;

namespace ReservaDeCanchas.Data.Repositorio
{
    public interface IReservaDeCanchasRepository : IDisposable
    {
        IGenericRepository<CampoSet> Campos { get; }
        IGenericRepository<FotoSet> Fotos { get; }
        IGenericRepository<PagoSet> Pagos { get; }
        IGenericRepository<ReservaSet> Reservas { get; }
        IGenericRepository<Tipo_campoSet> TiposDeCampo { get; }
        IGenericRepository<UsuarioSet> Usuarios { get; }

        void Commit();
    }
}