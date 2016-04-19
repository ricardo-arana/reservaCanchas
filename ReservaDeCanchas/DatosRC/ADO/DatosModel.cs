namespace DatosRC.ADO
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatosModel : DbContext
    {
        public DatosModel()
            : base("name=DatosModelDB")
        {
        }

        public virtual DbSet<CampoSet> CampoSet { get; set; }
        public virtual DbSet<FotoSet> FotoSet { get; set; }
        public virtual DbSet<PagoSet> PagoSet { get; set; }
        public virtual DbSet<ReservaSet> ReservaSet { get; set; }
        public virtual DbSet<Tipo_campoSet> Tipo_campoSet { get; set; }
        public virtual DbSet<UsuarioSet> UsuarioSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CampoSet>()
                .HasMany(e => e.ReservaSet)
                .WithRequired(e => e.CampoSet)
                .HasForeignKey(e => e.Campo_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CampoSet>()
                .HasMany(e => e.FotoSet)
                .WithMany(e => e.CampoSet)
                .Map(m => m.ToTable("FotoCampo").MapLeftKey("Campo_Id").MapRightKey("Foto_Id"));

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
    }
}
