using AliExpress.Data.Entities.Interfaces;
using AliExpress.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliExpress.Services
{
    public class PaqueteriaEstafetaStrategy : ITransportistas
    {
        public List<IMediosTransportes> lstMediosTransporte { get; set; }
        public decimal dMargenUtilidad { get { return 20; } }
        public string cPaqueteria { get { return "Estafeta"; } }
        private readonly IGeneradorMensajes GeneradorMensajes;
        public PaqueteriaEstafetaStrategy(IGeneradorMensajes _generadorMensajes)
        {
            this.GeneradorMensajes = _generadorMensajes ?? throw new ArgumentNullException(nameof(_generadorMensajes));
        }
        public bool ProcesarDTOPaqueteEnviado(IPaqueteEnviado _dtoPaqueteEnviado)
        {
            bool lReturn = true;
            if (_dtoPaqueteEnviado == null)
                throw new ArgumentNullException(nameof(_dtoPaqueteEnviado));
            IMediosTransportes mediosTransportes = ObtenerTransportista(_dtoPaqueteEnviado.cMedioTransporte);
            if (mediosTransportes == null)
            {
                GeneradorMensajes.GenerarMensajeMedioInexistente(_dtoPaqueteEnviado.cPaqueteria, _dtoPaqueteEnviado.cMedioTransporte);
                lReturn = false;
            }
            else
            {
                AsignarFechaEntrega(_dtoPaqueteEnviado, mediosTransportes);
                _dtoPaqueteEnviado.dCostoEnvio = mediosTransportes.ObtenerCostoEnvio(Convert.ToDecimal(_dtoPaqueteEnviado.cDistancia), dMargenUtilidad);
            }
            return lReturn;
        }

        private void AsignarFechaEntrega(IPaqueteEnviado _dtoPaqueteEnviado, IMediosTransportes _mediosTransportes)
        {
            double dTiempoTraslado = Convert.ToDouble(_dtoPaqueteEnviado.cDistancia) / _mediosTransportes.dVelocidadEntrega;
            _dtoPaqueteEnviado.dtFechaEntrega = _dtoPaqueteEnviado.dtFechaPedido.AddHours(dTiempoTraslado);
        }

        private IMediosTransportes ObtenerTransportista(string _cMedioTransporte)
        {
            IMediosTransportes mediosTransportes = null;
            if (lstMediosTransporte != null && lstMediosTransporte.Any())
            {
                mediosTransportes = lstMediosTransporte.Where(x => x.cMedioTransporte.ToUpper() == _cMedioTransporte.ToUpper()).FirstOrDefault();
            }
            return mediosTransportes;
        }
    }
}
