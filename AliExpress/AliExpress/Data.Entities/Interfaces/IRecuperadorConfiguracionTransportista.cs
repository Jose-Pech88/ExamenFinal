using AliExpress.Services.Interfaces;
using System.Collections.Generic;

namespace AliExpress.Data.Entities.Interfaces
{
    public interface IRecuperadorConfiguracionTransportista
    {
        List<IMediosTransportes> ObtenerConfiguracionDHL();
        List<IMediosTransportes> ObtenerConfiguracionEstafeta();
        List<IMediosTransportes> ObtenerConfiguracionFedex();

    }
}
