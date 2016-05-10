using System;

namespace ReservaDeCanchas.Negocio.ViewModels
{
    public class CampoListViewModel
    {
        public int id { get; set; }
        public virtual TipoCampoViewModel Tipo_campoSet { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public DateTime Fecha_Mod { get; set; }
        
    }

    public class CampoReservaViewModel
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string TipoCampo { get; set; }

    }
}