namespace DatosRC.ADO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReservaSet")]
    public partial class ReservaSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReservaSet()
        {
            PagoSet = new HashSet<PagoSet>();
        }

        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public string CreadoPor { get; set; }

        [Display(Name ="Fecha y hora de alquiler")]
        public DateTime FechaHoraAlquiler { get; set; }

        [Display(Name = "Monto de Alquiler")]
        public decimal MontoAlquiler { get; set; }

        [Display(Name = "Monto Pagado")]
        public decimal MontoPagado { get; set; }

        [Display(Name = "Fecha de Vencimiento")]
        public DateTime FechaHoraVencimiento { get; set; }

        [Required]
        [StringLength(128)]
        public string Usuario_Id { get; set; }

        public int Campo_Id { get; set; }

        public virtual CampoSet CampoSet { get; set; }

        public virtual UsuarioSet UsuarioSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PagoSet> PagoSet { get; set; }
    }
}
