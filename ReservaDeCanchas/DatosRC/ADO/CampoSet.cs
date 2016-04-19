namespace DatosRC.ADO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CampoSet")]
    public partial class CampoSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CampoSet()
        {
            ReservaSet = new HashSet<ReservaSet>();
            FotoSet = new HashSet<FotoSet>();
        }

        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [Display(Name ="Descripción")]
        public string Descripcion { get; set; }

        public string Estado { get; set; }

        [Display(Name="Fecha de creación")]

        public DateTime Fecha_Creacion { get; set; }
        [Display(Name = "Fecha de Modificación")]

        public DateTime Fecha_Mod { get; set; }
        [Display(Name = "Tipo de campo")]
        public int Tipo_campo_Id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservaSet> ReservaSet { get; set; }

        public virtual Tipo_campoSet Tipo_campoSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FotoSet> FotoSet { get; set; }
    }
}
