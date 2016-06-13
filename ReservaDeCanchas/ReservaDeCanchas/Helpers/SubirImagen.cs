using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ReservaDeCanchas.Helpers
{
    public class SubirImagen
    {
        private Imagen ObtenerImagen(HttpPostedFileBase image, string ruta)
        {
            if (image == null) return null;
            var stream = new MemoryStream();
            image.InputStream.CopyTo(stream);
            return new Imagen(
                stream,
                image.FileName,
                image.ContentType,
                ruta);
        }
    }
}