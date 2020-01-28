using AliExpress.Services.Interfaces;

namespace AliExpress.Services
{
    public class MedioTransporteTren : IMediosTransportes
    {
        public decimal dCostoKilometroPesos
        {
            get { return 5; }
        }
        public double dVelocidadEntrega
        {
            get { return 80; }
        }
        public string cMedioTransporte
        {
            get { return "Tren"; }
        }
        public decimal ObtenerCostoEnvio(decimal dDistancia, decimal _dMargenUtilidad)
        {
            decimal dCostoEnvio = 0;
            dCostoEnvio = (dDistancia * dCostoKilometroPesos) * (1 + (_dMargenUtilidad / 100));
            return dCostoEnvio;
        }
    }
}
