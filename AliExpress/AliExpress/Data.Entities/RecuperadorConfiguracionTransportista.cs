using AliExpress.Data.Entities.Interfaces;
using AliExpress.Services;
using AliExpress.Services.Interfaces;
using System.Collections.Generic;

namespace AliExpress.Data.Entities
{
    public class RecuperadorConfiguracionTransportista : IRecuperadorConfiguracionTransportista
    {
        public List<IMediosTransportes> ObtenerConfiguracionDHL()
        {
            List<IMediosTransportes> lstDHL = new List<IMediosTransportes>();
            MedioTransporteAvion avion = new MedioTransporteAvion();
            lstDHL.Add(avion);
            MedioTransporteBarco barco = new MedioTransporteBarco();
            lstDHL.Add(barco);
            return lstDHL;
        }

        public List<IMediosTransportes> ObtenerConfiguracionEstafeta()
        {
            List<IMediosTransportes> lstEstafeta = new List<IMediosTransportes>();
            MedioTransporteTren tren = new MedioTransporteTren();
            lstEstafeta.Add(tren);
            return lstEstafeta;
        }

        public List<IMediosTransportes> ObtenerConfiguracionFedex()
        {
            List<IMediosTransportes> lstFedex = new List<IMediosTransportes>();
            MedioTransporteBarco barco = new MedioTransporteBarco();
            lstFedex.Add(barco);
            return lstFedex;
        }
    }
}
