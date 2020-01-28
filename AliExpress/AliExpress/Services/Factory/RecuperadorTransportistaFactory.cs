using AliExpress.Data.Entities.Interfaces;
using AliExpress.Services.Factory.Interfaces;
using AliExpress.Services.Interfaces;
using System;

namespace AliExpress.Services.Factory
{
    public class RecuperadorTransportistaFactory : IRecuperadorTransportistas
    {
        private readonly IRecuperadorConfiguracionTransportista RecuperadorConfiguracionTransportista;
        private readonly IGeneradorMensajes GeneradorMensajes;
        public RecuperadorTransportistaFactory(IRecuperadorConfiguracionTransportista _recuperadorConfiguracionTransportista, IGeneradorMensajes _generadorMensajes)
        {
            RecuperadorConfiguracionTransportista = _recuperadorConfiguracionTransportista ?? throw new ArgumentNullException(nameof(_recuperadorConfiguracionTransportista));
            GeneradorMensajes = _generadorMensajes ?? throw new ArgumentNullException(nameof(_generadorMensajes));
        }
        public ITransportistas ObtenerTransportista(string _cTransportista)
        {
            ITransportistas transportista = null;
            switch (_cTransportista.ToUpper())
            {
                case "DHL":
                    transportista = new PaqueteriaDHLStrategy(GeneradorMensajes);
                    transportista.lstMediosTransporte = RecuperadorConfiguracionTransportista.ObtenerConfiguracionDHL();
                    break;
                case "FEDEX":
                    transportista = new PaqueteriaFedexStrategy(GeneradorMensajes);
                    transportista.lstMediosTransporte = RecuperadorConfiguracionTransportista.ObtenerConfiguracionFedex();
                    break;
                case "ESTAFETA":
                    transportista = new PaqueteriaEstafetaStrategy(GeneradorMensajes);
                    transportista.lstMediosTransporte = RecuperadorConfiguracionTransportista.ObtenerConfiguracionEstafeta();
                    break;
                default:                    
                    break;
            }
            return transportista;
        }
    }
}
