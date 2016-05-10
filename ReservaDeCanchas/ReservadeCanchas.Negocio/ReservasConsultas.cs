using System;
using System.Collections.Generic;
using ReservaDeCanchas.Negocio.ViewModels;
using ReservaDeCanchas.Data.Repositorio;
using ReservaDeCanchas.Dominio;
using System.Linq;

namespace ReservadeCanchas.Negocio
{
    public class ReservasConsultas
    {
        private readonly IReservaDeCanchasRepository db;

        public ReservasConsultas(IReservaDeCanchasRepository repositorio)
        {
            db = repositorio;
        }

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

        public string GetNombreUsuario(string id)
        {
            return db.Usuarios.Find(u => u.Id == id).Single().Nombre;
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
    }
}