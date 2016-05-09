namespace ReservaDeCanchas.Dominio
{
    using System.Collections.Generic;

    public partial class Tipo_campoSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tipo_campoSet()
        {
            CampoSet = new HashSet<CampoSet>();
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampoSet> CampoSet { get; set; }
    }
}
