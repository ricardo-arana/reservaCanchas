namespace DatosRC.ADO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PagoSet")]
    public partial class PagoSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PagoSet()
        {
            ReservaSet = new HashSet<ReservaSet>();
        }

        public int Id { get; set; }

        [Required]
        public string TipoPago { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public decimal Monto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservaSet> ReservaSet { get; set; }
    }
}
