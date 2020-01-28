
namespace AliExpress.Services.Interfaces
{
    public interface IObtenedorDatosArchivo
    {
        /// <summary>
        /// Obtiene la filas contenidas en el archivo.
        /// </summary>
        /// <param name="_path">Ruta del archivo.</param>
        /// <returns>Retorna un arreglo que contiene las filas contenidad en el archivo.</returns>
        string[] LeerArchivo(string _path);
    }
}
