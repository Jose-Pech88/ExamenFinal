using System;

namespace AliExpress.Services.Interfaces
{
    public interface IRecuperadorExpressionTiempo
    {
        IRecuperadorExpressionTiempo SiguienteNivel(IRecuperadorExpressionTiempo _iRecuperadorExpressionTiempo);
        string ProcesarTiempo(DateTime _dtFechaBase, DateTime _dtFechaEvaluar);
    }
}
