namespace ReservaDeCanchas.Dominio
{
    using System;
    using System.Collections.Generic;

    public partial class UsuarioSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UsuarioSet()
        {
            ReservaSet = new HashSet<ReservaSet>();
        }

        public string Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Telefono { get; set; }

        public string Documento_Tipo_Documento { get; set; }

        public string Documento_Nro_Documento { get; set; }

        public string Datos_Adicionales { get; set; }

        public DateTime Fecha_Registro { get; set; }

        public string Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservaSet> ReservaSet { get; set; }
    }
}
