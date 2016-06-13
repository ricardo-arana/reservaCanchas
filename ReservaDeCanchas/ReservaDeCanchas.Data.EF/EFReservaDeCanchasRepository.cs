using System;
using System.Data.Entity;
using ReservaDeCanchas.Dominio;
using ReservaDeCanchas.Data.EF.RepostiroEntidades;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ReservaDeCanchas.Data.Repositorio.EF
{
    public class EFReservaDeCanchasRepository : DbContext, IReservaDeCanchasRepository
    {
   
        private readonly IGenericRepository<CampoSet> _campos;
        private readonly IGenericRepository<ReservaSet> _reservas;
        private readonly IGenericRepository<UsuarioSet> _usuarios;
        private readonly IGenericRepository<PagoSet> _pagos;
        private readonly IGenericRepository<Tipo_campoSet> _tipoCampos;
        private readonly IGenericRepository<FotoSet> _fotos;

        public EFReservaDeCanchasRepository()
            : base("name=DatosModelDB")
        {

            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            _campos = new CampoRepository(this);
            _reservas = new ReservaRepository(this);
            _usuarios = new UsuarioRepository(this);
            _pagos = new PagoRepository(this);
            _tipoCampos = new Tipo_CampoRepository(this);
            _fotos = new FotoRepository(this);
        }
        #region metodos de entity framework
        public virtual DbSet<CampoSet> CampoSet { get; set; }
        public virtual DbSet<FotoSet> FotoSet { get; set; }
        public virtual DbSet<PagoSet> PagoSet { get; set; }
        public virtual DbSet<ReservaSet> ReservaSet { get; set; }
        public virtual DbSet<Tipo_campoSet> Tipo_campoSet { get; set; }
        public virtual DbSet<UsuarioSet> UsuarioSet { get; set; }
        #endregion



        public IGenericRepository<CampoSet> Campos
        {
            get
            {
                return _campos;
            }
        }

        public IGenericRepository<FotoSet> Fotos
        {
            get
            {
                return _fotos;
            }
        }

        public IGenericRepository<PagoSet> Pagos
        {
            get
            {
                return _pagos;
            }
        }

        public IGenericRepository<ReservaSet> Reservas
        {
            get
            {
                return _reservas;
            }
        }

        public IGenericRepository<Tipo_campoSet> TiposDeCampo
        {
            get
            {
                return _tipoCampos;
            }
        }

        public IGenericRepository<UsuarioSet> Usuarios
        {
            get
            {
                return _usuarios;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<CampoSet>()
               .HasMany(e => e.ReservaSet)
               .WithRequired(e => e.CampoSet)
               .HasForeignKey(e => e.Campo_Id)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<CampoSet>()
               .HasMany(e => e.FotoSet)
               .WithRequired(e => e.CampoSet)
               .HasForeignKey(e => e.Campo_Id)
               .WillCascadeOnDelete(false);

            //modelBuilder.Entity<CampoSet>()
            //    .HasMany(e => e.FotoSet)
            //    .WithMany(e => e.CampoSet)
            //    .Map(m => m.ToTable("FotoCampo").MapLeftKey("Campo_Id").MapRightKey("Foto_Id"));

            modelBuilder.Entity<PagoSet>()
                .Property(e => e.Monto)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PagoSet>()
                .HasMany(e => e.ReservaSet)
                .WithMany(e => e.PagoSet)
                .Map(m => m.ToTable("PagoReserva").MapLeftKey("Pago_Id").MapRightKey("Reserva_Id"));

            modelBuilder.Entity<ReservaSet>()
                .Property(e => e.MontoAlquiler)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ReservaSet>()
                .Property(e => e.MontoPagado)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Tipo_campoSet>()
                .HasMany(e => e.CampoSet)
                .WithRequired(e => e.Tipo_campoSet)
                .HasForeignKey(e => e.Tipo_campo_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UsuarioSet>()
                .HasMany(e => e.ReservaSet)
                .WithRequired(e => e.UsuarioSet)
                .HasForeignKey(e => e.Usuario_Id)
                .WillCascadeOnDelete(false);
        }

    #region IUnitOfWork Implementation



    public void Commit()
        {
            this.SaveChanges();
        }

        #endregion

    }
}