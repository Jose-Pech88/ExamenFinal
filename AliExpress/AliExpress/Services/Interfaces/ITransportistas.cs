using AliExpress.Data.Entities.Interfaces;
using System.Collections.Generic;

namespace AliExpress.Services.Interfaces
{
    public interface ITransportistas
    {
        List<IMediosTransportes> lstMediosTransporte { get; set; }
        string cPaqueteria { get; }
        decimal dMargenUtilidad { get; }
        bool ProcesarDTOPaqueteEnviado(IPaqueteEnviado _dtoPaqueteEnviado);
    }
}
