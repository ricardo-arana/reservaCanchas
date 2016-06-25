namespace ReservaDeCanchas.Migrations
{
    using Infraestructura;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Negocio.ViewModels;
    using ReservadeCanchas.Negocio;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ReservaDeCanchas.Models.ApplicationDbContext>
    {
        private ReservasConsultas reservasConsultas;
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            reservasConsultas = ConstructorServicios.ReservasConsultas();

        }

        protected override void Seed(ReservaDeCanchas.Models.ApplicationDbContext context)
        {
            var userManager =
               new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager =
                new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // Crear Roles

            roleManager.Create(new IdentityRole("Admin"));


            var user = new ApplicationUser()
            {
                UserName = "admin@pichanga.com",
                Email = "admin@pichanga.com",

            };

            userManager.Create(user, "123qQ!");
            userManager.AddToRole(user.Id, "Admin");
       

        var cliente = new ApplicationUser()
        {
            UserName = "cliente@pichanga.com",
            Email = "cliente@pichanga.com"
            
        };

        userManager.Create(cliente, "123qQ!");
            var cliente2 = new UsuarioRegistroViewModel
            {
                Id = cliente.Id,
                Nombre = "Prueba",
                Apellido = "test",
                Telefono = "234234",
                Documento_Tipo_Documento = "DNI",
                Documento_Nro_Documento = "12345678"
            };
            var crear = reservasConsultas.AddUsuario(cliente2);
        }
        //private void AddRole(ApplicationDbContext context, string role)
        //{
        //    if (!context.Roles.Any(x => x.Name == role))
        //        context.Roles.Add(new IdentityRole(role));
        //}
    }
}
