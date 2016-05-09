namespace ReservaDeCanchas.Dominio
{

    using System.Collections.Generic;


    public partial class FotoSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FotoSet()
        {
            CampoSet = new HashSet<CampoSet>();
        }

        public int Id { get; set; }

        public string Descripcion { get; set; }

        public string URL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampoSet> CampoSet { get; set; }
    }
}
