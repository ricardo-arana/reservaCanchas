namespace ReservaDeCanchas.Dominio
{
    using System;
    using System.Collections.Generic;

    public partial class CampoSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CampoSet()
        {
            ReservaSet = new HashSet<ReservaSet>();
            FotoSet = new HashSet<FotoSet>();
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Estado { get; set; }

        public DateTime Fecha_Creacion { get; set; }

        public DateTime Fecha_Mod { get; set; }
        public int Tipo_campo_Id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservaSet> ReservaSet { get; set; }

        public virtual Tipo_campoSet Tipo_campoSet { get; set; }

        public virtual ICollection<FotoSet> FotoSet { get; set; }
    }
}
