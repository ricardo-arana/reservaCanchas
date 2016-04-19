namespace DatosRC.ADO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FotoSet")]
    public partial class FotoSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FotoSet()
        {
            CampoSet = new HashSet<CampoSet>();
        }

        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string URL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampoSet> CampoSet { get; set; }
    }
}
