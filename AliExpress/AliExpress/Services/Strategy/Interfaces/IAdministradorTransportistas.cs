using AliExpress.Data.Entities.Interfaces;

namespace AliExpress.Services.Strategy.Interfaces
{
    public interface IAdministradorTransportistas
    {
        void LlenarDTOPaqueteEnviado(IPaqueteEnviado _dtoPaqueteEnviado);
    }
}
