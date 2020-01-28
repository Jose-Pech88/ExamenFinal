using System.Collections.Generic;

namespace AliExpress.Services.Interfaces
{
    public interface IEnlistadorPaqueteriaDisponibles
    {
        List<ITransportistas> obtenerListadoTransportistas();
    }
}
