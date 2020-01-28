using AliExpress.Data.Entities.Interfaces;

namespace AliExpress.Services.Interfaces
{
    public interface IObtenedorCostoEnvioMenor
    {
        IPaqueteCostoMenor RecuperarDTOCostoMenor(IPaqueteEnviado _dtoPaqueteEnviado);
    }
}
