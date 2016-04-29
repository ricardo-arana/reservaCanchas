using ReservadeCanchas.Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservadeCanchas.Negocio.Reserva
{
    public class Fechas
    {
        public IEnumerable<Dias> ObtenerSemana(DateTime dia)
        {
            List<Dias> lista = new List<Dias>();
            string diaTexto = dia.ToString("dddd")+" "+dia.Day;

            lista.Add(new Dias { textoDia = diaTexto, fecha = dia });

            for (int i = 1; i < 7; i++)
            {
                dia = dia.AddDays(1);
                diaTexto = dia.ToString("dddd") + " " + dia.Day;
                lista.Add(new Dias { textoDia = diaTexto, fecha = dia });
            }
            return lista;
        }
    }
}
