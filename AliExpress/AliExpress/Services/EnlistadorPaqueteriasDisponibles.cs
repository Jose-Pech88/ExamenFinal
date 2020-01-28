using AliExpress.Services.Factory.Interfaces;
using AliExpress.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace AliExpress.Services
{
    public class EnlistadorPaqueteriasDisponibles : IEnlistadorPaqueteriaDisponibles
    {
        private readonly IRecuperadorTransportistas RecuperadorTransportistas;
        public EnlistadorPaqueteriasDisponibles(IRecuperadorTransportistas _recuperadorTransportistas)
        {
            RecuperadorTransportistas = _recuperadorTransportistas ?? throw new ArgumentNullException(nameof(_recuperadorTransportistas));
        }
        public List<ITransportistas> obtenerListadoTransportistas()
        {
            List<ITransportistas> lstTransportistas = new List<ITransportistas>();
            lstTransportistas.Add(RecuperadorTransportistas.ObtenerTransportista("DHL"));
            lstTransportistas.Add(RecuperadorTransportistas.ObtenerTransportista("Estafeta"));
            lstTransportistas.Add(RecuperadorTransportistas.ObtenerTransportista("Fedex"));
            return lstTransportistas;
        }
    }
}
