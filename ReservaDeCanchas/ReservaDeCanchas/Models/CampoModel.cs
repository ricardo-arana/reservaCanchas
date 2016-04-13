using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ReservaDeCanchas.Models
{

    public class CampoConext : DbContext
    {
        public DbSet<TipoCampo> TipoCampo { get; set; }

    }
    public class Campo
    {
    }


    public class TipoCampo
    {
        string descripcion { get; set; }
    }
}