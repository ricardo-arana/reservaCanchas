using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaDeCanchas.Negocio.ViewModels
{
    public class UsuarioViewModel
    {
    }

    public class UsuarioRegistroViewModel
    {
        [StringLength(128)]
        public string Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Documento_Tipo_Documento { get; set; }
        [Required]
        public string Documento_Nro_Documento { get; set; }

    }
}
