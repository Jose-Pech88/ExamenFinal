using AliExpress.Services.Interfaces;

namespace AliExpress.Services
{
    public class MedioTransporteBarco : IMediosTransportes
    {
        public decimal dCostoKilometroPesos
        {
            get { return 1; }
        }
        public double dVelocidadEntrega
        {
            get { return 46; }
        }
        public string cMedioTransporte
        {
            get { return "Barco"; }
        }
        public decimal ObtenerCostoEnvio(decimal dDistancia, decimal _dMargenUtilidad)
        {
            decimal dCostoEnvio = 0;
            dCostoEnvio = (dDistancia * dCostoKilometroPesos) * (1 + (_dMargenUtilidad / 100));
            return dCostoEnvio;
        }
    }
}
