using AliExpress.Data.Entities.DTO;
using AliExpress.Data.Entities.Interfaces;
using AliExpress.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AliExpress.Services
{
    public class ObtenedorCostoEnvioMenor : IObtenedorCostoEnvioMenor
    {
        private readonly IEnlistadorPaqueteriaDisponibles EnlistadorPaqueteriaDisponibles;
        public ObtenedorCostoEnvioMenor(IEnlistadorPaqueteriaDisponibles _enlistadorPaqueteriasDisponibles)
        {
            EnlistadorPaqueteriaDisponibles = _enlistadorPaqueteriasDisponibles ?? throw new ArgumentNullException(nameof(_enlistadorPaqueteriasDisponibles));
        }
        public IPaqueteCostoMenor RecuperarDTOCostoMenor(IPaqueteEnviado _dtoPaqueteEnviado)
        {
            if (_dtoPaqueteEnviado == null)
                throw new ArgumentNullException(nameof(_dtoPaqueteEnviado));
            return ObtenerCostoMenor(_dtoPaqueteEnviado);
        }

        private IPaqueteCostoMenor ObtenerCostoMenor(IPaqueteEnviado _paquete)
        {
            IPaqueteCostoMenor PaqueteCostoMenor = null;
            decimal dCosto = 0;
            List<ITransportistas> lstTransportistas = EnlistadorPaqueteriaDisponibles.obtenerListadoTransportistas();
            IMediosTransportes MediosTransportes = null;
            if (lstTransportistas.Any())
            {
                foreach (ITransportistas item in lstTransportistas.Where(x => x.cPaqueteria.ToUpper() != _paquete.cPaqueteria.ToUpper()))
                {
                    MediosTransportes = item.lstMediosTransporte.Where(x => x.cMedioTransporte.ToUpper() == _paquete.cMedioTransporte.ToUpper()).FirstOrDefault();
                    if (MediosTransportes != null)
                    {
                        dCosto = decimal.MaxValue;
                        dCosto = MediosTransportes.ObtenerCostoEnvio(Convert.ToDecimal(_paquete.cDistancia), item.dMargenUtilidad);
                        if (dCosto < _paquete.dCostoEnvio)
                        {
                            dCosto = _paquete.dCostoEnvio - dCosto;
                            PaqueteCostoMenor = CrearPaqueteCostoMenor(item.cPaqueteria, dCosto);
                        }
                    }
                }
            }
            return PaqueteCostoMenor;
        }
        private IPaqueteCostoMenor CrearPaqueteCostoMenor(string _cPaqueteria, decimal _dCosto)
        {
            IPaqueteCostoMenor PaqueteCostoMenor = new PaqueteCostoMenor();
            PaqueteCostoMenor.Empresa = _cPaqueteria;
            PaqueteCostoMenor.CostoEnvio = _dCosto;
            return PaqueteCostoMenor;
        }
    }
}
