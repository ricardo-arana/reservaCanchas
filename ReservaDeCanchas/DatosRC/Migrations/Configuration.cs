namespace DatosRC.Migrations
{
    using ADO;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DatosRC.ADO.DatosModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DatosRC.ADO.DatosModel context)
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

            var campo1 = new CampoSet {
                Nombre = "Chino Vazques",
                Descripcion = "Campo que cuenta con todas las comidades",
                Estado = "A",
                Fecha_Creacion = DateTime.Now,
                Fecha_Mod   = DateTime.Now,
                Tipo_campoSet = new Tipo_campoSet {
                            Nombre = "Mediano",
                            Descripcion = "Campo para futbol 7"}
            };

            var campo2 = new CampoSet
            {
                Nombre = "La bombonera",
                Descripcion = "Campo que cuenta con camerinos y duchas",
                Estado = "A",
                Fecha_Creacion = DateTime.Now,
                Fecha_Mod = DateTime.Now,
                Tipo_campoSet = new Tipo_campoSet
                {
                    Nombre = "Grande",
                    Descripcion = "Campo para futbol 7"
                }
            };

            context.CampoSet.Add(campo1);
            context.CampoSet.Add(campo2);
            context.SaveChanges();


        }
    }
}
