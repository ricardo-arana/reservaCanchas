namespace DatosRC.ADO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsuarioSet")]
    public partial class UsuarioSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UsuarioSet()
        {
            ReservaSet = new HashSet<ReservaSet>();
        }

        public string Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        [StringLength(3)]
        public string Documento_Tipo_Documento { get; set; }

        [Required]
        [StringLength(12)]
        public string Documento_Nro_Documento { get; set; }

        [Required]
        public string Datos_Adicionales { get; set; }

        public DateTime Fecha_Registro { get; set; }

        [Required]
        public string Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservaSet> ReservaSet { get; set; }
    }
}
