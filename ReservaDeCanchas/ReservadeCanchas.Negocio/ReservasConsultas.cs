using System;
using System.Collections.Generic;
using ReservaDeCanchas.Negocio.ViewModels;
using ReservaDeCanchas.Data.Repositorio;
using ReservaDeCanchas.Dominio;
using System.Linq;
using System.Globalization;

namespace ReservadeCanchas.Negocio
{
    public class ReservasConsultas
    {
        private readonly IReservaDeCanchasRepository db;

        public ReservasConsultas(IReservaDeCanchasRepository repositorio)
        {
            db = repositorio;
        }
        #region Usuarios
        public void AddUsuario(UsuarioRegistroViewModel usuarioRC)
        {
            UsuarioSet usuario = new UsuarioSet {
                Id = usuarioRC.Id,
                Nombre = usuarioRC.Nombre,
                Apellido = usuarioRC.Apellido,
                Documento_Tipo_Documento = usuarioRC.Documento_Tipo_Documento,
                Documento_Nro_Documento = usuarioRC.Documento_Nro_Documento,
                Telefono = usuarioRC.Telefono,
                Estado = "A",
                Datos_Adicionales = "Ninguno",
                Fecha_Registro = DateTime.Now
            };
            db.Usuarios.Add(usuario);
        }
        public string GetNombreUsuario(string id)
        {
            return db.Usuarios.Find(u => u.Id == id).Single().Nombre;
        }
        #endregion

        #region Campos
        public CampoReservaViewModel CampoReservaFindId(int? id)
        {
            var o = db.Campos.Find(c => c.Id == id).Single();
            return new CampoReservaViewModel
            {
                id = o.Id,
                Nombre = o.Nombre,
                Descripcion = o.Descripcion,
                TipoCampo = o.Tipo_campoSet.Nombre
            };
        }

        public IEnumerable<CampoReservaViewModel> CampoReservaListar()
        {
            return db.Campos.GetAll()
                .Select(o => new CampoReservaViewModel
                {
                    id = o.Id,
                    Nombre = o.Nombre,
                    Descripcion = o.Descripcion
                });
        }

        public IEnumerable<ReservaViewModel> ReservasPorCampo(int id, DateTime fecha)
        {
            DateTime FechaMax = fecha.AddDays(7);
            return db.Reservas.GetAll()
                .Where(r => r.Campo_Id == id && r.FechaHoraAlquiler >= fecha &&
                r.FechaHoraAlquiler <= FechaMax)
                .Select(o => new ReservaViewModel
                {
                    Estado = o.Estado
                ,
                    FechaHoraAlquiler = o.FechaHoraAlquiler,
                    MontoAlquiler = o.MontoAlquiler
                });
        }

        public CampoListViewModel CampoFindId(int? id)
        {
            var o = db.Campos.Find(c => c.Id == id).Single();
            return new CampoListViewModel
            {
                id = o.Id,
                Nombre = o.Nombre,
                Descripcion = o.Descripcion,
                Estado = o.Estado,
                Fecha_Creacion = o.Fecha_Creacion,
                Fecha_Mod = o.Fecha_Mod,
                Tipo_campoSet =
                new TipoCampoViewModel
                {
                    Id = o.Tipo_campoSet.Id,
                    Nombre = o.Tipo_campoSet.Nombre,
                    Descripcion = o.Tipo_campoSet.Descripcion
                }
            };
        }

        public IEnumerable<CampoListViewModel> CampoListar()
        {
            return db.Campos.GetAll()
                .Select(o => new CampoListViewModel {
                id = o.Id,
                Nombre = o.Nombre,
                Descripcion = o.Descripcion,
                Estado = o.Estado,
                Fecha_Creacion = o.Fecha_Creacion,
                Fecha_Mod = o.Fecha_Mod,
                Tipo_campoSet = 
                new TipoCampoViewModel {Id =o.Tipo_campoSet.Id,
                                       Nombre = o.Tipo_campoSet.Nombre,
                                       Descripcion = o.Tipo_campoSet.Descripcion} });

                
        }

        #endregion

        #region reservas
        public bool CrearReserva(string fechaAlquilar, string hora, string fechaVencimiento, string idCampo, string userid, decimal MontoAlquiler, decimal MontoPagado)
        {
            int dia = int.Parse(fechaAlquilar.Substring(0, 2));
            int mes = int.Parse(fechaAlquilar.Substring(3, 2));
            int anio = int.Parse(fechaAlquilar.Substring(6, 4));
            int horac = int.Parse(hora.Substring(0, hora.IndexOf(":")));
            DateTime FechaHoraAlquiler = new DateTime(anio, mes, dia, horac, 0, 0);
            DateTime FechaDeVencimiento = DateTime.ParseExact(fechaVencimiento, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            ReservaSet reserva = new ReservaSet
            {
                CreadoPor = userid,
                Estado = "P",
                Fecha = DateTime.Now,
                FechaHoraAlquiler = FechaHoraAlquiler,
                FechaHoraVencimiento = FechaDeVencimiento,
                MontoAlquiler = MontoAlquiler,
                MontoPagado = MontoPagado,
                Campo_Id = int.Parse(idCampo),
                Usuario_Id = userid
            };
            db.Reservas.Add(reserva);

            try
            {
                db.Commit();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<MisReservasViewModel> GetMisReservas(string idUser)
        {

            return db.Reservas.Find(r => r.Usuario_Id == idUser)
                .Select(o => new MisReservasViewModel
                {
                    NombreCampo = o.CampoSet.Nombre,
                    Estado      = o.Estado,
                    FechaHoraAlquiler = o.FechaHoraAlquiler,
                    fechaVencimiento  = o.FechaHoraVencimiento,
                    montoAlquiler     = o.MontoAlquiler,
                    montoPagado       = o.MontoPagado
                });
        }

        #endregion //Reservas
    }

}