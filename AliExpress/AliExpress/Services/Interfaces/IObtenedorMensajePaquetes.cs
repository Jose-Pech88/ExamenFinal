using System;

namespace AliExpress.Services.Interfaces
{
    public interface IObtenedorMensajePaquetes
    {
        /// <summary>
        /// Obtiene el mensaje a mostrar.
        /// </summary>
        /// <param name="_path">Dirección física del archivo a leer.</param>
        /// <param name="_dtFechaBase">Fecha Base que servirá para comparar.</param>
        void ObtenerMensaje(string _path, DateTime _dtFechaBase);
    }
}
