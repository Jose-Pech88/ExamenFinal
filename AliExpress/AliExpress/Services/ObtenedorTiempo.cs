using AliExpress.Services.Interfaces;

namespace AliExpress.Services
{
    public class ObtenedorTiempo : IObtenedorTiempo
    {
        public IRecuperadorExpressionTiempo RecuperarExpresionTiempo()
        {
            ValidadorMinuto validadorMinuto = new ValidadorMinuto();
            ValidadorHora validadorHora = new ValidadorHora();
            ValidadorDia validadorDia = new ValidadorDia();
            ValidadorMes validadorMes = new ValidadorMes();

            validadorMinuto.SiguienteNivel(validadorHora).SiguienteNivel(validadorDia).SiguienteNivel(validadorMes);
            return validadorMinuto;
        }
    }
}
