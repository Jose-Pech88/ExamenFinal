using AliExpress.Services.Interfaces;

namespace AliExpress.Services
{
    public class MedioTransporteAvion : IMediosTransportes
    {
        public decimal dCostoKilometroPesos
        {
            get { return 10; }
        }
        public double dVelocidadEntrega
        {
            get { return 600; }
        }
        public string cMedioTransporte
        {
            get { return "Avión"; }
        }

        public decimal ObtenerCostoEnvio(decimal dDistancia, decimal _dMargenUtilidad)
        {
            decimal dCostoEnvio = 0;
            dCostoEnvio = (dDistancia * dCostoKilometroPesos) * (1 + (_dMargenUtilidad / 100));
            return dCostoEnvio;
        }
    }
}
