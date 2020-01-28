namespace AliExpress.Services.Interfaces
{
    public interface IMediosTransportes
    {
        decimal dCostoKilometroPesos { get; }
        double dVelocidadEntrega { get; }
        string cMedioTransporte { get; }
        decimal ObtenerCostoEnvio(decimal dDistancia, decimal _dMargenUtilidad);
    }
}
