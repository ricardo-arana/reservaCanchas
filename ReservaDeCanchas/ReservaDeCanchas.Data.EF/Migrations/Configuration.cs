namespace ReservaDeCanchas.Data.EF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ReservaDeCanchas.Data.EF.DatosModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ReservaDeCanchas.Data.EF.DatosModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Tipo_campoSet.AddOrUpdate(
                t => t.Nombre,
                new Dominio.Tipo_campoSet { Nombre = "pequeño"},
                new Dominio.Tipo_campoSet { Nombre = "Mediano"},
                new Dominio.Tipo_campoSet { Nombre = "Grande"}
                );
            
        }
    }
}
