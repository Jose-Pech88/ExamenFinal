using AliExpress.Services.Interfaces;

namespace AliExpress.Services.Factory.Interfaces
{
    public interface IRecuperadorTransportistas
    {
        ITransportistas ObtenerTransportista(string _cTransportista);
    }
}
