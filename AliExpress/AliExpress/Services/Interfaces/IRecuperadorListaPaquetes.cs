using AliExpress.Data.Entities.Interfaces;
using System.Collections.Generic;

namespace AliExpress.Services.Interfaces
{
    /// <summary>
    /// Crea una lista de objetos EventoDTO con las información contenida en el archivo cuya ubicación es enviada como parámetro.
    /// </summary>
    /// <param name="_path">Ruta del archivo a procesar.</param>
    /// <returns>Retorna una lista de objetos de tipo EventoDTO.</returns>
    public interface IRecuperadorListaPaquetes
    {
        List<IPaqueteEnviado> RecuperarListaPaquetes(string _path);
    }
}
