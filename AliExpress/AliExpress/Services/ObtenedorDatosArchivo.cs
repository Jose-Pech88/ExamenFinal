using AliExpress.Services.Interfaces;

namespace AliExpress.Services
{
    public class ObtenedorDatosArchivo : IObtenedorDatosArchivo
    {
        /// <summary>
        /// Obtiene la filas contenidas en el archivo.
        /// </summary>
        /// <param name="_path">Ruta del archivo.</param>
        /// <returns>Retorna un arreglo que contiene las filas contenidad en el archivo.</returns>
        public string[] LeerArchivo(string _path)
        {
            return System.IO.File.ReadAllLines(_path);
        }
    }
}
