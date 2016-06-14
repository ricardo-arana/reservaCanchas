namespace ReservaDeCanchas.Dominio
{

    using System.Collections.Generic;


    public partial class PagoSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PagoSet()
        {
            ReservaSet = new HashSet<ReservaSet>();
        }

        public int Id { get; set; }

        public string TipoPago { get; set; }

        public string Descripcion { get; set; }

        public decimal Monto { get; set; }

        public string Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservaSet> ReservaSet { get; set; }
    }
}
