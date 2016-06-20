using System;
using System.Collections.Generic;
using ReservaDeCanchas.Negocio.ViewModels;
using ReservaDeCanchas.Data.Repositorio;
using ReservaDeCanchas.Dominio;
using System.Linq;
using System.Globalization;
using System.Collections;
using System.Threading.Tasks;

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
        public async Task<bool> AddUsuario(UsuarioRegistroViewModel usuarioRC)
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
                TipoCampo = o.Tipo_campoSet.Nombre,
                imagen = o.FotoSet.Where(f => f.Principal ==true).Select(f => f.URL).FirstOrDefault(),
                imagenes = o.FotoSet.Where(f => f.Principal == false).Select(f => f.URL)
            };
        }

        public IEnumerable<CampoReservaViewModel> CampoReservaListar()
        {
            return db.Campos.GetAll()
                .Select(o => new CampoReservaViewModel
                {
                    id = o.Id,
                    Nombre = o.Nombre,
                    Descripcion = o.Descripcion,
                    TipoCampo = o.Tipo_campoSet.Nombre,
                    imagen = o.FotoSet.Where(f => f.Principal == true).Select(f => f.URL).FirstOrDefault()
                });
        }

        public void addCampo(CampoListViewModel campoSet, string imagen)
        {
            List<FotoSet> fotos = new List<FotoSet>();
            FotoSet foto = new FotoSet
            {
                Principal = true,
                Descripcion = campoSet.Nombre,
                URL = imagen
            };

            fotos.Add(foto);
            CampoSet campo = new CampoSet{
                Id = campoSet.id,
                Nombre = campoSet.Nombre,
                Descripcion = campoSet.Descripcion,
                Estado = campoSet.Estado,
                Fecha_Creacion = campoSet.Fecha_Creacion,
                Fecha_Mod = campoSet.Fecha_Mod,
                Tipo_campo_Id = campoSet.Tipo_campo_Id,
                FotoSet = fotos
            };
            db.Campos.Add(campo);
            
            db.Commit();
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

        public void UpdateCampo(CampoListViewModel campoSet)
        {
            CampoSet campo = new CampoSet {
                Id = campoSet.id,
                Nombre = campoSet.Nombre,
                Descripcion = campoSet.Descripcion,
                Estado = campoSet.Estado,
                Fecha_Creacion = campoSet.Fecha_Creacion,
                Fecha_Mod = campoSet.Fecha_Mod,
                Tipo_campo_Id = campoSet.Tipo_campo_Id
            };
            db.Campos.Update(campo);
            db.Commit();
        }

        public void AddFoto(string nombreArchivo, int id)
        {
            FotoSet foto = new FotoSet {
                Campo_Id = id,
                Descripcion = nombreArchivo,
                URL = nombreArchivo,
                Principal = false
            };
            db.Fotos.Add(foto);
            db.Commit();
        }

        public void DelCampo(CampoListViewModel campoSet)
        {
            CampoSet campo = new CampoSet
            {
                Id = campoSet.id,
                Nombre = campoSet.Nombre,
                Descripcion = campoSet.Descripcion,
                Estado = campoSet.Estado,
                Fecha_Creacion = campoSet.Fecha_Creacion,
                Fecha_Mod = campoSet.Fecha_Mod,
                Tipo_campo_Id = campoSet.Tipo_campo_Id
            };
            db.Campos.Delete(campo);
            db.Commit();
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

            return db.Reservas.Find(r => r.Usuario_Id == idUser && r.FechaHoraAlquiler >= DateTime.Today)
                .Select(o => new MisReservasViewModel
                {
                    idReserva = o.Id,
                    NombreCampo = o.CampoSet.Nombre,
                    Estado      = o.Estado,
                    FechaHoraAlquiler = o.FechaHoraAlquiler,
                    fechaVencimiento  = o.FechaHoraVencimiento,
                    montoAlquiler     = o.MontoAlquiler,
                    montoPagado       = o.MontoPagado,
                    Pagos              = o.PagoSet.Select(p => new PagoDetalleViewModel {
                        PagoId = p.Id,
                        Descripcion = p.Descripcion,
                        Estado = p.Estado,
                        Monto = p.Monto,
                        TipoPago = p.TipoPago
                    })
                    
                });
        }

        #endregion //Reservas

        #region Pagos
        public PagoViewModel GetMontoFaltante(int id)
        {
            ReservaSet reserva = db.Reservas.Find(p => p.Id == id).Single();
            decimal pago = reserva.MontoPagado;

            PagoViewModel pagomodel = new PagoViewModel
            {
                idReserva = id,
                MontoFaltante = 160 - pago
            };
            return pagomodel;
        }

        public bool AddPay(PagoViewModel model)
        {
            ICollection<ReservaSet> reserva = db.Reservas
                .Find(r => r.Id == model.idReserva)
                .ToList();
            PagoSet pago = new PagoSet {
                Descripcion = model.descripcion,
                Monto = model.monto,
                TipoPago = model.tipoPago,
                ReservaSet = reserva,
                Estado = model.Estado
            };

            db.Pagos.Add(pago);
            
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
        public IEnumerable<PagoAdminViewModel> getPagos()
        {
            return db.Pagos.GetAll().Select(t => new PagoAdminViewModel
            {
                PagoId = t.Id,
                Descripcion = t.Descripcion,
                Estado = t.Estado,
                Monto = t.Monto,
                TipoPago = t.TipoPago,
                NombreCampo = t.ReservaSet.FirstOrDefault().CampoSet.Nombre,
                ReservaId = t.ReservaSet.FirstOrDefault().Id
            });
        }

        public void ProcesaPago(int id, string flag)
        {
            PagoSet pago = db.Pagos.Find(p => p.Id == id).FirstOrDefault();
            switch (flag)
            {
                case "ok":
                    pago.Estado = "A";
                    pago.ReservaSet.SingleOrDefault().MontoPagado += pago.Monto;
                    if (pago.ReservaSet.SingleOrDefault().MontoPagado >= pago.ReservaSet.SingleOrDefault().MontoAlquiler / 2)
                    {
                        pago.ReservaSet.SingleOrDefault().Estado = "R";
                        pago.ReservaSet.SingleOrDefault().FechaHoraVencimiento = pago.ReservaSet.SingleOrDefault().FechaHoraAlquiler;

                    }
                    break;
                case "not":
                    pago.Estado = "R";
                    
                    break;
            }
            db.Pagos.Update(pago);
            db.Commit();
        }
        #endregion

        #region Tipo_Campo
        public IEnumerable<TipoCampoViewModel> GetTiposCampo()
        {
            return db.TiposDeCampo.GetAll()
                .Select(t => new TipoCampoViewModel {
                    Id = t.Id,
                    Nombre = t.Nombre,
                    Descripcion = t.Descripcion
                });
        }
        public void addTipoCampo(TipoCampoViewModel tipo_campoSet)
        {
            Tipo_campoSet tipoCampo = new Tipo_campoSet {
                Id = tipo_campoSet.Id,
                Nombre = tipo_campoSet.Nombre,
                Descripcion = tipo_campoSet.Descripcion
            };
            db.TiposDeCampo.Add(tipoCampo);
            db.Commit();
        }

        public TipoCampoViewModel GetTiposCampoId(int? id)
        {
            return db.TiposDeCampo.Find(o => o.Id == id)
                .Select(t => new TipoCampoViewModel {
                    Id = t.Id,
                    Nombre = t.Nombre,
                    Descripcion = t.Descripcion
                }).Single();
        }

        public void UpdateTipoCampo(TipoCampoViewModel tipo_campo)
        {
            Tipo_campoSet tipoCampo = new Tipo_campoSet
            {
                Id = tipo_campo.Id,
                Nombre = tipo_campo.Nombre,
                Descripcion = tipo_campo.Descripcion
            };
            db.TiposDeCampo.Update(tipoCampo);
            db.Commit();
        }
        #endregion
    }

}