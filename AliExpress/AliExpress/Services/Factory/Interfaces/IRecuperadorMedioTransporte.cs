using AliExpress.Services.Interfaces;

namespace AliExpress.Services.Factory.Interfaces
{
    public interface IRecuperadorMedioTransporte
    {
        IMediosTransportes ObtenerInstancia(string _cMedioTransporte);
    }
}
